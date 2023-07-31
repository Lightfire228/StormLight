using Microsoft.AspNetCore.Mvc;
using StormLight.Database;
using StormLight.Models;

namespace StormLight.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController
    : ControllerBase
{
    StormLightContext _context { get ;set; } = default!;

    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger) {
        _logger = logger;
    }

    [HttpGet(Name = "TestDB")]
    public bool TestDb() {

        return false;
    }
}
