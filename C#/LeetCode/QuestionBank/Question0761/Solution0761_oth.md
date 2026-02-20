### [本质是合法括号字符串，递归排序（$Python/Java/C++/Go$）](https://leetcode.cn/problems/special-binary-string/solutions/3905099/ben-zhi-shi-he-fa-gua-hao-zi-fu-chuan-di-x6ci/)

示例 $1$ 的 $s=11011000$，如果把 $1$ 看成左括号，$0$ 看成右括号，那么 $s=(()(()))$。

看上去，这是一个合法括号字符串？为什么？

对于合法括号字符串：

- 左右括号的个数相等。
- 每个右括号，都在左边有与之匹配的左括号。这意味着，对于括号字符串的每个前缀，左括号的个数不能低于右括号的个数（否则右括号无法找到配对的左括号）。

这两个性质和特殊字符串的两个性质是完全一样的。

用合法括号字符串思考更方便。移动操作相当于：

- 选择 $s$ 中的一对相邻的合法括号子串，交换。

示例 $1$ 的 $s=(()(()))$，交换内部的 $()$ 和 $(())$，得到 $((())())$。

如何交换，可以让合法括号字符串的字典序最大？

合法括号字符串有两种组合方式：

1. **拼接**。例如 $()+(())=()(())$。多个合法括号字符串拼接在一起，可以得到一个更长的合法括号字符串。
2. **嵌套**。例如 $(+()()+)=(()())$。在合法括号字符串的外层套一对括号，可以得到一个更长的合法括号字符串。

对于拼接，把 $s$ 拆分成若干个更短的合法括号子串，这些子串都可以做相邻交换。根据冒泡排序的想法，我们可以把这些子串从大到小排序。

对于嵌套，去掉外层的一对括号，问题变成操作子串 $[1,n-2]$ 能得到的最大字典序。这是一个规模更小（长为 $n-2$）的子问题，可以**递归**解决。

注意题目保证输入的 $s$ 是个特殊字符串（合法括号字符串）。

```Python
class Solution:
    def makeLargestSpecial(self, s: str) -> str:
        if len(s) <= 2:
            return s

        # 把 s 划分成若干段合法括号字符串，记录在 substrings 中
        substrings = []
        diff = 0  # 左括号个数 - 右括号个数
        start = 0  # 子串开始下标
        for i, ch in enumerate(s):
            if ch == '1':  # 左括号
                diff += 1
            else:  # 右括号
                diff -= 1
                if diff == 0:
                    # 子串 [start, i] 是合法括号字符串，且无法继续划分
                    # 这意味着子串 [start, i] 只能是嵌套的括号，那么去掉外层的括号，递归解决 [start+1, i-1]
                    substrings.append("1" + self.makeLargestSpecial(s[start + 1: i]) + "0")
                    start = i + 1  # 下一个子串从 i+1 开始

        substrings.sort(reverse=True)
        return ''.join(substrings)
```

```Java
class Solution {
    public String makeLargestSpecial(String s) {
        if (s.length() <= 2) {
            return s;
        }

        // 把 s 划分成若干段合法括号字符串，记录在 substrings 中
        List<String> substrings = new ArrayList<>();
        int diff = 0; // 左括号个数 - 右括号个数
        int start = 0; // 子串开始下标
        for (int i = 0; i < s.length(); i++) {
            char ch = s.charAt(i);
            if (ch == '1') { // 左括号
                diff++;
            } else if (--diff == 0) { // 右括号
                // 子串 [start, i] 是合法括号字符串，且无法继续划分
                // 这意味着子串 [start, i] 只能是嵌套的括号，那么去掉外层的括号，递归解决 [start+1, i-1]
                substrings.add("1" + makeLargestSpecial(s.substring(start + 1, i)) + "0");
                start = i + 1; // 下一个子串从 i+1 开始
            }
        }

        substrings.sort((a, b) -> b.compareTo(a));
        return String.join("", substrings);
    }
}
```

```C++
class Solution {
public:
    string makeLargestSpecial(string s) {
        if (s.size() <= 2) {
            return s;
        }

        // 把 s 划分成若干段合法括号字符串，记录在 substrings 中
        vector<string> substrings;
        int diff = 0; // 左括号个数 - 右括号个数
        int start = 0; // 子串开始下标
        for (int i = 0; i < s.size(); i++) {
            if (s[i] == '1') { // 左括号
                diff++;
            } else if (--diff == 0) { // 右括号
                // 子串 [start, i] 是合法括号字符串，且无法继续划分
                // 这意味着子串 [start, i] 只能是嵌套的括号，那么去掉外层的括号，递归解决 [start+1, i-1]
                substrings.push_back("1" + makeLargestSpecial(s.substr(start + 1, i - start - 1)) + "0");
                start = i + 1; // 下一个子串从 i+1 开始
            }
        }

        ranges::sort(substrings, greater());
        auto joined = substrings | views::join;
        return string(joined.begin(), joined.end());
    }
};
```

```Go
func makeLargestSpecial(s string) string {
    if len(s) <= 2 {
        return s
    }

    // 把 s 划分成若干段合法括号字符串，记录在 substrings 中
    substrings := []string{}
    diff := 0 // 左括号个数 - 右括号个数
    start := 0 // 子串开始下标
    for i, ch := range s {
        if ch == '1' { // 左括号
            diff++
        } else if diff--; diff == 0 { // 右括号
            // 子串 [start, i] 是合法括号字符串，且无法继续划分
            // 这意味着子串 [start, i] 只能是嵌套的括号，那么去掉外层的括号，递归解决 [start+1, i-1]
            substrings = append(substrings, "1"+makeLargestSpecial(s[start+1:i])+"0")
            start = i + 1 // 下一个子串从 i+1 开始
        }
    }

    slices.SortFunc(substrings, func(a, b string) int { return cmp.Compare(b, a) })
    return strings.Join(substrings, "")
}
```

#### 复杂度分析

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $s$ 的长度。瓶颈在拼接字符串上。最坏情况下，对于 $\frac{n}{2}$ 个 $1$ 和 $\frac{n}{2}$ 个 $0$ 的 $s$，递归 $O(n)$ 次，每次拼接字符串需要 $O(n)$ 时间。
- 空间复杂度：$O(n)$。

#### 专题训练

见下面数据结构题单的「**§3.4 合法括号字符串**」。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/基环树/最短路/最小生成树/网络流）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/划分/状态机/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
