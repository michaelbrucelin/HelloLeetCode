### [跟着我过一遍示例 2，你就明白怎么做了（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/remove-duplicate-letters/solutions/2381483/gen-zhao-wo-guo-yi-bian-shi-li-2ni-jiu-m-zd6u/?envType=problem-list-v2&envId=ySsxoJfz)

对于 $s=cbacdcbc$，从左到右遍历其中的字母。

1. $s[0]=c$。由于只遍历了一个字母，目前已知字典序最小的字符串是 $c$。
2. $s[1]=b$。如果右边没有字母 $c$，那么 $s[0]=c$ 必须保留；实际上右边还有字母 $c$，由于 $b<c$，我们可以去掉 $c$，改用 $b$ 当作目前字典序最小的字符串。
3. $s[2]=a$。同样的，由于 $a<b$ 且比右边还有字母 $b$，我们可以去掉 $b$，改用 $a$ 当作目前字典序最小的字符串（下面记作 $ans$）。
4. $s[3]=c$。由于 $c$ 比 $a$ 大，只能添加到 $a$ 后面，现在 $ans=ac$。
5. $s[4]=d$。由于 $d$ 比 $c$ 大，只能添加到 $c$ 后面，现在 $ans=acd$。
6. $s[5]=c$。由于 $acd$ 里面已经有 $c$ 了，直接跳过。现在 $ans=acd$。
7. $s[6]=b$。我们发现 $b$ 比 $d$ 小，能不能像上面 $s[1]$ 和 $s[2]$ 那样，去掉 $d$，添加 $b$ 呢？这是不行的，因为后面没有 $d$ 了，我们只能老老实实地添加到 $d$ 后面，现在 $ans=acdb$。
8. $s[7]=c$。由于 $acdb$ 里面已经有 $c$ 了，直接跳过。

遍历完毕，我们得到了答案 $ans=acdb$。

你可能会问，怎么知道右边是否还有某个字母 x？我们可以在遍历 $s$ 之前，先统计出每个字母的出现次数，记到一个哈希表或者数组 $left$ 中。在遍历 $s$ 时，减少 $s[i]$ 的出现次数，也就是把 $left[s[i]]$ 减一。如果发现 $left[x]=0$ 就说明右边没有 $x$ 了。

具体算法如下：

1. 统计每个字母的出现次数，记到一个哈希表或者数组 $left$ 中。
2. 遍历 $s$，先把 $left[s[i]]$ 减一。
3. 如果 $s[i]$ 在 $ans$ 中，直接 $continue$。为了快速判断 $s[i]$ 是否在 $ans$ 中，可以用一个哈希表或者布尔数组 $inAns$ 辅助判断。
4. 如果 $s[i]$ 不在 $ans$ 中，那么判断 $s[i]$ 是否小于 $ans$ 的最后一个字母（记作 $x$），如果 $s[i]<x$ 且 $left[x]>0$，那么可以把 $x$ 从 $ans$ 中去掉，同时标记 $inAns[x]=false$。
5. 反复执行第 $4$ 步，直到 $ans$ 为空，或者 $s[i]>x$，或者 $left[x]=0$。
6. 把 $s[i]$ 添加到 $ans$ 末尾，同时标记 $inAns[s[i]]=true$。然后继续遍历 $s$ 的下一个字母。
7. 遍历完 $s$ 后，返回 $ans$。

```Python
class Solution:
    def removeDuplicateLetters(self, s: str) -> str:
        left = Counter(s)  # 统计每个字母的出现次数
        ans = []  # 当作栈
        in_ans = set()
        for c in s:
            left[c] -= 1
            if c in in_ans:  # ans 中不能有重复字母
                continue
            # (设 x=ans[-1]) 如果 c < x，且右边还有 x，那么可以把 x 去掉，
            # 因为后面可以重新把 x 加到 ans 中
            while ans and c < ans[-1] and left[ans[-1]]:
                in_ans.remove(ans.pop())  # 标记栈顶不在 ans 中
            ans.append(c)  # 把 c 加到 ans 的末尾
            in_ans.add(c)  # 标记 c 在 ans 中
        return ''.join(ans)
```

```Java
class Solution {
    public String removeDuplicateLetters(String S) {
        char[] s = S.toCharArray();
        int[] left = new int[26];
        for (char c : s) {
            left[c - 'a']++; // 统计每个字母的出现次数
        }

        StringBuilder ans = new StringBuilder(26); // 当作栈
        boolean[] inAns = new boolean[26];
        for (char c : s) {
            left[c - 'a']--;
            if (inAns[c - 'a']) { // ans 中不能有重复字母
                continue;
            }
            // 设 x = ans.charAt(ans.length() - 1)，
            // 如果 c < x，且右边还有 x，那么可以把 x 去掉，因为后面可以重新把 x 加到 ans 中
            while (!ans.isEmpty() && c < ans.charAt(ans.length() - 1) && left[ans.charAt(ans.length() - 1) - 'a'] > 0) {
                inAns[ans.charAt(ans.length() - 1) - 'a'] = false; // 标记栈顶不在 ans 中
                ans.deleteCharAt(ans.length() - 1);
            }
            ans.append(c); // 把 c 加到 ans 的末尾
            inAns[c - 'a'] = true; // 标记 c 在 ans 中
        }
        return ans.toString();
    }
}
```

```C++
class Solution {
public:
    string removeDuplicateLetters(string s) {
        int left[26]{};
        for (char c : s) {
            left[c - 'a']++; // 统计每个字母的出现次数
        }

        string ans; // 当作栈
        bool in_ans[26]{};
        for (char c : s) {
            left[c - 'a']--;
            if (in_ans[c - 'a']) { // ans 中不能有重复字母
                continue;
            }
            while (!ans.empty() && c < ans.back() && left[ans.back() - 'a']) {
                // (设 x=ans.back()) 如果 c < x，且右边还有 x，那么可以把 x 去掉，
                // 因为后面可以重新把 x 加到 ans 中
                in_ans[ans.back() - 'a'] = false; // 标记栈顶不在 ans 中
                ans.pop_back();
            }
            ans += c; // 把 c 加到 ans 的末尾
            in_ans[c - 'a'] = true; // 标记 c 在 ans 中
        }
        return ans;
    }
};
```

```C
char* removeDuplicateLetters(char* s) {
    int left[26] = {};
    for (int i = 0; s[i]; i++) {
        left[s[i] - 'a']++; // 统计每个字母的出现次数
    }

    bool in_ans[26] = {};
    int top = -1; // 直接用 s 作为栈，top 为栈顶下标
    for (int i = 0; s[i]; i++) {
        char c = s[i];
        left[c - 'a']--;
        if (in_ans[c - 'a']) { // ans 中不能有重复字母
            continue;
        }
        while (top >= 0 && c < s[top] && left[s[top] - 'a'] > 0) {
            // (设 x=s[top]) 如果 c < x，且右边还有 x，那么可以把 x 去掉，
            // 因为后面可以重新把 x 加到 ans 中
            in_ans[s[top] - 'a'] = false; // 标记栈顶不在 ans 中
            top--;
        }
        s[++top] = c; // 把 c 加到 ans 的末尾
        in_ans[c - 'a'] = true; // 标记 c 在 ans 中
    }

    s[top + 1] = '\0';
    return s;
}
```

```Go
func removeDuplicateLetters(s string) string {
    left := ['z' + 1]int{} // 相比创建一个长为 26 的数组，多开一点空间更方便
    for _, c := range s {
        left[c]++ // 统计每个字母的出现次数
    }

    ans := []rune{} // 当作栈
    inAns := ['z' + 1]bool{}
    for _, c := range s {
        left[c]--
        if inAns[c] { // ans 中不能有重复字母
            continue
        }
        for len(ans) > 0 && c < ans[len(ans)-1] && left[ans[len(ans)-1]] > 0 {
            // 如果 c < x，且右边还有 x，那么可以把 x 去掉，因为后面可以重新把 x 加到 ans 中
            x := ans[len(ans)-1]
            ans = ans[:len(ans)-1]
            inAns[x] = false // 标记栈顶不在 ans 中
        }
        ans = append(ans, c) // 把 c 加到 ans 的末尾
        inAns[c] = true // 标记 c 在 ans 中
    }
    return string(ans)
}
```

```JavaScript
var removeDuplicateLetters = function(s) {
    const left = _.countBy(s); // 统计每个字母的出现次数
    const ans = [] // 当作栈
    const ansSet = new Set();
    for (const c of s) {
        left[c]--;
        if (ansSet.has(c)) { // ans 中不能有重复字母
            continue;
        }
        // 设 x = ans[ans.length-1]，
        // 如果 c < x，且右边还有 x，那么可以把 x 去掉，因为后面可以重新把 x 加到 ans 中
        while (ans && c < ans[ans.length - 1] && left[ans[ans.length - 1]]) {
            ansSet.delete(ans.pop()); // 标记栈顶不在 ans 中
        }
        ans.push(c); // 把 c 加到 ans 的末尾
        ansSet.add(c); // 标记 c 在 ans 中
    }
    return ans.join("");
};
```

```Rust
impl Solution {
    pub fn remove_duplicate_letters(s: String) -> String {
        let mut left = [0; 26];
        for c in s.bytes() {
            left[(c - b'a') as usize] += 1; // 统计每个字母的出现次数
        }

        let mut ans = vec![]; // 当作栈
        let mut in_ans = [false; 26];
        for c in s.bytes() {
            left[(c - b'a') as usize] -= 1;
            if in_ans[(c - b'a') as usize] { // ans 中不能有重复字母
                continue;
            }
            while let Some(&top) = ans.last() {
                if c > top || left[(top - b'a') as usize] == 0 {
                    break;
                }
                // (设 x=ans.last()) 如果 c < x，且右边还有 x，那么可以把 x 去掉，
                // 因为后面可以重新把 x 加到 ans 中
                in_ans[(top - b'a') as usize] = false; // 标记栈顶不在 ans 中
                ans.pop();
            }
            ans.push(c); // 把 c 加到 ans 的末尾
            in_ans[(c - b'a') as usize] = true; // 标记 c 在 ans 中
        }

        unsafe { String::from_utf8_unchecked(ans) }
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为 $s$ 的长度。我们写了一个二重循环，看上去是 $O(n^2)$ 的，但是考虑到每个 $s[i]$ 加到 $ans$ 中至多一次，从 $ans$ 中去掉也至多一次。所以整体上看，算法的时间复杂度是 $O(n)$ 的。
- 空间复杂度：$O(\vert \sum \vert )$，其中 $\vert \sum \vert $ 为字符集的大小，本题中字符均为小写字母，所以 $\vert \sum \vert =26$。注意 $ans$ 的长度不会超过 $\vert \sum \vert $。

#### 思考题

把问题改成：去掉尽量少的字母，且剩余的每种字母至多出现 $limit$ 次。这里 $limit$ 是额外输入的一个正整数（本题相当于 $limit=1$）。

这题是力扣之前的比赛题 [天池-03. 整理书架](https://leetcode.cn/contest/tianchi2022/problems/ev2bru/)。

欢迎在评论区发表你的做法。

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
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
