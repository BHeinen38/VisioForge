using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisioForgePlayground2
{
    public partial class Form3 : Form
    {
        public IMediaPlayer player;
        public Form3()
        {
            InitializeComponent();
            MediaPlayer1 mPlayer = new MediaPlayer1();
            mPlayer.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(mPlayer);
            this.player = mPlayer as IMediaPlayer;
        }
        

        private void bSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxSelectFile.Text = openFileDialog1.FileName;
            }
            player.FilenameOrURL = textBoxSelectFile.Text;

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Parent != null && Parent.Parent != null)
                {
                    Parent.Parent.ContextMenuStrip.Show(MousePosition);
                }
            }
        }
    }
}
