using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Control;

namespace Lab3DM
{
    class ComputeSNF
    {
        int type;

        int[][] matrix;

        string value;

        public ComputeSNF(int type)
        {
            this.type = type;
        }

        public void setMatrix(int[][] matrix)
        {
            this.matrix = matrix;
        }

        public void Perform()
        {
            value = "";
            int iLen = matrix.Length;
            int jLen = matrix[0].Length;
            for (int i = 0; i < iLen; i++) {
                if (matrix[i][jLen-1] == type) {
                    continue;
                }
                for (int j = 0; j < jLen - 1; j++) {
                    //string negation = matrix[i][j] == type? "_": "";
                    string symbol = (type == 0 ? matrix[i][j] : (matrix[i][j] + 1) % 2)+"";
                    value += symbol; 
                    value += j == jLen - 2 ? "" : "*";
                }

                value += i == iLen - 1 ? "" : "+";
            }
            if(value[value.Length-1]=='+') {
                value = value.Substring(0, value.Length - 1);
            }
        }

        public string getValue()
        {
            return value;
        }
    }
}
