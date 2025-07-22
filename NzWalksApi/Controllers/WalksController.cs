using System.Globalization;
using System.IO.MemoryMappedFiles;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalksApi.Models.Domain;
using NzWalksApi.Models.DTO;
using NzWalksApi.Repositories;

namespace NzWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalksRepository walksRepository;
        private readonly IMapper mapper;

        public WalksController(IWalksRepository walksRepository, IMapper mapper)
        {
            this.walksRepository = walksRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walks>(addWalkRequestDto);

            await walksRepository.CreateAsync(walkDomainModel);

            return Ok(mapper.Map<WalksDto>(walkDomainModel));
        }

        [HttpGet]
        public async Task<List<Walks>> GetAllAsync()
        {
            return await walksRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walksRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalksDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateAsync(Guid id, updateWalksRequestDto updateWalksRequestDto)
        {
            var walkDomainModel = mapper.Map<Walks>(updateWalksRequestDto);

            await walksRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalksDto>(walkDomainModel));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var walkDomain = await walksRepository.DeleteAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalksDto>(walkDomain));
        }

    }
}
