﻿using AutoMapper;
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
    public class CampsController : ApiController
    {
        private readonly ICampRepository _repostiory;
        private readonly IMapper _mapper;

        public CampsController(ICampRepository repository,IMapper mapper)
        {
            _repostiory = repository;
            _mapper = mapper;
        }
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repostiory.GetAllCampsAsync();

                var mappedResult = _mapper.Map<IEnumerable<CampModel>>(result);
                return Ok(mappedResult);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
