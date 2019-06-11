using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;
using WebApp.Models.Requests.Get;
using WebApp.Models.Requests.Post;
using WebApp.Persistence;
using WebApp.Persistence.Models;
using WebApp.Persistence.Repository;
using static WebApp.AutoMapper.AutoMapperResolver;

namespace WebApp.Controllers
{
    //[Authorize]
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
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<LineDbModel, int> repository = new Repository<LineDbModel, int>(dbContext);
                    List<LineDbModel> lineDbModels = repository.GetAll().OrderBy(x => x.Number).ToList();
                    var maps = Mapper.Map<List<Line>>(lineDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, maps);
                }
            }
            catch (Exception e)
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
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
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
            catch (Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // POST api/values/lines
        [HttpPost]
        [Route("Lines")]
        public HttpResponseMessage PostLine(HttpRequestMessage request, PostLineRequest lineRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    dbContext.Configuration.ProxyCreationEnabled = false;

                    Repository<LineDbModel, int> linesRepository = new Repository<LineDbModel, int>(dbContext);
                    Repository<StationDbModel, int> stationsRepository = new Repository<StationDbModel, int>(dbContext);
                    Repository<StationLineDbModel, int> stationLineRepository = new Repository<StationLineDbModel, int>(dbContext);
                    Repository<DepartureDbModel, int> departuresRepository = new Repository<DepartureDbModel, int>(dbContext);

                    var lineDbModel = Mapper.Map<LineDbModel>(lineRequest);
                    var departures = ResolveDeparturePostRequestToDepartureDbModel(lineRequest.Departures, lineDbModel);
                    foreach (var stationId in lineRequest.Stations)
                    {
                        var stationDbModel = stationsRepository.Get(stationId);
                        stationLineRepository.Add(new StationLineDbModel()
                        {
                            Line = lineDbModel,
                            Station = stationDbModel
                        });
                    }

                    departuresRepository.AddRange(departures);
                    dbContext.SaveChanges();

                    var lineId = linesRepository.Find(line => line.Number == lineDbModel.Number).First().Id;
                    return request.CreateResponse(System.Net.HttpStatusCode.OK, lineId);
                }
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/values/lines
        [HttpPut]
        [Route("Lines")]
        public HttpResponseMessage PutLine(HttpRequestMessage request, LineDbModel lineRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<LineDbModel, int> linesRepository = new Repository<LineDbModel, int>(dbContext);
                    linesRepository.Update(lineRequest);

                    dbContext.SaveChanges();
                    return request.CreateResponse(System.Net.HttpStatusCode.OK, lineRequest);
                }
            }
            catch (Exception e)
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
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<StationDbModel, int> repository = new Repository<StationDbModel, int>(dbContext);
                    List<StationDbModel> stationDbModels = repository.GetAll().ToList();
                    var stations = Mapper.Map<List<Station>>(stationDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, stations);
                }
            }
            catch (Exception e)
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
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<StationDbModel, int> repository = new Repository<StationDbModel, int>(dbContext);
                    List<StationDbModel> stationDbModels = repository.Find(st => st.StationLines.Where(l => l.Line.Number == stationsRequest.LineNumber).Any()).ToList();
                    var stations = Mapper.Map<List<Station>>(stationDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, stations);
                }
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // POST api/values/stations
        [HttpPost]
        [Route("Stations")]
        public HttpResponseMessage PostStation(HttpRequestMessage request, PostStationRequest postStationRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<StationDbModel, int> stationsRepository = new Repository<StationDbModel, int>(dbContext);
                    Repository<LineDbModel, int> linesRepository = new Repository<LineDbModel, int>(dbContext);
                    Repository<StationLineDbModel, int> stationLineRepository = new Repository<StationLineDbModel, int>(dbContext);
                    Repository<DepartureDbModel, int> departuresRepository = new Repository<DepartureDbModel, int>(dbContext);

                    var stationDbModel = Mapper.Map<StationDbModel>(postStationRequest);

                    foreach (var lineId in postStationRequest.LineIds)
                    {
                        var lineDbModel = linesRepository.Get(lineId);
                        stationLineRepository.Add(new StationLineDbModel()
                        {
                            Line = lineDbModel,
                            Station = stationDbModel
                        });
                    }

                    dbContext.SaveChanges();
                    var stationid = stationsRepository.Find(station => station.Address == postStationRequest.Address).First().Id;
                    return request.CreateResponse(System.Net.HttpStatusCode.OK, stationid);
                }
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // POST api/values/stations
        [HttpPut]
        [Route("Stations")]
        public HttpResponseMessage PutStation(HttpRequestMessage request, StationDbModel stationDbModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<StationDbModel, int> stationRepository = new Repository<StationDbModel, int>(dbContext);
                    stationRepository.Update(stationDbModel);

                    dbContext.SaveChanges();
                    return request.CreateResponse(System.Net.HttpStatusCode.OK, stationDbModel);
                }
            }
            catch (Exception e)
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
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
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
                        DirectionA = departures.Where(d => d.Direction == Direction.A).ToList(),
                        DirectionB = departures.Where(d => d.Direction == Direction.B).ToList(),
                    };

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, departureWrapper);
                }
            }
            catch (Exception e)
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
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<VehicleDbModel, int> repository = new Repository<VehicleDbModel, int>(dbContext);
                    List<VehicleDbModel> vehicleDbModels = repository.Find(st => st.LineDbModel.Id == schedulesRequest.LineNumber).ToList();
                    var vehicles = Mapper.Map<List<Vehicle>>(vehicleDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, vehicles);
                }
            }
            catch (Exception e)
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
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
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
            catch (Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("Price")]
        public HttpResponseMessage PostPrice(HttpRequestMessage request, PostPriceRequest postPriceRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<PriceDbModel, int> repository = new Repository<PriceDbModel, int>(dbContext);
                    var priceDbModel = Mapper.Map<PriceDbModel>(postPriceRequest);
                    repository.Add(priceDbModel);
                    dbContext.SaveChanges();

                    return request.CreateResponse(System.Net.HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [Route("Price")]
        public HttpResponseMessage PutPrice(HttpRequestMessage request, PriceDbModel priceDbModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, GetErrorMessage());
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<PriceDbModel, int> repository = new Repository<PriceDbModel, int>(dbContext);
                    repository.Update(priceDbModel);
                    dbContext.SaveChanges();

                    return request.CreateResponse(System.Net.HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        private Error GetErrorMessage()
        {
            var errorMessage = ModelState.Values.ToList()[0].Errors.FirstOrDefault(e => e.ErrorMessage != "")?.ErrorMessage;
            return new Error()
            {
                ErrorMessage = errorMessage ?? "Bad request."
            };
        }
    }
}
