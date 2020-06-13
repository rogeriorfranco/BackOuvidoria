using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Controllers
{
           [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaController : Controller
    {
        private readonly IOcorrenciaDal _OcorrenciaDal;

        public OcorrenciaController(IOcorrenciaDal OcorrenciaDal)
        {
            _OcorrenciaDal = OcorrenciaDal;

        }

        // GET listaOcorrencias?IdCliente=9378511&Id=1&DtAberturaInicial=2018-10-26&DtAberturaFinal=2018-10-26
        [HttpGet("listaOcorrencias")]
        public async Task<IActionResult> Get([FromQuery] int IdCliente)
        {
            return Ok(await _OcorrenciaDal.Read().Where(x => x.IdCliente == IdCliente).OrderBy(x=> x.DtAbertura).ToListAsync());
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
