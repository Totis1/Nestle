using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Formularios.RH
{
    public partial class Borrar_Empleado : Form
    {
        public Borrar_Empleado()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Borrar_Empleado_Load(object sender, EventArgs e)
        {
            Clases.Class_Empleados objEmpleado = new Clases.Class_Empleados();
            objEmpleado.MostrarEmpleadosV2(CBoxEmpleado);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Clases.Class_Empleados objEmpleado = new Clases.Class_Empleados();
            objEmpleado.EliminarEmpleado(CBoxEmpleado);
            this.Close();
        }
    }
}
