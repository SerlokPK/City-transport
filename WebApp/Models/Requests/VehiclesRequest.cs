using FluentValidation.Attributes;
using WebApp.Validatiors;

namespace WebApp.Models.Requests
{
    [Validator(typeof(VehiclesRequestValidator))]
    public class VehiclesRequest
    {
        public int? LineNumber { get; set; }
    }
}