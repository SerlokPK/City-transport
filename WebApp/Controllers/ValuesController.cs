﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Models.Requests.Get;
using WebApp.Models.Requests.Post;
using WebApp.Persistence;
using WebApp.Persistence.Models;
using WebApp.Persistence.Repository;

namespace WebApp.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        public ValuesController()
        {
        }

        // GET api/values/lines
        [HttpGet]
        [Route("Lines")]
        public HttpResponseMessage GetLines(HttpRequestMessage request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<LineDbModel, int> repository = new Repository<LineDbModel, int>(dbContext);
                    List<LineDbModel> lineDbModels = repository.GetAll().OrderBy(x => x.Number).ToList();
                    var maps = Mapper.Map<List<Line>>(lineDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, maps);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/lines/{lineType}
        [HttpGet]
        [Route("Lines/{lineType}")]
        public HttpResponseMessage GetSpecificLines(HttpRequestMessage request, [FromUri]GetLinesRequest linesRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    dbContext.Configuration.ProxyCreationEnabled = false;

                    Repository<LineDbModel, int> repository = new Repository<LineDbModel, int>(dbContext);
                    List<LineDbModel> lineDbModels = repository.Find(l => l.LineType == linesRequest.LineType).ToList();
                    var maps = Mapper.Map<List<Line>>(lineDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, maps);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/stations
        [HttpGet]
        [Route("Stations")]
        public HttpResponseMessage GetStations(HttpRequestMessage request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<StationDbModel, int> repository = new Repository<StationDbModel, int>(dbContext);
                    List<StationDbModel> stationDbModels = repository.GetAll().ToList();
                    var stations = Mapper.Map<List<Station>>(stationDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, stations);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/stations
        [HttpGet]
        [Route("Stations/{lineNumber}")]
        public HttpResponseMessage GetSepcificStations(HttpRequestMessage request, [FromUri]GetStationsRequest stationsRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<StationDbModel, int> repository = new Repository<StationDbModel, int>(dbContext);
                    List<StationDbModel> stationDbModels = repository.Find(st => st.StationLines.Where(l => l.Line.Number == stationsRequest.LineNumber).Any()).ToList();
                    var stations = Mapper.Map<List<Station>>(stationDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, stations);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/schedules
        [HttpGet]
        [Route("Schedules/{lineNumber}/{dayType}")]
        public HttpResponseMessage GetSpecificSchedules(HttpRequestMessage request, [FromUri]GetSchedulesRequest schedulesRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = true;
                    dbContext.Configuration.ProxyCreationEnabled = true;

                    Repository<DepartureDbModel, int> repository = new Repository<DepartureDbModel, int>(dbContext);
                    List<DepartureDbModel> departuresDbModels = repository.Find(dp => dp.DayType == schedulesRequest.DayType
                                                                                 && dp.LineDbModel.Number == schedulesRequest.LineNumber).ToList();

                    var departures = Mapper.Map<List<Departure>>(departuresDbModels);
                    var departureWrapper = new DepartureWrapper()
                    {
                        DirectionA = departures.Where(d => d.Direction == Direction.A).OrderBy(dep => dep.DeparturesAt).ToList(),
                        DirectionB = departures.Where(d => d.Direction == Direction.B).OrderBy(dep => dep.DeparturesAt).ToList(),
                    };

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, departureWrapper);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/vehicles
        [HttpGet]
        [Route("Vehicles/{LineNumber}")]
        public HttpResponseMessage GeSpecificVehicles(HttpRequestMessage request, [FromUri]GetVehiclesRequest schedulesRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<VehicleDbModel, int> repository = new Repository<VehicleDbModel, int>(dbContext);
                    List<VehicleDbModel> vehicleDbModels = repository.Find(st => st.LineDbModel.Id == schedulesRequest.LineNumber).ToList();
                    var vehicles = Mapper.Map<List<Vehicle>>(vehicleDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, vehicles);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/price
        [HttpGet]
        [Route("Price/{PassengerType}/{TicketType}")]
        public HttpResponseMessage GetSpecificPrice(HttpRequestMessage request, [FromUri]GetPriceRequest schedulesRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<PriceDbModel, int> repository = new Repository<PriceDbModel, int>(dbContext);
                    PriceDbModel priceDbModel = repository.Find(st => st.TicketType == schedulesRequest.TicketType
                                                                            && st.PassengerType == schedulesRequest.PassengerType).First();

                    var price = Mapper.Map<Price>(priceDbModel);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, price);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
