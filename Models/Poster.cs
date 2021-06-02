
using System.Collections.Generic;

namespace MovieNinja.Models 
{
    public class Poster 
    {
        public int id { get; set; }
        public bool adult { get; set; }
        public float popularity { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public List<int> genre_ids { get; set; }
        public float vote_average { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
    }
}