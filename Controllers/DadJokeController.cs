using DadJokeMVC.Services;
using DadJokeMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadJokeMVC.Controllers
{
    public class DadJokeController : Controller
    {
        private readonly IDadJokeAPIService dadJokeAPIService;
        private readonly ILogger<DadJokeController> logger;
        
        public DadJokeController(IDadJokeAPIService dadJokeAPIService, ILogger<DadJokeController> logger) {
            this.dadJokeAPIService = dadJokeAPIService;
            this.logger = logger;
        }


        public IActionResult DadJokeHome() {
            // create a div in the view to hold the random joke that gets returned. and a button to trigger the call 
            var viewmodel = new DadJokeHomeViewModel();

            return View("DadJokeHome", viewmodel);
        }
        public JsonResult Random() {

            var randomJoke = this.dadJokeAPIService.GetRandom();           
            return Json(randomJoke.Result.Joke);
        }

        public JsonResult Search(string searchText) {

            var results = this.dadJokeAPIService.SearchByText(searchText);
            return Json(results); 
        }
    }
}
