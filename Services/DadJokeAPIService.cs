﻿using DadJokeMVC.ApiModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DadJokeMVC.Services
{
    public class DadJokeAPIService : IDadJokeAPIService
    {
        private readonly Uri baseUrl = new Uri("https://icanhazdadjoke.com");
        private readonly ILogger<DadJokeAPIService> logger;

        public DadJokeAPIService(ILogger<DadJokeAPIService> logger) {
            this.logger = logger;
        }

        public async Task<DadJoke> GetRandom()
        {
            DadJoke dadJokeResponse = null;
            try
            {
                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Lloyd needs a new job"); //icanhazdadjoke wants people to set a custome user agent
                    using (var result = httpClient.GetAsync(baseUrl).Result)
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            dadJokeResponse = JsonConvert.DeserializeObject<DadJoke>(result.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                this.logger.Log(LogLevel.Information, ex.Message);
            }
            return dadJokeResponse;
        }

        public async Task<PagedDadJokeResponse> SearchByText(string text)
        {
            PagedDadJokeResponse pagedDadJokeResponse = null;
            try
            {
                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Lloyd needs a new job"); //icanhazdadjoke wants people to set a custome user agent
                    using (var result = httpClient.GetAsync(string.Format(baseUrl + "/search?term={0}", text)).Result)
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            pagedDadJokeResponse = JsonConvert.DeserializeObject<PagedDadJokeResponse>(result.Content.ReadAsStringAsync().Result);
                          
                            pagedDadJokeResponse.Results = CapitalizeSearchTermInResults(pagedDadJokeResponse.Results, text);                            
                        }
                    }
                }
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                this.logger.Log(LogLevel.Information, ex.Message);
            }
            return pagedDadJokeResponse;
        }

        private DadJokeSearchResult[] CapitalizeSearchTermInResults(DadJokeSearchResult[] dadJokes, string searchTerm) {

            var jokesWithUppercaseSearchTerm = from d in dadJokes
                            from word in d.Joke.Split(' ')
                            where string.Equals(word, searchTerm, StringComparison.OrdinalIgnoreCase)
                            select d.Joke.Replace(word, word.ToUpper());

            foreach (var originalDadJoke in dadJokes)
            { 
                foreach(var updatedDadJoke in jokesWithUppercaseSearchTerm)
                {
                    originalDadJoke.Joke = updatedDadJoke;
                }               
            }

            return dadJokes;

        }
    }
}
