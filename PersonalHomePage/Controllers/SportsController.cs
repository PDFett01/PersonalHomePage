namespace PersonalHomePage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportsController : Controller
    {
        [HttpGet]
        public string GetScore() 
        {
            return "5";
        }
    }
}
