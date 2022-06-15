using AdvertisementManagement.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertisementManagement.PersistanceDB.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(20);

            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.Image).IsRequired().IsUnicode(false);

            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(9).IsFixedLength().IsUnicode(false);
        }
    }
}
