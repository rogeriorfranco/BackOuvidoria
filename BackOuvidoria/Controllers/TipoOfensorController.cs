﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoOfensorController : Controller
    {
        private readonly IPendenteFilaEncaminhamentoDal _TipoOfensor;

        public TipoOfensorController(IPendenteFilaEncaminhamentoDal TipoOfensor)
        {
            _TipoOfensor = TipoOfensor;
        }

        // GET TipoOfensor
        [HttpGet("lista")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _TipoOfensor.Read().Where(x => x.Status == true).ToListAsync());
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
