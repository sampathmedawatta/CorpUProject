using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Unit
{
    public class OfferRegisterDto
    {
        [JsonPropertyName("Application_id")]
        public int Application_id { get; set; }

        [JsonPropertyName("offer_date")]
        public DateTime offer_date { get; set; }

        [JsonPropertyName("notes")]
        public string notes { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }
    }
}
