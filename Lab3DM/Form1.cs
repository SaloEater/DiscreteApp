using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3DM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void таблицаИстинностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPageWith(new TruthTable());
        }

        private void AddTabPageWith(IWindow element)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = element.Type;
            tabPage.Controls.Add(element);
            tabControl1.Controls.Add(tabPage);
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
        }

        private void сДНФToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPageWith(new SNF(0));
        }

        private void сКНФToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPageWith(new SNF(1));
        }

        private void карноКНФToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPageWith(new Karno(1));
        }

        private void карноДНФToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPageWith(new Karno(0));
        }

        private void квайнМКДНФToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPageWith(new Kvaine(0));
        }

        private void таблицаПокрытийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTabPageWith(new TableDecompose());
        }
    }
}
