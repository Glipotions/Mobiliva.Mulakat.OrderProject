namespace Mobiliva.Mulakat.Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(Status.Success, message)
        {

        }

        public SuccessResult() : base(Status.Success)
        {

        }

    }
}
