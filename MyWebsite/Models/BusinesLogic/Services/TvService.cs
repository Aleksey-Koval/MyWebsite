using AutoMapper;
using MyWebsite.Models.BusinesLogic.DataTransfer;
using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.DataAccess.Entities.Products;
using MyWebsite.Models.Interfaces;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Services
{
    public class TvService : ITvService
    {
        IUnitOfWork Database { get; set; }

        public TvService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public int Create(TvDto tvDto)
        {
            Tv tv = MappingTvDtoToTv(tvDto);
            Database.TvSets.Create(tv);
            Database.Save();
            return tv.Id;
        }


        public TvDto GetTv(int tvId)
        {
            Tv tv = Database.TvSets.Get(tvId);
            TvDto tvDto = MappingTvToTvDto(tv);
            return tvDto;
        }

        public List<ProductDto> GetTvSets()
        {
            var tvSets = Database.TvSets.GetAll();
            var productsDto = MappingTvSetsToProductsDto(tvSets);
            return productsDto;
        }

        public void Update(TvDto tvDto)
        {
            Tv tv = Database.TvSets.Get(tvDto.Id);

            tv.Name = tvDto.Name;
            tv.Company = tvDto.Company;
            tv.Contrast = tvDto.Contrast;
            tv.Description = tvDto.Description;
            tv.ResponseTime = tvDto.ResponseTime;
            tv.ScreenDiagonal = tvDto.ScreenDiagonal;
            tv.ScreenResolution = tvDto.ScreenResolution;
            tv.SmartTv = tvDto.SmartTv;
            tv.WiFi = tvDto.WiFi;

            if (tvDto.Image != null)
                tv.Image = tvDto.Image;
            if (tvDto.Price != 0)
                tv.Price = tvDto.Price;

            Database.TvSets.Update(tv);
            Database.Save();
        }

        private TvDto MappingTvToTvDto(Tv tv)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Tv, TvDto>()).CreateMapper();
            var tvDto = mapper.Map<Tv, TvDto>(tv);
            return tvDto;
        }

        private Tv MappingTvDtoToTv(TvDto tvDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TvDto, Tv>()).CreateMapper();
            var tv = mapper.Map<TvDto, Tv>(tvDto);
            return tv;
        }

        private List<ProductDto> MappingTvSetsToProductsDto(IEnumerable<Tv> tvSets)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Tv, ProductDto>()).CreateMapper();
            var productsDto = mapper.Map<IEnumerable<Tv>, List<ProductDto>>(tvSets);
            return productsDto;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}