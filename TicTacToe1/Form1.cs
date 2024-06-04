using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe1
{
    public partial class Form1 : Form
    {

        protected string btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
        private bool isPlayerX = true;


        public Form1()
        {
            InitializeComponent();
            label5.Text = Form2.usrname;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            btn1 = btn2 = btn3 = btn4 = btn5 = btn6 = btn7 = btn8 = btn9 = string.Empty;

            button1.Text = button2.Text = button3.Text = button4.Text = button5.Text = button6.Text = button7.Text = button8.Text = button9.Text = string.Empty;
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = true;

            isPlayerX = true;

        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (isPlayerX)
                {
                    button.Text = "X";
                    isPlayerX = false;
                }
                else
                {
                    button.Text = "O";
                    isPlayerX = true;
                }
                button.Enabled = false;

                switch (button.Name)
                {
                    case "button1":
                        btn1 = button.Text;
                    break;

                    case "button2":
                        btn2 = button.Text;
                    break;

                    case "button3":
                        btn3 = button.Text;
                    break;

                    case "button4":
                        btn4 = button.Text;
                    break;

                    case "button5":
                        btn5 = button.Text;
                    break;

                    case "button6":
                        btn6 = button.Text;
                    break;

                    case "button7":
                        btn7 = button.Text;
                    break;

                    case "button8":
                        btn8 = button.Text;
                    break;

                    case "button9":
                        btn9 = button.Text;
                    break;

                }

                ButtonChecker checker = new ButtonChecker(btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9);
                string result = checker.checkPlayerWon();

                if (result != "No Winner Yet")
                {
                    label3.Text = result;
                    DisableAllButtons();
                }
            }
        }

        private void DisableAllButtons()
        {
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to log out?", "Log-out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dr == DialogResult.No)
            {
                //Get back to tictactoe game
            }
        }

        public abstract class GameChecker
        {
            public abstract string checkPlayerWon();
        }

        public class ButtonChecker : GameChecker
        {
            private string btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;

            public ButtonChecker(string b1, string b2, string b3, string b4, string b5, string b6, string b7, string b8, string b9)
            {
                btn1 = b1;
                btn2 = b2;
                btn3 = b3;
                btn4 = b4;
                btn5 = b5;
                btn6 = b6;
                btn7 = b7;
                btn8 = b8;
                btn9 = b9;
            }

            public override string checkPlayerWon()
            {

                // Rows

                if (!string.IsNullOrEmpty(btn1) && btn1 == btn2 && btn2 == btn3)
                {
                    return $"Player {btn1} wins!";
                }
                else if (!string.IsNullOrEmpty(btn4) && btn4 == btn5 && btn5 == btn6)
                {
                    return $"Player {btn4} wins!";
                }
                else if (!string.IsNullOrEmpty(btn7) && btn7 == btn8 && btn8 == btn9)
                {
                    return $"Player {btn7} wins!";
                }

                // Columns

                if (!string.IsNullOrEmpty(btn1) && btn1 == btn4 && btn4 == btn7)
                {
                    return $"Player {btn1} wins!";
                }
                else if (!string.IsNullOrEmpty(btn2) && btn2 == btn5 && btn5 == btn8)
                {
                    return $"Player {btn2} wins!";
                }
                else if (!string.IsNullOrEmpty(btn3) && btn3 == btn6 && btn6 == btn9)
                {
                    return $"Player {btn3} wins!";
                }

                // Diagonals

                if (!string.IsNullOrEmpty(btn1) && btn1 == btn5 && btn5 == btn9)
                {
                    return $"Player {btn1} wins!";
                }
                else if (!string.IsNullOrEmpty(btn3) && btn3 == btn5 && btn5 == btn7)
                {
                    return $"Player {btn3} wins!";
                }

                // Draw

                if (!new[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 }.Any(b => string.IsNullOrEmpty(b)))
                { 
                    return "It's a draw"; 
                }
                return "No Winner Yet";
            }
        }
    }
}