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
    public class PaymentMethodManager : IPaymentMethodService
    {

        private readonly IRepository<PaymentMethodEntity> _paymentMethodRepository;
        public PaymentMethodManager(IRepository<PaymentMethodEntity> paymentMethodEntity)
        {
            _paymentMethodRepository = paymentMethodEntity;
        }

        public int AddPaymentMethod(AddPaymentMethodDto addPaymentMethodDto)
        {
            var paymentMethodEntity = new PaymentMethodEntity()
            {

                CardNumber = addPaymentMethodDto.CardNumber,
                CVV = addPaymentMethodDto.CVV,
                UserId = addPaymentMethodDto.UserId,
                ExpirationMonth = addPaymentMethodDto.ExpirationMonth,
                ExpirationYear = addPaymentMethodDto.ExpirationYear,
                PaymentMethodName = addPaymentMethodDto.PaymentMethodName,

            };
             _paymentMethodRepository.Add(paymentMethodEntity);
            return paymentMethodEntity.Id;


        }

        public void DeletePaymentMethod(int id)
        {
            _paymentMethodRepository.Delete(id);
        }

        public void EditPaymentMethod(EditPaymentMethodDto editPaymentMethodDto)
        {
            var paymentMethodEntity = _paymentMethodRepository.GetById(editPaymentMethodDto.Id);
            paymentMethodEntity.Id = editPaymentMethodDto.Id;
            paymentMethodEntity.PaymentMethodName = editPaymentMethodDto.PaymentMethodName;
            paymentMethodEntity.CardNumber = editPaymentMethodDto.CardNumber;
            paymentMethodEntity.ExpirationMonth = editPaymentMethodDto.ExpirationMonth;
            paymentMethodEntity.ExpirationYear = editPaymentMethodDto.ExpirationYear;
            paymentMethodEntity.UserId = editPaymentMethodDto.UserId;
            paymentMethodEntity.CVV = editPaymentMethodDto.CVV;

          
        }

        public List<ListPaymentMethodDto> GetAllPaymentMethods()
        {
            var paymentMethodEntity= _paymentMethodRepository.GetAll();
            var listPaymentMethodDto = paymentMethodEntity.Select(x => new ListPaymentMethodDto
            {
                CardNumber = x.CardNumber,
                ExpirationMonth = x.ExpirationMonth,
                ExpirationYear = x.ExpirationYear,
                UserId = x.UserId,
                CVV = x.CVV,
                Id = x.Id,
                PaymentMethodName = x.PaymentMethodName,


            }).ToList();
            return listPaymentMethodDto;

        }

        public GetPaymentMethodDto GetPaymentMethod(int id)
        {
            var paymentMethodEntity=_paymentMethodRepository.GetById(id);

            var getPaymentMethodDto = new GetPaymentMethodDto()
            {
                PaymentMethodName = paymentMethodEntity.PaymentMethodName,
                CardNumber = paymentMethodEntity.CardNumber,
                ExpirationMonth = paymentMethodEntity.ExpirationMonth,
                ExpirationYear = paymentMethodEntity.ExpirationYear,
                UserId = paymentMethodEntity.UserId,
                CVV = paymentMethodEntity.CVV,
                Id = paymentMethodEntity.Id,

            };
            return getPaymentMethodDto;

        }
    }
}
