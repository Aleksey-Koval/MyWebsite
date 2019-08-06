using AutoMapper;
using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.Interfaces;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Services
{
    public class PhoneService : IPhoneService
    {
        IUnitOfWork Database { get; set; }

        public PhoneService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public int Create(PhoneDto phoneDto)
        {
            Phone phone = MappingPhoneDtoToPhone(phoneDto);
            Database.Phones.Create(phone);
            Database.Save();
            return phone.Id;
        }


        public PhoneDto GetPhone(int phoneId)
        {
            Phone phone = Database.Phones.Get(phoneId);
            PhoneDto phoneDto = MappingPhoneToPhoneDto(phone);
            return phoneDto;
        }

        public List<ProductDto> GetPhones()
        {
            var phones = Database.Phones.GetAll();
            var productsDto = MappingPhonesToProductsDto(phones);
            return productsDto;
        }

        public void Update(PhoneDto phoneDto)
        {
            Phone phone = Database.Phones.Get(phoneDto.Id);

            phone.Name = phoneDto.Name;
            phone.BatteryCapacity = phoneDto.BatteryCapacity;
            phone.Camera = phoneDto.Camera;
            phone.FrontCamera = phoneDto.FrontCamera;
            phone.Company = phoneDto.Company;
            phone.CpuName = phoneDto.CpuName;
            phone.CpuFrequncy = phoneDto.CpuFrequncy;
            phone.CpuNumberOfCores = phoneDto.CpuNumberOfCores;
            phone.Memory = phoneDto.Memory;
            phone.OperatingSystem = phoneDto.OperatingSystem;
            phone.Ram = phoneDto.Ram;
            phone.ScreenDiagonal = phoneDto.ScreenDiagonal;
            phone.Description = phoneDto.Description;

            if (phoneDto.Image != null)
                phone.Image = phoneDto.Image;
            if (phoneDto.Price != 0)
                phone.Price = phoneDto.Price;

            Database.Phones.Update(phone);
            Database.Save();
        }

        private PhoneDto MappingPhoneToPhoneDto(Phone phone)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Phone, PhoneDto>()).CreateMapper();
            var phoneDto = mapper.Map<Phone, PhoneDto>(phone);
            return phoneDto;
        }

        private Phone MappingPhoneDtoToPhone(PhoneDto phoneDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhoneDto, Phone>()).CreateMapper();
            var phone = mapper.Map<PhoneDto, Phone>(phoneDto);
            return phone;
        }

        private List<ProductDto> MappingPhonesToProductsDto(IEnumerable<Phone> phones)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Phone, ProductDto>()).CreateMapper();
            var productsDto = mapper.Map<IEnumerable<Phone>, List<ProductDto>>(phones);
            return productsDto;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}