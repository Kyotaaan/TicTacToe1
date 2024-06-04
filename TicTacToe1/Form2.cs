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
using static TicTacToe1.Form3;

namespace TicTacToe1
{
    public partial class Form2 : Form
    {

        public static string usrname = "";
        public static List<User> users = new List<User>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Admin name cannot be empty, try again!", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Admin password cannot be empty, try again!", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (hasSpecialChar(textBox1.Text))
            {
                MessageBox.Show("Admin name cannot contain special characters, try again!", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else 
            {
                MessageBox.Show("Welcome!", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3 form3 = new Form3();
                form3.Show();
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string password = textBox4.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username cannot be empty, try again!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password cannot be empty, try again!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty, try again!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (IsExistingPlayer(username, password))
            {
                usrname = textBox3.Text;
                MessageBox.Show("Log-in Successful", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = new Form1();
                form1.Show();
            }

            else
            {
                MessageBox.Show("Invalid username or password, please try again!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "";
                textBox4.Text = "";
                return;
            }

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


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
        }
    }
}