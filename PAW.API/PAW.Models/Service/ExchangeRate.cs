using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PAW.Models.Service
{
    public class ExchangeRate
    {
        [JsonPropertyName("compra")]
        public decimal Buy {  get; set; }

        [JsonPropertyName("venta")]
        public decimal Sell { get; set; }

        [JsonPropertyName("fecha")]
        public string Date { get; set; }


    }
}
