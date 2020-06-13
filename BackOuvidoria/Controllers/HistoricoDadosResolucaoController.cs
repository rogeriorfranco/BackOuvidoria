using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ouvidoria.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Ouvidoria.Controllers
{
           [Route("api/[controller]")]
    [ApiController]
    public class HistoricoDadosResolucaoController : Controller
    {
        private readonly IHistoricoDadosResolucaoDal _HistoricoDadosResolucaoDal;

        public HistoricoDadosResolucaoController(IHistoricoDadosResolucaoDal HistoricoDadosResolucaoDal)
        {
            _HistoricoDadosResolucaoDal = HistoricoDadosResolucaoDal;
        }

        // GET historicoDadosResolucao/dadosResolucao/idManifestacao
        [HttpGet("dadosResolucao/{idManifestacao}")]
        public async Task<IActionResult> Get(int idManifestacao)
        {
           return Ok(await _HistoricoDadosResolucaoDal.Read().Where(x=> x.IdManifestacao == idManifestacao).ToListAsync());
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
