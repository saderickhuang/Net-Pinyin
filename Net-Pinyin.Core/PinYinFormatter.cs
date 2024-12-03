using System.Text;

namespace Net_Pinyin.Core
{
    internal class PinYinFormatter
    {
        private static Dictionary<string, string> _PhoneticSymbol;
        public static Dictionary<string, string> PhoneticSymbol
        {
            get
            {
                if (_PhoneticSymbol == null)
                {
                    _PhoneticSymbol = new Dictionary<string, string>();
                    _PhoneticSymbol["ā"] = "a1";
                    _PhoneticSymbol["á"] = "a2";
                    _PhoneticSymbol["ǎ"] = "a3";
                    _PhoneticSymbol["à"] = "a4";
                    _PhoneticSymbol["ē"] = "e1";
                    _PhoneticSymbol["é"] = "e2";
                    _PhoneticSymbol["ě"] = "e3";
                    _PhoneticSymbol["è"] = "e4";
                    _PhoneticSymbol["ō"] = "o1";
                    _PhoneticSymbol["ó"] = "o2";
                    _PhoneticSymbol["ǒ"] = "o3";
                    _PhoneticSymbol["ò"] = "o4";
                    _PhoneticSymbol["ī"] = "i1";
                    _PhoneticSymbol["í"] = "i2";
                    _PhoneticSymbol["ǐ"] = "i3";
                    _PhoneticSymbol["ì"] = "i4";
                    _PhoneticSymbol["ū"] = "u1";
                    _PhoneticSymbol["ú"] = "u2";
                    _PhoneticSymbol["ǔ"] = "u3";
                    _PhoneticSymbol["ù"] = "u4";
                    _PhoneticSymbol["ü"] = "v0";
                    _PhoneticSymbol["ǘ"] = "v2";
                    _PhoneticSymbol["ǚ"] = "v3";
                    _PhoneticSymbol["ǜ"] = "v4";
                    _PhoneticSymbol["ń"] = "n2";
                    _PhoneticSymbol["ň"] = "n3";
                    _PhoneticSymbol[""] = "m2";
                }
                return _PhoneticSymbol;
            }
        }
        public static string Convert2NoTone(string Pinyin)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in Pinyin)
            {
                string str = Convert.ToString(c);
                if (PhoneticSymbol.ContainsKey(str))
                {
                    str = PhoneticSymbol[str].Substring(0, 1);
                }
                sb.Append(str);
            }
            return sb.ToString();
        }

        public static string Conver2ToneWithNumber(string Pinyin)
        {
            StringBuilder sb = new StringBuilder();
            String ToneNumber = "";
            foreach (char c in Pinyin)
            {
                string str = Convert.ToString(c);
                if (PhoneticSymbol.ContainsKey(str))
                {
                    ToneNumber = PhoneticSymbol[str].Substring(1, 1);
                    str = PhoneticSymbol[str].Substring(0, 1);

                }
                sb.Append(str);
            }
            sb.Append(ToneNumber);
            return sb.ToString();
        }
    }
}
