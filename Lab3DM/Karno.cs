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

        SymmetryList tablesSymmetry;
        SymmetryList rowsSymmetry;

        List<List<string>> indexes;
        int[][] matrix;
        List<DotWithNeigs> neighbooredDots;
        List<Interval> intervals;

        int y;
        int x;
        Random rnd;
        public Karno(int type)
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
            Type = type == 0 ? "Карно ДНФ" : "Карно КНФ";
            header1.Title = Type;
            supportedTypes.Add(typeof(SNF));
            inputGroupBox1.HandleButtonWith(buttonClick);
            buttonAnotherSource1.setParent(this);
            textBox1.KeyDown += TextBox1_KeyDown;
            service = new KarnoControlService();
            rnd = new Random();
        }

        public void buttonClick(object sender, EventArgs e)
        {
            if (textBox1.Text == "") {
                MessageBox.Show("Укажите функцию");
                return;
            }
            tablesSymmetry = new SymmetryList();
            rowsSymmetry = new SymmetryList();
            neighbooredDots = new List<DotWithNeigs>();
            panelWork.Controls.Clear();
            string function = textBox1.Text;
            List<string> firstHalf = new List<string>();
            List<string> secondHalf = new List<string>();
            SplitFunction(function.Replace("*", "").Split('+')[0], out firstHalf, out secondHalf);

            //Создание вертикальных и горизонтальных полос с лейблами
            y = 0;
            int tables = (int)Math.Pow(2, firstHalf.Count);
            int rows = (int)Math.Pow(2, secondHalf.Count);

            for (int i = 0; i < tables; i++) {
                tablesSymmetry.Add(i);
            }

            for (int i = 0; i < rows; i++) {
                rowsSymmetry.Add(i);
            }

            int xOffset = 25;
            x = xOffset * secondHalf.Count;
            int width = (panelWork.Width - 10 * secondHalf.Count - x) / ((int)Math.Pow(2, firstHalf.Count) + 1);

            x += width;

            int height = 25;

            matrix = new int[rows][];

            for (int i = 0; i < rows; i++) {
                matrix[i] = new int[tables];
                for (int j = 0; j < tables; j++) {
                    matrix[i][j] = -1;
                }
            }

            int fhi = 1;

            List<string> tablesName = new List<string>();
            int z = 0;
            foreach (string labelName in firstHalf) {
                int interval = (int)Math.Pow(2, firstHalf.Count - fhi);
                Label name = ControlService.CreateLabel(firstHalf[firstHalf.Count-z-1], new Point(x, y));
                panelWork.Controls.Add(name);
                tablesName.Add("");
                tablesName[z] = AddSomeSymbolsToString(tablesName[z], typeInvalid, interval);
                for (int intervalFirstIndex = interval, intervalIndex = 0; intervalFirstIndex < tables; intervalFirstIndex += 2 * interval, intervalIndex++) {
                    if (intervalIndex % 2 == 1) {
                        tablesName[z] = AddSomeSymbolsToString(tablesName[z], typeInvalid, 2 * interval);
                        continue;
                    }
                    tablesName[z] = AddSomeSymbolsToString(tablesName[z], typeValid, 2 * interval);
                    int newWidth = interval * 2 * width;
                    int offset = x + intervalFirstIndex * width;
                    bool intervalTooBig = (offset + newWidth) > (tables * width + x);
                    newWidth = intervalTooBig ? (tables - intervalFirstIndex) * width : newWidth;
                    Label label = service.createHorizontalLabel(newWidth, new Point(offset, y));
                    panelWork.Controls.Add(label);

                    int intervalCenter = intervalFirstIndex + (intervalTooBig ? (int)Math.Ceiling((decimal)interval / 2) : interval) - 1;
                    for (int indexInInterval = 0; indexInInterval < interval * 2; indexInInterval++) {
                        try {
                            if (tablesSymmetry.Get(intervalCenter - indexInInterval).ContainsSymmetry(intervalCenter + indexInInterval + 1)) {
                                continue;
                            }
                            tablesSymmetry.Get(intervalCenter - indexInInterval).Add(intervalCenter + indexInInterval + 1);
                            tablesSymmetry.Get(intervalCenter + indexInInterval + 1).Add(intervalCenter - indexInInterval);
                        } catch (IndexOutOfRangeException e2) {
                            break;
                        }
                    }
                }
                z++;
                y += height;
                fhi++;
            }

            tablesSymmetry.CutAllHigher(tables - 1);

            y += height;
            List<string> rowsName = new List<string>();
            fhi = 0;
            z = 0;
            for (int m = secondHalf.Count - 1; m >= 0; m--){
                string labelName = secondHalf[m];
                int interval = (int)Math.Pow(2, secondHalf.Count - 1 - fhi);
                Label name = ControlService.CreateLabel(labelName, new Point(fhi * xOffset, y - 15), new Size(xOffset, 15));
                name.TextAlign = ContentAlignment.MiddleLeft;
                panelWork.Controls.Add(name);
                rowsName.Add("");
                rowsName[z] = AddSomeSymbolsToString(rowsName[z], typeInvalid, interval);
                for (int intervalFirstIndex = interval, intervalIndex = 0; intervalFirstIndex < rows; intervalFirstIndex += 2 * interval, intervalIndex++) {
                    if (intervalIndex % 2 == 1) {
                        rowsName[z] = AddSomeSymbolsToString(rowsName[z], typeInvalid, 2 * interval);
                        continue;
                    }
                    rowsName[z] = AddSomeSymbolsToString(rowsName[z], typeValid, 2 * interval);
                    int newHeight = interval * 2 * height;
                    int offset = y + intervalFirstIndex * height;
                    bool intervalTooBig = (offset + newHeight) > (rows * height + y);
                    newHeight = intervalTooBig ? (rows - intervalFirstIndex) * height : newHeight;
                    Label label = service.createVerticalLabel(newHeight, new Point(fhi * xOffset, offset));
                    panelWork.Controls.Add(label);

                    int intervalCenter = intervalFirstIndex + (intervalTooBig ? (int)Math.Ceiling((decimal)interval/2) : interval) - 1;
                    for (int indexInInterval = 0; indexInInterval < interval * 2; indexInInterval++) {
                        try {
                            if (rowsSymmetry.Get(intervalCenter - indexInInterval).ContainsSymmetry(intervalCenter + indexInInterval + 1)) {
                                continue;
                            }
                            rowsSymmetry.Get(intervalCenter - indexInInterval).Add(intervalCenter + indexInInterval + 1);
                            rowsSymmetry.Get(intervalCenter + indexInInterval + 1).Add(intervalCenter - indexInInterval);
                        } catch(IndexOutOfRangeException e2) {
                            break;
                        }
                    }
                }
                z++;
                fhi++;
            }
            rowsSymmetry.CutAllHigher(rows - 1);
            y -= height;
            x -= width;

            List<string> completeRows = new List<string>();

            for (int i = 0; i < rows; i++) {
                string strRow = "";
                foreach (string str in rowsName) {
                    strRow += str[i];
                }
                completeRows.Add(new string(strRow.ToCharArray().Reverse().ToArray()));
            }

            List<string> completeTables = new List<string>();

            for (int i = 0; i < tables; i++) {
                string strTable = "";
                foreach (string str in tablesName) {
                    strTable += str[i];
                }
                completeTables.Add(new string(strTable.ToCharArray().Reverse().ToArray()));
            }

            indexes = new List<List<string>>();
            indexes.Add(completeTables);
            indexes.Add(completeRows);

            for (int i = 0; i < rows + 1; i++) {
                if (i == 0) {
                    for (int j = 1; j < tables + 1; j++) {
                        TextBox textBox = ControlService.CreateTextbox(indexes[0][j - 1], new Point(x + j * width, y), true, new Size(width, height));
                        textBox.Name = "table_" + i + '_' + (j - 1);
                        panelWork.Controls.Add(textBox);
                    }
                } else {
                    for (int j = 0; j < tables + 1; j++) {
                        TextBox textBox;
                        if (j == 0) {
                            textBox = ControlService.CreateTextbox(indexes[1][i - 1], new Point(x + j * width, y), true, new Size(width, height));
                            textBox.Name = "row_" + i + '_' + j;
                        } else {
                            textBox = ControlService.CreateTextbox("", new Point(x + j * width, y), true, new Size(width, height));
                            textBox.Name = "karno_first_" + (i - 1) + '_' + (j - 1);
                        }
                        panelWork.Controls.Add(textBox);
                    }
                }
                y += height;
            }
            ParseFunction(function);
            VisualizeNeighboors();
            CountIntervals();
            VisualizeIntervals();
            MakeAnswer();
        }

        private void MakeAnswer()
        {
            string answer = "";

            foreach (Interval interval in intervals)
            {
                List<Dot> dots = interval.createDots();
                List<string> stringDots = new List<string>();
                foreach (Dot dot in dots) {
                    stringDots.Add(indexes[0][dot.table] + indexes[1][dot.row]);
                }

                int length = stringDots[0].Length;
                for (int i = 0; i < length; i++) {
                    bool oneFound = false,
                        zeroFound = false;

                    foreach(string str in stringDots) {
                        if(str[i] == '1') {
                            oneFound = true;
                        }
                        if (str[i] == '0') {
                            zeroFound = true;
                        }
                        if (oneFound && zeroFound) {
                            break;
                        }
                    }

                    if (oneFound && zeroFound) {
                        for (int j = 0; j < stringDots.Count; j++) {
                            char[] str = stringDots[j].ToCharArray();
                            str[i] = '-';
                            stringDots[j] = string.Join("", str);
                        }
                    }
                }

                string result = "";

                for(int i = 0; i < stringDots[0].Length; i++) {
                    if(stringDots[0][i] == '-') {
                        continue;
                    }
                    if(typeValid == '1') {
                        if (stringDots[0][i] == typeValid) {
                            result += "x" + (i + 1);
                        } else if (stringDots[0][i] == typeInvalid) {
                            result += "x" + (i + 1) + "_";
                        }
                    } else if(typeValid == '0') {
                        if (stringDots[0][i] == typeInvalid) {
                            result += "x" + (i + 1);
                        } else if (stringDots[0][i] == typeValid) {
                            result += "x" + (i + 1) + "_";
                        }
                    }
                    result += '*';
                }

                answer += result + "+";
            }

            if (answer.Length < 2) {
                textBoxResult.Text = "Невозможно построить ответ";
            } else {
                textBoxResult.Text = answer.Remove(answer.Length - 2, 2);
            }
        }

        private void VisualizeIntervals()
        {
            Label label = ControlService.CreateLabel(
                "Были найдены следующие интервалы:",
                new Point(x, y)
            );
            panelWork.Controls.Add(label);

            y += label.Height;

            int i = 0;
            foreach (Interval interval in intervals)
            {    

                List<TextBox> textBoxes = new List<TextBox>();

                foreach (Dot dot in interval.createDots()) {
                    textBoxes.Add(FindFirstTextBox(dot.row, dot.table));
                }

                Label panel = ControlService.CreateLabel(
                    interval.makeString(),
                    new Point(x, y)
                );
                panel.Font = new Font(FontFamily.GenericMonospace, 11);
                Color color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                panel.BackColor = color;
                panel.MouseHover += (object sender, EventArgs e) =>
                {
                    foreach (TextBox textBox in textBoxes)
                    {
                        textBox.BackColor = color;
                    }
                };
                panel.MouseLeave += (object sender, EventArgs e) =>
                {
                    foreach(TextBox textBox in textBoxes)
                        {
                        textBox.BackColor = Color.White;
                    }
                };

                y += panel.Height;
                panelWork.Controls.Add(panel);
                i++;
            }
        }

        private void CountIntervals()
        {
            intervals = new List<Interval>();
            List<Dot> forbidden = new List<Dot>();
            for (int i = 0; i < neighbooredDots.Count; i++) {
                DotWithNeigs one = neighbooredDots[i];
                bool cont = false;
                foreach(Dot dot in forbidden) {
                    if (dot.Equals(one)) {
                        cont = true;
                        break;
                    }
                }
                if (cont) {
                    continue;
                }
                Interval interval = new Interval(new Dot(one.row, one.table));
                //Бесконечный цикл для проверки симметричностей интервала
                interval = TryToFindMaxIntervalFor(interval);
                Dot origin = interval.getOrigin();
                foreach (IntervalShift shift in interval.getShifts()) {
                    forbidden.Add(shift.ApplyOn(origin, false));
                }
                Console.WriteLine("{0}: {1} and has {2}", i, interval.ToString(), one.neigs);
                intervals.Add(interval);
            }
        }

        private Interval TryToFindMaxIntervalFor(Interval interval)
        {
            Dot first = interval.getOrigin();
            List<Interval> allFoundIntervals = new List<Interval>();
            //Cтолбцы
            Symmetry tables = tablesSymmetry.Get(first.table);
            foreach (int table in tables.GetSymmetries()) {
                bool valid = true;
                Dot tableOrigin = new Dot(first.row, table);
                if (interval.HasReferenceTo(tableOrigin)) {
                    continue;
                }
                List<IntervalShift> shifts = interval.getShifts();
                List<Dot> edited = new List<Dot>();
                foreach (IntervalShift shift in shifts) {
                    Dot dot = shift.ApplyOn(tableOrigin, false, true);
                    try {
                        int value = matrix[dot.row][dot.table];
                        if (value == -1 /*|| value == -2*/) {
                            throw new IndexOutOfRangeException();
                        } else {
                            //matrix[dot.row][dot.table] = -2;
                            edited.Add(dot);
                        }
                    } catch (IndexOutOfRangeException e) {
                        valid = false;
                        break;
                    }
                }
                if (valid) {
                    Interval newInterval = IntervalFactory.CreateCopy(interval);
                    newInterval.CopyAndMoveHalfOnTable(table - first.table);
                    newInterval = TryToFindMaxIntervalFor(newInterval);
                    allFoundIntervals.Add(newInterval);
                } 
                /*foreach (Dot dot in edited) {
                    matrix[dot.row][dot.table] = 0;
                }*/
            }

            //Cтроки
            Symmetry rows = rowsSymmetry.Get(first.row);
            foreach (int row in rows.GetSymmetries()) {
                bool valid = true;
                Dot tableOrigin = new Dot(row, first.table);
                if (interval.HasReferenceTo(tableOrigin)) {
                    continue;
                }
                bool inverted = true;// row > first.row ? true : false;
                List<IntervalShift> shifts = interval.getShifts();
                List<Dot> edited = new List<Dot>();
                foreach (IntervalShift shift in shifts) {
                    Dot dot = shift.ApplyOn(tableOrigin, true, false);
                    try {
                        int value = matrix[dot.row][dot.table];
                        if (value == -1 /*|| value == -2*/) {
                            throw new IndexOutOfRangeException();
                        } else {
                            //matrix[dot.row][dot.table] = -2;
                            edited.Add(dot);
                        }
                    } catch (IndexOutOfRangeException e) {
                        valid = false;
                        break;
                    }
                }
                if (valid) {
                    Interval newInterval = IntervalFactory.CreateCopy(interval);
                    newInterval.CopyAndMoveHalfOnRow(row - first.row);
                    newInterval = TryToFindMaxIntervalFor(newInterval);
                    allFoundIntervals.Add(newInterval);
                }
                /*foreach (Dot dot in edited) {
                    matrix[dot.row][dot.table] = 0;
                }*/
            }

            List<IntervalShift> sides = new List<IntervalShift>() {
                new IntervalShift(0, 1),
                new IntervalShift(0, -1),
                new IntervalShift(-1, 0),
                new IntervalShift(1, 0),
            };
            /*for (int i = 0; i < sides.Count; i++) {
                IntervalShift shift = sides[i];
                if (interval.Contains(shift)) {
                    sides.Remove(shift);
                    i--;
                }
            }*/

            foreach (IntervalShift direction in sides) {
                Dot edge = interval.getEdgeInDirectrion(direction);
                Dot newEdge = direction.ApplyOn(edge, false);
                Dot origin = new Dot(newEdge.row + (edge.row - interval.getOrigin().row), newEdge.table + (edge.table - interval.getOrigin().table));
                List<IntervalShift> shifts = interval.getShifts();
                List<Dot> edited = new List<Dot>();
                bool valid = true;
                //bool overlap = false;
                bool invert = false;
                foreach (IntervalShift shift in shifts) {
                    Dot dot = null;
                    if (direction.offsetI != 0) {
                        dot = shift.ApplyOn(origin, true, false);
                    } else if (direction.offsetJ != 0) {
                        dot = shift.ApplyOn(origin, false, true);
                    } else
                    {
                        dot = origin;
                    }
                    try {
                        int value = matrix[dot.row][dot.table];
                        if (value == -1) {
                            throw new IndexOutOfRangeException();
                        } else {
                            /*if (value == -2) {
                                overlap = true;
                            }*/
                            //matrix[dot.row][dot.table] = -2;
                            edited.Add(dot);
                        }
                    } catch (IndexOutOfRangeException e) {
                        valid = false;
                        break;
                    }
                }
                if (valid) {
                    Interval newInterval = IntervalFactory.CreateCopy(interval);
                    newInterval.MirrorAround(direction, origin);
                    //if (!overlap) {
                        newInterval = TryToFindMaxIntervalFor(newInterval);
                    //}
                    allFoundIntervals.Add(newInterval);
                } 
                /*foreach (Dot dot in edited) {
                    matrix[dot.row][dot.table] = 0;
                }*/
            }

            if (allFoundIntervals.Count > 0) {
                int biggestIndex = 0;
                int biggest = allFoundIntervals[biggestIndex].getShifts().Count;
                for (int i = 1; i < allFoundIntervals.Count; i++) {
                    if (allFoundIntervals[i].getShifts().Count > biggest) {
                        biggestIndex = i;
                    }
                }
                interval = allFoundIntervals[biggestIndex];
            }

            return interval;
        }

        private void VisualizeNeighboors()
        {
            int rows = matrix.Length;
            int tables = matrix[0].Length;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < tables; j++) {
                    if (matrix[i][j] != -1) {
                        int neigs = CountNeigsFor(i, j);
                        SetTextBoxText(typeValid + "(" + neigs + ")", i, j);
                        neighbooredDots.Add(new DotWithNeigs(i, j, neigs));
                    }
                }
            }
            neighbooredDots.Sort((DotWithNeigs a, DotWithNeigs b) => {
                if (a.neigs > b.neigs) {
                    return 0;
                } else if (a.neigs < b.neigs) {
                    return -1;
                } else {
                    return 1;
                }
            });
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
                matrix[i][j] = (int)char.GetNumericValue(typeValid);
            }
        }

        private int CountNeigsFor(int row, int table)
        {
            return CountNeigsForRow(row, table) + CountNeigsForTable(row, table);
        }

        private int CountNeigsForTable(int row, int table)
        {
            int neigs = 0;

            List<int> list = tablesSymmetry.Get(table).GetSymmetries();

            int tables = matrix[0].Length;
            for (int i = 0; i < tables; i++) {
                if (!list.Contains(i)) {
                    continue;
                }
                if (matrix[row][i] != -1) {
                    neigs++;
                }
            }

            int newTable = table + 1 >= matrix[row].Length ? 0 : table + 1;
            if (matrix[row][newTable] != -1 && !list.Contains(newTable)) {
                neigs++;
            }
            newTable = table - 1 < 0 ? matrix[row].Length - 1 : table - 1;
            if (matrix[row][newTable] != -1 && !list.Contains(newTable)) {
                neigs++;
            }

            return neigs;
        }

        private int CountNeigsForRow(int row, int table)
        {
            int neigs = 0;

            List<int> list = rowsSymmetry.Get(row).GetSymmetries();

            int rows = matrix.Length;
            for (int i = 0; i < rows; i++) {
                if (!list.Contains(i)) {
                    continue;
                }
                if (matrix[i][table] != -1) {
                    neigs++;
                }
            }
            int newRow = row + 1 >= matrix.Length ? 0 : row + 1;
            if (matrix[newRow][table] != -1 && !list.Contains(newRow)) {
                neigs++;
            }
            newRow = row - 1 < 0 ? matrix.Length - 1 : row - 1;
            if (matrix[newRow][table] != -1 && !list.Contains(newRow)) {
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
            List<string> anyRow = indexes[1];
            for (int i = 0; i < anyRow.Count; i++) {
                if (part == anyRow[i]) {
                    return i;
                }
            }
            return -1;
        }

        private int GetJFor(string part)
        {
            for (int j = 0; j < indexes[0].Count; j++) {
                if (part == indexes[0][j]) {
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

        /*int type;

        char typeValid;
        char typeInvalid;

        KarnoControlService service;

        Dictionary<int, List<int>> tablesSymmetry;
        Dictionary<int, List<int>> rowsSymmetry;

        Dictionary<string, List<string>> matrix;
        List<List<int>> matrixInt;

        int y;

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
            y = 0;
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
            int width = (panelWork.Width - 10*secondHalf.Count - x) / ((int)Math.Pow(2, firstHalf.Count)+1);

            x += width;

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

            y += height;
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

            y -= height;
            x -= width;
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

            for (int i = 0; i < rows + 1; i++) {
                if (i == 0) {
                    for (int j = 1; j < tables + 1; j++) {
                        TextBox textBox = ControlService.CreateTextbox(matrix.ElementAt(j-1).Key, new Point(x + j * width, y), new Size(width, height));
                        textBox.Name = "table_" + i + '_' + (j-1);
                        panelWork.Controls.Add(textBox);
                    }
                } else {
                    for (int j = 0; j < tables + 1; j++) {
                        TextBox textBox;
                        if (j == 0) {
                            textBox = ControlService.CreateTextbox(matrix.First().Value[i-1], new Point(x + j * width, y), new Size(width, height));
                            textBox.Name = "row_" + i + '_' + j;
                        } else {
                            textBox = ControlService.CreateTextbox("", new Point(x + j * width, y), new Size(width, height));
                            textBox.Name = "karno_first_" + (i-1) + '_' + (j-1);
                        }
                        panelWork.Controls.Add(textBox);
                    }
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
        }*/

    }
}
