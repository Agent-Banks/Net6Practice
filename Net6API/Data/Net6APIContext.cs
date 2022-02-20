#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net6API.Models;

namespace Net6API.Data
{
    public class Net6APIContext : DbContext
    {
        public Net6APIContext (DbContextOptions<Net6APIContext> options)
            : base(options)
        {
        }

        public DbSet<Net6API.Models.User> User { get; set; }
    }
}
