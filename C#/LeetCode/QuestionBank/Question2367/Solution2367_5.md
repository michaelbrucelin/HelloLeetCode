#### [方法三：三指针](https://leetcode.cn/problems/number-of-arithmetic-triplets/solutions/2200026/suan-zhu-san-yuan-zu-de-shu-mu-by-leetco-ldq4/)

利用数组 $nums$ 严格递增的条件，可以使用三指针遍历数组得到算术三元组，使用 $O(n)$ 时间复杂度和 $O(1)$ 空间复杂度。

用 $i$、$j$ 和 $k$ 分别表示三元组的三个下标，其中 $i < j < k$，初始时 $i = 0$，$j = 1$，$k = 2$。对于每个下标 $i$，最多有一个下标 $j$ 和一个下标 $k$ 使得 $(i, j, k)$ 是算术三元组。假设存在两个算术三元组 $(i_1, j_1, k_1)$ 和 $(i_2, j_2, k_2)$ 满足 $i_1 < i_2$，则根据数组 $nums$ 严格递增可以得到 $nums[i_1] < nums[i_2]$，因此有 $nums[j_1] < nums[j_2]$ 和 $nums[k_1] < nums[k_2]$，下标关系满足 $j_1 < j_2$ 和 $k_1 < k_2$。由此可以得到结论：如果 $(i, j, k)$ 是算术三元组，则在将 $i$ 增加之后，为了得到以 $i$ 作为首个下标的算术三元组，必须将 $j$ 和 $k$ 也增加。

利用上述结论，可以使用三指针统计算术三元组的数目。

从小到大枚举每个 $i$，对于每个 $i$，执行如下操作。

1.  定位 $j$。
    1.  为了确保 $j > i$，如果 $j \le i$ 则将 $j$ 更新为 $i + 1$。
    2.  如果 $j < n - 1$ 且 $nums[j] - nums[i] < diff$，则只有将 $j$ 向右移动才可能满足 $nums[j] - nums[i] = diff$，因此将 $j$ 向右移动，直到 $j \ge n - 1$ 或 $nums[j] - nums[i] \ge diff$。如果此时 $j \ge n - 1$ 或 $nums[j] - nums[i] > diff$，则对于当前的 $i$ 不存在 $j$ 和 $k$ 可以组成算术三元组，因此继续枚举下一个 $i$。
2.  当 $j < n - 1$ 且 $nums[j] - nums[i] = diff$ 时，定位 $k$。
    1.  为了确保 $k > j$，如果 $k \le j$ 则将 $k$ 更新为 $j + 1$。
    2.  如果 $k < n$ 且 $nums[k] - nums[j] < diff$，则只有将 $k$ 向右移动才可能满足 $nums[k] - nums[j] = diff$，因此将 $k$ 向右移动，直到 $k \ge n$ 或 $nums[k] - nums[j] \ge diff$。如果此时 $k < n$ 且 $nums[k] - nums[j] = diff$，则当前的 $(i, j, k)$ 是算术三元组。

枚举所有可能的情况之后，即可得到算术三元组的数目。上述操作中，每个下标都只会增加不会减少，因此每个下标遍历数组的时间都是 $O(n)$。

```java
class Solution {
    public int arithmeticTriplets(int[] nums, int diff) {
        int ans = 0;
        int n = nums.length;
        for (int i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++) {
            j = Math.max(j, i + 1);
            while (j < n - 1 && nums[j] - nums[i] < diff) {
                j++;
            }
            if (j >= n - 1 || nums[j] - nums[i] > diff) {
                continue;
            }
            k = Math.max(k, j + 1);
            while (k < n && nums[k] - nums[j] < diff) {
                k++;
            }
            if (k < n && nums[k] - nums[j] == diff) {
                ans++;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int ArithmeticTriplets(int[] nums, int diff) {
        int ans = 0;
        int n = nums.Length;
        for (int i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++) {
            j = Math.Max(j, i + 1);
            while (j < n - 1 && nums[j] - nums[i] < diff) {
                j++;
            }
            if (j >= n - 1 || nums[j] - nums[i] > diff) {
                continue;
            }
            k = Math.Max(k, j + 1);
            while (k < n && nums[k] - nums[j] < diff) {
                k++;
            }
            if (k < n && nums[k] - nums[j] == diff) {
                ans++;
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int arithmeticTriplets(vector<int>& nums, int diff) {
        int ans = 0;
        int n = nums.size();
        for (int i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++) {
            j = max(j, i + 1);
            while (j < n - 1 && nums[j] - nums[i] < diff) {
                j++;
            }
            if (j >= n - 1 || nums[j] - nums[i] > diff) {
                continue;
            }
            k = max(k, j + 1);
            while (k < n && nums[k] - nums[j] < diff) {
                k++;
            }
            if (k < n && nums[k] - nums[j] == diff) {
                ans++;
            }
        }
        return ans;
    }
};
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int arithmeticTriplets(int* nums, int numsSize, int diff){
    int ans = 0;
    int n = numsSize;
    for (int i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++) {
        j = MAX(j, i + 1);
        while (j < n - 1 && nums[j] - nums[i] < diff) {
            j++;
        }
        if (j >= n - 1 || nums[j] - nums[i] > diff) {
            continue;
        }
        k = MAX(k, j + 1);
        while (k < n && nums[k] - nums[j] < diff) {
            k++;
        }
        if (k < n && nums[k] - nums[j] == diff) {
            ans++;
        }
    }
    return ans;
}
```

```javascript
var arithmeticTriplets = function(nums, diff) {
    let ans = 0;
    const n = nums.length;
    for (let i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++) {
        j = Math.max(j, i + 1);
        while (j < n - 1 && nums[j] - nums[i] < diff) {
            j++;
        }
        if (j >= n - 1 || nums[j] - nums[i] > diff) {
            continue;
        }
        k = Math.max(k, j + 1);
        while (k < n && nums[k] - nums[j] < diff) {
            k++;
        }
        if (k < n && nums[k] - nums[j] === diff) {
            ans++;
        }
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。三个指针最多各遍历数组一次。
-   空间复杂度：$O(1)$。只需要常数的额外空间。
