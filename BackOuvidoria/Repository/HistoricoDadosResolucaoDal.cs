using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class HistoricoDadosResolucaoDal : GenericCrud<HistoricoDadosResolucao>, IHistoricoDadosResolucaoDal
    {
        public HistoricoDadosResolucaoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
