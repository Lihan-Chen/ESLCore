using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ESL.Mvc.ViewModels
{
    /// <summary>
    /// The Facility class represents a Facility that belongs to a <see cref="Facility"> Facilility</see>.
    /// </summary>
    [DebuggerDisplay("Facility: {Facility, nq}")]
    public class FacilViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectFieldAttribute(key, identity, isNullable]
        /// </summary>
        [Required]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Facility Name [VARCHAR2(40)] of the Facility.
        /// </summary>
        [DisplayName("Facility")]
        public string FacilName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Facility Abbreviation [VARCHAR2(8)] of the Facility.
        /// </summary>
        [DisplayName("Abreviation")]
        public string FacilAbbr { get; set; } = string.Empty;

        #endregion

    }
}
