using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos2_Piotr_Tryfon_APBD.Models
{
    public class Organiser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrganiser { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Organiser> EventOrganiser { get; set; }
    }
}
