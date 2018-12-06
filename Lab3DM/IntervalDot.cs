using System;

namespace Lab3DM
{
    internal class IntervalShift
    {
        public int offsetI, offsetJ, rOffsetI, rOffsetJ;

        public IntervalShift(int offsetI, int offsetJ)
        {
            this.offsetI = offsetI;
            this.offsetJ = offsetJ;
            rOffsetI = -offsetI;
            rOffsetJ = -offsetJ;
        }

        internal Dot ApplyOn(Dot tableOrigin, bool invertRow = false, bool invertTable = false)
        {
            Dot dot = new Dot(tableOrigin.row + (invertRow ? rOffsetI : offsetI), 
                tableOrigin.table + (invertTable ? rOffsetJ : offsetJ));
            return dot;
        }

        internal IntervalShift offsetTableOn(int tableOffset, bool invert)
        {
            IntervalShift shift = new IntervalShift(offsetI, (invert ? rOffsetJ : offsetJ) + tableOffset);
            return shift;
        }

        internal IntervalShift offsetRowOn(int rowOffset, bool invert)
        {
            return new IntervalShift((invert ? rOffsetI : offsetI) + rowOffset, offsetJ);
        }

        internal IntervalShift Move(IntervalShift sideShift, bool invert)
        {
            return new IntervalShift(offsetI + (invert ? sideShift.rOffsetI : sideShift.offsetI), offsetJ + (invert ? sideShift.rOffsetJ : sideShift.offsetJ));
        }

        internal IntervalShift mirrorInDirection(IntervalShift rowOffset)
        {
            IntervalShift shift = new IntervalShift(
                (rowOffset.offsetI == 0 ? offsetI : rOffsetI) + rowOffset.offsetI,
                (rowOffset.offsetJ == 0 ? offsetJ : rOffsetJ) + rowOffset.offsetJ
            );
            return shift;
        }

        public override string ToString()
        {
            return offsetI + ":" + offsetJ;
        }

        internal IntervalShift CreateCopy()
        {
            return new IntervalShift(offsetI, offsetJ);
        }

        internal void setI(int value)
        {
            this.offsetI = value;
            rOffsetI = -value;
        }

        internal void setJ(int value)
        {
            this.offsetJ = value;
            rOffsetJ = -value;
        }
    }
}