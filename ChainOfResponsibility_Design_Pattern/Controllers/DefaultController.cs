using ChainOfResponsibility_Design_Pattern.ChainOfResponsibility;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResponsibility_Design_Pattern.Controllers
{
    public class DefaultController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(WithDraw p)
        {
            Employee treasurer = new Treasurer();
            Employee manager = new Manager();
            Employee director = new Director();
            Employee areaDirector = new AreaDirector();

            treasurer.SetNextApprover(manager);
            manager.SetNextApprover(director);
            director.SetNextApprover(areaDirector);

            treasurer.ProcessRequest(p);
            return View();
        }
    }
}
