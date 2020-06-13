using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class ProdutoPontoDal : GenericCrud<ProdutoPonto>, IProdutoPontoDal
    {
        public ProdutoPontoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
