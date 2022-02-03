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
    public class CoverValueConfiguration : IEntityTypeConfiguration<CoverValue>
    {
        public void Configure(EntityTypeBuilder<CoverValue> builder)
        {
            builder.HasData(                   
                    new CoverValue
                    {
                        Id = 1,
                        Code = "$",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        MinValue = 0,
                        MaxValue = 5
                    },
                    new CoverValue
                    {
                        Id = 2,
                        Code = "$$",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        MinValue = 5.01m,
                        MaxValue = 15
                    },
                    new CoverValue
                    {
                        Id = 3,
                        Code = "$$$",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        MinValue = 15.01m,
                        MaxValue = 50
                    },
                    new CoverValue
                    {
                        Id = 4,
                        Code = "$$$$",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        MinValue = 50.01m,
                        MaxValue = 150
                    },
                    new CoverValue
                    {
                        Id = 5,
                        Code = "$$$$$",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        MinValue = 150.01m,
                        MaxValue = 500
                    },
                    new CoverValue
                    {
                        Id = 6,
                        Code = "$$$$$$",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModifiedOn = null,
                        LastModifiedBy = null,
                        MinValue = 500.01m,
                        MaxValue = null
                    }
                );
        }
    }
}
