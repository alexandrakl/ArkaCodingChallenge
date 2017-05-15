using MyArkaProject.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyArkaProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        // GET: My Account -> Closet
        [AllowAnonymous]
        public ActionResult MyAccount()
        {
            string user = User.Identity.Name;
            string userId = string.Empty;
            string closetName = string.Empty;
            List<string> closetsList = new List<string>();
            List<int> closetIdsList = new List<int>();
            List<string> outfitsList = new List<string>();
            List<string> closetInviteList = new List<string>();
            List<string> outfitInviteList = new List<string>();

            Debug.WriteLine(user);
            // get User Id for user name
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UserConnection"].ConnectionString))
            {
                connection.Open();
                //Debug.WriteLine(user);
                StringBuilder sb = new StringBuilder();
                sb.Append("Select TOP 1 [Id] from [dbo].[AspNetUsers] where [Email]='" + user + "'");

                using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //get UserId
                            Debug.WriteLine(user);
                            Debug.WriteLine(reader["Id"].ToString());
                            userId = reader["Id"].ToString();                   
                        }
                    }
                }
            }

            return View();
        }

        public ActionResult SimpleInterest()
        {
            return View();
        }

    }
}
