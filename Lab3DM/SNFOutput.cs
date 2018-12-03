using System;

namespace Lab3DM
{
    internal class SNFOutput : IOutput
    {
        string function;

        public SNFOutput(string function)
        {
            this.function = function;
        }

        internal string getFunction()
        {
            return function;
        }
    }
}