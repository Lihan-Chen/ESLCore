using ESL.Application.Models;

namespace ESL.Mvc.Services
{
    public interface IAllEventService
    {
        /// <summary>
        /// Get a list of current all events based on the provided filter criteria, initially from query strings, and subsequently from populated logFilterPartialModel returned in a form.
        /// This task maps to AllEvents/Index Get method in the controller.
        /// Calls 
        /// </summary>
        /// <param name="logFilterPartialModel"></param>
        /// <param name="facilNo"></param>
        /// <param name="eventID"></param>
        /// <param name="eventID_RevNo"></param>
        /// <param name="eventDate"></param>
        /// <param name="eventTime"></param>
        /// <param name="subject"></param>
        /// <param name="details"></param>
        /// <param name="modifyFlag"></param>
        /// <param name="notes"></param>
        /// <param name="operatorType"></param>
        /// <param name="updatedBy"></param>
        /// <param name="updateDate"></param>
        /// <param name="clearanceID"></param>
        /// <returns>Current_AllEvent (VIEW_ALLEVENTS_CURRENT)</returns>
        // [Route("AllEvents")]
        public Task<IEnumerable<Current_AllEvent>> GetAllEventsByLogFilterPartialModel(LogFilterPartialModel logFilterPartialModel, int facilNo, string? eventID, string? eventID_RevNo, string? eventDate, string? eventTime, string? subject, string? details, string? modifyFlag, string? notes, string? operatorType, string? updatedBy, string? updateDate, string? clearanceID);

        /// <summary>
        /// Get event details (eventHighlight and eventTrail) based on the provided filter criteria.
        /// This maps to the private static GetLogDetails method in the AllEventsController.
        /// Note: switch on logTypeNo to get the correct details.
        /// </summary>
        /// <param name="_facilNo"></param>
        /// <param name="logTypeNo"></param>
        /// <param name="eventID"></param>
        /// <param name="eventID_RevNo"></param>
        /// <returns>AllEventDetailsModel (DTO) in the ESL.Application</returns>
        // [GET("Details")]
        public Task<IEnumerable<AllEventDetailsModel>> GetLogDetails(int _facilNo, int logTypeNo, string eventID, int eventID_RevNo);


        /// <summary>
        /// Get a list of current all events based on the provided filter criteria, initially from query strings, and subsequently from populated logFilterPartialModel returned in a form.
        /// Not referenced:= - This task maps to AllEvents/LogSearch Get method in the controller.
        /// </summary>
        /// <param name="facilNo"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="operatorType"></param>
        /// <returns></returns>
        // [GET("LogSearch")] =>ESL.ESL_AllEvents_Active_Proc
        public Task<IEnumerable<Current_AllEvent>> LogSearch(int facilNo, DateTime StartDate, DateTime EndDate, bool operatorType);
    }
}
