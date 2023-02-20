using MFORMATSLib;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UI
{
    public partial class Form1 : Form
    {
        private MFPreviewClass m_objPreview;
        private MFLiveClass m_objLive;
        private Thread m_threadWorker;	//Working thread
        private bool m_bWork;
        private CancellationTokenSource cancelSource;
        private int m_webcamIdx = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objPreview = new MFPreviewClass();
            try
            {
                m_objLive = new MFLiveClass();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MLive device not found\n\n" + ex.ToString());
            }
            //Configure preview
            m_objPreview.PreviewWindowSet("", panel1.Handle.ToInt32());
            m_objPreview.PreviewEnable("", 1, 1);

            //Fill live devices
            FindWebCamDeviceIdx();
            SelectWebCam();
            initWebCam();

            // Create & config background worker
            cancelSource = new CancellationTokenSource();
            m_threadWorker = new Thread(() => thread_DoWork(cancelSource.Token));
            m_threadWorker.Name = "thread_DoWork";
            m_threadWorker.Start();

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;   //Need for use renderersCombobox in multithreading 

        }

        private void FindWebCamDeviceIdx()
        {
            int vCount;
            try
            {
                m_objLive = new MFLiveClass();

                m_objLive.DeviceGetCount(eMFDeviceType.eMFDT_Video, out vCount);

                for (int i = 0; i < vCount; i++)
                {
                    string strName;
                    int _pbBusy;
                    m_objLive.DeviceGetByIndex(eMFDeviceType.eMFDT_Video, i, out strName, out _pbBusy);
                    Debug.WriteLine(strName);
                    if (strName.Contains("WebCam", StringComparison.OrdinalIgnoreCase))
                        m_webcamIdx = i;
                }
            }
            catch { }
        }

        private void SelectWebCam()
        {
            try
            {
                m_objLive.DeviceSet(eMFDeviceType.eMFDT_Video, m_webcamIdx, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void initWebCam()
        {
            // Set device
            m_objLive.DeviceSet(eMFDeviceType.eMFDT_Video, m_webcamIdx, "");

            // Set format
            M_VID_PROPS vidProps;
            string name;
            m_objLive.FormatVideoGetByIndex(eMFormatType.eMFT_Input, m_webcamIdx, out vidProps, out name);
            m_objLive.FormatVideoSet(eMFormatType.eMFT_Input, vidProps);

            // Start worker
            m_bWork = true;
        }

        private void thread_DoWork(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (m_bWork)
                {
                    MFFrame pFrame = null;

                    try
                    {
                        m_objLive.SourceFrameGet(-1, out pFrame, "");

                        //Send frame to the preview
                        m_objPreview.ReceiverFramePut(pFrame, -1, "");

                        //Release frame - DO NOT FORGOT TO DO THIS !!!
                        Marshal.ReleaseComObject(pFrame);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }

    }
}