### [等价转化，O(1) 公式（Python/Java/C++/Go）](https://leetcode.cn/problems/minimum-cost-to-split-into-ones/solutions/3910783/deng-jie-zhuan-hua-o1-gong-shi-pythonjav-9flx/?envType=problem-list-v2&envId=ySsxoJfz)

问题等价于如下递归过程：

- 有一个完全图，包含 $n$ 个节点，任意两个节点之间都有一条无向边，一共有 $C(n,2)=\dfrac{n(n-1)}{2}$ 条边。
- 把这 $n$ 个点划分成两组，记作 $A$ 和 $B$，大小分别为 $a$ 和 $b$，满足 $a+b=n$。组 $A$ 中的每个点，到组 $B$ 中的每个点之间都有一条边，把这些边全部断开，一共断开了 $a\cdot b$ 条边。注意这正好就是这次划分的代价。
- 递归处理组 $A$，做法同上。
- 递归处理组 $B$，做法同上。
- 递归边界：如果一个组的大小等于 $1$，返回。

递归结束后，所有的边都断开了。一共断开了 $\dfrac{n(n-1)}{2}$ 条边，即为答案。

换句话说，**对于任意划分（拆分）方案，得到的答案都是** $\dfrac{n(n-1)}{2}$。

> 所以我觉得这题很神奇，只要你的代码最终能拆分成 $n$ 个 $1$，计算结果就是对的。此外，把题目改成计算「最大总代价」，算出的结果也是一样的。

[本题视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1V4PMzrEYG%2F)，欢迎点赞关注~

```Python
class Solution:
    def minCost(self, n: int) -> int:
        return n * (n - 1) // 2
```

```Java
class Solution {
    public int minCost(int n) {
        return n * (n - 1) / 2;
    }
}
```

```C++
class Solution {
public:
    int minCost(int n) {
        return n * (n - 1) / 2;
    }
};
```

```Go
func minCost(n int) int {
    return n * (n - 1) / 2
}
```

#### 复杂度分析

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。

#### 附：记忆化搜索做法

```python
# 把 dfs 写在 class 外面，这样 cache 保存的数据可以在不同的测试数据间共享
@cache
def dfs(n: int) -> int:
    if n == 1:
        return 0
    res = inf
    for a in range(1, n):
        b = n - a
        res = min(res, dfs(a) + dfs(b) + a * b)
    return res

class Solution:
    def minCost(self, n: int) -> int:
        return dfs(n)
```

#### 复杂度分析

- 时间复杂度：$O(n^2)$。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times $ 单个状态的计算时间。本题状态个数等于 $O(n)$，单个状态的计算时间为 $O(n)$，所以总的时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(n)$。保存多少状态，就需要多少空间。

#### 专题训练

见下面思维题单的「**§5.3 等价转化**」。

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
