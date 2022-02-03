using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Philcosa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Philcosa.Infrastructure.Configuration
{
    public class CoverThemeConfiguration : IEntityTypeConfiguration<CoverTheme>
    {
        public void Configure(EntityTypeBuilder<CoverTheme> builder)
        {
            builder.HasKey(pt => new { pt.CoverId, pt.ThemeId });

            builder.HasOne<Cover>(pt => pt.Cover)
                .WithMany(p => p.CoverThemes)
                .HasForeignKey(pt => pt.CoverId);

            builder.HasOne<Theme>(pt => pt.Theme)
                .WithMany(p => p.CoverTheme)
                .HasForeignKey(pt => pt.ThemeId);
            
        }
    }
}
