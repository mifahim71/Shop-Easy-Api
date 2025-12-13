
using Microsoft.AspNetCore.Http;
using MySqlConnector;
using ShopEasyApi.Exceptions;
using System.Net;
using System.Text.Json;

namespace ShopEasyApi.Middlewares
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }



        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            var message = ex.Message;

            switch (ex)
            {
                case MySqlException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;

                case DuplicateUserCredentialException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;

                case InvalidUserCredentialException:
                    statusCode= HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;

                case NotFoundException:
                    statusCode= HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;

                case OperationFailedException:
                    statusCode= HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;

                case StockOutException:
                    statusCode = HttpStatusCode.BadRequest;
                    message= ex.Message;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = ex.Message;
                    break;
            }

            var result = JsonSerializer.Serialize(new
            {
                success = false,
                statusCode = (int)statusCode,
                message
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(result);
        }


    }
}