using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
//using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ESL.Core.Models.BusinessEntities
{
    [PrimaryKey(nameof(ScanSeqNo))]
    [Index(nameof(FacilNo), nameof(LogTypeNo), nameof(EventID), nameof(ScanNo), IsUnique = true, Name = "SCANLOB_DOC_IDX")]
    [Table($"ESL_SCANLOBS", Schema = "ESL")]
    public partial record ScanLob
    {
        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false)]
        [DisplayName("Scan File No.")]
        [Column("SCANSEQNO", TypeName = "NUMBER")]
        public int ScanSeqNo { get; set; }

        [DataObjectField(false, false, false, 2)]
        [DisplayName("Facility No.")]
        [Column("FACILNO", TypeName = "NUMBER")]
        public int FacilNo { get; set; }

        [DataObjectField(false, false, false, 2)]
        [Column("LOGTYPENO", TypeName = "NUMBER")]
        public int LogTypeNo { get; set; }

        [DataObjectField(false, false, false, 20)]
        [Column("EVENTID", TypeName = "VARCHAR2")]
        public string EventID { get; set; } = string.Empty;

        [DataObjectField(false, false, false, 2)]
        [DisplayName("Scanned Document No.")]
        [Column("SCANNO", TypeName = "NUMBER")]
        public int ScanNo { get; set; }

        [DataObjectField(false, false, false)]
        [DisplayName("File")]
        [Column("SCANLOB")]
        public byte[]? ScanBlob { get; set; } // = Array.Empty<byte>();

        [DataObjectField(false, false, false, 100)]
        [DisplayName("Scan Lob Type")]
        [Column("SCANLOBTYPE", TypeName = "VARCHAR2")]
        public string? ScanLobType { get; set; }


        [DataObjectField(false, false, true, 400)]
        [DisplayName("Notes")]
        [Column("NOTES", TypeName = "VARCHAR2")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the UID of the record.
        /// </summary>
        [DataObjectField(false, false, true, 60)]
        [DisplayName("Updated By")]
        [Column("UPDATEDBY", TypeName = "VARCHAR2")]
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate of the record.
        /// </summary>
        [DataObjectField(false, false, true)]
        [DisplayName("Updated on")]
        [Column("UPDATEDATE", TypeName = "DATE")]
        public DateTime? UpdateDate { get; set; }
    }
}