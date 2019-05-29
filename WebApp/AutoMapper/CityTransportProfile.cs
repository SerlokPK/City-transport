using AutoMapper;
using WebApp.Models;
using WebApp.Persistence.Models;
using static WebApp.AutoMapper.AutoMapperResolver;

namespace WebApp.AutoMapper
{
    public class CityTransportProfile : Profile
    {
        public CityTransportProfile()
        {
            CreateMap<StationDbModel, Station>()
                .ForMember(dest => dest.Lines, opts => opts.MapFrom(s => ResloveStationLinesToLines(s.StationLines)));

            CreateMap<LineDbModel, Line>()
                .ForMember(dest => dest.Stations, opts => opts.MapFrom(s => ResloveStationLinesToStations(s.StationLines)));
        }
    }
}