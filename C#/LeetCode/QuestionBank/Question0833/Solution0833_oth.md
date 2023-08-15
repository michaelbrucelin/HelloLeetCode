### [线性做法（Python/Java/C++/Go/JS）](https://leetcode.cn/problems/find-and-replace-in-string/solutions/2388853/xian-xing-zuo-fa-pythonjavacgojs-by-endl-uofo/)

1.  设 $s$ 长度为 $n$，创建一个长为 $n$ 的 $replace$ 列表。
2.  遍历每个替换操作。对于第 $i$ 个替换操作，如果从 $indices[i]$ 开始的字符串有前缀 $sources[i]$，则可以替换成 $target[i]$。例如 `s="abcd"`，`s[1:]="bcd"` 有前缀 `"bc"`。此时记录 $replace[indices[i]] = (target[i], len(sources[i]))$，表示替换后的字符串，以及被替换的长度。
3.  初始化 $i=0$，如果 $replace[i]$ 是空的，那么无需替换，把 $s[i]$ 加入答案，然后 $i$ 加一；如果 $replace[i]$ 不为空，那么把 $replace[i][0]$ 加入答案，然后 $i$ 增加 $replace[i][1]$。循环直到 $i=n$ 为止。

```python
class Solution:
    def findReplaceString(self, s: str, indices: List[int], sources: List[str], targets: List[str]) -> str:
        replace = [(c, 1) for c in s]
        for i, src, tar in zip(indices, sources, targets):
            if s.startswith(src, i):  # 判断 s[i:] 的前缀是否为 src，这样写无需切片
                replace[i] = (tar, len(src))  # (替换后的字符串，被替换的长度)

        ans = []
        i = 0
        while i < len(s):
            ans.append(replace[i][0])  # 替换后的字符串（默认为 s[i]）
            i += replace[i][1]  # 被替换的长度（默认为 1）
        return ''.join(ans)
```

```java
class Solution {
    public String findReplaceString(String s, int[] indices, String[] sources, String[] targets) {
        int n = s.length();
        var replaceStr = new String[n]; // 替换后的字符串
        var replaceLen = new int[n];    // 被替换的长度
        Arrays.fill(replaceLen, 1);     // 无需替换时 i+=1
        for (int i = 0; i < indices.length; i++) {
            int idx = indices[i];
            if (s.startsWith(sources[i], idx)) {
                replaceStr[idx] = targets[i];
                replaceLen[idx] = sources[i].length();
            }
        }

        var ans = new StringBuilder();
        for (int i = 0; i < n; i += replaceLen[i]) { // 无需替换时 i+=1
            if (replaceStr[i] == null) {
                ans.append(s.charAt(i));
            } else {
                ans.append(replaceStr[i]);
            }
        }
        return ans.toString();
    }
}
```

```cpp
class Solution {
public:
    string findReplaceString(string s, vector<int> &indices, vector<string> &sources, vector<string> &targets) {
        int n = s.length();
        vector<pair<string, int>> replace(n, {"", 1}); // 无需替换时 i+=1
        for (int i = 0; i < indices.size(); i++)
            if (s.compare(indices[i], sources[i].length(), sources[i]) == 0)
                replace[indices[i]] = {targets[i], sources[i].length()}; // {替换后的字符串，被替换的长度}

        string ans;
        for (int i = 0; i < n; i += replace[i].second) { // 无需替换时 i+=1
            if (replace[i].first.empty()) {
                ans += s[i];
            } else {
                ans += replace[i].first;
            }
        }
        return ans;
    }
};
```

```go
func findReplaceString(s string, indices []int, sources, targets []string) string {
    n := len(s)
    replaceStr := make([]string, n)
    replaceLen := make([]int, n)
    for i, idx := range indices {
        if strings.HasPrefix(s[idx:], sources[i]) {
            replaceStr[idx] = targets[i] // 替换后的字符串
            replaceLen[idx] = len(sources[i]) // 被替换的长度
        }
    }

    ans := &strings.Builder{}
    for i := 0; i < n; {
        if replaceStr[i] == "" {
            ans.WriteByte(s[i])
            i++
        } else {
            ans.WriteString(replaceStr[i])
            i += replaceLen[i]
        }
    }
    return ans.String()
}
```

```javascript
var findReplaceString = function(s, indices, sources, targets) {
    const n = s.length;
    let replaceStr = Array(n);
    let replaceLen = Array(n).fill(1); // 无需替换时 i+=1
    for (let i = 0; i < indices.length; i++) {
        const idx = indices[i];
        if (s.startsWith(sources[i], idx)) { // 这样写不需要 s.slice
            replaceStr[idx] = targets[i]; // 替换后的字符串
            replaceLen[idx] = sources[i].length; // 被替换的长度
        }
    }

    let ans = [];
    for (let i = 0; i < n; i += replaceLen[i]) // 无需替换时 i+=1
        ans.push(replaceStr[i] ? replaceStr[i] : s.charAt(i));
    return ans.join("");
};
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(L)$，其中 $L$ 为所有字符串的长度之和。注意题目保证 $sources$ 中没有重叠元素，也就是说 $sources$ 中的所有字符串长度加起来不会超过 $s$ 的长度。
-   空间复杂度：$\mathcal{O}(L)$。
