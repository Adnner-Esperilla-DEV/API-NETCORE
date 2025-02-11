
using System.Net;

namespace ESPERILLA.UseCases.DTOs.Interface;

public  interface IHttpStatus
{
    public HttpStatusCode HttpStatusCode { get; set; }
}
