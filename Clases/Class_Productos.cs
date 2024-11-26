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
    internal class Class_Productos
    {
        public void MostrarProductos(DataGridView tablaProductos)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from productos";
                tablaProductos.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaProductos.DataSource = dt;
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
        public void MostrarProductosV2(ComboBox Productos)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from productos";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Productos.DataSource = dt;
                Productos.DisplayMember = "nombre_producto";
                Productos.ValueMember = "id_producto";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cbbox: ", ex.ToString());
            }
        }
        public void InsertarProductos(TextBox NombreProducto, TextBox Descripcion, TextBox Precio, TextBox Stock, ComboBox ID_departamento)
        {
            int indiceCbox1 = Convert.ToInt32(ID_departamento.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "insert into productos (nombre_producto, descripcion, precio, stock, id_departamento) " +
                    "values ('" + NombreProducto.Text + "','" + Descripcion.Text + "'," + Precio.Text + "," + Stock.Text + "," + indiceCbox1 + ");";
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
        public void SeleccionarProducto(DataGridView tablaProductos, TextBox ID, TextBox NombreProducto, TextBox Descripcion, TextBox Precio, TextBox Stock, ComboBox ID_departamento)
        {
            try
            {
                ID.Text = tablaProductos.CurrentRow.Cells[0].Value.ToString();
                NombreProducto.Text = tablaProductos.CurrentRow.Cells[1].Value.ToString();
                Descripcion.Text = tablaProductos.CurrentRow.Cells[2].Value.ToString();
                Precio.Text = tablaProductos.CurrentRow.Cells[3].Value.ToString();
                Stock.Text = tablaProductos.CurrentRow.Cells[4].Value.ToString();
                ID_departamento.Text = tablaProductos.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar, error:" + ex.ToString());
            }
        }
        public void ActualizarProducto(TextBox ID, TextBox NombreProducto, TextBox Descripcion, TextBox Precio, TextBox Stock, ComboBox ID_departamento)
        {
            int indiceCbox1 = Convert.ToInt32(ID_departamento.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "update Productos set nombre_producto='" + NombreProducto.Text + "', descripcion='" + Descripcion.Text + "', precio=" + Precio.Text + ", stock=" + Stock.Text +
                    ", id_departamento=" + indiceCbox1 +
                    " where id_producto ='" + ID.Text + "';";
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
        public void EliminarProducto(ComboBox Eliminar)
        {
            int indiceCbox = Convert.ToInt32(Eliminar.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "delete from Productos where id_producto ='" + indiceCbox + "';";
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
