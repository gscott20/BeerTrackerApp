using AutoMapper;
using BeerTrackerAPI.Data;
using BeerTrackerAPI.Models.Player;

namespace BeerTrackerAPI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreatePlayerDto, Player>().ReverseMap();
            CreateMap<UpdatePlayerDto, Player>().ReverseMap();
            CreateMap<ReadOnlyPlayerDto, Player>().ReverseMap();
        }
    }
}
