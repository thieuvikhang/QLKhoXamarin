using System.Collections.Generic;
using DataTransferObject;
using System.Data;

namespace DataAccess
{
    public class Kho_DAL
    {
        private readonly Database _data = new Database();
        List<KhoObject> ds;
        public List<KhoObject> danhSachKho()
        {
            string sql = $"SELECT * FROM `Kho`";
            if(_data.Execute(sql) == false)
            {
                return null;
            }
            
            var dt = new DataTable();
            dt = _data.LoadData(sql);

            ds = new List<KhoObject>();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                KhoObject _kho = new KhoObject()
                {
                    item = i,
                    MaKho = int.Parse(dt.Rows[i][0].ToString()),
                    TenKho = dt.Rows[i][1].ToString(),
                    DiaChi = dt.Rows[i][2].ToString(),
                    MaNhanVien = int.Parse(dt.Rows[i][3].ToString())
                };
                ds.Add(_kho);
            }
            return ds;            
        }
    }
}