using Microsoft.AspNetCore.Mvc;

namespace safaei.Components
{
    public class ShowGroupInMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Views/Components/ShowGroupInMenu.cshtml");
        }
    }
}
