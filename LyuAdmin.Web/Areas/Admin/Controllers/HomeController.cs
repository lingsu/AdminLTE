using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LyuAdmin.Roles;
using LyuAdmin.Users;
using LyuAdmin.Users.Dto;

namespace LyuAdmin.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly IRoleAppService _roleAppService;

        public HomeController(IUserAppService userAppService, IRoleAppService roleAppService)
        {
            _userAppService = userAppService;
            _roleAppService = roleAppService;
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

            var roles = await _roleAppService.GetRoleList();
           // ViewBag.roles = new SelectItem
            return PartialView(model);
        }
    }
}