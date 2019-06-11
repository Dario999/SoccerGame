using SoccerGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerGame
{
    public partial class PlayForm : Form
    {

        private Image backgroundImage;
        public int Top { get; set; }
        public int Left { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public Block Block11 { get; set; }
        public Block Block12 { get; set; }
        public Block Block21 { get; set; }
        public Block Block22 { get; set; }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Ball Ball { get; set; }



        public PlayForm()
        {
            backgroundImage = Resources.playBackground;
            DoubleBuffered = true;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ball.Move(Left, Top, width, height,Player1,Player2);
            Invalidate();
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {
            this.Width += 160;
            this.Height += 170;
            this.Top = 55;
            this.Left = 50;
            this.width = this.Width - 100;
            this.height = this.Height - 95;
            Ball = new Ball(new Point(480, 320), Color.White);
            Player1 = new Player(new Point(300, 300), Color.Blue);
            Player2 = new Player(new Point(880, 300), Color.Red);
            Block11 = new Block(new Point(44, 246));
            Block12 = new Block(new Point(44, 398));
            Block21 = new Block(new Point(918, 246));
            Block22 = new Block(new Point(918, 398));
            Invalidate();
        }

        private void PlayForm_Paint(object sender, PaintEventArgs e)
        {
            var brush = new SolidBrush(Color.Blue);
            e.Graphics.DrawImage(backgroundImage, new Point(0, 20));
            Ball.Draw(e.Graphics);
            Player1.Draw(e.Graphics);
            Player2.Draw(e.Graphics);
            Block11.Draw(e.Graphics);
            Block12.Draw(e.Graphics);
            Block21.Draw(e.Graphics);
            Block22.Draw(e.Graphics);
        }

        private void PlayForm_KeyDown(object sender, KeyEventArgs e)
        {
            int y = 0;

            if(e.KeyCode == Keys.Up)
            {
                y = -10;
            }
            if (e.KeyCode == Keys.Down)
            {
                y = 10;
            }

            int y2 = 0;

            if (e.KeyCode == Keys.NumPad8)
            {
                y2 = -10;
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                y2 = 10;
            }



            Player2.Move(Top, height, 0, y2);
            Player1.Move(Top, height, 0, y);
            Invalidate();
        }
    }
}
