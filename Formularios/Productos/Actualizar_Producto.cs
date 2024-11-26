using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios.Productos
{
    public partial class Actualizar_Producto : Form
    {
        public Actualizar_Producto()
        {
            InitializeComponent();
            Clases.Class_Productos objProducto = new Clases.Class_Productos();
            objProducto.MostarDepartamentos(CBoxDepartamento);
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Clases.Class_Productos objProducto = new Clases.Class_Productos();
            objProducto.ActualizarProducto(TxtBoxID,TxtBoxNombre,TxtBoxDescripcion,TxtBoxPrecio,TxtBoxStock,CBoxDepartamento);
            this.Close();
        }
    }
}
