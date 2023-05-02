using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AccesoADatosADO
{
    internal class Conexion
    {
        const string strConnection = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True";
        public static int ExecuteCommand(string query, Action<SqlCommand> pExeCommand)
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
            catch (Exception ex)
            {
                result = 0;
            }

            return result;
        }
        public static async Task<int> ExecuteCommandASync(string query, Action<SqlCommand> pExeCommand)
        {
            int result = 0;
            try
            {
                using (var conn = new SqlConnection(strConnection))
                {
                    await conn.OpenAsync(); // conexion
                    var sqlcommand = new SqlCommand(query, conn);
                    pExeCommand(sqlcommand);
                    return await sqlcommand.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
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
        public static async Task ExecuteReaderAsync(string query, Action<SqlDataReader> reader)
        {
            using (var conn = new SqlConnection(strConnection))
            {
                await conn.OpenAsync(); // conexion
                var sqlcommand = new SqlCommand(query, conn);
                var sqlReader = await sqlcommand.ExecuteReaderAsync();
                while (sqlReader.Read())
                {
                    reader(sqlReader);
                }
            }
        }
    }
}
