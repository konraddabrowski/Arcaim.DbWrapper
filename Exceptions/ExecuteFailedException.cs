using Microsoft.AspNetCore.Http;

namespace Arcaim.DbWrapper.Exceptions
{
    public class ExecuteFailedException : DapperException
    {
        public override string Code => "query_failed";

        public override int StatusCode => StatusCodes.Status500InternalServerError;

        private ExecuteFailedException(string message) : base(message)
        {
        }
        
        private static ExecuteFailedException CreateExecuteFailedException(string message)
            => new ExecuteFailedException(message);

        public static ExecuteFailedException Create(string message)
            => CreateExecuteFailedException(message);
    }
}