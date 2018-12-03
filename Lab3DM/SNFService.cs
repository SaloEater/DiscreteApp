using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Control;

namespace Lab3DM
{
    class SNFService
    {
        public int[][] SerializeControlCollection(ControlCollection collection, int tables, int rows)
        {
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++) {
                matrix[i] = new int[tables];
                for (int j = 0; j < tables; j++) {
                    matrix[i][j] = int.Parse(collection[i * tables + j].Text);
                }
            }

            return matrix;
        }
    }
}
