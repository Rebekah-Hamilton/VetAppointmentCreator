using DogDescriptionApi.Models;
using System.Web.Http;

namespace DogDescriptionApi.Processors
{
    public class ProcessModel
    {
        public IEnumerable<DogAppointments> listOfAppointments { get; set; }

        public ProcessModel(AppointmentRequest request)
        {

        }

        public string Validate(AppointmentRequest request)
        {

            if (request == null)
            {
                return "the request is invalid";
            }
            var isBreedAllowed = dogIsInDataBase(request.DogBreed.ToString());
            if (!isBreedAllowed)
            {
                return "the requested breed cannot be scheduled currently";
            }

            return request.ToString();
        }

        public bool dogIsInDataBase(string dogBreed)
        {
             if (Enum.TryParse(typeof(Breeds), dogBreed, true, out var dogBreeds))
            {
                return true;
            }
            return false;
            
        }
    }
}
