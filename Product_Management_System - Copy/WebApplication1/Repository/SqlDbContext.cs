using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product_Managment_System.Models;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace Product_Managment_System.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options):base(options)
        {
        
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
