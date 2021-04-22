using DadJokeMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DadJokeMVC.Controllers
{
    public class DadJokeController : Controller
    {
        private readonly IDadJokeAPIService dadJokeAPIService;
        
        public DadJokeController(IDadJokeAPIService dadJokeAPIService) {
            this.dadJokeAPIService = dadJokeAPIService;
        }        
       
        public JsonResult Random() {

            var randomJoke = this.dadJokeAPIService.GetRandom();           
            return Json(randomJoke.Result.Joke);
        }
        
        public JsonResult Search(string searchText, int limit = 30, int page = 1) {

            var results = this.dadJokeAPIService.SearchByText(searchText, limit, page);    
            
            return Json(results); 
        }
    }
}
