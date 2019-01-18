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
        Projector m_projector;
        Dictionary<Keys, EventHandler> m_hotkeys;

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

        private void ITogglePowerState(InFocusIN146.Power state)
        {
            bool on = (state == InFocusIN146.Power.On);
            m_powerOff.Checked = !on;
            m_powerOn.Checked = on;
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
            m_projector.SetPowerState(Projector.Power.On);
        }

        private void IPowerOff(object sender, EventArgs e)
        {
            m_projector.SetPowerState(Projector.Power.Off);
        }

        private void ISetSourceHdmi(object sender, EventArgs e)
        {
            try {
                m_projector.SetVideoSource(Projector.VideoSources.HDMI);
            } catch (NotSupportedException) {
                MessageBox.Show("The projector does not support that input.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ISetSourceVga1(object sender, EventArgs e)
        {
            try {
                m_projector.SetVideoSource(Projector.VideoSources.VGA1);
            } catch (NotSupportedException) {
                MessageBox.Show("The projector does not support that input.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ISetSourceVga2(object sender, EventArgs e)
        {
            try {
                m_projector.SetVideoSource(Projector.VideoSources.VGA2);
            } catch (NotSupportedException) {
                MessageBox.Show("The projector does not support that input.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ISetSourceComposite(object sender, EventArgs e)
        {
            try {
                m_projector.SetVideoSource(Projector.VideoSources.Composite);
            } catch (NotSupportedException) {
                MessageBox.Show("The projector does not support that input.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ISetSourceSVideo(object sender, EventArgs e)
        {
            try {
                m_projector.SetVideoSource(Projector.VideoSources.SVideo);
            } catch (NotSupportedException) {
                MessageBox.Show("The projector does not support that input.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void IQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IShowAboutBox(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show(this);
        }
        #endregion
    }
}
