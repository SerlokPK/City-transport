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
                .ForMember(dest => dest.Lines, opts => opts.MapFrom(src => ResloveStationLinesToLines(src.StationLines)));

            CreateMap<LineDbModel, Line>()
                .ForMember(dest => dest.Stations, opts => opts.MapFrom(src => ResloveStationLinesToStations(src.StationLines)))
                .ForMember(dest => dest.Departures, opts => opts.MapFrom(src => ""));

            CreateMap<DeparturesDbModel, Departure>()
                .ForMember(dest => dest.DeparturesAt, opts => opts.MapFrom(src => src.Time.ToString("HH:mm")));
        }
    }
}