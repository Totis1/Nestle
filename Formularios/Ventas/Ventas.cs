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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
            Clases.Class_Ventas objVenta = new Clases.Class_Ventas();
            objVenta.MostrarVentas(dgvVentas);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Formularios.Ventas.Agregar_Venta frmAgregar = new Agregar_Venta();
            frmAgregar.ShowDialog();
            Clases.Class_Ventas objVenta = new Clases.Class_Ventas();
            objVenta.MostrarVentas(dgvVentas);
        }

        private void dgvVentas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Formularios.Ventas.Actualizar_Venta frmActualizar = new Actualizar_Venta();
            Clases.Class_Ventas objVenta = new Clases.Class_Ventas();
            objVenta.SeleccionarVentas(dgvVentas,frmActualizar.TxtBoxID,frmActualizar.CBoxProducto,frmActualizar.TxtBoxCantidad,frmActualizar.DtpFechaVenta,frmActualizar.TxtBoxPrecio,frmActualizar.CBoxCliente);
            frmActualizar.ShowDialog();
            objVenta.MostrarVentas(dgvVentas);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Formularios.Ventas.Borrar_Venta frmBorrar = new Borrar_Venta();
            frmBorrar.ShowDialog();
            Clases.Class_Ventas objVenta = new Clases.Class_Ventas();
            objVenta.MostrarVentas(dgvVentas);
        }
    }
}
