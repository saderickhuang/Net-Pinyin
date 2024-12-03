# Net-Pinyin



汉语转拼音工具



## 使用方法

```c#
string hanzi = "中文";
string pinyin = NetPinyin.PinYin(hanzi);
```

默认输出：

```
zhōng,wén
```

可选参数:

``` 
string hanzi = "中文";
string pinyin = NetPinyin.PinYin(hanzi, PinyinStyle.WithTone);//带声调的拼音
Console.WriteLine(pinyin);
pinyin = NetPinyin.PinYin(hanzi, PinyinStyle.NoTone);//不带声调的拼音
Console.WriteLine(pinyin);
pinyin = NetPinyin.PinYin(hanzi, PinyinStyle.ToneAsNumber);//数字标识声调的拼音
Console.WriteLine(pinyin);
pinyin = NetPinyin.PinYin(hanzi, PinyinStyle.WithTone,'|');//指定拼音的分隔符
Console.WriteLine(pinyin);
```

效果：

```
zhōng,wén
zhong,wen
zhong1,wen2
zhōng|wén
```



## TODO:

1. 分词功能
2. 多音字
