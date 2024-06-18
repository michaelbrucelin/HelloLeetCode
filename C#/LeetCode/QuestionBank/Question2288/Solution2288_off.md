### [价格减免](https://leetcode.cn/problems/apply-discount-to-prices/solutions/2809596/jie-ge-jian-mian-by-leetcode-solution-m8tx/)

#### 方法一：模拟

**思路与算法**

我们按照题目中的要求进行模拟即可。

首先我们将给定的字符串 $\textit{sentence}$ 根据空格进行分割，得到其中的每一个单词。随后我们遍历每个单词，如果该单词：

- 以 $ 开头；
- 后续至少有一个字符，且均在 $[0, 9]$ 中；

那么该单词就表示一个价格。我们提取后续的字符，转换成整数，计算折扣（即乘上 $1 - \dfrac{\textit{discount}}{100}$），保留两位小数，再转换回字符串，并添加开头的 $ 即可。

当所有单词遍历完成之后，我们就可以再加上空格，得到最终的字符串。

**代码**

```C++
class Solution {
public:
    string discountPrices(string sentence, int discount) {
        stringstream sin(sentence), sout;
        sout << fixed << setprecision(2);

        vector<string> words;
        string word;
        while (sin >> word) {
            if (word[0] == '$' && word.size() > 1 && all_of(word.begin() + 1, word.end(), ::isdigit)) {
                double price = stoll(word.substr(1, word.size() - 1)) * (1.0 - discount / 100.0);
                sout << '$' << price;
            }
            else {
                sout << word;
            }
            sout << " ";
        }
        string ans = sout.str();
        ans.pop_back();
        return ans;
    }
};
```

```Java
class Solution {
    public String discountPrices(String sentence, int discount) {
        String[] words = sentence.split(" ");
        for (int i = 0; i < words.length; i++) {
            String word = words[i];
            if (word.charAt(0) == '$' && isNumeric(word.substring(1))) {
                double price = Long.parseLong(word.substring(1)) * (1 - discount / 100.0);
                words[i] = String.format("$%.2f", price);
            }
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < words.length; i++) {
            if (i > 0) {
                sb.append(" ");
            }
            sb.append(words[i]);
        }
        return sb.toString();
    }

    public boolean isNumeric(String s) {
        if (s.isEmpty()) {
            return false;
        }
        for (int i = 0; i < s.length(); i++) {
            if (!Character.isDigit(s.charAt(i))) {
                return false;
            }
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public string DiscountPrices(string sentence, int discount) {
        string[] words = sentence.Split(" ");
        for (int i = 0; i < words.Length; i++) {
            string word = words[i];
            if (word[0] == '$' && IsNumeric(word.Substring(1))) {
                double price = long.Parse(word.Substring(1)) * (1 - discount / 100.0);
                words[i] = string.Format("${0:f2}", price);
            }
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < words.Length; i++) {
            if (i > 0) {
                sb.Append(" ");
            }
            sb.Append(words[i]);
        }
        return sb.ToString();
    }

    public bool IsNumeric(string s) {
        if (s.Length == 0) {
            return false;
        }
        foreach (char c in s) {
            if (!char.IsDigit(c)) {
                return false;
            }
        }
        return true;
    }
}
```

```Python
class Solution:
    def discountPrices(self, sentence: str, discount: int) -> str:
        words = sentence.split()
        for i, word in enumerate(words):
            if word[0] == "$" and word[1:].isnumeric():
                price = int(word[1:]) * (1 - discount / 100)
                words[i] = f"${price:.2f}"
        return " ".join(words)
```

```C
 bool isNumeric(const char *s) {
    int len = strlen(s);
    if (len == 0) {
        return false;
    }
    for (int i = 0; i < len; i++) {
        if (!isdigit(s[i])) {
            return false;
        }
    }
    return true;
}

char* discountPrices(char* sentence, int discount) {
    char *ans = (char *)calloc(strlen(sentence) * 4, sizeof(char));
    int pos = 0;
    int len = strlen(sentence);
    char *token = strtok(sentence, " ");
    while (token != NULL) {
        if (token[0] == '$' && isNumeric(token + 1)) {
            double price = atol(token + 1) * (1 - discount / 100.0);
            pos += sprintf(ans + pos, "$%0.2f ", price);
        } else {
            pos += sprintf(ans + pos, "%s ", token);
        }
        token = strtok(NULL, " ");
    }
    ans[pos - 1] = '\0';
    return ans;
}
```

```Go
func discountPrices(sentence string, discount int) string {
    words := strings.Split(sentence, " ")
    for i, word := range words {
        if strings.HasPrefix(word, "$") && isNumeric(word[1:]) {
            price, _ := strconv.Atoi(word[1:])
            discountedPrice := float64(price) * (1 - float64(discount)/100)
            words[i] = fmt.Sprintf("$%.2f", discountedPrice)
        }
    }
    return strings.Join(words, " ")
}

func isNumeric(s string) bool {
    match, _ := regexp.MatchString("^[0-9]+$", s)
    return match
}
```

```JavaScript
var discountPrices = function(sentence, discount) {
    let words = sentence.split(" ");
    for (let i = 0; i < words.length; i++) {
        let word = words[i];
        if (word.charAt(0) === '$' && isNumeric(word.substring(1))) {
            let price = parseInt(word.substring(1)) * (1 - discount / 100.0);
            words[i] = "$" + price.toFixed(2);
        }
    }
    let result = words.join(" ");
    return result;
};

const isNumeric = (s) => {
    return /^\d+$/.test(s);
}
```

```TypeScript
function discountPrices(sentence: string, discount: number): string {
    let words: string[] = sentence.split(" ");
    for (let i = 0; i < words.length; i++) {
        let word: string = words[i];
        if (word.charAt(0) === '$' && isNumeric(word.substring(1))) {
            let price: number = parseInt(word.substring(1)) * (1 - discount / 100.0);
            words[i] = "$" + price.toFixed(2);
        }
    }
    return words.join(" ");
};

function isNumeric(s: string): boolean {
    return /^\d+$/.test(s);
}
```

```Rust
impl Solution {
    pub fn discount_prices(sentence: String, discount: i32) -> String {
        let words: Vec<&str> = sentence.split_whitespace().collect();
        let mut replace: Vec<String> = Vec::new();
        for word in words.iter() {
            if word.starts_with("$") && word.len() > 1 && Self::is_numeric(&word[1..]) {
                let price: f64 = word[1..].parse().unwrap();
                let discounted_price = price * (1.0 - discount as f64 / 100.0);
                replace.push(format!("${:.2}", discounted_price));
            } else {
                replace.push(word.to_string());
            }
        }
        replace.join(" ")
    }

    fn is_numeric(s: &str) -> bool {
        s.chars().all(|c| c.is_digit(10))
    }
}

```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $\textit{sentence}$ 的长度。
- 空间复杂度：$O(n)$。
