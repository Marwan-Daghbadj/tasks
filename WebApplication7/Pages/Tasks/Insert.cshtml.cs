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
    public class InsertModel : PageModel
    {
        public List<employee> listEmplyee = new List<employee>();
        
        public void OnGet()
        {
            try
            {
                //get connection from configuration file
                string connectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                //connecting ...
                IDbConnection connection = new SqlConnection(connectionString);
                String sql = "select * from employee";
                //fetch result
                listEmplyee = connection.Query<employee>(sql).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void OnPost()
        {
            //get task details from post method
            tasks t = new tasks();
            t.t_name = Request.Form["name"];
            t.description = Request.Form["description"];
            t.em_name = Request.Form["id_employee"];
            try
            {
                //get connection from configuration file
                string connectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using SqlConnection con = new SqlConnection(connectionString);
                //open connection
                con.Open();
                //insert query
                String sql = string.Format("insert into tasks values('{0}','{1}','{2}')", t.t_name, t.description, t.em_name);
                //combine query with connection
                SqlCommand cmd = new SqlCommand(sql, con);
                //executing
                cmd.ExecuteNonQuery();
                //close con
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //redirect user to index of tasks
            Response.Redirect("/Tasks/Index");
        }
    }

}
