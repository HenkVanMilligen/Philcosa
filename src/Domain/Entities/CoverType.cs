
using Philcosa.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class CoverType : AuditableEntity<int>
    {
        [Required]
        [MaxLength(5)]
        public string Code { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        

        public IList<Cover> Covers { get; set; }
    }
}
