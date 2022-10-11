namespace DogDescriptionApi.Models
{
    public class ValidationErrors
    {
        public const string InvalidRequestMessage = "The Request is Invalid";
        public const string VisitReasonBreedWrong = "The requested breed or visitReason cannot be scheduled currently";
        public const string InternalServerError = "Internal Server Error. Unable to Process Request";
    }
}
