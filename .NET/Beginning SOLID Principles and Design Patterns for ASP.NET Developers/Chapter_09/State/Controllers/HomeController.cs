﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Net.Http.Headers;
using System.IO;
using State.Core;

using Microsoft.Extensions.Caching.Memory;


namespace State.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache cache;

        public HomeController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public IActionResult Index()
        {
            ICampaignState initialState = new CreateState();
            CampaignContext context = new CampaignContext(initialState);
            cache.Set("context", context);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Campaign obj)
        {
            CampaignContext context = cache.Get<CampaignContext>("context");
            context.Campaign = obj;
            context.Process();
            return View("Approve", obj);
        }

        [HttpPost]
        public IActionResult Approve()
        {
            CampaignContext context = cache.Get<CampaignContext>("context");
            context.Process();
            return View("Prepare", context.Campaign);
        }

        [HttpPost]
        public IActionResult Prepare()
        {
            CampaignContext context = cache.Get<CampaignContext>("context");
            context.Process();
            return View("Run", context.Campaign);
        }

        [HttpPost]
        public IActionResult Run()
        {
            CampaignContext context = cache.Get<CampaignContext>("context");
            context.Process();
            return View("Index", context.Campaign);
        }
    }

}
