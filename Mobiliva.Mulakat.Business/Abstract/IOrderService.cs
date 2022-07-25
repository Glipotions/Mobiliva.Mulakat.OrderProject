namespace Mobiliva.Mulakat.Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(CreateOrderRequestDto order);
    }
}
