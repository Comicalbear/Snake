using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace 贪吃蛇1.NewFolder1
{
    class Sqlhelp
    {
        //创建连接字符串
        static string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        public static SqlConnection conn = new SqlConnection();

        public static bool Open()
        {
            //连接属性赋值
            conn.ConnectionString = connectionString;
            //尝试打开连接
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                try
                {

                    conn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public static SqlDataReader ExecuteSql(string sql)
        {
            //1-打开数据库连接
            Sqlhelp.Open();
            //2-创建Command对象
            SqlCommand command = new SqlCommand();
            command.Connection = Sqlhelp.conn;
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            //3-执行查询返回结果到DataReader
            SqlDataReader dr = command.ExecuteReader();
            //返回查询结果           
            return dr;
        }
        public static void GetSchema(string sql, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                try
                {

                    conn.GetSchema();

                }
                catch
                {

                }
            }
        }
    }
}
