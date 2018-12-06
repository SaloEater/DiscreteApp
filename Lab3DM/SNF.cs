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
    public partial class SNF : IWindow
    {
        int type;
        int tables;
        int rows;
        ComputeSNF compute;

        public SNF(int type)
        {
            InitializeComponent();
            this.type = type;
            Type = type == 0 ? "СДНФ" : "СКНФ";
            header1.Title = Type;
            inputGroupBox1.HandleButtonWith(buttonClick);
            supportedTypes.Add(typeof(TruthTable));
            buttonAnotherSource1.setParent(this);
            compute = new ComputeSNF(type);
        }

        public void buttonClick(object sender, EventArgs e)
        {
            if (textBoxVars.Text == "") {
                MessageBox.Show("Заполните матрицу");
                return;
            }
            compute.setMatrix((new SNFService()).SerializeControlCollection(panelMatrix.Controls, tables, rows));
            compute.Perform();
            textBoxResult.Text = compute.getValue();
            if (textBoxResult.Text == "") {
                MessageBox.Show("Построить " + Type + " невозможно");
            }
        }

        protected override void fillFromPrevious()
        {
            if (previousOperation.GetType() == typeof(TruthTable)) {
                PrepareFields(((TruthTableOutput)previousOperation.getOutput()).getMatrix());
            }
        }

        public override IOutput getOutput()
        {
            return new SNFOutput(textBoxResult.Text);
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            int tables = int.Parse(textBoxVars.Text);
            int rows = (int)Math.Pow(2, tables);

            this.tables = tables;
            this.rows = rows;
           

            PrepareFields();
        }

        private void PrepareFields(int[][] matrix = null)
        {
            panelMatrix.Controls.Clear();
            if (matrix != null) {
                compute.setMatrix(matrix);
                rows = matrix.Length;
                tables = matrix[0].Length;
                textBoxVars.Text = (tables-1).ToString();
            }
            int height = 25;
            int width = panelMatrix.Width / (tables + 1);

            //panelMatrix.Height = rows * height;

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < tables; j++) {
                    panelMatrix.Controls.Add(ControlService.CreateTextbox(
                        matrix == null? "" : matrix[i][j].ToString(),
                        new Point(j * width, i * height),
                        false,
                        new Size(width, height)
                    ));
                }
            }
        }
    }
}
