using FirstShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Services
{
    public interface IPaymentMethodService
    {
       int AddPaymentMethod(AddPaymentMethodDto addPaymentMethodDto);

        void DeletePaymentMethod(int id);

        List<ListPaymentMethodDto> GetAllPaymentMethods();

        void EditPaymentMethod(EditPaymentMethodDto editPaymentMethodDto);

        GetPaymentMethodDto GetPaymentMethod(int id);

        


    }
}
