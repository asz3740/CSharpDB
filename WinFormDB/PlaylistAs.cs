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
    public partial class PlaylistAs : Form
    {
        private string listid;
        private string custid;
        private string musicid;
        private string present;
        private string previous;
        private string next;
        private int selectedRowIndex;

        public PlaylistAs()
        {
            InitializeComponent();
        }

        public PlaylistAs(int selectedRowIndex, string v1, string v2, string v3, string v4, string v5, string v6)
        {
            InitializeComponent();
            this.selectedRowIndex = selectedRowIndex;
            this.listid = v1;
            this.custid = v2;
            this.musicid = v3;
            this.present = v4;
            this.previous = v5;
            this.next = v6;
        }

        Playlist mainForm;

        private void PlaylistAs_Load(object sender, EventArgs e)
        {
            txtListid.Text = listid;
            txtCustid.Text = custid;
            txtMusicid.Text = musicid;
            txtPresent.Text = present;
            txtPrevious.Text = previous;
            txtNext.Text = next;

            if (Owner != null)
            {
                mainForm = Owner as Playlist;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string[] rowDatas = {
                txtCustid.Text,
                txtMusicid.Text,
                txtPresent.Text,
                txtPrevious.Text,
                txtNext.Text,
            };
            mainForm.InsertRow(rowDatas);
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] rowDatas = {
                txtListid.Text,
                txtCustid.Text,
                txtMusicid.Text,
                txtPresent.Text,
                txtPrevious.Text,
                txtNext.Text,
                };
            mainForm.UpdateRow(rowDatas);
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("정말삭제하시겠습니까?", "삭제확인창", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                mainForm.DeleteRow(listid);
                this.Close();
            }
        }

        private void btnTextBoxClear_Click(object sender, EventArgs e)
        {
            txtListid.Clear();
            txtCustid.Clear();
            txtMusicid.Clear();
            txtPresent.Clear();
            txtPrevious.Clear();
            txtNext.Clear();
        }
    }
}
