
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
    public class CoverConfiguration : IEntityTypeConfiguration<Cover>
    {
        public void Configure(EntityTypeBuilder<Cover> builder)
        {
            //builder.HasKey(pt => new { pt.Id });

            //builder.HasOne<Cover>(pt => pt.Cover)
            //    .WithMany(p => p.CoverThemes)
            //    .HasForeignKey(pt => pt.CoverId);

            //builder.HasOne<Theme>(pt => pt.Theme)
            //    .WithMany(p => p.CoverTheme)
            //    .HasForeignKey(pt => pt.ThemeId);
            //builder.HasOne<CoverIssuer>(c => c.Cover)
            //    .WithOne(i => i.Cover)
            //    .HasForeignKey<CoverIssuer>(c => c.CoverIssuerId)
        }

        //private List<Cover> GetCovers(string seedFolder, List<Country> countries, List<IssuedByEntity> issuedByEntities, List<Theme> themes, List<CoverType> types, List<CoverValue> values)
        //{
        //    string file = Path.Combine(seedFolder, "Cover.csv");

        //    var records = new List<Cover>();
        //    using (var rd = new StreamReader(file))
        //    {
        //        using var csv = new CsvReader(rd, CultureInfo.InvariantCulture);
        //        csv.Read();
        //        csv.ReadHeader();
        //        var id = 1;
        //        while (csv.Read())
        //        {
        //            var dateWithId = csv.GetField<string>("Date");
        //            var dates = dateWithId.Split(".");
        //            var date = DateTime.ParseExact(dates[0], "yyyyMMdd", CultureInfo.InvariantCulture);
        //            var numberOnDate = dates[1];

        //            var themesList = new List<Theme>();
        //            var theme1 = csv.GetField<string>("Theme A");
        //            if (!string.IsNullOrEmpty(theme1))
        //                themesList.Add(themes.SingleOrDefault(x => x.Name == theme1));

        //            var theme2 = csv.GetField<string>("Theme B");
        //            if (!string.IsNullOrEmpty(theme2))
        //                themesList.Add(themes.SingleOrDefault(x => x.Name == theme2));

        //            var theme3 = csv.GetField<string>("Theme C");
        //            if (!string.IsNullOrEmpty(theme3))
        //                themesList.Add(themes.SingleOrDefault(x => x.Name == theme3));

        //            var theme4 = csv.GetField<string>("Theme D");
        //            if (!string.IsNullOrEmpty(theme4))
        //                themesList.Add(themes.SingleOrDefault(x => x.Name == theme4));

        //            var areaFromCSV = csv.GetField<string>("Area");
        //            var typeFromCSV = csv.GetField<string>("Type");
        //            var issuedByFromCSV = csv.GetField<string>("Issued By");
        //            var noFromCSV = csv.GetField<string>("No");
        //            var valueFromCSV = csv.GetField<string>("Value");
        //            var descFromCSV = csv.GetField<string>("Description");
        //            var noIssuedFromCSV = csv.GetField<string>("# Issued").Trim();
        //            var atlasFromCSV = csv.GetField<string>("Atlas");
        //            var albertaFromCSV = csv.GetField<string>("Alberta");

        //            Int32.TryParse(noIssuedFromCSV, out int j);
        //            var record = new Cover
        //            {
        //                Id = id++,
        //                CreatedBy = "DataSeed",
        //                CreatedOn = DateTime.Now,
        //                LastModifiedBy = null,
        //                LastModifiedOn = null,

        //                CoverDate = date,
        //                IdOnDate = numberOnDate,
        //                Number = noFromCSV ?? null,
        //                Description = descFromCSV ?? null,
        //                AmountIssued = noIssuedFromCSV,
        //                Atlas = atlasFromCSV ?? null,
        //                Alberta = albertaFromCSV ?? null                        

        //            };

        //            var coverThemesList = new List<CoverTheme>();

                    
        //            records.Add(record);
        //        }
        //        return records;
        //    }
        //}

        //private List<CoverValue> GetCoverValues(string seedFolder)
        //{
        //    return new List<CoverValue>
        //    {
        //        new CoverValue
        //            {
        //                Id = 1,
        //                Code = "$",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                MinValue = 0,
        //                MaxValue = 5
        //            },
        //            new CoverValue
        //            {
        //                Id = 2,
        //                Code = "$$",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                MinValue = 5.01m,
        //                MaxValue = 15
        //            },
        //            new CoverValue
        //            {
        //                Id = 3,
        //                Code = "$$$",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                MinValue = 15.01m,
        //                MaxValue = 50
        //            },
        //            new CoverValue
        //            {
        //                Id = 4,
        //                Code = "$$$$",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                MinValue = 50.01m,
        //                MaxValue = 150
        //            },
        //            new CoverValue
        //            {
        //                Id = 5,
        //                Code = "$$$$$",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                MinValue = 150.01m,
        //                MaxValue = 500
        //            },
        //            new CoverValue
        //            {
        //                Id = 6,
        //                Code = "$$$$$$",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                MinValue = 500.01m,
        //                MaxValue = null
        //            }
        //    };
        //}

        //private List<CoverType> GetCoverTypes(string seedFolder)
        //{
        //    return new List<CoverType>
        //    {
        //        new CoverType
        //            {
        //                Id = 1,
        //                Code = "FDC",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "First Day"
        //            },
        //            new CoverType
        //            {
        //                Id = 2,
        //                Code = "CMC",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Comemorative"
        //            },
        //            new CoverType
        //            {
        //                Id = 3,
        //                Code = "FLT",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Flight"
        //            },
        //            new CoverType
        //            {
        //                Id = 4,
        //                Code = "SLK",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Silk"
        //            },
        //            new CoverType
        //            {
        //                Id = 5,
        //                Code = "GLD",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Gold Foiled"
        //            },
        //            new CoverType
        //            {
        //                Id = 6,
        //                Code = "MIL",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Military"
        //            },
        //            new CoverType
        //            {
        //                Id = 7,
        //                Code = "FIL",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Filatelic"
        //            },
        //            new CoverType
        //            {
        //                Id = 8,
        //                Code = "BAL",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Balloon"
        //            },
        //            new CoverType
        //            {
        //                Id = 9,
        //                Code = "RWY",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Railway"
        //            }
        //    };
        //}

        //private List<Theme> GetThemes(string seedFolder)
        //{
        //    string file = Path.Combine(seedFolder, "Themes.csv");
        //    Console.WriteLine("Theme seed location: " + file);

        //    var dictionary = new List<string>();
        //    using (var rd = new StreamReader(file))
        //    {
        //        while (!rd.EndOfStream)
        //        {
        //            var splits = rd.ReadLine().Split(',');
        //            //string clean is done with Regex
        //            dictionary.Add(Regex.Replace(splits[0], "[^A-Za-z0-9 ]", ""));
        //        }
        //    }

        //    var id = 1;
        //    var themeList = new List<Theme>();
        //    foreach (var theme in dictionary)
        //    {
        //        if (String.IsNullOrEmpty(theme))
        //            continue;

        //        themeList.Add(new Theme
        //        {
        //            Id = id++,
        //            CreatedBy = "DataSeed",
        //            CreatedOn = DateTime.Now,
        //            LastModifiedBy = null,
        //            LastModifiedOn = null,                    
        //            Name = theme
        //        });


        //    }
        //    return themeList;
        //}

        //private List<Country> GetCountries()
        //{
        //    return new List<Country> {
        //            new Country
        //            {
        //                Id = 1,
        //                Code = "VEN",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Venda",
        //            },
        //            new Country
        //            {
        //                Id = 2,
        //                Code = "TRA",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Transkei"
        //            },
        //            new Country
        //            {
        //                Id = 3,
        //                Code = "CIS",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Ciskei"
        //            },
        //            new Country
        //            {
        //                Id = 4,
        //                Code = "BOP",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Bophuthatswana"
        //            },
        //            new Country
        //            {
        //                Id = 5,
        //                Code = "SWA",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "South West Africa"
        //            },
        //            new Country
        //            {
        //                Id = 6,
        //                Code = "RSA",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "South Africa"
        //            },
        //            new Country
        //            {
        //                Id = 7,
        //                Code = "NAM",
        //                CreatedOn = DateTime.Now,
        //                CreatedBy = "DataSeed",
        //                LastModifiedOn = null,
        //                LastModifiedBy = null,
        //                Name = "Namibia"
        //            }
        //    };
        //}

        //private List<IssuedByEntity> GetIssuedByEntities(string seedFolder)
        //{
        //    string issuedByEntitiesfile = Path.Combine(seedFolder, "IssuedByEntities.csv");
        //    var issuedByDictionary = new List<string>();
        //    using (var rd = new StreamReader(issuedByEntitiesfile))
        //    {
        //        while (!rd.EndOfStream)
        //        {
        //            var splits = rd.ReadLine().Split(',');
        //            //string clean is done with Regex
        //            issuedByDictionary.Add(Regex.Replace(splits[0], "[^A-Za-z0-9() ]", ""));
        //        }
        //    }

        //    var id = 1;
        //    var list = new List<IssuedByEntity>();
        //    foreach (var entity in issuedByDictionary)
        //    {
        //        if (String.IsNullOrEmpty(entity))
        //            continue;

        //        //string code;
        //        //if (entity.Contains('('))
        //        //{
        //        //    code = entity.Split().Where(x => x.StartsWith("(") && x.EndsWith(")")).SingleOrDefault().ToUpper();
        //        //    entity.Remove()
        //        //}
        //        //else
        //        //{
        //        //    code = string.Join("", entity.Split(' ').Select(s => s[0].ToString().ToUpper()));
        //        //}

        //        list.Add(new IssuedByEntity
        //        {
        //            Id = id++,
        //            CreatedBy = "DataSeed",
        //            CreatedOn = DateTime.Now,
        //            LastModifiedBy = null,
        //            LastModifiedOn = null,
        //            Code = null,
        //            Name = entity
        //        });


        //    }

        //    return list;
        //}
    }
}
