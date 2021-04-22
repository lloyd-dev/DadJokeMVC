using DadJokeMVC.ApiModels;
using System.Threading.Tasks;

namespace DadJokeMVC.Services
{
    public interface IDadJokeAPIService
    {
        public Task<PagedDadJokeResponse> SearchByText(string text, int limit = 30, int page = 1);
        public Task<DadJoke> GetRandom();
    }
}
