#### [方法一：贪心 + 双指针](https://leetcode.cn/problems/form-array-by-concatenating-subarrays-of-another-array/solutions/2022689/tong-guo-lian-jie-ling-yi-ge-shu-zu-de-z-xsvx/)

使用变量 i 指向需要匹配的数组，即 groups[i]。遍历数组 nums，假设当前遍历到第 k 个元素：
-   以 nums[k] 为首元素的子数组与 groups[i] 相同，那么 groups[i] 可以找到对应的子数组。为了满足不相交的要求，我们将 k 加上数组 groups[i] 的长度，并且将 i 加 1；
-   以 nums[k] 为首元素的子数组与 groups[i] 不相同，那么我们直接将 k 加 1。

遍历结束时，如果 groups 的所有数组都找到对应的子数组，即 i = n 成立，返回 true；否则返回 false。

> **贪心的正确性**
> 
> 证明：假设存在 n 个不相交的子数组，使得第 i 个子数组与 groups[i] 完全相同，并且第 i 个子数组的首元素下标为 k，那么在匹配查找的过程中，如果存在下标 $k_1 \lt k$ 也满足第 i 个子数组的要求，显然我们将 $k_1$ 替代 k 是不影响后续的匹配的。

```python
class Solution:
    def canChoose(self, groups: List[List[int]], nums: List[int]) -> bool:
        k = 0
        for g in groups:
            while k + len(g) <= len(nums):
                if nums[k: k + len(g)] == g:
                    k += len(g)
                    break
                k += 1
            else:
                return False
        return True
```

```cpp
class Solution {
public:
    bool check(vector<int> &g, vector<int> &nums, int k) {
        if (k + g.size() > nums.size()) {
            return false;
        }
        for (int j = 0; j < g.size(); j++) {
            if (g[j] != nums[k + j]) {
                return false;
            }
        }
        return true;
    }

    bool canChoose(vector<vector<int>>& groups, vector<int>& nums) {
        int i = 0;
        for (int k = 0; k < nums.size() && i < groups.size();) {
            if (check(groups[i], nums, k)) {
                k += groups[i].size();
                i++;
            } else {
                k++;
            }
        }
        return i == groups.size();
    }
};
```

```java
class Solution {
    public boolean canChoose(int[][] groups, int[] nums) {
        int i = 0;
        for (int k = 0; k < nums.length && i < groups.length;) {
            if (check(groups[i], nums, k)) {
                k += groups[i].length;
                i++;
            } else {
                k++;
            }
        }
        return i == groups.length;
    }

    public boolean check(int[] g, int[] nums, int k) {
        if (k + g.length > nums.length) {
            return false;
        }
        for (int j = 0; j < g.length; j++) {
            if (g[j] != nums[k + j]) {
                return false;
            }
        }
        return true;
    }
}
```

```c#
public class Solution {
    public bool CanChoose(int[][] groups, int[] nums) {
        int i = 0;
        for (int k = 0; k < nums.Length && i < groups.Length;) {
            if (Check(groups[i], nums, k)) {
                k += groups[i].Length;
                i++;
            } else {
                k++;
            }
        }
        return i == groups.Length;
    }

    public bool Check(int[] g, int[] nums, int k) {
        if (k + g.Length > nums.Length) {
            return false;
        }
        for (int j = 0; j < g.Length; j++) {
            if (g[j] != nums[k + j]) {
                return false;
            }
        }
        return true;
    }
}
```

```c
bool check(const int *g, int gSize, const int *nums, int numsSize, int k) {
    if (k + gSize > numsSize) {
        return false;
    }
    for (int j = 0; j < gSize; j++) {
        if (g[j] != nums[k + j]) {
            return false;
        }
    }
    return true;
}

bool canChoose(int** groups, int groupsSize, int* groupsColSize, int* nums, int numsSize) {
    int i = 0;
    for (int k = 0; k < numsSize && i < groupsSize;) {
        if (check(groups[i], groupsColSize[i], nums, numsSize, k)) {
            k += groupsColSize[i];
            i++;
        } else {
            k++;
        }
    }
    return i == groupsSize;
}
```

```javascript
var canChoose = function(groups, nums) {
    let i = 0;
    for (let k = 0; k < nums.length && i < groups.length;) {
        if (check(groups[i], nums, k)) {
            k += groups[i].length;
            i++;
        } else {
            k++;
        }
    }
    return i === groups.length;
}

const check = (g, nums, k) => {
    if (k + g.length > nums.length) {
        return false;
    }
    for (let j = 0; j < g.length; j++) {
        if (g[j] !== nums[k + j]) {
            return false;
        }
    }
    return true;
};
```

```go
func canChoose(groups [][]int, nums []int) bool {
next:
    for _, g := range groups {
        for len(nums) >= len(g) {
            if equal(nums[:len(g)], g) {
                nums = nums[len(g):]
                continue next
            }
            nums = nums[1:]
        }
        return false
    }
    return true
}

func equal(a, b []int) bool {
    for i, x := range a {
        if x != b[i] {
            return false
        }
    }
    return true
}
```

**复杂度分析**

-   时间复杂度：$O(m \times \max g_i)$，其中 $m$ 是数组 $nums$ 的长度，$g_i$ 是数组 $groups[i]$ 的长度。最坏情况下，数组 $nums$ 在每个位置都调用一次 $check$ 函数，因此总时间复杂度为 $O(m \times \max g_i)$
-   空间复杂度：$O(1)$。
