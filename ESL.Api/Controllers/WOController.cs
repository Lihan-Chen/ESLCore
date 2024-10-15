using ESL.Api.Models.BusinessEntities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESL.Api.Controllers
{
    //[Route("api/[controller]")]
    [RoutePrefix("wo")]
    [ApiController]
    public class WOController : ControllerBase
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("")]
        [HttpPost]
        public void Post([FromBody]string strWo) //
        {
            // As defined in the request body in Fiddler 4
            // strWo = "{ 'created_by': 'WOES MWD', 'created_date': '2023-06-21', 'requested_by': 'Stephen Ma', 'requested_to': 'Evan Ho', 'requested_date': '2023-06-21',  'requested_time': '08:00', 'event_date': 2023-06-21', 'event_time': '08:32', 'meter_id': 'LB-01', 'new_value':85, 'old-value': 11,  'facilno': 1 }";

            WO myWO = JsonConvert.DeserializeObject<WO>(strWo);

            // Update OldValue regardless
            // myWO.OldValue = MeterManager.GetMeterReading(myWO.MeterID).Value ?? 0;

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                if (ModelState.IsValid)
                {
                    FlowChange flowchange = WoToFlowChange(myWO);

                    string FlowChange_Returned = FlowChangeDB.Update(myFlowChange, _modifyFlag);
                    //myTransactionScope.Completer();
                    return FlowChange_Returned;

                    // string _msg = WOManager.Update(myWO);
                    //HttpContext.Current.Response.AppendHeader("Update Status", "This item is added.");
                    //response.StatusCode = HttpStatusCode.Created;
                    ////string uri = Url.Route("DefaultApi", new { id = item.ID });
                    //response.Headers.Location = new Uri(Request.RequestUri, "/");
                    return Ok(myWO);
                }
                else
                {
                    return BadRequest(); // Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (DataException e)
            {
                HttpContext.Current.Response.AppendHeader("MyStatus", "Unable to complete the update action: " + e.Message);
                response = new HttpResponseMessage(HttpStatusCode.NotModified);
                return NotFound();// return new HttpResponseException(HttpStatusCode.SeeOther);
            }
        }

        private FlowChange WoToFlowChange(WO myWO)
        {
            // set logTypeNo for FlowChange type
            const int _logTypeNo = 5;

            string _unit = "CFS";

            string _modifyFlag = "Created";

            string _accepted = "Y";

            CultureInfo _provider = CultureInfo.InvariantCulture;

            string _operatorType = "Primary";

            DateTime _date = DateTime.Now;  // DateTime.ParseExact(dateString, "MM-dd-yyyy", provider)

            DateTime _midnight = _date.Date;

            int _yr = Convert.ToInt32(_midnight.ToString("yy")); // DateTime.Now.Year.ToString().Substring(2);

            string _strYr = _yr.ToString();

            int _shiftNo = DateTime.Now >= _midnight.AddHours(6) && DateTime.Now <= _midnight.AddHours(18) ? 1 : 2;

            //string OperatorFullName = Helpers.GetEmpFullName("FullName", 6337, 1);

            int _nextSeqNo = FlowChangesController.GetMaxSeqNo(myWO.FacilNo, _yr) + 1;
            
            // decimal? _oldValue = myWO.OldValue ?? MeterDB.GetMeter(myWO.MeterID).Value;
            decimal? _oldValue = MeterManager.GetMeterReading(myWO.MeterID).Value ?? 0;
            
            string _eventID = _strYr + "-" + _nextSeqNo.ToString("D5");

            FlowChange myFlowChange = new FlowChange()
            {

                // BaseEvent
                FacilNo = myWO.FacilNo,
                LogTypeNo = _logTypeNo,
                Yr = _strYr,
                SeqNo = _nextSeqNo, // FlowChangeDB.GetMaxSeqNo(myWO.FacilNo, _yr),
                EventID = _eventID, // taken care of by stored procedures
                EventID_RevNo = -1,
                OperatorType = _operatorType,
                OperatorID = Helpers.GetEmpID(myWO.UpdatedBy),
                CreatedBy = Helpers.GetEmpID(myWO.UpdatedBy),
                CreatedDate = DateTime.Now, // DateTime.ParseExact(myWO.RequestedDate, "yyyy-MM-dd", provider),
                ModifyFlag = _modifyFlag,
                ShiftNo = _shiftNo,
                UpdatedBy = myWO.UpdatedBy,
                UpdateDate = DateTime.Now,

                // FlowChange
                RequestedBy = Helpers.GetEmpID(myWO.RequestedBy),

                RequestedTo = Helpers.GetEmpID(myWO.RequestedTo),
                RequestedDate = DateTime.ParseExact(myWO.RequestedDate, "yyyy-MM-dd", _provider),
                RequestedTime = myWO.RequestedTime,

                EventDate = DateTime.ParseExact(myWO.EventDate, "yyyy-MM-dd", _provider),
                EventTime = myWO.EventTime,
                OffTime = myWO.OffTime ?? string.Empty,
                MeterID = myWO.MeterID,
                NewValue = myWO.NewValue,
                Unit = _unit,
                OldValue = _oldValue,
                OldUnit = _unit,
                ChangeBy = (myWO.NewValue - _oldValue).ToString(),
                ChangeByUnit = _unit,
                Accepted = _accepted
            };

        }

    }
}
