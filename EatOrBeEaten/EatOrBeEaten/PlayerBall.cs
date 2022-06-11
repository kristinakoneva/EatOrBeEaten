using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EatOrBeEaten
{
    public class PlayerBall
    {
        public Point Center { get; set; }
        public int Radius { get; set; }
        public static Color COLOR = Color.White;
        public static int PLAYER_BALL_START_RADIUS = 20;

        public PlayerBall(Point center)
        {
            Center = center;
            Radius = PLAYER_BALL_START_RADIUS;
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(COLOR);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            brush.Dispose();
        }
    }
}

