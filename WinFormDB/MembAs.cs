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
    public partial class MembAs : Form
    {
        private string nickname;
        private string name;
        private string useticket;
        private string grade;
        private string total;
        private string number;
        private string signdate;
        private int selectedRowIndex;
        public MembAs()
        {
            InitializeComponent();
        }

        public MembAs(int selectedRowIndex, string v1, string v2, string v3, string v4, string v5, string v6, string v7)
        {
            InitializeComponent();
            this.selectedRowIndex = selectedRowIndex;
            this.nickname = v1;
            this.name = v2;
            this.useticket = v3;
            this.grade = v4;
            this.total = v5;
            this.number = v6;
            this.signdate = v7;
        }

        Memb mainForm;


        private void MembAs_Load(object sender, EventArgs e)
        {
            txtNickname.Text = nickname;
            txtName.Text = name;
            txtTicket.Text = useticket;
            txtGrade.Text = grade;
            txtTotal.Text = total;
            txtNumber.Text = number;
            dateTimePicker.Text = signdate;
            if (Owner != null)
            {
                mainForm = Owner as Memb;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string[] rowDatas = {
                txtName.Text,
                txtTicket.Text,
                txtGrade.Text,
                txtTotal.Text,
                txtNumber.Text,
                dateTimePicker.Text
        };
            mainForm.InsertRow(rowDatas);
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] rowDatas = {
                txtNickname.Text,
                txtName.Text,
                txtTicket.Text,
                txtGrade.Text,
                txtTotal.Text,
                txtNumber.Text,
                dateTimePicker.Text};
            mainForm.UpdateRow(rowDatas);
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("고객 정보를 삭제 시 고객의 플레이리스트도 같이 삭제됩니다. 그래도 삭제하시겠습니까?", "삭제확인창", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                mainForm.DeleteRow(nickname);
                this.Close();
            }
        }

        private void btnTextBoxClear_Click(object sender, EventArgs e)
        {
            txtNickname.Clear();
            txtName.Clear();
            txtTicket.Text = "";
            txtGrade.Text = "";
            txtTotal.Clear();
            txtNumber.Clear();
            dateTimePicker.Text = "";
        }

    }
}
