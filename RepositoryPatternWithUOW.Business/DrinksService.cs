using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Business
{
    public class DrinksService : IDrinksService
    {
        private readonly IDrinkRepository _drinksRepository;
        public DrinksService(IDrinkRepository DrinksRepository) => _drinksRepository = DrinksRepository;
        public IEnumerable<Drink> GetAll()
        {
            return _drinksRepository.GetAll();
        }

        public Drink GetById(int id) => _drinksRepository.GetById(id);

        public void Add(Drink Product)
        {
            _drinksRepository.Add(Product);
        }

        public void Update(Drink product)
        {
            _drinksRepository.Update(product);

        }

        public void Delete(Drink product)
        {
            _drinksRepository.Delete(product);
        }
        public int GetDrinkPrice(int id)
        {
            Drink drink = _drinksRepository.GetAll().First(e => e.Id == id);
            return (int)drink.Price;
        }
        public void DrinkSall(int id)
        {
            Drink drink = _drinksRepository.GetAll().First(e => e.Id == id);
             drink.Quantity -= 1;
            _drinksRepository.Update(drink);
        }
        
       
    }
}
