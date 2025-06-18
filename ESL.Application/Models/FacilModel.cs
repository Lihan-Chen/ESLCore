using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Application.Models
{
    public partial record FacilModel
    {
        #region Public Properties

        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DisplayName("Facility")]
        public string FacilName { get; set; } = null!;

        [DisplayName("Abreviation")]
        public string FacilAbbr { get; set; } = null!;

        #endregion
    }
}
