using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Business
{
    public class CoinsService : ICoinsService
    {

        private readonly ICoinsRepository _coinsRepository;
        public CoinsService(ICoinsRepository CoinsRepository) => _coinsRepository = CoinsRepository;

        public IEnumerable<Coins> GetAll()=> _coinsRepository.GetAll();
        public Coins GetById(int id)=> _coinsRepository.GetById(id);
        
        void ICoinsService.Block(int Id) => _coinsRepository.Block(Id);
        public void Update(Coins coin)=>_coinsRepository.Update(coin);
        public void Add(Coins coin)=> _coinsRepository.Add(coin);
        public void Delete(Coins coin)=> _coinsRepository.Delete(coin);
        public void amount(int cont)
        {
            Coins coin = _coinsRepository.GetAll().First(e => e.Coin == cont);
            if (coin.IsFull != true)
            {
                coin.Count += 1;
                _coinsRepository.Update(coin);
            }
        }
        public int GetCount()
        {
            int money = 0;
            int count ;
            var data = _coinsRepository.GetAll().ToList();
            foreach (var coin in data)
            {
                count = (coin.Coin * coin.Count);
                money += count;
            }
            return money;
        }
        public void fULL()
        {
            var data = _coinsRepository.GetAll().ToList();
            foreach (var coin in data)
            {
                if (coin.Count >= 250)
                {
                    coin.IsFull = true;
                    _coinsRepository.Update(coin);
                }
                else
                {
                    coin.IsFull = false;
                    _coinsRepository.Update(coin);
                }
            }
        }

        public IEnumerable<int> Exchange(int amount)
        {
            var data = _coinsRepository.GetAll().ToList();
            foreach (var coin in data)
            {
                if (coin.Count > 0)
                {
                    int coin_ = Convert.ToInt32(coin.Coin);
                    int[] denominations = { coin_ };
                    while (amount >= denominations.Min())
                    {
                        var denomination = denominations.Where(i => i <= amount).Max();
                        amount -= denomination;
                        yield return denomination;
                    }

                }
            }
        }
    }
}
