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
            // create new About-box
            AboutBox1 box = new AboutBox1();
            box.Show();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // create new About-box
            AboutBox1 box = new AboutBox1();
            box.Show();
        }

        private void parityCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create new parity check window
            ParityCheck box = new ParityCheck();
            box.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close the app
            this.Close();
        }

        private void checksumTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create new checksum window
            Checksum_test box = new Checksum_test();
            box.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create new parity check window
            ParityCheck box = new ParityCheck();
            box.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // create new checksum window
            Checksum_test box = new Checksum_test();
            box.Show();
        }

        private void mD5TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create new hashsum test window
            md5_test box = new md5_test();
            box.Show();
        }

        private void luhnTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create new Luhn test window
            Luhn box = new Luhn();
            box.Show();
        }
    }
}
