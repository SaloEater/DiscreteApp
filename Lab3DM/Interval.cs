using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DM
{
    class Interval
    {
        List<IntervalDot> dots;

        public Interval()
        {
            dots = new List<IntervalDot>();
        }

        public void Add(int i, int j, int offsetI, int offsetJ)
        {
            dots.Add(new IntervalDot(i, j, offsetI, offsetJ));
        }
    }
}
