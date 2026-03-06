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

        public DbSet<carseller1.Models.Client> Client { get; set; } = default!;
    }
}
