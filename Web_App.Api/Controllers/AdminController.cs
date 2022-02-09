using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Business;
using RepositoryPatternWithUOW.Core.Models;
using Web_App.Api.Controllers;
namespace Web_App.Api.Controllers
{
    public class AdminController : Controller
    {
       
        public IActionResult Index()
        {
            return View("Admin_Page");
        }
     

    }
}
