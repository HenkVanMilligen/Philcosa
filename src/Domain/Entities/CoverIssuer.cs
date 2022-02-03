
using Philcosa.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class CoverIssuer : AuditableEntity<int>
    {
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public IList<Cover> Covers { get; set; }
    }
}
