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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

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
            conditions[0] = (tbNick.Text != "") ? "nickname=@nickname" : null;
            conditions[1] = (tbName.Text != "") ? "name=@name" : null;
            conditions[2] = (cbTicket.Text != "") ? "useticket=@useticket" : null;
            conditions[3] = (cbGrade.Text != "") ? "grade=@grade" : null;
            conditions[5] = (tbTotal.Text != "") ? "total = @total" : null;
            conditions[4] = (tbPhone.Text != "") ? "number=@number" : null;
            conditions[6] = (cbSigndate.Text != "") ? "signdate=@signdate" : null;


           

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
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nickname", tbNick.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@name", tbName.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@useticket", cbTicket.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@grade", cbGrade.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@number", tbPhone.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@signdate", cbSigndate.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@total", tbTotal.Text);

           try {
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


        private void button3_Click(object sender, EventArgs e)
        {

            //dataGridView에 데이터가 있는지 체크
            if (dataGridView1.RowCount < 2) // 1이면 데이터가 없음
            {
                MessageBox.Show("저장할 데이터가 없습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //라디오 버튼 선택에 따라 다른 처리
            if (radioButton1.Checked)
            {
                saveFileDialog1.Filter = "텍스트 파일(*.txt)|*.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveAsTxt(saveFileDialog1.FileName);
                }
            }
            else if (radioButton2.Checked)
            {
                saveFileDialog1.Filter = "엑셀 파일(*.xlsx)|*.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveAsExcel(saveFileDialog1.FileName);
                }
            }
            else
            {
                MessageBox.Show("저장 형태가 선택되지 않았습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveAsExcel(string filePath)
        {
            // 1. 엑셀 사용에 필요한 객체 준비
            Excel.Application eApp; // 엑셀 프로그램
            Excel.Workbook eWorkbook; // 엑셀 워크북(시트 여러개 포함)
            Excel.Worksheet eWorksheet; // 엑셀 워크시트

            eApp = new Excel.Application();
            eWorkbook = eApp.Workbooks.Add();
            eWorksheet = eWorkbook.Sheets[1]; // 엑셀 워크시트는 Index가 1부터 시작된다.

            // 2. 엑셀에 저장할 데이터를 2차원 스트링 배열로 준비
            int colCount = dataSet.Tables["customer"].Columns.Count;
            int rowCount = dataSet.Tables["customer"].Rows.Count + 1;
            string[,] dataArr = new string[rowCount, colCount];

            // 2-1 Column 이름 저장
            for (int i = 0; i < dataSet.Tables["customer"].Columns.Count; i++)
            {
                dataArr[0, i] = dataSet.Tables["customer"].Columns[i].ColumnName; // 첫 행에 컬럼이름을 저장
            }
            // 2-2 Row 데이터 저장
            for (int i = 0; i < dataSet.Tables["customer"].Rows.Count; i++)
            {
                for (int j = 0; j < dataSet.Tables["customer"].Columns.Count; j++)
                {
                    dataArr[i + 1, j] = dataSet.Tables["customer"].Rows[i].ItemArray[j].ToString();
                }
            }

            // 3. 준비된 스트링 배열을 엑셀파일로 저장
            string endCell = Convert.ToChar(65 + colCount - 1).ToString() + rowCount.ToString();
            eWorksheet.get_Range($"A1:{endCell}").Value = dataArr; // 배열의 데이터를 엑셀시트에 기록

            eWorkbook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, Type.Missing, Type.Missing,
                Type.Missing);
            eWorkbook.Close(false, Type.Missing, Type.Missing);
            eApp.Quit();
        }

        private void SaveAsTxt(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Column 이름들을 저장(한줄)
                foreach (DataColumn col in dataSet.Tables["customer"].Columns)
                {
                    sw.Write($"{col.ColumnName}\t");
                }
                sw.WriteLine();

                // Rows 데이터들을 저장
                foreach (DataRow row in dataSet.Tables["customer"].Rows)
                {
                    string rowString = "";
                    foreach (var data in row.ItemArray)
                    {
                        rowString += $"{data}\t";
                    }
                    sw.WriteLine(rowString);
                }
            }
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            MembAs Dig = new MembAs();
            Dig.Owner = this;
            Dig.ShowDialog();
            Dig.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbNick.Clear();
            tbName.Clear();
            tbTotal.Clear();
            cbTicket.Text = "";
            cbGrade.Text = "";
            tbPhone.Clear();
            cbSigndate.Text = "";
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            string queryStr;
            string[] conditions = new string[7];
            conditions[0] = (tbNick.Text != "") ? "nickname=@nickname" : null;
            conditions[1] = (tbName.Text != "") ? "name=@name" : null;
            conditions[2] = (cbTicket.Text != "") ? "useticket=@useticket" : null;
            conditions[3] = (cbGrade.Text != "") ? "grade=@grade" : null;
            conditions[5] = (tbTotal.Text != "") ? "total = @total" : null;
            conditions[4] = (tbPhone.Text != "") ? "number=@number" : null;
            conditions[6] = (cbSigndate.Text != "") ? "signdate=@signdate" : null;




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
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nickname", tbNick.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@name", tbName.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@useticket", cbTicket.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@grade", cbGrade.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@number", tbPhone.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@signdate", cbSigndate.Text);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@total", tbTotal.Text);

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
    }
}