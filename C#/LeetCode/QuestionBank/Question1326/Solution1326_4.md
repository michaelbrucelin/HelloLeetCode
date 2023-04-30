﻿#### [一张图秒懂！（Python/Java/C++/Go）](https://leetcode.cn/problems/minimum-number-of-taps-to-open-to-water-a-garden/solutions/2123855/yi-zhang-tu-miao-dong-pythonjavacgo-by-e-wqry/)

首先解释下示例 2 为什么要输出 $-1$：因为「整个花园」包含不是整点的位置，例如 $0.5$ 这种小数位置也要被灌溉到，但输入只能灌溉 $0,1,2,3$ 这 $4$ 个整点。

![](./assets/img/Solution1326_4_01.png)

#### 答疑

**问**：我能想出这题的思路，就是代码实现总是写不对，有没有什么建议？

**答**：清晰的变量名以及一些必要的注释，会对理清代码逻辑有帮助。在出现错误时，可以用一些小数据去运行你的代码，通过 print 或者打断点的方式，查看这些关键变量的值，看看是否与预期结果一致。

```python
class Solution:
    def minTaps(self, n: int, ranges: List[int]) -> int:
        right_most = [0] * (n + 1)
        for i, r in enumerate(ranges):
            left = max(i - ranges[i], 0)
            right_most[left] = max(right_most[left], i + ranges[i])

        ans = 0
        cur_right = 0  # 已建造的桥的右端点
        next_right = 0  # 下一座桥的右端点的最大值
        for i in range(n):  # 注意这里没有遍历到 n，因为它已经是终点了
            next_right = max(next_right, right_most[i])
            if i == cur_right:  # 到达已建造的桥的右端点
                if i == next_right:  # 无论怎么造桥，都无法从 i 到 i+1
                    return -1
                cur_right = next_right  # 造一座桥
                ans += 1
        return ans
```

```java
class Solution {
    public int minTaps(int n, int[] ranges) {
        int[] rightMost = new int[n + 1];
        for (int i = 0; i <= n; ++i) {
            int r = ranges[i];
            // 这样写可以在 i>r 时少写一个 max
            // 凭借这个优化，恭喜你超越了 100% 的用户
            // 说「超越」是因为原来的最快是 2ms，现在优化后是 1ms
            if (i > r) rightMost[i - r] = i + r; // 对于 i-r 来说，i+r 必然是它目前的最大值
            else rightMost[0] = Math.max(rightMost[0], i + r);
        }

        int ans = 0;
        int curRight = 0; // 已建造的桥的右端点
        int nextRight = 0; // 下一座桥的右端点的最大值
        for (int i = 0; i < n; ++i) { // 注意这里没有遍历到 n，因为它已经是终点了
            nextRight = Math.max(nextRight, rightMost[i]);
            if (i == curRight) { // 到达已建造的桥的右端点
                if (i == nextRight) return -1; // 无论怎么造桥，都无法从 i 到 i+1
                curRight = nextRight; // 造一座桥
                ++ans;
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int minTaps(int n, vector<int> &ranges) {
        int right_most[n + 1]; memset(right_most, 0, sizeof(right_most));
        for (int i = 0; i <= n; ++i) {
            int r = ranges[i];
            if (i > r) right_most[i - r] = i + r; // 对于 i-r 来说，i+r 必然是它目前的最大值
            else right_most[0] = max(right_most[0], i + r);
        }

        int ans = 0;
        int cur_right = 0; // 已建造的桥的右端点
        int next_right = 0; // 下一座桥的右端点的最大值
        for (int i = 0; i < n; ++i) { // 注意这里没有遍历到 n，因为它已经是终点了
            next_right = max(next_right, right_most[i]);
            if (i == cur_right) { // 到达已建造的桥的右端点
                if (i == next_right) return -1; // 无论怎么造桥，都无法从 i 到 i+1
                cur_right = next_right; // 造一座桥
                ++ans;
            }
        }
        return ans;
    }
};
```

```go
func minTaps(n int, ranges []int) (ans int) {
    rightMost := make([]int, n+1)
    for i, r := range ranges {
        left := max(i-r, 0)
        rightMost[left] = max(rightMost[left], i+r)
    }

    curRight := 0 // 已建造的桥的右端点
    nextRight := 0 // 下一座桥的右端点的最大值
    for i, r := range rightMost[:n] { // 注意这里没有遍历到 n，因为它已经是终点了
        nextRight = max(nextRight, r)
        if i == curRight { // 到达已建造的桥的右端点
            if i == nextRight { // 无论怎么造桥，都无法从 i 到 i+1
                return -1
            }
            curRight = nextRight // 造一座桥
            ans++
        }
    }
    return
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$O(n)$。
-   空间复杂度：$O(n)$。

#### 相似题目

-   [55\. 跳跃游戏](https://leetcode.cn/problems/jump-game/)
-   [45\. 跳跃游戏 II](https://leetcode.cn/problems/jump-game-ii/)
-   [1024\. 视频拼接](https://leetcode.cn/problems/video-stitching/)
