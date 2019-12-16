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
        private int selectedRowIndex;

        public MembAs()
        {
            InitializeComponent();

        }

        public MembAs(int selectedRowIndex, string v1, string v2, string v3, string v4, string v5, string v6)
        {
            InitializeComponent();
            this.selectedRowIndex = selectedRowIndex;
            this.nickname = v1;
            this.name = v2;
            this.useticket = v3;
            this.grade = v4;
            this.total = v5;
            this.number = v6;
        }

        Memb membform;
        private void MembAs_Load(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                membform = Owner as Memb;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string[] rowDatas =
            {
                txtNickname.Text,
                txtname.Text,
                txtuse.Text,
                txtrank.Text,
                txtTotal.Text,
                txtnumber.Text
            };
            membform.InsertRow(rowDatas);
            this.Close();
        }
    }
    }
    
