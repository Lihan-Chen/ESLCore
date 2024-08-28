using ESL.Api.Models.BusinessEntities;
using System.Linq.Expressions;
using System.ComponentModel;

namespace ESL.Api.Models.IRepositories
{
    public interface IMeterRepository
    {
        /// <summary>
        /// Gets a list with Meter objects.
        /// Maps to public static MeterList GetList(int facilNo)
        /// </summary>
        /// <param name="meterID">The ID of Meter for whom the FacilList should be returned.</param>
        /// <returns>A list with Meter objects when the database contains FlowChangees for the parameters specified,
        public Task<List<Meter>?> GetList(int facilNo);

        /// <summary>
        /// Gets a single Meter from the database by its FacilNo.
        /// Maps to public static Meter GetItem(int facilNo, string meterID)
        /// </summary>
        /// <param name="facilNo">The unique Facility No. in the database.</param>
        /// <param name="meterID">The unique Meter ID in the database.</param>
        /// <returns>An Meter object when the record exists in the database, or <see langword="null"/> otherwise.</returns>
        public Task<Meter?> GetItem(int facilNo, string meterID);

        /// <summary>
        /// Saves an Meter in the database.
        /// Maps tp public static int Update(Meter myMeter, string forceUpdate)
        /// </summary>
        ///<param name="myMeter">The Meter instance to save.</param>
        ///<param name="forceUpdate">The forceUpdate flag defaults to "D"</param>
        ///<returns>The facilNo if the Meter is new in the database or the existing facilNo when an item was updated.</returns>
        public Task<string> Update(int facilNo, string meterID, Meter meter, string forceUpdate = "D");

        /// <summary>
        /// Delete an Meter in the database.
        /// Maps to public static int Delete(Meter meter)
        /// </summary>
        ///<param name="meter">The Meter instance to save.</param>
        public Task<string> Delete(int facilNo, string meterID);

        //public List<SelectListItem> GetFacilAbbrList();

        //public List<SelectListItem> GetFacilTypes(); // SelectListItem
    }
}
