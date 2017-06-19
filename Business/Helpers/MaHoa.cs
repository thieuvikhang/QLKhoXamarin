using System;
using System.Text;
using System.Security.Cryptography;

namespace Business.Helpers
{
    public class MaHoa
    {
        public string Md5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));
            //get hash result after compute it
            var result = md5.Hash;
            var strBuilder = new StringBuilder();
            foreach (var t in result)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(t.ToString("x2"));
            }
            return strBuilder.ToString();
        }
        //Tạo cuổi ngẩu nhiêu
        public string RandomString(int length)
        {
            const string allowedLetterChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
            const string allowedNumberChars = "0123456789";
            var chars = new char[length];
            var rd = new Random();
            var useLetter = true;
            for (var i = length - 1; i >= 0; i--)
            {
                if (!useLetter)
                {
                    chars[i] = allowedNumberChars[rd.Next(0, allowedNumberChars.Length)];
                    useLetter = true;
                }
                else
                {
                    chars[i] = allowedLetterChars[rd.Next(0, allowedLetterChars.Length)];
                    useLetter = false;
                }
            }
            return new string(chars);
        }
        /// <summary>
        /// Mã hóa mật khẩu cộng thêm chuổi
        /// </summary>
        /// <param name="strRandom">chuổi ngẩu nhiên</param>
        /// <param name="matKhau">mật khẩu</param>
        /// <returns>chuổi được mã hóa</returns>
        public string MaHoaMatKhauMd5(string strRandom, string matKhau)
        {
            var outPut = Md5Hash(strRandom + matKhau);
            return outPut;
        }
    }
}