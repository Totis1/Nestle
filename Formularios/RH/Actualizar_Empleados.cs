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
    public partial class Actualizar_Empleados : Form
    {
        public Actualizar_Empleados()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Clases.Class_Empleados objEmpleado = new Clases.Class_Empleados();
            objEmpleado.ActualizarEmpleado(TxtBoxID,TxtBoxNombres,TxtBoxApellidos,TxtBoxCorreo,TxtBoxContraseña,TxtboxTelefono,CBoxDepartamento,CBoxCargo);
            this.Close();
        }

        private void Actualizar_Empleados_Load(object sender, EventArgs e)
        {
            Clases.Class_Empleados objEmpleado = new Clases.Class_Empleados();
            objEmpleado.MostarCargos(CBoxCargo);
            objEmpleado.MostarDepartamentos(CBoxDepartamento);
        }

        private void TxtboxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
