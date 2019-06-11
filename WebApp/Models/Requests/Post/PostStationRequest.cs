using System.Collections.Generic;

namespace WebApp.Models.Requests.Post
{
    public class PostStationRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public virtual List<int> LineIds { get; set; }
    }
}