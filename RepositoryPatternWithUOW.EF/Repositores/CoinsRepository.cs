using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositores
{
    public class CoinsRepository : BaseRepository<Coins>, ICoinsRepository
    {
        public CoinsRepository(AppDbContext context) : base(context)
        {
        }
       
        public void Block(int Id)
        {
            if (_Context.Coins.Find(Id).IsFull != true)
                _Context.Coins.Find(Id).IsFull = true;

            else if (_Context.Coins.Find(Id).IsFull = true)
            {
                _Context.Coins.Find(Id).IsFull = false;
            }

            _Context.SaveChanges();
        }
     
    }
}
