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
    internal class Class_Ventas
    {
        public void MostrarVentas(DataGridView tablaVentas)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from ventas";
                tablaVentas.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaVentas.DataSource = dt;
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
        public void MostrarClientes(ComboBox Clientes)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from clientes";
                Clientes.DataSource = null;
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
                MessageBox.Show("Error cbox: ", ex.ToString());
            }
        }
        public void MostrarVentasV2(ComboBox Ventas)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from ventas";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Ventas.DataSource = dt;
                Ventas.DisplayMember = "fecha_venta";
                Ventas.ValueMember = "id_venta";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cbbox: ", ex.ToString());
            }
        }
        public void InsertarVentas(ComboBox ID_Producto, TextBox Cantidad, DateTimePicker Fecha_Venta, TextBox Precio, ComboBox ID_Cliente)
        {
            int indiceCbox1 = Convert.ToInt32(ID_Producto.SelectedValue);
            int indiceCbox2 = Convert.ToInt32(ID_Cliente.SelectedValue);
            DateTime fechaVenta = Fecha_Venta.Value;
            string fechVent = fechaVenta.ToString("yyyy-MM-dd");
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "insert into ventas (id_producto, cantidad, fecha_venta, precio_venta, id_cliente) " +
                    "values (" + indiceCbox1 + "," + Cantidad.Text + ",'" + fechVent + "'," + Precio.Text + "," + indiceCbox2 + ");";
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
        public void SeleccionarVentas(DataGridView tablaVentas, TextBox ID, ComboBox ID_Producto, TextBox Cantidad, DateTimePicker Fecha_Venta, TextBox Precio, ComboBox ID_Cliente)
        {
            try
            {
                ID.Text = tablaVentas.CurrentRow.Cells[0].Value.ToString();
                ID_Producto.Text = tablaVentas.CurrentRow.Cells[1].Value.ToString();
                Cantidad.Text = tablaVentas.CurrentRow.Cells[2].Value.ToString();
                Fecha_Venta.Value = Convert.ToDateTime(tablaVentas.CurrentRow.Cells[3].Value.ToString());
                Precio.Text = tablaVentas.CurrentRow.Cells[4].Value.ToString();
                ID_Cliente.Text = tablaVentas.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar, error:" + ex.ToString());
            }
        }
        public void ActualizarVenta(TextBox ID, ComboBox ID_Producto, TextBox Cantidad, DateTimePicker Fecha_Venta, TextBox Precio, ComboBox ID_Cliente)
        {
            int indiceCbox1 = Convert.ToInt32(ID_Producto.SelectedValue);
            int indiceCbox2 = Convert.ToInt32(ID_Cliente.SelectedValue);
            DateTime fechaVenta = Fecha_Venta.Value;
            string fechVent = fechaVenta.ToString("yyyy-MM-dd");
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "update Ventas set id_producto=" + indiceCbox1 + ", cantidad=" + Cantidad.Text + ", fecha_venta='" + fechVent + "', precio_venta=" + Precio.Text +
                    ", id_cliente=" + indiceCbox2 +
                    " where id_venta ='" + ID.Text + "';";
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
        public void EliminarVenta(ComboBox Eliminar)
        {
            int indiceCbox = Convert.ToInt32(Eliminar.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "delete from Ventas where id_venta ='" + indiceCbox + "';";
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
