﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class Medicament
    {
        public virtual ICollection<Prescription_Medicament> Prescription_Medicament { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMedicament { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; }
    }
}
