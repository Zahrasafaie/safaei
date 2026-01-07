using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using safaei.Models;

namespace safaei.Data
{
    public class safaeiContext : DbContext
    {
        public safaeiContext (DbContextOptions<safaeiContext> options)
            : base(options)
        {
        }

        public DbSet<safaei.Models.PageGroup> PageGroup { get; set; } = default!;
        public DbSet<safaei.Models.Page> Page { get; set; } = default!;
        public DbSet<safaei.Models.Aboutus> Aboutus { get; set; } = default!;
        public DbSet<safaei.Models.Comment> Comment { get; set; } = default!;
        public DbSet<safaei.Models.contactus> contactus { get; set; } = default!;
    }
}
