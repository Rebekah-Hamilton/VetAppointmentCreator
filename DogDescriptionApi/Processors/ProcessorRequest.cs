using DogDescriptionApi.Controllers;
using DogDescriptionApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace DogDescriptionApi.Processors
{
    public class ProcessorRequest
    {
        public ControllerBase Controller { get; set; }
        public AppointmentRequest Request { get; set; }
        public HttpRequestMessage RequestMessage { get; set; }
    }
}
