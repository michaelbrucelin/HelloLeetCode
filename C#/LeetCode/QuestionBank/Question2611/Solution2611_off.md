#### [方法一：贪心 + 排序](https://leetcode.cn/problems/mice-and-cheese/solutions/2292688/lao-shu-he-nai-luo-by-leetcode-solution-6ia1/)

有 $n$ 块不同类型的奶酪，分别位于下标 $0$ 到 $n - 1$。下标 $i$ 处的奶酪被第一只老鼠吃掉的得分为 $reward_1[i]$，被第二只老鼠吃掉的得分为 $reward_2[i]$。

如果 $n$ 块奶酪都被第二只老鼠吃掉，则得分为数组 $reward_2$ 的元素之和，记为 $sum$。如果下标 $i$ 处的奶酪被第一只老鼠吃掉，则得分的变化量是 $reward_1[i] - reward_2[i]$。

创建长度为 $n$ 的数组 $diffs$，其中 $diffs[i] = reward_1[i] - reward_2[i]$。题目要求计算第一只老鼠恰好吃掉 $k$ 块奶酪的情况下的最大得分，假设第一只老鼠吃掉的 $k$ 块奶酪的下标分别是 $i_1$ 到 $i_k$，则总得分为：

$$sum + \sum_{j = 1}^k diffs[i_j]$$

其中 $sum$ 为确定的值。根据贪心思想，为了使总得分最大化，应使下标 $i_1$ 到 $i_k$ 对应的 $diffs$ 的值最大，即应该选择 $diffs$ 中的 $k$ 个最大值。

贪心思想的正确性说明如下：假设下标 $i_1$ 到 $i_k$ 对应的 $diffs$ 的值不是最大的 $k$ 个值，则一定存在下标 $i_j$ 和下标 $p$ 满足 $diffs[p] \ge diffs[i_j]$ 且 $p$ 不在 $i_1$ 到 $i_k$ 的 $k$ 个下标中，将 $diffs[i_j]$ 替换成 $diffs[p]$ 之后的总得分不变或增加。因此使用贪心思想可以使总得分最大。

具体做法是，将数组 $diffs$ 排序，然后计算 $sum$ 与数组 $diffs$ 的 $k$ 个最大值之和，即为第一只老鼠恰好吃掉 $k$ 块奶酪的情况下的最大得分。

```java
class Solution {
    public int miceAndCheese(int[] reward1, int[] reward2, int k) {
        int ans = 0;
        int n = reward1.length;
        int[] diffs = new int[n];
        for (int i = 0; i < n; i++) {
            ans += reward2[i];
            diffs[i] = reward1[i] - reward2[i];
        }
        Arrays.sort(diffs);
        for (int i = 1; i <= k; i++) {
            ans += diffs[n - i];
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int MiceAndCheese(int[] reward1, int[] reward2, int k) {
        int ans = 0;
        int n = reward1.Length;
        int[] diffs = new int[n];
        for (int i = 0; i < n; i++) {
            ans += reward2[i];
            diffs[i] = reward1[i] - reward2[i];
        }
        Array.Sort(diffs);
        for (int i = 1; i <= k; i++) {
            ans += diffs[n - i];
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int miceAndCheese(vector<int>& reward1, vector<int>& reward2, int k) {
        int ans = 0;
        int n = reward1.size();
        vector<int> diffs(n);
        for (int i = 0; i < n; i++) {
            ans += reward2[i];
            diffs[i] = reward1[i] - reward2[i];
        }
        sort(diffs.begin(), diffs.end());
        for (int i = 1; i <= k; i++) {
            ans += diffs[n - i];
        }
        return ans;
    }
};
```

```python
class Solution:
    def miceAndCheese(self, reward1: List[int], reward2: List[int], k: int) -> int:
        ans = 0
        n = len(reward1)
        diffs = [reward1[i] - reward2[i] for i in range(n)]
        ans += sum(reward2)
        diffs.sort()
        for i in range(1, k+1):
            ans += diffs[n - i]
        return ans
```

```go
func miceAndCheese(reward1 []int, reward2 []int, k int) int {
    ans := 0
    n := len(reward1)
    diffs := make([]int, n)
    for i:= 0; i < n; i++ {
        ans += reward2[i]
        diffs[i] = reward1[i] - reward2[i]
    }
    sort.Ints(diffs)
    for i:=1; i <= k; i++ {
        ans += diffs[n - i]
    }
    return ans
}
```

```javascript
var miceAndCheese = function(reward1, reward2, k) {
    let ans = 0;
    let n = reward1.length;
    let diffs = new Array(n);
    for (let i = 0; i < n; i++) {
        ans += reward2[i];
        diffs[i] = reward1[i] - reward2[i];
    }
    diffs.sort((a, b) => a - b);
    for (let i = 1; i <= k; i++) {
        ans += diffs[n - i];
    }
    return ans;
}
```

```c
static int cmp(const void* pa, const void* pb) {
    return *(int *)pa - *(int *)pb;
}

int miceAndCheese(int* reward1, int reward1Size, int* reward2, int reward2Size, int k) {
    int ans = 0;
    int n = reward1Size;
    int diffs[n];
    for (int i = 0; i < n; i++) {
        ans += reward2[i];
        diffs[i] = reward1[i] - reward2[i];
    }
    qsort(diffs, n, sizeof(int), cmp);
    for (int i = 1; i <= k; i++) {
        ans += diffs[n - i];
    }
    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(n \log n)$，其中 $n$ 是数组 $reward_1$ 和 $reward_2$ 的长度。创建数组 $diffs$ 需要 $O(n)$ 的时间，将数组 $diffs$ 排序需要 $O(n \log n)$ 的时间，排序后计算 $diffs$ 的 $k$ 个最大值之和需要 $O(k)$ 的时间，其中 $k \le n$，因此时间复杂度是 $O(n \log n)$。
-   空间复杂度：$O(n)$，其中 $n$ 是数组 $reward_1$ 和 $reward_2$ 的长度。需要创建长度为 $n$ 的数组 $diffs$ 并排序，数组需要 $O(n)$ 的空间，排序需要 $O(\log n)$ 的递归调用栈空间，因此空间复杂度是 $O(n)$。
