using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalksApi.Data;
using NzWalksApi.Models.Domain;
using NzWalksApi.Models.DTO;
using NzWalksApi.Repositories;


namespace NzWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {

        private readonly NzWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NzWalksDbContext dbContext, IRegionRepository regionsRepository, IMapper mapper) // Constructor Injection
        {
            this.dbContext = dbContext;
            this.regionRepository = regionsRepository;
            this.mapper = mapper;
        }

        // GET ALL Regions Uing Db context class
        // GET: http://localhost:port/api/region
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            //var regionsDomain = await dbContext.Regions.ToListAsync();
            var regionsDomain = await regionRepository.GetAllAsync();

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
            var regionsDomain = await regionRepository.GetByIdAsync(id);

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

            regionsDomainModel = await regionRepository.CreateAsync(regionsDomainModel);

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
            // Map DTO to Domain Model
            var regionsDomainModel = new Region
            {
                Code = updateRegionRequestDTO.Code,
                Name = updateRegionRequestDTO.Name,
                RegionImageUrl = updateRegionRequestDTO.RegionImageUrl
            };

            //var regionsDomain = await dbContext.Regions.FindAsync(id);
            var regionsDomain = await regionRepository.UpdateAsync(id, regionsDomainModel);

            if (regionsDomain == null)
            {
                return NotFound();
            }


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
            var regionsDomain = await regionRepository.DeleteAsync(id);

            if (regionsDomain == null)
            {
                return NotFound();
            }

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
