using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESL.Core.Models.BusinessEntities
{
    [NotMapped]
    public partial record Zone : BaseEntity<object>
    {
        public override object[] GetKeys()
        {
            return [FacilType, ZoneNo];
        }

        public int FacilNo { get; set; }

        [Key]
        public string FacilType { get; set; } = string.Empty;
       
        [Key]
        [DisplayName("Zone No.")]
        public int ZoneNo { get; set; }

        public string ZoneDescription { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public int SortNo { get; set; }

        public string? Disable { get; set; }

        //public Update Update { get; set; } = new Update();

        public string UpdatedBy { get; set; } = null!;

        public DateTimeOffset UpdateDate { get; set; }

    }
}