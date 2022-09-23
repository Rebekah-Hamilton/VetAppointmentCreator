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
            if (request.VisitReason == null || request.DogBreed == null)
            {
                return "the requested breed or visitReason cannot be scheduled currently";
            }

            return request.ToString();
        }
    }
}
