#### [方法一：二分查找](https://leetcode.cn/problems/maximum-fruits-harvested-after-at-most-k-steps/solutions/2254268/zhai-shui-guo-by-leetcode-solution-4j9v/)

**思路与算法**

由于题目中的水果位置已经是升序排列，假设此时我们知道在 $x$ 轴上的移动区间为 $[left, right]$，则可利用二分查找很快计算出区间 $[left, right]$ 范围内摘掉水果的数目。题目的关键则转变为求从起点移动 $k$ 步而实际在 $x$ 轴上移动的最大区间范围。当然在实际移动过程中肯定优先遵循「贪心」原则，因为这样每个位置的水果只能摘取一次，因此尽可能的移动更远，实际移动方法如下：

-   要么一直往一个方向移动 $k$ 步；要么先往一个方向移动 $x$ 步，然后再反方向移动 $k - x$ 步；
-   实际当 $x = 0$ 时，则一直往一个方向移动 $k$ 步；

根据以上分析，由于有左右两个方向，我们通过不断枚举 $x$，此时 $x \in[0, \frac{k}{2}]$，即可求出其移动的区间。假设我们从起点 $startPos$ 出发，实际有以下两种情况：

-   先往左移动 $x$ 步，然后向右移动 $k - x$ 步，此时的移动区间范围 $[startPos - x, startPos + k - 2x]$；
-   先往右移动 $x$ 步，然后向右移动 $k - x$ 步，此时的移动区间范围 $[startPos + 2x - k, startPos + x]$；

假设已知道当前采摘人员在 $x$ 轴上的移动区间范围，则我们利用二分查找即可在 $O(\log n)$ 时间复杂度内找到区间中包含的水果的数量，实际可以用前缀和进行预处理即可。

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

-   时间复杂度：$O(n + k \log n)$，其中 $n$ 表示数组的长度，$k$ 表示给定的整数 $k$。计算数组的前缀和需要的时间为 $O(n)$，每次查询区间中的水果数量时需要的时间为 $O(\log n)$，一共最多有 $k$ 次查询，因此总的时间复杂度即为 $n + k \log n$。
-   空间复杂度：$O(n)$，其中 $n$ 表示数组的长度。计算并存储数组的前缀和，需要的空间为 $O(n)$。
