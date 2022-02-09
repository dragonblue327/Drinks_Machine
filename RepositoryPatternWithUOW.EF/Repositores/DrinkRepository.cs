using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositores
{
    public class DrinkRepository : BaseRepository<Drink>, IDrinkRepository
    {
        public DrinkRepository(AppDbContext context) : base(context)
        {
        }

    }
}
