using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3DM
{
    class KarnoControlService
    {
        public Label createHorizontalLabel(int width, Point location)
        {
            Label original = new Label();
            original.Height = 3;
            original.Width = width;
            original.Location = location;
            original.BackColor = Color.Black;
            return original;
        }
        public Label createVerticalLabel(int height, Point location)
        {
            Label original = new Label();
            original.Height = height;
            original.Width = 3;
            original.Location = location;
            original.BackColor = Color.Black;
            return original;
        }
    }
}
