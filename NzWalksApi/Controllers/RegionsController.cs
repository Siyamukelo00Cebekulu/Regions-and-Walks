using Microsoft.AspNetCore.Mvc;
using NzWalksApi.Domain;

namespace NzWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        // GET ALL Regions
        // GET: http://localhost:port/api/region
        [HttpGet]
        /* public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
            {
                Id = Guid.NewGuid(),
                Name = "Auckland Region",
                Code = "AKL",
                RegionImageUrl = "https://en.wikipedia.org/wiki/Auckland_Region",
            },
            new Region
            {
                Id = Guid.NewGuid(),
                Name = "Wellington Region",
                Code = "WLG",
                RegionImageUrl = "https://en.wikipedia.org/wiki/Wellington_Region",
            }
        };
            return Ok(regions);
        }*/
    }
}
