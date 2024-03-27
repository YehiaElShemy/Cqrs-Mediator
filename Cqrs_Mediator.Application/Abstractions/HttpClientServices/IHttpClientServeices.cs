using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Mediator.Application.Abstractions.HttpClientServices
{
    public interface IHttpClientServeices
    {
        Task<TResponse> PostRequest<TResponse>(string url, HttpMethod method = default, TResponse data = default);
        Task<TResponse> GetRequestById<TResponse>(string url, string id);
        Task<TResponse> DeleteRequestbyid<TResponse>(string url, string id);
    }

}
