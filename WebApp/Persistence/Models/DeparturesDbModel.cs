using System;

namespace WebApp.Persistence.Models
{
    public enum DayType
    {
        WORKDAY = 0,
        SATURDAY,
        SUNDAY
    }

    public class DeparturesDbModel
    {
        public int Id { get; set; }
        public DayType DayType { get; set; }
        public DateTime Time { get; set; }
        public int LineDbModelId { get; set; }
        public LineDbModel LineDbModel { get; set; }
    }
}