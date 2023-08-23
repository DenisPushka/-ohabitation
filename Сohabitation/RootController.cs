using Microsoft.AspNetCore.Mvc;

namespace Сohabitation
{
    public class RootController : Controller
    {
        [HttpGet("/")]
        public IActionResult Result()
        {
            return View("Index");
        }
    }
}
