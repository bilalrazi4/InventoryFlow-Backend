using InventoryFlow.Domain.DbModels;
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
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
        }
        public void Dispose()
        {
        }
    }
}
