using Net_Pinyin.Core.builtInData;

namespace Net_Pinyin.Core
{
    internal class Dict
    {
        //make this singleton
        private Dict() { }
        private static readonly Lazy<Dict> lazy = new Lazy<Dict>(() => new Dict());
        public static Dict Instance
        {
            get
            {
                lazy.Value.LoadDictionary(true);
                return lazy.Value;
            }
        }

        private Dictionary<int, string> _SingleDictionary;
        public Dictionary<int, string> SingleDictionary
        {
            get
            {
                return _SingleDictionary;
            }

        }

        private Dictionary<int, string> GetSingleDictionary(bool readFromFileFirst = true)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            if (readFromFileFirst && System.IO.File.Exists("pinyin-data/pinyin.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines("pinyin-data/pinyin.txt");
                foreach (string line in lines)
                {
                    string sToParse = line;
                    if (line.StartsWith('#')) continue;
                    if (line.Contains('#'))
                    {
                        sToParse = line.Substring(0, line.IndexOf('#'));
                    }

                    string[] parts = sToParse.Split(':');
                    if (parts.Length == 2)
                    {
                        string pinyin = parts[1].Trim();
                        if (pinyin.Length > 0)
                        {
                            int code = Convert.ToInt32(parts[0].Substring(2).Trim(), 16);
                            dict[code] = pinyin;
                        }
                    }
                }

            }
            else
            {
                dict = BuiltInDict.BuiltInSingleDictionary;
            }
            return dict;
        }

        private Dictionary<string, string> _PhraseDictionary;
        public Dictionary<string, string> PhraseDictionary
        {
            get
            {
                return _PhraseDictionary;
            }
        }

        private Dictionary<string, string> GetPhraseDictionary(bool readFromFileFirst = true)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (readFromFileFirst && System.IO.File.Exists("phrase-pinyin-data/pinyin.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines("phrase-pinyin-data/pinyin.txt");
                foreach (string line in lines)
                {
                    string sToParse = line;
                    if (line.StartsWith('#')) continue;
                    if (line.Contains('#'))
                    {
                        sToParse = line.Substring(0, line.IndexOf('#'));
                    }

                    string[] parts = sToParse.Split(':');
                    if (parts.Length == 2)
                    {
                        string pinyin = parts[1].Trim();
                        dict[parts[0]] = pinyin;
                    }
                }
            }
            else
            {
                dict = BuiltInDict.BuiltInPhraseDictionary;
            }
            return dict;
        }



        public void LoadDictionary(bool readFromFileFirst)
        {
            _SingleDictionary = GetSingleDictionary(readFromFileFirst);
            _PhraseDictionary = GetPhraseDictionary(readFromFileFirst);
        }


    }
}
