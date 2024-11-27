using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios
{
    public partial class Finanzas : Form
    {
        public Finanzas()
        {
            InitializeComponent();
            Clases.Class_Compras objCompras = new Clases.Class_Compras();
            objCompras.MostrarCompras(dgvCompras);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Formularios.Compras.Agregar_Compra frmAgregar = new Compras.Agregar_Compra();
            frmAgregar.ShowDialog();
            Clases.Class_Compras objCompras = new Clases.Class_Compras();
            objCompras.MostrarCompras(dgvCompras);
        }

        private void dgvCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Formularios.Compras.Actualizar_Compra frmActualizar = new Compras.Actualizar_Compra();
            Clases.Class_Compras objCompras = new Clases.Class_Compras();
            objCompras.SeleccionarCompras(dgvCompras,frmActualizar.TxtBoxID,frmActualizar.CBoxProducto,frmActualizar.TxtBoxCantidad,frmActualizar.DtpFechaCompra,frmActualizar.TxtBoxPrecio,frmActualizar.CBoxProovedor);
            frmActualizar.ShowDialog();
            objCompras.MostrarCompras(dgvCompras);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Formularios.Compras.Borrar_Compra frmBorrar = new Compras.Borrar_Compra();
            frmBorrar.ShowDialog();
            Clases.Class_Compras objCompras = new Clases.Class_Compras();
            objCompras.MostrarCompras(dgvCompras);
        }
    }
}
