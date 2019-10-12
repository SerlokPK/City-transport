using System.Linq;
using System.Web.Http.ModelBinding;
using WebApp.Models;

namespace WebApp.Helpers
{
    public static class ErrorHelper
    {
        public static Error GetErrorMessage(ModelStateDictionary modelState)
        {
            var errorMessage = modelState.Values.ToList()[0].Errors.FirstOrDefault(e => e.ErrorMessage != "")?.ErrorMessage;
            return new Error()
            {
                ErrorMessage = errorMessage ?? "Bad request."
            };
        }
    }
}