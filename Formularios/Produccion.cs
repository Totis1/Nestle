using Nestle.Formularios.RH;
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
    public partial class Produccion : Form
    {
        public Produccion()
        {
            InitializeComponent();
            Clases.Class_Productos objProducto = new Clases.Class_Productos();
            objProducto.MostrarProductos(dgvProductos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Formularios.Productos.Agregar_Producto frmAgregar = new Productos.Agregar_Producto();
            frmAgregar.ShowDialog();
            Clases.Class_Productos objProducto = new Clases.Class_Productos();
            objProducto.MostrarProductos(dgvProductos);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Formularios.Productos.Borrar_Producto frmBorrar = new Productos.Borrar_Producto();
            frmBorrar.ShowDialog();
            Clases.Class_Productos objProducto = new Clases.Class_Productos();
            objProducto.MostrarProductos(dgvProductos);
        }

        private void dgvProductos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Formularios.Productos.Actualizar_Producto frmactualizar = new Productos.Actualizar_Producto();
            Clases.Class_Productos objProducto = new Clases.Class_Productos();
            objProducto.SeleccionarProducto(dgvProductos, frmactualizar.TxtBoxID, frmactualizar.TxtBoxNombre, frmactualizar.TxtBoxDescripcion,frmactualizar.TxtBoxPrecio,frmactualizar.TxtBoxStock,frmactualizar.CBoxDepartamento);
            frmactualizar.ShowDialog();
            objProducto.MostrarProductos(dgvProductos);
        }
    }
}
