using Evaluacion1.Controladores;
using Evaluacion1.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace EjemploCrud
{
    public partial class Form1 : Form
    {
        private DataTable tabla;
        private UsuariosControladores UsuariosController = new UsuariosControladores();
        int filaSeleccionada;
        string accion = "guardar";

        public Form1()
        {
            InitializeComponent();
            try
            {
                MostrarListaUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarTablaUsuarios()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Rut");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("EsEmpresa");
            tabla.Columns.Add("Telefono");
            tabla.Columns.Add("Direccion");
            tabla.Columns.Add("FechaRegistro");
            tabla.Columns.Add("CantidadFacturas");
            tabla.Columns.Add("NumeroUltimaFactura");
            tabla.Columns.Add("MontoUltimaFactura");
            dgUsuarios.DataSource = tabla;
        }

        private void MostrarListaUsuarios()
        {
            tabla.Clear();
            List<Usuario> usuarios = UsuariosController.ObtenerListaUsuarios();

            if (usuarios != null)
            {
                foreach (var usuario in usuarios)
                {
                    DataRow row = tabla.NewRow();
                    row["Rut"] = usuario.Rut;
                    row["Nombre"] = usuario.Nombre;
                    row["EsEmpresa"] = usuario.EsEmpresa;
                    row["Telefono"] = usuario.Telefono;
                    row["Direccion"] = usuario.Direccion;
                    row["FechaRegistro"] = usuario.FechaRegistro;
                    row["CantidadFacturas"] = usuario.CantidadFacturas;
                    row["NumeroUltimaFactura"] = usuario.NumeroUltimaFactura;
                    row["MontoUltimaFactura"] = usuario.MontoUltimaFactura;
                    tabla.Rows.Add(row);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos y creación del objeto usuario
                Usuario usuario = new Usuario
                {
                    Rut = textRut.Text,
                    Nombre = textNombre.Text,
                    Telefono = textTelefono.Text,
                    Direccion = textDileccion.Text,
                    FechaRegistro = DateTime.Now,
                    CantidadFacturas = Convert.ToInt32(textCFactura.Text),
                    NumeroUltimaFactura = Convert.ToInt32(textNUFactura.Text),
                    MontoUltimaFactura = Convert.ToInt32(textMUFactura.Text)
                };

                if (accion == "guardar")
                {
                    UsuariosController.GuardarUsuario(usuario);
                }
                else if (accion == "editar")
                {
                    UsuariosController.ActualizarUsuario(filaSeleccionada, usuario);
                    accion = "guardar";
                }

                MostrarListaUsuarios();
                LimpiarFormularioUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormularioUsuarios()
        {
            textRut.Text = "";
            textNombre.Text = "";
            textTelefono.Text = "";
            textDileccion.Text = "";
            textCFactura.Text = "";
            textNUFactura.Text = "";
            textMUFactura.Text = "";
        }

        private void dgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            filaSeleccionada = e.RowIndex;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            UsuariosController.EliminarUsuario(filaSeleccionada);
            MostrarListaUsuarios();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0 && filaSeleccionada < tabla.Rows.Count)
            {
                DataRow fila = tabla.Rows[filaSeleccionada];
                textRut.Text = fila["Rut"].ToString();
                textNombre.Text = fila["Nombre"].ToString();
                textTelefono.Text = fila["Telefono"].ToString();
                textDileccion.Text = fila["Direccion"].ToString();
                textCFactura.Text = fila["CantidadFacturas"].ToString();
                textTelefono.Text = fila["NumeroUltimaFactura"].ToString();
                textNUFactura.Text = fila["MontoUltimaFactura"].ToString();
                accion = "editar";
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormularioUsuarios();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            accion = "guardar";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Puedes agregar inicializaciones adicionales aquí si es necesario
        }
    }
}
