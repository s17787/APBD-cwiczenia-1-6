using Kolos2_Piotr_Tryfon_APBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos2_Piotr_Tryfon_APBD.DTOs.Responses
{
    public class ArtistDTOResponse
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
