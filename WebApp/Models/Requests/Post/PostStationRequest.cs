using System.Collections.Generic;
using WebApp.Persistence.Models;

namespace WebApp.Models.Requests.Post
{
    public class PostStationRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public virtual List<StationLineDbModel> StationLines { get; set; }
    }
}