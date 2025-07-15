using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalksApi.Data;
using NzWalksApi.Models.Domain;
using NzWalksApi.Models.DTO;


namespace NzWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly NzWalksDbContext dbContext;

        public RegionsController(NzWalksDbContext dbContext) // Constructor Injection
        {
            this.dbContext = dbContext;
        }

        // GET ALL Regions Uing Db context class
        // GET: http://localhost:port/api/region
        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var regionsDomain = await dbContext.Regions.ToListAsync();

            // Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var region in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            // Return DTOs
            return Ok(regionsDto);
        }

        // GET Region By Id
        // GET: http://localhost:port/api/region/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionsDomain = await dbContext.Regions.FindAsync(id);
            if (regionsDomain == null)
            {
                return NotFound();
            }
            else
            {
                // Map Domain Models to DTOs
                var regionsDto = new RegionDto
                {
                    Id = regionsDomain.Id,
                    Code = regionsDomain.Code,
                    Name = regionsDomain.Name,
                    RegionImageUrl = regionsDomain.RegionImageUrl
                };
                // Return DTO back to client
                return Ok(regionsDto);
            }
        }

        /*
            POST: Create New Region
        */
        [HttpPost]
        public async Task<IActionResult> Create(addRegionRequestDTO addRegionRequestDTO)
        {
            var regionsDomainModel = new Region
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            };

            await dbContext.Regions.AddAsync(regionsDomainModel);
            await dbContext.SaveChangesAsync();
            var regionsDto = new RegionDto
            {
                Id = regionsDomainModel.Id,
                Code = regionsDomainModel.Code,
                Name = regionsDomainModel.Name,
                RegionImageUrl = regionsDomainModel.RegionImageUrl
            };


            return CreatedAtAction(nameof(GetById), new { id = regionsDto.Id }, regionsDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, updateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionsDomain = await dbContext.Regions.FindAsync(id);
            if (regionsDomain == null)
            {
                return NotFound();
            }

            regionsDomain.Code = updateRegionRequestDTO.Code;
            regionsDomain.Name = updateRegionRequestDTO.Name;
            regionsDomain.RegionImageUrl = updateRegionRequestDTO.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            var regionsDto = new RegionDto
            {
                Id = regionsDomain.Id,
                Code = regionsDomain.Code,
                Name = regionsDomain.Name,
                RegionImageUrl = regionsDomain.RegionImageUrl
            };

            return Ok(regionsDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionsDomain = await dbContext.Regions.FindAsync(id);
            if (regionsDomain == null)
            {
                return NotFound();
            }

            dbContext.Regions.Remove(regionsDomain);
            await dbContext.SaveChangesAsync();

            var regionsDto = new RegionDto
            {
                Id = regionsDomain.Id,
                Code = regionsDomain.Code,
                Name = regionsDomain.Name,
                RegionImageUrl = regionsDomain.RegionImageUrl
            };

            return Ok(regionsDto);
        }
    }
}
