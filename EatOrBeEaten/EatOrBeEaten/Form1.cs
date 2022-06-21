using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EatOrBeEaten
{
    public partial class Form1 : Form
    {
        public Scene scene { get; set; }
        public bool isPlaying { get; set; }
        public int timeAlive { get; set; }
        public int gameMode { get; set; }
        // gameMode values:
        // 0->easy 1->medium 2->hard

        
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            initializeScene();
        }
        public void initializeScene()
        {
            scene = new Scene(this.Width,this.Height);
            isPlaying = false;
            gameMode = 0;
            timerGenerateNewBalls.Stop();
            timerTimeAlive.Stop();
            timerTimeAlive.Interval = 1000;
            timerMoveBalls.Stop();
            timeAlive = 0;
            updateTimeAlive();
            updateFoodEaten();
        }
        public void updateFoodEaten()
        {
            tsslblFoodEaten.Text = string.Format("Food Eaten: {0}", scene.Hits);
        }
        public int getTimeAliveSeconds()
        {
            return timeAlive % 60;
        }
        public int getTimeAliveMinutes()
        {
            return timeAlive / 60;

        }
        public void updateTimeAlive()
        {
            tsslblTimeAlive.Text = string.Format("Time Alive: {0:00}:{1:00}", getTimeAliveMinutes(), getTimeAliveSeconds());
        }
        public string getStatistics(bool hasWon)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('\n' + "GAME STATISTICS:" + '\n');
            sb.Append("Food Eaten: " + scene.Hits + '\n');
            if (hasWon)
            {
                sb.Append("Time Played: " + getTimeAliveMinutes() + " minute(s) and " + getTimeAliveSeconds() + " second(s)");
            }
            else
            {
                sb.Append("Time Alive: " + getTimeAliveMinutes() + " minute(s) and " + getTimeAliveSeconds() + " second(s)");
            }
            return sb.ToString();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame newGame = new NewGame();
            if(newGame.ShowDialog() == DialogResult.OK)
            {
                initializeScene();
                gameMode = newGame.gameMode;
                isPlaying = true;
                if(gameMode == 0)   // easy
                {
                    timerGenerateNewBalls.Interval = 1500;
                    timerMoveBalls.Interval = 50;
                }
                if(gameMode == 1)   // medium
                {
                    timerGenerateNewBalls.Interval = 1000;
                    timerMoveBalls.Interval = 20;
                }
                if(gameMode == 2)   // hard
                {
                    timerGenerateNewBalls.Interval = 500;
                    timerMoveBalls.Interval = 10;
                }
                timerGenerateNewBalls.Start();
                timerMoveBalls.Start();
                timerTimeAlive.Start();
            }
            Invalidate();
        }

        private void timerGenerateNewBalls_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                scene.AddBall();
            }
            
            Invalidate();
        }

        private void timerMoveBalls_Tick(object sender, EventArgs e)
        {
            scene.Move();
            scene.checkHits();
            checkEndGame();
            Invalidate();
        }
        public void checkEndGame()
        {
            if (scene.hasWon)
            {
                timersStop();
                MessageBox.Show("Congratulations! You won the game!" + '\n' + getStatistics(true), "GAME FINISHED");

                initializeScene();
            }
            if (scene.hasLost)
            {
                timersStop();
                MessageBox.Show("Game over, you lost! You have been eaten!" + '\n' + getStatistics(false), "GAME OVER");

                initializeScene();
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(scene.PlayerBall == null && isPlaying)
            {
                scene.PlayerBall = new PlayerBall(e.Location);
            }
            if (isPlaying)
            {
                scene.PlayerBall.Center = e.Location;
                scene.checkHits();
                checkEndGame();
            }
            updateFoodEaten();
            Invalidate();
        }
        public void timersStop()
        {
            timerGenerateNewBalls.Stop();
            timerTimeAlive.Stop();
            timerMoveBalls.Stop();
        }

        private void btnEndGame_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                isPlaying = false;
                timersStop();
                MessageBox.Show(getStatistics(true), "GAME FINISHED");
                initializeScene();
                Invalidate();
            }
        }

        private void timerTimeAlive_Tick(object sender, EventArgs e)
        {
            timeAlive++;
            updateTimeAlive();
            Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            scene.Resized(this.Width, this.Height);
            Invalidate();
        }
    }
}
