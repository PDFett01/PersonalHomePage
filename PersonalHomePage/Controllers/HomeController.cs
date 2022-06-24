using PersonalHomePage.Models;

namespace PersonalHomePage.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        MyModel message = new MyModel()
        {
            Message = "Hello World!"
        };

        return View(message);
    }
}
