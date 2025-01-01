### [将日期转换为二进制表示](https://leetcode.cn/problems/convert-date-to-binary/solutions/3030637/jiang-ri-qi-zhuan-huan-wei-er-jin-zhi-bi-nhll/)

#### 方法一：模拟

首先将 $date$ 按照 “yyyy-mm-dd” 的格式解析出年 $year$、月 $month$、日 $day$，然后将 $year$，$month$ 和 $day$ 的二进制表示字符串用 “-” 连接起来，返回结果。

```C++
class Solution {
public:
    string binary(int x) {
        string s;
        while (x) {
            s.push_back('0' + (x & 1));
            x >>= 1;
        }
        reverse(s.begin(), s.end());
        return s;
    }

    string convertDateToBinary(string date) {
        int year = stoi(date.substr(0, 4));
        int month = stoi(date.substr(5, 2));
        int day = stoi(date.substr(8, 2));
        return binary(year) + "-" + binary(month) + "-" + binary(day);
    }
};
```

```Python
class Solution:
    def binary(self, x: int) -> str:
        return bin(x)[2:]

    def convertDateToBinary(self, date: str) -> str:
        year = int(date[:4])
        month = int(date[5:7])
        day = int(date[8:10])
        return self.binary(year) + '-' + self.binary(month) + '-' + self.binary(day)
```

```C
int toInt(char *s, int l, int r) {
    int res = 0;
    for (; l < r; l++) {
        res = res * 10 + s[l] - '0';
    }
    return res;
}

int binary(char *s, int l, int x) {
    int r = l;
    for (; x; x >>= 1) {
        s[r++] = '0' + (x & 1);
    }
    for (int i = l, j = r - 1; i < j; i++, j--) {
        char t = s[i];
        s[i] = s[j];
        s[j] = t;
    }
    return r;
}

char* convertDateToBinary(char* date) {
    int year = toInt(date, 0, 4);
    int month = toInt(date, 5, 7);
    int day = toInt(date, 8, 10);

    char *res = (char *)calloc(128, 1);
    int i = binary(res, 0, year);
    res[i++] = '-';
    i = binary(res, i, month);
    res[i++] = '-';
    i = binary(res, i, day);
    return res;
}
```

```Go
func binary(x int) string {
    var s []byte
    for ; x != 0; x >>= 1 {
        s = append(s, '0' + byte(x & 1))
    }
    for i, j := 0, len(s) - 1; i < j; i, j = i + 1, j - 1 {
        s[i], s[j] = s[j], s[i]
    }
    return string(s)
}

func convertDateToBinary(date string) string {
    year, _ := strconv.Atoi(date[:4])
    month, _ := strconv.Atoi(date[5:7])
    day, _ := strconv.Atoi(date[8:])
    return binary(year) + "-" + binary(month) + "-" + binary(day)
}
```

```Java
public class Solution {
    private String binary(int x) {
        StringBuilder s = new StringBuilder();
        for (; x != 0; x >>= 1) {
            s.append(x & 1);
        }
        return s.reverse().toString();
    }

    public String convertDateToBinary(String date) {
        int year = Integer.parseInt(date.substring(0, 4));
        int month = Integer.parseInt(date.substring(5, 7));
        int day = Integer.parseInt(date.substring(8, 10));
        return binary(year) + "-" + binary(month) + "-" + binary(day);
    }
}
```

```CSharp
public class Solution {
    private string Binary(int x) {
        string s = string.Empty;
        while (x != 0) {
            s = s + (x & 1);
            x >>= 1;
        }
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public string ConvertDateToBinary(string date) {
        int year = int.Parse(date.Substring(0, 4));
        int month = int.Parse(date.Substring(5, 2));
        int day = int.Parse(date.Substring(8, 2));
        return Binary(year) + "-" + Binary(month) + "-" + Binary(day);
    }
}
```

```JavaScript
function binary(x) {
    let s = '';
    while (x !== 0) {
        s += (x & 1);
        x >>= 1;
    }
    return s.split('').reverse().join('');
}

var convertDateToBinary = function(date) {
    const year = parseInt(date.substring(0, 4), 10);
    const month = parseInt(date.substring(5, 7), 10);
    const day = parseInt(date.substring(8, 10), 10);
    return binary(year) + "-" + binary(month) + "-" + binary(day);
};
```

```TypeScript
function binary(x: number): string {
    let s = '';
    while (x !== 0) {
        s += (x & 1);
        x >>= 1;
    }
    return s.split('').reverse().join('');
}

function convertDateToBinary(date: string): string {
    const year = parseInt(date.substring(0, 4), 10);
    const month = parseInt(date.substring(5, 7), 10);
    const day = parseInt(date.substring(8, 10), 10);
    return binary(year) + "-" + binary(month) + "-" + binary(day);
}
```

```Rust
impl Solution {
    fn binary(x: i32) -> String {
        let mut s = String::new();
        let mut x = x;
        while x != 0 {
            s.push((x & 1).to_string().chars().next().unwrap());
            x >>= 1;
        }
        s.chars().rev().collect()
    }

    pub fn convert_date_to_binary(date: String) -> String {
        let year: i32 = date[0..4].parse().unwrap();
        let month: i32 = date[5..7].parse().unwrap();
        let day: i32 = date[8..10].parse().unwrap();
        format!("{}-{}-{}", Self::binary(year), Self::binary(month), Self::binary(day))
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
