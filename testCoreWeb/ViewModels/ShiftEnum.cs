using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace testCoreWeb.ViewModels
{
    public enum ShiftEnum
    {
        [Display(Name = "Day Shift 06:00 - 17:59")]
        Day = 1,

        [Display(Name = "Night Shift 18:00 - 05:59 +1 Day")]
        Night = 2,
    }
}
