using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3DM
{
    public partial class IWindow : UserControl
    {
        protected int currentY;

        protected IWindow previousOperation;

        protected List<Type> supportedTypes;

        public string Type { get; internal set; }

        protected IWindow()
        {
            previousOperation = null;
            supportedTypes = new List<Type>();
            currentY = 0;
            Type = "Неопределенное окно";
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime) {
                Dock = DockStyle.Fill;
            }
        }

        internal bool isSupported(Type type)
        {
            return supportedTypes.Contains(type);
        }

        protected virtual void fillFromPrevious() // Заполнение и получение информации из другого окна
        {
            throw new NotImplementedException();
        }

        public virtual IOutput getOutput()
        {
            throw new NotImplementedException();
        }

        public List<Type> getSupportedTypes()
        {
            return supportedTypes;
        }

        public void setPrevious(IWindow operation)
        {
            previousOperation = operation;
            fillFromPrevious();
        }
    }
}
