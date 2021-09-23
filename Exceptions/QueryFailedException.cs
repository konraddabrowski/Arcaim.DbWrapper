using Microsoft.AspNetCore.Http;

namespace Arcaim.DbWrapper.Exceptions
{
    public class QueryFailedException : DapperException
    {
        public override string Code => "query_failed";

        public override int StatusCode => StatusCodes.Status500InternalServerError;

        private QueryFailedException(string message) : base(message)
        {
        }
        
        private static QueryFailedException CreateQueryFailedException(string message)
            => new QueryFailedException(message);

        public static QueryFailedException Create(string message)
            => CreateQueryFailedException(message);
    }
}