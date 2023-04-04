using System.ComponentModel;

namespace UB_BikeRental.HelperClasses
{
    public enum ReservationResultStatus​
    {
        [Description("Błąd")]
        Error = 0,

        [Description("Sukces")]
        Success = 1,

        [Description("Anulowano")]
        Canceled = 2,

        [Description("Odrzucono")]
        Rejected = 3,

        [Description("Zamknieto i zaplacono")]
        ClosedAndPaid = 3,

        [Description("Ostrzeżenie")]
        Warning,

        [Description("Informacja")]
        Info,
    }
    public class ReservationStatus
    {
        public ReservationResultStatus ReservationResult { get; set; }
        public ICollection<String> Messages { get; set; }
        public ReservationStatus() 
        { 
            Messages = new List<String>();
            ReservationResult = ReservationResultStatus.Success;
        }
        public static ReservationStatus Canceled()
        {
            var status = new ReservationStatus { 
                ReservationResult = ReservationResultStatus​.Canceled, 
                Messages = new List<String>(new string[] { "Anulowano" }) };
            return status;
        }

        public static ReservationStatus Rejected()
        {
            var status = new ReservationStatus
            {
                ReservationResult = ReservationResultStatus​.Rejected,
                Messages = new List<String>(new string[] { "Odrzucono" })
            };
            return status;
        }

        public static ReservationStatus ClosedAndPaid()
        {
            var status = new ReservationStatus
            {
                ReservationResult = ReservationResultStatus​.ClosedAndPaid,
                Messages = new List<String>(new string[] { "Zamknięto i zaplacono" })
            };
            return status;
        }
    }
}