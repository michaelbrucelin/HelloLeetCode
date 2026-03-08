### [两种方法：暴力枚举 / 康托对角线（Python/Java/C++/Go）](https://leetcode.cn/problems/find-unique-binary-string/solutions/951165/go-jian-ji-xie-fa-by-endlesscheng-mcwc/)

#### 方法一：暴力枚举

把 $nums$ 中的字符串转成二进制整数，保存到一个哈希集合中。

枚举 $ans=0,1,2,\dots $ 直到 $ans$ 不在哈希集合中，即为答案。

方法二告诉我们，满足要求的答案是一定存在的。

```Python
class Solution:
    def findDifferentBinaryString(self, nums: List[str]) -> str:
        st = {int(s, 2) for s in nums}

        ans = 0
        while ans in st:
            ans += 1

        n = len(nums)
        return f"{ans:0{n}b}"
```

```Java
class Solution {
    public String findDifferentBinaryString(String[] nums) {
        Set<Integer> set = new HashSet<>();
        for (String s : nums) {
            set.add(Integer.parseInt(s, 2));
        }

        int ans = 0;
        while (set.contains(ans)) {
            ans++;
        }

        String bin = Integer.toBinaryString(ans);
        return "0".repeat(nums.length - bin.length()) + bin;
    }
}
```

```C++
class Solution {
public:
    string findDifferentBinaryString(vector<string>& nums) {
        unordered_set<int> st;
        for (auto& s : nums) {
            st.insert(stoi(s, nullptr, 2));
        }

        int ans = 0;
        while (st.contains(ans)) {
            ans++;
        }

        int n = nums.size();
        return bitset<32>(ans).to_string().substr(32 - n);
    }
};
```

```Go
func findDifferentBinaryString(nums []string) string {
    n := len(nums)
    has := make(map[int]bool, n)
    for _, s := range nums {
        x, _ := strconv.ParseInt(s, 2, 64)
        has[int(x)] = true
    }

    ans := 0
    for has[ans] {
        ans++
    }

    return fmt.Sprintf("%0*b", n, ans)
}
```

#### 复杂度分析

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $nums$ 的长度。把长为 $n$ 的字符串转成整数需要 $O(n)$ 的时间。
- 空间复杂度：$O(n)$。

#### 方法二：康托对角线

这个方法灵感来自数学家康托关于「实数是不可数无限」的证明。

例如 $nums=[111,011,000]$。我们可以构造一个字符串 $ans$，满足：

- $ans[0]=0\ne nums[0][0]$。
- $ans[1]=0\ne nums[1][1]$。
- $ans[2]=1\ne nums[2][2]$。

ans=001 和每个 $nums[i]$ **都至少有一个字符不同**，满足题目要求。

一般地，令 $ans[i]=nums[i][i]\oplus 1$，即可满足要求。其中 $\oplus $ 是异或运算。

```Python
class Solution:
    def findDifferentBinaryString(self, nums: List[str]) -> str:
        ans = [''] * len(nums)
        for i, s in enumerate(nums):
            ans[i] = '1' if s[i] == '0' else '0'
        return ''.join(ans)
```

```Java
class Solution {
    public String findDifferentBinaryString(String[] nums) {
        int n = nums.length;
        char[] ans = new char[n];
        for (int i = 0; i < n; i++) {
            ans[i] = (char) (nums[i].charAt(i) ^ 1);
        }
        return new String(ans);
    }
}
```

```C++
class Solution {
public:
    string findDifferentBinaryString(vector<string>& nums) {
        int n = nums.size();
        string ans(n, 0);
        for (int i = 0; i < n; i++) {
            ans[i] = nums[i][i] ^ 1;
        }
        return ans;
    }
};
```

```Go
func findDifferentBinaryString(nums []string) string {
    ans := make([]byte, len(nums))
    for i, s := range nums {
        ans[i] = s[i] ^ 1
    }
    return string(ans)
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。注意这个方法没有遍历整个字符串，只访问了每个字符串的其中一个字符。
- 空间复杂度：$O(1)$，返回值不计入。

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
