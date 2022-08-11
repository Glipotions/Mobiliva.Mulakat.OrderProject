//using AutoMapper;
//using AutoMapper.Internal.Mappers;
using AutoMapper;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Mobiliva.Mulakat.Business.Constants;
using Mobiliva.Mulakat.Core.Aspects.Autofac.Caching;
using Mobiliva.Mulakat.Core.Utilities.MessageBrokers.RabbitMq;

namespace Mobiliva.Mulakat.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        IOrderDetailDal _orderDetailDal;
        IMapper _mapper;
        IMailSenderBackgroundService _mailSenderBackgroundService;

        public OrderManager(IOrderDal orderDal, IMapper mapper, IOrderDetailDal orderDetailDal, IMailSenderBackgroundService mailSenderBackgroundService)
        {
            _orderDal = orderDal;
            _mapper = mapper;
            _orderDetailDal = orderDetailDal;
            _mailSenderBackgroundService = mailSenderBackgroundService;
        }

        //[TransactionScopeAspect]
        public IResult Add(CreateOrderRequestDto input)
        {
            var entity = _mapper.Map<CreateOrderRequestDto, Order>(input);
            _orderDal.Add(entity);
            var result = _mapper.Map<Order, OrderResponseDto>(entity);
            
            //result.ProductDetails = input.ProductDetails;
            foreach (var item in input.ProductDetails)
            {
                var detailEntity = _mapper.Map<ProductDetailDto, OrderDetail>(item);
                detailEntity.OrderId = entity.Id;
                _orderDetailDal.Add(detailEntity);
            }

            //_mailSenderBackgroundService.SendMail($"{new Email(){ To}");
            return new SuccessDataResult<OrderResponseDto>(result, Messages.Added);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }
    }
}
