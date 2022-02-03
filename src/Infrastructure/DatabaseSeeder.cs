using Philcosa.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Philcosa.Infrastructure.Models.Identity;
using Philcosa.Infrastructure.Contexts;
using Philcosa.Infrastructure.Helpers;
using Philcosa.Shared.Constants.Permission;
using Philcosa.Shared.Constants.Role;
using Philcosa.Shared.Constants.User;
using Microsoft.EntityFrameworkCore;
using Philcosa.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using Bunit.Extensions;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;

namespace Philcosa.Infrastructure
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ILogger<DatabaseSeeder> _logger;
        private readonly IStringLocalizer<DatabaseSeeder> _localizer;
        private readonly PhilcosaContext _db;
        private readonly UserManager<PhilcosaUser> _userManager;
        private readonly RoleManager<BlazorHeroRole> _roleManager;

        public DatabaseSeeder(
            UserManager<PhilcosaUser> userManager,
            RoleManager<BlazorHeroRole> roleManager,
            PhilcosaContext db,
            ILogger<DatabaseSeeder> logger,
            IStringLocalizer<DatabaseSeeder> localizer)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _logger = logger;
            _localizer = localizer;
        }

        public void Initialize()
        {
            AddAdministrator();
            AddBasicUser();
            //AddDefaultCovers();
            _db.SaveChanges();
        }

        private void AddDefaultCovers()
        {
            //Only run if no covers exist in db
            if (!_db.Covers.Any())
            {
                Task.Run(async () =>
                {
                    var countries = await _db.Countries.ToListAsync();
                    var coverIssuerEntities = await _db.CoverIssuers.ToListAsync();
                    var themes = await _db.Themes.ToListAsync();
                    var types = await _db.CoverTypes.ToListAsync();
                    var values = await _db.CoverValues.ToListAsync();

                    string seedFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Philcosa.Infrastructure\\Seeds\\";
                    string imagesSeedFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Philcosa\\Server\\Files\\Images\\Covers\\";
                    List<Cover> covers = GetCovers(seedFolder, imagesSeedFolder, countries, coverIssuerEntities, themes, types, values);

                    foreach (var cover in covers)
                    {
                        try
                        {
                            if (_db.Covers.Any(c => c.Id == cover.Id))
                                continue;

                            foreach (var coverTheme in cover.CoverThemes)
                            {

                                await _db.AddAsync(coverTheme);
                            }

                            await _db.AddAsync(cover);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }).GetAwaiter().GetResult();

            }
        }

        private static List<Cover> GetCovers(string seedFolder, string imagesSeedFolder, List<Country> countries, List<CoverIssuer> coverIssuerEntities, List<Theme> themes,
                                                List<CoverType> types, List<CoverValue> values)
        {
            string file = Path.Combine(seedFolder, "Covers.csv");

            DirectoryInfo imagesDI = new DirectoryInfo(imagesSeedFolder);
            FileInfo[] images = imagesDI.GetFiles("*.jpg");

            var records = new List<Cover>();
            using (var rd = new StreamReader(file))
            {
                using var csv = new CsvReader(rd, CultureInfo.InvariantCulture);
                csv.Read();
                csv.ReadHeader();
                var id = 1;
                var coverThemeId = 0;
                while (csv.Read())
                {

                    var dateWithId = csv.GetField<string>("Date");
                    var dates = dateWithId.Split(".");
                    var date = DateTime.ParseExact(dates[0], "yyyyMMdd", CultureInfo.InvariantCulture);
                    var numberOnDate = dates[1];

                    var themesList = new List<Theme>();
                    var theme1 = csv.GetField<string>("Theme A").Trim().ToLower();
                    if (!string.IsNullOrEmpty(theme1))
                    {
                        var theme = themes.SingleOrDefault(x => x.Name.ToLower() == theme1);
                        if (!themesList.Contains(theme))
                            themesList.Add(theme);
                    }

                    var theme2 = csv.GetField<string>("Theme B").Trim().ToLower();
                    if (!string.IsNullOrEmpty(theme2))
                    {
                        var theme = themes.SingleOrDefault(x => x.Name.ToLower() == theme2);
                        if (!themesList.Contains(theme))
                            themesList.Add(theme);
                    }

                    var theme3 = csv.GetField<string>("Theme C").Trim().ToLower();
                    if (!string.IsNullOrEmpty(theme3))
                    {
                        var theme = themes.SingleOrDefault(x => x.Name.ToLower() == theme3);
                        if (!themesList.Contains(theme))
                            themesList.Add(theme);
                    }

                    var theme4 = csv.GetField<string>("Theme D").Trim().ToLower();
                    if (!string.IsNullOrEmpty(theme4))
                    {
                        var theme = themes.SingleOrDefault(x => x.Name.ToLower() == theme4);
                        if (!themesList.Contains(theme))
                            themesList.Add(theme);
                    }

                    var areaFromCSV = csv.GetField<string>("Area").Trim();
                    var typeFromCSV = csv.GetField<string>("Type").Trim();
                    var issuedByFromCSV = csv.GetField<string>("Issued By").Trim();
                    var noFromCSV = csv.GetField<string>("No").Trim();
                    var valueFromCSV = csv.GetField<string>("Value").Trim();
                    var descFromCSV = csv.GetField<string>("Description").Trim();
                    var noIssuedFromCSV = csv.GetField<string>("# Issued").Trim();
                    var atlasFromCSV = csv.GetField<string>("Atlas").Trim();
                    var albertaFromCSV = csv.GetField<string>("Alberta").Trim();

                    Int32.TryParse(noIssuedFromCSV, out int j);
                    var coverThemeList = new List<CoverTheme>();
                    foreach (var themeForCover in themesList)
                    {
                        coverThemeId++;
                        var coverTheme = new CoverTheme
                        {
                            Id = coverThemeId,
                            CoverId = id,
                            ThemeId = themeForCover.Id,
                            CreatedBy = "DataSeed",
                            CreatedOn = DateTime.Now,
                            LastModifiedBy = null,
                            LastModifiedOn = null,
                        };
                        coverThemeList.Add(coverTheme);
                    }
                    var country = countries.SingleOrDefault(x => x.Code == areaFromCSV);
                    var coverImagesSearchPhrase = $"{country.Code} {date.ToString("yyyyMMdd")}.{numberOnDate}";
                    var imageForCover = images.Where(x => x.Name.Contains(coverImagesSearchPhrase));
                    string imageFileName = null;

                    if (imageForCover != null && imageForCover.Count() == 1)
                    {
                        imageFileName = $"Files\\Images\\Covers\\{imageForCover.SingleOrDefault().Name}";
                    }
                    var cover = new Cover
                    {
                        Id = id,
                        CreatedBy = "DataSeed",
                        CreatedOn = DateTime.Now,
                        LastModifiedBy = null,
                        LastModifiedOn = null,

                        CoverDate = date,
                        IdOnDate = numberOnDate,
                        CoverIssuer = coverIssuerEntities.SingleOrDefault(x => x.Code == issuedByFromCSV),
                        Number = noFromCSV ?? null,
                        Description = descFromCSV ?? null,
                        AmountIssued = noIssuedFromCSV,
                        Atlas = atlasFromCSV ?? null,
                        Alberta = albertaFromCSV ?? null,
                        CoverType = types.SingleOrDefault(x => x.Code == typeFromCSV),
                        Value = values.SingleOrDefault(x => x.Code == valueFromCSV),
                        Country = countries.SingleOrDefault(x => x.Code == areaFromCSV),
                        CoverThemes = coverThemeList,
                        ImageDataUrl = imageFileName

                    };
                    records.Add(cover);
                    id++;
                }

                return records;
            }


        }

        private void AddAdministrator()
        {
            Task.Run(async () =>
            {
                //Check if Role Exists
                var adminRole = new BlazorHeroRole(RoleConstants.AdministratorRole, _localizer["Administrator role with full permissions"]);
                var adminRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.AdministratorRole);
                if (adminRoleInDb == null)
                {
                    await _roleManager.CreateAsync(adminRole);
                    adminRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.AdministratorRole);
                    _logger.LogInformation(_localizer["Seeded Administrator Role."]);
                }
                //Check if User Exists
                var superUser = new PhilcosaUser
                {
                    FirstName = "Henk",
                    LastName = "Van Milligen",
                    Email = "henkvm14@gmail.com",
                    UserName = "henkvm_admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };
                var superUserInDb = await _userManager.FindByEmailAsync(superUser.Email);
                if (superUserInDb == null)
                {
                    await _userManager.CreateAsync(superUser, UserConstants.DefaultPassword);
                    var result = await _userManager.AddToRoleAsync(superUser, RoleConstants.AdministratorRole);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation(_localizer["Seeded Default SuperAdmin User."]);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            _logger.LogError(error.Description);
                        }
                    }
                }
                foreach (var permission in Permissions.GetRegisteredPermissions())
                {
                    await _roleManager.AddPermissionClaim(adminRoleInDb, permission);
                }
            }).GetAwaiter().GetResult();
        }

        private void AddBasicUser()
        {
            Task.Run(async () =>
            {
                //Check if Role Exists
                var basicRole = new BlazorHeroRole(RoleConstants.BasicRole, _localizer["Basic role with default permissions"]);
                var basicRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.BasicRole);
                if (basicRoleInDb == null)
                {
                    await _roleManager.CreateAsync(basicRole);
                    _logger.LogInformation(_localizer["Seeded Basic Role."]);
                }
                //Check if User Exists
                var basicUser = new PhilcosaUser
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@blazorhero.com",
                    UserName = "johndoe",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };
                var basicUserInDb = await _userManager.FindByEmailAsync(basicUser.Email);
                if (basicUserInDb == null)
                {
                    await _userManager.CreateAsync(basicUser, UserConstants.DefaultPassword);
                    await _userManager.AddToRoleAsync(basicUser, RoleConstants.BasicRole);
                    _logger.LogInformation(_localizer["Seeded User with Basic Role."]);
                }
            }).GetAwaiter().GetResult();
        }
    }
}