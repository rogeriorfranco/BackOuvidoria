using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class ParametrosSistemaDal : GenericCrud<ParametrosSistema>, IParametrosSistemaDal
    {
        public ParametrosSistemaDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
