using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApp.Models;
using WebApp.Persistence;
using WebApp.Persistence.Models;
using WebApp.Persistence.Repository;

namespace WebApp.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        public ValuesController()
        {
        }

        // GET api/values
        public IEnumerable<Station> Get()
        {
            List<Station> retVal = new List<Station>();

            using (var dbContext = new ApplicationDbContext())
            {
                Repository<StationDbModel, int> repository = new Repository<StationDbModel, int>(dbContext);
                List<StationDbModel> stationDbModels = repository.GetAll().ToList();

                foreach (var stationDbModel in stationDbModels)
                {
                    var station = new Station()
                    {
                        Name = stationDbModel.Name,
                        Address = stationDbModel.Address,
                        X = stationDbModel.X,
                        Y = stationDbModel.Y,
                        Lines = new List<Line>()
                    };

                    var lineDbModels = stationDbModel.StationLines.ToList();
                    foreach (var lineDbModel in lineDbModels)
                    {
                        var line = new Line()
                        {
                            Number = lineDbModel.Line.Number,
                            Stations = new List<Station>(),
                        };

                        foreach (var lineStation in lineDbModel.Line.StationLines)
                        {
                            line.Stations.Add(new Station()
                            {
                                Address = lineStation.Station.Address,
                                Name = lineStation.Station.Name,
                                X = lineStation.Station.X,
                                Y = lineStation.Station.Y
                            });
                        }

                        station.Lines.Add(line);
                    }

                    retVal.Add(station);
                }
            }

            return retVal;
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
