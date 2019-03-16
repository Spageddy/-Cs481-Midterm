using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Midterm.Models
{
    public partial class StockData
    {
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }

        [JsonProperty("Time Series (Daily)")]
        public Dictionary<string, TimeSeriesDaily> TimeSeriesDaily { get; set; }
    }

    public partial class MetaData
    {
        [JsonProperty("1. Information")]
        public string TheInformation { get; set; }

        [JsonProperty("2. Symbol")]
        public string TheSymbol { get; set; }

        [JsonProperty("3. Last Refreshed")]
        public DateTimeOffset The3LastRefreshed { get; set; }

        [JsonProperty("4. Output Size")]
        public string TheOutputSize { get; set; }

        [JsonProperty("5. Time Zone")]
        public string TheTimeZone { get; set; }
    }

    public partial class TimeSeriesDaily

    {
        public DateTime TheDate { get; set; }
        [JsonProperty("1. open")]
        public string TheOpen { get; set; }

        [JsonProperty("2. high")]
        public string TheHigh { get; set; }

        [JsonProperty("3. low")]
        public string TheLow { get; set; }

        [JsonProperty("4. close")]
        public string TheClose { get; set; }

        [JsonProperty("5. volume")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long TheVolume { get; set; }
    }
}
