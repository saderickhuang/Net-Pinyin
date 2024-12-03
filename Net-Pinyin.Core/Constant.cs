namespace Net_Pinyin.Core
{
    internal static class Constant
    {
        /// <summary>
        /// 汉字 Unicode 编码最小值
        /// </summary>
        public static char MIN_HANZI_UNICODE = (char)19968;

        /// <summary>
        /// 汉字 Unicode 编码最小值
        /// </summary>
        public static char MAX_HANZI_UNICODE = (char)40869;


    }

    public enum PinyinStyle
    {
        /// <summary>
        /// 不带声调
        /// </summary>
        NoTone,
        /// <summary>
        /// 声调在韵母上
        /// </summary>
        WithTone,

        /// <summary>
        /// 声调以数字形式在拼音之后，使用数字 0~4 标识
        /// </summary>
        ToneAsNumber,

    }


}
