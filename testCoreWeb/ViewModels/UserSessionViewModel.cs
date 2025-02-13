using ESL.Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace testCoreWeb.ViewModels
{
    public class UserSessionViewModel
    {
        public string UserID { get; set; }

        public string UserName { get; set; } = string.Empty;
        
        public int?  FacilNo {  get; set; }

        public string? FacilName { get; set; }

        public string? Shift { get; set; }

        public string? OperatorType {  get; set; }
    }
}
