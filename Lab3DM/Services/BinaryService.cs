using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DM
{
    public static class BinaryService
    {

        public static List<List<int>> toDoubleDim(string function)
        {
            List<List<int>> array = new List<List<int>>();
            function = function.Replace("*", "");

            string[] all = function.Split('+');
            int[] single = new int[all[0].Length];
            int index;
            foreach (string one in all) {
                index = 0;
                foreach(char ch in one) {
                    single[index++] = (int)char.GetNumericValue(ch);
                }
                array.Add(single.ToList());
            }

            return array;
        }

    }
}
