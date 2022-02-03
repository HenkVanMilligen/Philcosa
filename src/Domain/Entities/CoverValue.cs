
using Philcosa.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class CoverValue : AuditableEntity<int>
    {
        //public int CollectableId { get; set; }

        //public Collectable Collectable { get; set; }
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        
        public IList<Cover> Covers { get; set; }
    }
}
