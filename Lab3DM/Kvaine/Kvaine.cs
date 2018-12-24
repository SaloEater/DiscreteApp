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
    public partial class Kvaine : IWindow
    {
        int type;

        char typeValid;
        char typeInvalid;

        KvaineService kvaineService;

        public Kvaine(int type)
        {
            InitializeComponent();
            this.type = type;
            if (type == 0) {
                typeValid = '1';
                typeInvalid = '0';
            } else if (type == 1) {
                typeValid = '0';
                typeInvalid = '1';
            }
            Type = type == 0 ? "Алгоритм ДНФ Квайна Мак-Класки" : "Алгоритм КНФ Квайна Мак-Класки";
            header1.Title = Type;
            supportedTypes.Add(typeof(SNF));
            inputGroupBox1.HandleButtonWith(buttonClick);
            buttonAnotherSource1.setParent(this);
            textBox1.KeyDown += TextBox1_KeyDown;
            kvaineService = new KvaineService(typeValid, typeInvalid);
        }

        public void buttonClick(object sender, EventArgs e)
        {
            if (textBox1.Text == "") {
                MessageBox.Show("Укажите функцию");
                return;
            }
            panelWork.Controls.Clear();
            kvaineService.SetFunction(BinaryService.toDoubleDim(textBox1.Text));
            kvaineService.SetPanel(panelWork);
            kvaineService.SetWidth(panelWork.Width / 6);
            kvaineService.Start();
            string result = '{'+string.Join(", ",kvaineService.GetResult())+'}';
            textBoxResult.Text = result;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                inputGroupBox1.FakeButtonPress();
                e.SuppressKeyPress = true;
            }
        }

        protected override void fillFromPrevious()
        {
            if (previousOperation.GetType() == typeof(SNF)) {
                SNF snf = (SNF)previousOperation;
                textBox1.Text = ((SNFOutput)snf.getOutput()).getFunction();
            }
        }

        public override IOutput getOutput()
        {
            return new KvaineOutput(kvaineService.GetResult(), kvaineService.GetFunction());
        }

    }
}
