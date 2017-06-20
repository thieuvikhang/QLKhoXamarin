namespace DataTransferObject
{
    public class NhanVienObject
    {
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string MaHoa { get; set; }
        public int MaPhanQuyen { get; set; }
    }
    public class HangHoaObject
    {
        public int idHH { get; set; }
        public int MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public decimal? GiaNhap { get; set; }
        public int SoLuongTon { get; set; }
        public string MoTa { get; set; }
        public int MaLoaiHang { get; set; }
        public int MaNSX { get; set; }
    }
    public class ChucVuObject
    {
        public int MaChucVu { get; set; }
        public string TenChucVu { get; set; }
    }
}