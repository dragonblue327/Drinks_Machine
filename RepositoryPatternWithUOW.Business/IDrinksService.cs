using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Business
{
    public interface IDrinksService
    {
        IEnumerable<Drink> GetAll();
        Drink GetById(int id);
        void Add(Drink Product);
        void Update(Drink product); 
        void Delete(Drink Product);
        int GetDrinkPrice(int id);
        void DrinkSall(int id);
    }

}