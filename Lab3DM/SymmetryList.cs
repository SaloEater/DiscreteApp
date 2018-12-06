using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DM
{
    class SymmetryList
    {
        List<Symmetry> symmetries;
        public SymmetryList()
        {
            symmetries = new List<Symmetry>();
        }

        public void Add(int index)
        {
            symmetries.Add(new Symmetry(index));
        }

        public bool Contains(int index)
        {
            foreach (Symmetry s in symmetries) {
                if (s.Is(index)) {
                    return true;
                }
            }
            return false;
        }

        public Symmetry Get(int index)
        {
            foreach (Symmetry s in symmetries) {
                if (s.Is(index)) {
                    return s;
                }
            }
            throw new IndexOutOfRangeException();
        }

        public List<Symmetry> GetSymmetries()
        {
            return symmetries;
        }

        internal void CutAllHigher(int index)
        {
            for(int i = 0; i < symmetries.Count; i++) {
                Symmetry symmetry = symmetries[i];
                symmetry.CutAllHigher(index);
            }
        }

        public override string ToString()
        {
            return string.Join(",", symmetries);
        }
    }
}
