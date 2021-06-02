
using System;
using System.Collections.Generic;

namespace MovieNinja.Models
{
    public class TrendSet
    {
        public int page { get; set; }
        public List<Trend> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}