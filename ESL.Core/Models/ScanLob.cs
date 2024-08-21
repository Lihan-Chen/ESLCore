using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
//using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(ScanSeqNo))]
    [Index(nameof(FacilNo),nameof(LogTypeNo),nameof(EventID),nameof(ScanNo), IsUnique = true, Name = "SCANLOB_DOC_IDX")]
    [Table($"ESL_{nameof(ScanLob)}s")]
    public partial record ScanLob
    {
        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectField(key, identity, isNullable]
        /// </summary>
        [DataObjectField(true, true, false)]
        [DisplayName("Scan File No.")]
        [Column(nameof(ScanSeqNo))]
        public int ScanSeqNo { get; set; }
         
        [DataObjectField(false, false, false, 2)]
        [DisplayName("Facility No.")]
        
        [Column(nameof(FacilNo))]
        public int FacilNo { get; set; }

        [DataObjectField(false, false, false, 2)]
        public int LogTypeNo { get; set; }

        [DataObjectField(false, false, false, 20)]
        public string EventID { get; set; } = string.Empty;

        [DataObjectField(false, false, false, 2)]
        [DisplayName("Scanned Document No.")]
        public int ScanNo { get; set; }

        [DataObjectField(false, false, false)]
        [DisplayName("File")]
        [Column("ScanLob")]
        public byte[] Blob { get; set; } = Array.Empty<byte>();

        [DataObjectField(false, false, false, 100)]
        [DisplayName("Scan Lob Type")]
        public string ScanLobType { get; set; } = string.Empty;

        //[DataObjectField(false, false, false)]
        //[DisplayName("File")]
        //public Byte[] Blob { get; set; } = new Byte[0];

        [DataObjectField(false, false, true)]
        [DisplayName("Notes")]
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
    }
}