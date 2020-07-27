using System;

namespace Mizan.Covid19.Library
{
    public class DaywiseCase
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Cases { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}