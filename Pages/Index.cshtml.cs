using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using MovieNinja.Models;

namespace MovieNinja.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> posterURLS = new List<string>();
        public List<string> overviews = new List<string>();
        public List<string> movieIDs = new List<string>();

        public async Task OnGet()
        {
            await Program.fetch.GetTrends();
            foreach(Trend trend in Program.trendSet.results) {
                posterURLS.Add(trend.poster_path);
                overviews.Add(trend.overview);
                movieIDs.Add(trend.id.ToString());
            }
        } // OnGet()

        public async Task OnPostSearch(string search) {
            await Program.fetch.Search(search);
            foreach(Poster poster in Program.posterSet.results) {
                posterURLS.Add(poster.poster_path);
                overviews.Add(poster.overview);
                movieIDs.Add(poster.id.ToString());
            }
        }

        public void OnPostDetails(string movieID) {
            Response.Redirect("./Details?id=" + movieID);
        }

        public void OnPostLogin(string username, string password) 
        {
            Program.dataNinja.Login(username, password);
            Response.Redirect("./Index");
        }
        public void OnPostLogout() 
        {
            Program.dataNinja.Logout();
            Response.Redirect("./Index");
        }
    }
}