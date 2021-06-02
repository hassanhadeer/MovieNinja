using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MovieNinja.Models;

namespace MovieNinja.Pages
{
    public class DetailsModel : PageModel
    {
        // Cast Details
        public List<string> castPics = new List<string>();
        public List<string> castNames = new List<string>();
        public List<int> actorIDs = new List<int>();

        // Movie details
        public string movieOverview;
        public int movieRuntime;
        public string movieTagline;
        public long movieRevenue;
        public string movieReleaseDate;
        public string moviePoster;
        public string movieTitle;
        public string movieYearAndRuntime;

        public async Task OnGet(string id)
        {
            Program.dataNinja.movieID = id;
            Program.dataNinja.poster_path = Program.movie.poster_path;
            Program.dataNinja.overview = Program.movie.overview;
            await Program.fetch.GetDetails(id);

            movieOverview = Program.movie.overview;
            movieRuntime = Program.movie.runtime;
            movieTagline = Program.movie.tagline;
            movieRevenue = Program.movie.revenue;
            movieReleaseDate = Program.movie.release_date;
            moviePoster = Program.movie.poster_path;
            movieTitle = Program.movie.title;
            movieYearAndRuntime = "released " + movieReleaseDate.Substring(0, 4) + " " + movieRuntime + "mins";

            for(int i = 0; i < Program.creditSet.cast.Count; i++)
            {
                castPics.Add(Program.creditSet.cast[i].profile_path);
                actorIDs.Add(Program.creditSet.cast[i].id);
                castNames.Add(Program.creditSet.cast[i].name);
            }
        }

        public void OnPostGetActor(string actorID) {
            Response.Redirect("./Actor?id=" + actorID);
        }

        public void OnPostAddToWatch(string movieID, string poster_path, string overview, string userID) {
            Program.dataNinja.AddToWatch(movieID, poster_path, overview, userID);
            Response.Redirect("./Details?id=" + Program.dataNinja.movieID);
        }

        public void OnPostLogin(string username, string password) 
        {
            Program.dataNinja.Login(username, password);
            Response.Redirect("./Details?id=" + Program.dataNinja.movieID);
        }
        public void OnPostLogout() 
        {
            Program.dataNinja.Logout();
            Response.Redirect("./Index");
        }
    }
}