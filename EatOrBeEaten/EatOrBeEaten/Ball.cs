using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EatOrBeEaten
{
    public class Ball
    {
        public Point Center { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public int MovingDirection { get; set; }
        // MovingDirection values:
        // 0->up 1->down 2->left 3->right 4->diagonal(up-left) 5->diagonal(up-right) 6->diagonal(down-left) 7->diagonal(down-right)

        public Ball(Point center, int radius, Color color, int windowWidth, int windowHeight, int movingDirection)
        {
            Center = center;
            Radius = radius;
            Color = color;
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
            MovingDirection = movingDirection;
        }

       
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            brush.Dispose();
        }
        public void Move()
        {
            if(MovingDirection == 0)    //up
            {
                Center = new Point(Center.X, Center.Y-1);
            }
            else if(MovingDirection == 1)   // down
            {
                Center = new Point(Center.X, Center.Y + 1);
            }
            else if(MovingDirection == 2)   // left
            {
                Center = new Point(Center.X-1, Center.Y);
            }
            else if(MovingDirection == 3)   // right
            {
                Center = new Point(Center.X+1, Center.Y);
            }
            else if(MovingDirection == 4)   // diagonal (up - left)
            {
                Center = new Point(Center.X-1, Center.Y-1);
            }
            else if(MovingDirection == 5)   // diagonal (up - right)
            {
                Center = new Point(Center.X+1, Center.Y-1);
            }
            else if(MovingDirection == 6)   // diagonal (down - left)
            {
                Center = new Point(Center.X - 1, Center.Y + 1);
            }
            else                            // diagonal (down - right)
            {
                Center = new Point(Center.X + 1, Center.Y + 1);
            }
           
        }
        
        public bool IsOutOfBounds()
        {
            return Center.X-Radius>=WindowWidth || Center.X+Radius<=0 
                || Center.Y-Radius>=WindowHeight || Center.Y+Radius<=0;
        }
        public bool IsHit(PlayerBall ball)
        {
            return Math.Sqrt(Math.Pow(Center.X-ball.Center.X,2) + Math.Pow(Center.Y-ball.Center.Y,2))<=ball.Radius+Radius;
        }

    }
}
