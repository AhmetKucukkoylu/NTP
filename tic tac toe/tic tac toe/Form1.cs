using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count = 0;// tur saymak için
        void restartgame()
        {
            Application.Restart();
        }

        void checkwinner(string symbol)
        {
            if (button1.Text== symbol && button2.Text==symbol && button3.Text==symbol)
            {
                MessageBox.Show(symbol+" Won the game");
                restartgame();
            }
            else if (button4.Text == symbol && button5.Text == symbol && button6.Text == symbol)
            {
                MessageBox.Show(symbol + " Won the game");
                restartgame();
            }
            else if (button7.Text == symbol && button8.Text == symbol && button9.Text == symbol)
            {
                MessageBox.Show(symbol + " Won the game");
                restartgame();
            }
            else if (button1.Text == symbol && button4.Text == symbol && button7.Text == symbol)
            {
                MessageBox.Show(symbol + " Won the game");
                restartgame();
            }
            else if (button2.Text == symbol && button5.Text == symbol && button8.Text == symbol)
            {
                MessageBox.Show(symbol + " Won the game");
                restartgame();
            }
            else if (button3.Text == symbol && button6.Text == symbol && button9.Text == symbol)
            {
                MessageBox.Show(symbol + " Won the game");
                restartgame();
            }
            else if (button1.Text == symbol && button5.Text == symbol && button9.Text == symbol)
            {
                MessageBox.Show(symbol + " Won the game");
                restartgame();
            }
            else if (button3.Text == symbol && button5.Text == symbol && button7.Text == symbol)
            {
                MessageBox.Show(symbol + " Won the game");
                restartgame();
            }
        }




        void fnsyombol(object senderobj)
        {
            string buttontxt = ((Button)senderobj).Text;
            if(buttontxt == "")
            {
                if(count%2 == 0)
                {
                    ((Button)senderobj).Text = "O";
                    
                }
                else
                {
                    ((Button)senderobj).Text = "X";

                }
                count++;//sıranın hangi oyuncuda olduğunu arttırır
                checkwinner("O");
                checkwinner("X");

            }
            else
            {
                MessageBox.Show("Invalid Click");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            fnsyombol(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fnsyombol(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fnsyombol(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fnsyombol(sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fnsyombol(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fnsyombol(sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fnsyombol(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fnsyombol(sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fnsyombol(sender);
        }
    }
}
