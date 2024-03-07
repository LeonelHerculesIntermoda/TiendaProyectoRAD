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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void clasificacionClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vClasificacionCliente vClasificacionCliente = new vClasificacionCliente();
            vClasificacionCliente.MdiParent = this;
            vClasificacionCliente.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vClientes vClientes = new vClientes();
            vClientes.MdiParent = this;
            vClientes.Show();
        }
    }
}
