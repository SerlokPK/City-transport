using System.Collections.Generic;

namespace WebApp.Persistence.Models
{
    public enum LineType
    {
        URBAN = 0,
        SUBURBAN
    }
    public class LineDbModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public LineType LineType { get; set; }
        public virtual ICollection<DepartureDbModel> Departures { get; set; }
        public virtual ICollection<StationLineDbModel> StationLines { get; set; }
        public virtual ICollection<VehicleDbModel> Vehicles { get; set; }
    }
}