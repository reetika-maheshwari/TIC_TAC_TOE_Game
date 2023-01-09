using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIC_TAC_TOE_Game
{
    public partial class Tic_Tac_Game : Form
    {
        public Tic_Tac_Game()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //add action to all buttons inside panelTICButtons
            foreach (Control c in panelTIC.Controls)
            {
                if (c is Button)
                {
                    c.Click += new System.EventHandler(btn_click);
                }
            }
        }
        int XorO = 0;
        // create button action
        public void btn_click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (btn.Text.Equals("")) // we will clear text from buttons later
            {
                if (XorO % 2 == 0)
                {
                    btn.Text = "X";
                    btn.ForeColor = Color.Blue;
                    label1.Text = "O turn now";
                }
                else
                {
                    btn.Text = "O";
                    btn.ForeColor = Color.Red;
                    label1.Text = "X turn now";
                }

                if(getTheWinner() == true)
                {
                    label1.Text = btn.Text + " is the winner";
                    return;
                }
                XorO++;
            }
        }

        public bool getTheWinner()
        {
            if(!button1.Text.Equals("") && button1.Text.Equals(button2.Text) && button1.Text.Equals(button3.Text))
            {
                winEffect(button1, button2, button3);
                return true;
            }
            if (!button4.Text.Equals("") && button4.Text.Equals(button5.Text) && button4.Text.Equals(button6.Text))
            {
                winEffect(button4, button5, button6);
                return true;
            }
            if (!button7.Text.Equals("") && button7.Text.Equals(button8.Text) && button7.Text.Equals(button9.Text))
            {
                winEffect(button7, button8, button9);
                return true;
            }
            if (!button1.Text.Equals("") && button1.Text.Equals(button4.Text) && button1.Text.Equals(button7.Text))
            {
                winEffect(button1, button4, button7);
                return true;
            }
            if (!button2.Text.Equals("") && button2.Text.Equals(button5.Text) && button2.Text.Equals(button8.Text))
            {
                winEffect(button2, button5, button8);
                return true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button6.Text) && button3.Text.Equals(button9.Text))
            {
                winEffect(button3, button6, button9);
                return true;
            }
            if (!button1.Text.Equals("") && button1.Text.Equals(button5.Text) && button1.Text.Equals(button9.Text))
            {
                winEffect(button1, button5, button9);
                return true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button5.Text) && button3.Text.Equals(button7.Text))
            {
                winEffect(button3, button5, button7);
                return true;
            }
            // if no one win
            // if all buttons are not empty
            // we can but 1 char in a button "X or O"
            // we have 9 buttins
            // mean 9 char in Length

            if(AllBtnLength() == 9)
            {
                label1.Text = "No Winner";
            }

            return false;
        }
        public int AllBtnLength()
        {
            int allTextButtonsLength = 0;
            foreach (Control c in panelTIC.Controls)
            {
                if (c is Button)
                {
                    allTextButtonsLength += c.Text.Length;
                }
            }
            return allTextButtonsLength;
        }

        public void winEffect(Button b1, Button b2, Button b3)
        {
            b1.BackColor = Color.Green;
            b2.BackColor = Color.Green;
            b3.BackColor = Color.Green;

            b1.ForeColor = Color.White;
            b2.ForeColor = Color.White;
            b3.ForeColor = Color.White;

            label1.Text = b1.Text + "Win";
            
            

        }

        private void buttonPartie_Click(object sender, EventArgs e)
        {
            XorO = 0;
            label1.Text = "Play";
            foreach (Control c in panelTIC.Controls)
            {
                if (c is Button)
                {
                    c.Text = "";
                    c.BackColor = Color.White;
                }
            }

        }
    }
}
