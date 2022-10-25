using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;

namespace WebApplication7.Pages.Tasks
{
    public class employeeModel : PageModel
    {
        //employee list
         public List<employee> listEmplyee = new List<employee>();
        //get method
        public void OnGet()
        {
            try
            {
                //get connection from configuration file
                string connectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                //connecting ...
                IDbConnection connection = new SqlConnection(connectionString);
                //querry
                String sql = "select * from employee";
                //query result fetch into array
                listEmplyee = connection.Query<employee>(sql).ToList();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
    //class of employee
    public class employee
    {
        public string id { get; set; }
        public string em_name { get; set; }
    }
}
