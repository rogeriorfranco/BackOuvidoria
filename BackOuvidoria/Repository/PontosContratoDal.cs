using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class PontosContratoDal : GenericCrud<PontosContrato>, IPontosContratoDal
    {
        public PontosContratoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
