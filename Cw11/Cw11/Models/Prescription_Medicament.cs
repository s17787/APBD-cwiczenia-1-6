using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class Prescription_Medicament
    {
        public virtual Prescription Prescription { get; set; }
        public virtual Medicament Medicament { get; set; }
        [Key]
        public int IdPrescription { get; set; }

        [Key]
        public int IdMedicament { get; set; }

        [AllowNull]
        public int Dose { get; set; }

        [Required, MaxLength(100)]
        public string Details { get; set; }

    }
}
