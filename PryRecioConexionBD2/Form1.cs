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
using static PryRecioConexionBD2.clsConexionBD;

namespace PryRecioConexionBD2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        clsConexionBD conexionBD = new clsConexionBD();

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnCargarContactos_Click(object sender, EventArgs e)
        {
            // Crear y conectar a la base de datos
            clsConexionBD conexion = new clsConexionBD();
            conexion.ConectarBD();

            // Consulta para obtener los contactos
            string query = "SELECT Nombre, Apellido, Telefono, Correo FROM dbo.Contactos";

            // Ejecutar consulta y llenar DataTable
            SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion.ObtenerConexion());
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            // Configurar el DataGridView
            dgvContactos.Columns.Clear(); // Limpiar columnas anteriores
            dgvContactos.AutoGenerateColumns = false; // No generar columnas automáticas

            // Crear columna personalizada para 'Nombre'
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.HeaderText = "Nombre"; // Título visible
            colNombre.DataPropertyName = "Nombre"; // Nombre de campo de la tabla
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContactos.Columns.Add(colNombre);

            // Crear columna personalizada para 'Apellido'
            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.HeaderText = "Apellido"; // Título visible
            colApellido.DataPropertyName = "Apellido"; // Nombre de campo de la tabla
            colApellido.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContactos.Columns.Add(colApellido);

            // Crear columna personalizada para 'Telefono'
            DataGridViewTextBoxColumn colTelefono = new DataGridViewTextBoxColumn();
            colTelefono.HeaderText = "Telefono"; // Título visible
            colTelefono.DataPropertyName = "Telefono"; // Nombre de campo de la tabla
            colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContactos.Columns.Add(colTelefono);

            // Crear columna personalizada para 'Correo'
            DataGridViewTextBoxColumn colCorreo = new DataGridViewTextBoxColumn();
            colCorreo.HeaderText = "Correo"; // Título visible
            colCorreo.DataPropertyName = "Correo"; // Nombre de campo de la tabla
            colCorreo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContactos.Columns.Add(colCorreo);

            // Asignar la tabla al DataGridView
            dgvContactos.DataSource = tabla;
        }
    }
}
