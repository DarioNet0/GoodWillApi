using GoodWill.Communication.Responses;
using GoodWill.Exception;
using GoodWill.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoodWill.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is GoodWillException)
            {
                HandleProjectException(context);
            }

        }
        private void HandleProjectException(ExceptionContext context)
        {
            var cashFlowException = (GoodWillException)context.Exception;
            var errorResponse = new ResponseErrorJson(cashFlowException.GetErrors());

            context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }
        private void ThrowUnknownError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
