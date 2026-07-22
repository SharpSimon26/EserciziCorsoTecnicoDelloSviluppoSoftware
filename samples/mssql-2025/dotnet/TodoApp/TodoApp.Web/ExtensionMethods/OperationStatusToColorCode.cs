using TodoApp.Web.Models;

namespace TodoApp.Web.ExtensionMethods;

public static class OperationStatusToColorCode
{
    public static string ToColorCode(this OperationStatus status)
    {
        string colorCode = status switch
        {
            OperationStatus.Information => "#007aff",
            OperationStatus.Success     => "#03cc00",
            OperationStatus.Warning     => "#e4b90c",
            OperationStatus.Error       => "#ff0000",
            _                           => "#000"
        };

        return colorCode;
    }
}