using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication7.Pages.Employee
{
    public class InsertModel : PageModel
    {
        public void OnGet()
        {
        }
        //Post method for post action
        public void OnPost()
        {
            //retrieve name of employee
            string em_name = Request.Form["name"];
            try
            {
                //get connection from configuration file
                string connectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using SqlConnection con = new SqlConnection(connectionString);
                //connecting ...
                con.Open();
                //insert querry
                String sql = string.Format("insert into employee values('{0}')", em_name);
                //combine query with connection
                SqlCommand cmd = new SqlCommand(sql, con);
                //executing query 
                cmd.ExecuteNonQuery();
                //close connection
                con.Close();
            }
            catch (Exception ex)
            {
            }
            //back to index
            Response.Redirect("/Employee/Index");
        }
    }
}
