using FirstShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Services
{
    public interface IAddressService
    {
        int AddAddress(AddAddressDto addAddressDto);
        GetAddressDto GetAddress(int id);

        void DeleteAddress(int id);

        void EditAddress(EditAddressDto addressDto);

        List<ListAddressDto> GetAllAddresses();

        

    }
}
