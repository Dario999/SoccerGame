using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerGame
{
    public class Player
    {

        public Point Centar { get; set; }
        public Color Color { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool IsColiding { get; set; }

        public const int velocity = 15;

        public Player(Point center, Color c)
        {
            this.width = 20;
            this.height = 100;
            this.Centar = center;
            this.Color = c;
            this.IsColiding = false;
        }

        public void Move(int top, int height, int x, int y)
        {
            if (Centar.Y + y + 25 <= height && Centar.Y + y + 25 >= top )
            {
                Centar = new Point(Centar.X + x, Centar.Y + y);
            }
        }

        public void Draw(Graphics g)
        {
            var brush = new SolidBrush(Color);
            g.FillRectangle(brush, Centar.X, Centar.Y , 20, 100);
            brush.Dispose();
            //g.FillRectangle(brush, Centar.X - 120, Centar.Y - 25, 20, 100);

        }


    }
}
