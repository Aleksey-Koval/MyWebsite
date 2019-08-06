using AutoMapper;
using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.Interfaces;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Services
{
    public class HeadphonesService : IHeadphonesService
    {
        IUnitOfWork Database { get; set; }

        public HeadphonesService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public int Create(HeadphonesDto headphonesDto)
        {
            Headphones headphones = MappingHeadphonesDtoToHeadphones(headphonesDto);
            Database.Headphones.Create(headphones);
            Database.Save();
            return headphones.Id;
        }


        public HeadphonesDto GetHeadphones(int headphonesId)
        {
            Headphones headphones = Database.Headphones.Get(headphonesId);
            HeadphonesDto headphonesDto = MappingHeadphonesToHeadphonesDto(headphones);
            return headphonesDto;
        }

        public List<ProductDto> GetHeadphonesSets()
        {
            var headphonesSets = Database.Headphones.GetAll();
            var productsDto = MappingHeadphonesSetsToProductsDto(headphonesSets);
            return productsDto;
        }

        public void Update(HeadphonesDto headphonesDto)
        {
            Headphones headphones = Database.Headphones.Get(headphonesDto.Id);

            headphones.Company = headphonesDto.Company;
            headphones.Description = headphonesDto.Description;
            headphones.FrequencyRange = headphonesDto.FrequencyRange;
            headphones.Impedance = headphonesDto.Impedance;
            headphones.Microphone = headphonesDto.Microphone;
            headphones.Name = headphonesDto.Name;
            headphones.Type = headphonesDto.Type;
            headphones.TypeOfConnection = headphonesDto.TypeOfConnection;

            if (headphonesDto.Image != null)
                headphones.Image = headphonesDto.Image;
            if (headphonesDto.Price != 0)
                headphones.Price = headphonesDto.Price;

            Database.Headphones.Update(headphones);
            Database.Save();
        }

        private HeadphonesDto MappingHeadphonesToHeadphonesDto(Headphones headphones)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Headphones, HeadphonesDto>()).CreateMapper();
            var headphonesDto = mapper.Map<Headphones, HeadphonesDto>(headphones);
            return headphonesDto;
        }

        private Headphones MappingHeadphonesDtoToHeadphones(HeadphonesDto headphonesDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HeadphonesDto, Headphones>()).CreateMapper();
            var headphones = mapper.Map<HeadphonesDto, Headphones>(headphonesDto);
            return headphones;
        }

        private List<ProductDto> MappingHeadphonesSetsToProductsDto(IEnumerable<Headphones> headphonesSets)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Headphones, ProductDto>()).CreateMapper();
            var productsDto = mapper.Map<IEnumerable<Headphones>, List<ProductDto>>(headphonesSets);
            return productsDto;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}