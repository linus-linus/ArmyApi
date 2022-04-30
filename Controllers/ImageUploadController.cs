#nullable disable
using Microsoft.AspNetCore.Mvc;


namespace ArmyAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class ImageUploadController : ControllerBase
{

    private readonly IWebHostEnvironment _hosting;

    public ImageUploadController(IWebHostEnvironment hosting)
    {
          _hosting = hosting;
    }

    [HttpPost]
    [Route("[action]")] //https://localhost:7135/ImageUpload/PostImage
    public IActionResult PostImage(IFormFile file)
    {
    if(file != null)
    {
      string webRootPath = _hosting.WebRootPath;
      string absolutePath = Path.Combine($"{webRootPath}/images/{file.FileName}");

      using(var fileStream = new FileStream(absolutePath, FileMode.Create))
      {
          try
          {
          file.CopyTo(fileStream);
          }
          catch
          {
              return StatusCode(500);

          }
      }
      return Ok();
      }
      else 
      {
          return BadRequest();
      }

    }
}