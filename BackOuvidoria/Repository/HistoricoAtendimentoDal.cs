using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class HistoricoAtendimentoDal : GenericCrud<HistoricoAtendimento>, IHistoricoAtendimentoDal
    {
        public HistoricoAtendimentoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
