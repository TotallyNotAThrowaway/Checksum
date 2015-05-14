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
    public partial class Checksum_test : Form
    {
        public Checksum_test()
        {
            InitializeComponent();
        }


        bool xor = false;
        bool par = false;
        int xorc = 0;
        int parc = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            String[] temp = textBox1.Lines;
            Random rand = new Random();
            int n = 0;
            foreach (string str in textBox1.Lines)
            {
                temp[n] = "";
                for (int i = 0; i < 8; i++)
                {
                    temp[n] += rand.Next(2);
                }
                n++;
            }
            textBox1.Lines = temp;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private string getFirstParityString()
        {
            string str = "";

            for (int j = 0; j < 8; j++)
            {
                int s = 1;
                for (int i = 0; i < 8; i++)
                {
                    s += (int)Char.GetNumericValue(textBox2.Lines[j][i]);
                    if (s > 1)
                        s = 0;
                }
                str += s;
            }

            return str;
        }

        private string getSecondParityString()
        {
            string str = "";

            for (int j = 0; j < 8; j++)
            {
                int s = 1;
                for (int i = 0; i < 8; i++)
                {
                    s += (int)Char.GetNumericValue(textBox2.Lines[i][j]);
                    if (s > 1)
                        s = 0;
                }
                str += s;
            }

            return str;
        }

        private string getXORString()
        {
            string str = "";
            for (int j = 0; j < 8; j++)
            {
                int s = 1;
                for (int i = 0; i < 8; i++)
                {
                    s += (int)Char.GetNumericValue(textBox3.Lines[j][i]);
                    if (s > 1)
                        s = 0;
                }
                str += s;
            }

            return str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Lines = textBox1.Lines;
            textBox2.Text += System.Environment.NewLine + getFirstParityString();
            textBox2.Text += System.Environment.NewLine + getSecondParityString();
            textBox3.Lines = textBox1.Lines;
            textBox3.Text += System.Environment.NewLine + getXORString();
            textBox4.Text = textBox2.Lines[8] + System.Environment.NewLine + textBox2.Lines[9];
            textBox5.Text = getFirstParityString() + System.Environment.NewLine + getSecondParityString();
            textBox6.Text = getXORString();
            textBox7.Text = textBox3.Lines[8];
            label5.Text = "success";
            label6.Text = "success";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String[] temp = textBox2.Lines;
            Random rand = new Random();
            int x = rand.Next(8);
            int y = rand.Next(10);
            int n = 0;
            foreach (string str in textBox2.Lines)
            {
                temp[n] = "";
                for (int i = 0; i < 8; i++)
                {
                    if ((x == i) && (y == n))
                    {
                        if ((int)Char.GetNumericValue(str[i]) == 0)
                            temp[n] += "1";
                        else
                            temp[n] += "0";
                    }
                    else
                        temp[n] += str[i];
                }
                n++;
            }
            textBox2.Lines = temp;
 
            string str1 = getFirstParityString();
            string str2 = getSecondParityString();

            textBox4.Text = textBox2.Lines[8] + System.Environment.NewLine + textBox2.Lines[9];
            textBox5.Text = str1 + System.Environment.NewLine + str2;

            if ((textBox2.Lines[8] == str1)&&(textBox2.Lines[9] == str2))
                label5.Text = "success";
            else
                label5.Text = "failure";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String[] temp = textBox3.Lines;
            Random rand = new Random();
            int x = rand.Next(8);
            int y = rand.Next(9);
            int n = 0;
            foreach (string str in textBox3.Lines)
            {
                temp[n] = "";
                for (int i = 0; i < 8; i++)
                {
                    if ((x == i) && (y == n))
                    {
                        if ((int)Char.GetNumericValue(str[i]) == 0)
                            temp[n] += "1";
                        else
                            temp[n] += "0";
                    }
                    else
                        temp[n] += str[i];
                }
                n++;
            }
            textBox3.Lines = temp;

            string chk = getXORString();


            textBox6.Text = chk;
            textBox7.Text = textBox3.Lines[8];

            if (textBox3.Lines[8] == chk)
                label6.Text = "success";
            else
                label6.Text = "failure";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = checkBox1.Checked;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            xor = false;
            par = false;
            xorc = 0;
            parc = 0;

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!xor)
            {
                String[] temp = textBox3.Lines;
                Random rand = new Random();
                int x = rand.Next(8);
                int y = rand.Next(9);
                int n = 0;
                foreach (string str in textBox3.Lines)
                {
                    temp[n] = "";
                    for (int i = 0; i < 8; i++)
                    {
                        if ((x == i) && (y == n))
                        {
                            if ((int)Char.GetNumericValue(str[i]) == 0)
                                temp[n] += "1";
                            else
                                temp[n] += "0";
                        }
                        else
                            temp[n] += str[i];
                    }
                    n++;
                }
                textBox3.Lines = temp;

                string chk = getXORString();


                textBox6.Text = chk;
                textBox7.Text = textBox3.Lines[8];

                if (textBox3.Lines[8] == chk)
                {
                    label6.Text = "success";
                    xor = true;
                }
                else
                    label6.Text = "failure";

                xorc++;
                label13.Text = "";
                label13.Text += xorc;
            }


            if (!par)
            {
                String[] temp = textBox2.Lines;
                Random rand = new Random();
                int x = rand.Next(8);
                int y = rand.Next(10);
                int n = 0;
                foreach (string str in textBox2.Lines)
                {
                    temp[n] = "";
                    for (int i = 0; i < 8; i++)
                    {
                        if ((x == i) && (y == n))
                        {
                            if ((int)Char.GetNumericValue(str[i]) == 0)
                                temp[n] += "1";
                            else
                                temp[n] += "0";
                        }
                        else
                            temp[n] += str[i];
                    }
                    n++;
                }
                textBox2.Lines = temp;

                string str1 = getFirstParityString();
                string str2 = getSecondParityString();

                textBox4.Text = textBox2.Lines[8] + System.Environment.NewLine + textBox2.Lines[9];
                textBox5.Text = str1 + System.Environment.NewLine + str2;

                if ((textBox2.Lines[8] == str1) && (textBox2.Lines[9] == str2))
                {
                    label5.Text = "success";
                    par = true;
                }
                else
                    label5.Text = "failure";

                parc++;
                label14.Text = "";
                label14.Text += parc;
            }

            if (xor && par) timer1.Enabled = false;
        }
    }
}
