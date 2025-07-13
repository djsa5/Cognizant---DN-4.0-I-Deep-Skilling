using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApiWithFilters.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = context.Exception;
            string logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logPath);
            string filePath = Path.Combine(logPath, "exceptions.txt");

            File.AppendAllText(filePath, $"[{DateTime.Now}] {error.Message}\n");

            context.Result = new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
