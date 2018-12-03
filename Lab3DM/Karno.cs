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
    public partial class Karno : IWindow
    {
        int type;

        char typeValid;
        char typeInvalid;

        KarnoControlService service;

        Dictionary<int, List<int>> tablesSymmetry;
        Dictionary<int, List<int>> rowsSymmetry;

        Dictionary<string, List<string>> matrix;
        int[][] matrixInt;

        public Karno(int type)
        {
            InitializeComponent();
            this.type = type;
            if (type == 0) {
                typeValid = '1';
                typeInvalid = '0';
            } else if (type == 1){
                typeValid = '0';
                typeInvalid = '1';
            }
            Type = type == 0 ? "Карно ДНФ" : "Карно КНФ";
            header1.Title = Type;
            supportedTypes.Add(typeof(SNF));
            inputGroupBox1.HandleButtonWith(buttonClick);
            buttonAnotherSource1.setParent(this);
            textBox1.KeyDown += TextBox1_KeyDown;
            service = new KarnoControlService();
        }

        public void buttonClick(object sender, EventArgs e)
        {
            if (textBox1.Text == "") {
                MessageBox.Show("Укажите функцию");
                return;
            }
            tablesSymmetry = new Dictionary<int, List<int>>();
            rowsSymmetry = new Dictionary<int, List<int>>();
            panelWork.Controls.Clear();
            string function = textBox1.Text;
            List<string> firstHalf = new List<string>();
            List<string> secondHalf = new List<string>();
            SplitFunction(function.Replace("*", "").Split('+')[0], out firstHalf, out secondHalf);

            //Создание вертикальных и горизонтальных полос с лейблами
            int y = 0;
            int tables = (int)Math.Pow(2, firstHalf.Count);
            int rows = (int)Math.Pow(2, secondHalf.Count);

            for (int i = 0; i < tables; i++) {
                tablesSymmetry.Add(i, new List<int>());
            }

            for (int i = 0; i < rows; i++) {
                rowsSymmetry.Add(i, new List<int>());
            }

            int xOffset = 25;
            int x = xOffset * secondHalf.Count;
            int width = (panelWork.Width - 10*secondHalf.Count - x) / (int)Math.Pow(2, firstHalf.Count);
            int height = 25;

            matrixInt = new int[rows][];

            for(int i = 0; i < rows; i++) {
                matrixInt[i] = new int[tables];
                for (int j = 0; j < tables; j++) {
                    matrixInt[i][j] = -1;
                }
            }

            int fhi = 1;

            List<string> tablesName = new List<string>();
            int z = 0;
            foreach (string labelName in firstHalf) {
                int interval = (int)Math.Pow(2, firstHalf.Count - fhi);
                Label name = ControlService.CreateLabel(labelName, new Point(x, y));
                panelWork.Controls.Add(name);
                tablesName.Add("");
                tablesName[z] = AddSomeSymbolsToString(tablesName[z], typeInvalid, interval);
                for (int i = interval, j = 0; i < tables; i+=2*interval, j++) {
                    if (j % 2 == 1) {
                        tablesName[z] = AddSomeSymbolsToString(tablesName[z], typeInvalid, 2 *interval);
                        continue;
                    }
                    tablesName[z] = AddSomeSymbolsToString(tablesName[z], typeValid, 2 * interval);
                    int newWidth = interval * 2 * width;
                    int offset = x + i * width;
                    newWidth = (offset + newWidth) > (tables*width+x)? (tables - i) * width: newWidth;
                    Label label = service.createHorizontalLabel(newWidth, new Point(offset, y));
                    panelWork.Controls.Add(label);

                    int l = i + interval - 1;
                    for (int k = 0; k < interval*2; k++) {
                        tablesSymmetry[l - k].Add(l + k + 1);
                        if (tablesSymmetry.ContainsKey(l + k + 1)) {
                            tablesSymmetry[l + k + 1].Add(l - k);
                        }
                    }
                }
                z++;
                y += height;
                fhi++;
            }

            List<string> rowsName = new List<string>();
            fhi = 0;
            z = 0;
            foreach (string labelName in secondHalf) {
                int interval = (int)Math.Pow(2, secondHalf.Count - fhi - 1);
                Label name = ControlService.CreateLabel(labelName, new Point(fhi* xOffset, y - 15), new Size(xOffset, 15));
                name.TextAlign = ContentAlignment.MiddleLeft;
                panelWork.Controls.Add(name);
                rowsName.Add("");
                rowsName[z] = AddSomeSymbolsToString(rowsName[z], typeInvalid, interval);
                for (int i = interval, j = 0; i < rows; i += 2 * interval, j++) {
                    if (j % 2 == 1) {
                        rowsName[z] = AddSomeSymbolsToString(rowsName[z], typeInvalid, 2*interval);
                        continue;
                    }
                    rowsName[z] = AddSomeSymbolsToString(rowsName[z], typeValid, 2*interval);
                    int newHeight = interval * 2 * height;
                    int offset = y + i * height;
                    newHeight = (offset + newHeight) > (rows * height + y)? (rows - i) * height: newHeight;
                    Label label = service.createVerticalLabel(newHeight, new Point(fhi*xOffset, offset));
                    panelWork.Controls.Add(label);

                    int l = i + interval - 1;
                    for (int k = 0; k < interval * 2; k++) {
                        rowsSymmetry[l - k].Add(l + k + 1);
                        if (rowsSymmetry.ContainsKey(l + k + 1)) {
                            rowsSymmetry[l + k + 1].Add(l - k);
                        }
                    }
                }
                z++;
                fhi++;
            }

            matrix = new Dictionary<string, List<string>>();

            List<string> completeRows = new List<string>();

            for (int i = 0; i < rows; i++) {
                string strRow = "";
                foreach (string str in rowsName) {
                    strRow += str[i];
                }
                completeRows.Add(strRow);
            }

            for (int i = 0; i < tables; i++) {
                string strTable = "";
                foreach (string str in tablesName) {
                    strTable += str[i];
                }
                matrix.Add(strTable, completeRows);
            }

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < tables; j++) {
                    TextBox textBox = ControlService.CreateTextbox("", new Point(x + j * width, y), new Size(width, height));
                    textBox.Name = "karno_first_" + i + '_' + j;
                    panelWork.Controls.Add(textBox);
                }
                y += height;
            }
            ParseFunction(function);
            VisualizeNeighboors();
        }

        private void VisualizeNeighboors()
        {
            int rows = matrixInt.Length;
            int tables = matrixInt[0].Length;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < tables; j++) {
                    if (matrixInt[i][j] != -1) {
                        SetTextBoxText(typeValid + "(" + CountNeigsFor(i, j) + ")", i, j);
                    }
                }
            }
        }

        private void SplitFunction(string part, out List<string> firstHalf, out List<string> secondHalf)
        {
            firstHalf = new List<string>();
            secondHalf = new List<string>();
            
            int half = (int)Math.Ceiling((double)part.Length / 2);

            for (int i = 1; i <= half; i++) {
                string var = i + "";
                firstHalf.Add(var);
            }

            for (int i = half + 1; i <= part.Length; i++) {
                string var = i + "";
                secondHalf.Add(var);
            }
        }

        private void ParseFunction(string function)
        {
            string[] parts = function.Replace("*", "").Replace("\r", "").Replace("\n", "").Split('+');

            for (int k = 0; k < parts.Length; k++) {
                string firstHalf;
                string secondHalf;
                SplitFunctionToBinary(parts[k], out firstHalf, out secondHalf);
                int i = GetIFor(secondHalf);
                int j = GetJFor(firstHalf);
                matrixInt[i][j] = (int)char.GetNumericValue(typeValid);
            }            
        }

        private string CountNeigsFor(int row, int table)
        {
            return(CountNeigsForRow(row, table) + CountNeigsForTable(row, table)) + "";
        }

        private int CountNeigsForTable(int row, int table)
        {
            int neigs = 0;

            List<int> list = tablesSymmetry[table];

            int tables = matrixInt[0].Length;
            for(int i = 0; i < tables; i++) {
                if (!list.Contains(i)) {
                    continue;
                }
                if (matrixInt[row][i] != -1) {
                    neigs++;
                }
            }

            int newTable = table + 1 >= matrixInt[row].Length ? 0 : table + 1;
            if (matrixInt[row][newTable] != -1 && !list.Contains(newTable)) {
                neigs++;
            }
            newTable = table - 1 < 0 ? matrixInt[row].Length - 1 : table - 1;
            if (matrixInt[row][newTable] != -1 && !list.Contains(newTable)) {
                neigs++;
            }

            return neigs;
        }

        private int CountNeigsForRow(int row, int table)
        {
            int neigs = 0;

            List<int> list = rowsSymmetry[row];

            int rows = matrixInt.Length;
            for (int i = 0; i < rows; i++) {
                if (!list.Contains(i)) {
                    continue;
                }
                if (matrixInt[i][table] != -1) {
                    neigs++;
                }
            }
            int newRow = row + 1 >= matrixInt.Length ? 0 : row + 1;
            if (matrixInt[newRow][table] != -1 && !list.Contains(newRow)) {
                neigs++;
            }
            newRow = row - 1 < 0 ? matrixInt.Length - 1 : row - 1;
            if (matrixInt[newRow][table] != -1 && !list.Contains(newRow)) {
                neigs++;
            }

            return neigs;
        }

        private void SplitFunctionToBinary(string part, out string firstHalf, out string secondHalf)
        {
            firstHalf = "";
            secondHalf = "";

            int half = (int)Math.Ceiling((double)part.Length / 2);

            for (int i = 0; i < half; i++) {
                firstHalf += part[i];
            }

            for (int i = half; i < part.Length; i++) {
                secondHalf += part[i];
            }
        }

        private void SetTextBoxText(string value, int i, int j)
        {
            TextBox textBox = FindFirstTextBox(i, j);
            textBox.Text = value + "";
        }

        private TextBox FindFirstTextBox(int i, int j)
        {
            string lookingFor = "karno_first_" + i + '_' + j;
            foreach (Control c in panelWork.Controls) {
                if (c.Name.Equals(lookingFor)) {
                    return (TextBox)c;
                }
            }
            throw new ArgumentOutOfRangeException("Can't find control with name " + lookingFor);
        }

        private int GetIFor(string part)
        {
            List<string> anyRow = matrix.First().Value;
            for (int i = 0; i < anyRow.Count; i++) {
                if (part == anyRow[i]) {
                    return i;
                }
            }
            return -1;
        }

        private int GetJFor(string part)
        {
            for (int j = 0; j < matrix.Count; j++) {
                if (part == matrix.ElementAt(j).Key) {
                    return j;
                }
            }
            return -1;
        }

        private string AddSomeSymbolsToString(string origin, char symbol, int interval)
        {
            for (int j = 0; j < interval; j++) {
                origin += symbol;
            }
            return origin;
        }

        private void AddToAll(List<string> collection, char value, int iterator)
        {
            for (int i = 0; i < iterator; i++) {
                for (int j = 0; j < collection.Count; j++) {
                    collection[j] += value;
                }
            }
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

    }
}
