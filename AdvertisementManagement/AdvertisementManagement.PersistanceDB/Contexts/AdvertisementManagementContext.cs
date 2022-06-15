using AdvertisementManagement.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertisementManagement.PersistanceDB.Contexts
{
    public class AdvertisementManagementContext : DbContext
    {
        public AdvertisementManagementContext(DbContextOptions<AdvertisementManagementContext> options) : base(options)
        {

        }

        public DbSet<Advertisement> Advertisements { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdvertisementManagementContext).Assembly);
        }
    }
}
