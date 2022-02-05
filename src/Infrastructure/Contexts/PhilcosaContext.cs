using Philcosa.Application.Interfaces.Services;
using Philcosa.Application.Models.Chat;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Philcosa.Domain.Entities.Misc;
using Philcosa.Domain.Entities.Catalog;
using Philcosa.Domain.Contracts;
using Philcosa.Domain.Entities.ExtendedAttributes;
using Philcosa.Infrastructure.Models.Identity;
using Philcosa.Domain.Entities;
using Philcosa.Infrastructure.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using Philcosa.Application.Configurations;

namespace Philcosa.Infrastructure.Contexts
{
    public class PhilcosaContext : AuditableContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;
        private readonly bool _isDevelopment;
        

        public PhilcosaContext(DbContextOptions<PhilcosaContext> options, ICurrentUserService currentUserService, IDateTimeService dateTimeService, IHostingEnvironment env)
            : base(options)
        {
            _isDevelopment = env.IsDevelopment();
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;            
        }

        public DbSet<ChatHistory<PhilcosaUser>> ChatHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentExtendedAttribute> DocumentExtendedAttributes { get; set; }

        public DbSet<Cover> Covers { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<CoverTheme> CoverThemes { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<CoverValue> CoverValues { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CoverIssuer> CoverIssuers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTimeService.NowUtc;
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTimeService.NowUtc;
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        break;
                }
            }
            if (_currentUserService.UserId == null)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return await base.SaveChangesAsync(_currentUserService.UserId, cancellationToken);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            //Debugger.Launch();

            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new CoverTypeConfiguration());
            builder.ApplyConfiguration(new CoverValueConfiguration());
            var themeConfiguration = new ThemeConfiguration(_isDevelopment);
            builder.ApplyConfiguration(themeConfiguration);
            var coverIssureConfiguration = new CoverIssuerEntityConfiguration(_isDevelopment);
            builder.ApplyConfiguration(coverIssureConfiguration);
            builder.ApplyConfiguration(new CoverThemeConfiguration());

            base.OnModelCreating(builder);
            builder.Entity<ChatHistory<PhilcosaUser>>(entity =>
            {
                entity.ToTable("ChatHistory");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.ChatHistoryFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.ChatHistoryToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            builder.Entity<PhilcosaUser>(entity =>
            {
                entity.ToTable(name: "Users", "Identity");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<BlazorHeroRole>(entity =>
            {
                entity.ToTable(name: "Roles", "Identity");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Identity");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity");
            });

            builder.Entity<BlazorHeroRoleClaim>(entity =>
            {
                entity.ToTable(name: "RoleClaims", "Identity");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity");
            });
        }
    }
}