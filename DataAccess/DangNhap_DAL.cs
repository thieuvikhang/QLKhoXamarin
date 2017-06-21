using DataTransferObject;


namespace DataAccess
{
    public class DangNhapDal
    {
        private readonly Database _data = new Database();
        public NhanVienObject DangNhap(string taiKhoan, string matKhau)
        {
            var sql = $"CALL DangNhap('{taiKhoan}', '{matKhau}')";
            if (_data.Execute(sql) == false) return null;
            var dt = _data.LoadData(sql);
            var nv = new NhanVienObject
            {
                TenNhanVien = dt.Rows[0][0].ToString(),
                MaPhanQuyen = int.Parse(dt.Rows[0][1].ToString()),
                TaiKhoan = dt.Rows[0][2].ToString()
            };
            return nv;
        }
        public string LayChuoiMaHoa(string taiKhoan)
        {
            var sql = $"CALL LayChuoiMaHoa('{taiKhoan}')";
            if (_data.Execute(sql) == false) return null;
            var dt = _data.LoadData(sql);
            return dt.Rows[0][0].ToString();
        }

        public bool DangKy(NhanVienObject nhanVien)
        {
            var sql = $"CALL DangKy('{nhanVien.TenNhanVien}', '{nhanVien.GioiTinh}', '{nhanVien.NgaySinh}', '{nhanVien.DienThoai}', '{nhanVien.Email}', '{nhanVien.DiaChi}', '{nhanVien.TaiKhoan}', '{nhanVien.MatKhau}', '{nhanVien.MaHoa}', '{nhanVien.MaPhanQuyen}')";
            return _data.Execute(sql);
        }
    }
}