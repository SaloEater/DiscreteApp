using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DM
{
    public static class StringService
    {
        public static bool BinaryString(string one)
        {
            foreach (char c in one) {
                if (c != '0' && c != '1') {
                    return false;
                }
            }
            return true;
        }
    }
}
