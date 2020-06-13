using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ouvidoria.Repository;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Models;

namespace Ouvidoria.Controllers
{
           [Route("api/[controller]")]
    [ApiController]
    public class ResolucaoOcorrenciaController : Controller
    {
        private readonly IResolucaoOcorrenciaDal _ResolucaoOcorrenciaDal;

        public ResolucaoOcorrenciaController(IResolucaoOcorrenciaDal ResolucaoOcorrenciaDal)
        {
            _ResolucaoOcorrenciaDal = ResolucaoOcorrenciaDal;

        }

        // GET ResolucaoOcorrencia/DetalheResolucao/123
        [HttpGet("DetalheResolucao/{IdOcorrencia}")]
        public async Task<IActionResult> Get(int IdOcorrencia)
        {
            return Ok(await _ResolucaoOcorrenciaDal.Read().Where(x => x.IdOcorrencia == IdOcorrencia).ToListAsync());
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
