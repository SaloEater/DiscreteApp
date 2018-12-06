using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DM
{
    class Symmetry
    {
        int index;
        List<int> items;

        public Symmetry(int index)
        {
            this.index = index;
            items = new List<int>();
        }

        public void Add(int point)
        {
            items.Add(point);
        }

        public List<int> GetSymmetries()
        {
            return items;
        }

        internal bool Is(int index)
        {
            return this.index == index;
        }

        public int Get()
        {
            return index;
        }

        internal void CutAllHigher(int index)
        {
            for(int i = 0; i < items.Count; i++) {
                if (items[i] > index) {
                    items.RemoveAt(i);
                    i = -1;
                }
            }
        }

        public override string ToString()
        {
            return "(" + index + "):" + string.Join(":", items);
        }

        internal bool ContainsSymmetry(int lookingFor)
        {
            foreach (int symm in items) {
                if (symm == lookingFor) {
                    return true;
                }
            }
            return false;
        }
    }
}
