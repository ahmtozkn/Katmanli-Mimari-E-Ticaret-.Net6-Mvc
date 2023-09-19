using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.Data.Entities;
using FirstShop.Data.Enums;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Managers
{
    public class OrderManager:IOrderService
    {
        private readonly IRepository<OrderEntity> _orderRepository;


        public OrderManager(IRepository<OrderEntity> orderRepository)
        {
            _orderRepository = orderRepository;

        }

        public int AddOrder(AddOrderDto cart)
        {
            var entity = new OrderEntity()
            {
                UserId = cart.UserId,
                OrderStatus = OrderStatusEnum.Hazırlanıyor,
                AddressId = cart.AddressId,
                PaymentMethodId = cart.PaymentMethodId,


            };
            _orderRepository.Add(entity);

            return entity.Id;

        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);

        }

        public void EditOrder(GetOrderDto order)
        {
            var orderentiy = _orderRepository.GetById(order.Id);




            orderentiy.UserId = order.UserId;
            orderentiy.OrderStatus = order.OrderStatus;
            orderentiy.CreatedDate = order.CreatedDate;
            orderentiy.AddressId = order.AddressId;
            orderentiy.PaymentMethodId = order.PaymentMethodId;

            _orderRepository.Update(orderentiy);


        }

        public GetOrderDto GetOrder(int id)
        {
            var entity = _orderRepository.GetById(id);
            var getDto = new GetOrderDto()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                OrderStatus = entity.OrderStatus,
                CreatedDate = entity.CreatedDate,
                AddressId = entity.AddressId,
                PaymentMethodId=entity.PaymentMethodId

            };


            return getDto;

        }

        public List<ListOrderDto> GetOrders()
        {
            var entity = _orderRepository.GetAll();

            var listOrderDto = entity.Select(x => new ListOrderDto()
            {
                Id = x.Id,
                UserId = x.UserId,
                OrderStatus = x.OrderStatus,
                CreatedDate = x.CreatedDate,
                UserName = x.User.FirstName + " " + x.User.LastName,
                AddressId = x.AddressId,
                Address = x.Address.Adres,
                PaymentMethodId = x.PaymentMethodId,
                PaymentMethodName = x.PaymentMethod.PaymentMethodName.ToString(),



            }).ToList();
            return listOrderDto;




        }
    }
}
