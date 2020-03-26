using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _350Project.Common
{
    public class Password
    {
        public static string Encode(string password) {
            try
            {
                byte[] encode = new byte[password.Length];
                encode = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedata = Convert.ToBase64String(encode);
                return encodedata;

            }
            catch (Exception e) {

                throw new Exception("Error in Encode"+e.Message);
            }
        }

        public static string Decode(string enc)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder uft8decode = encoder.GetDecoder();
                byte[] Decodebyte = Convert.FromBase64String(enc);
                int charcount = uft8decode.GetCharCount(Decodebyte,0, Decodebyte.Length);
                char[] Decodechar = new char[charcount];
                uft8decode.GetChars(Decodebyte, 0, Decodebyte.Length, Decodechar, 0);
                string Decodedata = new string(Decodechar);
                return Decodedata;
            }
            catch (Exception e)
            {
                throw new Exception("Error in Decode"+e.Message);
            }
        }

    }
}