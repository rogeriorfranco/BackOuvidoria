using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausaEncerramentoCasoController : Controller
    {
        private readonly ICausaEncerramentoCasoDal _CausaEncerramentoCaso;

        public CausaEncerramentoCasoController(ICausaEncerramentoCasoDal CausaEncerramentoCaso)
        {
            _CausaEncerramentoCaso = CausaEncerramentoCaso;

        }

        // GET causaEncerramentoCaso/listaCausa
        [HttpGet("listaCausa/{idGrupoEncerramentoCaso}")]
        public async Task<IActionResult> Get(int idGrupoEncerramentoCaso)
        {
            return Ok(await _CausaEncerramentoCaso.Read().Where(x => x.Status == true && x.idGrupoEncerramentoCaso == idGrupoEncerramentoCaso).ToListAsync());
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
