using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route ("/api/image")]
    public class ImageController: ControllerBase
    {
        [HttpGet]
        [Route ("{name}")]
        public async Task<FileContentResult> Get(string name) {
            var image = await System.IO.File.ReadAllBytesAsync($"../Infrastructure/Img/{name}");
            return File(image, "image/jpeg");
        }
    }
}