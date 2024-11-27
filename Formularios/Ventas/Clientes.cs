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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            Clases.Class_Clientes objCliente = new Clases.Class_Clientes();
            objCliente.MostrarClientes(dgvClientes);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Formularios.Ventas.Agregar_Cliente frmAgregar = new Agregar_Cliente();
            frmAgregar.ShowDialog();
            Clases.Class_Clientes objCliente = new Clases.Class_Clientes();
            objCliente.MostrarClientes(dgvClientes);
        }

        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Formularios.Ventas.Actualizar_Cliente frmActualizar = new Actualizar_Cliente();
            Clases.Class_Clientes objCliente = new Clases.Class_Clientes();
            objCliente.SeleccionarCliente(dgvClientes,frmActualizar.TxtBoxID,frmActualizar.TxtBoxNombre,frmActualizar.DtpFechaRegistro,frmActualizar.CBoxEstado,frmActualizar.TxtBoxCorreo,frmActualizar.TxtBoxTelefono);
            frmActualizar.ShowDialog();
            objCliente.MostrarClientes(dgvClientes);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Formularios.Ventas.Borrar_Cliente frmBorrar = new Borrar_Cliente();
            frmBorrar.ShowDialog();
            Clases.Class_Clientes objCliente = new Clases.Class_Clientes();
            objCliente.MostrarClientes(dgvClientes);
        }
    }
}
