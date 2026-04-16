using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using carseller.Models;

namespace carseller.Data
{
    public class carsellerContext : DbContext
    {
        public carsellerContext (DbContextOptions<carsellerContext> options)
            : base(options)
        {
        }

        public DbSet<carseller.Models.Client> Client { get; set; } = default!;
        public DbSet<carseller.Models.Company> Company { get; set; } = default!;
        public DbSet<carseller.Models.Sale> Sale { get; set; } = default!;
        public DbSet<carseller.Models.User> User { get; set; } = default!;
        public DbSet<carseller.Models.Vehicle> Vehicle { get; set; } = default!;
    }
}
