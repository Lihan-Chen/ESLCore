using ESL.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models.BusinessEntities
{
    public partial record UserSession
    {
        public UserSession() { }

        public Guid SessionID { get; set; }

        public string? UserName { get; set; }

        public string? UserID { get; set; }

        // used to redirect to log in if not authenticated
        public bool IsAuthenticated { get; set; } = false;

        public string[] UserRole { get; set; } = null!;

        public int? ShiftNo { get; set; } //= System.Web.HttpContext.Current.Session["ShiftNo"].ToString();

        public string ShiftName => ShiftNo == 1 ? "Day" : ShiftNo == 2 ? "Night" : string.Empty;

        public string? OperatorType { get; set; }

        public int FacilNo { get; set; } = 1;

        public string FacilName => PlantsDictionary.Plants[FacilNo].PlantName; //.GetPlant(FacilNo).PlantName;

        // User is logged in when the authenticated has selected a plant, shift and operatory type
        // updated on the httppost action of HomeController's Login Method
        public bool UserLoggedIn;

        public SessionState UserSessionState;

        public DateTimeOffset SessionStart { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? SessionEnd { get; set; }

    }

    //public record Plant(string PlantName, string PlantAbbr, string PlantType, string PlantFullName);

    //public class PlantsDictionary
    //{
    //    public int PlantNo;

    //    public static Dictionary<int, Plant> Plants = new Dictionary<int, Plant>()
    //    {
    //        {  1, new Plant("OCC", "OCC", "OCC", "Operations Control Center") },
    //        {  2, new Plant("Diemer TP", "DmrTP", "TP", "Diemer Treatment Plant") },
    //        {  3, new Plant("Jensen TP", "JWTP", "TP", "Jensen Treatment Plant") },
    //        {  4, new Plant("Mills TP", "MilTP", "TP", "Mills Treatment Plant") },
    //        {  5, new Plant("Weymouth TP", "WeyTP", "TP", "Weymouth Treat Plant") },
    //        {  6, new Plant("Skinner TP", "SknTP", "TP", "Skinner Treat Plant") },
    //        {  7, new Plant("Desert OCC", "DsOCC", "DsOCC", "Desert Operations Control Center") },
    //        {  8, new Plant("Intake PP", "InPP", "PP", "Intake Pumping Plant") },
    //        {  9, new Plant("Gene PP", "GePP", "PP", "Gene Pumping Plant") },
    //        { 10, new Plant("Iron PP", "IrPP", "PP", "Operations Control Center") },
    //        { 11, new Plant("Eagle PP", "EaPP", "PP", "Eagle Mountain Pumping Plant") },
    //        { 12, new Plant("Hinds PP", "HiPP", "PP", "Hinds Pumping Plant") },
    //        { 13, new Plant("DVL", "DVL", "DVL", "Diamond Valley Lake") }
    //    };
    //}
}

