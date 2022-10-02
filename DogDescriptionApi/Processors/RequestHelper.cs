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
            var acceptedBreed = DogIsInDataBase(dogBreed);
            var acceptedReason = VisitIsValid(VisitReason);
            if (acceptedBreed && acceptedReason)
            {
                return new AppointmentRequest
                {
                    DogBreed = _dogBreeds.GetMatchingBreed(dogBreed),
                    PetName = PetName,
                    OwnerFullName = OwnerFullName,
                    VisitReason = _visitReasons.GetReason(VisitReason)
                };
            }
            if (acceptedBreed)
            {
                return new AppointmentRequest
                {
                    DogBreed = _dogBreeds.GetMatchingBreed(dogBreed),
                    PetName = PetName,
                    OwnerFullName = OwnerFullName,
                };
            }
            if (acceptedReason)
            {
                return new AppointmentRequest
                {
                    PetName = PetName,
                    OwnerFullName = OwnerFullName,
                    VisitReason = _visitReasons.GetReason(VisitReason)
                };
            }

            return new AppointmentRequest
            {
                PetName = PetName,
                OwnerFullName = OwnerFullName,
            };
        }
        public bool DogIsInDataBase(string dogBreed)
        {
            if (Enum.TryParse(typeof(Breeds), dogBreed, true, out var dogBreeds))
            {
                return true;
            }
            return false;

        }
        public bool VisitIsValid(string visitReason)
        {
            if (Enum.TryParse(typeof(VisitReason), visitReason, true, out var reason))
            {
                return true;
            }
            return false;
        }
    }
}
