### [最小元素和最大元素的最小平均值](https://leetcode.cn/problems/minimum-average-of-smallest-and-largest-elements/solutions/2943777/zui-xiao-yuan-su-he-zui-da-yuan-su-de-zu-2kab/)

#### 方法一：排序

首先将 $nums$ 从小到大进行排序，然后枚举 $i \in [0,\frac{n}{2}​)$，取 $\frac{nums[i]+nums[n-1-i]}{2}$​ 的最小值。

```C++
class Solution {
public:
    double minimumAverage(vector<int>& nums) {
        sort(nums.begin(), nums.end());
        int n = nums.size();
        double res = numeric_limits<double>::max();
        for (int i = 0; i < n / 2; i++) {
            res = min(res, (nums[i] + nums[n - 1 - i]) / 2.0);
        }
        return res;
    }
};
```

```Go
func minimumAverage(nums []int) float64 {
    sort.Ints(nums)
    res, n := math.MaxFloat64, len(nums)
    for i := 0; i < n / 2; i++ {
        res = min(res, float64(nums[i] + nums[n - 1 - i]) / 2)
    }
    return res;
}
```

```Python
class Solution:
    def minimumAverage(self, nums: List[int]) -> float:
        nums.sort()
        res, n = inf, len(nums)
        for i in range(n // 2):
            res = min(res, (nums[i] + nums[n - 1 - i]) / 2)
        return res
```

```C
int cmp(const void *p1, const void *p2) {
    return *(int *)p1 - *(int *)p2;
}

double minimumAverage(int* nums, int numsSize) {
    qsort(nums, numsSize, sizeof(int), cmp);
    double res = INT_MAX;
    for (int i = 0; i < numsSize / 2; i++) {
        res = fmin(res, (nums[i] + nums[numsSize - 1 - i]) / 2.0);
    }
    return res;
}
```

```Java
class Solution {
    public double minimumAverage(int[] nums) {
        Arrays.sort(nums);
        int n = nums.length;
        double res = Double.MAX_VALUE;
        for (int i = 0; i < n / 2; i++) {
            res = Math.min(res, (nums[i] + nums[n - 1 - i]) / 2.0);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public double MinimumAverage(int[] nums) {
        Array.Sort(nums);
        int n = nums.Length;
        double res = double.MaxValue;
        for (int i = 0; i < n / 2; i++) {
            res = Math.Min(res, (nums[i] + nums[n - 1 - i]) / 2.0);
        }
        return res;
    }
}
```

```var minimumAverage = function(nums) {
    nums.sort((a, b) => a - b);
    const n = nums.length;
    let res = Number.MAX_VALUE;
    for (let i = 0; i < Math.floor(n / 2); i++) {
        res = Math.min(res, (nums[i] + nums[n - 1 - i]) / 2);
    }
    return res;
};
```

```TypeScript
function minimumAverage(nums: number[]): number {
    nums.sort((a, b) => a - b);
    const n = nums.length;
    let res = Number.MAX_VALUE;
    for (let i = 0; i < Math.floor(n / 2); i++) {
        res = Math.min(res, (nums[i] + nums[n - 1 - i]) / 2);
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn minimum_average(nums: Vec<i32>) -> f64 {
        let mut nums = nums;
        nums.sort();
        let n = nums.len();
        let mut res = f64::INFINITY;
        for i in 0..n/2 {
            let average = (nums[i] as f64 + nums[n - 1 - i] as f64) / 2.0;
            res = res.min(average);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 是数组 $nums$ 的长度。排序需要 $O(nlogn)$。
- 空间复杂度：$O(logn)$。排序需要 $O(logn)$ 的栈空间。
