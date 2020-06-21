using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class Prescription
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrescription { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public virtual Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public int IdPatient { get; set; }

        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Doctor")]
        public int IdDoctor { get; set; }

        public virtual ICollection<Prescription_Medicament> Prescription_Medicament { get; set; }
    }
}
