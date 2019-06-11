using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerGame
{
    public class Block
    {

        public Point Centar { get; set; }

        public static readonly int Radius = 10;
        public readonly int Diameter;
        public const int velocity = 10;


        public Block(Point center)
        {
            this.Centar = center;
            Diameter = 2 * Radius;
        }

        public void Draw(Graphics g)
        {
            var brush = new SolidBrush(Color.Bisque);
            g.FillEllipse(brush, Centar.X - Radius, Centar.Y - Radius, Diameter, Diameter);
            var pen = new Pen(Color.Black, 3);
            g.DrawEllipse(pen, Centar.X - Radius, Centar.Y - Radius, Diameter, Diameter);
            brush.Dispose();
        }

        public bool isColided(Player ball)
        {
            var distance = Math.Sqrt(Math.Pow(Centar.X - ball.Centar.X, 2) + Math.Pow(Centar.Y - ball.Centar.Y, 2)) - 10;
            return distance < Diameter;
        }

    }
}
