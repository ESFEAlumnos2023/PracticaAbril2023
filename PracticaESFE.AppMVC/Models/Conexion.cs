using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;
namespace PracticaESFE.AppMVC.Models
{
    public class Conexion
    {
        const string strConnection = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True";
        public static int ExecuteCommand(string query,Action<SqlCommand> pExeCommand)
        {
            int result = 0;
            try
            {
                using (var conn = new SqlConnection(strConnection))
                {
                    conn.Open(); // conexion
                    var sqlcommand = new SqlCommand(query, conn);
                    pExeCommand(sqlcommand);
                    return sqlcommand.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                result = 0;
            }
           
            return result;
        }
        public static void ExecuteReader(string query, Action<SqlCommand> exeCommand, Action<SqlDataReader> reader)
        {           
            using (var conn = new SqlConnection(strConnection))
            {
                conn.Open(); // conexion
                var sqlcommand = new SqlCommand(query, conn);
                exeCommand(sqlcommand);
                var sqlReader = sqlcommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    reader(sqlReader);
                }
            }
        }
        public static void ExecuteReader(string query, Action<SqlDataReader> reader)
        {
            using (var conn = new SqlConnection(strConnection))
            {
                conn.Open(); // conexion
                var sqlcommand = new SqlCommand(query, conn);               
                var sqlReader = sqlcommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    reader(sqlReader);
                }
            }
        }       
    }
}
