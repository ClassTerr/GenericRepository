using System.Net;

namespace GenericRepository.Common.Contracts.Exceptions;

/// <summary>
/// Error object or exception with this interface is capable to identify HTTP status code.
/// </summary>
public interface IHttpStatusCodeSource
{
    /// <summary>Gets HTTP Status Code.</summary>
    public HttpStatusCode StatusCode { get; }
}
