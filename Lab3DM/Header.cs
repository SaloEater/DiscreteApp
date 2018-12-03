using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3DM
{
    public partial class Header : UserControl
    {
        

        [Category("Appearance")]
        [Description("Header title")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Localizable(true)]
        public string Title
        {
            get {
                return name1.getName();
            }
            set {
                name1.setName(value);
            }
        }

        public Header()
        {
            InitializeComponent();
            Resize += Header_Resize;
            Dock = DockStyle.Top;
            name1.Top = Height / 2 - name1.Height / 2;
        }

        private void Header_Resize(object sender, EventArgs e)
        {
            name1.Top = Height / 2 - name1.Height / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((TabPage)Parent.Parent).Dispose();
        }
    }
}
