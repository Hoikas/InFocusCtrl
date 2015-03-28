using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InFocusCtrl
{
    public partial class LampLifeForm : Form
    {
        public LampLifeForm(InFocusIN146 projector)
        {
            InitializeComponent();
            IInitLampLife(projector);
        }

        async void IInitLampLife(InFocusIN146 projector)
        {
            uint life = await projector.QueryLampLife();
            m_progress.Value = (int)life;
            m_lifeHint.Text = String.Format("Approximately {0} Hours", life);
        }
    }
}
