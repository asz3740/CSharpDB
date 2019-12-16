using MySql.Data.MySqlClient;
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

    public partial class Memb : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        int selectedRowIndex;

        public Memb()
        {
            InitializeComponent();
        }

        private void Memb_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;port=3307;database=melon;uid=root;pwd=1234 ;convert Zero Datetime=true";
            conn = new MySqlConnection(connStr);
            dataAdapter = new MySqlDataAdapter("SELECT * FROM customer", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "customer");
            dataGridView1.DataSource = dataSet.Tables["customer"];

            SetSearchComboBox();
        }

        private void SetSearchComboBox()
        {
            string sql = "SELECT distinct useticket FROM customer";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbTicket.Items.Add(reader.GetString("useticket"));
                }
                reader.Close();

                sql = "SELECT distinct grade FROM customer";
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbGrade.Items.Add(reader.GetString("grade"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void cbTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT distinct grade FROM customer WHERE useticket=@useticket";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@useticket", cbTicket.Text);

            cbGrade.Items.Clear();

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbGrade.Items.Add(reader.GetString("grade"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string queryStr;
            string[] conditions = new string[7];
            conditions[0] = (textBoxNickname.Text != "") ? "nickname=@nickname" : null;
            conditions[1] = (textBoxName.Text != "") ? "name=@name" : null;
            conditions[2] = (cbTicket.Text != "") ? "useticket=@useticket" : null;
            conditions[3] = (cbGrade.Text != "") ? "grade=@grade" : null;
            conditions[5] = (textBoxNumber.Text != "") ? "number=@number" : null;
            conditions[6] = (dateTimePicker.Text != "") ? "signdate=@signdate" : null;

            string condition_total;
            if (textBoxMin.Text != "" && textBoxMax.Text != "")
            {
                condition_total = "total>=@min and total<=@max";
            }
            else if (textBoxMin.Text != "" || textBoxMax.Text != "")
            {
                if (textBoxMin.Text != "")
                    condition_total = "total >= @min";
                else
                    condition_total = "total <= @max";
            }
            else
            {
                condition_total = null;
            }
            conditions[4] = condition_total;

            if (conditions[0] != null || conditions[1] != null || conditions[2] != null || conditions[3] != null || conditions[4] != null || conditions[5] != null || conditions[6] != null)
            {
                queryStr = $"SELECT * FROM customer WHERE ";
                bool firstCondition = true;
                for (int i = 0; i < conditions.Length; i++)
                {
                    if (conditions[i] != null)
                        if (firstCondition)
                        {
                            queryStr += conditions[i];
                            firstCondition = false;
                        }
                        else
                        {
                            queryStr += " and " + conditions[i];
                        }
                }
            }
            else
            {
                queryStr = "SELECT * FROM customer";
            }
            //
            dataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nickname", textBoxNickname.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@name", textBoxName.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@useticket", cbTicket.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@grade", cbGrade.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@min", textBoxMin.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@max", textBoxMax.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@number", textBoxNumber.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@signdate", dateTimePicker.Text);

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "customer") > 0)
                    dataGridView1.DataSource = dataSet.Tables["customer"];
                else
                    MessageBox.Show("찾는 회원이 없습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];

            MembAs Dig = new MembAs(
                selectedRowIndex,
                row.Cells[0].Value.ToString(),
                row.Cells[1].Value.ToString(),
                row.Cells[2].Value.ToString(),
                row.Cells[3].Value.ToString(),
                row.Cells[4].Value.ToString(),
                row.Cells[5].Value.ToString(),
                row.Cells[6].Value.ToString()
                );

            Dig.Owner = this;
            Dig.ShowDialog();
            Dig.Dispose();
        }

        public void InsertRow(string[] rowDatas)
        {
            string queryStr = "INSERT INTO customer ( name, useticket, grade, total, number, signdate) " +
                "VALUES(@name, @useticket, @grade, @total, @number, @signdate)";
            dataAdapter.InsertCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.InsertCommand.Parameters.Add("@name", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@useticket", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@grade", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@total", MySqlDbType.Int32);
            dataAdapter.InsertCommand.Parameters.Add("@number", MySqlDbType.Int32);
            dataAdapter.InsertCommand.Parameters.Add("@signdate", MySqlDbType.DateTime);

            #region Parameter를 이용한 처리
            dataAdapter.InsertCommand.Parameters["@name"].Value = rowDatas[0];
            dataAdapter.InsertCommand.Parameters["@useticket"].Value = rowDatas[1];
            dataAdapter.InsertCommand.Parameters["@grade"].Value = rowDatas[2];
            dataAdapter.InsertCommand.Parameters["@total"].Value = rowDatas[3];
            dataAdapter.InsertCommand.Parameters["@number"].Value = rowDatas[4];
            dataAdapter.InsertCommand.Parameters["@signdate"].Value = rowDatas[5];

            try
            {
                conn.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "customer");
                dataGridView1.DataSource = dataSet.Tables["customer"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            #endregion
        }

        internal void DeleteRow(string id)
        {
            string sql = "DELETE FROM customer WHERE nickname=@nickname";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@nickname", id);

            try
            {
                conn.Open();
                dataAdapter.DeleteCommand.ExecuteNonQuery();

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "customer");
                dataGridView1.DataSource = dataSet.Tables["customer"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        internal void UpdateRow(string[] rowDatas)
        {
            string sql = "UPDATE customer SET name=@name, useticket=@useticket, grade=@grade, total=@total, number=@number, signdate=@signdate WHERE nickname=@nickname";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@nickname", rowDatas[0]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@name", rowDatas[1]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@useticket", rowDatas[2]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@grade", rowDatas[3]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@total", rowDatas[4]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@number", rowDatas[5]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@signdate", rowDatas[6]);

            try
            {
                conn.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();

                dataSet.Clear();  // 이전 데이터 지우기
                dataAdapter.Fill(dataSet, "customer");
                dataGridView1.DataSource = dataSet.Tables["customer"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            MembAs Dig = new MembAs();
            Dig.Owner = this;
            Dig.ShowDialog();
            Dig.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxNickname.Clear();
            textBoxName.Clear();
            cbTicket.Text = "";
            cbGrade.Text = "";
            textBoxMin.Clear();
            textBoxMax.Clear();
            textBoxNumber.Clear();
            dateTimePicker.Text = "";
        }

    }
}
