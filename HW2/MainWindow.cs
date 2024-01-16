using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class MainWindow : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private DataTable dt;

        public MainWindow()
        {
            InitializeComponent();

            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<MainWindow>();
            var config = builder.Build();
            var connectionString = config["DefaultConnection"];

            conn = new SqlConnection(connectionString);

            conn.Open();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            using SqlCommand cmd = new("select [name] from sys.tables", conn);
            using SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                tablesBox.Items.Add(reader["name"]);
            }
        }

        private void getAllDatabtn_Click(object sender, EventArgs e)
        {
            if (tablesBox.SelectedItem == null)
            {
                MessageBox.Show("Select table first", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            adapter = new($"select * from {tablesBox.SelectedItem}", conn);

            dt = new();
            adapter.Fill(dt);

            dbDataGridView.DataSource = dt;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            using SqlCommandBuilder builder = new(adapter);

            adapter.Update(dt);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dbDataGridView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Select row first", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // удаление только из памяти, то есть для сохранения в бд требует обновление через адаптер (кликнуть save, как и с другими изменения)
            foreach (DataGridViewRow row in dbDataGridView.SelectedRows)
            {
                dt.Rows[row.Index].Delete();
            }

            // удаление из самой бд
            /* foreach (DataGridViewRow row in dbDataGridView.SelectedRows)
               {
                   adapter.DeleteCommand = new($"delete from {tablesBox.SelectedItem} where Id={row.Cells[0].Value}", conn);
                   adapter.DeleteCommand.ExecuteNonQuery();
               }*/
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }
    }
}
