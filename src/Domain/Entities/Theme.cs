
using Philcosa.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class Theme : AuditableEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public IList<CoverTheme> CoverTheme { get; set; }
    }
}
