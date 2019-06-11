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
    public partial class HowToPlay : Form
    {
        public Image background { get; set; }

        public HowToPlay()
        {
            InitializeComponent();
            background = Resources.HowToPlay;
            this.Height = background.Height + 40;
            this.Width = background.Width + 15;
        }

        private void HowToPlay_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(background, new Point(0, 0));

        }

    }
}

