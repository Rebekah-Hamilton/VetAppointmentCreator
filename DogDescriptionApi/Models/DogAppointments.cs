namespace DogDescriptionApi.Models
{
    public class DogAppointments
    {
        public string Dogname { get; set; }
        public string OwnerName { get; set; }
        public DogBreeds Breed { get; set; }
        public DateTime AppointmentDate { get; set; }
        public VisitReason VisitReason { get; set; }
    }
}
