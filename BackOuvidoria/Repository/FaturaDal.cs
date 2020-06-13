using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class FaturaDal : GenericCrud<Fatura>, IFaturaDal
    {
        public FaturaDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
