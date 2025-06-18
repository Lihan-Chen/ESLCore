using ESL.Core.Models.Enums;
using ESL.Infrastructure.DataAccess;
using ESL.Mvc.ViewModels;

public static class SessionExtensions
{
    public static bool ValidateDbContext(this ISession session, EslDbContext context)
    {
        if (context == null || !context.Database.CanConnect())
        {
            session.Clear();
            return false;
        }

        return true;
    }

    public static OnDutyViewModel GetOnDutyInfo(this ISession session)
    {
        var employeeNo = session.GetInt32("EmployeeNo");
        var plantId = session.GetInt32("PlantId");

        if (!employeeNo.HasValue || !plantId.HasValue)
        {
            throw new InvalidOperationException("Session not properly initialized");
        }

        return new OnDutyViewModel
        {
            EmployeeNo = session.GetInt32("EmployeeNo") ?? 0,

            UserRole = session.GetString("UserRole") ?? "Operator",

            SelectedShift = Enum.Parse<Shift>(
                session.GetString("Shift") ?? "Day"),

            SelectedOperatorType = Enum.Parse<OperatorType>(
                session.GetString("SelectedOperatorType") ?? "Primary"),

            SelectedPlantId = plantId.Value,

            // IsAuthenticated = true
        };
    }

    //ToDo: revise session key names based on the base controller constants
    public static bool HasValidOnDutySession(this ISession session)
    {
        return session.GetInt32("EmployeeNo").HasValue &&
               session.GetInt32("PlantId").HasValue &&
               !string.IsNullOrEmpty(session.GetString("UserRole")) &&
               !string.IsNullOrEmpty(session.GetString("Shift")) &&
               !string.IsNullOrEmpty(session.GetString("SelectedOperatorType"));
    }
}