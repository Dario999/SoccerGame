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
    public partial class Main : Form
    {

        public Image background { get; set; }

        public Main()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            background = Resources.MainBackground1;
        }


        private void btnHow_Click(object sender, EventArgs e)
        {
            HowToPlay htpDialog = new HowToPlay();
            if (htpDialog.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
                htpDialog.ShowDialog();
                this.Show();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Quit?", "Exit", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(background, new Point(0, 0));
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayForm htpDialog = new PlayForm();
            if (htpDialog.ShowDialog() == DialogResult.OK)
            {
                this.Close();
                htpDialog.ShowDialog();
                this.Show();
            }
        }

      
    }
}
