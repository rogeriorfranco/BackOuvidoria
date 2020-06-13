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
    public class FaturaController : Controller
    {
        private readonly IFaturaDal _Fatura;

        public FaturaController(IFaturaDal Fatura)
        {
            _Fatura = Fatura;

        }

        // GET listaFaturas?IdCliente=9378511&DataVencimentoInicial=2018-10-26&DataVencimentoFinal=2018-10-26
        [HttpGet("listaFaturas")]
        public async Task<IActionResult> Get([FromQuery] int IdCliente)
        {
            //List<Fatura> list = null;

            //list = await _Fatura.Read().Where(x => x.IdCliente == IdCliente).ToListAsync();

            //if (DataVencimentoInicial != null)
            //    list = list.Where(x => x.DataVencimento >= DataVencimentoInicial).ToList();

            //if (DataVencimentoFinal != null)
            //    list = list.Where(x => x.DataVencimento <= DataVencimentoFinal).ToList();

            return Ok(await _Fatura.Read().Where(x => x.IdCliente == IdCliente).ToListAsync());
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
