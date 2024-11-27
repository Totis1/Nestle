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
    internal class Class_Clientes
    {
        public void MostrarClientes(DataGridView tablaClientes)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from clientes";
                tablaClientes.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaClientes.DataSource = dt;
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error dgv: ", ex.ToString());
            }
        }
        public void MostrarClientesV2(ComboBox Clientes)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from clientes";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Clientes.DataSource = dt;
                Clientes.DisplayMember = "nombre_cliente";
                Clientes.ValueMember = "id_cliente";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cbbox: ", ex.ToString());
            }
        }
        public void InsertarCliente(TextBox Nombre, DateTimePicker Fecha_Registro, ComboBox Estado, TextBox Correo, TextBox Telefono)
        {
            DateTime fechaRegistro = Fecha_Registro.Value;
            string fechRegis = fechaRegistro.ToString("yyyy-MM-dd");
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "insert into clientes (nombre_cliente, fecha_registro, estado, email, telefono) " +
                    "values ('" + Nombre.Text + "','" + fechRegis + "','" + Estado.Text + "','" + Correo.Text + "','" + Telefono.Text + "');";
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
        public void SeleccionarCliente(DataGridView tablaClientes, TextBox ID, TextBox Nombre, DateTimePicker Fecha_Registro, ComboBox Estado, TextBox Correo, TextBox Telefono)
        {
            try
            {
                ID.Text = tablaClientes.CurrentRow.Cells[0].Value.ToString();
                Nombre.Text = tablaClientes.CurrentRow.Cells[1].Value.ToString();
                Fecha_Registro.Value = Convert.ToDateTime(tablaClientes.CurrentRow.Cells[2].Value.ToString());
                Estado.Text = tablaClientes.CurrentRow.Cells[3].Value.ToString();
                Correo.Text = tablaClientes.CurrentRow.Cells[4].Value.ToString();
                Telefono.Text = tablaClientes.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar, error:" + ex.ToString());
            }
        }
        public void ActualizarCliente(TextBox ID, TextBox Nombre, DateTimePicker Fecha_Registro, ComboBox Estado, TextBox Correo, TextBox Telefono)
        {
            DateTime fechaRegistro = Fecha_Registro.Value;
            string fechRegis = fechaRegistro.ToString("yyyy-MM-dd");
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "update Clientes set nombre_cliente='" + Nombre.Text + "', fecha_registro='" + fechRegis + "', estado='" + Estado.Text + "', email='" + Correo.Text +
                    "', telefono='" + Telefono.Text +
                    "' where id_cliente ='" + ID.Text + "';";
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
        public void EliminarCliente(ComboBox Eliminar)
        {
            int indiceCbox = Convert.ToInt32(Eliminar.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "delete from Clientes where id_cliente ='" + indiceCbox + "';";
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
                MessageBox.Show("No se elimino el registro del proyecto, error: " + ex.ToString());
            }
        }
    }
}
