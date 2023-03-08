using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AutoMvc.Models
{
    public class Auto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Lessee { get; set; }
        public string Status { get; set; }
    }

    public class AutoDBContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
    }
}