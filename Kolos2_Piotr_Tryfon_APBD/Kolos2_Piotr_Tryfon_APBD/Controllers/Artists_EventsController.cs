using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolos2_Piotr_Tryfon_APBD.DTOs.Requests;
using Kolos2_Piotr_Tryfon_APBD.DTOs.Responses;
using Kolos2_Piotr_Tryfon_APBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2_Piotr_Tryfon_APBD.Controllers
{
    //Chcialbym uprzedzic i przeprosic za blad - Nazwa Models/HomeController.cs zostala wygenerowana automatycznie i nie zdazylem jej zrefactorowac
    [Route("/api/artists/ ")]
    [ApiController]
    public class Artists_EventsController : ControllerBase
    {
        private readonly HomeController _context;
        public Artists_EventsController(HomeController context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetArtist([FromRoute] int id)
        {
            ICollection<Artist_Event> events;
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                events = _context.Artist_Events
                .Where(Artist_Event => Artist_Event.Artist.IdArtist == id)
                .ToList();

            }

            ArtistDTOResponse response = new ArtistDTOResponse();
            return Ok(response);
        }

        [Route("/api/artists//events/")]
        [HttpPut]
        public IActionResult UpdateDate(ArtistTimeUpdateDTORequest request)
        {
            var temp = _context.Event.Where(e => e.IdEvent == request.IdEvent || e.StartDate < DateTime.Now).First();

            if (temp == null)
                {
                    return BadRequest();
                }
            else
            {
                //
            }


            _context.SaveChanges();
            return Ok();
        }
        
    }
}
