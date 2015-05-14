using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checksum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.Show();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.Show();
        }

        private void parityCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParityCheck box = new ParityCheck();
            box.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checksumTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checksum_test box = new Checksum_test();
            box.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParityCheck box = new ParityCheck();
            box.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Checksum_test box = new Checksum_test();
            box.Show();
        }

        private void mD5TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            md5_test box = new md5_test();
            box.Show();
        }

        private void luhnTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Luhn box = new Luhn();
            box.Show();
        }
    }
}
