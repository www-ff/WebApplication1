using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ToolMysqlData
    {
        //1.数据库的连接,创建等工作
        public static string connstr = ConfigurationManager.ConnectionStrings["lx"].ToString();
        //string url = ConfigurationSettings.AppSettings["connString"];
        static MySqlConnection conn = new MySqlConnection(connstr);

        //一个外部调用的,添加语句的方法
        public static int executeSql(String sql)
        {
            conn.Open();//打开
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;//执行外部传入的sql语句

            int result = -1;//返回值,默认为-1

            //执行语句,并将返回值赋值
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            finally
            {
                //各种关闭
                cmd.Dispose();
                conn.Close();
            }

            //返回此项返回值
            return result;
        }
    }
}