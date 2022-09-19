using DogDescriptionApi.Models;
using DogDescriptionApi.Processors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.ComponentModel.DataAnnotations;

namespace DogDescriptionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogAppointmentController : ControllerBase
    {
        public readonly DogBreeds _dogBreeds;
        public readonly ProcessModel _processModel;

        public DogAppointmentController (DogBreeds dogBreeds, ProcessModel processModel)
        {
            _dogBreeds = dogBreeds;
            _processModel = processModel;
        }

        [HttpGet("GetDogBreeds")]
        [SwaggerResponse(200, "Succesful Operation", typeof(DogAppointmentController))]
        [SwaggerResponse(400, "Bad Request - There was an error in your request", typeof(DogAppointmentController))]
        [SwaggerResponse(500, "Server Error - An error occurred on the server Please try your request again.", typeof(DogAppointmentController))]
        public List<string> GetBreeds()
        {
            return _dogBreeds.GetDogBreeds();
        }

        [HttpGet("GetDogAppointments")]
        [SwaggerResponse(200, "Succesful Operation", typeof(DogAppointmentController))]
        [SwaggerResponse(400, "Bad Request - There was an error in your request", typeof(DogAppointmentController))]
        [SwaggerResponse(500, "Server Error - An error occurred on the server Please try your request again.", typeof(DogAppointmentController))]
        public IEnumerable<Models.DogAppointments> GetDogAppointments([Required] Models.DogAppointments dogAppointments)
        {
            var appointmentList = new List<DogAppointments>();
            return appointmentList;
        }

        [HttpPost("PostDogAppointment")]
        [SwaggerResponse(200, "Succesful Operation", typeof(DogAppointmentController))]
        [SwaggerResponse(400, "Bad Request - There was an error in your request", typeof (DogAppointmentController))]
        [SwaggerResponse(500, "Server Error - An error occurred on the server Please try your request again.", typeof(DogAppointmentController))]
        public string CreateDogAppointment([Required] AppointmentRequest dogAppointmentRequest)
        {
            var response = _processModel.Validate(dogAppointmentRequest);
            return response;
        }

    }
}
