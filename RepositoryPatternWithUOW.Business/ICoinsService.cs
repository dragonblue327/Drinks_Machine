using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Business
{
    public interface ICoinsService
    {
        IEnumerable<int> Exchange(int amount);
        void amount(int cont);
        IEnumerable<Coins> GetAll();
        int GetCount();
        Coins GetById(int id);
        void Block(int Id);
        void fULL();
        void Update(Coins coin);
        void Add(Coins coin);
        void Delete(Coins coin);
    }
}