### [作为子字符串出现在单词中的字符串数目](https://leetcode.cn/problems/number-of-strings-that-appear-as-substrings-in-word/solutions/936704/zuo-wei-zi-zi-fu-chuan-chu-xian-zai-dan-wmsp4/)

#### 方法一：暴力匹配

**思路与算法**

我们可以让字符串数组 $patterns$ 中的每个字符串 $pattern$ 都与 $word$ 匹配一次，同时统计其中为 $word$ 子串的字符串数目。

我们用函数 $check(pattern,word)$ 来判断字符串 $pattern$ 是否是 $word$ 的子串。我们假设 $pattern$ 的长度为 $m$。在该函数中，我们让 $pattern$ 与 $word$ 的每个长度为 $m$ 的子串均匹配一次。

为了减少不必要的匹配，我们每次匹配失败即立刻停止当前子串的匹配，对下一个子串继续匹配。如果当前子串匹配成功，我们返回 $true$；如果所有子串都匹配失败，则返回 $false$。

**代码**

```C++
class Solution {
public:
    int numOfStrings(vector<string>& patterns, string word) {
        auto check = [](const string& pattern, const string& word) -> bool{
            int m = pattern.size();
            int n = word.size();
            for (int i = 0; i + m <= n; ++i){
                bool flag = true;
                for (int j = 0; j < m; ++j){
                    if (word[i + j] != pattern[j]){
                        flag = false;
                        break;
                    }
                }
                if (flag){
                    return true;
                }
            }
            return false;
        };

        int res = 0;
        for (const string& pattern : patterns){
            res += check(pattern, word);
        }
        return res;
    }
};
```

```Python
class Solution:
    def numOfStrings(self, patterns: List[str], word: str) -> int:
        def check(pattern: str, word: str) -> bool:
            m = len(pattern)
            n = len(word)
            for i in range(n - m + 1):
                flag = True
                for j in range(m):
                    if word[i + j] != pattern[j]:
                        flag = False
                        break
                if flag:
                    return True
            return False

        res = 0
        for pattern in patterns:
            res += check(pattern, word)
        return res
```

```Java
class Solution {
    public int numOfStrings(String[] patterns, String word) {
        int res = 0;
        for (String pattern : patterns) {
            if (check(pattern, word)) {
                res++;
            }
        }
        return res;
    }

    private boolean check(String pattern, String word) {
        int m = pattern.length();
        int n = word.length();
        for (int i = 0; i + m <= n; i++) {
            boolean flag = true;
            for (int j = 0; j < m; j++) {
                if (word.charAt(i + j) != pattern.charAt(j)) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                return true;
            }
        }
        return false;
    }
}
```

```CSharp
public class Solution {
    public int NumOfStrings(string[] patterns, string word) {
        int res = 0;
        foreach (string pattern in patterns) {
            if (Check(pattern, word)) {
                res++;
            }
        }
        return res;
    }

    private bool Check(string pattern, string word) {
        int m = pattern.Length;
        int n = word.Length;
        for (int i = 0; i + m <= n; i++) {
            bool flag = true;
            for (int j = 0; j < m; j++) {
                if (word[i + j] != pattern[j]) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                return true;
            }
        }
        return false;
    }
}
```

```Go
func numOfStrings(patterns []string, word string) int {
    res := 0
    for _, pattern := range patterns {
        if check(pattern, word) {
            res++
        }
    }
    return res
}

func check(pattern string, word string) bool {
    m := len(pattern)
    n := len(word)
    for i := 0; i + m <= n; i++ {
        flag := true
        for j := 0; j < m; j++ {
            if word[i+j] != pattern[j] {
                flag = false
                break
            }
        }
        if flag {
            return true
        }
    }
    return false
}
```

```C
bool check(const char* pattern, const char* word) {
    int m = strlen(pattern);
    int n = strlen(word);
    for (int i = 0; i + m <= n; i++) {
        bool flag = true;
        for (int j = 0; j < m; j++) {
            if (word[i + j] != pattern[j]) {
                flag = false;
                break;
            }
        }
        if (flag) {
            return true;
        }
    }
    return false;
}

int numOfStrings(char** patterns, int patternsSize, char* word) {
    int res = 0;
    for (int i = 0; i < patternsSize; i++) {
        if (check(patterns[i], word)) {
            res++;
        }
    }
    return res;
}
```

```JavaScript
var numOfStrings = function(patterns, word) {
    const check = (pattern, word) => {
        const m = pattern.length;
        const n = word.length;
        for (let i = 0; i + m <= n; i++) {
            let flag = true;
            for (let j = 0; j < m; j++) {
                if (word[i + j] !== pattern[j]) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                return true;
            }
        }
        return false;
    };

    let res = 0;
    for (const pattern of patterns) {
        if (check(pattern, word)) {
            res++;
        }
    }
    return res;
};
```

```TypeScript
function numOfStrings(patterns: string[], word: string): number {
    const check = (pattern: string, word: string): boolean => {
        const m = pattern.length;
        const n = word.length;
        for (let i = 0; i + m <= n; i++) {
            let flag = true;
            for (let j = 0; j < m; j++) {
                if (word[i + j] !== pattern[j]) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                return true;
            }
        }
        return false;
    };

    let res = 0;
    for (const pattern of patterns) {
        if (check(pattern, word)) {
            res++;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn num_of_strings(patterns: Vec<String>, word: String) -> i32 {
        fn check(pattern: &str, word: &str) -> bool {
            let m = pattern.len();
            let n = word.len();
            if m > n {
                return false;
            }
            let word_bytes = word.as_bytes();
            let pattern_bytes = pattern.as_bytes();

            for i in 0..=n - m {
                let mut flag = true;
                for j in 0..m {
                    if word_bytes[i + j] != pattern_bytes[j] {
                        flag = false;
                        break;
                    }
                }
                if flag {
                    return true;
                }
            }
            false
        }

        let mut res = 0;
        for pattern in patterns {
            if check(&pattern, &word) {
                res += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\times \sum_i m_i)$，其中 $n$ 为字符串 $word$ 的长度，$m_i$ 为字符串 $patterns[i]$ 的长度。
 $  $ 对于 $patterns$ 中的每个字符串 $patterns[i]$，暴力匹配判断是否为 $word$ 子串的时间复杂度为 $O(n\times m_i)$。
- 空间复杂度：$O(1)$。

#### 方法二：$KMP$ 算法

**思路与算法**

在方法一中，每一次调用函数 $check(pattern,word)$ 进行判断都需要暴力比较 $pattern$ 与 $word$ 中所有长度为 $m$ 的子串，假设 $word$ 的长度为 $n$，则匹配的时间复杂度为 $O(nm)$。

我们可以对函数 $check(pattern,word)$ 中暴力比较的过程进行优化。在这里，我们使用 $KMP$ 算法对匹配过程进行优化。如果读者不熟悉 $KMP$ 算法，可以阅读[「28. 实现 $strStr()$ 的官方题解」](https://leetcode-cn.com/problems/implement-strstr/solution/shi-xian-strstr-by-leetcode-solution-ds6y/) 中的方法二。

**代码**

```C++
class Solution {
public:
    int numOfStrings(vector<string>& patterns, string word) {
        auto check = [](const string& pattern, const string& word) -> bool{
            int m = pattern.size();
            int n = word.size();
            // 生成 pattern 的前缀数组
            vector<int> pi(m);
            for (int i = 1, j = 0; i < m; i++){
                while (j > 0 && pattern[i] != pattern[j]){
                    j = pi[j - 1];
                }
                if (pattern[i] == pattern[j]){
                    ++j;
                }
                pi[i] = j;
            }
            // 利用前缀数组进行匹配
            for (int i = 0, j = 0; i < n; i++){
                while (j > 0 && word[i] != pattern[j]){
                    j = pi[j - 1];
                }
                if (word[i] == pattern[j]){
                    ++j;
                }
                if (j == m){
                    return true;
                }
            }
            return false;
        };

        int res = 0;
        for (const string& pattern : patterns){
            res += check(pattern, word);
        }
        return res;
    }
};
```

```Python
class Solution:
    def numOfStrings(self, patterns: List[str], word: str) -> int:
        def check(pattern: str, word: str) -> bool:
            m = len(pattern)
            n = len(word)
            # 生成 pattern 的前缀数组
            pi = [0] * m
            j = 0
            for i in range(1, m):
                while j and pattern[i] != pattern[j]:
                    j = pi[j - 1]
                if pattern[i] == pattern[j]:
                    j += 1
                pi[i] = j
            # 利用前缀数组进行匹配
            j = 0
            for i in range(n):
                while j and word[i] != pattern[j]:
                    j = pi[j - 1]
                if word[i] == pattern[j]:
                    j += 1
                if j == m:
                    return True
            return False

        res = 0
        for pattern in patterns:
            res += check(pattern, word)
        return res
```

```Java
class Solution {
    public int numOfStrings(String[] patterns, String word) {
        int res = 0;
        for (String pattern : patterns) {
            if (check(pattern, word)) {
                res++;
            }
        }
        return res;
    }

    private boolean check(String pattern, String word) {
        int m = pattern.length();
        int n = word.length();

        // 生成 pattern 的前缀数组
        int[] pi = new int[m];
        for (int i = 1, j = 0; i < m; i++) {
            while (j > 0 && pattern.charAt(i) != pattern.charAt(j)) {
                j = pi[j - 1];
            }
            if (pattern.charAt(i) == pattern.charAt(j)) {
                j++;
            }
            pi[i] = j;
        }

        // 利用前缀数组进行匹配
        for (int i = 0, j = 0; i < n; i++) {
            while (j > 0 && word.charAt(i) != pattern.charAt(j)) {
                j = pi[j - 1];
            }
            if (word.charAt(i) == pattern.charAt(j)) {
                j++;
            }
            if (j == m) {
                return true;
            }
        }
        return false;
    }
}
```

```CSharp
public class Solution {
    public int NumOfStrings(string[] patterns, string word) {
        int res = 0;
        foreach (string pattern in patterns) {
            if (check(pattern, word)) {
                res++;
            }
        }
        return res;
    }

    private bool check(string pattern, string word) {
        int m = pattern.Length;
        int n = word.Length;

        // 生成 pattern 的前缀数组
        int[] pi = new int[m];
        for (int i = 1, j = 0; i < m; i++) {
            while (j > 0 && pattern[i] != pattern[j]) {
                j = pi[j - 1];
            }
            if (pattern[i] == pattern[j]) {
                j++;
            }
            pi[i] = j;
        }

        // 利用前缀数组进行匹配
        for (int i = 0, j = 0; i < n; i++) {
            while (j > 0 && word[i] != pattern[j]) {
                j = pi[j - 1];
            }
            if (word[i] == pattern[j]) {
                j++;
            }
            if (j == m) {
                return true;
            }
        }
        return false;
    }
}
```

```Go
func numOfStrings(patterns []string, word string) int {
    res := 0
    for _, pattern := range patterns {
        if check(pattern, word) {
            res++
        }
    }
    return res
}

func check(pattern string, word string) bool {
    m := len(pattern)
    n := len(word)

    // 生成 pattern 的前缀数组
    pi := make([]int, m)
    for i, j := 1, 0; i < m; i++ {
        for j > 0 && pattern[i] != pattern[j] {
            j = pi[j-1]
        }
        if pattern[i] == pattern[j] {
            j++
        }
        pi[i] = j
    }

    // 利用前缀数组进行匹配
    for i, j := 0, 0; i < n; i++ {
        for j > 0 && word[i] != pattern[j] {
            j = pi[j-1]
        }
        if word[i] == pattern[j] {
            j++
        }
        if j == m {
            return true
        }
    }
    return false
}
```

```C
bool check(const char* pattern, const char* word) {
    int m = strlen(pattern);
    int n = strlen(word);

    // 生成 pattern 的前缀数组
    int* pi = (int*)malloc(m * sizeof(int));
    pi[0] = 0;
    for (int i = 1, j = 0; i < m; i++) {
        while (j > 0 && pattern[i] != pattern[j]) {
            j = pi[j - 1];
        }
        if (pattern[i] == pattern[j]) {
            j++;
        }
        pi[i] = j;
    }

    // 利用前缀数组进行匹配
    bool found = false;
    for (int i = 0, j = 0; i < n; i++) {
        while (j > 0 && word[i] != pattern[j]) {
            j = pi[j - 1];
        }
        if (word[i] == pattern[j]) {
            j++;
        }
        if (j == m) {
            found = true;
            break;
        }
    }

    free(pi);
    return found;
}

int numOfStrings(char** patterns, int patternsSize, char* word) {
    int res = 0;
    for (int i = 0; i < patternsSize; i++) {
        if (check(patterns[i], word)) {
            res++;
        }
    }
    return res;
}
```

```JavaScript
var numOfStrings = function(patterns, word) {
    const check = (pattern, word) => {
        const m = pattern.length;
        const n = word.length;


        // 生成 pattern 的前缀数组
        const pi = new Array(m).fill(0);
        for (let i = 1, j = 0; i < m; i++) {
            while (j > 0 && pattern[i] !== pattern[j]) {
                j = pi[j - 1];
            }
            if (pattern[i] === pattern[j]) {
                j++;
            }
            pi[i] = j;
        }

        // 利用前缀数组进行匹配
        for (let i = 0, j = 0; i < n; i++) {
            while (j > 0 && word[i] !== pattern[j]) {
                j = pi[j - 1];
            }
            if (word[i] === pattern[j]) {
                j++;
            }
            if (j === m) {
                return true;
            }
        }
        return false;
    };

    let res = 0;
    for (const pattern of patterns) {
        if (check(pattern, word)) {
            res++;
        }
    }
    return res;
};
```

```TypeScript
function numOfStrings(patterns: string[], word: string): number {
    const check = (pattern: string, word: string): boolean => {
        const m = pattern.length;
        const n = word.length;

        // 生成 pattern 的前缀数组
        const pi: number[] = new Array(m).fill(0);
        for (let i = 1, j = 0; i < m; i++) {
            while (j > 0 && pattern[i] !== pattern[j]) {
                j = pi[j - 1];
            }
            if (pattern[i] === pattern[j]) {
                j++;
            }
            pi[i] = j;
        }

        // 利用前缀数组进行匹配
        for (let i = 0, j = 0; i < n; i++) {
            while (j > 0 && word[i] !== pattern[j]) {
                j = pi[j - 1];
            }
            if (word[i] === pattern[j]) {
                j++;
            }
            if (j === m) {
                return true;
            }
        }
        return false;
    };

    let res = 0;
    for (const pattern of patterns) {
        if (check(pattern, word)) {
            res++;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn num_of_strings(patterns: Vec<String>, word: String) -> i32 {
        let mut res = 0;
        for pattern in patterns {
            if Self::check(&pattern, &word) {
                res += 1;
            }
        }
        res
    }

    fn check(pattern: &str, word: &str) -> bool {
        let m = pattern.len();
        let n = word.len();

        let pattern_bytes = pattern.as_bytes();
        let word_bytes = word.as_bytes();

        // 生成 pattern 的前缀数组
        let mut pi = vec![0; m];
        let mut j = 0;
        for i in 1..m {
            while j > 0 && pattern_bytes[i] != pattern_bytes[j] {
                j = pi[j - 1];
            }
            if pattern_bytes[i] == pattern_bytes[j] {
                j += 1;
            }
            pi[i] = j;
        }

        // 利用前缀数组进行匹配
        j = 0;
        for i in 0..n {
            while j > 0 && word_bytes[i] != pattern_bytes[j] {
                j = pi[j - 1];
            }
            if word_bytes[i] == pattern_bytes[j] {
                j += 1;
            }
            if j == m {
                return true;
            }
        }
        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nk+\sum_i m_i)$，其中 $n$ 为字符串 $word$ 的长度，$k$ 为数组 $patterns$ 中的元素数目，$m_i$ 为字符串 $patterns[i]$ 的长度。
  对于 $patterns$ 中的每个字符串 $patterns[i]$，利用 $KMP$ 算法判断是否为 $word$ 子串的时间复杂度为 $O(n+m_i)$。
- 空间复杂度：$O(maxi(m_i))$，其中 $m_i$ 为字符串 $patterns[i]$ 的长度。即为所有 $patterns[i]$ 的前缀数组的空间开销。
