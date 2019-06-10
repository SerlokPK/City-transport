using FluentValidation.Attributes;
using WebApp.Persistence.Models;
using WebApp.Validatiors;

namespace WebApp.Models.Requests.Get
{
    [Validator(typeof(GetSchedulesRequestValidator))]
    public class GetSchedulesRequest
    {
        public int? LineNumber { get; set; }
        public DayType? DayType { get; set; }
    }
}