using FluentValidation.Attributes;
using WebApp.Validatiors;

namespace WebApp.Models.Requests
{
    [Validator(typeof(StationsRequestValidator))]
    public class StationsRequest
    {
        public int? LineNumber { get; set; }
    }
}