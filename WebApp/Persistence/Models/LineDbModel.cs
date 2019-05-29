using System.Collections.Generic;

namespace WebApp.Persistence.Models
{
    public class LineDbModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public virtual ICollection<StationLineDbModel> StationLines { get; set; }

    }
}