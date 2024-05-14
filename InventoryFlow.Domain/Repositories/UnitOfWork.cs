using InventoryFlow.Domain.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.Repositories
{
    public class UnitOfWork<T> : IDisposable where T : class
    {
        private HfinventoryFlowContext _context;
        private GenericRepository<T> repository;

        public UnitOfWork()
        {
            _context = new HfinventoryFlowContext();
        }
        public UnitOfWork(HfinventoryFlowContext context)
        {
            _context = context;
        }
        public GenericRepository<T> Repository
        {
            get
            {
                if (repository == null)
                {
                    repository = new GenericRepository<T>(_context);
                }
                return repository;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public HfinventoryFlowContext GetDbContext()
        {
            return _context;
        }

        public void Detach(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Detached;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
        }
        public void Dispose()
        {
        }
    }
}
