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
    public partial class ParityCheck : Form
    {
        public ParityCheck()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allowing 1-s and 0-s in this textbox

            if (Char.IsDigit(e.KeyChar))                        // if the input is digit
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '1')       // only allowing 1-s and 0-s
                    e.Handled = false;
                else
                    e.Handled = true;

                return;
            }
            if (Char.IsControl(e.KeyChar)) return;              // also allow control keys such as navigation and backspaces
            e.Handled = true;                                   // block everything else
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this generates random 7-bite word

            Random rand = new Random();
            textBox1.Text = "";
            for (int i = 0; i < 7; i++) 
            {
                textBox1.Text += rand.Next(2);
            }
        }

        private string Random()
        {
            throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // calculate and display parity bite

            int s = 1;                                              // this is our parity bite. Indicates even by default
            for (int i = 0; i < 7; i++)
            {
                s += (int)Char.GetNumericValue(textBox1.Text[i]);   // add a next digit from the input
                if (s > 1)                                          // make sure our parity bite is actually a bite by making it always less than 2
                    s = 0;
            }
            textBox3.Text = "";                                     
            textBox3.Text += s;                                     // textBox3 displays parity bite only
            textBox2.Text = textBox1.Text + textBox3.Text;          // textBox2 displays the whole message. Copied from input and added a parity bite at the end
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // proceed the message to reciever

            textBox4.Text = textBox2.Text;


            // checking the parity bit the same way we calculated it in the first place
            int s = 1;
            for (int i = 0; i < 7; i++)
            {
                s += (int)Char.GetNumericValue(textBox4.Text[i]);
                if (s > 1)
                    s = 0;
            }

            textBox5.Text = "";
            textBox5.Text += s;                                     // display the expected parity bite
            if (textBox5.Text[0] == textBox4.Text[7])               // compare it to the recieved parity bite and display the according result
                label6.Text = "success";                    
            else
                label6.Text = "failure";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // this contains some trickery, but it should corrupt one bit of the message at random

            Random rand = new Random();
            int r = rand.Next(8);                               // decide which bite to corrupt
            string s = textBox2.Text;
            textBox2.Text = "";
            for (int i = 0; i < 8; i++)                         // this either translates the old bit value, or, if the bit is the one we chose to corrupt, changes it's value to opposite
            {
                if (i == r)
                {
                    if ((int)Char.GetNumericValue(s[i]) == 0)
                    {
                        textBox2.Text += "1";
                    }
                    else
                    {
                        textBox2.Text += "0";
                    }
                }
                else
                    textBox2.Text += s[i];
            }
        }
    }
}
