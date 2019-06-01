using FluentValidation.Attributes;
using WebApp.Persistence.Models;
using WebApp.Validatiors;

namespace WebApp.Models.Requests
{
    [Validator(typeof(SchedulesRequestValidator))]
    public class SchedulesRequest
    {
        public int? LineNumber { get; set; }
        public DayType? DayType { get; set; }
    }
}