using System.Net;
using joinfreela.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace joinfreela.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is BadRequestException )
            {
                var exception = context.Exception as BadRequestException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(
                    new{
                        Message = exception.Message,
                        Errors = exception.Errors
                    }
                );
            }
            
            else if(context.Exception is NotFoundException){
                var exception = context.Exception as NotFoundException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new JsonResult(
                    new{
                        Message = exception.Message 
                    }
                );
            }

            else if(context.Exception is NotAuthorizedException){
                var exception = context.Exception as NotAuthorizedException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(
                    new{
                        Message = exception.Message 
                    }
                );
            }
            else if(context.Exception is PaymentException){
                var exception = context.Exception as PaymentException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result= new JsonResult(
                    new{
                        Message = exception.Message
                    }
                );
            }

        }
    }
}