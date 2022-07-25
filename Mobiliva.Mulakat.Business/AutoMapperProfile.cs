using AutoMapper;

namespace Mobiliva.Mulakat.Business
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateOrderRequestDto, Order>()
                .ForMember(x=>x.OrderDetails,y=>y.MapFrom(z=>z.ProductDetails));
            CreateMap<Order, CreateOrderRequestDto>();
            //.ForMember(x => x.ProductDetails, y => y.MapFrom(z => z.OrderDetails));
            CreateMap<Order, OrderResponseDto>();
            CreateMap<ProductDetailDto, OrderDetail>();
        }
    }
}
