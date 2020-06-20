using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolos2_Piotr_Tryfon_APBD.Models
{
    public class HomeController : DbContext
    {
        public virtual ICollection<EventOrganiser> EventOrganiser { get; set; }
        
        public virtual ICollection<Artist_Event> Artist_Events { get; set; }

        public DbSet<Organiser> Organiser { get; set; }
        public DbSet<Event> Event { get; set; }

        public HomeController()
        {

        }
        public HomeController(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EventOrganiser>()
                .HasKey(z => new { z.IdEvent, z.IdOrganiser });
        }
    }
}
