

using Newtonsoft.Json;

namespace DogDescriptionApi.Models
{
    public class DogBreeds
    {
        public enum Breeds
        {
            Corgi = 0,
            Terrier = 1,
            Schnauzer = 2,
            Rottweiler = 3,
            Chihuahua = 4,
            ShibaInu = 5
        }

        public List<string> GetDogBreeds()
        {
            var list = Enum.GetNames(typeof(Breeds)).ToList();
            return list;
        }
    }

}
