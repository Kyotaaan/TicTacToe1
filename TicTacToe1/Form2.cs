using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe1
{
    public partial class Form2 : Form
    {
        private string adminName;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            adminName = textBox1.Text;

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Admin name cannot be empty, try again!", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (hasSpecialChar(textBox1.Text))
            {
                MessageBox.Show("Admin name cannot contain special characters, try again!", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else 
            {
                
                MessageBox.Show($"Welcome, {adminName}!", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
            textBox1.Text = "";
        }

        private bool hasSpecialChar(string text)
        {
            string specialChar = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            foreach (var item in specialChar)
            {
                if (text.Contains(item))
                    return true;
            }
            return false;
        }

    }
}