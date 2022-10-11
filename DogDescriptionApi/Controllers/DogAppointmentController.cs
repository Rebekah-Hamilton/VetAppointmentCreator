using DogDescriptionApi.Models;
using DogDescriptionApi.Processors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.Http.Controllers;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DogDescriptionApi.Controllers
{
    [ApiController]
    public class DogAppointmentController : ControllerBase
    {
        public readonly DogBreeds _dogBreeds;
        public readonly AppointmentProcessor _apptProcessor;
        public readonly VisitReasons _visitReasons;
        public readonly RequestHelper _requestHelper;

        public DogAppointmentController (DogBreeds dogBreeds, 
            AppointmentProcessor apptProcessor,
            VisitReasons visitReasons,
            RequestHelper requestHelper)
        {
            _dogBreeds = dogBreeds;
            _apptProcessor = apptProcessor;
            _visitReasons = visitReasons;
            _requestHelper = requestHelper;
        }

        [HttpGet]
        [Route("GetBreeds")]
        [SwaggerResponse(200, "Succesful Operation", typeof(DogAppointmentController))]
        [SwaggerResponse(400, "Bad Request - There was an error in your request", typeof(DogAppointmentController))]
        [SwaggerResponse(500, "Server Error - An error occurred on the server Please try your request again.", typeof(DogAppointmentController))]
        public List<string> GetBreeds()
        {
            return _dogBreeds.GetDogBreeds();
        }

        [HttpGet]
        [Route("GetDogAppointments")]
        [SwaggerResponse(200, "Succesful Operation", typeof(DogAppointmentController))]
        [SwaggerResponse(400, "Bad Request - There was an error in your request", typeof(DogAppointmentController))]
        [SwaggerResponse(500, "Server Error - An error occurred on the server Please try your request again.", typeof(DogAppointmentController))]
        public IEnumerable<Models.DogAppointments> GetDogAppointments([Required] Models.DogAppointments dogAppointments)
        {
            var appointmentList = new List<DogAppointments>();
            return appointmentList;
        }

        [HttpPost]
        [Route("CreateAppointment")]
        [SwaggerResponse(200, "Succesful Operation", typeof(DogAppointmentController))]
        [SwaggerResponse(400, "Bad Request - There was an error in your request", typeof(DogAppointmentController))]
        [SwaggerResponse(500, "Server Error - An error occurred on the server Please try your request again.", typeof(DogAppointmentController))]
        public async Task<IHttpActionResult> CreateDogAppointment([Required] string dogBreed, string PetName, string OwnerFullName, string VisitReason)
        {
            var request = _requestHelper.CreateAppointmentRequest(dogBreed, PetName, OwnerFullName, VisitReason);
            var appointmentProcessorRequest = new ProcessorRequest
            {
                Controller = this,
                Request = request,
                RequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent("CreateAppointment")
                }
            };
            var response = await _apptProcessor.Execute(appointmentProcessorRequest);
            return response;
        }

        [HttpGet]
        [Route("GetVisitReasons")]
        [SwaggerResponse(200, "Succesful Operation", typeof(DogAppointmentController))]
        [SwaggerResponse(400, "Bad Request - There was an error in your request", typeof(DogAppointmentController))]
        [SwaggerResponse(500, "Server Error - An error occurred on the server Please try your request again.", typeof(DogAppointmentController))]
        public List<string> GetVisitReason()
        {
            return _visitReasons.GetVisitReasons();
        }


    }
}
