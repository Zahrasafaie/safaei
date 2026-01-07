using Microsoft.AspNetCore.Mvc;

namespace safaei.Components
{
    public class Slider : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Views/Components/Slider.cshtml");
        }
    }
}
