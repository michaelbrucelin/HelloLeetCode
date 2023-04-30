﻿#### [教你一步步思考动态规划！（Python/Java/C++/Go）](https://leetcode.cn/problems/longest-string-chain/solutions/2247269/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-wdkm/)

#### 前置知识：动态规划入门

详见 [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)。

> APP 用户如果无法打开，可以分享到微信。

#### 方法一：记忆化搜索

对于字符串 $s$ 来说，假设它是词链的最后一个单词，那么去掉 $s$ 中的一个字母，设新字符串为 $t$，问题就变成计算以 $t$ 结尾的词链的最长长度。由于这是一个和原问题相似的子问题，因此可以用递归解决。

直接把字符串作为递归的参数，定义 $dfs(s)$ 表示以 $s$ 结尾的词链的最长长度。由于字符串的长度不超过 $16$，暴力枚举去掉的字符，设新字符串为 $t$ 且在 $words$ 中，则有

$$dfs(s) = \max\{dfs(t)\} + 1$$

为了快速判断字符串是否在 $words$ 中，需要将所有 $words[i]$ 存入哈希表 $ws$ 中。

由于 $"aba"$ 和 $"aca"$ 去掉中间字母都会变成 $"aa"$，为避免重复计算，代码实现时可以用记忆化搜索。进一步地，可以直接把计算结果存到 $ws$ 中。（Python 还是用 `@cache`）

```python
class Solution:
    def longestStrChain(self, words: List[str]) -> int:
        ws = set(words)
        @cache  # 缓存装饰器，避免重复计算 dfs 的结果
        def dfs(s: str) -> int:
            res = 0
            for i in range(len(s)):  # 枚举去掉 s[i]
                t = s[:i] + s[i + 1:]
                if t in ws:  # t 在 words 中
                    res = max(res, dfs(t))
            return res + 1
        return max(dfs(s) for s in ws)
```

```java
class Solution {
    private Map<String, Integer> ws = new HashMap<>();

    public int longestStrChain(String[] words) {
        for (var s : words)
            ws.put(s, 0); // 0 表示未被计算
        int ans = 0;
        for (var s : ws.keySet())
            ans = Math.max(ans, dfs(s));
        return ans;
    }

    private int dfs(String s) {
        int res = ws.get(s);
        if (res > 0) return res; // 之前计算过
        for (int i = 0; i < s.length(); i++) { // 枚举去掉 s[i]
            var t = s.substring(0, i) + s.substring(i + 1);
            if (ws.containsKey(t)) // t 在 words 中
                res = Math.max(res, dfs(t));
        }
        ws.put(s, res + 1); // 记忆化
        return res + 1;
    }
}
```

```cpp
class Solution {
public:
    int longestStrChain(vector<string> &words) {
        unordered_map<string, int> ws;
        for (auto &s: words) ws[s] = 0; // 0 表示未被计算
        function<int(string)> dfs = [&](string s) -> int {
            int res = ws[s];
            if (res) return res; // 之前计算过
            for (int i = 0; i < s.length(); ++i) { // 枚举去掉 s[i]
                auto t = s.substr(0, i) + s.substr(i + 1);
                if (ws.count(t)) // t 在 words 中
                    res = max(res, dfs(t));
            }
            return ws[s] = res + 1; // 记忆化
        };
        int ans = 0;
        for (auto &[s, _]: ws)
            ans = max(ans, dfs(s));
        return ans;
    }
};
```

```go
func longestStrChain(words []string) (ans int) {
    ws := map[string]int{}
    for _, s := range words {
        ws[s] = 0 // 0 表示未被计算
    }
    var dfs func(string) int
    dfs = func(s string) int {
        res := ws[s]
        if res > 0 { // 之前计算过
            return res
        }
        for i := range s { // 枚举去掉 s[i]
            t := s[:i] + s[i+1:]
            if _, ok := ws[t]; ok {
                res = max(res, dfs(t))
            }
        }
        ws[s] = res + 1 // 记忆化
        return res + 1
    }
    for s := range ws {
        ans = max(ans, dfs(s))
    }
    return
}

func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(nL^2)$，其中 $n$ 为 $words$ 的长度，$L$ 为字符串的最大长度，本题不超过 $16$。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。这里状态个数为 $\mathcal{O}(n)$，单个状态的计算时间为 $\mathcal{O}(L^2)$，因此时间复杂度为 $\mathcal{O}(nL^2)$。
-   空间复杂度：$\mathcal{O}(nL)$。每个状态都需要 $\mathcal{O}(L)$ 的空间。

#### 方法二：1:1 翻译成递推

我们可以去掉递归中的「递」，只保留「归」的部分，即自底向上计算。

对于本题，只需要把递归改成循环。

由于我们总是从短的字符串转移到长的字符串，所以要先把字符串按长度从小到大排序，然后从短的开始递推。

```python
class Solution:
    def longestStrChain(self, words: List[str]) -> int:
        words.sort(key=len)
        f = {}
        for s in words:
            res = 0
            for i in range(len(s)):  # 枚举去掉 s[i]
                res = max(res, f.get(s[:i] + s[i + 1:], 0))
            f[s] = res + 1
        return max(f.values())
```

```java
class Solution {
    public int longestStrChain(String[] words) {
        Arrays.sort(words, (a, b) -> a.length() - b.length());
        int ans = 0;
        var f = new HashMap<String, Integer>();
        for (var s : words) {
            int res = 0;
            for (int i = 0; i < s.length(); i++) { // 枚举去掉 s[i]
                var t = s.substring(0, i) + s.substring(i + 1);
                res = Math.max(res, f.getOrDefault(t, 0));
            }
            f.put(s, res + 1);
            ans = Math.max(ans, res + 1);
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int longestStrChain(vector<string> &words) {
        sort(words.begin(), words.end(), [](const auto &a, const auto &b) {
            return a.length() < b.length();
        });
        int ans = 0;
        unordered_map<string, int> f;
        for (auto &s: words) {
            int res = 0;
            for (int i = 0; i < s.length(); ++i) { // 枚举去掉 s[i]
                auto it = f.find(s.substr(0, i) + s.substr(i + 1));
                if (it != f.end())
                    res = max(res, it->second);
            }
            ans = max(ans, f[s] = res + 1);
        }
        return ans;
    }
};
```

```go
func longestStrChain(words []string) (ans int) {
    sort.Slice(words, func(i, j int) bool { return len(words[i]) < len(words[j]) })
    f := map[string]int{}
    for _, s := range words {
        res := 0
        for i := range s { // 枚举去掉 s[i]
            res = max(res, f[s[:i]+s[i+1:]])
        }
        f[s] = res + 1
        ans = max(ans, res+1)
    }
    return
}

func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n\log n + nL^2)$，其中 $n$ 为 $words$ 的长度，$L$ 为字符串的最大长度，本题不超过 $16$。排序的时间复杂度为 $\mathcal{O}(n\log n)$（注意只比较长度）。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。这里状态个数为 $\mathcal{O}(n)$，单个状态的计算时间为 $\mathcal{O}(L^2)$，因此时间复杂度为 $\mathcal{O}(nL^2)$。总的时间复杂度为 $\mathcal{O}(n\\log n + nL^2)$。
-   空间复杂度：$\mathcal{O}(nL)$。每个状态都需要 $\mathcal{O}(L)$ 的空间。
