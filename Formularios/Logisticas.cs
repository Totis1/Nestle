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
    public partial class Logisticas : Form
    {
        public Logisticas()
        {
            InitializeComponent();
            Clases.Class_Inventario objInventario = new Clases.Class_Inventario();
            objInventario.MostrarInventario(dgvInventario);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Formularios.Logistica.Agregar_Inventario frmAgregar = new Logistica.Agregar_Inventario();
            frmAgregar.ShowDialog();
            Clases.Class_Inventario objInventario = new Clases.Class_Inventario();
            objInventario.MostrarInventario(dgvInventario);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Formularios.Logistica.Borrar_Inventario frmBorrar = new Logistica.Borrar_Inventario();
            frmBorrar.ShowDialog();
            Clases.Class_Inventario objInventario = new Clases.Class_Inventario();
            objInventario.MostrarInventario(dgvInventario);
        }

        private void dgvInventario_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Formularios.Logistica.Actualizar_Inventario frmActualizar = new Logistica.Actualizar_Inventario();
            Clases.Class_Inventario objInventario = new Clases.Class_Inventario();
            objInventario.SeleccionarInventario(dgvInventario,frmActualizar.TxtBoxID,frmActualizar.CBoxProducto,frmActualizar.TxtBoxCantidad,frmActualizar.CBoxDepartamento);
            frmActualizar.ShowDialog();
            objInventario.MostrarInventario(dgvInventario);
        }
    }
}
