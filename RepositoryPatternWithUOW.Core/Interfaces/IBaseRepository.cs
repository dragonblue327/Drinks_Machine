using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T>where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T Product);
        T Update(T product);
        void Delete(T product);
    }
}
