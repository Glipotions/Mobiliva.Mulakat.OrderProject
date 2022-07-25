namespace Mobiliva.Mulakat.Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {

        public DataResult(T data, Status status, string message) : base(status, message)
        {
            Data = data;
        }

        public DataResult(T data, Status status) : base(status)
        {
            Data = data;
        }

        public T Data { get; }

    }
}
