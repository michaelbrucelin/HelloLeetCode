### [使二叉树所有路径值相等的最小代价](https://leetcode.cn/problems/make-costs-of-paths-equal-in-a-binary-tree/solutions/2656293/shi-er-cha-shu-suo-you-lu-jing-zhi-xiang-65hk/)

#### 方法一：自底向上 + 贪心

##### 思路与算法

我们首先考虑所有的叶结点。

对于任一叶结点，它的值为 $x$，它的兄弟节点的值为 $y$。可以发现，对于树上的其余节点，它们要么同时是这两个叶节点的祖先，要么同时不是这两个叶节点的祖先。对这些节点进行一次操作，要么同时增加了根到这两个叶节点的路径值 $1$，要么没有任何效果。因此，要想使得根到这两个叶节点的路径值相等，我们只能增加 $x$ 和 $y$ 本身。

由于我们希望操作次数最少，那么应该进行 $|x - y|$ 次操作，将较小的值增加至与较大的值相等。

待考虑完所有叶节点之后，互为兄弟节点的叶节点的值两两相等（并且根到它们的路径值显然也相等）。如果我们还需要操作某个叶节点，那么为了使得路径值相等，它的兄弟节点同样也需要操作。此时就需要两次操作，但不如直接操作它们的双亲节点，可以省去一次操作。

因此，所有的叶节点都无需进行操作。我们就可以将它们全部移除。为了使得路径值保持不变，我们可以将叶节点的值增加至它们的双亲节点。这样一来，所有的双亲节点都变成了新的叶节点，我们重复进行上述操作即可。当只剩一个节点（根节点）时，就可以得到最终的答案。

##### 细节

由于本题中的树是以数组形式给定的，因此只需要对数组进行一次逆序遍历，就等价于对整个树进行了一次从叶节点开始的，自底向上的遍历。

##### 代码

```c++
class Solution {
public:
    int minIncrements(int n, vector<int>& cost) {
        int ans = 0;
        for (int i = n - 2; i > 0; i -= 2) {
            ans += abs(cost[i] - cost[i + 1]);
            // 叶节点 i 和 i+1 的双亲节点下标为 i/2（整数除法）
            cost[i / 2] += max(cost[i], cost[i + 1]);
        }
        return ans;
    }
};
```

```java
class Solution {
    public int minIncrements(int n, int[] cost) {
        int ans = 0;
        for (int i = n - 2; i > 0; i -= 2) {
            ans += Math.abs(cost[i] - cost[i + 1]);
            // 叶节点 i 和 i+1 的双亲节点下标为 i/2（整数除法）
            cost[i / 2] += Math.max(cost[i], cost[i + 1]);
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int MinIncrements(int n, int[] cost) {
        int ans = 0;
        for (int i = n - 2; i > 0; i -= 2) {
            ans += Math.Abs(cost[i] - cost[i + 1]);
            // 叶节点 i 和 i+1 的双亲节点下标为 i/2（整数除法）
            cost[i / 2] += Math.Max(cost[i], cost[i + 1]);
        }
        return ans;
    }
}
```

```python
class Solution:
    def minIncrements(self, n: int, cost: List[int]) -> int:
        ans = 0
        for i in range(n - 2, 0, -2):
            ans += abs(cost[i] - cost[i + 1])
            # 叶节点 i 和 i+1 的双亲节点下标为 i/2（整数除法）
            cost[i // 2] += max(cost[i], cost[i + 1])
        return ans
```

```c
int minIncrements(int n, int* cost, int costSize){
    int ans = 0;
    for (int i = n - 2; i > 0; i -= 2) {
        ans += abs(cost[i] - cost[i + 1]);
        // 叶节点 i 和 i+1 的双亲节点下标为 i/2（整数除法）
        cost[i / 2] += fmax(cost[i], cost[i + 1]);
    }
    return ans;
}
```

```go
func minIncrements(n int, cost []int) int {
    ans := 0
    for i := n - 2; i > 0; i -= 2 {
        ans += abs(cost[i] - cost[i + 1])
        // 叶节点 i 和 i+1 的双亲节点下标为 i/2（整数除法）
        cost[i / 2] = cost[i / 2] + max(cost[i], cost[i + 1])
    }
    return ans
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```javascript
var minIncrements = function(n, cost) {
    let ans = 0;
    for (let i = n - 2; i > 0; i -= 2) {
        ans += Math.abs(cost[i] - cost[i + 1]);
        // 叶节点 i 和 i+1 的双亲节点下标为 i/2（整数除法）
        cost[i >> 1] += Math.max(cost[i], cost[i + 1]);
    }
    return ans;
};
```

```typescript
function minIncrements(n: number, cost: number[]): number {
    let ans = 0;
    for (let i = n - 2; i > 0; i -= 2) {
        ans += Math.abs(cost[i] - cost[i + 1]);
        // 叶节点 i 和 i+1 的双亲节点下标为 i/2（整数除法）
        cost[i >> 1] += Math.max(cost[i], cost[i + 1]);
    }
    return ans;
};
```

```rust
impl Solution {
    pub fn min_increments(n: i32, cost: Vec<i32>) -> i32 {
        let mut ans = 0;
        let mut cost = cost.clone();
        for i in (0..(n as usize) - 1).rev().step_by(2) {
            ans += (cost[i] - cost[i + 1]).abs();
            // 叶节点 i 和 i+1 的双亲节点下标为 i/2（整数除法）
            cost[i / 2] += cost[i].max(cost[i + 1]);
        }
        ans
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
