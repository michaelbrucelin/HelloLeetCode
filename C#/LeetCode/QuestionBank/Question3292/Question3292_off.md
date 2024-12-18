### [形成目标字符串需要的最少字符串数 II](https://leetcode.cn/problems/minimum-number-of-valid-strings-to-form-target-ii/solutions/3014796/xing-cheng-mu-biao-zi-fu-chuan-xu-yao-de-pl2j/)

#### 方法一：KMP + 动态规划

**思路与算法**

首先我们对每一个 $words$ 中的单词和 $target$ 使用「Knuth–Morris–Pratt」 算法，可以求出对于结束在 $target[i]$ 的前缀，所能够匹配单词的最长前缀 $back[i]$。

然后我们用「动态规划」解决本题目，用 $dp[i]$ 表示形成前 $n$ 个字母需要的最少字符串数。初始化 $dp[0]$ 为零，其他为大整数。因为题目的性质可以观察到，$dp$ 是单调递增数列，并推导递推公式 $dp[i+1]=dp[i+1-back[i]]+1$。

最后返回 $dp[n]$ 为结果。

**代码**

```C++
class Solution {
public:
    int minValidStrings(vector<string>& words, string target) {
        auto prefix_function = [](const string& word, const string& target) -> vector<int> {
            string s = word + '#' + target;
            int n = s.size();
            vector<int> pi(n, 0);
            for (int i = 1; i < n; i++) {
                int j = pi[i - 1];
                while (j > 0 && s[i] != s[j]) {
                    j = pi[j - 1];
                }
                if (s[i] == s[j]) {
                    j++;
                }
                pi[i] = j;
            }
            return pi;
        };

        int n = target.size();
        vector<int> back(n, 0);
        for (const string& word : words) {
            vector<int> pi = prefix_function(word, target);
            int m = word.size();
            for (int i = 0; i < n; i++) {
                back[i] = max(back[i], pi[m + 1 + i]);
            }
        }

        vector<int> dp(n + 1, 0);
        for (int i = 1; i <= n; i++) {
            dp[i] = 1e9;
        }
        for (int i = 0; i < n; i++) {
            dp[i + 1] = dp[i + 1 - back[i]] + 1;
            if (dp[i + 1] > n) {
                return -1;
            }
        }
        return dp[n];
    }
};
```

```Java
class Solution {
    public int minValidStrings(String[] words, String target) {
        int n = target.length();
        int[] back = new int[n];
        for (String word : words) {
            int[] pi = prefixFunction(word, target);
            int m = word.length();
            for (int i = 0; i < n; i++) {
                back[i] = Math.max(back[i], pi[m + 1 + i]);
            }
        }
        int[] dp = new int[n + 1];
        Arrays.fill(dp, 1, n + 1, (int) 1e9);
        for (int i = 0; i < n; i++) {
            dp[i + 1] = dp[i + 1 - back[i]] + 1;
            if (dp[i + 1] > n) {
                return -1;
            }
        }
        return dp[n];
    }

    private int[] prefixFunction(String word, String target) {
        String s = word + "#" + target;
        int n = s.length();
        int[] pi = new int[n];
        for (int i = 1; i < n; i++) {
            int j = pi[i - 1];
            while (j > 0 && s.charAt(i) != s.charAt(j)) {
                j = pi[j - 1];
            }
            if (s.charAt(i) == s.charAt(j)) {
                j++;
            }
            pi[i] = j;
        }
        return pi;
    }
}
```

```Python
class Solution:
    def minValidStrings(self, words: List[str], target: str) -> int:
        def prefix_function(word, target):
            s = word + '#' + target
            n = len(s)
            pi = [0] * n
            for i in range(1, n):
                j = pi[i - 1]
                while j > 0 and s[i] != s[j]:
                    j = pi[j - 1]
                if s[i] == s[j]:
                    j += 1
                pi[i] = j
            return pi
        n = len(target)
        back = [0] * n
        for word in words:
            pi = prefix_function(word, target)
            m = len(word)
            for i in range(n):
                back[i] = max(back[i], pi[m + 1 + i])
        dp = [0] + [10 ** 9] * n
        for i in range(n):
            dp[i + 1] = dp[i + 1 - back[i]] + 1
            if dp[i + 1] > n:
                return -1
        return dp[n]
```

```JavaScript
var minValidStrings = function(words, target) {
    const prefixFunction = (word, target) => {
        const s = word + '#' + target;
        const n = s.length;
        const pi = new Array(n).fill(0);
        for (let i = 1; i < n; i++) {
            let j = pi[i - 1];
            while (j > 0 && s[i] !== s[j]) {
                j = pi[j - 1];
            }
            if (s[i] === s[j]) {
                j++;
            }
            pi[i] = j;
        }
        return pi;
    };

    const n = target.length;
    const back = new Array(n).fill(0);
    for (const word of words) {
        const pi = prefixFunction(word, target);
        const m = word.length;
        for (let i = 0; i < n; i++) {
            back[i] = Math.max(back[i], pi[m + 1 + i]);
        }
    }

    const dp = new Array(n + 1).fill(0);
    for (let i = 1; i <= n; i++) {
        dp[i] = 1e9;
    }
    for (let i = 0; i < n; i++) {
        dp[i + 1] = dp[i + 1 - back[i]] + 1;
        if (dp[i + 1] > n) {
            return -1;
        }
    }
    return dp[n];
};
```

```TypeScript
function minValidStrings(words: string[], target: string): number {
    const prefixFunction = (word, target) => {
        const s = word + '#' + target;
        const n = s.length;
        const pi = new Array(n).fill(0);
        for (let i = 1; i < n; i++) {
            let j = pi[i - 1];
            while (j > 0 && s[i] !== s[j]) {
                j = pi[j - 1];
            }
            if (s[i] === s[j]) {
                j++;
            }
            pi[i] = j;
        }
        return pi;
    };

    const n = target.length;
    const back = new Array(n).fill(0);
    for (const word of words) {
        const pi = prefixFunction(word, target);
        const m = word.length;
        for (let i = 0; i < n; i++) {
            back[i] = Math.max(back[i], pi[m + 1 + i]);
        }
    }

    const dp = new Array(n + 1).fill(0);
    for (let i = 1; i <= n; i++) {
        dp[i] = 1e9;
    }
    for (let i = 0; i < n; i++) {
        dp[i + 1] = dp[i + 1 - back[i]] + 1;
        if (dp[i + 1] > n) {
            return -1;
        }
    }
    return dp[n];
};
```

```Go
func minValidStrings(words []string, target string) int {
    prefixFunction := func(word, target string) []int {
        s := word + "#" + target
        n := len(s)
        pi := make([]int, n)
        for i := 1; i < n; i++ {
            j := pi[i - 1]
            for j > 0 && s[i] != s[j] {
                j = pi[j - 1]
            }
            if s[i] == s[j] {
                j++
            }
            pi[i] = j
        }
        return pi
    }

    n := len(target)
    back := make([]int, n)
    for _, word := range words {
        pi := prefixFunction(word, target)
        m := len(word)
        for i := 0; i < n; i++ {
            back[i] = int(math.Max(float64(back[i]), float64(pi[m + 1 + i])))
        }
    }

    dp := make([]int, n + 1)
    for i := 1; i <= n; i++ {
        dp[i] = int(1e9)
    }
    for i := 0; i < n; i++ {
        dp[i + 1] = dp[i + 1 - back[i]] + 1
        if dp[i + 1] > n {
            return -1
        }
    }
    return dp[n]
}
```

```CSharp
public class Solution {
    public int MinValidStrings(string[] words, string target) {
        int n = target.Length;
        int[] back = new int[n];
        foreach (string word in words) {
            int[] pi = PrefixFunction(word, target);
            int m = word.Length;
            for (int i = 0; i < n; i++) {
                back[i] = Math.Max(back[i], pi[m + 1 + i]);
            }
        }
        int[] dp = Enumerable.Repeat(1000000000, n + 1).ToArray();
        dp[0] = 0;
        for (int i = 0; i < n; i++) {
            dp[i + 1] = dp[i + 1 - back[i]] + 1;
            if (dp[i + 1] > n) {
                return -1;
            }
        }
        return dp[n];
    }

    private int[] PrefixFunction(string word, string target) {
        string s = word + "#" + target;
        int n = s.Length;
        int[] pi = new int[n];
        for (int i = 1; i < n; i++) {
            int j = pi[i - 1];
            while (j > 0 && s[i] != s[j]) {
                j = pi[j - 1];
            }
            if (s[i] == s[j]) {
                j++;
            }
            pi[i] = j;
        }
        return pi;
    }
}
```

```C
int* prefix_function(const char* word, const char* target) {
    char* s = malloc(strlen(word) + strlen(target) + 2);
    strcpy(s, word);
    strcat(s, "#");
    strcat(s, target);
    int n = strlen(s);
    int* pi = (int*)malloc(sizeof(int) * n);
    for (int i = 0; i < n; i++) {
        pi[i] = 0;
    }
    for (int i = 1; i < n; i++) {
        int j = pi[i - 1];
        while (j > 0 && s[i] != s[j]) {
            j = pi[j - 1];
        }
        if (s[i] == s[j]) {
            j++;
        }
        pi[i] = j;
    }
    free(s);
    return pi;
}

int minValidStrings(char** words, int wordsSize, const char* target) {
    int n = strlen(target);
    int* back = (int*)malloc(sizeof(int) * n);
    for (int i = 0; i < n; i++) {
        back[i] = 0;
    }
    for (int k = 0; k < wordsSize; k++) {
        int* pi = prefix_function(words[k], target);
        int m = strlen(words[k]);
        for (int i = 0; i < n; i++) {
            if (pi[m + 1 + i] > back[i]) {
                back[i] = pi[m + 1 + i];
            }
        }
        free(pi);
    }

    int* dp = (int*)malloc(sizeof(int) * (n + 1));
    dp[0] = 0;
    for (int i = 1; i <= n; i++) {
        dp[i] = 1000000000;
    }
    for (int i = 0; i < n; i++) {
        dp[i + 1] = dp[i + 1 - back[i]] + 1;
        if (dp[i + 1] > n) {
            break
        }
    }
    int res = dp[n];
    free(back);
    free(dp);
    return res;
}

```

```Rust
pub fn prefix_function(word: &str, target: &str) -> Vec<usize> {
    let s = word.to_owned() + "#" + target;
    let n = s.len();
    let mut pi = vec![0; n];
    for i in 1..n {
        let mut j = pi[i - 1];
        while j > 0 && s.as_bytes()[i] != s.as_bytes()[j] {
            j = pi[j - 1];
        }
        if s.as_bytes()[i] == s.as_bytes()[j] {
            j += 1;
        }
        pi[i] = j;
    }
    pi
}

impl Solution {
    pub fn min_valid_strings(words: Vec<String>, target: String) -> i32 {
        let n = target.len();
        let mut back = vec![0; n];
        for word in words {
            let pi = prefix_function(&word, &target);
            let m = word.len();
            for i in 0..n {
                back[i] = std::cmp::max(back[i], pi[m + 1 + i]);
            }
        }

        let mut dp = vec![0; n + 1];
        for i in 1..=n {
            dp[i] = 1_000_000_000;
        }
        for i in 0..n {
            dp[i + 1] = dp[i + 1 - back[i]] + 1;
            if dp[i + 1] > n as i32 {
                return -1;
            }
        }
        dp[n] as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(k \times (m+n))$，其中 $k$ 是数组的长度，$m$ 是单词的长度，$n$ 是 $target$ 长度。
- 空间复杂度：$O(m+n)$，其中 $m$ 是单词的长度，$n$ 是 $target$ 长度。
