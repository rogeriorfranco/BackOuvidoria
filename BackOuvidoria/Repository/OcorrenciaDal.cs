using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class OcorrenciaDal : GenericCrud<Ocorrencia>, IOcorrenciaDal
    {
        public OcorrenciaDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
