using System.Text.RegularExpressions;

namespace Business.Helpers
{
    public class MoRong
    {
        //Format tiền sang kiểu string 1.000.000₫
        public string FormatMoney(decimal money)
        {
            return money == 0 ? "0" : money.ToString("#,###") + "₫";
        }
        //Hàm kiểm tra chuỗi có phải là số hay không
        public bool IsNumber(string pText)
        {
            var regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
    }
}