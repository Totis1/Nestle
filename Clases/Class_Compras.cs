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
    internal class Class_Compras
    {
        public void MostrarCompras(DataGridView tablaCompras)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from compras";
                tablaCompras.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaCompras.DataSource = dt;
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error dgv: ", ex.ToString());
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
        public void MostrarProveedores(ComboBox Proveedores)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from proveedores";
                Proveedores.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Proveedores.DataSource = dt;
                Proveedores.DisplayMember = "nombre_proveedor";
                Proveedores.ValueMember = "id_proveedor";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cbox: ", ex.ToString());
            }
        }
        public void MostrarComprasV2(ComboBox Compras)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from compras";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Compras.DataSource = dt;
                Compras.DisplayMember = "fecha_compra";
                Compras.ValueMember = "id_compra";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cbbox: ", ex.ToString());
            }
        }
        public void InsertarCompras(ComboBox ID_Producto, TextBox Cantidad, DateTimePicker Fecha_Compra, TextBox Precio, ComboBox ID_Proveedor)
        {
            int indiceCbox1 = Convert.ToInt32(ID_Producto.SelectedValue);
            int indiceCbox2 = Convert.ToInt32(ID_Proveedor.SelectedValue);
            DateTime fechaCompra = Fecha_Compra.Value;
            string fechComp = fechaCompra.ToString("yyyy-MM-dd");
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "insert into compras (id_producto, cantidad, fecha_compra, precio_compra, id_proveedor) " +
                    "values (" + indiceCbox1 + "," + Cantidad.Text + ",'" + fechComp + "'," + Precio.Text + "," + indiceCbox2 + ");";
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
        public void SeleccionarCompras(DataGridView tablaCompras, TextBox ID, ComboBox ID_Producto, TextBox Cantidad, DateTimePicker Fecha_Compra, TextBox Precio, ComboBox ID_Proveedor)
        {
            try
            {
                ID.Text = tablaCompras.CurrentRow.Cells[0].Value.ToString();
                ID_Producto.Text = tablaCompras.CurrentRow.Cells[1].Value.ToString();
                Cantidad.Text = tablaCompras.CurrentRow.Cells[2].Value.ToString();
                Fecha_Compra.Value = Convert.ToDateTime(tablaCompras.CurrentRow.Cells[3].Value.ToString());
                Precio.Text = tablaCompras.CurrentRow.Cells[4].Value.ToString();
                ID_Proveedor.Text = tablaCompras.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar, error:" + ex.ToString());
            }
        }
        public void ActualizarCompra(TextBox ID, ComboBox ID_Producto, TextBox Cantidad, DateTimePicker Fecha_Compra, TextBox Precio, ComboBox ID_Proveedor)
        {
            int indiceCbox1 = Convert.ToInt32(ID_Producto.SelectedValue);
            int indiceCbox2 = Convert.ToInt32(ID_Proveedor.SelectedValue);
            DateTime fechaCompra = Fecha_Compra.Value;
            string fechComp = fechaCompra.ToString("yyyy-MM-dd");
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "update Compras set id_producto=" + indiceCbox1 + ", cantidad=" + Cantidad.Text + ", fecha_compra='" + fechComp + "', precio_compra=" + Precio.Text +
                    ", id_proveedor=" + indiceCbox2 +
                    " where id_compra ='" + ID.Text + "';";
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
        public void EliminarCompra(ComboBox Eliminar)
        {
            int indiceCbox = Convert.ToInt32(Eliminar.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "delete from Compras where id_compra ='" + indiceCbox + "';";
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
