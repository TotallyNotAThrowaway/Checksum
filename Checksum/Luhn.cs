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
            // check if number is correct by using Luhn algorithm 

            string s = textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text;   // first get the whole string
            int sum = 0;                                                                // initialize the sum
            try                                                                         // in case the user didn't fill all the numbers in, put everything in a try-tag
            {
                for (int i = 0; i < 16; i += 2)                                         // for the whole string
                {
                    if ((int)Char.GetNumericValue(s[i]) > 4)                            // for every odd position if 2*s[i]>9
                        sum += (int)Char.GetNumericValue(s[i]) * 2 - 9;                 // we add a 2*s[i]-9 to the sum
                    else
                        sum += (int)Char.GetNumericValue(s[i]) * 2;                     // otherwise just ass 2*s[i]
                    sum += (int)Char.GetNumericValue(s[i + 1]);                         // for every even position, just add s[i] to the sum
                }
                if (sum % 10 == 0)                                                      // if the result can be divided by 10 then the input number is correct
                    label1.Text = "Correct!";
                else
                    label1.Text = "Incorrect!";
            }
            catch { }                                                                   // we don't catch anything. The only thing happening is ArrayOutOfBounds anyway, who cares?
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 4) textBox2.Focus();    // switch to next text box once this one is full
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 4) textBox3.Focus();    // switch to next text box once this one is full
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 4) textBox4.Focus();    // switch to next text box once this one is full
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 4) runLuhn();          // check if input is correct once (hopefully) all of the boxes are full
        }

        // for next 4 calls we just make sure we only allow numeric input as well as clontrol keys in all textboxes

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
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
            runLuhn();      // check Luhn manually
        }
    }
}
