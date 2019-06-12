using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerGame
{
    public class Ball
    {

        public Point Centar { get; set; }
        public Color Color { get; set; }
        public bool IsColiding { get; set; }

        private double velocityX;
        private double velocityY;

        public static readonly int Radius = 15;
        public readonly int Diameter;
        public const int velocity = 8;


        public Ball(Point center, Color c)
        {
            this.Centar = center;
            this.Color = c;
            Diameter = 2 * Radius;
            this.IsColiding = false;
            var random = new Random();
            var angle = 2 * Math.PI * 0.45;
            velocityX = Math.Cos(angle) * velocity;
            velocityY = Math.Sin(angle) * velocity;
          
        }

        public void Move(int left, int top, int width, int height,Player p1,Player p2)
        {
            var nextX = Centar.X + velocityX;
            var nextY = Centar.Y + velocityY;
            int lft = left + Radius;
            int rgt = left + width - Radius;
            int tp = top + Radius;
            int btm = top + height - Radius;

            if (nextX - 10 <= lft)
            {
                nextX = lft + (lft - nextX);
                velocityX *= -1;
            }
            if (nextX >= rgt)
            {
                nextX = rgt - (nextX - rgt);
                velocityX *= -1;
            }
            if (nextY <= tp)
            {
                nextY = tp + (tp - nextY);
                velocityY *= -1;
            }
            if (nextY >= btm)
            {
                nextY = btm - (nextY - btm);
                velocityY *= -1;
            }

            /*if (this.isTouching(p2))
            {
                velocityX *= -1;
                velocityY *= -1;
            }
            if (this.isTouching(p2))
            {
                velocityX *= -1;
                velocityY *= -1;
            }*/

            Centar = new Point((int)nextX, (int)nextY);
           }

        public void Draw(Graphics g)
        {
            var brush = new SolidBrush(Color);
            g.FillEllipse(brush, Centar.X - Radius, Centar.Y - Radius, Diameter, Diameter);
            var pen = new Pen(Color.Gray, 3);
            g.DrawEllipse(pen, Centar.X - Radius, Centar.Y - Radius, Diameter, Diameter);
            brush.Dispose();
        }

        public void isColided(Player player)
        {
            if (this.isTouching(player))
            {
                velocityX *= -1;
            }
        }
        
        public bool isTouching(Player player)
        {

            return (Math.Abs(player.Centar.X - this.Centar.X) <= (player.width / 2) +  Radius) &&
                (Math.Abs(player.Centar.Y + 50 - Centar.Y) <= (player.height / 2) + Radius);
        }

    }
}
