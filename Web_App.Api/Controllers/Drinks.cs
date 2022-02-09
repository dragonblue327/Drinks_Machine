using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.Business;

namespace Web_App.Api.Controllers
{
    public class Drinks : Controller 
    {
        private readonly IDrinksService _drinksService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public Drinks(IDrinksService drinksService ,IWebHostEnvironment hostEnvironment )
        {
            _drinksService = drinksService;
            _hostEnvironment = hostEnvironment;
        } 

        public IActionResult Index()
        {

            var drinks = _drinksService.GetAll();
            return View(drinks);
        }

        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Drink product)
        {
                //product.=
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                product.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                using (var fs = new FileStream(path, FileMode.Create))
                {
                await product.ImageFile.CopyToAsync(fs);
                }
            
            ModelState.Remove("Drink ID");
            _drinksService.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {
           var Drink_ = _drinksService.GetById(Id);
            return View("Add", Drink_);
        }   
        [HttpPost]
        public async Task<IActionResult> Update(Drink product )
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            product.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Images/", fileName);
            using (var fs = new FileStream(path, FileMode.Create))
            {
                await product.ImageFile.CopyToAsync(fs);
            }
            this._drinksService.Update(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var Drink_ = _drinksService.GetById(Id);
            this._drinksService.Delete(Drink_);
            return RedirectToAction("Index");
        }


    }
}
