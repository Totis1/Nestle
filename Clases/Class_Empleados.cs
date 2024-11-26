using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nestle.Clases
{
    internal class Class_Empleados
    {
        public void MostrarEmpleados(DataGridView tablaEmpleados)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from empleados";
                tablaEmpleados.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaEmpleados.DataSource = dt;
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error dgv: ", ex.ToString());
            }
        }
        public void MostarDepartamentos(ComboBox Departamento)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from departamentos";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Departamento.DataSource = dt;
                Departamento.DisplayMember = "nombre_departamento";
                Departamento.ValueMember = "id_departamento";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cbbox: ", ex.ToString());
            }
        }
        public void MostarCargos(ComboBox Cargos)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from cargos";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Cargos.DataSource = dt;
                Cargos.DisplayMember = "nombre_cargo";
                Cargos.ValueMember = "id_cargo";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cbbox: ", ex.ToString());
            }
        }
        public void MostrarEmpleadosV2(ComboBox Empleados)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from empleados";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Empleados.DataSource = dt;
                Empleados.DisplayMember = "email";
                Empleados.ValueMember = "id_empleado";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cbbox: ", ex.ToString());
            }
        }
        public void InsertarEmpleados(TextBox Nombres, TextBox Apellidos, TextBox Email, TextBox Contraseña, TextBox Telefono, ComboBox ID_departamento, ComboBox ID_cargo)
        {
            int indiceCbox1 = Convert.ToInt32(ID_departamento.SelectedValue);
            int indiceCbox2 = Convert.ToInt32(ID_cargo.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "insert into empleados (nombre_empleado, apellido_empleado, email, contraseña, telefono, id_departamento, id_cargo) " +
                    "values ('" + Nombres.Text + "','" + Apellidos.Text + "','" + Email.Text + "','" + Contraseña.Text + "','" + Telefono.Text + "','" + indiceCbox1 + "','" + indiceCbox2 + "');";
                MySqlCommand cmd = new MySqlCommand(query, objConn.establecerConn());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }
        }
        public void SeleccionarEmpleado(DataGridView tablaEmpleados, TextBox ID, TextBox Nombres, TextBox Apellidos, TextBox Email, TextBox Contraseña, TextBox Telefono, ComboBox ID_departamento, ComboBox ID_cargo)
        {
            try
            {
                ID.Text = tablaEmpleados.CurrentRow.Cells[0].Value.ToString();
                ID_cargo.Text = tablaEmpleados.CurrentRow.Cells[1].Value.ToString();
                Nombres.Text = tablaEmpleados.CurrentRow.Cells[2].Value.ToString();
                Apellidos.Text = tablaEmpleados.CurrentRow.Cells[3].Value.ToString();
                Email.Text = tablaEmpleados.CurrentRow.Cells[4].Value.ToString();
                Contraseña.Text = tablaEmpleados.CurrentRow.Cells[5].Value.ToString();
                Telefono.Text = tablaEmpleados.CurrentRow.Cells[6].Value.ToString();
                ID_departamento.Text = tablaEmpleados.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar, error:" + ex.ToString());
            }
        }
        public void ActualizarEmpleado(TextBox ID, TextBox Nombres, TextBox Apellidos, TextBox Email, TextBox Contraseña, TextBox Telefono, ComboBox ID_departamento, ComboBox ID_cargo)
        {
            int indiceCbox1 = Convert.ToInt32(ID_departamento.SelectedValue);
            int indiceCbox2 = Convert.ToInt32(ID_cargo.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "update Empleados set id_cargo='" + indiceCbox2 + "', nombre_empleado='" + Nombres.Text + "', apellido_empleado='" + Apellidos.Text + "', email='" + Email.Text +
                    "', contraseña='" + Contraseña.Text + "', telefono='" + Telefono.Text + "', id_departamento='" + indiceCbox1 +
                    "'where id_empleado ='" + ID.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, objConn.establecerConn());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar registro: " + ex.ToString());
            }
        }
        public void EliminarEmpleado(ComboBox Eliminar)
        {
            int indiceCbox = Convert.ToInt32(Eliminar.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "delete from Empleados where id_empleado ='" + indiceCbox + "';";
                MySqlCommand cmd = new MySqlCommand(query, objConn.establecerConn());
                MySqlDataReader reader = cmd.ExecuteReader();
                //MessageBox.Show("Se guardo el registro");
                while (reader.Read())
                {

                }
                MessageBox.Show("Se borro el campo seleccionado satisfactoriamente");
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se elimino el proyecto, error: " + ex.ToString());
            }
        }
    }
}
