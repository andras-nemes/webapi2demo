using RockbandData.Models.Domain;
using RockbandData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RockbandData.Controllers
{
    [EnableCors("http://localhost:51737", "*", "GET")]
    [Authorize]
    public class RockbandsController : ApiController
    {
        private IObjectContextFactory _objectContextFactory;

        public RockbandsController()
        {
            _objectContextFactory = new LazySingletonObjectContextFactory();
        }

        public IEnumerable<RockBand> Get()
        {
            return _objectContextFactory.Create().GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            RockBand rockband = _objectContextFactory.Create().GetById(id);
            if (rockband == null)
            {
                return NotFound();
            }
            return Ok<RockBand>(rockband);
        }

        [Route("api/rockbands/{id:int:min(1)}/albums")]
        public IHttpActionResult GetAlbums(int id)
        {
            RockBand rockband = _objectContextFactory.Create().GetById(id);
            if (rockband == null)
            {
                return NotFound();
            }
            return Ok<IEnumerable<Album>>(rockband.Albums);
        }
    }
}
