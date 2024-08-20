using ESL.Web.Models.BusinessEntities.ValueObjects;
using System.ComponentModel;
using System.Diagnostics;

namespace ESL.Web.Models.BusinessEntities
{
    /// <summary>
    /// The Facility class represents a Facility that belongs to a <see cref="Facility"> Facilility</see>.
    /// </summary>
    [DebuggerDisplay("Facility: {Facility, nq}")]
    public class Facility: BaseUpdate, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false, 3)]
        [DisplayName("Facility No.")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Facility Name [VARCHAR2(40)] of the Facility.
        /// </summary>
        [DataObjectField(true, true, false, 40)]
        [DisplayName("Facility")]
        public string FacilName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Facility Abbreviation [VARCHAR2(5)] of the Facility.
        /// </summary>
        [DataObjectField(false, true, false, 6)]
        [DisplayName("Abreviation")]
        public string FacilAbbr { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Facility Type [VARCHAR2(30)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, false, 30)]
        [DisplayName("Facility Type")]
        public string FacilType { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Sort Order [NUMBER(2)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, false, 2)]
        [DisplayName("Sort Order")]
        public int? SortNo { get; set; }
        //public Nullable<short> SortNo { get; set; }

        /// <summary>
        /// Gets or sets the Notes [VARCHAR2(400)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the Disable [VARCHAR2(15)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 15)]
        [DisplayName("Disable?")]
        public string? Disable { get; set; }

        /// <summary>
        /// Gets or sets the Visible To [VARCHAR2(60)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 60)]
        [DisplayName("Visible To")]
        public string? VisibleTo { get; set; }

        /// <summary>
        /// Gets or sets the Facility Full Name [VARCHAR2(60)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 60)]
        [DisplayName("Full Name")]
        public string FacilFullName { get; set; } = null!;

        /// <summary>
        /// Gets or sets a collection of <see cref="Employee" /> instances for the facility.
        /// </summary>
        public virtual List<Employee> EmployeeList { get; set; } = new List<Employee>();

        #endregion

    }
}
