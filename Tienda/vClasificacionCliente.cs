using Datos.Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda
{
    public partial class vClasificacionCliente : Form
    {
        NClasificacionClientes nClasificacionClientes;

        public vClasificacionCliente()
        {
            InitializeComponent();
            nClasificacionClientes = new NClasificacionClientes();
        }

        private void vClasificacionCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos() 
        {
            var datos = nClasificacionClientes.obtenerClasificacionesCliente().Select(c => new
            {
                c.ClasificacionClienteId,
                c.Codigo,
                c.Descripcion,
                c.Estado,
            });
            //gvClasificacionCliente.DataSource = nClasificacionClientes.obtenerClasificacionesCliente();
            gvClasificacionCliente.DataSource = datos.ToList();
        }
        private void Limpiar()
        {
            txtClasificacionId.Text = "";
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            cbEstado.Checked = false;
            errorProvider1.Clear();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string clasificacionId = txtClasificacionId.Text;
            string codigo = txtCodigo.Text;
            string descripcion = txtDescripcion.Text;
            if (string.IsNullOrEmpty(codigo) || string.IsNullOrWhiteSpace(codigo))
            {
                errorProvider1.SetError(txtCodigo, "Debe colocar el codigo de la clasificacion");
                return;
            }

            if (string.IsNullOrEmpty(descripcion) || string.IsNullOrWhiteSpace(descripcion))
            {
                errorProvider1.SetError(txtDescripcion, "Debe colocar la descripcion");
                return;
            }
            if (string.IsNullOrEmpty(clasificacionId) || string.IsNullOrWhiteSpace(clasificacionId))
            {
                clasificacionId = "0";
            }

            var clasificacionCliente = new ClasificacionCliente();
            if (int.Parse(clasificacionId) != 0)
            {
                clasificacionCliente.ClasificacionClienteId = int.Parse(clasificacionId);
            }
            clasificacionCliente.Codigo = codigo;
            clasificacionCliente.Descripcion = descripcion;
            clasificacionCliente.Estado = cbEstado.Checked;
            nClasificacionClientes.Guardar(clasificacionCliente);
            
            Limpiar();
            CargarDatos();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gvClasificacionCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClasificacionId.Text = gvClasificacionCliente.CurrentRow.Cells["ClasificacionClienteId"].Value.ToString(); 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string clasificacionId = txtClasificacionId.Text;
           
            if (string.IsNullOrEmpty(clasificacionId) || string.IsNullOrWhiteSpace(clasificacionId))
            {
                errorProvider1.SetError(txtClasificacionId, "Debe seleccionar un registro para eliminar");
                return;
            }

            
            nClasificacionClientes.Eliminar(int.Parse(clasificacionId));

            Limpiar();
            CargarDatos();
        }
    }
}
