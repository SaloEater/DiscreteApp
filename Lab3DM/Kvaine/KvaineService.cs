using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3DM
{
    class KvaineService
    {
        private int typeValid;
        private int typeInvalid;

        //Исходные данные
        private List<KvaineRow> function;

        //Выходные данные
        private List<KvaineRow> result;
        private List<KvaineRow> current;

        private Panel panel;

        private int textBoxWidth;
        private int uiRow;

        public List<KvaineRow> GetFunction()
        {
            return function;
        }

        public List<KvaineRow> GetResult()
        {
            return result;
        }

        public KvaineService(char typeValid, char typeInvalid)
        {
            this.typeValid = (int)char.GetNumericValue(typeValid);
            this.typeInvalid = (int)char.GetNumericValue(typeInvalid);
            panel = null;
            textBoxWidth = 0;
        }

        

        public void SetPanel(Panel panel)
        {
            this.panel = panel;
        }

        public void SetWidth(int width)
        {
            textBoxWidth = width;
        }

        public void SetFunction(List<List<int>> function)
        {
            this.function = new List<KvaineRow>();
            foreach(List<int> a in function) {
                this.function.Add(new KvaineRow(a, typeValid));
            }
        }

        public void Start()
        {
            uiRow = 0;
            result = new List<KvaineRow>();
            current = SortByDescending(function.ToList());
            BeginCycle();
        }

        private void BeginCycle()
        {
            int originalLength = current.Count;
            for (int i = 0; i < current[0].Length(); i++) {
                for (int j = 0; j < originalLength; j++) { 
                    KvaineRow original = current[j];
                    if(original.GetValids() < i) {
                        continue;
                    }
                    if(original.GetValids() > i) {
                        break;
                    }
                    for (int k = 0; k < originalLength; k++) {
                        KvaineRow suspect = current[k];
                        if (suspect.GetValids() <= i) {
                            continue;
                        }
                        if (suspect.GetValids() > i + 1) {
                            break;
                        }
                        int index;
                        if (CanGlue(original, suspect, out index)) {
                            original.Use();
                            suspect.Use();
                            KvaineRow one = original.MarkAt(index);
                            AddToCurrent(one);
                        }
                    }
                }
            }
            int z = 0;
            for (int i = 0; i < originalLength; i++, z++) {
                KvaineRow row = current[i];
                TextBox textBox = ControlService.CreateTextbox(
                        row.ToString(),
                        new System.Drawing.Point(textBoxWidth * uiRow, z * 25),
                        true,
                        new System.Drawing.Size(textBoxWidth, 25)
                    );
                if (!row.IsUsed()) {
                    result.Add(row);
                    textBox.BackColor = Color.Red;
                }
                panel.Controls.Add(textBox);
                current.RemoveAt(i);
                i--;
                originalLength--;
            }
            uiRow++;
            if (current.Count > 0) {
                current = SortByDescending(current);
                BeginCycle();
            }
        }

        private void AddToCurrent(KvaineRow one)
        {
            foreach (KvaineRow row in current) {
                if (row.Equals(one)) {
                    return;
                }
            }
            current.Add(one);
        }

        private bool CanGlue(KvaineRow original, KvaineRow suspect, out int index)
        {
            int diffs = 0;
            index = -1;
            int a, b;
            for (int i = 0; i < original.Length(); i++) {
                a = original.At(i);
                b = suspect.At(i);
                if (a!=b) {
                    diffs++;
                    if(diffs > 2) {
                        break;
                    }
                }
                if (a == 1 && b == 0 || a == 0 && b == 1) {
                    diffs++;
                    if (diffs > 2) {
                        break;
                    }
                    index = i;
                }

            }
            if (diffs > 2 || index == -1) {
                return false;
            } else {
                return true;
            }
            
        }

        

        private List<KvaineRow> SortByDescending(List<KvaineRow> item)
        {
            item.Sort((KvaineRow a, KvaineRow b) =>
            {
                int first = a.GetValids();

                int second = b.GetValids(); 

                if (first > second) {
                    return 0;
                } else if (first < second) {
                    return -1;
                } else {
                    return 1;
                }
            });
            return item;
        }
    }

    internal class KvaineRow
    {
        private List<int> row;
        private int typeValid;

        private int valids = 0;

        private bool used = false;

        public KvaineRow(List<int> a, int typeValid)
        {
            this.typeValid = typeValid;
            row = new List<int>();
            foreach (int _a in a) {
                row.Add(_a);
                if (_a == typeValid) {
                    valids++;
                }
            }
        }

        internal int GetValids()
        {
            return valids;
        }

        public int Length()
        {
            return row.Count;
        }

        public void Use()
        {
            used = true;
        }

        public bool IsUsed()
        {
            return used;
        }

        public int At(int i)
        {
            return row[i];
        }

        internal KvaineRow MarkAt(int index)
        {
            KvaineRow one = new KvaineRow(row, typeValid);
            one.Replace(index);
            return one;            
        }

        public void Replace(int index)
        {
            row[index] = -1;
        }

        public override string ToString()
        {
            return string.Join("", row).Replace("-1", "-");
        }

        public override bool Equals(object obj)
        {
            KvaineRow one = (KvaineRow)obj;
            for(int i = 0; i < row.Count; i++) {
                if(row[i]!=one.At(i)) {
                    return false;
                }
            }
            return true;
        }

        internal bool CanAbsorb(KvaineRow kRow)
        {
            for (int i = 0; i < row.Count; i++) {
                if (
                    (row[i] != -1 && kRow.At(i) != -1 && row[i] != kRow.At(i) ||
                    (row[i] != -1 && kRow.At(i) == -1)
                    )
                ) { 
                    return false;
                }
            }
            return true;
        }
    }
}
