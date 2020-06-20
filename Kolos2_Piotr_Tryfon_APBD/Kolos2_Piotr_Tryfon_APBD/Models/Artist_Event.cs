using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos2_Piotr_Tryfon_APBD.Models
{
    public class Artist_Event
    {
        [Required]
        public DateTime PerformanceDate { get; set; }

        [ForeignKey("IdEvent")]
        public virtual Event Event { get; set; }

        [ForeignKey("IdArtist")]
        public virtual Artist Artist { get; set; }
    }
}
