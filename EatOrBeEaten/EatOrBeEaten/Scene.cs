using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EatOrBeEaten
{
    public class Scene
    {
        public List<Ball> Balls { get; set; }
        public PlayerBall PlayerBall { get; set; }
        public Random Random { get; set; }  
        public int Width { get; set; }
        public int Height { get; set; }
        public bool hasWon { get; set; }
        public bool hasLost { get; set; }
        public static Color[] colors = { Color.Magenta, Color.Lime, Color.Cyan, Color.Yellow, Color.Aquamarine };
        public static int PLAYER_BALL_START_RADIUS = 20;
        public int Hits { get; set; }

        public Scene(int width, int height)
        {
            Width = width;
            Height = height;
            Random = new Random();
            Balls = new List<Ball>();
            PlayerBall = null;
            Hits = 0;
            hasWon = false;
            hasLost = false;
        }
        public void Resized(int width, int height)
        {
            Width = width;
            Height = height;
            foreach (Ball ball in Balls)
            {
                ball.WindowWidth = Width;
                ball.WindowHeight = Height;
            }
        }
        
        public void AddBall()
        {
            int direction = Random.Next(8);
            int colorIndex = Random.Next(colors.Length);
            Color color = colors[colorIndex];
            int radius = Random.Next(PlayerBall.PLAYER_BALL_START_RADIUS - 10, PlayerBall.Radius + 10);
            int x = Random.Next(radius + 10, Width - radius - 10);
            int y = Random.Next(radius + 10, Height - radius - 10);
            Point center = new Point(x, y);
            Balls.Add(new Ball(center, radius, color, Width, Height, direction));

        }
        public void Draw(Graphics g)
        {
            if (PlayerBall != null)
            {
                PlayerBall.Draw(g);
            }
            foreach (Ball ball in Balls)
            {
                ball.Draw(g);
            }
        }
        public void checkHits()
        {
            if(PlayerBall != null)
            {
                foreach (Ball ball in Balls.ToList())
                {
                    if (ball.IsHit(PlayerBall) && ball.Radius <= PlayerBall.Radius)
                    {
                        Balls.Remove(ball);
                        Hits++;
                        PlayerBall.Radius = (int)(PlayerBall.Radius + ball.Radius * 0.1);
                        if(PlayerBall.Radius > 150)
                        {
                            hasWon = true;
                        }
                    }
                    if(ball.IsHit(PlayerBall) && ball.Radius > PlayerBall.Radius)
                    {
                        hasLost = true;
                        PlayerBall = null;
                        break;
                    }
                }
            }
            
        }
        public void Move()
        {
            foreach(Ball ball in Balls.ToList())
            {
                ball.Move();
                if (ball.IsOutOfBounds())
                {
                    Balls.Remove(ball);
                }
            }
        }

    }
}
