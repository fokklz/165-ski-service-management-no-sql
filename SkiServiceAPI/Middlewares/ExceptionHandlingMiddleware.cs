using MongoDB.Driver;

namespace SkiServiceAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                await HandleMongoDBDuplicateKeyException(context, ex);
            }
            catch (MongoBulkWriteException ex) when (ex.WriteErrors.Any(e => e.Category == ServerErrorCategory.DuplicateKey))
            {
                await HandleMongoDBDuplicateKeyException(context, ex);
            }
            // Add additional specific catches for other MongoDB exceptions here
            catch (Exception ex)
            {
                await HandleGenericException(context, ex);
            }
        }

        private Task HandleMongoDBDuplicateKeyException(HttpContext context, Exception ex)
        {
            var errorMessage = "A duplicate key error occurred.";
            if (ex is MongoWriteException writeEx)
            {
                errorMessage += $" Message: {writeEx.WriteError.Message}";
            }
            else if (ex is MongoBulkWriteException bulkWriteEx)
            {
                var errorMessages = bulkWriteEx.WriteErrors.Select(e => e.Message).ToArray();
                errorMessage += $" Multiple errors occurred: {string.Join(", ", errorMessages)}";
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 400; // Bad Request
            return context.Response.WriteAsJsonAsync(new { error = errorMessage });
        }


        private Task HandleGenericException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500; // Internal Server Error
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                return context.Response.WriteAsJsonAsync(new { error = ex.Message, stackTrace = ex.StackTrace });

            return context.Response.WriteAsJsonAsync(new { error = "An error occurred processing your request." });
        }
    }
}
