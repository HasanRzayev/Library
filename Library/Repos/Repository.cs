using Library.Data;
using Library.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repos
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private AppDB _context;

        private DbSet<T> _dbSet;

        public Repository(AppDB context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
