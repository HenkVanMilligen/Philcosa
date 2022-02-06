using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Philcosa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Philcosa.Infrastructure.Configuration
{
    public class CoverIssuerEntityConfiguration : IEntityTypeConfiguration<CoverIssuer>
    {
        public bool IsDevelopment { get; set; }

        public CoverIssuerEntityConfiguration(bool isDevelopment)
        {
            IsDevelopment = isDevelopment;
        }

        public void Configure(EntityTypeBuilder<CoverIssuer> builder)
        {
            string seedFolder = Directory.GetCurrentDirectory() + "/Seeds";
            if (IsDevelopment)
            {
                seedFolder = Directory.GetCurrentDirectory() + "/bin/Debug/net5.0/Seeds";
            }
            string file = Path.Combine(seedFolder, "CoverIssuers.csv");

            var list = new List<CoverIssuer>();
            using (var rd = new StreamReader(file))
            {
                using var csv = new CsvReader(rd, CultureInfo.InvariantCulture);
                csv.Read();
                csv.ReadHeader();
                var id = 1;
                while (csv.Read())
                {
                    var code = csv.GetField<string>("Code");
                    var name = csv.GetField<string>("Name");

                    if (string.IsNullOrEmpty(name))
                        continue;

                    list.Add(new CoverIssuer
                    {
                        Id = id,
                        CreatedBy = "DataSeed",
                        CreatedOn = DateTime.Now,
                        LastModifiedBy = null,
                        LastModifiedOn = null,
                        Code = code,
                        Name = name
                    });
                    id++;
                }
            }
            builder.HasData(list);
        }
    }
}
