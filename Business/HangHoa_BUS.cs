using DataAccess;
using DataTransferObject;
using System.Collections.Generic;

namespace Business
{
    public class HangHoa_BUS
    {
        private readonly HangHoa_DAL _hangHoa = new HangHoa_DAL();
        public List<HangHoaObject> ListHangHoa()
        {
            return _hangHoa.ListHangHoa();
        }
    }
}