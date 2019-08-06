using MyWebsite.Models.BusinesLogic.DataTransfer;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Interfaces
{
    public interface ITvService
    {
        int Create(TvDto tvDto);
        List<ProductDto> GetTvSets();
        TvDto GetTv(int tvId);
        void Update(TvDto tvDto);
        void Dispose();
    }
}
