using Microsoft.AspNetCore.Mvc;

namespace OnlineCinema.Mvc.Controllers
{
    public class PromotionController : Controller
    {
        [Route("promo/{name}")]
        public IActionResult Promo(string name)
        {
            return View();
        }
    }
}
