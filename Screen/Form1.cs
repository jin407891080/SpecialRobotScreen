using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Runtime.InteropServices;

namespace Screen
{
    public partial class Form1 : Form
    {
        Point oldPoint;
        int oldWidth = 0;
        int oldHeight = 0;
        int oldZIndex = 0;
        bool isMax = false;
        int count = 0;
        private bool m_bInitSDK = false;
        private Int32 m_lUserID1 = -1;
        private Int32 m_lUserID2 = -1;
        private Int32 m_lUserID3 = -1;
        private Int32 m_lUserID4 = -1;
        private Int32 m_lUserID5 = -1;
        private Int32 m_lRealHandle1 = -1;
        private Int32 m_lRealHandle2 = -1;
        private Int32 m_lRealHandle3 = -1;
        private Int32 m_lRealHandle4 = -1;
        private Int32 m_lRealHandle5 = -1;
        private bool m_bRecord1 = false;
        private bool m_bRecord2 = false;
        private bool m_bRecord3 = false;
        private bool m_bRecord4 = false;
        private bool m_bRecord5 = false;


        public struct CopyDataStruct
        {
            public IntPtr dwData;
            public int cbData;

            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        private const int WM_COPYDATA = 0x004A;

        //接收消息方法
        protected override void WndProc(ref System.Windows.Forms.Message e)
        {
            if (e.Msg == WM_COPYDATA)
            {
                CopyDataStruct cds = (CopyDataStruct)e.GetLParam(typeof(CopyDataStruct));
                switch (cds.lpData)
                {
                    case "1":
                        if (m_lRealHandle1 != -1)
                        {
                            PanelSizeLarge(panel1);
                        }
                        else if (m_lRealHandle1 == -1)
                        {
                            ShowVideo1();
                        }
                        break;
                    case "2":
                        if (m_lRealHandle2 != -1)
                        {
                            PanelSizeLarge(panel2);
                        }
                        else if (m_lRealHandle2 == -1)
                        {
                            ShowVideo2();
                        }
                        break;
                    case "3":
                        if (m_lRealHandle3 != -1)
                        {
                            PanelSizeLarge(panel3);
                        }
                        else if (m_lRealHandle3 == -1)
                        {
                            ShowVideo3();
                        }
                        break;
                    case "4":
                        if (m_lRealHandle4 != -1)
                        {
                            PanelSizeLarge(panel4);
                        }
                        else if (m_lRealHandle4 == -1)
                        {
                            ShowVideo4();
                        }
                        break;
                    case "5":
                        {
                            if (count == 1)
                                PanelSizeSmall(panel1);
                            else if (count == 2)
                                PanelSizeSmall(panel2);
                            else if (count == 3)
                                PanelSizeSmall(panel3);
                            else if (count == 4)
                                PanelSizeSmall(panel4);
                            break;
                        }
                    case "6":
                        {
                            if (m_lRealHandle1 != -1 && m_bRecord1 == false)   //确保视频开启成功
                            {
                                string videofile1 = @"录像视频\video1.mp4";
                                //强制I帧 Make one key frame
                                //通道号 Channel number
                                CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID1, 1);

                                //开始录像 Start recording
                                if (!CHCNetSDK.NET_DVR_SaveRealData(m_lRealHandle1, videofile1))
                                {
                                    return;
                                }
                                m_bRecord1 = true;
                            }
                            else if (m_lRealHandle1 != -1 && m_bRecord1 == true)
                            {
                                //停止录像 Stop recording
                                if (!CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle1))
                                {
                                    return;
                                }
                                m_bRecord1 = false;
                            }
                            break;
                        }
                    case "7":
                        {
                            if (m_lRealHandle2 != -1 && m_bRecord2 == false)   //确保视频开启成功
                            {
                                string videofile2 = @"录像视频\video2.mp4";
                                //强制I帧 Make one key frame
                                //通道号 Channel number
                                CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID2, 1);

                                //开始录像 Start recording
                                if (!CHCNetSDK.NET_DVR_SaveRealData(m_lRealHandle2, videofile2))
                                {
                                    return;
                                }
                                m_bRecord2 = true;
                            }
                            else if (m_lRealHandle2 != -1 && m_bRecord2 == true)
                            {
                                //停止录像 Stop recording
                                if (!CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle2))
                                {
                                    return;
                                }
                                m_bRecord2 = false;
                            }
                            break;
                        }
                    case "8":
                        {
                            if (m_lRealHandle3 != -1 && m_bRecord3 == false)   //确保视频开启成功
                            {
                                string videofile3 = @"录像视频\video3.mp4";
                                //强制I帧 Make one key frame
                                //通道号 Channel number
                                CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID3, 1);

                                //开始录像 Start recording
                                if (!CHCNetSDK.NET_DVR_SaveRealData(m_lRealHandle3, videofile3))
                                {
                                    return;
                                }
                                m_bRecord3 = true;

                            }
                            else if (m_lRealHandle3 != -1 && m_bRecord3 == true)
                            {
                                //停止录像 Stop recording
                                if (!CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle3))
                                {
                                    return;
                                }
                                m_bRecord3 = false;
                            }
                            break;
                        }
                    case "9":
                        {
                            if (m_lRealHandle4 != -1 && m_bRecord4 == false)   //确保视频开启成功
                            {
                                string videofile4 = @"录像视频\video4.mp4";
                                //强制I帧 Make one key frame
                                //通道号 Channel number
                                CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID4, 1);

                                //开始录像 Start recording
                                if (!CHCNetSDK.NET_DVR_SaveRealData(m_lRealHandle4, videofile4))
                                {
                                    return;
                                }
                                m_bRecord4 = true;

                            }
                            else if (m_lRealHandle4 != -1 && m_bRecord4 == true)
                            {
                                //停止录像 Stop recording
                                if (!CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle4))
                                {
                                    return;
                                }
                                m_bRecord4 = false;
                            }
                            break;
                        }
                    case "10":
                        {

                            break;
                        }
                    case "11":
                        {
                            if (m_lRealHandle5 != -1 && m_bRecord5 == false)   //确保视频开启成功
                            {
                                string videofile5 = @"录像视频\video5.mp4";
                                //强制I帧 Make one key frame
                                //通道号 Channel number
                                CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID5, 1);

                                //开始录像 Start recording
                                if (!CHCNetSDK.NET_DVR_SaveRealData(m_lRealHandle5, videofile5))
                                {
                                    return;
                                }
                                m_bRecord5 = true;

                            }
                            else if (m_lRealHandle5 != -1 && m_bRecord5 == true)
                            {
                                //停止录像 Stop recording
                                if (!CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle5))
                                {
                                    return;
                                }
                                m_bRecord5 = false;
                            }
                            break;

                        }
                    case "12":
                        {
                            if (m_lRealHandle1 != -1)
                            {
                                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle1))
                                {
                                    return;
                                }
                                m_lRealHandle1 = -1;
                            }
                            if (!CHCNetSDK.NET_DVR_Logout(m_lUserID1))
                            {
                                return;
                            }
                            m_lUserID1 = -1;
                            this.panel1.BackColor = System.Drawing.Color.Gray;
                            break;

                        }
                    case "13":
                        {
                            if (m_lRealHandle2 != -1)
                            {
                                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle2))
                                {
                                    return;
                                }
                                m_lRealHandle2 = -1;
                            }
                            if (!CHCNetSDK.NET_DVR_Logout(m_lUserID2))
                            {
                                return;
                            }
                            m_lUserID2 = -1;
                            this.panel2.BackColor = System.Drawing.Color.Yellow;
                            break;

                        }
                    case "14":
                        {
                            if (m_lRealHandle3 != -1)
                            {
                                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle3))
                                {
                                    return;
                                }
                                m_lRealHandle3 = -1;
                            }
                            if (!CHCNetSDK.NET_DVR_Logout(m_lUserID3))
                            {
                                return;
                            }
                            m_lUserID3 = -1;
                            this.panel3.BackColor = System.Drawing.Color.Blue;
                            break;

                        }
                    case "15":
                        {
                            if (m_lRealHandle4 != -1)
                            {
                                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle4))
                                {
                                    return;
                                }
                                m_lRealHandle4 = -1;
                            }
                            if (!CHCNetSDK.NET_DVR_Logout(m_lUserID4))
                            {
                                return;
                            }
                            m_lUserID4 = -1;
                            this.panel4.BackColor = System.Drawing.Color.Red;
                            break;

                        }
                    case "16":
                        {

                            break;

                        }
                    default:
                        break;
                }
            }
            base.WndProc(ref e);
        }
        public Form1()
        {
            showOnMonitor(1);
            InitializeComponent();
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                return;
            }

        }
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }
        private void PanelSizeSmall(Panel thisPanel)
        {
            if (isMax)//缩小
            {
                thisPanel.Location = oldPoint;
                thisPanel.Height = oldHeight;
                thisPanel.Width = oldWidth;
                this.Controls.SetChildIndex(thisPanel, oldZIndex);
                isMax = false;
                count = 0;
            }
        }
        private void PanelSizeLarge(Panel thisPanel)
        {
            if (!isMax)
            {
                oldPoint = thisPanel.Location;
                oldHeight = thisPanel.Height;
                oldWidth = thisPanel.Width;
                oldZIndex = this.Controls.GetChildIndex(thisPanel);
                thisPanel.Location = new Point(0, 0);
                thisPanel.Height = thisPanel.Parent.Height;
                thisPanel.Width = thisPanel.Parent.Width;
                this.Controls.SetChildIndex(thisPanel, 100);
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i] is Panel)
                    {
                        this.Controls.SetChildIndex(this.Controls[i], 0);
                    }
                }
                isMax = true;
                if (thisPanel == panel1)
                { count = 1; }
                else if (thisPanel == panel2)
                { count = 2; }
                else if (thisPanel == panel3)
                { count = 3; }
                else if (thisPanel == panel4)
                { count = 4; }
            }
        }

        private void showOnMonitor(int showOnMonitor)
        {
            System.Windows.Forms.Screen[] sc;
            sc = System.Windows.Forms.Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.  
            // this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }
        private void ShowVideo1()
        {
            string DVRIPAddress = "192.168.1.63"; //设备IP地址或者域名
            Int16 DVRPortNumber = 8000;//设备服务端口号
            string DVRUserName = "admin";//设备登录用户名
            string DVRPassword = "admin123";//设备登录密码
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo1 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            m_lUserID1 = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo1);
            if (m_lUserID1 < 0)
            {
                return;
            }
            //uint len = 0;
            //CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30 struParams = new CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30();//实例化参数结构体
            //Int32 nSize = Marshal.SizeOf(struParams);  //获取结构体空间大小
            //IntPtr ptrCfg = Marshal.AllocHGlobal(nSize); //设置指针大小
            //CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID1, 1040, 1, ptrCfg, (uint)nSize, ref len);//106代表获取压缩参数
            //struParams = (CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30)Marshal.PtrToStructure(ptrCfg, typeof(CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30));//指针转换为结构体
            //struParams.struNetPara.byStreamType = 0;
            //struParams.struNetPara.byResolution = 2;
            //struParams.struNetPara.byBitrateType = 1;
            //struParams.struNetPara.byPicQuality = 5;
            //struParams.struNetPara.dwVideoBitrate = 4;
            //struParams.struNetPara.dwVideoFrameRate = 13;
            //struParams.struNetPara.byVideoEncType = 1;
            //Marshal.StructureToPtr(struParams, ptrCfg, false);//结构体转换为指针
            //CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID1, 1041, 1, ptrCfg, (uint)nSize);//设置参数
            //Marshal.FreeHGlobal(ptrCfg);//释放指针
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo.hPlayWnd = panel1.Handle;//预览窗口
            lpPreviewInfo.lChannel = 1;//预te览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

            CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            IntPtr pUser1 = new IntPtr();//用户数据
            m_lRealHandle1 = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID1, ref lpPreviewInfo, null/*RealData*/, pUser1);
            if (m_lRealHandle1 < 0)
            {
                return;
            }
        }
        private void ShowVideo2()
        {
            string DVRIPAddress = "192.168.1.67"; //设备IP地址或者域名
            Int16 DVRPortNumber = 8200;//设备服务端口号
            string DVRUserName = "admin";//设备登录用户名
            string DVRPassword = "admin123";//设备登录密码
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo2 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            m_lUserID2 = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo2);
            if (m_lUserID2 < 0)
            {
                return;
            }
            //uint len = 0;
            //CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30 struParams = new CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30();//实例化参数结构体
            //Int32 nSize = Marshal.SizeOf(struParams);  //获取结构体空间大小
            //IntPtr ptrCfg = Marshal.AllocHGlobal(nSize); //设置指针大小
            //CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID2, 1040, 1, ptrCfg, (uint)nSize, ref len);//106代表获取压缩参数
            //struParams = (CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30)Marshal.PtrToStructure(ptrCfg, typeof(CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30));//指针转换为结构体
            //struParams.struNetPara.byStreamType = 0;
            //struParams.struNetPara.byResolution = 2;
            //struParams.struNetPara.byBitrateType = 1;
            //struParams.struNetPara.byPicQuality = 5;
            //struParams.struNetPara.dwVideoBitrate = 4;
            //struParams.struNetPara.dwVideoFrameRate = 13;
            //struParams.struNetPara.byVideoEncType = 1;
            //Marshal.StructureToPtr(struParams, ptrCfg, false);//结构体转换为指针
            //CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID2, 1041, 1, ptrCfg, (uint)nSize);//设置参数
            //Marshal.FreeHGlobal(ptrCfg);//释放指针
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo2 = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo2.hPlayWnd = panel2.Handle;//预览窗口
            lpPreviewInfo2.lChannel = 1;//预te览的设备通道
            lpPreviewInfo2.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo2.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo2.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            //public const int NET_DVR_PLAY_FORWARD = 29;//倒放切换为正放

            CHCNetSDK.REALDATACALLBACK RealData2 = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            IntPtr pUser2 = new IntPtr();//用户数据
            m_lRealHandle2 = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID2, ref lpPreviewInfo2, null/*RealData*/, pUser2);
            if (m_lRealHandle2 < 0)
            {
                return;
            }
        }
        private void ShowVideo3()
        {
            string DVRIPAddress = "192.168.1.65"; //设备IP地址或者域名
            Int16 DVRPortNumber = 8100;//设备服务端口号
            string DVRUserName = "admin";//设备登录用户名
            string DVRPassword = "admin123";//设备登录密码
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo3 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            m_lUserID3 = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo3);
            if (m_lUserID3 < 0)
            {
                return;
            }
            //uint len = 0;
            //CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30 struParams = new CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30();//实例化参数结构体
            //Int32 nSize = Marshal.SizeOf(struParams);  //获取结构体空间大小
            //IntPtr ptrCfg = Marshal.AllocHGlobal(nSize); //设置指针大小
            //CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID2, 1040, 1, ptrCfg, (uint)nSize, ref len);//106代表获取压缩参数
            //struParams = (CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30)Marshal.PtrToStructure(ptrCfg, typeof(CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30));//指针转换为结构体
            //struParams.struNetPara.byStreamType = 0;
            //struParams.struNetPara.byResolution = 2;
            //struParams.struNetPara.byBitrateType = 1;
            //struParams.struNetPara.byPicQuality = 5;
            //struParams.struNetPara.dwVideoBitrate = 4;
            //struParams.struNetPara.dwVideoFrameRate = 13;
            //struParams.struNetPara.byVideoEncType = 1;
            //Marshal.StructureToPtr(struParams, ptrCfg, false);//结构体转换为指针
            //CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID2, 1041, 1, ptrCfg, (uint)nSize);//设置参数
            //Marshal.FreeHGlobal(ptrCfg);//释放指针
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo3 = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo3.hPlayWnd = panel3.Handle;//预览窗口
            lpPreviewInfo3.lChannel = 1;//预te览的设备通道
            lpPreviewInfo3.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo3.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo3.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            //public const int NET_DVR_PLAY_FORWARD = 29;//倒放切换为正放

            CHCNetSDK.REALDATACALLBACK RealData3 = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            IntPtr pUser3 = new IntPtr();//用户数据
            m_lRealHandle3 = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID3, ref lpPreviewInfo3, null/*RealData*/, pUser3);
            if (m_lRealHandle3 < 0)
            {
                return;
            }
        }
        private void ShowVideo4()
        {
            string DVRIPAddress = "192.168.1.69"; //设备IP地址或者域名
            Int16 DVRPortNumber = 8300;//设备服务端口号h
            string DVRUserName = "admin";//设备登录用户名
            string DVRPassword = "robot123";//设备登录密码
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo4 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            m_lUserID4 = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo4);
            if (m_lUserID4 < 0)
            {
                return;
            }
            //uint len = 0;
            //CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30 struParams = new CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30();//实例化参数结构体
            //Int32 nSize = Marshal.SizeOf(struParams);  //获取结构体空间大小
            //IntPtr ptrCfg = Marshal.AllocHGlobal(nSize); //设置指针大小
            //CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID4, 1040, 1, ptrCfg, (uint)nSize, ref len);//106代表获取压缩参数
            //struParams = (CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30)Marshal.PtrToStructure(ptrCfg, typeof(CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30));//指针转换为结构体
            //struParams.struNetPara.byStreamType = 0;
            //struParams.struNetPara.byResolution = 2;
            //struParams.struNetPara.byBitrateType = 1;
            //struParams.struNetPara.byPicQuality = 5;
            //struParams.struNetPara.dwVideoBitrate = 4;
            //struParams.struNetPara.dwVideoFrameRate = 13;
            //struParams.struNetPara.byVideoEncType = 1;
            //Marshal.StructureToPtr(struParams, ptrCfg, false);//结构体转换为指针
            //CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID4, 1041, 1, ptrCfg, (uint)nSize);//设置参数
            //Marshal.FreeHGlobal(ptrCfg);//释放指针
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo4 = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo4.hPlayWnd = panel4.Handle;//预览窗口
            lpPreviewInfo4.lChannel = 1;//预te览的设备通道
            lpPreviewInfo4.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo4.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo4.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            CHCNetSDK.REALDATACALLBACK RealData4 = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            IntPtr pUser4 = new IntPtr();//用户数据
            m_lRealHandle4 = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID4, ref lpPreviewInfo4, null/*RealData*/, pUser4);
            if (m_lRealHandle4 < 0)
            {
                return;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowVideo1();
            ShowVideo2();
            ShowVideo3();
            ShowVideo4();

            //string DVRIPAddress = "192.168.1.63"; //设备IP地址或者域名
            //Int16 DVRPortNumber = 7800;//设备服务端口号
            //string DVRUserName = "admin";//设备登录用户名
            //string DVRPassword = "admin123";//设备登录密码
            //CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo2 = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            //m_lUserID2 = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo2);
            //if (m_lUserID2 < 0)
            //{
            //    return;
            //}
            //uint len = 0;
            //CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30 struParams = new CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30();//实例化参数结构体
            //Int32 nSize = Marshal.SizeOf(struParams);  //获取结构体空间大小
            //IntPtr ptrCfg = Marshal.AllocHGlobal(nSize); //设置指针大小
            //CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID2, 1040, 1, ptrCfg, (uint)nSize, ref len);//106代表获取压缩参数
            //struParams = (CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30)Marshal.PtrToStructure(ptrCfg, typeof(CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30));//指针转换为结构体
            //struParams.struNetPara.byStreamType = 0;
            //struParams.struNetPara.byResolution = 2;
            //struParams.struNetPara.byBitrateType = 1;
            //struParams.struNetPara.byPicQuality = 5;
            //struParams.struNetPara.dwVideoBitrate = 4;
            //struParams.struNetPara.dwVideoFrameRate = 13;
            //struParams.struNetPara.byVideoEncType = 1;
            //Marshal.StructureToPtr(struParams, ptrCfg, false);//结构体转换为指针
            //CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID2, 1041, 1, ptrCfg, (uint)nSize);//设置参数
            //Marshal.FreeHGlobal(ptrCfg);//释放指针
            //CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo2 = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            //lpPreviewInfo2.hPlayWnd = panel2.Handle;//预览窗口
            //lpPreviewInfo2.lChannel = 1;//预te览的设备通道
            //lpPreviewInfo2.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            //lpPreviewInfo2.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            //lpPreviewInfo2.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            ////public const int NET_DVR_PLAY_FORWARD = 29;//倒放切换为正放

            //CHCNetSDK.REALDATACALLBACK RealData2 = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            //IntPtr pUser2 = new IntPtr();//用户数据
            //m_lRealHandle2 = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID2, ref lpPreviewInfo2, null/*RealData*/, pUser2);
            //if (m_lRealHandle2 < 0)
            //{
            //    return;
            //}
        }


    }
}
