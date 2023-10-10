using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Minio.DataModel;
using StormLight.Database;
using StormLight.Models;
using StormLight.Models.Api.Storage;
using StormLight.Storage;
using StormLight.Storage.S3;

namespace StormLight.Server.Controllers;

[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[Produces(MediaTypeNames.Application.Json)]

[ApiController]
[Route("/api/v1/[controller]")]
public class StorageController
    : ControllerBase
{
    StormLightContext _context { get ;set; } = default!;

    private readonly IStorage<ProgressReport>   _storageClient;
    private readonly ILogger<StorageController> _logger;

    public StorageController(
        IStorage<ProgressReport>   storageClient,
        ILogger<StorageController> logger
    ) {
        _storageClient = storageClient;
        _logger        = logger;
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("GetUploadUrl", Name = "GetUploadUrl")]
    //TODO: CSRF token
    // [GenerateAntiforgeryTokenCookie]
    public async Task<ActionResult<UploadUrl>> GetUploadUrl() {

        return new UploadUrl() {
            Url = await _storageClient.GetUploadUrl()
        };

    }


    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [HttpPut("UploadFile", Name = "UploadFile")]
    // //TODO: CSRF token
    // // [GenerateAntiforgeryTokenCookie]
    // public async Task<ActionResult> UploadFile(IFormFile file) {

    //     await _storageClient.UploadFile()

    //     return Ok();

    // }
}
