using Business.Helpers;
using DataAccess;
using DataTransferObject;


namespace Business
{
    public class DangNhapBus
    {
        private readonly DangNhapDal _dangNhap = new DangNhapDal();
        private readonly MaHoa _maHoa = new MaHoa();
        public NhanVienObject DangNhap(string taiKhoan, string matKhau)
        {
            var maHoa = _dangNhap.LayChuoiMaHoa(taiKhoan);
            var matKhauMaHoa = _maHoa.MaHoaMatKhauMd5(maHoa, matKhau);
            return _dangNhap.DangNhap(taiKhoan, matKhauMaHoa);
        }

        public bool DangKy(NhanVienObject nhanVien)
        {
            nhanVien.MaHoa = _maHoa.Md5Hash(_maHoa.RandomString(6));
            nhanVien.MatKhau = _maHoa.MaHoaMatKhauMd5(nhanVien.MaHoa, nhanVien.MatKhau);
            return _dangNhap.DangKy(nhanVien);
        }
    }
}