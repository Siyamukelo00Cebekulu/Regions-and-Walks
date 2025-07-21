using AutoMapper;
using NzWalksApi.Models.Domain;
using NzWalksApi.Models.DTO;

namespace NzWalksApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Walks, WalksDto>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walks>().ReverseMap();
        }
    }
}