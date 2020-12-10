using System.Collections.Generic;

namespace WPFMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public ulong BoxOffice { get; set; }
        public uint Year { get; set; }
        public List<Award> Awards { get; set; }
    } 
}
