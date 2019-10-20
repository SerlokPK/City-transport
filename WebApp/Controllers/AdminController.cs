using AutoMapper;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApp.AutoMapper;
using WebApp.Helpers;
using WebApp.Models.Requests.Post;
using WebApp.Persistence;
using WebApp.Persistence.Models;
using WebApp.Persistence.Repository;

namespace WebApp.Controllers
{
    [RoutePrefix("api/Admin")]
    [Authorize]
    public class AdminController : ApiController
    {
        // POST api/Admin/lines
        [HttpPost]
        [Route("Lines")]
        public HttpResponseMessage PostLine(HttpRequestMessage request, PostLineRequest lineRequest)
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

                    Repository<LineDbModel, int> linesRepository = new Repository<LineDbModel, int>(dbContext);
                    Repository<StationDbModel, int> stationsRepository = new Repository<StationDbModel, int>(dbContext);
                    Repository<StationLineDbModel, int> stationLineRepository = new Repository<StationLineDbModel, int>(dbContext);
                    Repository<DepartureDbModel, int> departuresRepository = new Repository<DepartureDbModel, int>(dbContext);

                    var lineDbModel = Mapper.Map<LineDbModel>(lineRequest);
                    var departures = AutoMapperResolver.ResolveDeparturePostRequestToDepartureDbModel(lineRequest.Departures, lineDbModel);
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
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/Admin/lines
        [HttpPut]
        [Route("Lines")]
        public HttpResponseMessage PutLine(HttpRequestMessage request, LineDbModel lineRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<LineDbModel, int> linesRepository = new Repository<LineDbModel, int>(dbContext);
                    linesRepository.Update(lineRequest);

                    dbContext.SaveChanges();
                    return request.CreateResponse(System.Net.HttpStatusCode.OK, lineRequest);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // POST api/admin/stations
        [HttpPost]
        [Route("Stations")]
        public HttpResponseMessage PostStation(HttpRequestMessage request, PostStationRequest postStationRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
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
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/admin/stations
        [HttpPut]
        [Route("Stations")]
        public HttpResponseMessage PutStation(HttpRequestMessage request, StationDbModel stationDbModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<StationDbModel, int> stationRepository = new Repository<StationDbModel, int>(dbContext);
                    stationRepository.Update(stationDbModel);

                    dbContext.SaveChanges();
                    return request.CreateResponse(System.Net.HttpStatusCode.OK, stationDbModel);
                }
            }
            catch (Exception)
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
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<PriceDbModel, int> repository = new Repository<PriceDbModel, int>(dbContext);
                    var priceDbModel = Mapper.Map<PriceDbModel>(postPriceRequest);
                    repository.Add(priceDbModel);
                    dbContext.SaveChanges();

                    var priceId = repository.Find(price => price.PassengerType == postPriceRequest.PassengerType && price.TicketType == postPriceRequest.TicketType).First().Id;
                    return request.CreateResponse(System.Net.HttpStatusCode.OK, priceId);
                }
            }
            catch (Exception)
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
                    return request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ErrorHelper.GetErrorMessage(ModelState));
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<PriceDbModel, int> repository = new Repository<PriceDbModel, int>(dbContext);
                    repository.Update(priceDbModel);
                    dbContext.SaveChanges();

                    return request.CreateResponse(System.Net.HttpStatusCode.OK);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
