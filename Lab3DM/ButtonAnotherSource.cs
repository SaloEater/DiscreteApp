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
    public partial class ButtonAnotherSource : UserControl
    {
        IWindow parent;
        public ButtonAnotherSource()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            ContextMenuStrip strip = new ContextMenuStrip();
            Control tabControl = parent.Parent.Parent;
            foreach (Control c in tabControl.Controls) {
                Control inside = c.Controls[0];
                if (parent.isSupported(inside.GetType())) {
                    ToolStripMenuItem element = new ToolStripMenuItem(c.Text);
                    element.Click += (object _sender, EventArgs _e) => {
                        parent.setPrevious((IWindow)inside);
                    };
                    strip.Items.Add(element);
                }
            }
            strip.Show(MousePosition);
        }   

        public void setParent(IWindow parent)
        {
            this.parent = parent;
        }
    }
}
