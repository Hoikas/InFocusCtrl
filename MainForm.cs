using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InFocusCtrl
{
    public partial class MainForm : Form
    {
        InFocusIN146 m_projector;
        Dictionary<Keys, EventHandler> m_hotkeys;

        // Hacks...
        ManualResetEvent m_initialStuffDoneEvent = new ManualResetEvent(false);

        public MainForm()
        {
            // Setup the projector notifiers
            m_projector = new InFocusIN146();

            // Because...
            m_hotkeys  = new Dictionary<Keys, EventHandler>() {
                { Keys.F5, IPowerOff },
                { Keys.F6, IPowerOn },
                { Keys.F7, ISetSourceVga1 },
                { Keys.F8, ISetSourceHdmi },
            };

            // Setup things
            InitializeComponent();
            IAsyncInit();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Visible = false;

            // Register hotkeys
            foreach (var key in m_hotkeys.Keys) {
                IRegisterHotKey(key);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unregister HotKeys
            for (int i = m_hkId; i > 0; i--)
                UnregisterHotKey(Handle, i);
        }

        private async void IAsyncInit()
        {
            // We do this so we can chain the read commands
            await IUpdatePowerState();
            await IUpdateVideoSource();
            m_initialStuffDoneEvent.Set();
        }

        private async Task IUpdatePowerState()
        {
            InFocusIN146.Power state = await m_projector.IsPoweredOn();
            ITogglePowerState(state);
        }

        private void ITogglePowerState(InFocusIN146.Power state)
        {
            bool on = (state == InFocusIN146.Power.On);
            m_powerOff.Checked = !on;
            m_powerOn.Checked = on;
        }

        private async Task IUpdateVideoSource()
        {
            InFocusIN146.VideoSources source = await m_projector.QueryVideoSource();
            IToggleSource(source);
        }

        private void IToggleSource(InFocusIN146.VideoSources source)
        {
            ToolStripMenuItem[] items = { m_inputVga1, m_inputVga2, m_inputHdmi, m_inputSVideo, m_inputComposite };
            for (int i = 0; i < items.Length; i++)
                items[i].Checked = (i == (int)source);
        }

        #region Win32 Hotkeys
        int m_hkId = 0;
        private const int WM_HOTKEY = 0x312;

        [DllImport("user32", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        void IRegisterHotKey(Keys key)
        {
            int id = System.Threading.Interlocked.Increment(ref m_hkId);
            if (!RegisterHotKey(Handle, id, 0x4000, (uint)key))
                throw new Exception();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY) {
                Keys key = (Keys)((m.LParam.ToInt32() & 0xFFFF0000) >> 16);
                if (m_hotkeys.ContainsKey(key))
                    m_hotkeys[key].Invoke(this, null);
            }

            base.WndProc(ref m);
        }
        #endregion

        #region Program Start
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        #endregion

        #region Event Handlers
        private void IPowerOn(object sender, EventArgs e)
        {
            m_projector.SetPowerState(InFocusIN146.Power.On);
            ITogglePowerState(InFocusIN146.Power.On);
        }

        private void IPowerOff(object sender, EventArgs e)
        {
            m_projector.SetPowerState(InFocusIN146.Power.Off);
            ITogglePowerState(InFocusIN146.Power.Off);
        }

        private void ISetSourceHdmi(object sender, EventArgs e)
        {
            m_projector.SetVideoSource(InFocusIN146.VideoSources.HDMI);
            IToggleSource(InFocusIN146.VideoSources.HDMI);
        }

        private void ISetSourceVga1(object sender, EventArgs e)
        {
            m_projector.SetVideoSource(InFocusIN146.VideoSources.VGA1);
            IToggleSource(InFocusIN146.VideoSources.VGA1);
        }

        private void ISetSourceVga2(object sender, EventArgs e)
        {
            m_projector.SetVideoSource(InFocusIN146.VideoSources.VGA2);
            IToggleSource(InFocusIN146.VideoSources.VGA2);
        }

        private void ISetSourceComposite(object sender, EventArgs e)
        {
            m_projector.SetVideoSource(InFocusIN146.VideoSources.Composite);
            IToggleSource(InFocusIN146.VideoSources.Composite);
        }

        private void ISetSourceSVideo(object sender, EventArgs e)
        {
            m_projector.SetVideoSource(InFocusIN146.VideoSources.SVideo);
            IToggleSource(InFocusIN146.VideoSources.SVideo);
        }

        private void IQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IShowLampInfo(object sender, EventArgs e)
        {
            // Don't send any more read commands to the projector until we know the initial ones
            // are done... Otherwise... well, I don't want to talk about it.
            m_initialStuffDoneEvent.WaitOne();
            LampLifeForm llf = new LampLifeForm(m_projector);
            llf.Show(this);
        }

        private void IShowAboutBox(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show(this);
        }
        #endregion
    }
}
