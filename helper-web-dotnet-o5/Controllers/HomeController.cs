using helper_web_dotnet_o5.Models;
using helper_web_dotnet_o5.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Threading;

namespace helper_web_dotnet_o5.Controllers
{
    public class HomeController : Controller
    {
        private const string ENDPOINT = "https://localhost:7021/api/Grupo13YgoProDeck";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.RaceList = new SelectList(getRaceList(), "Value", "Text");

            var route = "&race=Dragon";

            var api = new HelperAPI(ENDPOINT);
            var result = api.MetodoGET<ListCard>(route).Result;

            if (result is not null)
            {
                return View(result.Data.ToList());
            }
            else
            {
                return View("IndexEmpty");
            }  
        }

        public IActionResult IndexSearch(string fname, string race)
        {
            ViewBag.RaceList = new SelectList(getRaceList(), "Value", "Text");

            var route = "";

            if (!String.IsNullOrEmpty(fname))
            {
                route += $"&fname={fname}";
            }

            if (!String.IsNullOrEmpty(race))
            {
                route += $"&race={race}";
            }

            if (route == null)
            {
                route += $"&num=100&offset=0";
            }

            var api = new HelperAPI(ENDPOINT);
            var result = api.MetodoGET<ListCard>(route).Result;

            ViewBag.FName = fname;
            ViewBag.Race = race;

            if (result is not null)
            {
                return View("Index", result.Data.ToList());
            }
            else
            {
                return View("IndexEmpty");
            }
        }

        public IActionResult Game()
        {
            var api = new HelperAPI(ENDPOINT);
            var result1 = api.MetodoGETRandom<Card>().Result;
            var result2 = api.MetodoGETRandom<Card>().Result;

            ViewBag.Result1 = result1;
            ViewBag.Result2 = result2;

            if (result1 is not null && result2 is not null)
            {
                return View();
            }
            else
            {
                return View("RandomEmpty");
            }
        }

        public List<SelectListItem> getRaceList()
        {
            List<SelectListItem> RaceList = new List<SelectListItem>();
            RaceList.Add(new SelectListItem { Value = "", Text = "Raça" });
            RaceList.Add(new SelectListItem { Value = "Aqua", Text = "Aqua" });
            RaceList.Add(new SelectListItem { Value = "Beast", Text = "Beast" });
            RaceList.Add(new SelectListItem { Value = "BeastWarrior", Text = "Beast-Warrior" });
            RaceList.Add(new SelectListItem { Value = "CreatorGod", Text = "Creator-God" });
            RaceList.Add(new SelectListItem { Value = "Cyberse", Text = "Cyberse" });
            RaceList.Add(new SelectListItem { Value = "Dinosaur", Text = "Dinosaur" });
            RaceList.Add(new SelectListItem { Value = "DivineBeast", Text = "Divine-Beast" });
            RaceList.Add(new SelectListItem { Value = "Dragon", Text = "Dragon" });
            RaceList.Add(new SelectListItem { Value = "Fairy", Text = "Fairy" });
            RaceList.Add(new SelectListItem { Value = "Fiend", Text = "Fiend" });
            RaceList.Add(new SelectListItem { Value = "Fish", Text = "Fish" });
            RaceList.Add(new SelectListItem { Value = "Insect", Text = "Insect" });
            RaceList.Add(new SelectListItem { Value = "Machine", Text = "Machine" });
            RaceList.Add(new SelectListItem { Value = "Plant", Text = "Plant" });
            RaceList.Add(new SelectListItem { Value = "Psychic", Text = "Psychic" });
            RaceList.Add(new SelectListItem { Value = "Pyro", Text = "Pyro" });
            RaceList.Add(new SelectListItem { Value = "Reptile", Text = "Reptile" });
            RaceList.Add(new SelectListItem { Value = "Rock", Text = "Rock" });
            RaceList.Add(new SelectListItem { Value = "SeaSerpent", Text = "Sea Serpent" });
            RaceList.Add(new SelectListItem { Value = "Spellcaster", Text = "Spellcaster" });
            RaceList.Add(new SelectListItem { Value = "Thunder", Text = "Thunder" });
            RaceList.Add(new SelectListItem { Value = "Warrior", Text = "Warrior" });
            RaceList.Add(new SelectListItem { Value = "WingedBeast", Text = "Winged Beast" });
            RaceList.Add(new SelectListItem { Value = "Wyrm", Text = "Wyrm" });
            RaceList.Add(new SelectListItem { Value = "Zombie", Text = "Zombie" });

            return RaceList;
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
}
