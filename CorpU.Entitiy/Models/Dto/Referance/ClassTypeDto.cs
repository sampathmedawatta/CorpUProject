using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Referance
{
    public class ClassTypeDto
    {

        [JsonPropertyName("class_type_id")]
        public int class_type_id { get; set; }

        [JsonPropertyName("class_description")]
        public string class_description { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }


    }
}
