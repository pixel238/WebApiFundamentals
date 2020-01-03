using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.Data;
using TheCodeCamp.Models;

namespace TheCodeCamp.Controllers
{
    [RoutePrefix("api/camps")]
    public class CampsController : ApiController
    {
        private readonly ICampRepository _repostiory;
        private readonly IMapper _mapper;

        public CampsController(ICampRepository repository,IMapper mapper)
        {
            _repostiory = repository;
            _mapper = mapper;
        }
        [Route()]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repostiory.GetAllCampsAsync();

                var mappedResult = _mapper.Map<IEnumerable<CampModel>>(result);
                if (mappedResult == null)
                    return NotFound();
                return Ok(mappedResult);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{moniker}")]
        public async Task<IHttpActionResult> Get(String moniker)
        {
            try
            {
                var result = await _repostiory.GetCampAsync(moniker);
                if (result == null)
                    return NotFound();
                return Ok(_mapper.Map<CampModel>(result));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
