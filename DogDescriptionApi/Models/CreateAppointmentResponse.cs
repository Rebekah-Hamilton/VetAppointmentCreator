namespace DogDescriptionApi.Models
{
    public class CreateAppointmentResponse
    {
        public DogAppointments appointment { get; set; }
        public string message { get; set; }
    }
}
