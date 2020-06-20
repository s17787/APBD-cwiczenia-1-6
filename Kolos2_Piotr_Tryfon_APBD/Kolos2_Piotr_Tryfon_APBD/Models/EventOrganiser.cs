using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos2_Piotr_Tryfon_APBD.Models
{
    public class EventOrganiser
    {
        public int IdEvent { get; set; }
        public int IdOrganiser { get; set; }

        [ForeignKey("IdEvent")]
        public virtual Event Event { get; set; }

        [ForeignKey("IdOrganiser")]
        public virtual Organiser Organiser { get; set; }
    }
}
