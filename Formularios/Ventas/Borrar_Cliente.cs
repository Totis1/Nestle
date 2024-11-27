using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios.Ventas
{
    public partial class Borrar_Cliente : Form
    {
        public Borrar_Cliente()
        {
            InitializeComponent();
            Clases.Class_Clientes objCliente = new Clases.Class_Clientes();
            objCliente.MostrarClientesV2(CBoxBorrar);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Clases.Class_Clientes objCliente = new Clases.Class_Clientes();
            objCliente.EliminarCliente(CBoxBorrar);
            this.Close();
        }
    }
}
