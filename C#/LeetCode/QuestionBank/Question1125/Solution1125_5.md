﻿#### [状压 0-1 背包，查表法 vs 刷表法（Python/Java/C++/Go）](https://leetcode.cn/problems/smallest-sufficient-team/solutions/2214387/zhuang-ya-0-1-bei-bao-cha-biao-fa-vs-shu-qode/)

#### 前置知识：动态规划、记忆化搜索、0-1 背包

1.  [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)
2.  [0-1 背包与完全背包【基础算法精讲 18】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV16Y411v7Y6%2F)

> APP 用户需要分享到 wx 打开链接。

#### 前置知识：集合论与位运算

集合可以用二进制表示，二进制从低到高第 $i$ 位为 $1$ 表示 $i$ 在集合中，为 $0$ 表示 $i$ 不在集合中。例如集合 {0,2,3}\\{0,2,3\\}{0,2,3} 对应的二进制数为 1101(2)1101\_{(2)}1101(2)。

本题中用到的位运算技巧：

1.  将元素 xxx 变成集合 {x}\\{x\\}{x}，即 `1 << x`。
2.  判断元素 xxx 是否在集合 AAA 中，即 `((A >> x) & 1) == 1`。
3.  计算两个集合 A,BA,BA,B 的并集 A∪BA\\cup BA∪B，即 `A | B`。例如 `110 | 11 = $1$`。
4.  计算 A∖BA \\setminus BA∖B，表示从集合 AAA 中去掉在集合 BBB 中的元素，即 `A & ~B`。例如 `110 & ~11 = 100`。
5.  全集 U={0,1,⋯ ,n−1}U=\\{0,1,\\cdots,n-1\\}U\={0,1,⋯,n−1}，即 `(1 << n) - 1`。

> 注：位运算的技巧太多了，后面我会出期视频讲解。

#### 一、转换成 0-1 背包问题

重新描述一遍问题：从 $people$ 中选择一些元素（技能集合），这些技能集合的并集等于 $reqSkills$，要求选的元素个数尽量少。

把 $people[i]$ 看成物品（集合），$reqSkills$ 看成背包容量（目标集合），本题就是一个集合版本的 0-1 背包问题。

为方便计算，先把 $reqSkills$ 中的每个字符串映射到其下标上，记到一个哈希表 $sid$ 中。然后把每个 $people[i]$ 通过映射转换成数字集合，再压缩成一个二进制数。

例如示例 1，把 `"java","nodejs","reactjs"` 分别映射到 0,1,20,1,20,1,2 上，那么 people[0],people[1],people[2]people[0],people[1],people[2]people[0],people[1],people[2] 按照这种映射关系就转换成集合 {0},{1},{1,2}\\{0\\},\\{1\\},\\{1,2\\}{0},{1},{1,2}，对应的二进制数分别为 1(2),10(2),110(2)1\_{(2)}, 10\_{(2)}, 110\_{(2)}1(2),10(2),110(2)。那么选择集合 {0}\\{0\\}{0} 和 {1,2}\\{1,2\\}{1,2}，它俩的并集为 {0,1,2}\\{0,1,2\\}{0,1,2}，满足题目要求。这等价于选择二进制数 1(2)1\_{(2)}1(2) 和 110(2)110\_{(2)}110(2)，它俩的或运算的结果是 $1$(2)$1$\_{(2)}$1$(2)，就对应着集合 {0,1,2}\\{0,1,2\\}{0,1,2}。

类似 0-1 背包，定义 dfs(i,j)dfs(i, j)dfs(i,j) 表示从前 $i$ 个集合中选择一些集合，并集等于 $j$，至少需要选择的集合个数。

分类讨论：

-   不选第 $i$ 个集合：dfs(i,j)=dfs(i−1,j)dfs(i, j) = dfs(i-1, j)dfs(i,j)\=dfs(i−1,j)。
-   选第 $i$ 个集合：dfs(i,j)=dfs(i−1,j∖people[i])+1dfs(i, j) = dfs(i-1, j\\setminuspeople[i])+1dfs(i,j)\=dfs(i−1,j∖people[i])+1。
-   取最小值，即 dfs(i,j)=min⁡(dfs(i−1,j),dfs(i−1,j∖people[i])+1)dfs(i, j) = \\min(dfs(i-1, j),dfs(i-1, j\\setminuspeople[i])+1)dfs(i,j)\=min(dfs(i−1,j),dfs(i−1,j∖people[i])+1)。

由于本题还需要输出具体方案，为了方便存储，我们可以把人员编号集合也用二进制数表示。这是因为本题 $people$ 的长度不超过 606060，可以压缩到一个 646464 位整数中。如果长度大于 646464 呢？更加通用的做法我在 [1092\. 最短公共超序列（题解）](https://leetcode.cn/problems/shortest-common-supersequence/solution/cong-di-gui-dao-di-tui-jiao-ni-yi-bu-bu-auy8z/)中详细介绍了，留作练习，欢迎把代码贴在评论区。

修改后，dfs(i,j)dfs(i, j)dfs(i,j) 定义成从前 $i$ 个集合中选择一些集合，并集等于 $j$，所选择的最小下标集合：

-   不选第 $i$ 个集合：dfs(i,j)=dfs(i−1,j)dfs(i, j) = dfs(i-1, j)dfs(i,j)\=dfs(i−1,j)。
-   选第 $i$ 个集合：dfs(i,j)=dfs(i−1,j∖people[i])∪{i}dfs(i, j) = dfs(i-1, j\\setminuspeople[i])\\cup \\{i\\}dfs(i,j)\=dfs(i−1,j∖people[i])∪{i}。
-   取这两个集合中大小最小的。
-   递归边界：如果 j=∅j=\\varnothingj\=∅，返回 ∅\\varnothing∅。如果 i<0i<0i<0，返回全集 U={0,1,⋯ ,n−1}U=\\{0,1,\\cdots,n-1\\}U\={0,1,⋯,n−1}（也可以再多加一个 nnn，不过由于题目保证答案存在，这样就够了）。
-   上述是用集合的语言描述的，代码中用位运算实现。

```python
class Solution:
    def smallestSufficientTeam(self, req_skills: List[str], people: List[List[str]]) -> List[int]:
        sid = {s: i for i, s in enumerate(req_skills)}  # 字符串映射到下标
        n = len(people)
        mask = [0] * n
        for i, skills in enumerate(people):
            for s in skills:  # 把 skills 压缩成一个二进制数 mask[i]
                mask[i] |= 1 << sid[s]

        # dfs(i,j) 表示从前 i 个集合中选择一些集合，并集等于 j，需要选择的最小集合
        @cache
        def dfs(i: int, j: int) -> int:
            if j == 0: return 0  # 背包已装满
            if i < 0: return (1 << n) - 1  # 没法装满背包，返回全集，这样下面比较集合大小会取更小的
            res = dfs(i - 1, j)  # 不选 mask[i]
            res2 = dfs(i - 1, j & ~mask[i]) | (1 << i)  # 选 mask[i]
            return res if res.bit_count() < res2.bit_count() else res2

        res = dfs(n - 1, (1 << len(req_skills)) - 1)
        return [i for i in range(n) if (res >> i) & 1]  # 所有在 res 中的下标
```

```java
class Solution {
    private long all;
    private int[] mask;
    private long[][] memo;

    public int[] smallestSufficientTeam(String[] reqSkills, List<List<String>> people) {
        var sid = new HashMap<String, Integer>();
        int m = reqSkills.length;
        for (int i = 0; i < m; ++i)
            sid.put(reqSkills[i], i); // 字符串映射到下标

        int n = people.size();
        mask = new int[n];
        for (int i = 0; i < n; ++i)
            for (var s : people.get(i)) // 把 people[i] 压缩成一个二进制数 mask[i]
                mask[i] |= 1 << sid.get(s);

        int u = 1 << m;
        memo = new long[n][u];
        for (int i = 0; i < n; i++)
            Arrays.fill(memo[i], -1); // -1 表示还没有计算过
        all = (1L << n) - 1;
        long res = dfs(n - 1, u - 1);

        var ans = new int[Long.bitCount(res)];
        for (int i = 0, j = 0; i < n; ++i)
            if (((res >> i) & 1) > 0)
                ans[j++] = i; // 所有在 res 中的下标
        return ans;
    }

    private long dfs(int i, int j) {
        if (j == 0) return 0; // 背包已装满
        if (i < 0) return all; // 没法装满背包，返回全集，这样下面比较集合大小会取更小的
        if (memo[i][j] != -1) return memo[i][j];
        long res = dfs(i - 1, j); // 不选 mask[i]
        long res2 = dfs(i - 1, j & ~mask[i]) | (1L << i); // 选 mask[i]
        return memo[i][j] = Long.bitCount(res) < Long.bitCount(res2) ? res : res2;
    }
}
```

```cpp
class Solution {
public:
    vector<int> smallestSufficientTeam(vector<string> &req_skills, vector<vector<string>> &people) {
        unordered_map<string, int> sid;
        int m = req_skills.size();
        for (int i = 0; i < m; ++i)
            sid[req_skills[i]] = i; // 字符串映射到下标

        int n = people.size(), mask[n];
        memset(mask, 0, sizeof(mask));
        for (int i = 0; i < n; ++i)
            for (auto &s: people[i]) // 把 people[i] 压缩成一个二进制数 mask[i]
                mask[i] |= 1 << sid[s];

        int u = 1 << m;
        long long memo[n][u], all = (1LL << n) - 1;
        memset(memo, -1, sizeof(memo)); // -1 表示还没有计算过
        function<long long(int, int)> dfs = [&](int i, int j) -> long long {
            if (j == 0) return 0; // 背包已装满
            if (i < 0) return all; // 没法装满背包，返回全集，这样下面比较集合大小会取更小的
            auto &res = memo[i][j]; // 注意这里是引用，下面会直接修改 memo[i][j]
            if (res != -1) return res;
            auto r1 = dfs(i - 1, j); // 不选 mask[i]
            auto r2 = dfs(i - 1, j & ~mask[i]) | (1LL << i); // 选 mask[i]
            return res = __builtin_popcountll(r1) < __builtin_popcountll(r2) ? r1 : r2;
        };
        auto res = dfs(n - 1, u - 1);

        vector<int> ans;
        for (int i = 0; i < n; ++i)
            if ((res >> i) & 1)
                ans.push_back(i); // 所有在 res 中的下标
        return ans;
    }
};
```

```go
func smallestSufficientTeam(reqSkills []string, people [][]string) (ans []int) {
    m := len(reqSkills)
    sid := make(map[string]int, m)
    for i, s := range reqSkills {
        sid[s] = i // 字符串映射到下标
    }

    n := len(people)
    mask := make([]int, n)
    for i, skills := range people {
        for _, s := range skills { // 把 skills 压缩成一个二进制数 mask[i]
            mask[i] |= 1 << sid[s]
        }
    }

    u, all := 1<<m, 1<<n-1
    memo := make([][]int, n)
    for i := range memo {
        memo[i] = make([]int, u)
        for j := range memo[i] {
            memo[i][j] = -1 // -1 表示还没有计算过
        }
    }
    var dfs func(int, int) int
    dfs = func(i, j int) int {
        if j == 0 { // 背包已装满
            return 0
        }
        if i < 0 { // 没法装满背包，返回全集，这样下面比较集合大小会取更小的
            return all
        }
        p := &memo[i][j]
        if *p != -1 {
            return *p
        }
        r1 := dfs(i-1, j) // 不选 mask[i]
        r2 := dfs(i-1, j&^mask[i]) | 1<<i // 选 mask[i]
        if bits.OnesCount(uint(r1)) < bits.OnesCount(uint(r2)) {
            *p = r1
        } else {
            *p = r2
        }
        return *p
    }
    res := dfs(n-1, u-1)

    for i := 0; i < n; i++ {
        if res>>i&1 > 0 {
            ans = append(ans, i) // 所有在 res 中的下标
        }
    }
    return
}
```

#### 复杂度分析

-   时间复杂度：O(T+n2m)O(T+n2^m)O(T+n2m)，其中 TTT 为 $people$ 中的字符串的长度之和，nnn 为 $people$ 的长度，mmm 为 $reqSkills$ 的长度。忽略比较字符串的时间。初始化数组 mask\\textit{mask}mask 需要 O(T)O(T)O(T) 的时间。由于每个状态只会计算一次，记忆化搜索的时间复杂度 \==\= 状态个数 ×\\times× 单个状态的计算时间。本题状态个数为 O(n2m)O(n2^m)O(n2m)，单个状态的计算时间为 O(1)O(1)O(1)，因此记忆化搜索的时间复杂度为 O(n2m)O(n2^m)O(n2m)。
-   空间复杂度：O(S+n2m)O(S+n2^m)O(S+n2m)，其中 SSS 为 $reqSkills$ 中的字符串的长度之和。

> 注意 T≥ST\\ge ST≥S，所以时间复杂度中忽略了 SSS。

#### 二、1:1 翻译成递推

把 dfsdfsdfs 改成 fff 数组，把递归改成循环就好了。相当于原来是用递归计算每个状态 (i,j)(i,j)(i,j)，现在改用循环去计算每个状态 (i,j)(i,j)(i,j)。

由于需要处理 i<0i<0i<0，也就是需要 f[−1]f[-1]f[−1] 这个状态，那么在 fff 的前面插入一个状态，f[0]f[0]f[0] 就对应到 i<0i<0i<0 的情况了，原来的 f[i]f[i]f[i] 需要变成 f[i+1]f[i+1]f[i+1]。

#### 答疑

**问**：为什么变慢了？

**答**：因为有很多状态是不需要计算的。比如集合 {0}\\{0\\}{0} 和 {1,2}\\{1,2\\}{1,2}，在记忆化搜索中，是不会递归到 j={0,1}j=\\{0,1\\}j\={0,1} 这种集合的，而递推需要计算所有状态。

没关系，后面会优化。

```python
class Solution:
    def smallestSufficientTeam(self, req_skills: List[str], people: List[List[str]]) -> List[int]:
        sid = {s: i for i, s in enumerate(req_skills)}  # 字符串映射到下标
        n = len(people)
        u = 1 << len(req_skills)
        # f[i+1][j] 表示从前 i 个集合中选择一些集合，并集等于 j，需要选择的最小集合
        f = [[0] * u for _ in range(n + 1)]
        f[0] = [(1 << n) - 1] * u  # 对应记忆化搜索中的 if i < 0: return (1 << n) - 1
        f[0][0] = 0
        for i, skills in enumerate(people):
            mask = 0
            for s in skills:  # 把 skills 压缩成一个二进制数 mask
                mask |= 1 << sid[s]
            for j in range(1, u):
                res = f[i][j]  # 不选 mask
                res2 = f[i][j & ~mask] | (1 << i)  # 选 mask
                f[i + 1][j] = res if res.bit_count() < res2.bit_count() else res2
        res = f[-1][-1]
        return [i for i in range(n) if (res >> i) & 1]  # 所有在 res 中的下标
```

```java
class Solution {
    public int[] smallestSufficientTeam(String[] reqSkills, List<List<String>> people) {
        var sid = new HashMap<String, Integer>();
        int m = reqSkills.length;
        for (int i = 0; i < m; ++i)
            sid.put(reqSkills[i], i); // 字符串映射到下标

        int n = people.size(), u = 1 << m;
        // f[i+1][j] 表示从前 i 个集合中选择一些集合，并集等于 j，需要选择的最小集合
        var f = new long[n + 1][u];
        Arrays.fill(f[0], (1L << n) - 1); // 对应记忆化搜索中的 if (i < 0) return all;
        f[0][0] = 0;
        for (int i = 0; i < n; ++i) {
            int mask = 0;
            for (var s : people.get(i)) // 把 people[i] 压缩成一个二进制数 mask
                mask |= 1 << sid.get(s);
            for (int j = 1; j < u; ++j) {
                long res = f[i][j]; // 不选 mask
                long res2 = f[i][j & ~mask] | (1L << i); // 选 mask
                f[i + 1][j] = Long.bitCount(res) < Long.bitCount(res2) ? res : res2;
            }
        }

        long res = f[n][u - 1];
        var ans = new int[Long.bitCount(res)];
        for (int i = 0, j = 0; i < n; ++i)
            if (((res >> i) & 1) > 0)
                ans[j++] = i; // 所有在 res 中的下标
        return ans;
    }
}
```

```cpp
class Solution {
public:
    vector<int> smallestSufficientTeam(vector<string> &req_skills, vector<vector<string>> &people) {
        unordered_map<string, int> sid;
        int m = req_skills.size();
        for (int i = 0; i < m; ++i)
            sid[req_skills[i]] = i; // 字符串映射到下标

        int n = people.size(), u = 1 << m;
        // f[i+1][j] 表示从前 i 个集合中选择一些集合，并集等于 j，需要选择的最小集合
        long long f[n + 1][u];
        fill(f[0], f[0] + u, (1LL << n) - 1); // 对应记忆化搜索中的 if (i < 0) return all;
        f[0][0] = 0;
        for (int i = 0; i < n; ++i) {
            int mask = 0;
            for (auto &s: people[i]) // 把 people[i] 压缩成一个二进制数 mask[i]
                mask |= 1 << sid[s];
            f[i + 1][0] = 0;
            for (int j = 1; j < u; ++j) {
                auto r1 = f[i][j]; // 不选 mask
                auto r2 = f[i][j & ~mask] | (1L << i); // 选 mask
                f[i + 1][j] = __builtin_popcountll(r1) < __builtin_popcountll(r2) ? r1 : r2;
            }
        }
        auto res = f[n][u - 1];

        vector<int> ans;
        for (int i = 0; i < n; ++i)
            if ((res >> i) & 1)
                ans.push_back(i); // 所有在 res 中的下标
        return ans;
    }
};
```

```go
func smallestSufficientTeam(reqSkills []string, people [][]string) (ans []int) {
    m := len(reqSkills)
    sid := make(map[string]int, m)
    for i, s := range reqSkills {
        sid[s] = i // 字符串映射到下标
    }

    n := len(people)
    u, all := 1<<m, 1<<n-1
    // f[i+1][j] 表示从前 i 个集合中选择一些集合，并集等于 j，需要选择的最小集合
    f := make([][]int, n+1)
    for i := range f {
        f[i] = make([]int, u)
    }
    for j := 1; j < u; j++ {
        f[0][j] = all // 对应记忆化搜索中的 if (i < 0) return all
    }
    for i, skills := range people {
        mask := 0
        for _, s := range skills { // 把 skills 压缩成一个二进制数 mask[i]
            mask |= 1 << sid[s]
        }
        for j := 1; j < u; j++ {
            r1 := f[i][j] // 不选 mask[i]
            r2 := f[i][j&^mask] | 1<<i // 选 mask[i]
            if bits.OnesCount(uint(r1)) < bits.OnesCount(uint(r2)) {
                f[i+1][j] = r1
            } else {
                f[i+1][j] = r2
            }
        }
    }
    res := f[n][u-1]

    for i := 0; i < n; i++ {
        if res>>i&1 > 0 {
            ans = append(ans, i) // 所有在 res 中的下标
        }
    }
    return
}
```

#### 复杂度分析

-   时间复杂度：O(T+n2m)O(T+n2^m)O(T+n2m)，其中 TTT 为 $people$ 中的字符串的长度之和，nnn 为 $people$ 的长度，mmm 为 $reqSkills$ 的长度。忽略比较字符串的时间。初始化数组 mask\\textit{mask}mask 需要 O(T)O(T)O(T) 的时间。由于每个状态只会计算一次，递推的时间复杂度 \==\= 状态个数 ×\\times× 单个状态的计算时间。本题状态个数为 O(n2m)O(n2^m)O(n2m)，单个状态的计算时间为 O(1)O(1)O(1)，因此递推的时间复杂度为 O(n2m)O(n2^m)O(n2m)。
-   空间复杂度：O(S+n2m)O(S+n2^m)O(S+n2m)，其中 SSS 为 $reqSkills$ 中的字符串的长度之和。

#### 三、空间优化

由于计算 f[i+1]f[i+1]f[i+1] 只需要 f[i]f[i]f[i]，不需要下标更小的，所以只需要一个长为 2m2^m2m 的数组。

实现时需要倒序循环 $j$，原理见 [0-1 背包与完全背包【基础算法精讲 18】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV16Y411v7Y6%2F)。

```python
class Solution:
    def smallestSufficientTeam(self, req_skills: List[str], people: List[List[str]]) -> List[int]:
        sid = {s: i for i, s in enumerate(req_skills)}  # 字符串映射到下标
        n = len(people)
        u = 1 << len(req_skills)
        f = [(1 << n) - 1] * u
        f[0] = 0
        for i, skills in enumerate(people):
            mask = 0
            for s in skills:  # 把 skills 压缩成一个二进制数 mask
                mask |= 1 << sid[s]
            for j in range(u - 1, 0, -1):
                res = f[j]  # 不选 mask
                res2 = f[j & ~mask] | (1 << i)  # 选 mask
                f[j] = res if res.bit_count() < res2.bit_count() else res2
        res = f[-1]
        return [i for i in range(n) if (res >> i) & 1]  # 所有在 res 中的下标
```

```java
class Solution {
    public int[] smallestSufficientTeam(String[] reqSkills, List<List<String>> people) {
        var sid = new HashMap<String, Integer>();
        int m = reqSkills.length;
        for (int i = 0; i < m; ++i)
            sid.put(reqSkills[i], i); // 字符串映射到下标

        int n = people.size(), u = 1 << m;
        var f = new long[u];
        Arrays.fill(f, (1L << n) - 1);
        f[0] = 0;
        for (int i = 0; i < n; ++i) {
            int mask = 0;
            for (var s : people.get(i)) // 把 people[i] 压缩成一个二进制数 mask
                mask |= 1 << sid.get(s);
            for (int j = u - 1; j > 0; --j) {
                long res = f[j]; // 不选 mask
                long res2 = f[j & ~mask] | (1L << i); // 选 mask
                f[j] = Long.bitCount(res) < Long.bitCount(res2) ? res : res2;
            }
        }

        long res = f[u - 1];
        var ans = new int[Long.bitCount(res)];
        for (int i = 0, j = 0; i < n; ++i)
            if (((res >> i) & 1) > 0)
                ans[j++] = i; // 所有在 res 中的下标
        return ans;
    }
}
```

```cpp
class Solution {
public:
    vector<int> smallestSufficientTeam(vector<string> &req_skills, vector<vector<string>> &people) {
        unordered_map<string, int> sid;
        int m = req_skills.size();
        for (int i = 0; i < m; ++i)
            sid[req_skills[i]] = i; // 字符串映射到下标

        int n = people.size(), u = 1 << m;
        long long f[u];
        fill(f, f + u, (1LL << n) - 1);
        f[0] = 0;
        for (int i = 0; i < n; ++i) {
            int mask = 0;
            for (auto &s: people[i]) // 把 people[i] 压缩成一个二进制数 mask[i]
                mask |= 1 << sid[s];
            for (int j = u - 1; j; --j) {
                auto r1 = f[j]; // 不选 mask
                auto r2 = f[j & ~mask] | (1L << i); // 选 mask
                f[j] = __builtin_popcountll(r1) < __builtin_popcountll(r2) ? r1 : r2;
            }
        }
        auto res = f[u - 1];

        vector<int> ans;
        for (int i = 0; i < n; ++i)
            if ((res >> i) & 1)
                ans.push_back(i); // 所有在 res 中的下标
        return ans;
    }
};
```

```go
func smallestSufficientTeam(reqSkills []string, people [][]string) (ans []int) {
    m := len(reqSkills)
    sid := make(map[string]int, m)
    for i, s := range reqSkills {
        sid[s] = i // 字符串映射到下标
    }

    n := len(people)
    u, all := 1<<m, 1<<n-1
    f := make([]int, u)
    for j := 1; j < u; j++ {
        f[j] = all // 对应记忆化搜索中的 if (i < 0) return all
    }
    for i, skills := range people {
        mask := 0
        for _, s := range skills { // 把 skills 压缩成一个二进制数 mask[i]
            mask |= 1 << sid[s]
        }
        for j := u - 1; j > 0; j-- {
            r1 := f[j] // 不选 mask[i]
            r2 := f[j&^mask] | 1<<i // 选 mask[i]
            if bits.OnesCount(uint(r1)) > bits.OnesCount(uint(r2)) {
                f[j] = r2
            }
        }
    }
    res := f[u-1]

    for i := 0; i < n; i++ {
        if res>>i&1 > 0 {
            ans = append(ans, i) // 所有在 res 中的下标
        }
    }
    return
}
```

#### 复杂度分析

-   时间复杂度：O(T+n2m)O(T+n2^m)O(T+n2m)，其中 TTT 为 $people$ 中的字符串的长度之和，nnn 为 $people$ 的长度，mmm 为 $reqSkills$ 的长度。忽略比较字符串的时间。初始化数组 mask\\textit{mask}mask 需要 O(T)O(T)O(T) 的时间。由于每个状态只会计算一次，递推的时间复杂度 \==\= 状态个数 ×\\times× 单个状态的计算时间。本题状态个数为 O(n2m)O(n2^m)O(n2m)，单个状态的计算时间为 O(1)O(1)O(1)，因此递推的时间复杂度为 O(n2m)O(n2^m)O(n2m)。
-   空间复杂度：O(S+2m)O(S+2^m)O(S+2m)，其中 SSS 为 $reqSkills$ 中的字符串的长度之和。

#### 四、查表法 vs 刷表法

上面的做法算作查表法，意思是用其它状态更新当前状态。但是这种写法无法跳过无效的状态，在很多不必要的计算上浪费了大量时间。

我们还可以用当前状态去更新其它状态，从小到大遍历每个 f[j]f[j]f[j]，然后遍历 mask\\textit{mask}mask，用 f[j]f[j]f[j] 去更新 f[j∣mask[i]]f[j|\\textit{mask}[i]]f[j∣mask[i]]。

由于我们是从小到大遍历 $j$，并且更新也是更新到比 $j$ 更大的数上，如果 f[j]f[j]f[j] 等于其初始值，说明没有它被更新过，也就说明 $j$ 无法由若干集合的并集得到，是无效状态，可以直接跳过。

```python
class Solution:
    def smallestSufficientTeam(self, req_skills: List[str], people: List[List[str]]) -> List[int]:
        sid = {s: i for i, s in enumerate(req_skills)}  # 字符串映射到下标
        n = len(people)
        mask = [0] * n
        for i, skills in enumerate(people):
            for s in skills:  # 把 skills 压缩成一个二进制数 mask[i]
                mask[i] |= 1 << sid[s]

        ALL = (1 << n) - 1
        u = 1 << len(req_skills)
        f = [ALL] * u  # f[j] 表示并集为 j 要选的最小 people 集合
        f[0] = 0
        for j in range(u - 1):  # f[u-1] 无需计算
            if f[j] == ALL: continue  # 无法更新其它状态，直接跳过
            for i, msk in enumerate(mask):
                if f[j].bit_count() + 1 < f[j | msk].bit_count():
                    f[j | msk] = f[j] | (1 << i)  # 刷表：用 f[j] 去更新其它状态

        res = f[-1]
        return [i for i in range(n) if (res >> i) & 1]  # 所有在 res 中的下标
```

```java
class Solution {
    public int[] smallestSufficientTeam(String[] reqSkills, List<List<String>> people) {
        var sid = new HashMap<String, Integer>();
        int m = reqSkills.length;
        for (int i = 0; i < m; ++i)
            sid.put(reqSkills[i], i); // 字符串映射到下标

        int n = people.size();
        var mask = new int[n];
        for (int i = 0; i < n; ++i)
            for (var s : people.get(i)) // 把 people[i] 压缩成一个二进制数 mask[i]
                mask[i] |= 1 << sid.get(s);

        long all = (1L << n) - 1;
        int u = 1 << m;
        var f = new long[u]; // f[j] 表示并集为 j 至少要选的 people 集合
        Arrays.fill(f, all);
        f[0] = 0;
        for (int j = 0; j < u - 1; ++j) // f[u-1] 无需计算
            if (f[j] < all)
                for (int i = 0; i < n; ++i)
                    if (Long.bitCount(f[j]) + 1 < Long.bitCount(f[j | mask[i]]))
                        f[j | mask[i]] = f[j] | (1L << i); // 刷表：用 f[j] 去更新其它状态

        long res = f[u - 1];
        var ans = new int[Long.bitCount(res)];
        for (int i = 0, j = 0; i < n; ++i)
            if (((res >> i) & 1) > 0)
                ans[j++] = i; // 所有在 res 中的下标
        return ans;
    }
}
```

```cpp
class Solution {
public:
    vector<int> smallestSufficientTeam(vector<string> &req_skills, vector<vector<string>> &people) {
        unordered_map<string, int> sid;
        int m = req_skills.size();
        for (int i = 0; i < m; ++i)
            sid[req_skills[i]] = i; // 字符串映射到下标

        int n = people.size(), mask[n];
        memset(mask, 0, sizeof(mask));
        for (int i = 0; i < n; ++i)
            for (auto &s: people[i]) // 把 people[i] 压缩成一个二进制数 mask[i]
                mask[i] |= 1 << sid[s];

        int u = 1 << m;
        long long all = (1LL << n) - 1, f[u];
        fill(f, f + u, all);
        f[0] = 0;
        for (int j = 0; j < u - 1; ++j) // f[u-1] 无需计算
            if (f[j] < all)
                for (int i = 0; i < n; ++i)
                    if (__builtin_popcountll(f[j]) + 1 < __builtin_popcountll(f[j | mask[i]]))
                        f[j | mask[i]] = f[j] | (1LL << i); // 刷表：用 f[j] 去更新其它状态
        auto res = f[u - 1];

        vector<int> ans;
        for (int i = 0; i < n; ++i)
            if ((res >> i) & 1)
                ans.push_back(i); // 所有在 res 中的下标
        return ans;
    }
};
```

```go
func smallestSufficientTeam(reqSkills []string, people [][]string) (ans []int) {
    m := len(reqSkills)
    sid := make(map[string]int, m)
    for i, s := range reqSkills {
        sid[s] = i // 字符串映射到下标
    }

    n := len(people)
    mask := make([]int, n)
    for i, skills := range people {
        for _, s := range skills { // 把 skills 压缩成一个二进制数 mask[i]
            mask[i] |= 1 << sid[s]
        }
    }

    u, all := 1<<m, 1<<n-1
    f := make([]int, u)
    for j := 1; j < u; j++ {
        f[j] = all // 对应记忆化搜索中的 if (i < 0) return all
    }
    for j, fj := range f {
        if fj < all {
            for i, msk := range mask {
                if bits.OnesCount(uint(fj))+1 < bits.OnesCount(uint(f[j|msk])) {
                    f[j|msk] = fj | 1<<i // 刷表：用 f[j] 去更新其它状态
                }
            }
        }
    }
    res := f[u-1]

    for i := 0; i < n; i++ {
        if res>>i&1 > 0 {
            ans = append(ans, i) // 所有在 res 中的下标
        }
    }
    return
}
```

#### 优化

由于计算二进制中 $1$ 的个数也比较耗时，新开一个数组 ids\\textit{ids}ids 单独记录压缩后的下标集合。这样 f[j]f[j]f[j] 的含义就是并集为 $j$ 最少要选的集合个数了。

```python
class Solution:
    def smallestSufficientTeam(self, req_skills: List[str], people: List[List[str]]) -> List[int]:
        sid = {s: i for i, s in enumerate(req_skills)}  # 字符串映射到下标
        n = len(people)
        mask = [0] * n
        for i, skills in enumerate(people):
            for s in skills:  # 把 skills 压缩成一个二进制数 mask[i]
                mask[i] |= 1 << sid[s]

        u = 1 << len(req_skills)
        ids = [0] * u  # ids[j] 表示 f[j] 对应的 people 下标集合
        f = [inf] * u  # f[j] 表示并集为 j 至少要选的 people 个数
        f[0] = 0
        for j in range(u - 1):  # f[u-1] 无需计算
            if f[j] == inf: continue  # 无法更新其它状态，直接跳过
            for i, msk in enumerate(mask):
                if f[j] + 1 < f[j | msk]:
                    f[j | msk] = f[j] + 1  # 刷表：用 f[j] 去更新其它状态
                    ids[j | msk] = ids[j] | (1 << i)

        res = ids[-1]
        return [i for i in range(n) if (res >> i) & 1]  # 所有在 res 中的下标
```

```java
class Solution {
    public int[] smallestSufficientTeam(String[] reqSkills, List<List<String>> people) {
        var sid = new HashMap<String, Integer>();
        int m = reqSkills.length;
        for (int i = 0; i < m; ++i)
            sid.put(reqSkills[i], i); // 字符串映射到下标

        int n = people.size();
        var mask = new int[n];
        for (int i = 0; i < n; ++i)
            for (var s : people.get(i)) // 把 people[i] 压缩成一个二进制数 mask[i]
                mask[i] |= 1 << sid.get(s);

        int u = 1 << m;
        var ids = new long[u]; // ids[j] 表示 f[j] 对应的 people 下标集合
        var f = new int[u]; // f[j] 表示并集为 j 至少要选的 people 个数
        Arrays.fill(f, Integer.MAX_VALUE);
        f[0] = 0;
        for (int j = 0; j < u - 1; ++j) // f[u-1] 无需计算
            if (f[j] < Integer.MAX_VALUE)
                for (int i = 0; i < n; ++i)
                    if (f[j] + 1 < f[j | mask[i]]) {
                        f[j | mask[i]] = f[j] + 1; // 刷表：用 f[j] 去更新其它状态
                        ids[j | mask[i]] = ids[j] | (1L << i);
                    }

        long res = ids[u - 1];
        var ans = new int[Long.bitCount(res)];
        for (int i = 0, j = 0; i < n; ++i)
            if (((res >> i) & 1) > 0)
                ans[j++] = i; // 所有在 res 中的下标
        return ans;
    }
}
```

```cpp
class Solution {
public:
    vector<int> smallestSufficientTeam(vector<string> &req_skills, vector<vector<string>> &people) {
        unordered_map<string, int> sid;
        int m = req_skills.size();
        for (int i = 0; i < m; ++i)
            sid[req_skills[i]] = i; // 字符串映射到下标

        int n = people.size(), mask[n];
        memset(mask, 0, sizeof(mask));
        for (int i = 0; i < n; ++i)
            for (auto &s: people[i]) // 把 people[i] 压缩成一个二进制数 mask[i]
                mask[i] |= 1 << sid[s];

        int u = 1 << m;
        long long ids[u]; memset(ids, 0, sizeof(ids));
        char f[u]; memset(f, 0x7f, sizeof(f));
        f[0] = 0;
        for (int j = 0; j < u - 1; ++j) // f[u-1] 无需计算
            if (f[j] < 0x7f)
                for (int i = 0; i < n; ++i)
                    if (f[j] + 1 < f[j | mask[i]]) {
                        f[j | mask[i]] = f[j] + 1; // 刷表：用 f[j] 去更新其它状态
                        ids[j | mask[i]] = ids[j] | (1LL << i);
                    }
        auto res = ids[u - 1];

        vector<int> ans;
        for (int i = 0; i < n; ++i)
            if ((res >> i) & 1)
                ans.push_back(i); // 所有在 res 中的下标
        return ans;
    }
};
```

```go
func smallestSufficientTeam(reqSkills []string, people [][]string) (ans []int) {
    m := len(reqSkills)
    sid := make(map[string]int, m)
    for i, s := range reqSkills {
        sid[s] = i // 字符串映射到下标
    }

    n := len(people)
    mask := make([]int, n)
    for i, skills := range people {
        for _, s := range skills { // 把 skills 压缩成一个二进制数 mask[i]
            mask[i] |= 1 << sid[s]
        }
    }

    u := 1 << m
    ids := make([]int, u)
    f := make([]int8, u)
    for j := 1; j < u; j++ {
        f[j] = math.MaxInt8
    }
    for j, fj := range f {
        if fj < math.MaxInt8 {
            for i, msk := range mask {
                if fj+1 < f[j|msk] {
                    f[j|msk] = fj + 1 // 刷表：用 f[j] 去更新其它状态
                    ids[j|msk] = ids[j] | 1<<i
                }
            }
        }
    }
    res := ids[u-1]

    for i := 0; i < n; i++ {
        if res>>i&1 > 0 {
            ans = append(ans, i) // 所有在 res 中的下标
        }
    }
    return
}
```

##### 复杂度分析

-   时间复杂度：O(T+n2m)O(T+n2^m)O(T+n2m)，其中 TTT 为 $people$ 中的字符串的长度之和，nnn 为 $people$ 的长度，mmm 为 $reqSkills$ 的长度。忽略比较字符串的时间。初始化数组 mask\\textit{mask}mask 需要 O(T)O(T)O(T) 的时间。由于每个状态只会计算一次，递推的时间复杂度 \==\= 状态个数 ×\\times× 单个状态的计算时间。本题状态个数为 O(n2m)O(n2^m)O(n2m)，单个状态的计算时间为 O(1)O(1)O(1)，因此递推的时间复杂度为 O(n2m)O(n2^m)O(n2m)。
-   空间复杂度：O(S+n+2m)O(S+n+2^m)O(S+n+2m)，其中 SSS 为 $reqSkills$ 中的字符串的长度之和。

##### 相似题目（0-1 背包）

-   [494\. 目标和](https://leetcode.cn/problems/target-sum/)
-   [416\. 分割等和子集](https://leetcode.cn/problems/partition-equal-subset-sum/)
-   [2518\. 好分区的数目](https://leetcode.cn/problems/number-of-great-partitions/)
