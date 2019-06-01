namespace WebApp.Persistence.Models
{
    public class VehicleDbModel
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int LineDbModelId { get; set; }
        public virtual LineDbModel LineDbModel { get; set; }
    }
}