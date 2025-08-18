### [6 和 9 组成的最大数字](https://leetcode.cn/problems/maximum-69-number/solutions/101258/6-he-9-zu-cheng-de-zui-da-shu-zi-by-leetcode-solut/)

#### 方法一：贪心 $+$ 字符串

**思路与算法**

此题要求将一个由数字 $6$ 和 $9$ 构成的十进制数 $num$ 进行至多一次 $6$ 和 $9$ 之间的翻转得到的最大数字。由十进制数的性质易知：贪心的选择数位最高的一个 $6$ 变成 $9$，得到的答案就是最大的。如果不存在这样的 $6$，则说明这个数字全由数字 $9$ 构成。根据题意，此时不对 $num$ 做任何更改即为最优解。

对于算法实现，我们使用字符数组来处理 $num$ 较为方便。首先将 $num$ 转为字符数组，然后从左到遍历字符，按上述算法处理。最后将修改后的字符数组转回数字即为所求。

**代码**

```C++
class Solution {
public:
    int maximum69Number (int num) {
        string s = to_string(num);
        for (char &c : s) {
            if (c == '6') {
                c = '9';
                break;
            }
        }
        return stoi(s);
    }
};
```

```Java
public class Solution {
    public int maximum69Number (int num) {
        char[] chars = Integer.toString(num).toCharArray();
        for (int i = 0; i < chars.length; i++) {
            if (chars[i] == '6') {
                chars[i] = '9';
                break;
            }
        }
        return Integer.parseInt(new String(chars));
    }
}
```

```CSharp
public class Solution {
    public int Maximum69Number (int num) {
        char[] chars = num.ToString().ToCharArray();
        for (int i = 0; i < chars.Length; i++) {
            if (chars[i] == '6') {
                chars[i] = '9';
                break;
            }
        }
        return int.Parse(new string(chars));
    }
}
```

```Go
func maximum69Number(num int) int {
    s := strconv.Itoa(num)
    chars := []byte(s)
    for i := 0; i < len(chars); i++ {
        if chars[i] == '6' {
            chars[i] = '9'
            break
        }
    }
    result, _ := strconv.Atoi(string(chars))
    return result
}
```

```Python
class Solution:
    def maximum69Number (self, num: int) -> int:
        s = list(str(num))
        for i in range(len(s)):
            if s[i] == '6':
                s[i] = '9'
                break
        return int(''.join(s))
```

```C
int maximum69Number(int num) {
    char s[20];
    sprintf(s, "%d", num);
    for (int i = 0; s[i] != '\0'; i++) {
        if (s[i] == '6') {
            s[i] = '9';
            break;
        }
    }
    return atoi(s);
}
```

```Rust
impl Solution {
    pub fn maximum69_number (num: i32) -> i32 {
        let mut s = num.to_string().chars().collect::<Vec<char>>();
        for i in 0..s.len() {
            if s[i] == '6' {
                s[i] = '9';
                break;
            }
        }
        s.iter().collect::<String>().parse().unwrap()
    }
}
```

```JavaScript
var maximum69Number = function (num) {
    let charArray = [...num.toString()];

    for (let i = 0; i < charArray.length; i++) {
        if (charArray[i] === '6') {
            charArray[i] = '9';
            break;
        }
    }

    return Number(charArray.join(''));
};
```

```TypeScript
function maximum69Number(num: number): number {
    let charArray = [...num.toString()];

    for (let i = 0; i < charArray.length; i++) {
        if (charArray[i] === '6') {
            charArray[i] = '9';
            break;
        }
    }

    return Number(charArray.join(''));
};
```

**复杂度分析**

- 时间复杂度：$O(\log num)$。
- 空间复杂度：$O(\log num)$。

#### 方法二：贪心 $+$ 数学

**思路与算法**

思想同方法一，但是不依赖字符串操作，而是通过纯数学的方式找到最高位的 $6$ 并更改为 $9$。

首先初始化一个基数 $digitBase=10^{\lfloor \log_{10}(num)\rfloor}$，这个基数代表了 $num$ 的最高位。然后从高位向低位遍历，每次将 $digitBase$ 除以 $10$。在每一次循环中，通过 $\lfloor num÷digitBase\rfloor mod 10$ 来获取当前基数 $digitBase$ 所在的十进制位上的数字。一旦这个数字等于 $6$，我们就可以确定这就是需要修改的最高位的 $6$。此时，我们将 $num$ 加上 $3\times digitBase$，即可将该位的 $6$ 修改为 $9$，结果即为所求。

**代码**

```C++
class Solution {
public:
    int maximum69Number (int num) {
        int digitBase = pow(10, (int)log10(num));
        while (digitBase > 0) {
            if ((num / digitBase) % 10 == 6) {
                num += 3 * digitBase;
                return num;
            }
            digitBase /= 10;
        }
        
        return num;
    }
};
```

```Java
public class Solution {
    public int maximum69Number (int num) {
        int digitBase = (int)Math.pow(10, (int)Math.log10(num));
        while (digitBase > 0) {
            if ((num / digitBase) % 10 == 6) {
                num += 3 * digitBase;
                return num;
            }
            digitBase /= 10;
        }
        
        return num;
    }
}
```

```CSharp
public class Solution {
    public int Maximum69Number (int num) {
        int digitBase = (int)Math.Pow(10, (int)Math.Log10(num));
        while (digitBase > 0) {
            if ((num / digitBase) % 10 == 6) {
                num += 3 * digitBase;
                return num;
            }
            digitBase /= 10;
        }
        
        return num;
    }
}
```

```Go
func maximum69Number(num int) int {
    digitBase := int(math.Pow10(int(math.Log10(float64(num)))))
    for digitBase > 0 {
        if (num / digitBase) % 10 == 6 {
            num += 3 * digitBase
            return num
        }
        digitBase /= 10
    }
    
    return num
}
```

```Python
class Solution:
    def maximum69Number (self, num: int) -> int:
        digit_base = 10 ** int(math.log10(num)) if num != 0 else 0
        while digit_base > 0:
            if (num // digit_base) % 10 == 6:
                num += 3 * digit_base
                return num
            digit_base = digit_base // 10
        
        return num
```

```C
int maximum69Number(int num) {
    int digitBase = pow(10, (int)log10(num));
    while (digitBase > 0) {
        if ((num / digitBase) % 10 == 6) {
            num += 3 * digitBase;
            return num;
        }
        digitBase /= 10;
    }
    
    return num;
}
```

```Rust
impl Solution {
    pub fn maximum69_number (num: i32) -> i32 {
        let mut digit_base = 10i32.pow((num as f32).log10() as u32);
        let mut num = num;
        while digit_base > 0 {
            if (num / digit_base) % 10 == 6 {
                num += 3 * digit_base;
                return num;
            }
            digit_base /= 10;
        }
        
        num
    }
}
```

```JavaScript
var maximum69Number = function (num) {
    let digitBase = Math.pow(10, Math.trunc(Math.log10(num)));

    while (digitBase > 0) {
        if (Math.trunc(num / digitBase) % 10 === 6) {
            num += 3 * digitBase;
            return num;
        }
        digitBase = Math.trunc(digitBase / 10);
    }

    return num;
};
```

```TypeScript
function maximum69Number(num: number): number {
    let digitBase = Math.pow(10, Math.trunc(Math.log10(num)));

    while (digitBase > 0) {
        if (Math.trunc(num / digitBase) % 10 === 6) {
            num += 3 * digitBase;
            return num;
        }
        digitBase = Math.trunc(digitBase / 10);
    }

    return num;
};
```

**复杂度分析**

- 时间复杂度：$O(\log num)$。
- 空间复杂度：$O(1)$。
