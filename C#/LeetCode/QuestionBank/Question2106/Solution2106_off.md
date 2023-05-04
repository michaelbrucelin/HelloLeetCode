﻿#### [方法一：二分查找](https://leetcode.cn/problems/maximum-fruits-harvested-after-at-most-k-steps/solutions/2254268/zhai-shui-guo-by-leetcode-solution-4j9v/)

**思路与算法**

由于题目中的水果位置已经是升序排列，假设此时我们知道在 xxx 轴上的移动区间为 \[left,right\]\[\\textit{left}, \\textit{right}\]\[left,right\]，则可利用二分查找很快计算出区间 \[left,right\]\[\\textit{left}, \\textit{right}\]\[left,right\] 范围内摘掉水果的数目。题目的关键则转变为求从起点移动 kkk 步而实际在 xxx 轴上移动的最大区间范围。当然在实际移动过程中肯定优先遵循「贪心」原则，因为这样每个位置的水果只能摘取一次，因此尽可能的移动更远，实际移动方法如下：

-   要么一直往一个方向移动 kkk 步；要么先往一个方向移动 xxx 步，然后再反方向移动 k−xk - xk−x 步；
-   实际当 x=0x = 0x\=0 时，则一直往一个方向移动 kkk 步；

根据以上分析，由于有左右两个方向，我们通过不断枚举 xxx，此时 x∈\[0,k2\]x \\in\[0, \\frac{k}{2}\]x∈\[0,2k\]，即可求出其移动的区间。假设我们从起点 startPos\\textit{startPos}startPos 出发，实际有以下两种情况：

-   先往左移动 xxx 步，然后向右移动 k−xk - xk−x 步，此时的移动区间范围 \[startPos−x,startPos+k−2x\]\[\\textit{startPos} - x, \\textit{startPos} + k - 2x\]\[startPos−x,startPos+k−2x\]；
-   先往右移动 xxx 步，然后向右移动 k−xk - xk−x 步，此时的移动区间范围 \[startPos+2x−k,startPos+x\]\[\\textit{startPos} + 2x - k,\\textit{startPos} + x\]\[startPos+2x−k,startPos+x\]；

假设已知道当前采摘人员在 xxx 轴上的移动区间范围，则我们利用二分查找即可在 O(log⁡n)O(\\log n)O(logn) 时间复杂度内找到区间中包含的水果的数量，实际可以用前缀和进行预处理即可。

**代码**

```cpp
class Solution {
public:
    int maxTotalFruits(vector<vector<int>>& fruits, int startPos, int k) {
        int n = fruits.size();
        vector<int> sum(n + 1);
        vector<int> indices(n);
        for (int i = 0; i < n; i++) {
            sum[i + 1] = sum[i] + fruits[i][1];
            indices[i] = fruits[i][0];
        }
        int ans = 0;
        for (int x = 0; x <= k / 2; x++) {
            /* 向左走 x 步，再向右走 k - x 步 */
            int y = k - 2 * x;
            int left = startPos - x;
            int right = startPos + y;
            int start = lower_bound(indices.begin(), indices.end(), left) - indices.begin();
            int end = upper_bound(indices.begin(), indices.end(), right) - indices.begin();
            ans = max(ans, sum[end] - sum[start]);
            /* 向右走 x 步，再向左走 k - x 步 */
            y = k - 2 * x;
            left = startPos - y;
            right = startPos + x;
            start = lower_bound(indices.begin(), indices.end(), left) - indices.begin();
            end = upper_bound(indices.begin(), indices.end(), right) - indices.begin();
            ans = max(ans, sum[end] - sum[start]);
        }
        return ans;
    }
};
```

```java
class Solution {
    public int maxTotalFruits(int[][] fruits, int startPos, int k) {
        int n = fruits.length;
        int[] sum = new int[n + 1];
        int[] indices = new int[n];
        sum[0] = 0;
        for (int i = 0; i < n; i++) {
            sum[i + 1] = sum[i] + fruits[i][1];
            indices[i] = fruits[i][0];
        }
        int ans = 0;
        for (int x = 0; x <= k / 2; x++) {
            /* 向左走 x 步，再向右走 k - x 步 */
            int y = k - 2 * x;
            int left = startPos - x;
            int right = startPos + y;
            int start = lowerBound(indices, 0, n - 1, left);
            int end = upperBound(indices, 0, n - 1, right);
            ans = Math.max(ans, sum[end] - sum[start]);
            /* 向右走 x 步，再向左走 k - x 步 */
            y = k - 2 * x;
            left = startPos - y;
            right = startPos + x;
            start = lowerBound(indices, 0, n - 1, left);
            end = upperBound(indices, 0, n - 1, right);
            ans = Math.max(ans, sum[end] - sum[start]);
        }
        return ans;
    }

    public int lowerBound(int[] arr, int left, int right, int val) {
        int res = right + 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] >= val) {
                res = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return res;
    }

    public int upperBound(int[] arr, int left, int right, int val) {
        int res = right + 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] > val) {
                res = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int MaxTotalFruits(int[][] fruits, int startPos, int k) {
        int n = fruits.Length;
        int[] sum = new int[n + 1];
        int[] indices = new int[n];
        sum[0] = 0;
        for (int i = 0; i < n; i++) {
            sum[i + 1] = sum[i] + fruits[i][1];
            indices[i] = fruits[i][0];
        }
        int ans = 0;
        for (int x = 0; x <= k / 2; x++) {
            /* 向左走 x 步，再向右走 k - x 步 */
            int y = k - 2 * x;
            int left = startPos - x;
            int right = startPos + y;
            int start = LowerBound(indices, 0, n - 1, left);
            int end = UpperBound(indices, 0, n - 1, right);
            ans = Math.Max(ans, sum[end] - sum[start]);
            /* 向右走 x 步，再向左走 k - x 步 */
            y = k - 2 * x;
            left = startPos - y;
            right = startPos + x;
            start = LowerBound(indices, 0, n - 1, left);
            end = UpperBound(indices, 0, n - 1, right);
            ans = Math.Max(ans, sum[end] - sum[start]);
        }
        return ans;
    }

    public int LowerBound(int[] arr, int left, int right, int val) {
        int res = right + 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] >= val) {
                res = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return res;
    }

    public int UpperBound(int[] arr, int left, int right, int val) {
        int res = right + 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] > val) {
                res = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return res;
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int lowerBound(const int *arr, int left, int right, int val) {
    int res = right + 1;
    while (left <= right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] >= val) {
            res = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return res;
}

int upperBound(const int *arr, int left, int right, int val) {
    int res = right + 1;
    while (left <= right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] > val) {
            res = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return res;
}

int maxTotalFruits(int** fruits, int fruitsSize, int* fruitsColSize, int startPos, int k) {
    int n = fruitsSize;
    int sum[n + 1];
    int indices[n];
    sum[0] = 0;
    for (int i = 0; i < n; i++) {
        sum[i + 1] = sum[i] + fruits[i][1];
        indices[i] = fruits[i][0];
    }
    int ans = 0;
    for (int x = 0; x <= k / 2; x++) {
        /* 向左走 x 步，再向右走 k - x 步 */
        int y = k - 2 * x;
        int left = startPos - x;
        int right = startPos + y;
        int start = lowerBound(indices, 0, n - 1, left);
        int end = upperBound(indices, 0, n - 1, right);
        ans = MAX(ans, sum[end] - sum[start]);
        /* 向右走 x 步，再向左走 k - x 步 */
        y = k - 2 * x;
        left = startPos - y;
        right = startPos + x;
        start = lowerBound(indices, 0, n - 1, left);
        end = upperBound(indices, 0, n - 1, right);
        ans = MAX(ans, sum[end] - sum[start]);
    }
    return ans;
}
```

```javascript
var maxTotalFruits = function(fruits, startPos, k) {
    const n = fruits.length;
    const sum = new Array(n + 1).fill(0);
    const indices = new Array(n).fill(0);
    sum[0] = 0;
    for (let i = 0; i < n; i++) {
        sum[i + 1] = sum[i] + fruits[i][1];
        indices[i] = fruits[i][0];
    }
    let ans = 0;
    for (let x = 0; x <= Math.floor(k / 2); x++) {
        /* 向左走 x 步，再向右走 k - x 步 */
        let y = k - 2 * x;
        let left = startPos - x;
        let right = startPos + y;
        let start = lowerBound(indices, 0, n - 1, left);
        let end = upperBound(indices, 0, n - 1, right);
        ans = Math.max(ans, sum[end] - sum[start]);
        /* 向右走 x 步，再向左走 k - x 步 */
        y = k - 2 * x;
        left = startPos - y;
        right = startPos + x;
        start = lowerBound(indices, 0, n - 1, left);
        end = upperBound(indices, 0, n - 1, right);
        ans = Math.max(ans, sum[end] - sum[start]);
    }
    return ans;
}

const lowerBound = (arr, left, right, val) => {
    let res = right + 1;
    while (left <= right) {
        const mid = left + Math.floor((right - left) / 2);
        if (arr[mid] >= val) {
            res = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return res;
}

const upperBound = (arr, left, right, val) => {
    let res = right + 1;
    while (left <= right) {
        const mid = left + Math.floor((right - left) / 2);
        if (arr[mid] > val) {
            res = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：O(n+klog⁡n)O(n + k \\log n)O(n+klogn)，其中 nnn 表示数组的长度，kkk 表示给定的整数 kkk。计算数组的前缀和需要的时间为 O(n)O(n)O(n)，每次查询区间中的水果数量时需要的时间为 O(log⁡n)O(\\log n)O(logn)，一共最多有 kkk 次查询，因此总的时间复杂度即为 n+klog⁡nn + k \\log nn+klogn。
-   空间复杂度：O(n)O(n)O(n)，其中 nnn 表示数组的长度。计算并存储数组的前缀和，需要的空间为 O(n)O(n)O(n)。

#### [方法二：滑动窗口](https://leetcode.cn/problems/maximum-fruits-harvested-after-at-most-k-steps/solutions/2254268/zhai-shui-guo-by-leetcode-solution-4j9v/)

**思路与算法**

我们可以换个思路来思考该问题，假设已知区间 \[left,right\]\[\\textit{left},\\textit{right}\]\[left,right\]，现在从起点 startPos\\textit{startPos}startPos 出发，至少需要走多少步才能遍历该区间，实际我们可以看到分为以下三种情况：

-   当 startPos>right\\textit{startPos} > \\textit{right}startPos\>right 时，即区间在 startPos\\textit{startPos}startPos 的左边，此时应该从起点开始一直向左移动，直到 left\\textit{left}left 为止，此时至少需要移动 startPos−left\\textit{startPos} -\\textit{left}startPos−left 步；
-   当 startPos<left\\textit{startPos} < \\textit{left}startPos<left 时，即区间在 startPos\\textit{startPos}startPos 的右边，此时应该从起点开始一直向右移动，直到 right\\textit{right}right 为止，此时至少需要移动 right−startPos\\textit{right} -\\textit{startPos}right−startPos 步；
-   当 left≤startPos≤right\\textit{left} \\le \\textit{startPos} \\le \\textit{right}left≤startPos≤right 时，即 startPos\\textit{startPos}startPos 刚好在区间范围内，此时有两种选择：
    -   从起点开始一直向左移动，直到 left\\textit{left}left 为止，然后再向右移动到 right\\textit{right}right，此时需要移动 startPos−left+right−left\\textit{startPos} - \\textit{left} + \\textit{right} - \\textit{left}startPos−left+right−left 步；
    -   从起点开始一直向右移动，直到 right\\textit{right}right 为止，然后再向左移动到 left\\textit{left}left，此时最少需要移动 right−startPos+right−left\\textit{right} - \\textit{startPos} + \\textit{right} - \\textit{left}right−startPos+right−left 步；
    -   根据两种情形，最少需要移动 right−left+min⁡(∣right−startPos∣,∣startPos−left∣)\\textit{right} - \\textit{left} + \\min(|\\textit{right} - \\textit{startPos}|,|\\textit{startPos} - \\textit{left}|)right−left+min(∣right−startPos∣,∣startPos−left∣) 步;
-   当然上述所有的情形都可以合并为一个计算公式，即实际最少需要移动 right−left+min⁡(∣right−startPos∣,∣startPos−left∣)\\textit{right} - \\textit{left} + \\min(|\\textit{right} - \\textit{startPos}|,|\\textit{startPos} - \\textit{left}|)right−left+min(∣right−startPos∣,∣startPos−left∣) 步，才能覆盖区间 \[left,right\]\[\\textit{left},\\textit{right}\]\[left,right\]，如下图所示： ![1](https://assets.leetcode-cn.com/solution-static/2106/2106_1.png)

我们设函数 step(left,right)\\text{step}(\\textit{left},\\textit{right})step(left,right) 表示从起点 startPos\\textit{startPos}startPos 出发可以覆盖区间 \[left,right\]\[\\textit{left},\\textit{right}\]\[left,right\] 的最少移动步数，此时 step(left,right)=right−left+min⁡(∣right−startPos∣,∣startPos−left∣)\\text{step}(\\textit{left},\\textit{right}) = \\textit{right} - \\textit{left} + \\min(|\\textit{right} - \\textit{startPos}|,|\\textit{startPos} - \\textit{left}|)step(left,right)\=right−left+min(∣right−startPos∣,∣startPos−left∣)。当固定 right\\textit{right}right 时，此时减少 left\\textit{left}left，可以观察到:

-   当 left<startPos\\textit{left} < \\textit{startPos}left<startPos 时，step(left−1,right)<step(left,right)\\text{step}(\\textit{left} - 1,\\textit{right}) < \\text{step}(\\textit{left},\\textit{right})step(left−1,right)<step(left,right);
-   当 left≥startPos\\textit{left} \\ge \\textit{startPos}left≥startPos 时，step(left−1,right)=step(left,right)\\text{step}(\\textit{left} - 1,\\textit{right}) = \\text{step}(\\textit{left},\\textit{right})step(left−1,right)\=step(left,right);

综上可以得到结论：

step(left−1,right)≤step(left,right) \\text{step}(\\textit{left} - 1,\\textit{right}) \\le \\text{step}(\\textit{left},\\textit{right}) step(left−1,right)≤step(left,right)

即随着 left\\textit{left}left 的减小，step(left,right)\\text{step}(\\textit{left},\\textit{right})step(left,right) 可能会减小，但一定不会继续增大，利用这个特性我们即可利用滑动窗口来遍历所有符合要求的最大区间，然后找到区间内的覆盖水果的最大值即可，实际计算过程如下:

-   初始时 left=0,right=0\\textit{left} = 0, \\textit{right} = 0left\=0,right\=0，每次 right\\textit{right}right 向右移动一步；
-   计算当前区间 \[left,right\]\[\\textit{left},\\textit{right}\]\[left,right\] 需要的移动步数 step\\textit{step}step，假设 step>k\\textit{step} > kstep\>k，则我们移动左起点 left\\textit{left}left，直达满足 step<k,left≤right\\textit{step} < k,\\textit{left} \\le \\textit{right}step<k,left≤right，即可求出移动步数小于等于 kkk 且以 right\\textit{right}right 为终点的最长区间，计算出改区间覆盖的水果数目即可；
-   依次按照上述方式移动直到 right\\textit{right}right 移动到终点为止。

**代码**

```cpp
class Solution {
public:
    int maxTotalFruits(vector<vector<int>>& fruits, int startPos, int k) {
        int left = 0;
        int right = 0;
        int n = fruits.size();
        int sum = 0;
        int ans = 0;

        auto step = [&](int left, int right) -> int {
            if (fruits[right][0] <= startPos) {
                return startPos - fruits[left][0];
            } else if (fruits[left][0] >= startPos) {
                return fruits[right][0] - startPos;
            } else {
                return min(abs(startPos - fruits[right][0]), abs(startPos - fruits[left][0])) + \
                       fruits[right][0] - fruits[left][0];
            }
        };
        // 每次固定住窗口右边界
        while (right < n) {
            sum += fruits[right][1];
            // 移动左边界
            while (left <= right && step(left, right) > k) {
                sum -= fruits[left][1];
                left++;
            }
            ans = max(ans, sum);
            right++;
        }
        return ans;
    }
};
```

```java
class Solution {
    public int maxTotalFruits(int[][] fruits, int startPos, int k) {
        int left = 0;
        int right = 0;
        int n = fruits.length;
        int sum = 0;
        int ans = 0;
        // 每次固定住窗口右边界
        while (right < n) {
            sum += fruits[right][1];
            // 移动左边界
            while (left <= right && step(fruits, startPos, left, right) > k) {
                sum -= fruits[left][1];
                left++;
            }
            ans = Math.max(ans, sum);
            right++;
        }
        return ans;
    }

    public int step(int[][] fruits, int startPos, int left, int right) {
        return Math.min(Math.abs(startPos - fruits[right][0]), Math.abs(startPos - fruits[left][0])) + fruits[right][0] - fruits[left][0];
    }
}
```

```csharp
public class Solution {
    public int MaxTotalFruits(int[][] fruits, int startPos, int k) {
        int left = 0;
        int right = 0;
        int n = fruits.Length;
        int sum = 0;
        int ans = 0;
        // 每次固定住窗口右边界
        while (right < n) {
            sum += fruits[right][1];
            // 移动左边界
            while (left <= right && Step(fruits, startPos, left, right) > k) {
                sum -= fruits[left][1];
                left++;
            }
            ans = Math.Max(ans, sum);
            right++;
        }
        return ans;
    }

    public int Step(int[][] fruits, int startPos, int left, int right) {
        if (fruits[right][0] <= startPos) {
            return startPos - fruits[left][0];
        } else if (fruits[left][0] >= startPos) {
            return fruits[right][0] - startPos;
        } else {
            return Math.Min(Math.Abs(startPos - fruits[right][0]), Math.Abs(startPos - fruits[left][0])) + fruits[right][0] - fruits[left][0];
        }
    }
}
```

```python
class Solution:
    def maxTotalFruits(self, fruits: List[List[int]], startPos: int, k: int) -> int:
        left = 0
        right = 0
        n = len(fruits)
        sum = 0
        ans = 0

        def step(left: int, right: int) -> int:
            if fruits[right][0] <= startPos:
                return startPos - fruits[left][0]
            elif fruits[left][0] >= startPos:
                return fruits[right][0] - startPos
            else:
                return min(abs(startPos - fruits[right][0]), abs(startPos - fruits[left][0])) + \
                    fruits[right][0] - fruits[left][0]

        # 每次固定住窗口右边界
        while right < n:
            sum += fruits[right][1]
            # 移动左边界
            while left <= right and step(left, right) > k:
                sum -= fruits[left][1]
                left += 1

            ans = max(ans, sum)
            right += 1

        return ans
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int step(const int** fruits, int left, int right, int startPos) {
    if (fruits[right][0] <= startPos) {
        return startPos - fruits[left][0];
    } else if (fruits[left][0] >= startPos) {
        return fruits[right][0] - startPos;
    } else {
        return MIN(abs(startPos - fruits[right][0]), abs(startPos - fruits[left][0])) + \
                fruits[right][0] - fruits[left][0];
    }
}

int maxTotalFruits(int** fruits, int fruitsSize, int* fruitsColSize, int startPos, int k) {
    int left = 0;
    int right = 0;
    int sum = 0;
    int ans = 0;

    /* 固定住窗口右边界 */
    while (right < fruitsSize) {
        sum += fruits[right][1];
        /* 移动左边界 */
        while (left <= right && step(fruits, left, right, startPos) > k) {
            sum -= fruits[left][1];
            left++;
        }
        ans = MAX(ans, sum);
        right++;
    }
    return ans;
}
```

```javascript
var maxTotalFruits = function(fruits, startPos, k) {
    let left = 0;
    let right = 0;
    const n = fruits.length;
    let sum = 0;
    let ans = 0;
    // 每次固定住窗口右边界
    while (right < n) {
        sum += fruits[right][1];
        // 移动左边界
        while (left <= right && step(fruits, startPos, left, right) > k) {
            sum -= fruits[left][1];
            left++;
        }
        ans = Math.max(ans, sum);
        right++;
    }
    return ans;
}

const step = (fruits, startPos, left, right) => {
    return Math.min(Math.abs(startPos - fruits[right][0]), Math.abs(startPos - fruits[left][0])) + fruits[right][0] - fruits[left][0];
};
```

```go
func maxTotalFruits(fruits [][]int, startPos int, k int) int {
    left := 0
    right := 0
    n := len(fruits)
    sum := 0
    ans := 0

    step := func(left int, right int) int {
        if fruits[right][0] <= startPos {
            return startPos - fruits[left][0]
        } else if fruits[left][0] >= startPos {
            return fruits[right][0] - startPos
        } else {
            return min(abs(startPos-fruits[right][0]), abs(startPos-fruits[left][0])) + fruits[right][0] - fruits[left][0]
        }
    }
    // 每次固定住窗口右边界
    for right < n {
        sum += fruits[right][1]
        // 移动左边界
        for left <= right && step(left, right) > k {
            sum -= fruits[left][1]
            left++
        }
        ans = max(ans, sum)
        right++
    }
    return ans
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

**复杂度分析**

-   时间复杂度：O(n)O(n)O(n)，其中 nnn 表示数组的长度。每次固定窗口的右侧，然后尝试移动左侧窗口，右侧端点最多移动 nnn 次，左侧端点最多移动 nnn 次，因此时间复杂度为 O(2n)=O(n)O(2n) = O(n)O(2n)\=O(n)。
-   空间复杂度：O(1)O(1)O(1)。
