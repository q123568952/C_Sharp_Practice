using DemoShoppingWebsite.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoShoppingWebsite.Controllers
{
    public class UserController : Controller
    {
        MySqlConnection conn;
        // GET: User
        public ActionResult ListUser()
        {
            String sql = "SELECT id, usericon, userAccount, email, username, createtime  FROM UserInfo";
            string connstr = "server=dropcatasia.c10mg2ikizc4.ap-northeast-3.rds.amazonaws.com;port=3306;user=admin;password=Dropcat666;database=Dropcat;Charset=utf8;";
            conn = new MySqlConnection(connstr);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            LinkedList<User> userlist = new LinkedList<User>();
            while (reader.Read())
            {
                User user = new User();
                user.id = (int)reader["id"];
                user.icon = (string)reader["usericon"];
                user.userAccount = (string)reader["userAccount"];
                user.email = (string)reader["email"];
                user.username = (string)reader["username"];
                user.createtime = (DateTime)reader["createtime"];
                userlist.AddLast(user);
            }
            



            return View(userlist);
        }
    }
}