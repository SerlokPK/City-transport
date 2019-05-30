using AutoMapper;
using System.Collections.Generic;
using System.Linq;
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
        [Route("Lines")]
        public IEnumerable<Line> GetLines(LinesRequest linesRequest)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Repository<LineDbModel, int> repository = new Repository<LineDbModel, int>(dbContext);
                List<LineDbModel> lineDbModels = repository.Find(l => l.LineType == linesRequest.LineType).ToList();
                return Mapper.Map<List<Line>>(lineDbModels);
            }
        }

        // GET api/values/stations
        [Route("Stations")]
        public IEnumerable<Station> GetStations()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Repository<StationDbModel, int> repository = new Repository<StationDbModel, int>(dbContext);
                List<StationDbModel> stationDbModel = repository.GetAll().ToList();
                return Mapper.Map<List<Station>>(stationDbModel);
            }
        }

        // GET api/values/schedules
        [Route("Schedules")]
        public IEnumerable<Departure> GetSchedules(SchedulesRequest schedulesRequest)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Repository<DeparturesDbModel, int> repository = new Repository<DeparturesDbModel, int>(dbContext);
                List<DeparturesDbModel> departuresDbModels = repository.Find(dp => dp.DayType == schedulesRequest.DayType
                                                                             && dp.LineDbModel.Number == schedulesRequest.LineNumber).ToList();
                var maps = Mapper.Map<List<Departure>>(departuresDbModels);
                return maps;
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
