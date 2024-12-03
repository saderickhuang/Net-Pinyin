using Net_Pinyin.Core;
namespace Net_Pinyin.Test
{
    internal class Demo
    {
        static void Main(string[] args)
        {

            string hanzi = "中文";
            string pinyin = NetPinyin.PinYin(hanzi, PinyinStyle.WithTone);//带声调的拼音
            Console.WriteLine(pinyin);
            pinyin = NetPinyin.PinYin(hanzi, PinyinStyle.NoTone);//不带声调的拼音
            Console.WriteLine(pinyin);
            pinyin = NetPinyin.PinYin(hanzi, PinyinStyle.ToneAsNumber);//数字标识声调的拼音
            Console.WriteLine(pinyin);
            pinyin = NetPinyin.PinYin(hanzi, PinyinStyle.WithTone,'|');//指定拼音的分隔符
            Console.WriteLine(pinyin);
            return;
        }
    }
}
