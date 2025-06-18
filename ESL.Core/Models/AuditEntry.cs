using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models
{
    
    public class AuditEntry
    {
        // ToDo: consider using this class in the future for auditing
        public int AuditEntryId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
    }

    // https://learn.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=data-annotations
}
