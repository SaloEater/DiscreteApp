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
    public partial class TruthTable : IWindow
    {
        ComputeTruthTable compute;

        public TruthTable()
        {
            InitializeComponent();
            Type = "Таблица истинности";
            inputGroupBox1.HandleButtonWith(buttonClick);
            compute = new ComputeTruthTable();
            textBox1.KeyDown += TextBox1_KeyDown;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                inputGroupBox1.FakeButtonPress();
                e.SuppressKeyPress = true;
            }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            string function = textBox1.Text;
            if (function == "") {
                MessageBox.Show("Введите формулу");
                return;
            }
            if (!StringService.BinaryString(function)) {
                MessageBox.Show("В строках могут быть только символы '0' и '1'");
                return;
            }
            double pow = Math.Log10(function.Length) / Math.Log10(2);
            int tables = (int)pow;
            if (pow - tables != 0) {
                MessageBox.Show("Должно быть введено 2^n чисел, а было написано " + function.Length + " символов");
                return;
            }
            int rows = function.Length;
            compute.Perform(function, rows, tables);
            int[][] matrix = compute.getMatrix();
            
            int height = 25;
            int width = panelResult.Width / (tables + 1);
            panelResult.Controls.Clear();
            panelResult.Height = rows * height;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < tables; j++) {
                    panelResult.Controls.Add(ControlService.CreateTextbox(
                        matrix[i][j].ToString(),
                        new Point(j * width, i*height),
                        new Size(width, height)
                    ));
                }
                panelResult.Controls.Add(ControlService.CreateTextbox(
                       function[i] + "",
                       new Point(tables * width, i * height),
                       new Size(width, height)
                   ));
            }
        }

        protected override void fillFromPrevious()
        {
            throw new NotImplementedException();
        }

        public override IOutput getOutput()
        {
            return new TruthTableOutput(compute.getMatrix());
        }
    }
}
