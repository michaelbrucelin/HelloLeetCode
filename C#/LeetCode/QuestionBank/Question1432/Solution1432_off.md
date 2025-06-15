### [改变一个整数能得到的最大差值](https://leetcode.cn/problems/max-difference-you-can-get-from-changing-an-integer/solutions/514358/gai-bian-yi-ge-zheng-shu-neng-de-dao-de-0byhw/)

#### 分析

要想使得 $a$ 和 $b$ 的差值尽可能大，我们应该找到从 $num$ 可以得到的最大以及最小的整数分别作为 $a$ 和 $b$。

#### 方法一：枚举

根据题目的描述，我们可以任意选择两个数字 $x$ 和 $y$，并将 $num$ 中的所有 $x$ 替换成 $y$。由于 $x$ 和 $y$ 的取值范围均为 $[0,9]$，那么我们最多只有 $10 \times 10=100$ 种不同的替换方法。

因此我们可以使用两重循环枚举所有的替换方法。在得到的所有新整数中，找出最大以及最小的赋予 $a$ 和 $b$。

```C++
class Solution {
public:
    int maxDiff(int num) {
        auto change = [&](int x, int y) {
            string num_s = to_string(num);
            for (char& digit: num_s) {
                if (digit - '0' == x) {
                    digit = '0' + y;
                }
            }
            return num_s;
        };

        int min_num = num;
        int max_num = num;
        for (int x = 0; x < 10; ++x) {
            for (int y = 0; y < 10; ++y) {
                string res = change(x, y);
                // 判断是否有前导零
                if (res[0] != '0') {
                    int res_i = stoi(res);
                    min_num = min(min_num, res_i);
                    max_num = max(max_num, res_i);
                }
            }
        }

        return max_num - min_num;
    }
};
```

```Python
class Solution:
    def maxDiff(self, num: int) -> int:
        def change(x, y):
            return str(num).replace(str(x), str(y))
        
        min_num = max_num = num
        for x in range(10):
            for y in range(10):
                res = change(x, y)
                # 判断是否有前导零
                if res[0] != "0":
                    res_i = int(res)
                    min_num = min(min_num, res_i)
                    max_num = max(max_num, res_i)
        
        return max_num - min_num
```

```Java
class Solution {
    public int maxDiff(int num) {
        int min_num = num;
        int max_num = num;
        for (int x = 0; x < 10; ++x) {
            for (int y = 0; y < 10; ++y) {
                String res = change(num, x, y);
                // 判断是否有前导零
                if (res.charAt(0) != '0') {
                    int res_i = Integer.parseInt(res);
                    min_num = Math.min(min_num, res_i);
                    max_num = Math.max(max_num, res_i);
                }
            }
        }

        return max_num - min_num;
    }

    public String change(int num, int x, int y) {
        StringBuffer num_s = new StringBuffer(String.valueOf(num));
        int length = num_s.length();
        for (int i = 0; i < length; i++) {
            char digit = num_s.charAt(i);
            if (digit - '0' == x) {
                num_s.setCharAt(i, (char) ('0' + y));
            }
        }
        return num_s.toString();
    }
}
```

```CSharp
public class Solution {
    public int MaxDiff(int num) {
        Func<int, int, string> change = (x, y) => {
            var numStr = num.ToString();
            return new string(numStr.Select(digit => (digit - '0') == x ? (char)('0' + y) : digit).ToArray());
        };

        int minNum = num;
        int maxNum = num;
        for (int x = 0; x < 10; ++x) {
            for (int y = 0; y < 10; ++y) {
                string res = change(x, y);
                 // 判断是否有前导零
                if (res[0] != '0') {
                    int res_i = int.Parse(res);
                    minNum = Math.Min(minNum, res_i);
                    maxNum = Math.Max(maxNum, res_i);
                }
            }
        }
        return maxNum - minNum;
    }
}
```

```Go
func maxDiff(num int) int {
    // 定义一个函数 change，用于将数字中的 x 替换为 y
    change := func(x, y int) string {
        numStr := strconv.Itoa(num)
        var res strings.Builder
        for _, digit := range numStr {
            if int(digit-'0') == x {
                res.WriteByte(byte('0' + y))
            } else {
                res.WriteRune(digit)
            }
        }
        return res.String()
    }

    minNum := num
    maxNum := num
    // 遍历所有可能的替换组合
    for x := 0; x < 10; x++ {
        for y := 0; y < 10; y++ {
            res := change(x, y)
            // 判断是否有前导零
            if res[0] != '0' {
                res_i, _ := strconv.Atoi(res)
                minNum = min(minNum, res_i)
                maxNum = max(maxNum, res_i)
            }
        }
    }

    return maxNum - minNum
}
```

```C
int maxDiff(int num) {
    char numStr[20];
    sprintf(numStr, "%d", num);
    int minNum = num;
    int maxNum = num;

    for (int x = 0; x < 10; ++x) {
        for (int y = 0; y < 10; ++y) {
            char res[20];
            strcpy(res, numStr);
            for (int i = 0; res[i]; ++i) {
                if (res[i] - '0' == x) {
                    res[i] = '0' + y;
                }
            }
             // 判断是否有前导零
            if (res[0] != '0') {
                int res_i = atoi(res);
                if (res_i < minNum) {
                    minNum = res_i;
                }
                if (res_i > maxNum) {
                    maxNum = res_i;
                }
            }
        }
    }

    return maxNum - minNum;
}
```

```JavaScript
var maxDiff = function(num) {
    const change = (x, y) => {
        let numStr = num.toString();
        let res = '';
        for (let digit of numStr) {
            if (parseInt(digit) === x) {
                res += y.toString();
            } else {
                res += digit;
            }
        }
        return res;
    };

    let minNum = num;
    let maxNum = num;
    for (let x = 0; x < 10; ++x) {
        for (let y = 0; y < 10; ++y) {
            let res = change(x, y);
             // 判断是否有前导零
            if (res[0] !== '0') {
                let resI = parseInt(res);
                minNum = Math.min(minNum, resI);
                maxNum = Math.max(maxNum, resI);
            }
        }
    }

    return maxNum - minNum;
};
```

```TypeScript
function maxDiff(num: number): number {
    const change = (x: number, y: number): string => {
        let numStr = num.toString();
        let res = '';
        for (let digit of numStr) {
            if (parseInt(digit) === x) {
                res += y.toString();
            } else {
                res += digit;
            }
        }
        return res;
    };

    let minNum = num;
    let maxNum = num;
    for (let x = 0; x < 10; ++x) {
        for (let y = 0; y < 10; ++y) {
            let res = change(x, y);
             // 判断是否有前导零
            if (res[0] !== '0') {
                let resI = parseInt(res);
                minNum = Math.min(minNum, resI);
                maxNum = Math.max(maxNum, resI);
            }
        }
    }

    return maxNum - minNum;
};
```

```Rust
impl Solution {
    pub fn max_diff(num: i32) -> i32 {
        let change = |x: i32, y: i32| -> String {
            num.to_string()
                .chars()
                .map(|digit| if digit.to_digit(10).unwrap() as i32 == x { (y as u8 + b'0') as char } else { digit })
                .collect()
        };

        let mut min_num = num;
        let mut max_num = num;

        for x in 0..10 {
            for y in 0..10 {
                let res = change(x, y);
                 // 判断是否有前导零
                if res.chars().nth(0).unwrap() != '0' {
                    let res_i: i32 = res.parse().unwrap();
                    min_num = min_num.min(res_i);
                    max_num = max_num.max(res_i);
                }
            }
        }

        max_num - min_num
    }
}
```

**复杂度分析**

- 时间复杂度：$O(d^2log(num))$，其中 $d=10$，表示 $num$ 是一个「十」进制数。我们使用两重循环枚举所有的替换方法，时间复杂度为 $O(d^2)$。对于每一种替换方法，我们将 $num$ 转换成字符串后并进行替换操作，需要的时间与 $num$ 的长度成正比，记为 $O(log(num))$。
- 空间复杂度：$O(1)$。

#### 方法二：贪心算法

**思路**

如果我们想要得到最大的整数，最好的办法应该是找到一个高位将它修改为 $9$。同理，如果我们想要得到最小的整数，最好的办法应该是找到一个高位将它修改为 $0$。

**找到最大的数**

要想得到最大的整数，我们从高到低依次枚举 $num$ 中的每一个位置。如果当前枚举到的位置的数字不为 $9$，那么我们该数字全部替换成 $9$，即可得到最大的整数。

**找到最小的数**

要想得到最小的整数，我们从高到低依次枚举 $num$ 中的每一个位置。如果当前枚举到的位置的数字不为 $0$，那么我们将该数字全部替换成 $0$，即可得到最小的整数。

等等，如果我们将数字替换成 $0$，是不是可能会出现「前导零」？举个例子，如果 $num=123$，我们会将最高位的 $1$ 替换成 $0$，得到 $023$，这样就出现了前导零。因此我们必须要考虑前导零的问题：

- 如果我们枚举的是最高位，那么我们只能将其替换成 $1$，否则就会有前导零了；
- 如果我们枚举的是其它的数位：
    - 如果当前的数字与最高位的数字不相等，那么我们就可以将其替换成 $0$；
    - 如果当前的数字与最高位的数字相等，那么我们直接跳过这个数位，这是因为当我们在枚举最高位时，我们已经处理过这个**数字**了。既然在枚举最高位遇到相同的数字时没有选择替换，那么说明这个数字一定就是 $1$，由于前导零的限制我们也不能将其替换成 $0$，因此就可以直接跳过了。

至此，我们通过贪心找高位的方法得到了最大以及最小的数，这样也就得到了最终的答案。

```C++
class Solution {
public:
    int maxDiff(int num) {
        auto replace = [](string& s, char x, char y) {
            for (char& digit: s) {
                if (digit == x) {
                    digit = y;
                }
            }
        };

        string min_num = to_string(num);
        string max_num = to_string(num);
        // 找到一个高位替换成 9
        for (char digit: max_num) {
            if (digit != '9') {
                replace(max_num, digit, '9');
                break;
            }
        }

        // 将最高位替换成 1
        // 或者找到一个与最高位不相等的高位替换成 0
        for (int i = 0; i < min_num.size(); ++i) {
            char digit = min_num[i];
            if (i == 0) {
                if (digit != '1') {
                    replace(min_num, digit, '1');
                    break;
                }
            }
            else {
                if (digit != '0' && digit != min_num[0]) {
                    replace(min_num, digit, '0');
                    break;
                }
            }
        }

        return stoi(max_num) - stoi(min_num);
    }
};
```

```Python
class Solution:
    def maxDiff(self, num: int) -> int:
        min_num, max_num = str(num), str(num)

        # 找到一个高位替换成 9
        for digit in max_num:
            if digit != "9":
                max_num = max_num.replace(digit, "9")
                break

        # 将最高位替换成 1
        # 或者找到一个与最高位不相等的高位替换成 0
        for i, digit in enumerate(min_num):
            if i == 0:
                if digit != "1":
                    min_num = min_num.replace(digit, "1")
                    break
            else:
                if digit != "0" and digit != min_num[0]:
                    min_num = min_num.replace(digit, "0")
                    break

        return int(max_num) - int(min_num)
```

```Java
class Solution {
    public int maxDiff(int num) {
        StringBuffer min_num = new StringBuffer(String.valueOf(num));
        StringBuffer max_num = new StringBuffer(String.valueOf(num));

        // 找到一个高位替换成 9
        int max_length = max_num.length();
        for (int i = 0; i < max_length; ++i) {
            char digit = max_num.charAt(i);
            if (digit != '9') {
                replace(max_num, digit, '9');
                break;
            }
        }

        // 将最高位替换成 1
        // 或者找到一个与最高位不相等的高位替换成 0
        int min_length = min_num.length();
        for (int i = 0; i < min_length; ++i) {
            char digit = min_num.charAt(i);
            if (i == 0) {
                if (digit != '1') {
                    replace(min_num, digit, '1');
                    break;
                }
            }
            else {
                if (digit != '0' && digit != min_num.charAt(0)) {
                    replace(min_num, digit, '0');
                    break;
                }
            }
        }

        return Integer.parseInt(max_num.toString()) - Integer.parseInt(min_num.toString());
    }

    public void replace(StringBuffer s, char x, char y) {
        int length = s.length();
        for (int i = 0; i < length; ++i) {
            if (s.charAt(i) == x) {
                s.setCharAt(i, y);
            }
        }
    }
}
```

```CSharp
public class Solution {
    public int MaxDiff(int num) {
        // 替换字符串中的字符
        void Replace(ref string s, char x, char y) {
            s = s.Replace(x, y);
        }
        string minNum = num.ToString();
        string maxNum = num.ToString();
        // 找到一个高位替换成 9
        foreach (char digit in maxNum) {
            if (digit != '9') {
                Replace(ref maxNum, digit, '9');
                break;
            }
        }
        // 将最高位替换成 1
        // 或者找到一个与最高位不相等的高位替换成 0
        for (int i = 0; i < minNum.Length; ++i) {
            char digit = minNum[i];
            if (i == 0) {
                if (digit != '1') {
                    Replace(ref minNum, digit, '1');
                    break;
                }
            }
            else {
                if (digit != '0' && digit != minNum[0]) {
                    Replace(ref minNum, digit, '0');
                    break;
                }
            }
        }
        return int.Parse(maxNum) - int.Parse(minNum);
    }
}
```

```Go
func maxDiff(num int) int {
    // 替换字符串中的字符
    replace := func(s string, x, y byte) string {
        return strings.ReplaceAll(s, string(x), string(y))
    }
    minNum := strconv.Itoa(num)
    maxNum := strconv.Itoa(num)
    // 找到一个高位替换成 9
    for _, digit := range maxNum {
        if digit != '9' {
            maxNum = replace(maxNum, byte(digit), '9')
            break
        }
    }
    // 将最高位替换成 1
    // 或者找到一个与最高位不相等的高位替换成 0
    for i := 0; i < len(minNum); i++ {
        digit := minNum[i]
        if i == 0 {
            if digit != '1' {
                minNum = replace(minNum, digit, '1')
                break
            }
        } else {
            if digit != '0' && digit != minNum[0] {
                minNum = replace(minNum, digit, '0')
                break
            }
        }
    }

    max, _ := strconv.Atoi(maxNum)
    min, _ := strconv.Atoi(minNum)
    return max - min
}
```

```C
void replace(char* s, char x, char y) {
    for (int i = 0; s[i]; ++i) {
        if (s[i] == x) {
            s[i] = y;
        }
    }
}

int maxDiff(int num) {
    char minNum[20], maxNum[20];
    sprintf(minNum, "%d", num);
    sprintf(maxNum, "%d", num);
    // 找到一个高位替换成 9
    for (int i = 0; maxNum[i]; ++i) {
        if (maxNum[i] != '9') {
            replace(maxNum, maxNum[i], '9');
            break;
        }
    }
    // 将最高位替换成 1
    // 或者找到一个与最高位不相等的高位替换成 0
    for (int i = 0; minNum[i]; ++i) {
        char digit = minNum[i];
        if (i == 0) {
            if (digit != '1') {
                replace(minNum, digit, '1');
                break;
            }
        } else {
            if (digit != '0' && digit != minNum[0]) {
                replace(minNum, digit, '0');
                break;
            }
        }
    }

    return atoi(maxNum) - atoi(minNum);
}
```

```JavaScript
var maxDiff = function(num) {
    // 替换字符串中的字符
    const replace = (s, x, y) => s.split(x).join(y);
    let minNum = num.toString();
    let maxNum = num.toString();
    // 找到一个高位替换成 9
    for (let digit of maxNum) {
        if (digit !== '9') {
            maxNum = replace(maxNum, digit, '9');
            break;
        }
    }

    // 将最高位替换成 1
    // 或者找到一个与最高位不相等的高位替换成 0
    for (let i = 0; i < minNum.length; ++i) {
        let digit = minNum[i];
        if (i === 0) {
            if (digit !== '1') {
                minNum = replace(minNum, digit, '1');
                break;
            }
        } else {
            if (digit !== '0' && digit !== minNum[0]) {
                minNum = replace(minNum, digit, '0');
                break;
            }
        }
    }

    return parseInt(maxNum) - parseInt(minNum);
}
```

```TypeScript
function maxDiff(num: number): number {
    // 替换字符串中的字符
    const replace = (s: string, x: string, y: string): string => s.split(x).join(y);
    let minNum: string = num.toString();
    let maxNum: string = num.toString();
    // 找到一个高位替换成 9
    for (let digit of maxNum) {
        if (digit !== '9') {
            maxNum = replace(maxNum, digit, '9');
            break;
        }
    }
    // 将最高位替换成 1
    // 或者找到一个与最高位不相等的高位替换成 0
    for (let i = 0; i < minNum.length; ++i) {
        let digit = minNum[i];
        if (i === 0) {
            if (digit !== '1') {
                minNum = replace(minNum, digit, '1');
                break;
            }
        } else {
            if (digit !== '0' && digit !== minNum[0]) {
                minNum = replace(minNum, digit, '0');
                break;
            }
        }
    }

    return parseInt(maxNum) - parseInt(minNum);
};
```

```Rust
impl Solution {
    pub fn max_diff(num: i32) -> i32 {
        // 替换字符串中的字符
        fn replace(s: &str, x: char, y: char) -> String {
            s.chars().map(|c| if c == x { y } else { c }).collect()
        }
        let mut min_num = num.to_string();
        let mut max_num = num.to_string();
        // 找到一个高位替换成 9
        for digit in max_num.chars() {
            if digit != '9' {
                max_num = replace(&max_num, digit, '9');
                break;
            }
        }
        // 将最高位替换成 1
        // 或者找到一个与最高位不相等的高位替换成 0
        for (i, digit) in min_num.chars().enumerate() {
            if i == 0 {
                if digit != '1' {
                    min_num = replace(&min_num, digit, '1');
                    break;
                }
            } else {
                if digit != '0' && digit != min_num.chars().nth(0).unwrap() {
                    min_num = replace(&min_num, digit, '0');
                    break;
                }
            }
        }

        max_num.parse::<i32>().unwrap() - min_num.parse::<i32>().unwrap()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(log(num))$，我们最多只需要枚举 $num$ 的每个数位一次。
- 空间复杂度：$O(1)$。
