using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DM
{
    class Interval
    {
        Dot origin;
        List<IntervalShift> shifts;

        public Interval(Dot origin)
        {
            shifts = new List<IntervalShift>();
            this.origin = origin;
            Add(0, 0);
        }

        internal void Add(IntervalShift shift)
        {
            shifts.Add(shift);
        }

        public void Add(int offsetI, int offsetJ)
        {
            shifts.Add(new IntervalShift(offsetI, offsetJ));
        }

        internal IntervalShift Get(int index)
        {
            return shifts[index];
        }

        internal List<IntervalShift> getShifts()
        {
            return shifts;
        }

        internal Dot getOrigin()
        {
            return origin;
        }

        public void CopyAndMoveHalfOnTable(int tableOffset)
        {
            int current = shifts.Count;
            for (int i = 0; i < current; i++) {
                shifts.Add(shifts[i].offsetTableOn(tableOffset, true));
            }
        }

        internal void CopyAndMoveHalfOnRow(int rowOffset)
        {
            int current = shifts.Count;
            for (int i = 0; i < current; i++) {
                shifts.Add(shifts[i].offsetRowOn(rowOffset, true));
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach(IntervalShift shift in shifts) {
                str += (origin.row + shift.offsetI) + "," + (origin.table + shift.offsetJ) + ", ";
            }
            return str;
        }

        public bool Contains(IntervalShift shift)
        {
            foreach(IntervalShift s in shifts) {
                if (s.offsetI == shift.offsetI && s.offsetJ == shift.offsetJ) {
                    return true;
                }
            }
            return false;
        }

        internal void MirrorAround(IntervalShift direction, Dot newOrigin)
        {
            int current = shifts.Count;
            for (int i = 0; i < current; i++) {
                IntervalShift shift = shifts[i].CreateCopy();
                shift.setI(direction.offsetI == 0 ? shift.offsetI : shift.rOffsetI + (newOrigin.row - origin.row));
                shift.setJ(direction.offsetJ == 0 ? shift.offsetJ : shift.rOffsetJ + (newOrigin.table - origin.table));
                shifts.Add(shift);
            }
        }

        internal Dot getEdgeInDirectrion(IntervalShift direction)
        {
            IntervalShift best = null;
            //Проверяем вертикально
            switch (direction.offsetI) {
                case 0: {
                        //Проверяем горизонтально
                        switch(direction.offsetJ) {
                            case 1: {
                                    //Самый правый
                                    best = shifts[0];
                                    foreach (IntervalShift shift in shifts) {
                                        if (shift.offsetJ > best.offsetJ) {
                                            best = shift;
                                        }
                                    }
                                    break;
                                }

                            case -1: {
                                    //Самый левый
                                    best = shifts[0];
                                    foreach (IntervalShift shift in shifts) {
                                        if (shift.offsetJ < best.offsetJ) {
                                            best = shift;
                                        }
                                    }
                                    break;
                                }
                        }
                    break;
                }

                case 1: {
                        //Самый нижний
                        best = shifts[0];
                        foreach (IntervalShift shift in shifts) {
                            if (shift.offsetI > best.offsetI) {
                                best = shift;
                            }
                        }
                        break;
                }

                case -1: {
                        //Самый верхний

                        best = shifts[0];
                        foreach (IntervalShift shift in shifts) {
                            if (shift.offsetI < best.offsetI) {
                                best = shift;
                            }
                        }
                        break; 
                }
            }
            return best.ApplyOn(origin, false);
        }

        internal bool HasReferenceTo(Dot tableOrigin)
        {
            foreach(IntervalShift shift in shifts) {
                if (tableOrigin.Equals(shift.ApplyOn(origin, false))) {
                    return true;
                }
            }
            return false;
        }

        internal string makeString()
        {
            string str = "";

            foreach (IntervalShift shift in shifts)
            {
                str += shift.ApplyOn(origin).Increment().ToString() + ", ";
            }

            return str;
        }

        internal List<Dot> createDots()
        {
            List<Dot> dots = new List<Dot>();

            foreach (IntervalShift shift in shifts) {
                dots.Add(shift.ApplyOn(origin));
            }

            return dots;
        }
    }
}
