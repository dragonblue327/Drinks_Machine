using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Business;
using System.Collections;

namespace Web_App.Api.Controllers
{
    public class ClientController : Controller
    {
        private readonly IDrinksService _drinksService;

        private readonly ICoinsService _coinsService;
        public ClientController(IDrinksService drinksService, ICoinsService coinsService)
        {
            _drinksService = drinksService;
            _coinsService = coinsService;
        }

        public IActionResult Index()
        {
            var drinks = _drinksService.GetAll();
            return View(drinks);
        }

        public IActionResult Buy(int id, int amount)
        {
            var rest_ = " ";
            int price =  _drinksService.GetDrinkPrice(id);

            if (amount != 0)
                _coinsService.amount(amount);

            foreach (var d in _coinsService.Exchange(price).GroupBy(i => i))
            {
                rest_ = ( d.Key +"   "+d.Count());//exchange the rest of money 
            }
            
            _drinksService.DrinkSall(id);
            return RedirectToAction("Index");
        }
       
    }
}
