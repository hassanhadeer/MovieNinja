using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieNinja.Models;

namespace MovieNinja
{
    public class Program
    {
        public static Fetch fetch = new Fetch(); // API method call to TMDB
        public static DataNinja dataNinja = new DataNinja(); // SP calls to DB
        public static TrendSet trendSet = new TrendSet();
        public static PosterSet posterSet = new PosterSet();
        public static Movie movie = new Movie();
        public static VideoSet videoSet = new VideoSet();
        public static CreditSet creditSet = new CreditSet();
        public static int userID = 0;

        public static Actor actor;
        public static ProfileSet profileSet;
        public static RelatedSet relatedSet;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}