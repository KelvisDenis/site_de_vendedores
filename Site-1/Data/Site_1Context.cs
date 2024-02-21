using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Site_1.Models;

namespace Site_1.Data
{
    public class Site_1Context : DbContext
    {
        public Site_1Context (DbContextOptions<Site_1Context> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }

        public DbSet<Departament> Departament { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellesRecord>SellesRecords { get; set; }
    }
}
