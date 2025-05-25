# WinForms CRUD con MySQL

![image](https://github.com/user-attachments/assets/e9905b02-16b7-434c-9271-309b4ce83bcb)

![image](https://github.com/user-attachments/assets/855e0b43-ba16-4df3-b52e-74668aba7a25)

- **Proyecto**: WinForms CRUD con MySQL  
- **IDE**: Visual Studio 2022  
- **Paquetes NuGet necesarios**:
  - `MySql.Data`

## Pasos para implementar

1. Crea un nuevo proyecto **Windows Forms App** (.NET Framework o .NET 6+) en Visual Studio 2022.
2. En el Diseñador, arrastra al formulario principal (`MainForm`):
   - Un `DataGridView` llamado `dgvRecords`
   - Cuatro botones: `btnCreate`, `btnRead`, `btnUpdate`, `btnDelete`
   - `Labels` y `TextBoxes`: `txtId`, `txtName`, `txtValue` para editar registros
3. Agrega la referencia a `MySql.Data`:  
   `Tools > NuGet Package Manager > Manage NuGet Packages`
4. Reemplaza el contenido de `Program.cs` y `MainForm.cs` como sigue:

---

## Program.cs

```csharp
using System;
using System.Windows.Forms;

namespace WinFormsCrudMySql
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
```

---

## MainForm.cs

```csharp
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsCrudMySql
{
    public partial class MainForm : Form
    {
        // Ajusta tu cadena de conexión según tus credenciales
        private const string ConnectionString =
            "Server=localhost;Database=tu_base;Uid=tu_usuario;Pwd=tu_contraseña;";

        public MainForm()
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
            dgvRecords.DataSource = table;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using var conn = new MySqlConnection(ConnectionString);
            conn.Open();
            var cmd = new MySqlCommand(
                "INSERT INTO registros (Name, Value) VALUES (@name, @value)", conn);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@value", txtValue.Text);
            cmd.ExecuteNonQuery();
            LoadData();
            ClearFields();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                using var conn = new MySqlConnection(ConnectionString);
                conn.Open();
                var cmd = new MySqlCommand(
                    "UPDATE registros SET Name=@name, Value=@value WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@value", txtValue.Text);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                LoadData();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                using var conn = new MySqlConnection(ConnectionString);
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM registros WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                LoadData();
                ClearFields();
            }
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecords.CurrentRow != null)
            {
                txtId.Text = dgvRecords.CurrentRow.Cells["Id"].Value.ToString();
                txtName.Text = dgvRecords.CurrentRow.Cells["Name"].Value.ToString();
                txtValue.Text = dgvRecords.CurrentRow.Cells["Value"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtValue.Clear();
        }
    }
}
```

---

## Script SQL para la base de datos

```sql

   CREATE DATABASE IF NOT EXISTS tu_base;
   USE tu_base;

   CREATE TABLE IF NOT EXISTS registros (
     Id INT AUTO_INCREMENT PRIMARY KEY,
     Name VARCHAR(100) NOT NULL,
     Value VARCHAR(100) NOT NULL
   );

   INSERT INTO registros (Name, Value) VALUES ('Producto A', '100');
   INSERT INTO registros (Name, Value) VALUES ('Producto B', '250');
   INSERT INTO registros (Name, Value) VALUES ('Producto C', '75');
   INSERT INTO registros (Name, Value) VALUES ('Producto D', '300');
   INSERT INTO registros (Name, Value) VALUES ('Servicio X', '1200');
   INSERT INTO registros (Name, Value) VALUES ('Servicio Y', '800');
   INSERT INTO registros (Name, Value) VALUES ('Accesorio Z', '45');
   INSERT INTO registros (Name, Value) VALUES ('Insumo K', '60');

```

---

## Uso

1. Ejecuta la aplicación.
2. Llena los campos `Name` y `Value`.
3. Usa los botones `Crear`, `Leer`, `Actualizar`, `Eliminar` para gestionar los datos en la tabla `registros` de MySQL.

