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
    public class IndexModel : PageModel
    {
        public List<tasks> listTasks = new List<tasks>();
        public void OnGet()
        {
            try
            {
                //get connection from configuration file
                string connectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                //connecting ...
                IDbConnection connection = new SqlConnection(connectionString);
                //querry to get deatils of tasks for insertion in table in front-end
                String sql = "select tasks.id,tasks.t_name,tasks.description,employee.em_name from tasks,employee where tasks.id_employee=employee.id";
                //dapper allows us to execute queries faster
                listTasks = connection.Query<tasks>(sql).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    //tasks class that contains info for each task
    public class tasks
    {
        public string id { get; set; }
        public string t_name { get; set; }
        public string description { get; set; }
        public string em_name { get; set; }
    }
}
