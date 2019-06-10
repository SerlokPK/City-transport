using FluentValidation.Attributes;
using WebApp.Validatiors;

namespace WebApp.Models.Requests.Get
{
    [Validator(typeof(GetVehiclesRequestValidator))]
    public class GetVehiclesRequest
    {
        public int? LineNumber { get; set; }
    }
}