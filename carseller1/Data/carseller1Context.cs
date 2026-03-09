using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using carseller1.Models;

namespace carseller1.Data
{
    public class carseller1Context : DbContext
    {
        public carseller1Context (DbContextOptions<carseller1Context> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Company> Company{ get; set; }
        public DbSet<Sale> Sale{ get; set; }
        public DbSet<User> User{ get; set; }
        public DbSet<Vehicle> Vehicle{ get; set; }
    }
}
