using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace EjercicioExamen
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet dsPersona()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);user=user324;pwd=123456;database=BDKatherine";
            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "select * from persona";
            ada.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ada.Fill(ds, "persona");
            return ds;
        }
        [WebMethod]
        public String agregarPersona(String ci,String nom,String ap,String am)
        {
            
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            String sql;
            con.ConnectionString = "server=(local);user=user324;pwd=123456;database=BDKatherine";
            cmd.Connection = con;
            sql = "insert into persona (ci,nombre, apellidop, apellidom) ";
            sql = sql + "VALUES ("+ci+",'"+nom+"', '"+ap+"', '"+am+"')";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            int resp=cmd.ExecuteNonQuery();
            con.Close();
            String men = "";
            if (resp > 0)
            {
                men = "Persona registrada";
            }
            else
            {
                men = "No se pudo realizar registro";
            }
            return men;
        }
        [WebMethod]
        public void ActualizarDatosPersona(int ci, string nuevoNombre, string nuevoApellidoP, string nuevoApellidoM)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);user=user324;pwd=123456;database=BDKatherine";

            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "select * from persona where ci=" + ci + "";
            ada.SelectCommand.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            ada.Fill(ds, "persona");

            if (ds.Tables["persona"].Rows.Count > 0)
            {
                ds.Tables["persona"].Rows[0]["nombre"] = nuevoNombre;
                ds.Tables["persona"].Rows[0]["apellidop"] = nuevoApellidoP;
                ds.Tables["persona"].Rows[0]["apellidom"] = nuevoApellidoM;
                SqlCommandBuilder builder = new SqlCommandBuilder(ada);
                ada.Update(ds, "persona");
            }
            else
            {
                Console.WriteLine("No se encontró ninguna persona con ci dado");
            }
        }
        [WebMethod]
        public String eliminarPersona(String ci)
        {
            try { 
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            String sql;
            con.ConnectionString = "server=(local);user=user324;pwd=123456;database=BDKatherine";
            cmd.Connection = con;
            sql = "Delete from persona where ci=" + ci + "";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            int resp = cmd.ExecuteNonQuery();
            con.Close();
            String men = "";
            if (resp > 0) {
                men = "Eliminacion realizada";
            }
            else {
                men = "No se pudo eliminar la persona tiene registrada cuentas a su nombre";
            }
            return men;
        }catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [WebMethod]
        public DataSet obtenerPersona(int ci)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);user=user324;pwd=123456;database=BDKatherine";
            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "select * from persona where ci="+ci+"";
            ada.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ada.Fill(ds, "persona");
            return ds;
        }

        [WebMethod]
        public DataSet dsCuenta()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);user=user324;pwd=123456;database=BDKatherine";
            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "SELECT * FROM persona p INNER JOIN cuenta c ON p.ci = c.persona_id";
            ada.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ada.Fill(ds, "cuenta");
            return ds;
        }
        [WebMethod]
        public String agregarCuenta(String id, String persona_id, String tipo_cuenta, String saldo)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            String sql;
            con.ConnectionString = "server=(local);user=user324;pwd=123456;database=BDKatherine";
            cmd.Connection = con;
            sql = "insert into cuenta (id,persona_id,tipo_cuenta,saldo) ";
            sql = sql + "VALUES (" + id + ",'" + persona_id + "', '" + tipo_cuenta + "', " + saldo + ")";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            int resp = cmd.ExecuteNonQuery();
            con.Close();
            String men = "";
            if (resp > 0)
            {
                men = "Persona registrada";
            }
            else
            {
                men = "No se pudo realizar registro";
            }
            return men;
        }
        [WebMethod]
        public String eliminarCuenta(String id)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            String sql;
            con.ConnectionString = "server=(local);user=user324;pwd=123456;database=BDKatherine";
            cmd.Connection = con;
            sql = "Delete from cuenta where id=" + id + "";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            int resp = cmd.ExecuteNonQuery();
            con.Close();
            String men = "";
            if (resp > 0)
            {
                men = "Eliminacion realizada";
            }
            else
            {
                men = "No se pudo eliminar la cuenta tiene registrada transacciones";
            }
            return men;
        }
        [WebMethod]
        public DataSet obtenerCuenta(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);user=user324;pwd=123456;database=BDKatherine";
            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "select * from cuenta where id=" + id + "";
            ada.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ada.Fill(ds, "cuenta");
            return ds;
        }
    }
}
