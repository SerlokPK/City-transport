using FluentValidation.Attributes;
using WebApp.Validatiors;

namespace WebApp.Models.Requests.Get
{
    [Validator(typeof(GetStationsRequestValidator))]
    public class GetStationsRequest
    {
        public int? LineNumber { get; set; }
    }
}