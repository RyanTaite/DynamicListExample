using DynamicListExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicListExample.Controllers
{
    public class ParentController : Controller
    {
        public IActionResult GetChildPartialView()
        {
            // If this is throwing an error saying it can't resolve _ChildPartialView you can ignore it, works fine. Not present in VS2019 Version 16.4.5
            return PartialView("_ChildPartialView", new Child());
        }
    }
}