using DogDescriptionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DogDescriptionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogAppointments : ControllerBase
    {
        public readonly DogBreeds _dogBreeds;

        public DogAppointments (DogBreeds dogBreeds)
        {
            _dogBreeds = dogBreeds;
        }

        [HttpGet("GetDogBreeds")]
        public List<string> GetBreeds()
        {
            return _dogBreeds.GetDogBreeds();
        }

        [HttpGet("GetDogAppointments")]
        public IEnumerable<Models.DogAppointments> GetDogAppointments([Required] Models.DogAppointments dogAppointments)
        {
            //IEnumerable<DogAppointments> list = new IEnumerable<DogAppointments>("this is an item," "this is anotheritem");
            return null;
        }

        [HttpPut("PutDogAppointment")]
        public string CreateDogAppointment()
        {
            var Test = "Testing";
            return Test;
            
        }

    }
}
