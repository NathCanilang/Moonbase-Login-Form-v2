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

namespace Activity1V2
{
    public partial class TableForms : Form
    {
        public static TableForms TableFormsInstance;
        private MySqlConnection conn;
        public TableForms()
        {
            InitializeComponent();
            string mysqlcon = "server=localhost;user=root;database=moonbasedatabase;password=";
            conn = new MySqlConnection(mysqlcon);

            string query = "SELECT * FROM mbuserinfo";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            AdminLbl.Parent = pictureBox1;


        }

        private void TableForms_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            refreshTable();

            dataGridView1.Columns["FullName"].Width = 150;
            dataGridView1.Columns["Age"].Width = 30;
            dataGridView1.Columns["Gender"].Width = 50;
            dataGridView1.Columns["Username"].Width = 150;
            dataGridView1.Columns["Email"].Width = 150; // Set your desired width
            dataGridView1.Columns["Status"].Width = 130;

            dataGridView1.Columns["FullName"].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns["Age"].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns["Gender"].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns["Username"].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns["Email"].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns["Status"].Resizable = DataGridViewTriState.False;

        }

        private void SearchTxtBox_TextChanged(object sender, EventArgs e)
        {

            string searchText = SearchTxtBox.Text.Trim();
            DataTable filteredTable = FilterTable(searchText);
            dataGridView1.DataSource = filteredTable;
        }

        private DataTable FilterTable(string searchText)
        {
            string mysqlcon = "server=localhost;user=root;database=moonbasedatabase;password=";
            conn = new MySqlConnection(mysqlcon);

            using (conn = new MySqlConnection(mysqlcon))
            {
                string selectQuery = $"SELECT * FROM mbuserinfo WHERE FullName LIKE '%{searchText}%' OR Username LIKE '%{searchText}%' OR Email LIKE '%{searchText}%' OR Age LIKE '%{searchText}%'  OR Gender LIKE '%{searchText}%' OR Status LIKE '%{searchText}%' ";
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, conn);
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }

                return dataTable;
            }
        }

        private void refreshTable()
        {
            string mysqlcon = "server=localhost;user=root;database=moonbasedatabase;password=";
            conn = new MySqlConnection(mysqlcon);

            using (conn = new MySqlConnection(mysqlcon))
            {
                string selectQuery = "SELECT * FROM mbuserinfo";
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, conn);
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void DeactivateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult choices = MessageBox.Show("Deactivate selected accounts?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (choices == DialogResult.Yes)
                {
                    try
                    {
                        conn.Open();

                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {
                            string accountUsername = selectedRow.Cells["Username"].Value.ToString();
                            string updateQuery = $"UPDATE mbuserinfo SET Status = 'DEACTIVATED' WHERE Username = '{accountUsername}'";
                            MySqlCommand cmdDataBase = new MySqlCommand(updateQuery, conn);
                            cmdDataBase.ExecuteNonQuery();
                            selectedRow.Cells["Status"].Value = "DEACTIVATED";
                        }
                        MessageBox.Show("Selected accounts updated!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                DialogResult choices = MessageBox.Show("No account selected?", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult choices = MessageBox.Show("Delete selected account/s?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (choices == DialogResult.Yes)
                {
                    try
                    {
                        conn.Open();
                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {
                            string accountUsername = selectedRow.Cells["Username"].Value.ToString();
                            string updateQuery = $"DELETE FROM mbuserinfo WHERE Username = '{accountUsername}'";
                            MySqlCommand cmdDataBase = new MySqlCommand(updateQuery, conn);
                            cmdDataBase.ExecuteNonQuery();
                            refreshTable();
                        }
                        MessageBox.Show("Selected accounts deleted!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                DialogResult choices = MessageBox.Show("No account selected?", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void ActivateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult choices = MessageBox.Show("Activate selected accounts?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (choices == DialogResult.Yes)
                {
                    try
                    {
                        conn.Open();

                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {
                            string accountUsername = selectedRow.Cells["Username"].Value.ToString();
                            string updateQuery = $"UPDATE mbuserinfo SET Status = 'ACTIVATED' WHERE Username = '{accountUsername}'";
                            MySqlCommand cmdDataBase = new MySqlCommand(updateQuery, conn);
                            cmdDataBase.ExecuteNonQuery();
                            selectedRow.Cells["Status"].Value = "ACTIVATED";
                        }
                        MessageBox.Show("Selected accounts updated!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                DialogResult choices = MessageBox.Show("No account selected?", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AdminLbl_Click(object sender, EventArgs e)
        {

        }

        
    }
}
