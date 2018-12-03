using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DM
{
    class ComputeTruthTable
    {
        int[][] matrix;

        public int[][] getMatrix()
        {
            return matrix;
        }

        public void Perform(string function, int rows, int tables)
        {
            matrix = new int[rows][];

            for (int i = 0; i < rows; i++) {
                matrix[i] = new int[tables+1];
                for (int j = 0; j < tables; j++) {
                    int interval = (int)Math.Pow(2, tables - j - 1);
                    double buf = i / interval;
                    int value = (int)Math.Floor(buf) % 2;
                    matrix[i][j] = value;
                }
                matrix[i][tables] = (int)char.GetNumericValue(function[i]);
            }
        }
    }
}
