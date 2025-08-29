using AdvertisingPlatforms.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace AdvertisingPlatforms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly PlatformsService _service;

        public PlatformsController(PlatformsService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Файл не загружен");

            using var reader = new StreamReader(file.OpenReadStream());
            var lines = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                if (line != null)
                    lines.Add(line);
            }

            _service.LoadFromLines(lines);

            return Ok("Данные загружены");
        }


        [HttpGet("search")]
        public IActionResult Search([FromQuery] string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return BadRequest("Локация не указана");

            var result = _service.Search(location);
            return Ok(result);
        }
    }
}
