using System;
using System.Collections.Generic;

namespace Lab3DM
{
    internal class KvaineOutput : IOutput
    {
        private List<KvaineRow> result, 
            function;

        public int rows, tables;

        public KvaineOutput(List<KvaineRow> result, List<KvaineRow> function)
        {
            this.result = result;
            this.function = function;
            rows = result.Count;
            tables = function.Count;
        }

        public Dictionary<string, string> makeOutput()
        {
            Dictionary<string, string> output = new Dictionary<string, string>();

            int index = 0;
            foreach(KvaineRow row in result) {
                output.Add("row_" + index++, row.ToString());
            }

            for(int i = 0; i < result.Count; i++) {
                KvaineRow row = result[i];
                for (int j = 0; j < function.Count; j++) {
                    if (row.CanAbsorb(function[j])) {
                        output.Add(i + "_" + j, "1");
                    } else {
                        output.Add(i + "_" + j, "0");
                    }
                }
            }

            return output;
        }
    }
}