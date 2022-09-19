using System.Web.Http;

namespace DogDescriptionApi.Processors
{
    public interface IProcessor
    {
        Task<HttpResponseMessage> Execute();
    }
}
