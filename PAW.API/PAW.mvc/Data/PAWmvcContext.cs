using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PAW.Models;

namespace PAW.mvc.Data
{
    public class PAWmvcContext : DbContext
    {
        public PAWmvcContext (DbContextOptions<PAWmvcContext> options)
            : base(options)
        {
        }
        public DbSet<PAW.Models.Product> Product { get; set; } = default!;
    }
}