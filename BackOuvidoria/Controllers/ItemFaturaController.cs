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
    public class ItemFaturaController : Controller
    {
        private readonly IItemFaturaDal _ItemFatura;

        public ItemFaturaController(IItemFaturaDal ItemFatura)
        {
            _ItemFatura = ItemFatura;

        }

        // GET detalheFatura?IdContestacaoFatura=1&item=teste
        [HttpGet("detalheFatura")]
        public async Task<IActionResult> Get([FromQuery] int IdContestacaoFatura, [FromQuery] string item)
        {
            List<ItemFatura> list = null;

            list = await _ItemFatura.Read().Where(x => x.IdFatura == IdContestacaoFatura).ToListAsync();

            if (!string.IsNullOrEmpty(item))
                list = list.Where(x => x.Item.Contains(item)).ToList();

            return Ok(list);
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
