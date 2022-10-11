using DogDescriptionApi.Models;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http;

namespace DogDescriptionApi.Processors
{
    public class AppointmentProcessor
    {
        public IEnumerable<DogAppointments> listOfAppointments { get; set; }
        public List<string> errors = new List<string>();

        public AppointmentProcessor(AppointmentRequest request,
            ProcessorRequest processorRequest)
        {

        }

        //HttpActionResult change this
        public async Task<IHttpActionResult> Validate(ProcessorRequest request)
        {

            if (request?.Request == null)
            {
                return new BadRequestResult(request.RequestMessage);
            }
            if (request.Request.VisitReason == null || request.Request.DogBreed == null)
            {
                return new BadRequestResult(request.RequestMessage);
            }

            SaveToDataBaseHere(request.Request);
            return null;
        }

        public async Task<IHttpActionResult> ProcessRequest(ProcessorRequest request)
        {
            return new OkResult(request.RequestMessage);
        }

        public async Task<IHttpActionResult> Execute(ProcessorRequest request)
        {
            try
            {
                var result = await Validate(request);

                if (result != null) return result;

                return await ProcessRequest(request);
            }
            catch
            {
                return new BadRequestResult(request.RequestMessage);
                //this should probably be an internal server error not a badrequest
            }
        }

        public void SaveToDataBaseHere(AppointmentRequest request)
        {
            //code goes here
        }

    }
}
