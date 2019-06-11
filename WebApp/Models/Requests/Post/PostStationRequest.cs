using FluentValidation.Attributes;
using System.Collections.Generic;
using WebApp.Validatiors.Post;

namespace WebApp.Models.Requests.Post
{
    [Validator(typeof(PostStationRequestValidator))]
    public class PostStationRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public virtual List<int> LineIds { get; set; }
    }
}