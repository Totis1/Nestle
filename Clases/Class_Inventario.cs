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
    internal class Class_Inventario
    {
        public void MostrarInventario(DataGridView tablaInventario)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from inventarios";
                tablaInventario.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaInventario.DataSource = dt;
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
        public void MostrarProductos(ComboBox Productos)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from productos";
                Productos.DataSource = null;
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
                MessageBox.Show("Error cbox: ", ex.ToString());
            }
        }
        public void MostrarInventarioV2(ComboBox Inventario)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from inventarios";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Inventario.DataSource = dt;
                Inventario.DisplayMember = "cantidad";
                Inventario.ValueMember = "id_inventario";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cbbox: ", ex.ToString());
            }
        }
        public void InsertarInventario(ComboBox ID_Producto, TextBox Cantidad, ComboBox ID_Departamento)
        {
            int indiceCbox1 = Convert.ToInt32(ID_Producto.SelectedValue);
            int indiceCbox2 = Convert.ToInt32(ID_Departamento.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "insert into inventarios (id_producto, cantidad, id_departamento) " +
                    "values (" + indiceCbox1 + "," + Cantidad.Text + "," + indiceCbox2 + ");";
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
        public void SeleccionarInventario(DataGridView tablaInventario, TextBox ID, ComboBox ID_Producto, TextBox Cantidad, ComboBox ID_Departamento)
        {
            try
            {
                ID.Text = tablaInventario.CurrentRow.Cells[0].Value.ToString();
                ID_Producto.Text = tablaInventario.CurrentRow.Cells[1].Value.ToString();
                Cantidad.Text = tablaInventario.CurrentRow.Cells[2].Value.ToString();
                ID_Departamento.Text = tablaInventario.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar, error:" + ex.ToString());
            }
        }
        public void ActualizarInventario(TextBox ID, ComboBox ID_Producto, TextBox Cantidad, ComboBox ID_Departamento)
        {
            int indiceCbox1 = Convert.ToInt32(ID_Producto.SelectedValue);
            int indiceCbox2 = Convert.ToInt32(ID_Departamento.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "update Inventarios set id_producto=" + indiceCbox1 + ", cantidad=" + Cantidad.Text +
                    ", id_departamento=" + indiceCbox2 +
                    " where id_inventario ='" + ID.Text + "';";
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
        public void EliminarInventario(ComboBox Eliminar)
        {
            int indiceCbox = Convert.ToInt32(Eliminar.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "delete from Inventarios where id_inventario ='" + indiceCbox + "';";
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
