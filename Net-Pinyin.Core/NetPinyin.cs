using System.Text;

namespace Net_Pinyin.Core
{
    public class NetPinyin
    {
        private static Dict PinyinDict = Dict.Instance;

        //public static List<string> PinYin(string Hanzi, PinyinStyle Style = PinyinStyle.Normal)
        //{
        //    List<string> ret = new List<string>();

        //    return ret;
        //}
        public static string PinYin(string Hanzi, PinyinStyle Style = PinyinStyle.WithTone, char Seperator = ',')
        {
            string ret = "";
            var builder1 = new StringBuilder();
            for (int i = 0; i < Hanzi.Length; i++)
            {
                if (IsHanzi(Hanzi[i]))
                {
                    if (builder1.Length > 0 && builder1.ToString().ElementAt(builder1.Length - 1) != Seperator)
                    {
                        builder1.Append(Seperator);
                    }
                    builder1.Append(GetSinglePinyin(Hanzi[i], Style));
                    if (i != Hanzi.Length - 1)
                    {
                        builder1.Append(Seperator);
                    }
                }
                else
                {
                    builder1.Append(Hanzi[i]);
                }


            }
            return builder1.ToString();
        }
        private static string GetSinglePinyin(char Hanzi, PinyinStyle Style)
        {
            string ret = "";
            ret = PinyinDict.SingleDictionary[Hanzi];
            if (ret.Contains(','))
            {
                ret = ret.Split(',')[0];
            }
            ret = $"{ConvertPinyinStyle(ret, Style)}";
            return ret;
        }
        private static string ConvertPinyinStyle(string Pinyin, PinyinStyle Style)
        {
            string ret = Pinyin;
            switch (Style)
            {
                case PinyinStyle.WithTone:
                    break;
                case PinyinStyle.NoTone:
                    ret = PinYinFormatter.Convert2NoTone(Pinyin);
                    break;
                case PinyinStyle.ToneAsNumber:
                    ret = PinYinFormatter.Conver2ToneWithNumber(Pinyin);
                    break;
                default:
                    break;
            }
            return ret;
        }

        private static bool IsHanzi(char Hanzi)
        {
            if (Hanzi >= Constant.MIN_HANZI_UNICODE && Hanzi <= Constant.MAX_HANZI_UNICODE)
            {
                return true;
            }
            return false;
        }

    }
}
