using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings;
using MovieNinja.Models;

namespace MovieNinja.Pages
{
    public class JoinModel : PageModel
    {
        public void OnGet() 
        {
            
        } // OnGet()

        public void OnPostSignup(string username, string password, string email) 
        {
            Program.dataNinja.Signup(username, password, email);
        } // OnPostSignup()

        public void OnPostLogin(string username, string password) 
        {
            Program.dataNinja.Login(username, password);
            Response.Redirect("./Index");
        } // OnPostLogin()

        public void OnPostLogout() 
        {
            Program.dataNinja.Logout();
            Response.Redirect("./Index");
        } // OnPostLogout()
    } // class
} // namespace