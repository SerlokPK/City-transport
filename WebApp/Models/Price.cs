using WebApp.Persistence.Models;

namespace WebApp.Models
{
    public class Price
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public PassengerType PassengerType { get; set; }
        public TicketType TicketType { get; set; }
    }
}