namespace Arcaim.DbWrapper.Exceptions
{
    public abstract class DapperException: System.Exception
    {
        public abstract string Code { get; }
        public abstract int StatusCode { get; }
        public override string Source { get => "Arcaim.DbWrapper"; }

        public DapperException(string message) : base(message)
        {
        }
    }
}