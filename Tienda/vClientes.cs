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
    public partial class vClientes : Form
    {
        NCliente nCliente;
        NClasificacionClientes nClasificacionClientes;
        NGrupoClientes nGrupoClientes;
        public vClientes()
        {
            InitializeComponent();
            nCliente = new NCliente();
            nClasificacionClientes = new NClasificacionClientes();
            nGrupoClientes = new NGrupoClientes();
        }

        private void vClientes_Load(object sender, EventArgs e)
        {
            cargarDatos();
            cargaCombos();
        }
        private void cargarDatos() 
        {
            var clientes = nCliente.obtenerCliente().ToList().Select(c => new { c.ClienteId, c.Codigo, c.Nombres, c.Apellidos, c.ClasificacionCliente.Descripcion }).ToList();
            dgClientes.DataSource = clientes.ToList();//nCliente.obtenerCliente();
        }

        private void cargaCombos() 
        {
            cbClasificacion.DataSource = nClasificacionClientes.obtenerClasificacionesCliente()
                                                               .Where(c => c.Estado == true).Select(c => new { c.ClasificacionClienteId, c.Descripcion })
                                                               .ToList();
            cbClasificacion.DisplayMember = "Descripcion";
            cbClasificacion.ValueMember = "ClasificacionClienteId";
            cbFiltroClasificacion.DataSource = nClasificacionClientes.obtenerClasificacionesCliente()
                                                               .Where(c => c.Estado == true).Select(c => new { c.ClasificacionClienteId, c.Descripcion })
                                                               .ToList();
            cbFiltroClasificacion.DisplayMember = "Descripcion";
            cbFiltroClasificacion.ValueMember = "ClasificacionClienteId";

            cbGrupo.DataSource = nGrupoClientes.obtenerGruposCliente()
                                               .Where(c => c.Estado == true)
                                               .Select(c => new { c.GrupoClienteId, c.Descripcion })
                                               .ToList();
            cbGrupo.DisplayMember = "Descripcion";
            cbGrupo.ValueMember = "GrupoClienteId";
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Cliente cliente = new Cliente()
            {
                Codigo = txtCodigo.Text,
                DNI = txtDNI.Text,
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                Estado = cbEstado.Checked,
                ClasificacionClienteId = int.Parse(cbClasificacion.SelectedValue.ToString()),
                GrupoClienteId = int.Parse(cbGrupo.SelectedValue.ToString()),
                FechaIngreso = DateTime.Now
            };
            nCliente.Guardar(cliente);
            cargarDatos();
        }

        private void cbFiltroClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int clasificacionId = Convert.ToInt32(cbFiltroClasificacion.SelectedValue.ToString());
            var activo = cbFiltro.Checked;
            var clientes = nCliente.obtenerCliente()
                                   .Where(c => c.ClasificacionClienteId == clasificacionId &&
                                               c.Estado == activo)
                                   .ToList()
                                   .Select(c => new { c.ClienteId, c.Codigo, c.Nombres, c.Apellidos, c.ClasificacionCliente.Descripcion }).ToList();
            dgClientes.DataSource = clientes.ToList();//nCliente.obtenerCliente();

        }
    }
}
