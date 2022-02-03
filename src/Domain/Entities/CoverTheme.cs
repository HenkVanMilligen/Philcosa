using Philcosa.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Domain.Entities
{
    public class CoverTheme : AuditableEntity<int>
    {        
        public int CoverId { get; set; }
        public Cover Cover { get; set; }

        public int ThemeId { get; set; }
        public Theme Theme { get; set; }

    }
}
