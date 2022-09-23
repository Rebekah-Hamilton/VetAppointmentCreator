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

        //HttpActionResult change this
        public HttpResponseMessage Validate(AppointmentRequest request)
        {

            if (request == null)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent("the request is invalid");
                return response;
            }
            if (request.VisitReason == null || request.DogBreed == null)
            {
                var response =  new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent("the requested breed or visitReason cannot be scheduled currently");
                return response;
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }
    }
}
