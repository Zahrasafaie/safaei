using Microsoft.AspNetCore.Mvc;

namespace safaei.Components
{
    public class ShowGroup : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Views/Components/ShowGroup.cshtml");
        }
    }
}
