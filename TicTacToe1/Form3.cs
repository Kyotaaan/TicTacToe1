using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TicTacToe1
{
    public partial class Form3 : Form
    {
        public static List<User> users = new List<User>();

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Username cannot be empty", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Password cannot be empty, try again!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Confirm password cannot be empty, try again!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (password != confirmPassword)
            {
                MessageBox.Show("Password does not match with confirm password, try again!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (hasSpecialChar(textBox1.Text) || hasSpecialChar(textBox2.Text))
            {
                MessageBox.Show("Password cannot be empty, try again!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                // Create Account Code
                if (users.Any(user => user.GetUsername() == username))
                {
                    MessageBox.Show("Player name already exist!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                // Add the user to the list
                users.Add(new Player(username, password));

                MessageBox.Show("Player created!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox4.Text;
            string oldPassword = textBox5.Text;
            string newPassword = textBox6.Text;
            string confirmPassword = textBox7.Text;


            // Check if username or new password are empty
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username cannot be empty, try again!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrEmpty(oldPassword))
            {
                MessageBox.Show("Old password cannot be empty, try again!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("New password cannot be empty, try again!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if new password and confirm password match
            else if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password does not match with confirm password, try again!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Check if username exists
            User user = users.FirstOrDefault(u => u.GetUsername() == username);
            if (user == null)
            {
                MessageBox.Show("Username does not exist, please enter an existing username!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Update the password
            user.UpdatePassword(newPassword);

            MessageBox.Show("Password updated successfully!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool IsExistingPlayer(string username, string password)
        {
            return users.Any(user => user.VerifyLogin(username, password));
        }

        // Define the User class
        public abstract class User
        {
            protected string username;
            protected string password;

            public User(string username, string password)
            {
                this.username = username;
                this.password = password;
            }

            public string GetUsername()
            {
                return username;
            }

            public bool VerifyLogin(string username, string password)
            {
                return this.username == username && this.password == password;
            }

            public abstract void UpdatePassword(string newPassword);
        }

        // Define the Player class
        public class Player : User
        {
            public Player(string username, string password) : base(username, password)
            {

            }

            public override void UpdatePassword(string newPassword)
            {
                this.password = newPassword;
            }
        }

        // Define the Administrator class
        public class Administrator : User
        {
            private string adminName;

            public Administrator(string adminName, string username, string password) : base(username, password)
            {
                this.adminName = adminName;
            }

            public void UpdateAdminName(string adminName)
            {
                this.adminName = adminName;
            }

            public override void UpdatePassword(string newPassword)
            {
                this.password = newPassword;
            }
        }

        // Check for special characters
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.PasswordChar = '*';
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.PasswordChar = '*';
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.PasswordChar = '*';
        }

    }
}
