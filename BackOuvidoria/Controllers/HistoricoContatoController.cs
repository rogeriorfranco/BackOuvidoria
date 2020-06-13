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
    public class HistoricoContatoController : Controller
    {
        private readonly IHistoricoContatoDal _HistoricoContatoDal;

        public HistoricoContatoController(IHistoricoContatoDal HistoricoContatoDal)
        {
            _HistoricoContatoDal = HistoricoContatoDal;
        }

        // GET historicoContato/dadosContato/idManifestacao
        [HttpGet("dadosContato/{idManifestacao}")]
        public async Task<IActionResult> Get(int idManifestacao)
        {
           return Ok(await _HistoricoContatoDal.Read().Where(x=> x.IdManifestacao == idManifestacao).OrderByDescending(x=> x.DataTentativa).ToListAsync());
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
