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
    public partial class Playlist : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        int selectedRowIndex;
        public Playlist()
        {
            InitializeComponent();
        }

        private void Playlist_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;port=3307;database=melon;uid=root;pwd=1234";
            conn = new MySqlConnection(connStr);
            dataAdapter = new MySqlDataAdapter("SELECT * FROM playlist", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "playlist");
            dataGridView1.DataSource = dataSet.Tables["playlist"];

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string queryStr;

            string[] conditions = new string[7];
            conditions[0] = (textBoxListID.Text != "") ? "listid=@listid" : null;
            conditions[1] = (textBoxCustID.Text != "") ? "custid=@custid" : null;
            conditions[2] = (textBoxMusicID.Text != "") ? "musicid=@musicid" : null;
            conditions[4] = (textBoxPresent.Text != "") ? "present=@present" : null;
            conditions[5] = (textBoxPrevious.Text != "") ? "previous=@previous" : null;
            conditions[6] = (textBoxNext.Text != "") ? "next=@next" : null;
      
           
            if (conditions[0] != null || conditions[1] != null || conditions[2] != null || conditions[3] != null || conditions[4] != null || conditions[5] != null || conditions[6] != null)
            {
                queryStr = $"SELECT * FROM playlist WHERE ";
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
                queryStr = "SELECT * FROM playlist";
            }
            dataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@listid", textBoxListID.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@custid", textBoxCustID.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@musicid", textBoxMusicID.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@present", textBoxPresent.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@previous", textBoxPrevious.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@next", textBoxNext.Text);

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "playlist") > 0)
                    dataGridView1.DataSource = dataSet.Tables["playlist"];
                else
                    MessageBox.Show("찾는 데이터가 없습니다.");
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

            PlaylistAs Dig = new PlaylistAs(
                selectedRowIndex,
                row.Cells[0].Value.ToString(),
                row.Cells[1].Value.ToString(),
                row.Cells[2].Value.ToString(),
                row.Cells[3].Value.ToString(),
                row.Cells[4].Value.ToString(),
                row.Cells[5].Value.ToString()
                );

            Dig.Owner = this;
            Dig.ShowDialog();
            Dig.Dispose();
        }

        public void InsertRow(string[] rowDatas)
        {
            string queryStr = "INSERT INTO playlist (custid, musicid, present, previous, next) " +
                "VALUES(@custid, @musicid, @present, @previous, @next)";
            dataAdapter.InsertCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.InsertCommand.Parameters.Add("@custid", MySqlDbType.Int32);
            dataAdapter.InsertCommand.Parameters.Add("@musicid", MySqlDbType.Int32);
            dataAdapter.InsertCommand.Parameters.Add("@present", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@previous", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@next", MySqlDbType.VarChar);

            dataAdapter.InsertCommand.Parameters["@custid"].Value = rowDatas[0];
            dataAdapter.InsertCommand.Parameters["@musicid"].Value = rowDatas[1];
            dataAdapter.InsertCommand.Parameters["@present"].Value = rowDatas[2];
            dataAdapter.InsertCommand.Parameters["@previous"].Value = rowDatas[3];
            dataAdapter.InsertCommand.Parameters["@next"].Value = rowDatas[4];

            try
            {
                conn.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "playlist");
                dataGridView1.DataSource = dataSet.Tables["playlist"];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        internal void DeleteRow(string id)
        {
            string sql = "DELETE FROM playlist WHERE listid=@listid";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@listid", id);

            try
            {
                conn.Open();
                dataAdapter.DeleteCommand.ExecuteNonQuery();

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "playlist");
                dataGridView1.DataSource = dataSet.Tables["playlist"];
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
            string sql = "UPDATE playlist SET custid=@custid, musicid=@musicid, present=@present, previous=@previous, next=@next WHERE listid=@listid";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@listid", rowDatas[0]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@custid", rowDatas[1]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@musicid", rowDatas[2]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@present", rowDatas[3]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@previous", rowDatas[4]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@next", rowDatas[5]);


            try
            {
                conn.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "playlist");
                dataGridView1.DataSource = dataSet.Tables["playlist"];
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
            PlaylistAs Dig = new PlaylistAs();
            Dig.Owner = this;
            Dig.ShowDialog();
            Dig.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxListID.Clear();
            textBoxCustID.Clear();
            textBoxMusicID.Clear();
            textBoxPresent.Clear();
            textBoxPrevious.Clear();
            textBoxNext.Clear();
        }
    }
}
