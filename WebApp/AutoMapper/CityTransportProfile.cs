﻿using AutoMapper;
using WebApp.Models;
using WebApp.Models.Requests.Post;
using WebApp.Persistence.Models;
using static WebApp.AutoMapper.AutoMapperResolver;

namespace WebApp.AutoMapper
{
    public class CityTransportProfile : Profile
    {
        public CityTransportProfile()
        {
            #region Get
            CreateMap<StationDbModel, Station>()
                .ForMember(dest => dest.Lines, opts => opts.MapFrom(src => ResolveStationLinesToLines(src.StationLines)));

            CreateMap<LineDbModel, Line>()
                .ForMember(dest => dest.Stations, opts => opts.MapFrom(src => ResolveStationLinesToStations(src.StationLines)))
                .ForMember(dest => dest.Departures, opts => opts.MapFrom(src => ""));

            CreateMap<DepartureDbModel, Departure>()
                .ForMember(dest => dest.DeparturesAt, opts => opts.MapFrom(src => src.Time.ToString("HH:mm")))
                .ForMember(dest => dest.Line, opts => opts.MapFrom(src => Mapper.Map<Line>(src.LineDbModel)));

            CreateMap<VehicleDbModel, Vehicle>()
                .ForMember(dest => dest.Line, opts => opts.MapFrom(src => Mapper.Map<Line>(src.LineDbModel)));

            CreateMap<PriceDbModel, Price>();
            #endregion

            #region Post
            CreateMap<PostLineRequest, LineDbModel>()
                .ForMember(dest => dest.Departures, opts => opts.Ignore())
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.StartLocation + "-" + src.EndLocation));

            CreateMap<PostStationRequest, StationDbModel>();

            CreateMap<PostPriceRequest, PriceDbModel>();
            #endregion
        }
    }
}