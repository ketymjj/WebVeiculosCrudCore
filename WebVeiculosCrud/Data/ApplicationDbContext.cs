using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebVeiculosCrud.Models;

namespace WebVeiculosCrud.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VeiculosModel> VeiculosModel { get; set; }

        public DbSet<LoginUsuarioModel> LoginUsuarioModel { get; set; }

    }
}
