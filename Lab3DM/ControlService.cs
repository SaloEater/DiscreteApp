using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3DM
{
    public static class ControlService
    {
        public static TextBox CreateTextbox(string text, Point? location = null, Size? size = null, bool readOnly = true)
        {
            TextBox textBox = new TextBox();
            if (location != null) {
                textBox.Location = location.Value;
            }
            if (size != null) {
                textBox.Size = size.Value;
            }
            textBox.Text = text;
            textBox.ReadOnly = readOnly;
            return textBox;
        }

        internal static Label CreateLabel(string labelName, Point location, Size? size = null)
        {
            Label label = new Label();
            label.Text = labelName;
            label.Location = location;

            if (size != null) {
                label.Size = size.Value;
            }

            return label;
        }
    }
}
