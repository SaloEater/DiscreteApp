using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;

namespace Lab3DM
{
    public partial class InputGroupBox : GroupBox
    {
        [DefaultValue(typeof(string), "Исходные данные")]
        public override string Text { get => base.Text; set => base.Text = value; }

        Button button;

        bool edited = false;

        public InputGroupBox()
        {
            InitializeComponent();
            Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            BackColor = Color.White;
            button = new Button();
            button.Text = "Вычислить";
            button.Location = new Point(5, 5);
            button.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
            button.FlatStyle = FlatStyle.Flat;
            Size = new Size(button.Width + 10, button.Height + 10);
            Controls.Add(button);
            Resize += InputGroupBox_Resize;
            
        }

        internal void FakeButtonPress()
        {
            button.PerformClick();
        }

        private void InputGroupBox_Resize(object sender, EventArgs e)
        {
            if (!edited && !(LicenseManager.UsageMode == LicenseUsageMode.Designtime)) {
                Text = "Исходные данные";
                button.Location = new Point(button.Left, Height - 5 - button.Height);
                edited = true;
            }
        }

        public void HandleButtonWith(EventHandler eventHandler)
        {
            button.Click += eventHandler;
        }
    }
}
