using DataTransferObject;


namespace DataAccess
{
    public class DangNhapDal
    {
        private readonly Database _data = new Database();
        public NhanVienObject DangNhap(string taiKhoan, string matKhau)
        {
            var sql = $"Select `TenNhanVien`, `MaChucVu`, `TaiKhoan` from `NhanVien` WHERE `TaiKhoan` LIKE '{taiKhoan}' AND `MatKhau` LIKE '{matKhau}'";
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
    }
}