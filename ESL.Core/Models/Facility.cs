using ESL.Core.Models.ComplexTypes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ESL.Core.Models
{
    /// <summary>
    /// The Facility class represents a Facility that belongs to a <see cref="Facility"> Facilility</see>.
    /// </summary>
    [DebuggerDisplay("Facility: {Facility, nq}")]
    [PrimaryKey(nameof(FacilNo))]
    [Table("ESL_Facilities")]
    public partial record Facility //: IEnumerable
    {
        #region Public Properties


        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false, 3)]
        [DisplayName("Facility No.")]
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        /// <summary>
        /// Gets or sets the Facility Name [VARCHAR2(40)] of the Facility.
        /// </summary>
        [DataObjectField(false, true, false, 40)]
        [DisplayName("Facility")]
        [Column(nameof(FacilName))]
        public string FacilName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Facility Abbreviation [VARCHAR2(5)] of the Facility.
        /// </summary>
        [DataObjectField(false, true, false, 6)]
        [DisplayName("Abreviation")]
        [Column(nameof(FacilAbbr))]
        public string FacilAbbr { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Facility Type [VARCHAR2(30)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, false, 30)]
        [DisplayName("Facility Type")]
        [Column(nameof(FacilType))]
        public string FacilType { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Sort Order [NUMBER(2)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, false, 2)]
        [DisplayName("Sort Order")]
        [Column(nameof(SortNo))]
        public int? SortNo { get; set; }

        /// <summary>
        /// Gets or sets the Notes [VARCHAR2(400)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column(nameof(Notes))]
        public string? Notes { get; set; }

        //public Update Update { get; set; } = new Update();

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, false, 60)]
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the updateDate of the record.
        /// </summary>
        [DataObjectField(false, false, false)]
        [DisplayName("Updated on")]
        public DateTimeOffset UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the Disable [VARCHAR2(15)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 15)]
        [DisplayName("Disabled?")]
        [Column(nameof(Disable))]
        public string? Disable { get; set; }

        /// <summary>
        /// Gets or sets the Visible To [VARCHAR2(60)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 60)]
        [DisplayName("Visible To")]
        [Column(nameof(VisibleTo))]
        public string? VisibleTo { get; set; }

        /// <summary>
        /// Gets or sets the Facility Full Name [VARCHAR2(60)] of the Facility.
        /// </summary>
        [DataObjectField(false, false, true, 60)]
        [DisplayName("Full Name")]
        [Column(nameof(FacilFullName))]
        public string? FacilFullName { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="Employee" /> instances for the facility.
        /// </summary>
        // public virtual List<Employee> EmployeeList { get; set; } = new List<Employee>();
        
        #endregion

    }
}
