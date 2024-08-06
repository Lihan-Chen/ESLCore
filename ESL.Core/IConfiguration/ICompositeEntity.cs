using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.IConfiguration
{
    /// <summary>
    /// This is the base interface for composite key (FacilNo + IEntity) mainly for ESL parameters such as Meters.
    /// </summary>
    public interface ICompositeEntity : IEntity
    {
        public int FacilNo { get; set; }
    }
}
