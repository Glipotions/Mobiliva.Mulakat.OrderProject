namespace Mobiliva.Mulakat.Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, Status.Success, message)
        {

        }

        public SuccessDataResult(T data) : base(data, Status.Success)
        {

        }

        public SuccessDataResult(string message) : base(default, Status.Success, message)
        {

        }
        public SuccessDataResult() : base(default, Status.Success)
        {

        }

    }
}
