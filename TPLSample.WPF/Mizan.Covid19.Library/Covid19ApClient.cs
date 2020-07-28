using Mizan.Covid19.Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mizan.Covid19.Library
{
    public class Covid19ApClient
    {
        public async Task<Covid19Summary> GetSummaryAsync()
        {
            return await GetDataAsync<Covid19Summary>(ApiURL.SummaryUrl);
        }

        public Covid19Summary GetSummary()
        {
            return GetData<Covid19Summary>(ApiURL.SummaryUrl);
        }

        public async Task<List<CountryData>> GetCountryDataAsync()
        {
            return await GetDataAsync<List<CountryData>>(ApiURL.CountryUrl);
        }

        public async Task<List<DaywiseCase>> GetDayWiseConfirmedCases(string country)
        {
            return await GetDataAsync<List<DaywiseCase>>(ApiURL.GetDaywiseAllCasesUrl(country));
        }        

        public T GetData<T>(string url)
        {
            WebClient httpClient = new WebClient();
            var result = httpClient.DownloadString(url);
            var covid19Summary = JsonConvert.DeserializeObject<T>(result);
            return covid19Summary;
        }

        public async Task<T> GetDataAsync<T>(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
