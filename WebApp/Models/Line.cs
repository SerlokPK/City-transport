using System.Collections.Generic;

namespace WebApp.Models
{
    public class Line
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Station> Stations { get; set; }

    }
}