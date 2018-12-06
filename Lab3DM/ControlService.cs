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
        public static TextBox CreateTextbox(string text, Point? location = null, bool readOnly = true, Size? size = null)
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
            } else
            {
                label.AutoSize = true;
            }

            return label;
        }

        internal static Panel CreateOutputPanel(string labelText, Point location)
        {
            Panel panel = new Panel();
            panel.Location = location;

            Label label = CreateLabel(labelText, new Point(5, 5));

            panel.Controls.Add(label);

            panel.Size = new Size(label.Width + 10, label.Height + 10);

            return panel;
        }
    }
}
