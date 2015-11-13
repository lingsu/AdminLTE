﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Localization;
using Abp.Threading;

namespace LyuAdmin.Web.Areas.Admin.Controllers
{
    public class LayoutController : AdminControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly ILocalizationManager _localizationManager;

        public LayoutController(IUserNavigationManager userNavigationManager, ILocalizationManager localizationManager)
        {
            _userNavigationManager = userNavigationManager;
            _localizationManager = localizationManager;
        }


        [ChildActionOnly]
        public PartialViewResult LeftMenu()
        {
            //var model = new TopMenuViewModel
            //{
            //    MainMenu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("MainMenu", AbpSession.UserId)),
            //    ActiveMenuItemName = activeMenu
            //};

            return PartialView("_LeftMenu");
        }

        [ChildActionOnly]
        public PartialViewResult LanguageSelection()
        {
            //var model = new LanguageSelectionViewModel
            //{
            //    CurrentLanguage = _localizationManager.CurrentLanguage,
            //    Languages = _localizationManager.GetAllLanguages()
            //};

            return PartialView("_LanguageSelection");
        }

    }
}