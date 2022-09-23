using DogDescriptionApi.Models;

namespace DogDescriptionApi.Processors
{
    public class RequestHelper
    {
        public readonly DogBreeds _dogBreeds;
        public readonly VisitReasons _visitReasons;
        public RequestHelper(DogBreeds dogBreeds,
            VisitReasons visitReasons)
        {
            _dogBreeds = dogBreeds;
            _visitReasons = visitReasons;  
        }
        public AppointmentRequest CreateAppointmentRequest(string dogBreed, string PetName, string OwnerFullName, string VisitReason)
        {
            return new AppointmentRequest
            {
                DogBreed = _dogBreeds.GetMatchingBreed(dogBreed),
                PetName = PetName,
                OwnerFullName = OwnerFullName,
                VisitReason = _visitReasons.GetReason(VisitReason)
            };
        }
    }
}
