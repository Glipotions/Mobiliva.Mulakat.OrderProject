namespace Mobiliva.Mulakat.Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(Status.Failed, message)
        {

        }

        public ErrorResult() : base(Status.Failed)
        {

        }
    }
}