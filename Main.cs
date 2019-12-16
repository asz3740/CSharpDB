using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTmemb_Click(object sender, EventArgs e)
        {
            Memb frm1 = new Memb();

            frm1.Show();
        }

        private void BTmusic_Click(object sender, EventArgs e)
        {
            Music frm2 = new Music();

            frm2.Show();
        }

        private void BTplaylist_Click(object sender, EventArgs e)
        {
            Playlist frm3 = new Playlist();

            frm3.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pictureBox1.Load(@"C:\WinFormDB\melon.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
