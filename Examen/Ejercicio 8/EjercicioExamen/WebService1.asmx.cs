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
        public int agregarPersona(String ci,String nom,String ap,String am)
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
            return resp;
        }
        [WebMethod]
        public int ActualizarDatosPersona(string ci, string nnom, string nap, string nam)
        {
            
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            String sql;
            con.ConnectionString = "server=(local);user=user324;pwd=123456;database=BDKatherine";
            cmd.Connection = con;
            sql = "UPDATE persona SET nombre = '" + nnom + "',apellidop = '" + nap + "',apellidom = '" + nam + "' WHERE  ci=" + ci + "";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            int resp = cmd.ExecuteNonQuery();
            con.Close();
            return resp;
        }
        [WebMethod]
        public int eliminarPersona(String ci)
        {
            try { SqlConnection con = new SqlConnection();
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
            return resp;
            }
            catch (Exception e){
                return -1;
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

        
    }
}
