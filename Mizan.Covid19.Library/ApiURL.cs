using System;
using System.Collections.Generic;
using System.Text;

namespace Mizan.Covid19.Library
{
    public static class ApiURL
    {
        public static string BASE_URL = "https://api.covid19api.com/";
        public static string SummaryUrl = BASE_URL + "summary";
        public static string CountryUrl = BASE_URL + "countries";
        
        public static string GetDaywiseConfirmedCasesUrl(string country)
        {
            return BASE_URL + "dayone/country/" + country + "/status/confirmed";
        }        

        public static string GetDaywiseAllCasesUrl(string country)
        {
            return BASE_URL + "/dayone/country/" + country;
        }        
    }
}
