using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadJokeMVC.ApiModels
{
    public class PagedDadJokeResponse
    {
        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("next_page")]
        public long NextPage { get; set; }

        [JsonProperty("previous_page")]
        public long PreviousPage { get; set; }

        [JsonProperty("results")]
        public DadJokeSearchResult[] Results { get; set; }

        [JsonProperty("search_term")]
        public string SearchTerm { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("total_jokes")]
        public long TotalJokes { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }
    }
}

