﻿using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class VisualizarUsuarios : Form
    {
        public VisualizarUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            // Configurar el DataGridView y establecer AutoGenerateColumns a false
            ConfigurarDataGridView();
            dataGridUsuarios.AutoGenerateColumns = false;

            // Obtener los usuarios desde la base de datos
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            List<Usuario> usuarios = usuarioDAL.ObtenerUsuarios();

            if (usuarios != null && usuarios.Count > 0)
            {
                // Transformar los datos en un modelo plano
                var usuariosPlanos = usuarios.Select(u => new
                {
                    IdUsuario = u.IdUsuario,
                    CuilEmpleado = u.CuilEmpleado,
                    PasswordUsuario = u.PassswordUsuario,
                    DNI = u.Empleado?.DNI,
                    Nombre = u.Empleado?.Nombre,
                    Apellido = u.Empleado?.Apellido,
                    Email = u.Empleado?.Email
                }).ToList();

                dataGridUsuarios.DataSource = usuariosPlanos;
            }
            else
            {
                MessageBox.Show("No se encontraron usuarios.");
            }
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar cualquier configuración previa
            dataGridUsuarios.Columns.Clear();

            dataGridUsuarios.Columns.Add("IdUsuario", "ID");
            dataGridUsuarios.Columns["IdUsuario"].DataPropertyName = "IdUsuario";

            dataGridUsuarios.Columns.Add("CuilEmpleado", "CUIL");
            dataGridUsuarios.Columns["CuilEmpleado"].DataPropertyName = "CuilEmpleado";

            dataGridUsuarios.Columns.Add("password_Usuario", "Contraseña");
            dataGridUsuarios.Columns["password_Usuario"].DataPropertyName = "PassswordUsuario";

            dataGridUsuarios.Columns.Add("DNI", "DNI");
            dataGridUsuarios.Columns["DNI"].DataPropertyName = "DNI";

            dataGridUsuarios.Columns.Add("Nombre", "Nombre");
            dataGridUsuarios.Columns["Nombre"].DataPropertyName = "Nombre";

            dataGridUsuarios.Columns.Add("Apellido", "Apellido");
            dataGridUsuarios.Columns["Apellido"].DataPropertyName = "Apellido";

            dataGridUsuarios.Columns.Add("Email", "Email");
            dataGridUsuarios.Columns["Email"].DataPropertyName = "Email";
            dataGridUsuarios.Columns["Email"].MinimumWidth = 200;

            dataGridUsuarios.AutoGenerateColumns = false;
            dataGridUsuarios.CellFormatting += dataGridUsuarios_CellFormatting;
        }

        private void BBuscarUsuario_Click(object sender, EventArgs e)
        {

            string textoBusqueda = TBBuscarUsuario.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                FiltrarUsuarios(textoBusqueda);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un texto para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void FiltrarUsuarios(string texto)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();

            // Filtrar usuarios con el texto de búsqueda
            List<Usuario> usuariosFiltrados = usuarioDAL.FiltrarUsuarios(texto);

            if (usuariosFiltrados != null && usuariosFiltrados.Count > 0)
            {
                // Transformar los datos en un modelo plano
                var usuariosPlanos = usuariosFiltrados.Select(u => new
                {
                    IdUsuario = u.IdUsuario,
                    CuilEmpleado = u.CuilEmpleado,
                    PasswordUsuario = u.PassswordUsuario,
                    DNI = u.Empleado?.DNI,
                    Nombre = u.Empleado?.Nombre,
                    Apellido = u.Empleado?.Apellido,
                    Email = u.Empleado?.Email
                }).ToList();

                // Asignar los datos transformados al DataGridView
                dataGridUsuarios.DataSource = usuariosPlanos;
            }
            else
            {
                // Si no hay resultados, mostrar mensaje y recargar todos los usuarios
                MessageBox.Show("No se encontraron usuarios con el criterio de búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar todos los usuarios
                CargarUsuarios();
            }
        }

        private void BRefrescarUsuarios_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void BEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridUsuarios.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridUsuarios.SelectedRows[0];

                // Obtener valores de la fila seleccionada
                int idUsuario = Convert.ToInt32(filaSeleccionada.Cells["IdUsuario"].Value);
                string cuilEmpleado = filaSeleccionada.Cells["CuilEmpleado"].Value.ToString();
                string dniEmpleado = filaSeleccionada.Cells["DNI"].Value?.ToString();
                string nombreEmpleado = filaSeleccionada.Cells["Nombre"].Value?.ToString();
                string apellidoEmpleado = filaSeleccionada.Cells["Apellido"].Value?.ToString();
                string emailEmpleado = filaSeleccionada.Cells["Email"].Value?.ToString();

                // Crear el objeto empleado
                Empleado empleado = new Empleado
                {
                    CUIL = cuilEmpleado,
                    DNI = dniEmpleado,
                    Nombre = nombreEmpleado,
                    Apellido = apellidoEmpleado,
                    Email = emailEmpleado
                };

                // Abrir el formulario de edición con los datos del empleado
                EditarUsuario formUsuario = new EditarUsuario(idUsuario, cuilEmpleado, empleado);
                formUsuario.ShowDialog();

                // Actualizar la lista de usuarios después de editar
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BEliminarUsuario_Click(object sender, EventArgs e)
        {
            // Verifica que haya una fila seleccionada en el DataGridView
            if (dataGridUsuarios.SelectedRows.Count > 0)
            {
                // Obtén los valores de la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridUsuarios.SelectedRows[0];
                string cuilEmpleado = filaSeleccionada.Cells["CuilEmpleado"].Value.ToString();
                string apellidoEmpleado = filaSeleccionada.Cells["Apellido"].Value.ToString();
                string nombreEmpleado = filaSeleccionada.Cells["Nombre"].Value.ToString();
                int idUsuario = Convert.ToInt32(filaSeleccionada.Cells["IdUsuario"].Value);

                // Mostrar mensaje de confirmación
                string mensaje = $"¿Estás seguro que deseas eliminar al usuario?\nCUIL: {cuilEmpleado}\nEmpleado/a: {apellidoEmpleado}, {nombreEmpleado}";
                DialogResult resultado = MessageBox.Show(mensaje, "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (resultado == DialogResult.Yes)
                {
                    // Llama al método para eliminar al usuario
                    UsuarioDAL usuarioDAL = new UsuarioDAL();
                    if (usuarioDAL.EliminarUsuario(idUsuario))
                    {
                        MessageBox.Show("Usuario eliminado exitosamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresca los datos del DataGridView
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si la columna es la de contraseña
            if (dataGridUsuarios.Columns[e.ColumnIndex].Name == "password_Usuario")
            {
                // Mostrar asteriscos en lugar del valor real
                e.Value = new string('*', 8); // Cambiar la cantidad según prefieras
                e.FormattingApplied = true;
            }
        }

        private void DataGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                BEditarUsuario.Enabled = true;
                BEliminarUsuario.Enabled = true;
            }
        }

        private void DataGridUsuario_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridUsuarios.SelectedRows.Count > 0)
            {
                BEditarUsuario.Visible = true;
                BEliminarUsuario.Visible = true;
            }
            else
            {
                // Opcionalmente, ocultar los botones si no hay selección
                BEditarUsuario.Visible = false;
                BEliminarUsuario.Visible = false;
            }
        }
    }
}