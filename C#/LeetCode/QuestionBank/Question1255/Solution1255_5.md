﻿#### [回溯三问：思考回溯问题的通用方法（Python/Java/C++/Go）...](https://leetcode.cn/problems/maximum-score-words-formed-by-letters/solutions/2133515/hui-su-san-wen-si-kao-hui-su-wen-ti-de-t-kw3y/)

本题是标准的**子集型回溯**，我在 [回溯算法套路①子集型回溯](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1mG4y1A7Gu%2F) 中讲了如何思考这类问题。

对于本题，先在回溯之前统计 $letters$ 中每个字母的出现次数，记作 $left$。

然后用「回溯三问」来思考：

1.  当前操作是什么？枚举 $words[i]$ **选或不选**：如果不选，那么得分不变；如果选，那么统计 $words[i]$ 中的每个字母对应的分数之和，累加到得分 $total$ 中。
2.  子问题是什么？从上面的分析可以知道，我们可以用 $(i,total)$ 表示当前的状态：从前 $i$ 个单词中继续选择，当前得分为 $total$。
3.  完成操作后，下一个子问题是什么？如果不选，那么递归到 $dfs(i−1,total)$；如果选，且剩余字母足够，那么递归到 $dfs(i−1,total+s)$，这里 $s$ 表示 $words[i]$ 的得分。

#### 答疑

**问**：什么叫「恢复现场」？
**答**：选了 $words[i]$，递归返回时，$words[i]$ 应当从「已选单词集合」中移除，也就是把 $left[c]$「恢复」到选 $words[i]$ 之前的样子。如果不恢复的话，相当于没选这个单词，却把 $left$ 中的字母个数减少了，这可能会导致无法选上其它的单词，计算出错误的结果。

**问**：为什么没有恢复 $total$？
**答**：$total$ 是局部变量，不会影响搜索树上父节点的 $total$ 值。

```python
class Solution:
    def maxScoreWords(self, words: List[str], letters: List[str], score: List[int]) -> int:
        ans = 0
        left = Counter(letters)
        score = dict(zip(ascii_lowercase, score))  # 字母对应的分数

        def dfs(i: int, total: int) -> None:
            if i < 0:  # base case
                nonlocal ans
                ans = max(ans, total)
                return

            # 不选 words[i]
            dfs(i - 1, total)

            # 选 words[i]
            for j, c in enumerate(words[i]):
                if left[c] == 0:  # 剩余字母不足
                    for c in words[i][:j]:  # 撤销
                        left[c] += 1
                    return
                left[c] -= 1  # 减少剩余字母
                total += score[c]  # 累加得分

            dfs(i - 1, total)

            # 恢复现场
            for c in words[i]:
                left[c] += 1

        dfs(len(words) - 1, 0)
        return ans
```

```java
class Solution {
    private String[] words;
    private int[] score, left = new int[26];
    private int ans;

    public int maxScoreWords(String[] words, char[] letters, int[] score) {
        this.words = words;
        this.score = score;
        for (char c : letters) ++left[c - 'a'];
        dfs(words.length - 1, 0);
        return ans;
    }

    private void dfs(int i, int total) {
        if (i < 0) { // base case
            ans = Math.max(ans, total);
            return;
        }

        // 不选 words[i]
        dfs(i - 1, total);

        // 选 words[i]
        char[] s = words[i].toCharArray();
        boolean ok = true;
        for (char c : s) {
            if (left[c - 'a']-- == 0)
                ok = false; // 剩余字母不足
            total += score[c - 'a']; // 累加得分
        }

        if (ok)
            dfs(i - 1, total);

        // 恢复现场
        for (char c : s)
            ++left[c - 'a'];
    }
}
```

```cpp
class Solution {
public:
    int maxScoreWords(vector<string> &words, vector<char> &letters, vector<int> &score) {
        int ans = 0, left[26]{};
        for (char c : letters)
            ++left[c - 'a'];

        function<void(int, int)> dfs = [&](int i, int total) {
            if (i < 0) { // base case
                ans = max(ans, total);
                return;
            }

            // 不选 words[i]
            dfs(i - 1, total);

            // 选 words[i]
            bool ok = true;
            for (char c : words[i]) {
                if (left[c - 'a']-- == 0)
                    ok = false; // 剩余字母不足
                total += score[c - 'a']; // 累加得分
            }

            if (ok)
                dfs(i - 1, total);

            // 恢复现场
            for (char c : words[i])
                ++left[c - 'a'];
        };

        dfs(words.size() - 1, 0);
        return ans;
    }
};
```

```go
func maxScoreWords(words []string, letters []byte, score []int) (ans int) {
    left := [26]int{}
    for _, c := range letters {
        left[c-'a']++
    }

    var dfs func(int, int)
    dfs = func(i, total int) {
        if i < 0 { // base case
            ans = max(ans, total)
            return
        }

        // 不选 words[i]
        dfs(i-1, total)

        // 选 words[i]
        for j, c := range words[i] {
            c -= 'a'
            if left[c] == 0 { // 剩余字母不足
                for _, c := range words[i][:j] { // 撤销
                    left[c-'a']++
                }
                return
            }
            left[c]-- // 减少剩余字母
            total += score[c] // 累加得分
        }

        dfs(i-1, total)

        // 恢复现场
        for _, c := range words[i] {
            left[c-'a']++
        }
    }
    dfs(len(words)-1, 0)
    return
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$O(m+L2^n)$，其中 $n$ 为 $words$ 的长度，$L$ 为 $words[i]$ 的长度，$m$ 为 $letters$ 的长度。搜索树是一棵满二叉树，有 $O(2^n)$ 个节点，每个节点的耗时为 $O(L)$，所以回溯的时间复杂度为 $O(L2^n)$，加上初始化 $left$ 的 $O(m)$ 时间，总的时间复杂度为 $O(m+L2^n)$。
-   空间复杂度：$O(|\Sigma|)$，其中 $|\Sigma|$ 为字符集合的大小，本题中字符均为小写字母，所以 $\Sigma|=26$。

___

如果你觉得恢复现场太麻烦，想写出更加简洁的代码，可以把 $left$ 作为参数传入，在选单词时复制一份。另外，把 $total$ 改为返回值。

```python
class Solution:
    def maxScoreWords(self, words: List[str], letters: List[str], score: List[int]) -> int:
        score = dict(zip(ascii_lowercase, score))  # 字母对应的分数

        def dfs(i: int, left: Counter) -> int:
            if i < 0:  # base case
                return 0

            # 不选 words[i]
            res = dfs(i - 1, left)

            # 选 words[i]
            cw = Counter(words[i])
            if all(v <= left.get(k, 0) for k, v in cw.items()):  # 可以选
                res = max(res, sum(score[c] for c in words[i]) + dfs(i - 1, left - cw))
            return res

        return dfs(len(words) - 1, Counter(letters))
```

```java
class Solution {
    private String[] words;
    private int[] score;

    public int maxScoreWords(String[] words, char[] letters, int[] score) {
        this.words = words;
        this.score = score;
        int[] left = new int[26];
        for (char c : letters) ++left[c - 'a'];
        return dfs(words.length - 1, left);
    }

    private int dfs(int i, int[] left) {
        if (i < 0) return 0; // base case

        // 不选 words[i]
        int res = dfs(i - 1, left);

        // 选 words[i]
        int[] tmp = left.clone();
        int s = 0;
        for (char c : words[i].toCharArray()) {
            if (tmp[c - 'a']-- == 0)
                return res; // 剩余字母不足
            s += score[c - 'a']; // 累加得分
        }
        return Math.max(res, s + dfs(i - 1, tmp));
    }
}
```

```cpp
class Solution {
public:
    int maxScoreWords(vector<string> &words, vector<char> &letters, vector<int> &score) {
        function<int(int, array<int, 26>)> dfs = [&](int i, array<int, 26> left) -> int {
            if (i < 0) return 0; // base case

            // 不选 words[i]
            int res = dfs(i - 1, left);

            // 选 words[i]
            int s = 0;
            for (char c : words[i]) {
                if (left[c - 'a']-- == 0)
                    return res; // 剩余字母不足
                s += score[c - 'a']; // 累加得分
            }
            return max(res, s + dfs(i - 1, left));
        };

        array<int, 26> left{};
        for (char c : letters) ++left[c - 'a'];
        return dfs(words.size() - 1, left);
    }
};
```

```go
func maxScoreWords(words []string, letters []byte, score []int) (ans int) {
    var dfs func(int, [26]int) int
    dfs = func(i int, left [26]int) int {
        if i < 0 { // base case
            return 0
        }

        // 不选 words[i]
        res := dfs(i-1, left)

        // 选 words[i]
        s := 0
        for _, c := range words[i] {
            c -= 'a'
            if left[c] == 0 { // 剩余字母不足
                return res
            }
            left[c]-- // 减少剩余字母
            s += score[c] // 累加得分
        }
        return max(res, s+dfs(i-1, left))
    }
    left := [26]int{}
    for _, c := range letters {
        left[c-'a']++
    }
    return dfs(len(words)-1, left)
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 强化训练：子集型回溯

-   [1601\. 最多可达成的换楼请求数目](https://leetcode.cn/problems/maximum-number-of-achievable-transfer-requests/)
-   [2044\. 统计按位或能得到最大值的子集数目](https://leetcode.cn/problems/count-number-of-maximum-bitwise-or-subsets/)
-   [2397\. 被列覆盖的最多行数](https://leetcode.cn/problems/maximum-rows-covered-by-columns/)
