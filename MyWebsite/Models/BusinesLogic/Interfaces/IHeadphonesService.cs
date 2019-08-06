using MyWebsite.Models.BusinesLogic.DataTransfer;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Interfaces
{
    public interface IHeadphonesService
    {
        int Create(HeadphonesDto headphonesDto);
        List<ProductDto> GetHeadphonesSets();
        HeadphonesDto GetHeadphones(int headphonesId);
        void Update(HeadphonesDto headphonesDto);
        void Dispose();
    }
}
