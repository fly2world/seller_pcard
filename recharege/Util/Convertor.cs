using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace recharege.Util
{
    public static class Convertor
    {
        public static string Ascii2Str(byte[] buf)
        {
            return System.Text.Encoding.ASCII.GetString(buf);
        }

        public static string ConvertToHex(byte[] bytHex, int offset, int hexlen)//Byte到HexString
        {
            StringBuilder sbHexStr = new StringBuilder();
            for (int i = 0; i < hexlen; i++)
            {
                sbHexStr.Append(bytHex[offset + i].ToString("X2"));
            }
            return sbHexStr.ToString();
        }

        public static byte[] ConvertFromHexString(string strHex)//HexString到Byte
        {
            byte[] result = new byte[strHex.Length / 2];
            int resultindex = 0;
            for (int i = 0; i < strHex.Length; i += 2)
            {
                string strTmp = strHex.Substring(i, 2);
                byte bytTmp = Convert.ToByte(strTmp, 16);
                result[resultindex++] = bytTmp;
            }
            return result;
        }

        /*
            string转json
        */
        public static String listToJson(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                //item.Key;
                //item.Value;

            }
            return null;
        }

    }
}
