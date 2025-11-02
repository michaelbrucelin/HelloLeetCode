### [复数乘法](https://leetcode.cn/problems/complex-number-multiplication/solutions/1283204/fu-shu-cheng-fa-by-leetcode-solution-163i/)

#### 方法一：模拟

复数可以写成 $a+bi$ 的形式，其中 $a,b\in R$，a 是实部，$b$ 是虚部，$i$ 是虚数单位，$i^2=-1$。

对于给定的两个复数 $num_1$ 和 $num_2$，首先分别得到两个复数的实部和虚部，然后计算两个复数的乘法。用 $real_1$ 和 $imag_1$ 分别表示 $num_1$ 的实部和虚部，用 $real_2$ 和 $imag_2$ 分别表示 $num_2$ 的实部和虚部，则两个复数的乘法计算如下：

$$\begin{array}{ccl}
& & (real_1+imag_1\times i)\times (real_2+imag_2\times i) \\ & = & real_1\times real_2+real_1\times imag_2\times i+imag_1\times real_2\times i+imag_1\times imag_2\times i^2 \\ & = & real_1\times real_2+real_1\times imag_2\times i+imag_1\times real_2\times i-imag_1\times imag_2 \\ & = & (real_1\times real_2-imag_1\times imag_2)+(real_1\times imag_2+imag_1\times real_2)\times i
\end{array}$$

得到两个复数的乘积之后，将乘积转换成复数格式的字符串并返回。

```Python
class Solution:
    def complexNumberMultiply(self, num1: str, num2: str) -> str:
        real1, imag1 = map(int, num1[:-1].split('+'))
        real2, imag2 = map(int, num2[:-1].split('+'))
        return f'{real1 * real2 - imag1 * imag2}+{real1 * imag2 + imag1 * real2}i'
```

```Java
class Solution {
    public String complexNumberMultiply(String num1, String num2) {
        String[] complex1 = num1.split("\\+|i");
        String[] complex2 = num2.split("\\+|i");
        int real1 = Integer.parseInt(complex1[0]);
        int imag1 = Integer.parseInt(complex1[1]);
        int real2 = Integer.parseInt(complex2[0]);
        int imag2 = Integer.parseInt(complex2[1]);
        return String.format("%d+%di", real1 * real2 - imag1 * imag2, real1 * imag2 + imag1 * real2);
    }
}
```

```CSharp
public class Solution {
    public string ComplexNumberMultiply(string num1, string num2) {
        string[] complex1 = num1.Split(new char[2]{'+','i'});
        string[] complex2 = num2.Split(new char[2]{'+','i'});
        int real1 = int.Parse(complex1[0]);
        int imag1 = int.Parse(complex1[1]);
        int real2 = int.Parse(complex2[0]);
        int imag2 = int.Parse(complex2[1]);
        return string.Format("{0}+{1}i", real1 * real2 - imag1 * imag2, real1 * imag2 + imag1 * real2);
    }
}
```

```C++
class Solution {
public:
    string complexNumberMultiply(string num1, string num2) {
        regex re("\\+|i"); 
        vector<string> complex1(sregex_token_iterator(num1.begin(), num1.end(), re, -1), std::sregex_token_iterator());
        vector<string> complex2(sregex_token_iterator(num2.begin(), num2.end(), re, -1), std::sregex_token_iterator());
        int real1 = stoi(complex1[0]);
        int imag1 = stoi(complex1[1]);
        int real2 = stoi(complex2[0]);
        int imag2 = stoi(complex2[1]);
        return to_string(real1 * real2 - imag1 * imag2) + "+" + to_string(real1 * imag2 + imag1 * real2) + "i";
    }
};
```

```C
bool parseComplexNumber(const char * num, int * real, int * image) {
    char *token = strtok(num, "+");
    *real = atoi(token);
    token = strtok(NULL, "i");
    *image = atoi(token);
    return true;
};

char * complexNumberMultiply(char * num1, char * num2){
    int real1 = 0, imag1 = 0;
    int real2 = 0, imag2 = 0;
    char * res = (char *)malloc(sizeof(char) * 20);
    parseComplexNumber(num1, &real1, &imag1);
    parseComplexNumber(num2, &real2, &imag2);
    snprintf(res, 20, "%d+%di", real1 * real2 - imag1 * imag2, real1 * imag2 + imag1 * real2);
    return res;
}
```

```JavaScript
var complexNumberMultiply = function(num1, num2) {
    const complex1 = [num1.split("+")[0], num1.split("+")[1].split("i")[0]];
    const complex2 = [num2.split("+")[0], num2.split("+")[1].split("i")[0]];
    const real1 = parseInt(complex1[0]);
    const imag1 = parseInt(complex1[1]);
    const real2 = parseInt(complex2[0]);
    const imag2 = parseInt(complex2[1]);
    return '' + real1 * real2 - imag1 * imag2 + '+' + (real1 * imag2 + imag1 * real2) + 'i';
};
```

```Go
func parseComplexNumber(num string) (real, imag int) {
    i := strings.IndexByte(num, '+')
    real, _ = strconv.Atoi(num[:i])
    imag, _ = strconv.Atoi(num[i+1 : len(num)-1])
    return
}

func complexNumberMultiply(num1, num2 string) string {
    real1, imag1 := parseComplexNumber(num1)
    real2, imag2 := parseComplexNumber(num2)
    return fmt.Sprintf("%d+%di", real1*real2-imag1*imag2, real1*imag2+imag1*real2)
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。由于两个复数字符串的长度都很小，因此可以将字符串处理的时间视为常数。
- 空间复杂度：$O(1)$。
