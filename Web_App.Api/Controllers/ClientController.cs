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

        public IActionResult Index(int amount)
        {
            var drinks = _drinksService.GetAll();
            if (amount != 0) 
               _coinsService.amount(amount);
            return View(drinks);
        }
        
        public IActionResult Buy(int id)
        {
            var rest_ = " ";
            int price =  _drinksService.GetDrinkPrice(id);

            foreach (var d in _coinsService.Exchange(price).GroupBy(i => i))
            {
                rest_ = ( d.Key +"   "+d.Count());
            }
            _drinksService.DrinkSall(id);
            return RedirectToAction("Index", rest_);
        }
       
    }
}
