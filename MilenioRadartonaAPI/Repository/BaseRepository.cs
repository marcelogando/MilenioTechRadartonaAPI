using Microsoft.EntityFrameworkCore;
using MilenioRadartonaAPI.Context;
using MilenioRadartonaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Repository
{
    public class BaseRepository<T> where T : Base
    {
        protected readonly ApplicationContext _ctx;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<T>();
        }
    }
}
