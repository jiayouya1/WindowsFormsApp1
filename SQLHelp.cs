using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class SQLHelp
    {
        private static string connString = @"server=.;uid=sa;pwd=sa;database=BookDB";

        private static SqlConnection conn=null;
        private static SqlCommand command = null;

        public static SqlConnection GetSqlConnection() 
        {
            conn=new SqlConnection(connString);
            conn.Open();
            return conn;
        }

        public static SqlCommand GetSqlCommand()
        {
            command = new SqlCommand();
            return command;
        }
        public static SqlCommand GetSqlCommand(SqlConnection conn,string str)
        {
            command = new SqlCommand(str,conn);
            return command;
        }

        public static object GetExecuteScalar(SqlConnection conn,string str) 
        {
            command=GetSqlCommand(conn,str);
            return command.ExecuteScalar();
        }

        public static int GetExecuteNonQuery(SqlConnection conn, string str)
        {
            command=GetSqlCommand(conn,str);
            return command.ExecuteNonQuery();
        }

        public static SqlDataReader GetExectureReader(SqlConnection conn,string str) 
        {
            command=GetSqlCommand(conn,str);
            SqlDataReader sdr=command.ExecuteReader(CommandBehavior.CloseConnection);
            return sdr;
        }

        public static SqlDataAdapter GetDataAdapter(SqlConnection conn,string str) 
        {
            command= GetSqlCommand(conn,str);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            return adapter;
        }

        public static void CloseConn(SqlConnection conn) 
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
