using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;
using VehicleControl.CrossCutting.Exceptions;

namespace VehicleControl.CrossCutting.Helper
{
    public class ExceptionHelper
    {
        private readonly RequestDelegate _next;

        public ExceptionHelper(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            object response = exception.Message;

            switch (exception)
            {
                case EntityValidationException _:
                    code = HttpStatusCode.BadRequest;
                    response = new ErrorMessageModel($"Requisição inválida: {exception.Message}");
                    break;

                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    response = new ErrorMessageModel("Registro não encontrado");
                    break;

                case PermissionException _:
                    code = HttpStatusCode.Unauthorized;
                    response = new ErrorMessageModel("Acesso negado");
                    break;

                case ForbiddenException _:
                    code = HttpStatusCode.Forbidden;
                    response = new ErrorMessageModel("Token inválido");
                    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    response = new ErrorMessageModel($"Erro: {exception.Message}");
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = Convert.ToInt32(code);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}
