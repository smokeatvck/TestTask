using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Poster.Application.Exceptions;
using System.Net;

namespace Poster.Application.Filters
{
    /// <summary>
    /// Фильтр исключений
    /// </summary>
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger) {
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            context.Result = new ContentResult()
            {
                Content = JsonConvert.SerializeObject(
                 new
                 {
                     StatusCode = (int)HttpStatusCode.InternalServerError,
                     ErrorMessage = context.Exception.InnerException is AppException ex
                        ? ex.ResponseMessage
                        : "Возникла ошибка при выполнении запроса",
                 }),
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ContentType = "application/json"
            };


            _logger.LogError(context.Exception, context.Exception.Message);

            return Task.CompletedTask;
        }
    }
}
