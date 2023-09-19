using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.Data.Entities;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Managers
{
    public class OrderDetailManager:IOrderDetailService
    {
        private readonly IRepository<OrderDetailEntity> _orderDetailRepository;
        public OrderDetailManager(IRepository<OrderDetailEntity> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public void AddOrderDetail(AddOrderDetailDto orderDetail)
        {
            var entity = new OrderDetailEntity()
            {
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price,
                OrderId = orderDetail.OrderId,
                ImagePath = orderDetail.ImagePath,


            };
            _orderDetailRepository.Add(entity);


        }

        public void DeleteOrderDetail(int id)
        {
            _orderDetailRepository.Delete(id);
        }

        public void EditOrderDetail(EditOrderDetailDto orderDetail)
        {
            var entity = new OrderDetailEntity()
            {
                Id = orderDetail.Id,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price,
                OrderId = orderDetail.OrderId,
                ImagePath = orderDetail.ImagePath

            };
            _orderDetailRepository.Update(entity);

        }

        public List<ListOrderDetailDto> GetAllOrders()
        {
            var list = _orderDetailRepository.GetAll();

            var listDto = list.Select(x => new ListOrderDetailDto()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Price = x.Price,
                OrderId = x.OrderId,
                ImagePath = x.ImagePath,
                TotalPrice = +x.Product.UnitPrice



            }).ToList();

            return listDto;



        }

        public GetOrderDetailDto GetOrderDetail(int id)
        {
            var entity = _orderDetailRepository.GetById(id);
            var dto = new GetOrderDetailDto()
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                Price = entity.Price,
                OrderId = entity.OrderId,
                ImagePath = entity.ImagePath

            };

            return dto;


        }
    }
}
