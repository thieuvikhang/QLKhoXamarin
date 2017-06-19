using DataAccess;
using DataTransferObject;


namespace Business
{
    public class DangNhapBus
    {
        private readonly DangNhapDal _dangNhap = new DangNhapDal();
        public NhanVienObject DangNhap(string taiKhoan, string matKhau)
        {
            return _dangNhap.DangNhap(taiKhoan, matKhau);
        }
    }
}