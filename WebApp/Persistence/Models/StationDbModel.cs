using System.Collections.Generic;

namespace WebApp.Persistence.Models

{
    public class StationDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public virtual ICollection<StationLineDbModel> StationLines { get; set; }

    }
}