using Microsoft.AspNetCore.Mvc;

namespace safaei.Components
{
    public class TopNews : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Views/Components/TopNews.cshtml");
        }
    }
}
