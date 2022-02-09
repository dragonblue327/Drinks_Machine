using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositores
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AppDbContext _Context;
        public BaseRepository(AppDbContext context)
        {
            _Context=context;
        }
        public IEnumerable<T> GetAll()
        {
            return _Context.Set<T>().ToList();
        }


        public T GetById(int Id)
        {
            return _Context.Set<T>().Find(Id);
        }
        public void Add(T Product)
        {
            _Context.Set<T>().Add(Product);
            _Context.SaveChanges();
        }

        public T Update(T product)
        {
            _Context.Update(product);
            _Context.SaveChanges();
            return product;

        }
        public void Delete(T product)
        {
            _Context.Set<T>().Remove(product);
            _Context.SaveChanges();
        }

    }
}
