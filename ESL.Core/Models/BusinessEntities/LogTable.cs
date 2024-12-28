using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models.BusinessEntities
{
    public partial record LogTable
    {
        [Key]
        public decimal LogTypeNo { get; set; }

        public string? LogTableName { get; set; }
    }

}
