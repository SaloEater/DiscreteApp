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
    public partial class Name : UserControl
    {
        public Name()
        {
            InitializeComponent();

            LocationChanged += Name_LocationChanged;
            labelName.TextChanged += Name_LocationChanged;
        }

        internal string getName()
        {
            return labelName.Text;
        }

        private void Name_LocationChanged(object sender, EventArgs e)
        {
            if (Parent != null) {
                Size size = TextRenderer.MeasureText(labelName.Text, labelName.Font);
                Location = new Point(Parent.Width / 2 - size.Width / 2, Top);
            }
        }

        public void setName(string name)
        {
            labelName.Text = name;
        }
    }
}
