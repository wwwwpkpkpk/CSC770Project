using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MysqlTest.Models;
using MySql.Data;
using MySql.Data.MySqlClient;



namespace MysqlTest.Controllers
{
    public class HomeController : Controller
    {

        public HomeController() 
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Signin()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult Signup_success()
        {
            return View();
        }
        public ActionResult Signin_success()
        {
            return View();
        }
        public ActionResult Signout()
        {
            return View();
        }
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult Staffnum()
        {
            return View();
        }
        public ActionResult Management()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
        public ActionResult Reservation()
        {
            return View();
        }
        public ActionResult Advertisement()
        {
            return View();
        }
        public ActionResult Inventory()
        {
            return View();
        }

        //Get the registration form
        [HttpPost]
        public ActionResult Signup(string newUsername, string newEmail, string newPn1, string newPn2, string newPn3, string newFname, string newLname,string newPwd, string newRPwd)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "drunkencode";
            bool duplicate = false;
            if (dbCon.IsConnect())
            {
                //Check email duplication
                dbCon.Open();
                string query = "SELECT username FROM user_account";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                Debug.WriteLine(reader.FieldCount);

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string estUsername = reader.GetString(0);
                        if (newUsername == estUsername)
                        {
                            duplicate = true;
                            break;
                        }
                    }
                    reader.NextResult();
                }
                dbCon.Close();
            }
            if (duplicate == true)
            {
                TempData["testmsg"] = "username";
                return RedirectToAction("Signup");
            }
            else if(newPwd != newRPwd)
            {
                TempData["testmsg"] = "password";
                return RedirectToAction("Signup");
            }
            else
            {
                dbCon.Open();
                if (newPwd == newRPwd)
                {
                    //Insert data to datbase
                    string pnum = newPn1 + "-" + newPn2 + "-" + newPn3;
                    var cmdInsert = new MySqlCommand("INSERT INTO user_account(username, email, firstName, lastName, fpassword, rpassword, phoneNum) Values (?username, ?email, ?firstName, ?lastName, ?fpassword, ?rpassword, ?phoneNum);", dbCon.Connection);
                    cmdInsert.Parameters.AddWithValue("?username", newUsername);
                    cmdInsert.Parameters.AddWithValue("?email", newEmail);
                    cmdInsert.Parameters.AddWithValue("?firstName", newFname);
                    cmdInsert.Parameters.AddWithValue("?lastName", newLname);
                    cmdInsert.Parameters.AddWithValue("?fpassword", newPwd);
                    cmdInsert.Parameters.AddWithValue("?rpassword", newRPwd);
                    cmdInsert.Parameters.AddWithValue("?phoneNum", pnum);
                    cmdInsert.ExecuteNonQuery();
                }
                dbCon.Close();
                return RedirectToAction("Signup_success");
                
            }
        }
        
        public ActionResult Signin(string newUsername, string newfpassword)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "drunkencode";
            dbCon.Open();
            bool existing = false;

            if (dbCon.IsConnect())
            {
                //Check email duplication
                dbCon.Open();

                string query = "SELECT username, fpassword FROM user_account where username= ?newUsername";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.Parameters.AddWithValue("?newUsername", newUsername);
                var reader = cmd.ExecuteReader();
                Debug.WriteLine(reader.FieldCount);

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string estUsername = reader.GetString(0);
                        if (newUsername == estUsername)
                        {
                            string estPassword = reader.GetString(1);

                            if()//password
                            existing = true;
                            break;
                        }
                        else
                        {
                            TempData["testmsg"] = "No_exist";
                            return RedirectToAction("Signin");
                        }
                    }
                    reader.NextResult();
                }
                dbCon.Close();
            }
            return RedirectToAction("Signin_success");

        }

        public ActionResult Errors() {
            return View();
        }


        //Get the login form
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
