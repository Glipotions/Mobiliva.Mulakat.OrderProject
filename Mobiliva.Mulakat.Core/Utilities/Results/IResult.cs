using Mobiliva.Mulakat.Core.Enums;

namespace Mobiliva.Mulakat.Core.Utilities.Results
{
    public interface IResult
    {
        //bool Success { get; }
        Status Status { get; }
        string Message { get; }
    }
}
