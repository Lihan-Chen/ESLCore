using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models.BusinessEntities
{
    /// <summary>
    /// The Facility class represents a Facility that belongs to a <see cref="Facility"> Facilility</see>.
    /// </summary>
    [NotMapped]
    public partial record Facil
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectFieldAttribute(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the Facility Name [VARCHAR2(40)] of the Facility.
        /// </summary>
        [DataObjectField(false, true, false)]
        [DisplayName("Facility")]
        public string FacilName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Facility Abbreviation [VARCHAR2(8)] of the Facility.
        /// </summary>
        [DataObjectField(false, true, false)]
        [DisplayName("Abreviation")]
        public string FacilAbbr { get; set; } = null!;

        #endregion

    }
}
