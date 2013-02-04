using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SerialDownload
{
    public partial class Download : Form
    {
        public byte[] picData;
        public byte[] nameData;
        public byte[] depData;
        public byte[] keyID_Data;
        public byte[] infoPkg;
        public int count = 0;
        public SerialPort ComPort = new SerialPort();
        public byte[] ACK = { 0x7e, 0, 0, 0, 0 };
        public byte[] NAK = { 0x7e, 0, 0, 0, 0 };
        public byte[] pkgData = new byte[2055];

        public Download()
        {
            InitializeComponent();
        }

        private Bitmap to16pic(Bitmap img)
        {
            var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb565);
            using (var gr = Graphics.FromImage(bmp))
                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return bmp;
        }

        private short RGB888to565(int R, int G, int B)
        {
            return (short)((((R & 0x0ff) / 8) << 11) | (((G & 0x0ff) / 8) << 6) | ((B & 0x0ff) / 8));
        }

       

        //private short RGB888to565(int R, int G, int B)
        //{
        //    return (short)(((R & 0x01f) << 11) | ((G & 0x03f) << 6) | (B & 0x1f));
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            string filePath = "";
            Stream myStream;
            // Displays an OpenFileDialog so the user can select a Cursor.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "bmp files (*.bmp) | *.bmp";
            openFileDialog1.Title = "Select a BMP File";
            openFileDialog1.RestoreDirectory = true;

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .CUR file was selected, open it.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();

                    filePath = openFileDialog1.FileName.ToString();                    

                    Image image = Image.FromFile(filePath);
                    
                    //PictureBox.Image = image;
                    //PictureBox.Show();

                    //自动调整BMP图片大小为217,252
                    Bitmap bitMap = new Bitmap(image, 128, 171);
                    
                    //显示图片  
                    PictureBox.Image = (Image)bitMap;
                    PictureBox.Show();
                    
                    //转换为16位的图片，貌似没啥用
                    bitMap = to16pic(bitMap);

                    //转换ARGB为RGB565型数据
                    //bitMap.RotateFlip(RotateFlipType.Rotate90FlipX);  //图片旋转90°
                    picData = new byte[bitMap.Width * bitMap.Height * 2];

                    Color imageColor;
                    for (int i = 0; i < bitMap.Height; i++)
                    {
                            for (int j = 0; j < bitMap.Width; j++)
                            {
                                imageColor = bitMap.GetPixel(j, i);
                                picData[count++] = (byte)((RGB888to565(imageColor.R, imageColor.G, imageColor.B) >> 8) & 0x00ff);
                                picData[count++] = (byte)(RGB888to565(imageColor.R, imageColor.G, imageColor.B) & 0x00ff);
                            }
                    }

                }
            }
        }

        private void Download_Load(object sender, EventArgs e)
        {


            string[] sAllPort = null;
            try
            {
                sAllPort = SerialPort.GetPortNames();

            }
            catch (Exception ex)
            {
                throw new Exception("获取计算机COM口列表失败!\r\n错误信息:" + ex.Message);
            }

            for (int i = 0; i < sAllPort.Length; i++)
            {
                this.ComComboBox.Items.Add(sAllPort[i]);
            }

        }


        private void DownloadButton_Click(object sender, EventArgs e)
        {
            
            DownloadProgressBar.Maximum = 100;
            DownloadProgressBar.Value = 0;
            DownloadButton.Enabled = false;
            FileButton.Enabled = false;

            this.ComPort.BaudRate = 115200;

            try
            {
                if (this.ComComboBox.SelectedItem != null)
                {
                    this.ComPort.PortName = this.ComComboBox.SelectedItem.ToString();
                    //ComPort.WriteTimeout = 10;
                    //ComPort.ReadTimeout = 10;
                    if (this.ComPort.IsOpen.Equals(false).Equals(true))
                    {
                        this.ComPort.Open();
                        if (picData != null)
                        {
                            logInfo.Clear();
                            transportPic();
                            transportName();
                            transportDep();
                            transportProfession();
                            transportJobNum();
                            transportKeyID();                            
                            MessageBox.Show("完成下载");
                            DownloadProgressBar.Value = 0;
                        }
                        else
                        {  
                            MessageBox.Show("请选择图片");
                        }
                    }
                    else
                    {
                        MessageBox.Show("串口被占用");
                    }
                }
                else
                {
                    MessageBox.Show("请选择串口");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("获取计算机COM口" + this.ComComboBox.SelectedItem.ToString() + "失败!\r\n错误信息:" + ex.Message);
            }

            this.ComPort.Close();
            DownloadButton.Enabled = true;
            FileButton.Enabled = true;

        }

        private byte[] transportC2Hex(byte[] bitmap, string message)
        {
            List<byte[]> listMsg = new List<byte[]>();

            bitmap[0] = 0xcc;
            bitmap[1] = (byte)message.Length;

            for (int index = 0; index < message.Length; index++)
            {
                //FileStream fsAsc16 = new FileStream("Asc8X16E.dat", FileMode.Open);    //将"ASC16"字库文件读入文件流
                //FileStream fsHzk16 = new FileStream("宋体16.dot", FileMode.Open);    //将"HZK16"字库文件读入文件流
                FileStream fsAsc16 = new FileStream("Asc8X16E.dat", FileMode.Open);    //将"ASC16"字库文件读入文件流
                FileStream fsHzk24 = new FileStream("宋体24.dot", FileMode.Open);    //将"HZK16"字库文件读入文件流

                string s = message.Substring(index, 1);
                if (Convert.ToChar(s) < 256)    //判断是否为中文，小于256为字符
                {
                    //byte[] bMsg = new byte[16];
                    //int offset = 16 * (byte)(s[0]);
                    //fsAsc16.Seek(offset, SeekOrigin.Begin);
                    //fsAsc16.Read(bMsg, 0, 16);
                    //listMsg.Add(bMsg);
                    byte[] bMsg = new byte[2];
                    bMsg[0] = (byte)s[0];
                    bMsg[1] = 0x00;
                    listMsg.Add(bMsg);
                    bitmap[index + 2] = 0xdd;
                }
                else
                {
                    byte[] bMsg = new byte[72];
                    byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(s.ToCharArray());
                    int offset = 72 * (94 * (bytes[0] - 0xA1) + bytes[1] - 0xA1);
                    fsHzk24.Seek(offset, SeekOrigin.Begin);
                    fsHzk24.Read(bMsg, 0, 72);

                    byte[] bMsgH = new byte[36];
                    byte[] bMsgL = new byte[36];
                    int l = 0;
                    int h = 0;
                    for (int j = 0; j < 36 * 2; j++)
                    {
                        if (j < 36)
                            bMsgH[h++] = bMsg[j];
                        else
                            bMsgL[l++] = bMsg[j];
                    }
                    listMsg.Add(bMsgH);
                    listMsg.Add(bMsgL);

                    bitmap[index + 2] = 0xee;
                }

                fsAsc16.Close();
                fsHzk24.Close();
                //fsHzk16.Close();
            }

            //为字节数组排序
            byte[] bMessages = new byte[listMsg.Count * 36];
            for (int i = 0; i < listMsg.Count; i++)
            {
                for (int j = 0; j < listMsg[i].Length; j++)
                {
                    bMessages[i * 36 + j] = listMsg[i][j];
                }
            }

            return bMessages;
        }

        private Boolean checkRecvPkg(byte seq)
        {
            byte[] comData = new byte[10];
            ComPort.Read(comData, 0, 10);

            if (comData[0] != 0x7e)
            {
                return false;
            }
            if (comData[1] != 0x03)
            {
                return false;
            }
            if (comData[2] != seq - 1)
            {
                return false;
            }

            return true;
        }

        private void sendPkg(byte pkgType, byte[] pkg2Send)
        {
            byte seq = 1, lastSeq;
            int i, length = 0;
            byte checksum = 0;
            int lastCount;
            int retransmissionCount = 3;
            count = 0;

            pkgData[0] = 0x7e;
            pkgData[1] = 0x01;
            //logInfo.AppendText("\n");
            //logInfo.AppendText(count.ToString());
            //logInfo.AppendText("\n");
            //logInfo.AppendText(pkg2Send.Length.ToString());
            while (count < pkg2Send.Length)
            {
                if (retransmissionCount < 0)
                {
                    logInfo.AppendText("\n");
                    logInfo.AppendText("传输失败！");
                    break;
                }
                lastCount = count;
                lastSeq = seq;
                //sequence
                pkgData[2] = seq++;

                if ((pkg2Send.Length - count) / 2048 > 0)
                {
                    //length
                    pkgData[3] = 8;
                    pkgData[4] = 1;
                    pkgData[5] = pkgType;
                    checksum += pkgData[5];
                    //data
                    for (i = 0; i < 2048; i++)
                    {
                        pkgData[6 + i] = pkg2Send[count++];
                        checksum += pkgData[6 + i];
                    }
                    //checksum
                    pkgData[6 + i] = checksum;
                    
                }
                else
                {
                    //length
                    pkgData[3] = (byte)(((pkg2Send.Length - count) % 2048) / 256);
                    pkgData[4] = (byte)(((pkg2Send.Length - count) % 2048) % 256 + 1);
                    pkgData[5] = pkgType;
                    checksum += pkgData[5];
                    //data
                    int rest = pkg2Send.Length - count;
                    for (i = 0; i < rest; i++)
                    {
                        pkgData[6 + i] = pkg2Send[count++];
                        checksum += pkgData[6 + i];
                    }
                    //checksum
                    pkgData[6 + i] = checksum;
                    
                }
                
                length = 7 + i;
                for (i = 0; i < length; i++)
                {
                    ComPort.Write(pkgData, i, 1);
                }
                checksum = 0;
                Thread.Sleep(100);
                if (checkRecvPkg(seq) != true)
                {
                    count = lastCount;
                    seq = lastSeq;
                    retransmissionCount--;
                    logInfo.AppendText(".");
                }else
                {
                    logInfo.AppendText(".");
                    //logInfo.AppendText("\n");
                    //logInfo.AppendText(count.ToString());
                    DownloadProgressBar.Value = count * 100 / pkg2Send.Length;
                    DownLoadLable.Text = (count * 100 / pkg2Send.Length).ToString();
                }

            }
        }

        private void transportPic()
        {
            logInfo.AppendText("正在擦除FLASH");
            cleanFlash(1);
                      
            logInfo.AppendText("\n\n");
            logInfo.AppendText("擦除完成！\n");
            logInfo.AppendText("\n\n");
            logInfo.AppendText("下载图片信息");
            sendPkg(1, picData);
            
            finish(1);
        }

        private void transportName()
        {
            cleanFlash(2);

            //MessageBox.Show(NameTextBox.Text);
            string message = "姓名：" + NameTextBox.Text;
            infoPkg = new byte[message.Length + 2];

            nameData = transportC2Hex(infoPkg, message);
            sendPkg(2, infoPkg);

            sendPkg(2, nameData);
            finish(2);
            
        }

        private void transportDep()
        {

            cleanFlash(3);
            string message = "单位：" + DepTextBox.Text;
            infoPkg = new byte[message.Length + 2];

            depData = transportC2Hex(infoPkg, message);
            sendPkg(3, infoPkg);

            sendPkg(3, depData);
            finish(3);
        }

        //字符串转16进制字节数组
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private void transportProfession()
        {
            cleanFlash(4);
            string message = "工种：" + WorkTextBox.Text;
            infoPkg = new byte[message.Length + 2];

            depData = transportC2Hex(infoPkg, message);
            sendPkg(4, infoPkg);

            sendPkg(4, depData);
            finish(4);
        }

        private void transportJobNum()
        {
            cleanFlash(5);
            string message = "工号：" + NumTextBox.Text;
            infoPkg = new byte[message.Length + 2];

            depData = transportC2Hex(infoPkg, message);
            sendPkg(5, infoPkg);

            sendPkg(5, depData);
            finish(5);
        }

        private void transportKeyID()
        {
            cleanFlash(6);
            string message = KeyIDTextBox.Text;

            keyID_Data = strToToHexByte(message);
 
            sendPkg(6, keyID_Data);
            finish(6);
        }

        private void finish(byte type)
        {
            int length = 0;
            byte checksum = 0;
            byte i = 3, j = 0;

            while (i-- > 0)
            {
                pkgData[0] = 0x7e;
                pkgData[1] = 0x02;
                //seq
                pkgData[2] = 0x00;
                //length
                pkgData[3] = 0x00;
                pkgData[4] = 0x01;
                //data
                pkgData[5] = type;
                //checksum
                pkgData[6] = checksum;

                length = 7;

                for (j = 0; j < length; j++)
                {
                    ComPort.Write(pkgData, j, 1);
                }
                Thread.Sleep(100);
                if (checkRecvPkg(1) == true)
                {
                    i = 0;
                }
            }
        }

        private void cleanFlash(byte type)
        {
            int length = 0;
            byte checksum = 0;
            byte i = 3, j = 0;

            while (i-- > 0)
            {
                pkgData[0] = 0x7e;
                pkgData[1] = 0x05;
                //seq
                pkgData[2] = 0x00;
                //length
                pkgData[3] = 0x00;
                pkgData[4] = 0x01;
                //data
                pkgData[5] = type;
                //checksum
                pkgData[6] = checksum;

                length = 7;

                for (j = 0; j < length; j++)
                {
                    ComPort.Write(pkgData, j, 1);
                }
                Thread.Sleep(1000);
                if (checkRecvPkg(1) == true)
                {
                    i = 0;
                }
            }
        }

    }
}
