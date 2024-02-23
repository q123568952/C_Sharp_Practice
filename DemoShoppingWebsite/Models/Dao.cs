using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DemoShoppingWebsite.Models.Dao
{
    public class Dao
    {
        MySqlConnection conn;
        String sql = "SELECT * FROM UserInfo";
        public MySqlConnection getConn()
        {
            string connstr = "server=mysql://dropcatasia.c10mg2ikizc4.ap-northeast-3.rds.amazonaws.com;port=3306;user=admin;password=Dropcat666;database=Dropcat;Charset=utf8;";
            
            conn = new MySqlConnection(connstr);
            conn.Open(); 
            return conn; 
        }
        public MySqlCommand command(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, getConn());
            return cmd;
        }
        
        public MySqlDataReader read(string sql) // 读取操作
        {
            return command(sql).ExecuteReader();
        }

        public void show(string sql) // 读取操作
        {
            MySqlDataReader reader = command(sql).ExecuteReader();
            while (reader.Read())
            {
                //输出第一列字段值
                Console.Write(reader + "\t");
                //Console.Write(reader.GetInt32("id") + "\t");

                //判断字段"username"是否为null，为null数据转换会失败
                if (!reader.IsDBNull(1))
                {
                    //输出第二列字段值
                    Console.Write(reader.GetString(1) + "\t");
                    //Console.Write(reader.GetString("username") + "\t");
                }
                //判断字段"password"是否为null，为null数据转换会失败
                if (!reader.IsDBNull(2))
                {
                    //输出第三列字段值
                    Console.Write(reader.GetString(2) + "\n");
                    //Console.Write(reader.GetString("password") + "\t");
                }
            }
        }

        public void DaoClose() // 关闭数据库连接
        {
            conn.Close();
        }
    }
}