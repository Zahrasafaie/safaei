using Microsoft.AspNetCore.Mvc;

namespace safaei.Components
{
    public class LastNews : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Views/Components/LastNews.cshtml");
        }
    }
}
