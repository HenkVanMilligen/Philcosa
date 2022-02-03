using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Philcosa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Infrastructure.Configuration
{
    public class CoverTypeConfiguration : IEntityTypeConfiguration<CoverType>
    {
        public void Configure(EntityTypeBuilder<CoverType> builder)
        {
            builder.HasData(
                    new CoverType
                    {
                        Id = 1,
                        Code = "FDC",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        Name = "First Day"
                    },
                    new CoverType
                    {
                        Id = 2,
                        Code = "CMC",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        Name = "Comemorative"
                    },
                    new CoverType
                    {
                        Id = 3,
                        Code = "FLT",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        Name = "Flight"
                    },
                    new CoverType
                    {
                        Id = 4,
                        Code = "MIL",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        Name = "Military"
                    },
                    new CoverType
                    {
                        Id = 5,
                        Code = "FIL",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        Name = "Filatelic"
                    },
                    new CoverType
                    {
                        Id = 8,
                        Code = "BAL",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        Name = "Balloon"
                    },
                    new CoverType
                    {
                        Id = 9,
                        Code = "RWY",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        Name = "Railway"
                    }
                );
        }
    }
}
