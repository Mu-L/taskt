using System;
using System.Drawing;
using System.Windows.Forms;

namespace taskt.UI.Forms
{
    public partial class ThemedForm : Form
    {
        private taskt.Core.Theme _Theme = new taskt.Core.Theme();
        public taskt.Core.Theme Theme
        {
            get { return _Theme; }
            set { _Theme = value; }
        }

        public ThemedForm()
        {
            InitializeComponent();
        }

        private void ThemedForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.ClientSize.Height > Screen.PrimaryScreen.WorkingArea.Height - this.CurrentAutoScaleDimensions.Height) // Resizes if too tall to fit
            {
                this.ClientSize = new Size(this.ClientSize.Width, Screen.PrimaryScreen.WorkingArea.Height - (int)this.CurrentAutoScaleDimensions.Height);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(this.Theme.CreateGradient(this.ClientRectangle), this.ClientRectangle);
            base.OnPaint(e);
        }

    }
}
