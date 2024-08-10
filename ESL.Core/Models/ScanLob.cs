using ESL.Core.Models.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
//using ESL.Core.Models.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models
{
    [PrimaryKey(nameof(ScanLobNo))]
    [Table($"ESL_{nameof(ScanLob)}s")]
    public partial record ScanLob
    {
        /// <summary>
        /// Gets or sets the Facility No [NUMBER(3)] of the Facility.
        /// [DataObjectFieldAttribute(key, identity, isNullable]
        /// </summary>
        [DataObjectFieldAttribute(true, true, false)]
        [DisplayName("Scan File No.")]
        public int ScanLobNo { get; set; }
         
        [DataObjectFieldAttribute(false, false, false)]
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DataObjectFieldAttribute(false, false, false)]
        public int LogTypeNo { get; set; }

        [DataObjectFieldAttribute(false, false, false)]
        public string EventID { get; set; } = string.Empty;

        [DataObjectFieldAttribute(false, false, false)]
        [DisplayName("Scanned Document No.")]
        public int ScanNo { get; set; }

        [DataObjectFieldAttribute(false, false, false)]
        [DisplayName("Scan File Name")]
        public string ScanFileName { get; set; } = string.Empty;

        [DataObjectFieldAttribute(false, false, false)]
        [DisplayName("Scan File Type")]
        public string ScanLobType { get; set; } = string.Empty;

        [DataObjectFieldAttribute(false, false, false)]
        [DisplayName("File")]
        public Byte[] Blob { get; set; } = new Byte[0];

        [DataObjectFieldAttribute(false, false, true)]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        public Update Update { get; set; } = new Update();
    }
}