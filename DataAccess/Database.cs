using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess
{
    public class Database
    {
        private readonly MySqlConnection _con;
        private MySqlDataAdapter _da;
        private DataSet _ds;
        public Database()
        {
            const string sql = "Server=db4free.net;Port=3307;database=qlkho;User Id=khang100;Password=123456;charset=utf8";
            _con = new MySqlConnection(sql);
        }

        public bool Execute(string sql)
        {
            var cmd = new MySqlCommand(sql, _con);
            try
            {
                _con.Open();
                cmd.ExecuteNonQuery();
                _con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable LoadData(string sql)
        {
            _ds = new DataSet();
            _da = new MySqlDataAdapter(sql, _con);
            _da.Fill(_ds);
            return _ds.Tables[0];
        }
    }
}