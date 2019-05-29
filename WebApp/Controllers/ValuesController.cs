using AutoMapper;
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
                var stations = Mapper.Map<List<Station>>(stationDbModels);

                retVal.AddRange(stations);
            }

            using (var dbContext = new ApplicationDbContext())
            {
                Repository<LineDbModel, int> repository = new Repository<LineDbModel, int>(dbContext);

                List<LineDbModel> lineDbModels = repository.GetAll().ToList();
                var lines = Mapper.Map<List<Line>>(lineDbModels);
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
