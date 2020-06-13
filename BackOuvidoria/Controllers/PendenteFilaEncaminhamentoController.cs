using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendenteFilaEncaminhamentoController : Controller
    {
        private readonly IPendenteFilaEncaminhamentoDal _PendenteFilaEncaminhamento;

        public PendenteFilaEncaminhamentoController(IPendenteFilaEncaminhamentoDal PendenteFilaEncaminhamento)
        {
            _PendenteFilaEncaminhamento = PendenteFilaEncaminhamento;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _PendenteFilaEncaminhamento.Read().Where(x => x.Status == true).ToListAsync());
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
