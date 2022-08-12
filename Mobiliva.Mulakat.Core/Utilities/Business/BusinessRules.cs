using Mobiliva.Mulakat.Core.Utilities.Results;

namespace Mobiliva.Mulakat.Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                //if (logic.Status!=Status.Success)
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
