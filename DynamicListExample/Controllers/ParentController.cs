using DynamicListExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicListExample.Controllers
{
    public class ParentController : Controller
    {
        public IActionResult GetChildPartialView()
        {
            // This is throwing an error saying it can't resolve _ChildPartialView, but it works fine
            return PartialView("_ChildPartialView", new Child());
        }
    }
}