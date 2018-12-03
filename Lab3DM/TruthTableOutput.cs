using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DM
{
    class TruthTableOutput : IOutput
    {
        int[][] matrix;

        public TruthTableOutput(int[][] matrix)
        {
            this.matrix = matrix;
        }

        public int[][] getMatrix()
        {
            return matrix;
        }

    }
}
