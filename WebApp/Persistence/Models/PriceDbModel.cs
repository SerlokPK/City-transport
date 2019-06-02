namespace WebApp.Persistence.Models
{
    public enum TicketType
    {
        Time = 0,
        Daily,
        Monthly,
        Yearly
    }

    public enum PassengerType
    {
        Student = 0,
        Regular,
        Pensioner
    }

    public class PriceDbModel
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public PassengerType PassengerType { get; set; }
        public TicketType TicketType { get; set; }
    }
}