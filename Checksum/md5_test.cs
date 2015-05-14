using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checksum
{
    public partial class md5_test : Form
    {
        public md5_test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(textBox1.Text));
            textBox2.Text = BitConverter.ToString(checkSum).Replace("-", String.Empty);

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            checkSum = sha1.ComputeHash(Encoding.UTF8.GetBytes(textBox1.Text));
            textBox5.Text = BitConverter.ToString(checkSum).Replace("-", String.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(textBox4.Text));
            textBox3.Text = BitConverter.ToString(checkSum).Replace("-", String.Empty);

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            checkSum = sha1.ComputeHash(Encoding.UTF8.GetBytes(textBox4.Text));
            textBox6.Text = BitConverter.ToString(checkSum).Replace("-", String.Empty);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
