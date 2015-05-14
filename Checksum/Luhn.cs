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
    public partial class Luhn : Form
    {
        public Luhn()
        {
            InitializeComponent();
        }

        private void runLuhn()
        {
            string s = textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text;
            int sum = 0;
            try
            {
                for (int i = 0; i < 16; i += 2)
                {
                    if ((int)Char.GetNumericValue(s[i]) > 4)
                        sum += (int)Char.GetNumericValue(s[i]) * 2 - 9;
                    else
                        sum += (int)Char.GetNumericValue(s[i]) * 2;
                    sum += (int)Char.GetNumericValue(s[i + 1]);
                }
                if (sum % 10 == 0)
                    label1.Text = "Correct!";
                else
                    label1.Text = "Incorrect!";
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 4) textBox2.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 4) textBox3.Focus();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 4) textBox4.Focus();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           if (textBox4.Text.Length == 4) runLuhn();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            runLuhn();
        }
    }
}
