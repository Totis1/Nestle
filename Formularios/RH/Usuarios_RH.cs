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
    public partial class Usuarios_RH : Form
    {
        public Usuarios_RH()
        {
            InitializeComponent();
            Clases.Class_Empleados objEmpleado = new Clases.Class_Empleados();
            objEmpleado.MostrarEmpleados(DgvEmpleados);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Formularios.RH.Agregar_Empleado frmAgregar = new Agregar_Empleado();
            frmAgregar.ShowDialog();
            Clases.Class_Empleados objEmpleado = new Clases.Class_Empleados();
            objEmpleado.MostrarEmpleados(DgvEmpleados);
        }

        private void DgvEmpleados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Formularios.RH.Actualizar_Empleados frmActualizar = new Actualizar_Empleados();
            Clases.Class_Empleados objEmpleado = new Clases.Class_Empleados();
            objEmpleado.SeleccionarEmpleado(DgvEmpleados,frmActualizar.TxtBoxID,frmActualizar.TxtBoxNombres,frmActualizar.TxtBoxApellidos,frmActualizar.TxtBoxCorreo,frmActualizar.TxtBoxContraseña,frmActualizar.TxtboxTelefono,frmActualizar.CBoxDepartamento,frmActualizar.CBoxCargo);
            frmActualizar.ShowDialog();
            objEmpleado.MostrarEmpleados(DgvEmpleados);
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            Clases.Class_Empleados objEmpleado = new Clases.Class_Empleados();
            Formularios.RH.Borrar_Empleado frmborrar = new Borrar_Empleado();
            frmborrar.ShowDialog();
            objEmpleado.MostrarEmpleados(DgvEmpleados);
        }
    }
}
