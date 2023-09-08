using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SQLGetData
    {
        public static int GetId(SqlConnection conn,int bid) 
        {
            string str = "select id from Book where bid=@bid";
            SqlCommand cmd=new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@bid", bid);
            int id=(int)cmd.ExecuteScalar();
            return id;
        }

        public static DateTime GetBookInTime(SqlConnection conn,int id) 
        {
            string str = "select inTime from Book where id=@id";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@id", id);
            DateTime time = (DateTime)cmd.ExecuteScalar();
            return time;
        }

        public static DateTime GetBackupTableInTime(SqlConnection conn, int id)
        {
            string str = "select inTime from backupTable where id=@id";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@id", id);
            DateTime time = (DateTime)cmd.ExecuteScalar();
            return time;
        }
    }
}
