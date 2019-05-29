namespace WebApp.Persistence.Models

{
    public class StationLineDbModel
    {
        public int StationId { get; set; }
        public int LineId { get; set; }

        public virtual LineDbModel Line { get; set; }
        public virtual StationDbModel Station { get; set; }
    }
}