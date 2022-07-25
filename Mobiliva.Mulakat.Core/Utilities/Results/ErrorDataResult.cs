namespace Mobiliva.Mulakat.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        public ErrorDataResult(T data, string message) : base(data, Status.Failed, message)
        {

        }

        public ErrorDataResult(T data) : base(data, Status.Failed)
        {

        }

        public ErrorDataResult(string message) : base(default, Status.Failed, message)
        {

        }
        public ErrorDataResult() : base(default, Status.Failed)
        {

        }

    }
}
