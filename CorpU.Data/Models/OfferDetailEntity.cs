using CorpU.Entitiy.Models.Dto.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class OfferDetailEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int offer_id { get; set; }

        [Required]
        public int Application_id { get; set; }

        [Required]
        public DateTime offer_date { get; set; }
        public string notes { get; set; }
        public string status { get; set; }

        [JsonPropertyName("Application")]
        public ApplicationEntity application { get; set; }
    }
}
