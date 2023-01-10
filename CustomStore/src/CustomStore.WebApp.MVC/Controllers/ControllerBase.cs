using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomStore.WebApp.MVC.Controllers
{
    public class ControllerBase : Controller
    {
        // mocked client to get from claim, cookie, or other source
        protected Guid ClientId = Guid.Parse("7389626b-aa30-4651-bce0-cdb1322019ff");
    }
}
