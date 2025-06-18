using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Application.Models
{
    [Keyless]
    public partial record LogTypeModel // VIEW_ALLEVENTS_LOGTYPE
    {
        [Precision(2)]
        public byte LOGTYPENO { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string LOGTYPENAME { get; set; } = null!;
    }
}
