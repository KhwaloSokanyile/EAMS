using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EMS.Data
{
    public class EMSContext : IdentityDbContext<ApplicationUser>
    {
        public EMSContext (DbContextOptions<EMSContext> options)
            : base(options)
        {
        }

        public DbSet<Admin>? Admins { get; set; }
        public DbSet<Asset>? Assets { get; set; }
        public DbSet<BuildSystem>? BuildSystems { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<ReturnedSystem>? ReturnedSystems { get; set; }
        public DbSet<SignUp>? SignUps { get; set; }
        public DbSet<SignIn>? SignIns { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }   
        public DbSet<ResolvedTicket>? ResolvedTickets { get; set; }
        public DbSet<ReturnedAsset>? ReturnedAssets { get; set; }

        public DbSet<AssignedTicket>? AssignedTickets { get; set;}



    }
}
