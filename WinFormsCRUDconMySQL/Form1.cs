using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsCRUDconMySQL
{
    public partial class Form1 : Form
    {
        private const string ConnectionString = "Server=localhost;Database=crud_escritorio;Uid=giovanny;Pwd=tapiero;";
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using var conn = new MySqlConnection(ConnectionString);
            var adapter = new MySqlDataAdapter("SELECT * FROM registros", conn);
            var table = new DataTable();
            adapter.Fill(table);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

