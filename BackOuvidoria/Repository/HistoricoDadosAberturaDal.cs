using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class HistoricoDadosAberturaDal : GenericCrud<HistoricoDadosAbertura>, IHistoricoDadosAberturaDal
    {
        public HistoricoDadosAberturaDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
