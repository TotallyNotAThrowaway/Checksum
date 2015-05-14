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
            if (Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '1')
                    e.Handled = false;
                else
                    e.Handled = true;

                return;
            }
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            int s = 1;
            for (int i = 0; i < 7; i++)
            {
                s += (int)Char.GetNumericValue(textBox1.Text[i]);
                if (s > 1) 
                    s = 0;
            }
            textBox3.Text = "";
            textBox3.Text += s;
            textBox2.Text = textBox1.Text + textBox3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox2.Text;

            int s = 1;
            for (int i = 0; i < 7; i++)
            {
                s += (int)Char.GetNumericValue(textBox4.Text[i]);
                if (s > 1)
                    s = 0;
            }

            textBox5.Text = "";
            textBox5.Text += s;
            if (textBox5.Text[0] == textBox4.Text[7])
                label6.Text = "success";
            else
                label6.Text = "failure";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int r = rand.Next(8);
            string s = textBox2.Text;
            textBox2.Text = "";
            for (int i = 0; i < 8; i++)
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
