using System.ComponentModel;

namespace UB_BikeRental.HelperClasses
{
    public enum ServiceResultStatus​
    {
        [Description("Błąd")]
        Error = 0,

        [Description("Sukces")]
        Success = 1,

        [Description("Ostrzeżenie")]
        Warning,

        [Description("Informacja")]
        Info,
    }

    public class ServiceResult​
    {
        public ServiceResultStatus Result { get; set; }
        public ICollection<String> Messages { get; set; }
        public ServiceResult()
        {
            Result = ServiceResultStatus.Success;
            Messages = new List<String>();
        }

        public static Dictionary<String, ServiceResult> CommonResults { get; set; } =
            new Dictionary<string, ServiceResult>()
            {
                {"NotFound", new ServiceResult() {
                Result = ServiceResultStatus.Error,
                Messages = new List<String>( new string[] {"Nie znaleziono obiektu"}) } },
                {"OK", new ServiceResult() {
                Result = ServiceResultStatus.Success,
                Messages = new List<String>()} }
            };
    }
}