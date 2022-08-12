
namespace Mobiliva.Mulakat.Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        //public Result(Status status)
        //{
        //    //Status = status;
        //    StatusName = status.ToString();
        //}

        //public Result(Status status, string message) : this(status)
        //{
        //    Message = message;
        //}

        //public Status Status { get; }
        public bool Success { get; set; }

        //public string StatusName { get; set; }

        public string Message { get; }
    }
}