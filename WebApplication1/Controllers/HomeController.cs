using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
       public ActionResult PersonnelAdd()
        {
              return View();
        }
        [HttpPost]
        public ActionResult PersonnelAdd(student students)
        {
            try
            {
                string sql = string.Format(@"insert into student values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", students.name, students.gender, students.age, students.birth, students.phone, students.body_temperature, students.date_filling);
                Console.WriteLine(students);
                //判断是否添加成功
                if (students.name.ToString().Length > 300)
                {
                    return Content("<script >alert('姓名长度不能超过300字！');window.history.back(-1);</script >", "text/html");
                }
                else if (Convert.ToInt32(students.age) < 1 || Convert.ToInt32(students.age) > 200)
                {
                    return Content("<script >alert('年龄范围在1~200！');window.history.back(-1);</script >", "text/html");
                }
                else if (students.phone.ToString().Length != 11)
                {
                    return Content("<script >alert('手机号格式错误！');window.history.back(-1);</script >", "text/html");
                }
                else if (Convert.ToInt32(students.body_temperature) < 30 || Convert.ToInt32(students.body_temperature) > 50)
                {
                    return Content("<script >alert('体温范围在30℃~50℃！');window.history.back(-1);</script >", "text/html");
                }
                else if (ToolMysqlData.executeSql(sql) > 0)
                {
                    return Content("<script >alert('录入成功！');window.history.back(-1);document.getElementsByTagName('input').value='';</script >", "text/html");
                }
                else
                {
                    return Content("<script >alert('录入失败！');window.history.back(-1);</script >", "text/html");
                }
            }
            catch (Exception)
            {
                return Content("<script >alert('录入失败！该人员已录入');window.history.back(-1);</script >", "text/html");
                throw;
            }

        }
    }
}