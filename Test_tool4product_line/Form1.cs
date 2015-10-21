using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BarcodeLib;

namespace Test_tool4product_line
{
    public partial class Form1 : Form
    {
        USBHID usbHID = null;
        USBHID usbHIDreality = null;
        Thread enumdevice;
        public int cid;
        public Form1()
        {
            InitializeComponent();
            
            enumdevice = new Thread(hid_discovery);
            enumdevice.Start();
        }
        private void hid_discovery()
        {
            while (true)
            {
                usbHID = new USBHID();
                #region add HID dev into listbox
                foreach (string device in usbHID.GetDeviceList())
                {
                    if ((device.IndexOf("vid_0451") >= 0) && (device.IndexOf("pid_16b4") >= 0))
                    {
                        string idx = device.Substring(device.IndexOf("pid_16b4")+11,1);
                        this.lb_hiddevice.Invoke((MethodInvoker)delegate()
                        {
                            updatedevlist(idx+"号设备--"+device);
                        });                        
                    }
                }
                #endregion

                Thread.Sleep(5000);
                this.lb_hiddevice.Invoke((MethodInvoker)delegate()
                {
                    cleardevlist(); 
                });                
            }

        }
        private void updatedevlist(string str)
        {
            lb_hiddevice.Items.Add(str); 
        }
        private void cleardevlist()
        {
            lb_hiddevice.Items.Clear();            
        }

        private void bt_teststart_Click(object sender, EventArgs e)
        {

            if (bt_teststart.Text.ToString() == "连接设备")
            {
                usbHIDreality = usbHID;
                if (lb_hiddevice.SelectedItem == null)
                {
                    MessageBox.Show("请从设备列表中选择设备");
                    return;
                }

                #region Initial UI
                bt_teststart.Text = "断开连接";
                lb_ttstatus.Text = "测试工具运行中";
                #endregion

                string conndev=this.lb_hiddevice.SelectedItem.ToString().Substring(6);
                if (usbHIDreality.OpenUSBHid(conndev))
                {
                    string idx = conndev.Substring(conndev.IndexOf("pid_16b4") + 11, 1);
                    this.gb_dev1.Text = idx + "号设备";
                    this.lb_dev1_status.Text = "已连接";
                    usbHIDreality.DataReceived += usbHID_DataReceived;
                    usbHIDreality.DeviceRemoved += usbHID_DeviceRemoved;
                }
                else
                    this.lb_dev1_status.Text = "连接失败";
                
            }
            else 
            {
                bt_teststart.Text = "连接设备";
                lb_ttstatus.Text = "测试工具等待中";
                this.lb_dev1_rlt.Text = "测试结果";
                lb_dev1_rlt.ForeColor = Color.Blue;
                this.lb_dev1_status.Text = "等待连接";
                lib_dev1_ng.Items.Clear();
                this.pb_dev1_barcode.Image = null;

                //enumdevice.Abort();
                try
                {
                     usbHIDreality.CloseDevice();
                }
                catch (Exception err)
                {
                    err.ToString();
                }
            }        
        }
        
        private void usbHID_DeviceRemoved(object sender, EventArgs e)
        {
            //report myRP = (report)e;
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usbHID_DeviceRemoved), new object[] { sender, e });
            }
            else
            {
                lb_ttstatus.Text = "设备移除";
                bt_teststart.Text = "连接设备";
                this.lb_dev1_rlt.Text = "测试结果";
                lb_dev1_rlt.ForeColor = Color.Blue;
                this.lb_dev1_status.Text = "等待连接";
                lib_dev1_ng.Items.Clear();
                this.pb_dev1_barcode.Image = null;

                enumdevice.Abort();
                try
                {
                    usbHIDreality.CloseDevice();
                }
                catch (Exception err)
                {
                    err.ToString();
                }
            }
        }

        private void usbHID_DataReceived(object sender, EventArgs e)
        {
            report myRP = (report)e;
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usbHID_DataReceived), new object[] { sender, e });
            }
            else
            {
                lib_dev1_ng.Items.Clear();
                //if (myRP.reportBuff[0] == 0x00)
                if ((myRP.reportBuff[0] & 0x27) == 0x00)
                {
                    lb_dev1_rlt.Text = "OK"+" , -"+Convert.ToString((int)(myRP.reportBuff[7]-128))+"dB";
                    lb_dev1_rlt.ForeColor = Color.Green;
                }
                else
                {
                    lb_dev1_rlt.Text = "NG";
                    lb_dev1_rlt.ForeColor = Color.Red;
                    if ((myRP.reportBuff[0] & 0x01) == 0x01)
                    {
                        lib_dev1_ng.Items.Add("Flash ID错误");
                    }
                    if ((myRP.reportBuff[0] & 0x02) == 0x02)
                    {
                        lib_dev1_ng.Items.Add("Flash 读写错误");
                    }
                    if ((myRP.reportBuff[0] & 0x04) == 0x04)
                    {
                        lib_dev1_ng.Items.Add("G-sensor ID错误");
                    }
                    if ((myRP.reportBuff[0] & 0x08) == 0x08)
                    {
                        lib_dev1_ng.Items.Add("G-sensor 自检失败");
                    }
                    /*if ((myRP.reportBuff[0] & 0x10) == 0x10)
                    {
                        lib_dev1_ng.Items.Add("PPG传感器错误");
                    }*/
                    if ((myRP.reportBuff[0] & 0x20) == 0x20)
                    {
                        lib_dev1_ng.Items.Add("ADC错误");
                    }
                    /*if ((myRP.reportBuff[0] & 0x40) == 0x40)
                    {
                        lib_dev1_ng.Items.Add("PPG电流检测失败");
                    }
                    if ((myRP.reportBuff[0] & 0x80) == 0x80)
                    {
                        lib_dev1_ng.Items.Add("没有检测到充电状态");
                    }*/
                }
                byte[] byte_macaddr = new byte[6];
                for (cid = 0; cid < 6; cid++)
                {
                    byte_macaddr[cid] = myRP.reportBuff[6 - cid];
                }
                string str_macaddr = USBHID.ByteToHexString(byte_macaddr);
                this.pb_dev1_barcode.Image = null;
                System.Drawing.Image image;
                int width = pb_dev1_barcode.Size.Width, height = pb_dev1_barcode.Size.Height;
                string fileSavePath = AppDomain.CurrentDomain.BaseDirectory + "barcode.jpg";
                GetBarcode(height, width, BarcodeLib.TYPE.CODE128, str_macaddr, out image, fileSavePath);

                this.pb_dev1_barcode.Image = Image.FromFile("barcode.jpg");
            }
        }

        public static void GetBarcode(int height, int width, BarcodeLib.TYPE type, string code, out System.Drawing.Image image, string fileSaveUrl)
        {
            try
            {
                image = null;
                
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.BackColor = System.Drawing.Color.White;//图片背景颜色
                b.ForeColor = System.Drawing.Color.Black;//条码颜色
                b.IncludeLabel = true;
                b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;//code的显示位置
                b.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;//图片格式
                System.Drawing.Font font = new System.Drawing.Font("verdana", 10f);//字体设置
                b.LabelFont = font;
                b.Height = height;//图片高度设置(px单位)
                b.Width = width;//图片宽度设置(px单位)

                image = b.Encode(type, code);//生成图片
                image.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception err)
            {
                err.ToString();
                image = null;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            enumdevice.Abort();
        }
    }
}
