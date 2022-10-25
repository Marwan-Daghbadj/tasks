using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication7.Pages.Tasks
{
    public class EditModel : PageModel
    {
        public List<employee> listEmplyee = new List<employee>();
        public tasks task = new tasks();
        public string taskId;
        public string err = "";
        //use get method to retreive informations about the task
        public void OnGet()
        {
            try
            {
                taskId = Request.Query["id"];
                //get connection from configuration file
                string connectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                //connecting ...
                IDbConnection connection = new SqlConnection(connectionString);
                String sql = "select * from employee";
                listEmplyee = connection.Query<employee>(sql).ToList();
                //query to add the first result of the query
                sql = string.Format("select tasks.id,tasks.t_name,tasks.description,employee.em_name from tasks,employee where tasks.id_employee=employee.id and tasks.id={0}", taskId);
                task = connection.Query<tasks>(sql).ToList()[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void OnPost()
        {
            try
            {
                //save data ofter editing
                taskId = Request.Form["taskId"];
                tasks t = new tasks
                {
                    t_name = Request.Form["name"],
                    description = Request.Form["description"],
                    em_name = Request.Form["id_employee"]
                };
                //get connection from configuration file
                string connectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                //update the sepecific row 
                string sql = String.Format("update tasks set t_name = '{0}', description = '{1}', id_employee = '{2}' where id = {3}", t.t_name, t.description, t.em_name, int.Parse(taskId));
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                err = ex.StackTrace;
                return ;
            }
            //redirecting
            Response.Redirect("/Tasks/Index");
        }
    }
}
