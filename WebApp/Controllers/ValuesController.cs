﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;
using WebApp.Models.Requests;
using WebApp.Persistence;
using WebApp.Persistence.Models;
using WebApp.Persistence.Repository;

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
        public HttpResponseMessage GetLines(HttpRequestMessage request, LinesRequest linesRequest)
        {
            try
            {
                using (var dbContext = new ApplicationDbContext())
                {
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

        // GET api/values/stations
        [HttpGet]
        [Route("Stations")]
        public HttpResponseMessage GetStations(HttpRequestMessage request, StationsRequest stationsRequest)
        {
            try
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<StationDbModel, int> repository = new Repository<StationDbModel, int>(dbContext);
                    List<StationDbModel> stationDbModels = repository.Find(st => st.StationLines.Where(l => l.Line.Number == stationsRequest.LineNumber).Any()).ToList();
                    var maps = Mapper.Map<List<Station>>(stationDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, maps);
                }
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/schedules
        [HttpGet]
        [Route("Schedules")]
        public HttpResponseMessage GetSchedules(HttpRequestMessage request, SchedulesRequest schedulesRequest)
        {
            try
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = true;
                    dbContext.Configuration.ProxyCreationEnabled = true;

                    Repository<DeparturesDbModel, int> repository = new Repository<DeparturesDbModel, int>(dbContext);
                    List<DeparturesDbModel> departuresDbModels = repository.Find(dp => dp.DayType == schedulesRequest.DayType
                                                                                 && dp.LineDbModel.Number == schedulesRequest.LineNumber).ToList();

                    var maps = Mapper.Map<List<Departure>>(departuresDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, maps);
                }
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/vehicles

        [HttpGet]
        [Route("Vehicles")]
        public HttpResponseMessage GeVehicles(HttpRequestMessage request, VehiclesRequest schedulesRequest)
        {
            try
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    Repository<VehicleDbModel, int> repository = new Repository<VehicleDbModel, int>(dbContext);
                    List<VehicleDbModel> vehicleDbModels = repository.Find(st => st.LineDbModel.Id == schedulesRequest.LineNumber).ToList();
                    var maps = Mapper.Map<List<Vehicle>>(vehicleDbModels);

                    return request.CreateResponse(System.Net.HttpStatusCode.OK, maps);
                }
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
