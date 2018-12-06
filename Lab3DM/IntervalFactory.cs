using System;
using System.Collections.Generic;

namespace Lab3DM
{
    public static class IntervalFactory
    {
        internal static Interval CreateCopy(Interval interval)
        {
            Interval newOne = new Interval(interval.getOrigin());
            List<IntervalShift> list = interval.getShifts();
            for (int i = 1; i < list.Count; i++) {
                IntervalShift shift = list[i];
                newOne.Add(shift);
            }
            return newOne;
        }
    }
}