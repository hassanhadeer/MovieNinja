using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using MovieNinja.Models;

namespace MovieNinja 
{
    public class Fetch
    {
        public string cs = "Server=(localdb)\\ProjectsV13;Database=MovieNinjaDB;Trusted_Connection=true";
        public HttpClient client = new HttpClient();
        public const string API_KEY = "d194eb72915bc79fac2eb1a70a71ddd3";
        public string Data { get; set; }   
        public string Videos { get; set; }
        public string Details { get; set; }
        public string Credits { get; set; }

        public async Task GetTrends() { 
            ClearHeaders();

            // Get the latest trends in Movies
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/trending/movie/day?api_key=" + API_KEY);

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.trendSet = JsonSerializer.Deserialize<TrendSet>(Data);
            }
            else {
                Data = null;
            }
        } // GetTrends()

        public async Task Search(string search) {
            ClearHeaders();

            // Does a movie search
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/search/movie?api_key=" + API_KEY + "&query=" + search);

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.posterSet = JsonSerializer.Deserialize<PosterSet>(Data);
            }
            else {
                Data = null;
            }
        } // Seach()

        public async Task GetDetails(string movieID) {
            ClearHeaders();

            //===========================>>
            // Grabs Video details
            HttpResponseMessage videoDetails =
                await client.GetAsync(
                    "https://api.themoviedb.org/3/movie/" + movieID
                                      + "/videos?api_key=" + API_KEY + "&language=en-US");

            HttpResponseMessage movieDetails =
            await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" + movieID 
                    + "?api_key=" + API_KEY + "&language=en-US");

            HttpResponseMessage castDetails =
            await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" + movieID +
                    "/credits?api_key=" + API_KEY);

            if (videoDetails.IsSuccessStatusCode || 
                movieDetails.IsSuccessStatusCode ||
                castDetails.IsSuccessStatusCode)
            {
                Videos = await videoDetails.Content.ReadAsStringAsync();
                Details = await movieDetails.Content.ReadAsStringAsync();
                Credits = await castDetails.Content.ReadAsStringAsync();
                Program.videoSet = JsonSerializer.Deserialize<VideoSet>(Videos);
                Program.movie = JsonSerializer.Deserialize<Movie>(Details);
                Program.creditSet = JsonSerializer.Deserialize<CreditSet>(Credits);
            }
            else
            {
                Data = null;
            }
        } // GetDetails()

            // Get Actor Details
        public async Task GetActorDetails(string id)
        {
            ClearHeaders();

            HttpResponseMessage actorData =
                await client.GetAsync("https://api.themoviedb.org/3/person/" + id +
                    "?api_key=" + API_KEY + "&language=en-US");

            if (actorData.IsSuccessStatusCode)
            {
                Data = await actorData.Content.ReadAsStringAsync();
                Program.actor = JsonSerializer.Deserialize<Actor>(Data);
            }
            else
            {
                Data = null;
            }
        }  // Get Actor Details()

            // Get Actor Images
        public async Task GetActorImages(string id)
        {
            ClearHeaders();
            
            HttpResponseMessage profileData =
                await client.GetAsync("https://api.themoviedb.org/3/person/" + id 
                    + "/images" + "?api_key=" + API_KEY + "&language=en-US");

            if (profileData.IsSuccessStatusCode)
            {
                Data = await profileData.Content.ReadAsStringAsync();
                Program.profileSet = JsonSerializer.Deserialize<ProfileSet>(Data);
            }
            else
            {
                Data = null;
            }
        } // Get Actor Images()

        // Get Related Movies
        public async Task GetRelatedMovies(string id)
        {
            ClearHeaders();

            HttpResponseMessage relatedData =
                await client.GetAsync("https://api.themoviedb.org/3/discover/movie?with_cast=" + id + 
                "&sort_by=revenue.desc&api_key=" + API_KEY + "&language=en-US");

            if (relatedData.IsSuccessStatusCode)
            {
                Data = await relatedData.Content.ReadAsStringAsync();
                Program.relatedSet = JsonSerializer.Deserialize<RelatedSet>(Data);
            }
            else
            {
                Data = null;
            }
        } // Get Related Movies()

        public void ClearHeaders() {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicationException/json"));
        } // clearHeaders
    } // class
} // namespace