﻿using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public class HistoricoContatoDal : GenericCrud<HistoricoContato>, IHistoricoContatoDal
    {
        public HistoricoContatoDal(OuvidoriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
