using DadJokeMVC.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadJokeMVC.Services
{
    public interface IDadJokeAPIService
    {
        public Task<IEnumerable<DadJoke>> SearchByText(string text);
        public Task<DadJoke> GetRandom();
    }
}
