using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PeopleRegistration.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
   
    private readonly ILoggerManager _logger;

    public WeatherForecastController(ILoggerManager logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        //_logger.LogInfo("Here is the info message from the controller");
        //_logger.LogDebug("Here is debug message from the controller");
        //_logger.LogWarn("Here is warn message from the controller");
        //_logger.LogError("Here is error message from the controller");

        return new string[] {"value 1", "value 2" };   
    }
}