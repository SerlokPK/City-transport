using System;

namespace WebApp.Persistence.Models
{
    public enum DayType
    {
        WORKDAY = 0,
        SATURDAY,
        SUNDAY
    }

    public enum Direction
    {
        A = 0,
        B
    }

    public class DepartureDbModel
    {
        public int Id { get; set; }
        public Direction Direction { get; set; }
        public DayType DayType { get; set; }
        public DateTime Time { get; set; }
        public int LineDbModelId { get; set; }
        public virtual LineDbModel LineDbModel { get; set; }
    }
}