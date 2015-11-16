using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LyuAdmin.Users;
using LyuAdmin.Users.Dto;

namespace LyuAdmin.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserAppService _userAppService;

        public HomeController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Edit(long? id)
        {
            UserDto model;
            if (id.HasValue)
                model = await _userAppService.GetUser(id.Value);
            else
                model = new UserDto();

            return PartialView(model);
        }
    }
}