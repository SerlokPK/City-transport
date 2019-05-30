using WebApp.Persistence.Models;

namespace WebApp.Models.Requests
{
    public class SchedulesRequest
    {
        public int LineNumber { get; set; }
        public DayType DayType { get; set; }
    }
}