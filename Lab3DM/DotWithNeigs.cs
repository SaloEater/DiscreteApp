namespace Lab3DM
{
    internal class DotWithNeigs : Dot
    {
        public int neigs;

        public DotWithNeigs(int row, int table, int neigs) : base(row, table)
        {
            this.neigs = neigs;
        }

        public override string ToString()
        {
            return base.ToString() + "|" + neigs;
        }
    }
}