using Instagram.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Data.Contexts
{
    public class InstagramDbContext : DbContext
    {
        public InstagramDbContext(DbContextOptions<InstagramDbContext> options) : base( options )
        {
        }
        public InstagramDbContext()
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
