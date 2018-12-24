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
    public partial class TableDecompose : IWindow
    {
        string[] rowNames;

        Dictionary<char, List<int>> sourceTable;
        List<List<char>> answer;

        int matrixY;

        int rows, tables;

        public TableDecompose()
        {
            InitializeComponent();
            Type = "Таблица покрытий";
            header1.Title = Type;
            supportedTypes.Add(typeof(Kvaine));
            inputGroupBox1.HandleButtonWith(buttonClick);
            buttonAnotherSource1.setParent(this);
            textBoxRows.KeyDown += TextBox1_KeyDown;
        }

        

        public void buttonClick(object sender, EventArgs e)
        {
            if (textBoxRows.Text == "") {
                MessageBox.Show("Укажите функцию");
                return;
            }
            panelWork.Controls.Clear();
            ParseUI();
            matrixY = 0;
            DecomposeTable(sourceTable, new List<char>(), false);

            MakeAnswer();

        }

        private void MakeAnswer()
        {
            int shortest = answer[0].Count;
            foreach (List<char> rememberPacks in answer) {
                if (rememberPacks.Count < shortest) shortest = rememberPacks.Count;
            }

            textBoxResult.Text = "Получено " + answer.Count + " покрытий: \n";
            foreach (List<char> rememberPacks in answer) {
                string packStr = "{ ";
                foreach (char ch in rememberPacks) {
                    packStr += " {" + rowNames[(int)char.GetNumericValue(ch)] + "}, ";
                }
                if (rememberPacks.Count == shortest) {
                    packStr += "} - кратчайшее\n";
                } else {
                    packStr += "}\n";
                }
                textBoxResult.Text += packStr;
            }
        }

        private void DrawMatrix(Dictionary<char, List<int>> workMatrix, string message)
        {
            RichTextBox title = new RichTextBox();
            title.Location = new Point(0, matrixY);
            matrixY += 20;
            title.Size = new Size(540, 20);
            title.Text = message;
            panelWork.Controls.Add(title);
            if (workMatrix.Count == 0) {
                RichTextBox _title = new RichTextBox();
                _title.Location = new Point(0, matrixY);
                matrixY += 20;
                _title.Size = new Size(540, 20);
                _title.Text = "Матрица была полностью истощена";
                panelWork.Controls.Add(_title);
                return;
            }
            for (int j = 0; j <= workMatrix.ElementAt(0).Value.Count; j++) {
                TextBox textBox = new TextBox();
                textBox.Location = new Point(j * 50, matrixY);
                textBox.Size = new Size(50, 50);
                textBox.Text = j.ToString();
                panelWork.Controls.Add(textBox);
            }
            matrixY += 20;
            int i;
            foreach (char key in workMatrix.Keys) {
                i = 0;
                TextBox textBox = new TextBox();
                textBox.Location = new Point((i++) * 50, matrixY);
                textBox.Size = new Size(50, 50);
                textBox.Text = "{" + key + "}";
                panelWork.Controls.Add(textBox);

                foreach (int v in workMatrix[key]) {
                    TextBox textBox2 = new TextBox();
                    textBox2.Location = new Point((i++) * 50, matrixY);
                    textBox2.Size = new Size(50, 50);
                    textBox2.Text = v.ToString();
                    panelWork.Controls.Add(textBox2);
                }

                matrixY += 20;
            }
            panelWork.Refresh();
        }

        private void DrawBranching(string _message, List<char> remembered)
        {
            RichTextBox title = new RichTextBox();
            title.Location = new Point(0, matrixY);
            matrixY += 20;
            title.Size = new Size(540, 20);

            string message = "{";

            foreach (char key in remembered) {
                message += "{" + key + "}, ";
            }
            message += "}";
            title.Text = _message + message;
            panelWork.Controls.Add(title);
        }

        private void DecomposeTable(Dictionary<char, List<int>> workTable, List<char> remembered, bool decomposed)
        {
            Dictionary<char, List<int>> copy = MakeCopy(workTable);
            bool done = false;
            //if (decomposed) {
                DrawMatrix(copy, "Исходная матрица на этом шаге");
            //}
            do {
                done = false;
                //PrintMatrix(copy);
                if (copy.Count == 0 || copy.ElementAt(0).Value.Count < 2) {
                    Console.WriteLine("Answer is: ");
                    foreach (char key in copy.Keys) {
                        remembered.Add(key);
                        /*if(row.Count!=0)
                        {
                            Console.Write("{");
                            foreach(int el in row)
                            {
                                Console.Write("{0}, ", (el+1));
                            }
                            Console.Write("}, ");
                        }*/
                    }
                    Console.WriteLine("Before cleaning: ");
                    //PrintRow(remembered);
                    ClearSameVertexes(remembered);
                    Console.WriteLine("Cleared: ");
                    //PrintRow(remembered);
                    return;
                }
                List<int> foundCoreTables;
                List<char> coreRaws = FindCoreTables(copy, out foundCoreTables);
                if (coreRaws.Count != 0) {
                    Console.Write("Core tables removed and saved: ");
                    foreach (char ch in coreRaws) {
                        remembered.Add(ch);
                        Console.Write("{" + ch + "} ");
                    }
                    Console.WriteLine();
                    //PrintMatrix(copy);
                    string deleted = "Удалены ядерные cтолбцы: ";
                    foreach (int a in foundCoreTables) {
                        deleted += (a + 1) + ", ";
                    }
                    DrawMatrix(copy, deleted);
                    DrawBranching("Сохраненные циклы: ", remembered);
                    done = true;
                }
                List<char> removedEmptyRaws;
                if (RemoveEmptyRaws(copy, out removedEmptyRaws)) {
                    Console.WriteLine("Empty raws removed:");
                    //PrintMatrix(copy);
                    string removed = "Удалены пустые строки: ";
                    foreach (char ch in removedEmptyRaws) {
                        removed += "{" + ch + "}, ";
                    }
                    DrawMatrix(copy, removed);
                    done = true;
                }
                List<int> removedEmptyTables;
                if (RemoveEmptyTables(copy, out removedEmptyTables)) {
                    Console.WriteLine("Empty tables removed:");
                    //PrintMatrix(copy);
                    string deleted = "Удалены пустые cтолбцы: ";
                    foreach (int a in removedEmptyTables) {
                        deleted += (a + 1) + ", ";
                    }
                    DrawMatrix(copy, deleted);
                    done = true;
                }
                List<int> removedAbsTables;
                if (RemoveAbsorptioningTables(copy, out removedAbsTables)) {
                    Console.WriteLine("Absorptioning tables removed:");
                    //PrintMatrix(copy);
                    string deleted = "Удалены поглощающие cтолбцы: ";
                    foreach (int a in removedAbsTables) {
                        deleted += (a + 1) + ", ";
                    }
                    DrawMatrix(copy, deleted);
                    done = true;
                }
                List<char> removedAbsRows = null;
                if (RemoveAbsorptionedRows(copy, out removedAbsRows)) {
                    Console.WriteLine("Absorptioned rows removed:");
                    //PrintMatrix(copy);
                    string removed = "Удалены поглощаемые строки: ";
                    foreach (char ch in removedAbsRows) {
                        string strNew = "{" + ch + "}, ";
                        removed += strNew;
                    }
                    DrawMatrix(copy, removed);
                    done = true;
                }
                Console.WriteLine("Cycle finished");
            } while (done);
            int index = FindShortestTable(copy);
            for (int j = 0; j < copy.Keys.Count; j++) {
                char key = copy.ElementAt(j).Key;
                List<int> row = copy[key];
                if (row[index] == 1) {
                    Dictionary<char, List<int>> copyTabled = MakeCopy(copy);

                    List<int> tabledRow = copyTabled.ElementAt(j).Value;
                    int sizeT = copyTabled.ElementAt(0).Value.Count;
                    for (int i = 0; i < sizeT; i++) {
                        if (tabledRow[i] == 1) {
                            foreach (List<int> rR in copyTabled.Values) {
                                rR.RemoveAt(i);
                            }
                            i = -1;
                            sizeT = copyTabled.ElementAt(0).Value.Count;
                        }
                    }
                    copyTabled.Remove(key);
                    Console.WriteLine("Creating new one on row {0}", (index + 1));
                    List<char> copyFinal = MakeCopyS(remembered);
                    copyFinal.Add(key);
                    DrawBranching("Новое ветвление по cтолбцу " + (index + 1) + ": ", copyFinal);
                    DecomposeTable(copyTabled, copyFinal, true);
                }
            }
        }

        private int FindShortestTable(Dictionary<char, List<int>> workTable)
        {
            int onesMin = int.MaxValue;
            int bestIndex = 0;
            int tables = workTable.ElementAt(0).Value.Count;
            for (int j = 0; j < tables; j++) {
                int ones = 0;
                foreach (List<int> row in workTable.Values) {
                    if (row[j] == 1) ones++;
                }
                if (ones < onesMin) {
                    onesMin = ones;
                    bestIndex = j;
                }
            }
            return bestIndex;
        }

        private List<char> MakeCopyS(List<char> remembered)
        {
            List<char> copy = new List<char>();

            foreach (char ch in remembered) {
                copy.Add(ch);
            }

            return copy;
        }

        private bool RemoveAbsorptionedRows(Dictionary<char, List<int>> workTable, out List<char> removedAbsRows)
        {
            removedAbsRows = new List<char>();
            if (workTable.Count == 0) return false;
            bool done = false;
            int rows = workTable.Values.Count;
            for (int j = 0; j < rows; j++) {
                bool shouldRestart = false;
                for (int m = 0; m < rows; m++) {
                    if (m == j) continue;
                    if (SecondRawAbsorbFirst(workTable, j, m)) {
                        removedAbsRows.Add(workTable.ElementAt(j).Key);
                        workTable.Remove(workTable.ElementAt(j).Key);
                        shouldRestart = true;
                        break;
                    }
                }
                if (shouldRestart) {
                    done = true;
                    rows = workTable.Values.Count;
                    j = -1;
                }
            }
            return done;
        }

        private bool RemoveAbsorptioningTables(Dictionary<char, List<int>> workTable, out List<int> removedAbsTables)
        {
            removedAbsTables = new List<int>();
            if (workTable.Count == 0) return false;
            bool done = false;
            int tables = workTable.ElementAt(0).Value.Count;
            int removed = 0;
            for (int j = 0; j < tables; j++) {
                bool shouldRestart = false;
                for (int m = j + 1; m < tables; m++) {
                    if (SecondTableAbsorbFirst(workTable, j, m)) {
                        foreach (List<int> row in workTable.Values) {
                            row.RemoveAt(m);
                        }
                        removedAbsTables.Add(m + removed);
                        removed++;
                        shouldRestart = true;
                        break;
                    }
                }
                if (shouldRestart) {
                    done = true;
                    tables = workTable.ElementAt(0).Value.Count;
                    j = -1;
                }
            }
            return done;
        }

        private bool SecondRawAbsorbFirst(Dictionary<char, List<int>> workTable, int firstRaw, int secondRaw)
        {
            List<int> row1 = workTable.ElementAt(firstRaw).Value;
            List<int> row2 = workTable.ElementAt(secondRaw).Value;
            for (int i = 0; i < workTable.ElementAt(0).Value.Count; i++) {
                if (row2[i] < row1[i]) return false;
            }
            return true;
        }

        private bool SecondTableAbsorbFirst(Dictionary<char, List<int>> workTable, int firstT, int secondT)
        {
            foreach (List<int> row in workTable.Values) {
                if (row[firstT] != 0 && row[firstT] != row[secondT]) return false;
            }
            return true;
        }

        private bool RemoveEmptyTables(Dictionary<char, List<int>> workTable, out List<int> removedEmptyTables)
        {
            removedEmptyTables = new List<int>();
            if (workTable.Count == 0) return false;
            bool done = false;
            int size = workTable.ElementAt(0).Value.Count;
            int removed = 0;
            for (int i = 0; i < size; i++) {
                int empty = 0;
                foreach (List<int> row in workTable.Values) {
                    if (row[i] != 0) {
                        empty++;
                        break;
                    }
                }
                if (empty == 0) {
                    done = true;
                    removedEmptyTables.Add(i + removed);
                    foreach (List<int> row in workTable.Values) {
                        row.RemoveAt(i);
                    }
                    i = -1;
                    removed++;
                    size = workTable.ElementAt(0).Value.Count;
                }
            }
            return done;
        }

        private bool RemoveEmptyRaws(Dictionary<char, List<int>> workTable, out List<char> removedEmptyRaws)
        {
            removedEmptyRaws = new List<char>();
            if (workTable.Count == 0) return false;
            bool done = false;
            int rows = workTable.Values.Count;
            for (int i = 0; i < rows; i++) {
                List<int> row = workTable.ElementAt(i).Value;
                int empty = 0;
                foreach (int el in row) {
                    if (el != 0) {
                        empty++;
                        break;
                    }
                }
                if (empty == 0) {
                    done = true;
                    removedEmptyRaws.Add(workTable.ElementAt(i).Key);
                    workTable.Remove(workTable.ElementAt(i).Key);
                    i = -1;
                    rows = workTable.Values.Count;
                }
            }
            return done;
        }

        private List<char> FindCoreTables(Dictionary<char, List<int>> workTable, out List<int> deletedCoreTables)
        {
            deletedCoreTables = new List<int>();
            if (workTable.Count == 0) return new List<char>();
            List<char> coreRaws = new List<char>();
            int size = workTable.ElementAt(0).Value.Count;
            int delta = 0;
            int removed = 0;
            for (int i = 0; i < size; i++) {
                int oneAmount = 0;
                int rowIndex = 0;
                for (int l = 0; l < workTable.Values.Count; l++) {
                    List<int> row = workTable.ElementAt(l).Value;
                    if (row[i] == 1) {
                        rowIndex = l;
                        oneAmount++;
                    }
                }
                if (oneAmount == 1) {
                    deletedCoreTables.Add(i + removed++);
                    coreRaws.Add(workTable.ElementAt(rowIndex).Key);
                    int index = 0;
                    List<int> removedRow = workTable.ElementAt(rowIndex).Value;
                    //int removedAmount = 0;
                    for (int l = 0; l < removedRow.Count; l++) {
                        int el = removedRow[l];
                        if (el == 1) {
                            foreach (List<int> row in workTable.Values) {
                                row.RemoveAt(index);
                            }
                            l = -1;
                            index = -1;
                            //removedAmount++;
                        }
                        index++;
                    }
                    workTable.Remove(workTable.ElementAt(rowIndex).Key);
                    /*foreach (List<int> row in workTable.Values)
                    {
                        row.RemoveAt(i- removedAmount);
                    }*/
                    delta++;
                    i = -1;
                    if (workTable.Count == 0) break;
                    size = workTable.ElementAt(0).Value.Count;
                }
            }

            return coreRaws;
        }

        private void ClearSameVertexes(List<char> remembered)
        {
            for (int i = remembered.Count - 1; i >= 0; i--) {
                char checkering = remembered[i];
                for (int k = remembered.Count - 1; k >= 0; k--) {
                    if (k == i) continue;
                    char checker = remembered[k];
                    if (checkering == checker) {
                        remembered.Remove(checkering);
                        i = remembered.Count;
                        break;
                    }
                }
            }
            answer.Add(remembered);
        }

        private Dictionary<char, List<int>> MakeCopy(Dictionary<char, List<int>> copy)
        {
            Dictionary<char, List<int>> a = new Dictionary<char, List<int>>();
            foreach (KeyValuePair<char, List<int>> pair in copy) {
                List<int> value = new List<int>();
                foreach (int i in pair.Value) {
                    value.Add((i));
                }
                a.Add(pair.Key, value);
            }
            return a;
        }

        private void ParseUI()
        {
            rows = int.Parse(textBoxRows.Text);
            tables = int.Parse(textBoxTables.Text);
            rowNames = new string[rows];
            answer = new List<List<char>>();
            sourceTable = new Dictionary<char, List<int>>();

            
            for (int i = 0; i < rows; i++) {
                List<int> a = new List<int>();
                for (int j = 0; j < tables; j++) {
                    a.Add(-1);
                }
                sourceTable.Add((char)(i+48), a);
            }

            foreach(Control c in panelInput.Controls) {
                string first = c.Name.Split('_')[0],
                    second = c.Name.Split('_')[1];
                if (first == "row") {
                    rowNames[int.Parse(second)] = c.Text;
                } else {
                    sourceTable.ElementAt(int.Parse(first)).Value[int.Parse(second)] = int.Parse(c.Text != "" ? c.Text : "0");
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
            if (previousOperation.GetType() == typeof(Kvaine)) {
                Kvaine kvaine = (Kvaine)previousOperation;
                KvaineOutput kvaineOutput = (KvaineOutput)kvaine.getOutput();
                Dictionary<string, string> controls = kvaineOutput.makeOutput();
                textBoxRows.Text = kvaineOutput.rows.ToString();
                textBoxTables.Text = kvaineOutput.tables.ToString();
                checkBoxNames.Checked = true;
                button1.PerformClick();
                foreach (Control c in panelInput.Controls) {
                    c.Text = controls[c.Name];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxRows.Text == "" || textBoxTables.Text == "") {
                MessageBox.Show("Укажите размеры");
                return;
            }

            panelInput.Controls.Clear();

            int x = 0,
                rows = int.Parse(textBoxRows.Text),
                tables = int.Parse(textBoxTables.Text),
                height = 25,
                width = 50;

            if (checkBoxNames.Checked) {
                for (int i = 0; i < rows; i++) {
                    TextBox textBox = ControlService.CreateTextbox(
                        "",
                        new Point(0, i*height),
                        false,
                        new Size(width, height)
                    );
                    textBox.Name = "row_" + i;
                    panelInput.Controls.Add(textBox);
                }
                x++;
            }
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < tables; j++) {
                    TextBox textBox = ControlService.CreateTextbox(
                        "",
                        new Point(width * (j+x), height*i),
                        false,
                        new Size(width, height)
                    );
                    textBox.Name = i + "_" + j;
                    panelInput.Controls.Add(textBox);
                }
            }

        }
    }
}
