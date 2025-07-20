using System.Net;
using System.Text.Json;
using AnimeAPI.Domain.ValueObjects.Exceptions.DirectorExceptions;
using AnimeAPI.Domain.ValueObjects.Exceptions.NameExceptions;
using AnimeAPI.Domain.ValueObjects.Exceptions.SummaryExceptions;

namespace AnimeAPI.API.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            var exceptionId = Guid.NewGuid();
            logger.LogError(ex, "Exceção não tratada capturada pelo middleware. ID da exceção: {ExcecaoId}", exceptionId);
            
            await HandleExceptionAsync(httpContext, ex, exceptionId);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, Guid exceptionId)
    {
        context.Response.ContentType = "application/json";
        
        var statusCode = HttpStatusCode.InternalServerError;
        var message = "Um erro inesperado ocorreu. Por favor, tente novamente mais tarde.";
        string details = $"Se o problema persistir, por favor, entre em contato com o suporte e forneça o ID de erro: {exceptionId}";

        
        switch (exception)
        {
            case InvalidOperationException:
                statusCode = HttpStatusCode.BadRequest;
                message = "Os dados fornecidos são inválidos ou a operação não é permitida.";
                details = exception.Message;
                break;
            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                message = "O recurso solicitado não foi encontrado.";
                details = exception.Message;
                break;
            case UnauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized;
                message = "Acesso não autorizado.";
                details = exception.Message;
                break;
            case NotSupportedException:
                statusCode = HttpStatusCode.NotImplemented;
                message = "A funcionalidade solicitada não está implementada.";
                details = exception.Message;
                break;
            case TimeoutException:
                statusCode = HttpStatusCode.RequestTimeout;
                message = "A solicitação demorou muito tempo para ser concluída.";
                details = exception.Message;
                break;
            case HttpRequestException:
                statusCode = HttpStatusCode.ServiceUnavailable;
                message = "O serviço está temporariamente indisponível. Por favor, tente novamente mais tarde.";
                details = exception.Message;
                break;
            case InvalidNameSizeException:
                statusCode = HttpStatusCode.BadRequest;
                message = "O tamanho do nome fornecido é inválido.";
                details = exception.Message;
                break;
            case NullNameException:
                statusCode = HttpStatusCode.BadRequest;
                message = "O nome fornecido não pode ser nulo.";
                details = exception.Message;
                break;
            case InvalidDirectorSizeException:
                statusCode = HttpStatusCode.BadRequest;
                message = "O tamanho do nome do diretor fornecido é inválido.";
                details = exception.Message;
                break;
            case NullDirectorException:
                statusCode = HttpStatusCode.BadRequest;
                message = "O nome do diretor fornecido não pode ser nulo.";
                details = exception.Message;
                break;
            case InvalidSummarySizeException:
                statusCode = HttpStatusCode.BadRequest;
                message = "O tamanho do resumo fornecido é inválido.";
                details = exception.Message;
                break;
            case NullSummaryException:
                statusCode = HttpStatusCode.BadRequest;
                message = "O resumo fornecido não pode ser nulo.";
                details = exception.Message;
                break;
        }
       

        context.Response.StatusCode = (int)statusCode; 
        
        var responseBody = new
        {
            statusCode = (int)statusCode,
            message = message,
            details = details,
            errorId = exceptionId,
            timestamp = DateTime.UtcNow
        };
        
        return context.Response.WriteAsync(JsonSerializer.Serialize(responseBody, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
    }

}