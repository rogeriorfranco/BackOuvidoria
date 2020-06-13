using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class ResolucaoOcorrenciaDal : GenericCrud<ResolucaoOcorrencia>, IResolucaoOcorrenciaDal
    {
        public ResolucaoOcorrenciaDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
