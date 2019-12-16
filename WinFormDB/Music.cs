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
    public partial class Music : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        int selectedRowIndex;
        public Music()
        {
            InitializeComponent();
        }

        private void Music_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;port=3307;database=melon;uid=root;pwd=1234";
            conn = new MySqlConnection(connStr);
            dataAdapter = new MySqlDataAdapter("SELECT * FROM music", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "music");
            dataGridView1.DataSource = dataSet.Tables["music"];

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string queryStr;

            string[] conditions = new string[7];
            conditions[0] = (textBoxID.Text != "") ? "id=@id" : null;
            conditions[1] = (textBoxName.Text != "") ? "name=@name" : null;
            conditions[2] = (textBoxArtist.Text != "") ? "artist=@artist" : null;
            conditions[3] = (textBoxGood.Text != "") ? "good=@good" : null;
            conditions[4] = (textBoxPlaycount.Text != "") ? "playcount=@playcount" : null;

            if (conditions[0] != null || conditions[1] != null || conditions[2] != null || conditions[3] != null || conditions[4] != null)
            {
                queryStr = $"SELECT * FROM music WHERE ";
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
                queryStr = "SELECT * FROM music";
            }
            dataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@id", textBoxID.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@name", textBoxName.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@artist", textBoxArtist.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@good", textBoxGood.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@playcount", textBoxPlaycount.Text);

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "music") > 0)
                    dataGridView1.DataSource = dataSet.Tables["music"];
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

            MusicAs Dig = new MusicAs(
                selectedRowIndex,
                row.Cells[0].Value.ToString(),
                row.Cells[1].Value.ToString(),
                row.Cells[2].Value.ToString(),
                row.Cells[3].Value.ToString(),
                row.Cells[4].Value.ToString()
                );

            Dig.Owner = this;
            Dig.ShowDialog();
            Dig.Dispose();
        }
        public void InsertRow(string[] rowDatas)
        {
            string queryStr = "INSERT INTO music (name, artist, good, playcount) " +
                "VALUES(@name, @artist, @good, @playcount)";
            dataAdapter.InsertCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.InsertCommand.Parameters.Add("@name", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@artist", MySqlDbType.VarChar);
            dataAdapter.InsertCommand.Parameters.Add("@good", MySqlDbType.Int32);
            dataAdapter.InsertCommand.Parameters.Add("@playcount", MySqlDbType.Int32);

            dataAdapter.InsertCommand.Parameters["@name"].Value = rowDatas[0];
            dataAdapter.InsertCommand.Parameters["@artist"].Value = rowDatas[1];
            dataAdapter.InsertCommand.Parameters["@good"].Value = rowDatas[2];
            dataAdapter.InsertCommand.Parameters["@playcount"].Value = rowDatas[3];
      
            try
            {
                conn.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "music");
                dataGridView1.DataSource = dataSet.Tables["music"];
            }
            catch (Exception)
            {
                MessageBox.Show("해당 뮤직이 존재하지 않습니다.");
            }
            finally
            {
                conn.Close();
            }
        }

        internal void DeleteRow(string id)
        {
            string sql = "DELETE FROM music WHERE id=@id";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@id", id);

            try
            {
                conn.Open();
                dataAdapter.DeleteCommand.ExecuteNonQuery();

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "music");
                dataGridView1.DataSource = dataSet.Tables["music"];
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
            string sql = "UPDATE music SET name=@name, artist=@artist, good=@good, playcount=@playcount  WHERE id=@id";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@id", rowDatas[0]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@name", rowDatas[1]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@artist", rowDatas[2]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@good", rowDatas[3]);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@playcount", rowDatas[4]);

            try
            {
                conn.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "music");
                dataGridView1.DataSource = dataSet.Tables["music"];
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
            MusicAs Dig = new MusicAs();
            Dig.Owner = this;
            Dig.ShowDialog();
            Dig.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxID.Clear();
            textBoxName.Clear();
            textBoxArtist.Clear();
            textBoxGood.Clear();
            textBoxPlaycount.Clear();
        }
    }


}
