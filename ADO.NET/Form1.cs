using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\\New folder\\Konten\\ADO.NET\\database.mdb";
            OleDbConnection conn = new OleDbConnection(connection);
            string query = "select * from tbl_barang";
            OleDbCommand command = new OleDbCommand(query, conn);
            var tblBarang = new DataTable("tbl_barang");
            var adapter = new OleDbDataAdapter(command);

            adapter.Fill(tblBarang);
            dataGridView1.DataSource = tblBarang;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\\New folder\\Konten\\ADO.NET\\database.mdb";
            OleDbConnection conn = new OleDbConnection(connection);
            string query = "select * from tbl_barang";
            OleDbCommand command = new OleDbCommand(query, conn);
            var tblBarang = new DataTable("tbl_barang");

            conn.Open();
            OleDbDataReader dataReader = command.ExecuteReader();
            tblBarang.Load(dataReader);
            dataGridView1.DataSource = tblBarang;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\\New folder\\Konten\\ADO.NET\\database.mdb";
            OleDbConnection conn = new OleDbConnection(connection);
            string query = "select * from tbl_barang";
            OleDbCommand command = new OleDbCommand(query, conn);
            var adapter = new OleDbDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "tblBarang");

            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "tblBarang";
        }
    }
}
