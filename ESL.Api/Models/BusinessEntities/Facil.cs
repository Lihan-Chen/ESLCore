using System.ComponentModel;

namespace ESL.Api.Models.BusinessEntities
{
    /// <summary>
    /// The Facility class represents a Facility that belongs to a <see cref="Facility"> Facilility</see>.
    /// </summary>
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
        public string FacilName { get; set; }

        /// <summary>
        /// Gets or sets the Facility Abbreviation [VARCHAR2(8)] of the Facility.
        /// </summary>
        [DataObjectField(false, true, false)]
        [DisplayName("Abreviation")]
        public string FacilAbbr { get; set; }

        #endregion

    }
}
