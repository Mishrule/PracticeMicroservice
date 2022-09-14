using PracticeMicroservice.Web.Models;

namespace PracticeMicroservice.Web.Services.IServices
{
  public interface IBaseService: IDisposable
  {
    ResponseDto _responseModel { get; set; }
    Task<T> SendAsync<T>(ApiRequest apiRequest);
  }
}
