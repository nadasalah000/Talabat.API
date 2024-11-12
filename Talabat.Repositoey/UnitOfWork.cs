using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;
using Talabat.Repositoey.Data;

namespace Talabat.Repositoey
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _dbContext;
        private Hashtable _repositoires;
        public UnitOfWork(StoreContext dbContext)
        {
            _repositoires = new Hashtable();
            this._dbContext = dbContext;
        }
        public async Task<int> CompleteAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        => _dbContext.DisposeAsync();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var Type = typeof(TEntity).Name;
            if(!_repositoires.ContainsKey(Type))
            {
                var Repository = new GenericRepository<TEntity>(_dbContext);
                _repositoires.Add(Type, Repository);
            }
            return _repositoires[Type] as IGenericRepository<TEntity>;  
        }
    }
}
