using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private SqlDataReader reader;
        private DataTable table;
        private SqlConnection conn;
        string cs = "";
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            cs = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            conn.ConnectionString = cs;
        }
        private void show_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.CommandText = tbRequest.Text;
                comm.Connection = conn;
                dataGridView1.DataSource = null;
                conn.Open();
                table = new DataTable();
                reader = comm.ExecuteReader();
                int line = 0;
                do
                {
                    while (reader.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i <
                            reader.FieldCount; i++)
                            {
                                table.Columns.Add(reader.
                                GetName(i));
                            }
                            line++;
                        }
                        DataRow row = table.NewRow();
                        for (int i = 0; i <
                        reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        table.Rows.Add(row);
                    }
                } while (reader.NextResult());
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probably wrong request syntax");
            }

            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        private void btAsync_Click(object sender, EventArgs e)
        {
            /// блок 1
            const string AsyncEnabled = "Asynchronous Processing=true";
            if (!cs.Contains(AsyncEnabled))
            {
                cs = String.Format("{0}; {1}", cs, AsyncEnabled);
            }
            ///
            conn = new SqlConnection(cs);
            SqlCommand comm = conn.CreateCommand();
            /// блок 2
            comm.CommandText = "WAITFOR DELAY /00:00:05/; SELECT * FROM Books; ";
            comm.CommandType = CommandType.Text;
            comm.CommandTimeout = 30;
            ///
            try
            {
                conn.Open();
                /// блок 3
                AsyncCallback callback = new AsyncCallback(GetDataCallback);
                comm.BeginExecuteReader(callback, comm);
                MessageBox.Show("Added thread is working...");
                ///
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetDataCallback(IAsyncResult result)
        {
            SqlDataReader reader = null;
            try
            {
                /// блок 1
                SqlCommand command = (SqlCommand)result.AsyncState;
                ///
                /// блок 2
                reader = command.EndExecuteReader(result);
                ///
                table = new DataTable();
                int line = 0;
                do
                {
                    while (reader.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i <
                            reader.FieldCount; i++)
                            {
                                table.Columns.Add(reader.GetName(i));
                            }
                            line++;
                        }
                        DataRow row = table.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        table.Rows.Add(row);
                    }
                } while (reader.NextResult());
                DgvAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("From Callback 1:" + ex.Message);
            }
            finally
            {
                try
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("From Callback 2:" + ex.Message);
                }
            }
        }
        private void DgvAction()
        {
            if (dataGridView2.InvokeRequired)
            {
                dataGridView2.Invoke(new Action(DgvAction));
                return;
            }
            dataGridView2.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
