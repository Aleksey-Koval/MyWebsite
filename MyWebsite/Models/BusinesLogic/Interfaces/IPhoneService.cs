using MyWebsite.Models.BusinesLogic.DataTransfer;
using System.Collections.Generic;

namespace MyWebsite.Models.BusinesLogic.Interfaces
{
    public interface IPhoneService
    {
        int Create(PhoneDto phoneDto);
        List<ProductDto> GetPhones();
        PhoneDto GetPhone(int phoneId);
        void Update(PhoneDto phoneDto);
        void Dispose();
    }
}
