using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos2_Piotr_Tryfon_APBD.DTOs.Requests
{
    public class ArtistTimeUpdateDTORequest
    {

        public int IdArtist { get; set; }

        public int IdEvent { get; set; }

        public DateTime PerformanceDate { get; set; }
    }
}
