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
    public partial class Agregar_Empleado : Form
    {
        public Agregar_Empleado()
        {
            InitializeComponent();

        }

        private void TxtboxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Agregar_Empleado_Load(object sender, EventArgs e)
        {
            Clases.Class_Empleados objEmpleados = new Clases.Class_Empleados();
            objEmpleados.MostarDepartamentos(CBoxDepartamento);
            objEmpleados.MostarCargos(CBoxCargo);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clases.Class_Empleados objEmpleado = new Clases.Class_Empleados();
            objEmpleado.InsertarEmpleados(TxtBoxNombres,TxtBoxApellidos,TxtBoxCorreo,TxtBoxContraseña,TxtboxTelefono,CBoxDepartamento,CBoxCargo);
            this.Close();
        }
    }
}
