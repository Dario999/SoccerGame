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

        public int Counter { get; set; }
        public bool flag { get; set; }



        public PlayForm()
        {
            backgroundImage = Resources.playBackground1;
            DoubleBuffered = true;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Ball.Centar.Y  > Block11.Centar.Y && Ball.Centar.Y  < Block12.Centar.Y && Ball.Centar.X > 0 && Ball.Centar.X < 70)
            {
                    int score = int.Parse(ply2lbl.Text);
                    int newScore = score + 1;
                    ply2lbl.Text = newScore.ToString();
                    flag = true;
                    Counter = 1;
                    timer1.Stop();
                    Ball = new Ball(new Point(480, 320), Color.White);
            }
            if (Ball.Centar.Y > Block21.Centar.Y && Ball.Centar.Y < Block22.Centar.Y && Ball.Centar.X > 900 && Ball.Centar.X < 920)
            {
                int score = int.Parse(ply1lbl.Text);
                int newScore = score + 1;
                ply1lbl.Text = newScore.ToString();
                flag = true;
                Counter = 1;
                timer1.Stop();
                Ball = new Ball(new Point(480, 320), Color.White);
            }
            Ball.isColided(Player1);
            Ball.isColided(Player2);
        
            Ball.Move(Left, Top, width, height, Player1, Player2);
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
            Player1 = new Player(new Point(180, 275), Color.Blue);
            Player2 = new Player(new Point(760, 275), Color.Red);
            Block11 = new Block(new Point(44, 246));
            Block12 = new Block(new Point(44, 398));
            Block21 = new Block(new Point(918, 246));
            Block22 = new Block(new Point(918, 398));
            this.Counter = 0;
            this.flag = false;
            Invalidate();
        }

        private void PlayForm_Paint(object sender, PaintEventArgs e)
        {
            var brush = new SolidBrush(Color.Blue);
            e.Graphics.DrawImage(backgroundImage, new Point(0, 20));
            Ball.Draw(e.Graphics);
            var brush1 = new SolidBrush(Color.White);
            //e.Graphics.FillRectangle(brush1, 24, 246, 20, 152);
            //e.Graphics.FillRectangle(brush1, 918, 246, 20, 152);
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
                y = -35;
            }
            if (e.KeyCode == Keys.Down)
            {
                y = 35;
            }

            int y2 = 0;

            if (e.KeyCode == Keys.NumPad8)
            {
                y2 = -35;
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                y2 = 35;
            }



            Player2.Move(Top, height, 0, y2);
            Player1.Move(Top, height, 0, y);
            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int sek = int.Parse(lblTime.Text);
            if(sek == 0)
            {
                int ply1 = int.Parse(ply1lbl.Text);
                int ply2 = int.Parse(ply2lbl.Text);
                if(ply1 > ply2)
                {
                    whoWinslbl.Text = "Player1 Wins";
                    timer1.Stop();
                    timer2.Stop();
                }else if(ply2 > ply1)
                {
                    whoWinslbl.Text = "Player2 Wins";
                    timer1.Stop();
                    timer2.Stop();
                }
                else
                {
                    whoWinslbl.Text = "Draw";
                    timer1.Stop();
                    timer2.Stop();
                }
            }
            else
            {
                int newSek = sek - 1;
                lblTime.Text = newSek.ToString();
            }
            Counter++;
            if (flag && Counter % 2 == 0)
            {
                timer1.Start();
                flag = false;
            }

            Invalidate();
        }


    }
}
