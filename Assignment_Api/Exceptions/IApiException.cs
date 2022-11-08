using System.Collections.Generic;

namespace Assignment_Api.Exceptions
{
    public interface IApiException
    {
            string Code { get; }
            string ServiceName { get; }
            IReadOnlyCollection<Error> Errors { get; }
    }
}
