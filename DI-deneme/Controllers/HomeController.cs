using DI_deneme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DI_deneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingleton singleton;
        private readonly IScoped scoped;
        private readonly ITransient transient;
        private readonly ISingleton _singleton;
        private readonly IScoped _scoped;
        private readonly ITransient _transient;

        public HomeController(ILogger<HomeController> logger, ISingleton singleton, IScoped scoped, ITransient transient, ISingleton singleton2, IScoped scoped2, ITransient transient2)
        {
            _logger = logger;
            this.singleton = singleton;
            this.scoped = scoped;
            this.transient = transient;
            _singleton = singleton2;
            _scoped = scoped2;
            _transient = transient2;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = singleton.Guid;

            ViewBag.Singleton2 = _singleton.Guid;

            ViewBag.Scoped = scoped.Guid;

            ViewBag.Scoped2 = _scoped.Guid;

            ViewBag.Transient = transient.Guid;

            ViewBag.Transient2 = _transient.Guid;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class Singleton : ISingleton
    {
        public Guid Guid { get; set; }

        public Singleton()
        {
            Guid = Guid.NewGuid();
        }
    }
    public class Scoped : IScoped
    {
        public Guid Guid { get; set; }

        public Scoped()
        {
            Guid = Guid.NewGuid();
        }
    }
    public class Transient : ITransient
    {
        public Guid Guid { get; set; }

        public Transient()
        {
            Guid = Guid.NewGuid();
        }
    }
}
