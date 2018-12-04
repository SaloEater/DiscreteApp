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
        List<int> symmetries;

        public Symmetry(int index)
        {
            this.index = index;
            symmetries = new List<int>();
        }

        public void Add(int point)
        {
            symmetries.Add(point);
        }

        public List<int> GetSymmetries()
        {
            return symmetries;
        }

        internal bool Is(int index)
        {
            return this.index == index;
        }

        public int Get()
        {
            return index;
        }
    }
}
