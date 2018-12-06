using System;

namespace Lab3DM
{
    internal class Dot
    {
        public int row, table;

        public Dot(int row, int table)
        {
            this.row = row;
            this.table = table;
        }

        public override bool Equals(object obj)
        {
            Dot dot = (Dot)obj;
            return row == dot.row && table == dot.table;
        }

        public override string ToString()
        {
            return row + ":" + table;
        }

        internal Dot Increment()
        {
            return new Dot(row + 1, table + 1);
        }
    }
}