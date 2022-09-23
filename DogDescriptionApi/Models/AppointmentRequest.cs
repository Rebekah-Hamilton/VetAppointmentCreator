using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DogDescriptionApi.Models
{
    public class AppointmentRequest
    {
        [DataMember(Name = "petName")]
        [Required]
        public virtual string PetName { get; set; }

        [DataMember(Name = "ownerFirstName")]
        [Required]
        public virtual string OwnerFirstName { get; set; }

        [DataMember(Name = "ownerLastNameName")]
        [Required]
        public virtual string OwnerLastName { get; set; }

        [DataMember(Name = "dogBreed")]
        [EnumDataType(typeof(DogBreeds))]
        [Required]
        public virtual DogBreeds DogBreed { get; set; }

        [DataMember(Name = "visitReason")]
        [EnumDataType(typeof(VisitReason))]
        [Required]
        public virtual VisitReason VisitReason { get; set; }

        [DataMember(Name = "appointmentDate")]
        [Required]
        public virtual DateTime AppointmentDate { get; set; }
    }
}
