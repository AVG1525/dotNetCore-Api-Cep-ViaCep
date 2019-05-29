using AspCepAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCepAPI.Domain
{
    public class CepDomain : DbContext
    {
        public CepDomain(DbContextOptions<CepDomain> options) : base(options)
        {

        } 

        public DbSet<CepModel> CepModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CepModel>().HasKey(m => m.cep);
            base.OnModelCreating(builder);
        }
    } 
}
