using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradeDO.Exceptions;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsHandlerController : ControllerBase
    {
        private readonly ILogger _logger;
        public ErrorsHandlerController(ILogger<ErrorsHandlerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/error")]
        [HttpPut("/error")]
        [HttpPost("/error")]
        [HttpDelete("/error")]
        public IActionResult HandleError()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
            
            if (exceptionDetails != null)
            {
                _logger.LogError(exceptionDetails.Error.Message, "error was throwed");
                _logger.LogDebug(exceptionDetails.Error, "");
            }
            if (exceptionDetails?.Error is StudentAlradyExistException AeEx)
            {
                _logger.LogWarning("The student already exist!!");
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Exist already",
                statusCode: 700
                );

            }

            if (exceptionDetails?.Error is StudentInCorrectPassException ncEx)
            {
                _logger.LogWarning("The entered password is not correct!!");
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "password is not correct",
                statusCode: 400
                );

            }

            if (exceptionDetails?.Error is StudentNotExistException neEx)
            {
                _logger.LogWarning("The student is not exist!!");
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "not exist student",
                statusCode: 300
                );

            }

            if (exceptionDetails?.Error is GradeNotExistException gneEx)
            {
                _logger.LogWarning("The grade is not exist!!");
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "not exist grade",
                statusCode: 999
                );

            }
            if (exceptionDetails?.Error is NullReferenceException)
            {
                return Problem(
                detail: "Please connect the owner of the website 59869083450",
                title: "An error occurred",
                statusCode: 777
                );

            }
            return Problem(
                detail: "Please restart the website agein",
                title: "An error occurred",
                statusCode: 500
            );
        }
    }
}
