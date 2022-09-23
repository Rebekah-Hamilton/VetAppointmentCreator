

using Newtonsoft.Json;

namespace DogDescriptionApi.Models
{
    public class DogBreeds
    {

        public List<string> GetDogBreeds()
        {
            var list = Enum.GetNames(typeof(Breeds)).ToList();
            return list;
        }

        public Breeds GetMatchingBreed(string dogBreed)
        {
            string selection = dogBreed.ToUpper();
            Breeds selectedBreed = (Breeds)Enum.Parse(typeof(Breeds), selection);
            return selectedBreed;
        }
    }

    public enum Breeds
    {
        CORGI = 0,
        TERRIER = 1,
        SCHNAUZER = 2,
        ROTTWEILER = 3,
        CHIHUAHUA = 4,
        SHIBAINU = 5
    }

}
