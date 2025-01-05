using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdGame
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        bool gameOver = false; // Oyunun bitip bitmediğini kontrol edecek bir değişken
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox_bottom_Click(object sender, EventArgs e)
        {

        }

        private void GameTimer(object sender, EventArgs e)
        {
            if (!gameOver) // Eğer oyun bitmediyse
            {
                pictureBox_bird.Top += gravity;
                pictureBox_bottom.Left -= pipeSpeed;
                pictureBox_up.Left -= pipeSpeed;
                label1.Text = "SCORE: " + score;

                if (pictureBox_bottom.Left < -150)
                {
                    pictureBox_bottom.Left = 800;
                    score++;
                }
                if (pictureBox_up.Left < -180)
                {
                    pictureBox_up.Left = 950;
                    score++;
                }
                if (pictureBox_bird.Bounds.IntersectsWith(pictureBox_bottom.Bounds) ||
                    pictureBox_bird.Bounds.IntersectsWith(pictureBox_up.Bounds) ||
                    pictureBox_bird.Bounds.IntersectsWith(pictureBox_ground.Bounds) || pictureBox_bird.Top < -25)
                {
                    EndGame();
                }
            }
        }

        public void EndGame()
        {
            timer_GameController.Stop();
            label1.Text = "GAME OVER!      Bir tuşa bas!";
            gameOver = true; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void game_Down(object sender, KeyEventArgs e)
        {
            if (gameOver) 
            {
                RestartGame();
            }
            else if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void game_Up(object sender, KeyEventArgs e)
        {
            if (!gameOver && e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void RestartGame()
        {
            gameOver = false;
            score = 0;
            gravity = 15;
            pipeSpeed = 8;
            pictureBox_bird.Top = 200;
            pictureBox_bottom.Left = 800;
            pictureBox_up.Left = 950;
            label1.Text = "SCORE: " + score;
            timer_GameController.Start(); 
        }
    }
}
