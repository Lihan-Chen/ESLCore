using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Application.Models
{
    public record LogFilterPartialModel
    {
        public int? FacilNo { get; set; }

        public int? LogTypeNo { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public string? SearchString { get; set; }

        public bool? IsPrimaryOperator { get; set; }
    }
}
