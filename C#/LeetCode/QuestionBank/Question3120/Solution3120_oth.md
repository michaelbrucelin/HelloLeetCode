### [位运算一次遍历 + O(1) 空间（Python/Java/C++/Go）](https://leetcode.cn/problems/count-the-number-of-special-characters-i/solutions/2749291/wei-yun-suan-yi-ci-bian-li-o1-kong-jian-c6wy1/)

用两个集合分别记录小写字母和大写字母（转成小写字母），集合交集的大小就是答案。

这可以用位运算实现，原理请看 [从集合论到位运算，常见位运算技巧分类总结！](https://leetcode.cn/circle/discuss/CaOJ45/)

对于大写英文字母：其二进制从右往左第 $6$ 个比特值一定是 $0$。

对于小写英文字母：其二进制从右往左第 $6$ 个比特值一定是 $1$。

对于任何英文字母：其小写字母二进制低 $5$ 位，一定和其大写字母二进制低 $5$ 位相等。

具体请看 [视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1gu4m1F7B8%2F)，欢迎点赞关注！

##### 代码

```python
class Solution:
    def numberOfSpecialChars(self, word: str) -> int:
        mask = [0, 0]
        for c in map(ord, word):
            mask[c >> 5 & 1] |= 1 << (c & 31)
        return (mask[0] & mask[1]).bit_count()
```

```java
class Solution {
    public int numberOfSpecialChars(String word) {
        int[] mask = new int[2];
        for (char c : word.toCharArray()) {
            mask[c >> 5 & 1] |= 1 << (c & 31);
        }
        return Integer.bitCount(mask[0] & mask[1]);
    }
}
```

```c++
class Solution {
public:
    int numberOfSpecialChars(string word) {
        int mask[2]{};
        for (char c : word) {
            mask[c >> 5 & 1] |= 1 << (c & 31);
        }
        return __builtin_popcount(mask[0] & mask[1]);
    }
};
```

```go
func numberOfSpecialChars(word string) int {
    mask := [2]int{}
    for _, c := range word {
        mask[c>>5&1] |= 1 << (c & 31)
    }
    return bits.OnesCount(uint(mask[0] & mask[1]))
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $\textit{word}$ 的长度。
- 空间复杂度：$\mathcal{O}(1)$。

#### 分类题单

- [滑动窗口（定长/不定长/多指针）](https://leetcode.cn/circle/discuss/0viNMK/)
- [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
- [单调栈（矩形系列/字典序最小/贡献法）](https://leetcode.cn/circle/discuss/9oZFK9/)
- [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
- [位运算（基础/性质/拆位/试填/恒等式/贪心/脑筋急转弯）](https://leetcode.cn/circle/discuss/dHn9Vk/)
- [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
- [动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
