using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Business;
using RepositoryPatternWithUOW.Core.Models;

namespace Web_App.Api.Controllers
{
    public class CashRegisterController : Controller
    {

        private readonly ICoinsService _coinsService;
        public CashRegisterController(ICoinsService coinsService) => _coinsService = coinsService;
      
        public IActionResult Index()
        {
            var coins = _coinsService.GetAll();
            var count =  _coinsService.GetCount();
            ViewBag.tootal = count;
            return View("Index", coins);
        }
        public IActionResult Block(int Id)
        {
            this._coinsService.Block(Id);

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Coins coin = _coinsService.GetById(id);
            return View("Add", coin);
        }
        [HttpPost]
        public IActionResult Update(Coins coin_)
        {
            this._coinsService.Update(coin_);
            return RedirectToAction("Index");

        }
        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        public IActionResult Add(Coins coin_)
        {
            _coinsService.Add(coin_);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int Id)
        {
            var coin = _coinsService.GetById(Id);
            this._coinsService.Delete(coin);
            return RedirectToAction("Index");
        }
        public IActionResult Default()
        {
            _coinsService.fULL();
            return RedirectToAction("Index");
        }
    }
}
