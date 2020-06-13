using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class StatusClienteDal : GenericCrud<StatusCliente>, IStatusClienteDal
    {
        public StatusClienteDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
