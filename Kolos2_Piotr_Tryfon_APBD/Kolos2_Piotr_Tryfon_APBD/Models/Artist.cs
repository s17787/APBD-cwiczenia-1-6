using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos2_Piotr_Tryfon_APBD.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArtist { get; set; }

        [Required]
        [MaxLength(30)]
        public string NickName { get; set; }
        public virtual ICollection<Artist_Event> Artist_Event { get; set; }

    }
}
