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
    internal class Class_Proyectos
    {
        public void MostrarProyectos(DataGridView tablaProyectos)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from proyectos";
                tablaProyectos.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaProyectos.DataSource = dt;
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cbbox: ", ex.ToString());
            }
        }
        public void MostarDepartamentos(ComboBox Departamento)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from departamentos";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query,objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Departamento.DataSource = dt;
                Departamento.DisplayMember = "nombre_departamento";
                Departamento.ValueMember = "id_departamento";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {

            }
        }
        public void MostarProyectos_V2(ComboBox Proyectos)
        {
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "select * from proyectos";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objConn.establecerConn());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Proyectos.DataSource = dt;
                Proyectos.DisplayMember = "nombre_proyecto";
                Proyectos.ValueMember = "id_proyecto";
                objConn.cerrarConn();
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertarProyecto(TextBox Nombre, TextBox Descripcion, DateTimePicker FechaInicio, DateTimePicker FechaFin, ComboBox IdDepartamento)
        {
            int indiceCbox = Convert.ToInt32(IdDepartamento.SelectedValue);
            DateTime fechaInicio = FechaInicio.Value;
            DateTime fechaFin = FechaFin.Value;
            string fechIni = fechaInicio.ToString("yyyy-MM-dd");
            string fechFin = fechaFin.ToString("yyyy-MM-dd");
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "insert into Proyectos (nombre_proyecto, descripcion, fecha_inicio, fecha_fin, id_departamento) " +
                    "values ('"+ Nombre.Text + "','" + Descripcion.Text + "','" + fechIni + "','" + fechFin + "','" + indiceCbox + "');";
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
        public void SeleccionarProyecto(DataGridView tablaProyectos, TextBox ID, TextBox Nombre, TextBox Descripcion, DateTimePicker FechaInicio, DateTimePicker FechaFin, ComboBox IdDepartamento)
        {
            try
            {
                ID.Text = tablaProyectos.CurrentRow.Cells[0].Value.ToString();
                Nombre.Text = tablaProyectos.CurrentRow.Cells[1].Value.ToString();
                Descripcion.Text = tablaProyectos.CurrentRow.Cells[2].Value.ToString();
                FechaInicio.Value = Convert.ToDateTime(tablaProyectos.CurrentRow.Cells[3].Value.ToString());
                FechaFin.Value = Convert.ToDateTime(tablaProyectos.CurrentRow.Cells[4].Value.ToString());
                IdDepartamento.Text = tablaProyectos.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar, error:" + ex.ToString());
            }
        }
        public void ActualizarProyecto(TextBox ID,TextBox Nombre ,TextBox Descripcion, DateTimePicker FechaInicio, DateTimePicker FechaFin, ComboBox IdDepartamento)
        {
            int indiceCbox = Convert.ToInt32(IdDepartamento.SelectedValue);
            DateTime fechaInicio = FechaInicio.Value;
            DateTime fechaFin = FechaFin.Value;
            string fechIni = fechaInicio.ToString("yyyy-MM-dd");
            string fechFin = fechaFin.ToString("yyyy-MM-dd");
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "update Proyectos set nombre_proyecto='" + Nombre.Text + "', descripcion='" + Descripcion.Text + "', fecha_inicio='" + fechIni +
                    "', fecha_fin='" + fechFin + "', id_departamento='" + indiceCbox +
                    "'where id_proyecto ='" + ID.Text + "';";
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
        public void EliminarProyecto(ComboBox Eliminar)
        {
            int indiceCbox = Convert.ToInt32(Eliminar.SelectedValue);
            try
            {
                Conexion_DB objConn = new Conexion_DB();
                string query = "delete from Proyectos where id_proyecto ='" + indiceCbox + "';";
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
