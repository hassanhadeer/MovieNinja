using System.Collections.Generic;

namespace MovieNinja.Models {
    public class CreditSet {
        public int id { get; set; }
        public List<Cast> cast { get; set; }
        public List<Crew> crew { get; set; }
    }
}