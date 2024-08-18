using MCPlaces_Backend.Models.ApiResponse.Interfaces;
using MCPlaces_Backend.Utilities.ActionFilters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MCPlaces_Backend.Utilities.ActionFilters
{
    public class ModelValidationActionFilter : IModelValidationActionFilter
    {
        public ModelValidationActionFilter(IApiResponse apiResponse)
        {
            _apiResponse = apiResponse;
        }

        private readonly IApiResponse _apiResponse;
        public void OnActionExecuted(ActionExecutedContext context)
        {            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                _apiResponse.Failure("Supplied model is not valid.");
                context.Result = new BadRequestObjectResult(_apiResponse);
            }
        }
    }
}
