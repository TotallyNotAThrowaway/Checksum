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
        
        // these are used for bruteforcing the message by timer
  
        private bool xor = false;
        private bool par = false;
        private int xorc = 0;
        private int parc = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            // generating a random message containing 8 bytes

            String[] temp = textBox1.Lines;         // initialize temperary string array
            Random rand = new Random();
            int n = 0;                              // we use this to count the line number
            foreach (string str in textBox1.Lines)  // speaks for itself
            {  
                temp[n] = "";
                for (int i = 0; i < 8; i++)
                {
                    temp[n] += rand.Next(2);        // adding next bit the same way as always
                }
                n++;
            }
            textBox1.Lines = temp;                  // finally transfer temporary value to textBox
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // why do I even have this? It's useless! It does nothing! Why are you reading this?!
        }

        private string getFirstParityString()
        {
            // we would use this code two or three times in the project, so I figured I'll make it a proper function
            // this gets the first parity bite for Block Parity check; it contains all the parity bites for every row

            string str = "";

            for (int j = 0; j < 8; j++)                                     // basically same as in plane parity check, but for every string in the input and put it all in one string
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

            return str;                                                     // return the produced string, of cource... would be stupid not to do that
        }

        private string getSecondParityString()
        {
            // we would use this code two or three times in the project, so I figured I'll make it a proper function
            // this gets the second parity bite for Block Parity check; it contains all the parity bites for every column

            string str = "";

            for (int j = 0; j < 8; j++)
            {
                int s = 1;
                for (int i = 0; i < 8; i++)
                {
                    s += (int)Char.GetNumericValue(textBox2.Lines[i][j]);   // literally the same as a first one, but transposed indexes
                    if (s > 1)
                        s = 0;
                }
                str += s;
            }

            return str;
        }

        private string getXORString()
        {
            // we would use this code two or three times in the project, so I figured I'll make it a proper function
            // this gets the bite for XOR check; it basically every single row XOR-ed onto each eother

            // it looks familiar. It's different in some way, I forgot how exactly... but it works, so fuck it
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
            // send the input to Block Parity and XOR checks 

            textBox2.Lines = textBox1.Lines;                                                                // copy the input to Block Parity check message
            textBox2.Text += System.Environment.NewLine + getFirstParityString();                           // add a first check bite to the next line
            textBox2.Text += System.Environment.NewLine + getSecondParityString();                          // add a second check string to the next line
            textBox3.Lines = textBox1.Lines;                                                                // copy the input to XOR check
            textBox3.Text += System.Environment.NewLine + getXORString();                                   // add a check string to the next line
            textBox4.Text = textBox2.Lines[8] + System.Environment.NewLine + textBox2.Lines[9];             // copy the Block Parity check bites to a textBox on the right for easier visual comparising
            textBox5.Text = getFirstParityString() + System.Environment.NewLine + getSecondParityString();  // calculate the same thing from the message to the box below. It is always the same, but this is more fair this way
            textBox6.Text = getXORString();                                                                 // copy XOR check bite to the textBox on the right
            textBox7.Text = textBox3.Lines[8];                                                              // calculate the same thing
            label5.Text = "success";                                                                        // reset the indication labels. It's always gonna be the same, so there's no need for a check
            label6.Text = "success";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // corrupt a random bit in a Block Parity check message
            // contains the same trickery from  parity check corruption method, but for every string

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

            // at this point we ruined a bit our message, so let's see if parity bites checks out!
 
            string str1 = getFirstParityString();                                               // calculate new check bites
            string str2 = getSecondParityString();

            textBox4.Text = textBox2.Lines[8] + System.Environment.NewLine + textBox2.Lines[9]; // display them in the box to the right
            textBox5.Text = str1 + System.Environment.NewLine + str2;

            if ((textBox2.Lines[8] == str1)&&(textBox2.Lines[9] == str2))                       // see if they match
                label5.Text = "success";
            else
                label5.Text = "failure";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // corrupt a bit in XOR check
            // same trickery as always. I pretty much copied the code

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
            // I dunno why, but I diceded to hide the bruteforce box, but whatever

            groupBox1.Visible = checkBox1.Checked;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            // this is useless
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // reset the things we want to count as well as both flags

            xor = false;
            par = false;
            xorc = 0;
            parc = 0;

            // start the bruteforce by enabling the timer so it runs 1000-ish times per second... spoiler: it doesn't

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // bruteforce time. This runs for every timer tick

            if (!xor)                                                                                   // if XOR check never hit a match
            {                                                       
                String[] temp = textBox3.Lines;                                                         // we ruin one random bit like we did before
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

                if (textBox3.Lines[8] == chk)                                                           // see if we scored a match
                {
                    label6.Text = "success";
                    xor = true;                                                                         // if we did, mark the flag so we stop doing what we're doing
                }
                else
                    label6.Text = "failure";

                xorc++;                                                                                 // increase the number of iterations taken so far
                label13.Text = "";                                                                      // and display it
                label13.Text += xorc;
            }


            if (!par)                                                                                   // do abso-fucking-lutely the same for block parity check
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

            if (xor && par) timer1.Enabled = false;                                                 // if we hit a match on both block parity and XOR checks, disable this timer and stop the thing
        }
    }
}
