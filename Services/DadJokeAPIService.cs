using DadJokeMVC.ApiModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadJokeMVC.Services
{
    public class DadJokeAPIService : IDadJokeAPIService
    {
        private readonly Uri baseUrl = new Uri("https://icanhazdadjoke.com");
        private readonly ILogger<DadJokeAPIService> logger;

        public DadJokeAPIService(ILogger<DadJokeAPIService> logger) { 
        
        }

        public Task<DadJoke> GetRandom()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DadJoke>> SearchByText(string text)
        {
            throw new NotImplementedException();
        }
    }
}
