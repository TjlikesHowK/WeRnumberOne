using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeRnumberOne
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            BackgroundImage = Properties.Resources.startFon;
            ImageAnimator.Animate(BackgroundImage, OnFrameChanged);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                return;
            }
            ImageAnimator.UpdateFrames();
            Invalidate(false);
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            this.Text = "Ok, let`s start";

            btnStart.Image = Properties.Resources.start;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.BackColor = Color.Transparent;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            WeRnumberOne form1 = new WeRnumberOne();
            form1.Show();
            this.Hide();
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
