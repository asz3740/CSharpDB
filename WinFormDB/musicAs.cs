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
    public partial class MusicAs : Form
    {
        private string id;
        private string name;
        private string artist;
        private string good;
        private string playcount;
        private int selectedRowIndex;
        public MusicAs()
        {
            InitializeComponent();
        }

        public MusicAs(int selectedRowIndex, string v1, string v2, string v3, string v4, string v5)
        {
            InitializeComponent();
            this.selectedRowIndex = selectedRowIndex;
            this.id = v1;
            this.name = v2;
            this.artist = v3;
            this.good = v4;
            this.playcount = v5;
        }

        Music mainForm;

        private void MusicAs_Load(object sender, EventArgs e)
        {
            txtId.Text = id;
            txtName.Text = name;
            txtArtist.Text = artist;
            txtGood.Text = good;
            txtPlaycount.Text = playcount;

            if (Owner != null)
            {
                mainForm = Owner as Music;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string[] rowDatas = {
                txtName.Text,
                txtArtist.Text,
                txtGood.Text,
                txtPlaycount.Text
            };
            mainForm.InsertRow(rowDatas);
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] rowDatas = {
                txtId.Text,
                txtName.Text,
                txtArtist.Text,
                txtGood.Text,
                txtPlaycount.Text,
            };
            mainForm.UpdateRow(rowDatas);
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("정말삭제하시겠습니까?", "삭제확인창", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                mainForm.DeleteRow(id);
                this.Close();
            }
        }

        private void btnTextBoxClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtArtist.Clear();
            txtGood.Clear();
            txtPlaycount.Clear();
        }
    }
}
