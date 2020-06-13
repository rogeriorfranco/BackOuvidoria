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
    public class HistoricoAtendimentoController : Controller
    {
        private readonly IHistoricoAtendimentoDal _HistoricoAtendimentoDal;

        public HistoricoAtendimentoController(IHistoricoAtendimentoDal HistoricoAtendimentoDal)
        {
            _HistoricoAtendimentoDal = HistoricoAtendimentoDal;
        }

        // GET HistoricoAtendimento/listaHistorico/idCliente
        [HttpGet("listaHistorico/{idCliente}")]
        public async Task<IActionResult> Get(int idCliente)
        {
            var result = await _HistoricoAtendimentoDal.Read().Where(x => x.IdCliente == idCliente).Select(
                x => new
                {
                    x.IdManifestacao,
                    x.IdAnatel,
                    x.Produto,
                    x.Area,
                    x.Canal,
                    x.Responsavel,
                    x.DataMaxima,
                    dias = (int)DateTime.Today.Subtract(x.DataMaxima).TotalDays,
                }).OrderBy(x => x.DataMaxima).ToListAsync();

            return Ok(result);
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
