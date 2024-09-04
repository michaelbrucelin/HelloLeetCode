### [让所有学生保持开心的分组方法数](https://leetcode.cn/problems/happy-students/solutions/2895368/rang-suo-you-xue-sheng-bao-chi-kai-xin-d-45br/)

#### 方法一：枚举

**思路与算法**

根据题意可知，假设数组 $nums$ 的长度为 $n$，此时设选中学生人数为 $k$，此时 $k \in [0,n]$，$k$ 应满足如下：

- 所有满足 $nums[i] < k$ 的学生应被选中；
- 所有满足 $nums[i] > k$ 的学生不应被选中；
- 不能存在 $nums[i] = k$ 的学生；

这意味着在确定当前已择中学生人数的前提下，则此时选择方案是唯一的，为方便判断，我们把 $nums$ 从小到大排序。我们枚举选中的人数 $k$，由于 $nums$ 已有序，此时最优分组一定是前 $k$ 个学生被选中，剩余的 $n-k$ 个学生不被选中，此时只需要检测选中的 $k$ 个学生中的最大值是否满足小于 $k$，未被选中的学生中的最小值是否满足大于 $k$ 即可，如果同时满足上述两个条件，则该分配方案可行，最终返回可行的方案计数即可，需要注意处理好边界 $0$ 与 $n$。

**代码**

```C++
class Solution {
public:
    int countWays(vector<int>& nums) {
        int n = nums.size();
        int res = 0;
        sort(nums.begin(), nums.end());
        for (int k = 0; k <= n; k++) {
            // 前 k 个元素的最大值是否小于 k
            if (k > 0 && nums[k - 1] >= k) {
                continue;
            }
            // 后 n - k 个元素的最小值是否大于 k
            if (k < n && nums[k] <= k) {
                continue;
            }
            res++;
        }
        return res;
    }
};
```

```Java
class Solution {
    public int countWays(List<Integer> nums) {
        int n = nums.size();
        int res = 0;
        Collections.sort(nums);
        for (int k = 0; k <= n; k++) {
            // 前 k 个元素的最大值是否小于 k
            if (k > 0 && nums.get(k - 1) >= k) {
                continue;
            }
            // 后 n - k 个元素的最小值是否大于 k
            if (k < n && nums.get(k) <= k) {
                continue;
            }
            res++;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountWays(IList<int> nums) {
        int n = nums.Count;
        int res = 0;
        ((List<int>) nums).Sort();
        for (int k = 0; k <= n; k++) {
            // 前 k 个元素的最大值是否小于 k
            if (k > 0 && nums[k - 1] >= k) {
                continue;
            }
            // 后 n - k 个元素的最小值是否大于 k
            if (k < n && nums[k] <= k) {
                continue;
            }
            res++;
        }
        return res;
    }
}
```

```C
int compare(const void *a, const void *b) {
    return (*(int*)a - *(int*)b);
}

int countWays(int* nums, int numsSize){
    int res = 0;
    qsort(nums, numsSize, sizeof(int), compare);
    for (int k = 0; k <= numsSize; k++) {
        // 前 k 个元素的最大值是否小于 k
        if (k > 0 && nums[k - 1] >= k) {
            continue;
        }
        // 后 n - k 个元素的最小值是否大于 k
        if (k < numsSize && nums[k] <= k) {
            continue;
        }
        res++;
    }
    return res; 
}
```

```Python
class Solution:
    def countWays(self, nums: List[int]) -> int:
        n = len(nums)
        res = 0
        nums.sort()
        for k in range(0, n + 1):
            # 前 k 个元素的最大值是否小于 k
            if k > 0 and nums[k - 1] >= k:
                continue
            # 后 n - k 个元素的最小值是否大于 k
            if k < n and nums[k] <= k:
                continue
            res += 1
        return res
```

```Go
func countWays(nums []int) int {
    n := len(nums)
    res := 0
    sort.Ints(nums)
    for k := 0; k <= n; k++ {
        // 前 k 个元素的最大值是否小于 k
        if k > 0 && nums[k - 1] >= k {
            continue
        }
        // 后 n - k 个元素的最小值是否大于 k
        if k < n && nums[k] <= k {
            continue;
        }
        res++
    }
    return res
}
```

```JavaScript
var countWays = function(nums) {
    const n = nums.length;
    let res = 0;
    nums.sort((a, b) => a - b);
    for (let k = 0; k <= n; k++) {
        // 前 k 个元素的最大值是否小于 k
        if (k > 0 && nums[k - 1] >= k) {
            continue
        }
        // 后 n - k 个元素的最小值是否大于 k
        if (k < n && nums[k] <= k) {
            continue;
        }
        res++
    }
    return res;
};
```

```TypeScript
function countWays(nums: number[]): number {
    const n = nums.length;
    let res = 0;
    nums.sort((a, b) => a - b);
    for (let k = 0; k <= n; k++) {
        // 前 k 个元素的最大值是否小于 k
        if (k > 0 && nums[k - 1] >= k) {
            continue
        }
        // 后 n - k 个元素的最小值是否大于 k
        if (k < n && nums[k] <= k) {
            continue;
        }
        res++
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn count_ways(mut nums: Vec<i32>) -> i32 {
        nums.sort();
        let n = nums.len();
        let mut res = 0;
        for k in 0..= n {
            // 前 k 个元素的最大值是否小于 k
            if k > 0 && nums[k - 1] >= k as i32 {
                continue;
            }
            // 后 n - k 个元素的最小值是否大于 k
            if k < n && nums[k] <= k as i32 {
                continue;
            }
            res += 1;
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 表示数组 $nums$ 的长度。排序需要的时间为 $O(nlogn)$。
- 空间复杂度：$O(logn)$，其中 $n$ 表示数组。排序需要 $O(logn)$ 的栈空间。
