using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoDadosAberturaController : Controller
    {
        private readonly IHistoricoDadosAberturaDal _HistoricoDadosAberturaDal;

        public HistoricoDadosAberturaController(IHistoricoDadosAberturaDal HistoricoDadosAberturaDal)
        {
            _HistoricoDadosAberturaDal = HistoricoDadosAberturaDal;
        }

        // GET historicoDadosAbertura/dadosAbertura/idManifestacao
        [HttpGet("dadosAbertura/{idManifestacao}")]
        public async Task<IActionResult> Get(int idManifestacao)
        {
           return Ok(await _HistoricoDadosAberturaDal.Read().Where(x=> x.IdManifestacao == idManifestacao).ToListAsync());
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
