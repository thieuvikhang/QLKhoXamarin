using DataTransferObject;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class HangHoa_DAL
    {
        private readonly Database _data = new Database();
        List<HangHoaObject> lstHH;
        public List<HangHoaObject> ListHangHoa()
        {
            string sql = $"SELECT * FROM `HangHoa`";
            if (_data.Execute(sql) == false) return null;
            DataTable dt = _data.LoadData(sql);
            lstHH = new List<HangHoaObject>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HangHoaObject hanghoa = new HangHoaObject()
                {
                    idHH = i,
                    MaHangHoa =int.Parse(dt.Rows[i][0].ToString()),
                    TenHangHoa = dt.Rows[i][1].ToString(),
                    GiaNhap = decimal.Parse(dt.Rows[i][2].ToString()),
                    SoLuongTon = int.Parse(dt.Rows[i][3].ToString()),
                    MoTa = dt.Rows[i][4].ToString(),
                    MaLoaiHang = int.Parse(dt.Rows[i][5].ToString()),
                    MaNSX = int.Parse(dt.Rows[i][6].ToString())
                };
                lstHH.Add(hanghoa);
            }
            return lstHH;
        }
    }
}