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
    public class AddressManager : IAddressService
    {
        private readonly IRepository<AddressEntity> _addressRepository;
        public AddressManager(IRepository<AddressEntity> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public int AddAddress(AddAddressDto addAddressDto)
        {
            var enitity = new AddressEntity()
            {
                Ad = addAddressDto.Ad,
                Adres = addAddressDto.Adres,
                Sehir = addAddressDto.Sehir,
                Soyad = addAddressDto.Soyad,
                PostaKodu = addAddressDto.PostaKodu,
                UserId = addAddressDto.UserId,

            };
            _addressRepository.Add(enitity);

            return enitity.Id;

        }

        public void DeleteAddress(int id)
        {
            _addressRepository.Delete(id);
        }

        public void EditAddress(EditAddressDto editAddressDto)
        {
            var addressEntity = _addressRepository.GetById(editAddressDto.Id);


           
            addressEntity.Adres = editAddressDto.Adres;
            addressEntity.Sehir = editAddressDto.Sehir;
            addressEntity.PostaKodu = editAddressDto.PostaKodu;
         
            _addressRepository.Update(addressEntity);






        }

        public GetAddressDto GetAddress(int id)
        {
            var addressEntity = _addressRepository.GetById(id);
            var addressDto = new GetAddressDto()
            {
                Ad = addressEntity.Ad,
                Adres = addressEntity.Adres,
                Soyad = addressEntity.Soyad,
                Sehir = addressEntity.Sehir,
                PostaKodu = addressEntity.PostaKodu,
                UserId = addressEntity.UserId,
                Id = addressEntity.Id


            };

            return addressDto;

        }

        public List<ListAddressDto> GetAllAddresses()
        {
            var addressListEntity = _addressRepository.GetAll();
            var addressListDto = addressListEntity.Select(x => new ListAddressDto()
            {
                Id = x.Id,
                Ad = x.Ad,
                Soyad = x.Soyad,
                PostaKodu = x.PostaKodu,
                Adres = x.Adres,
                Sehir = x.Sehir,
                UserId = x.UserId

            }).ToList();
            return addressListDto;

        }

        
    }
}
