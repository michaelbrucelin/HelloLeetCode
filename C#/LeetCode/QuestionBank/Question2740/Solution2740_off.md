### [找出分区值](https://leetcode.cn/problems/find-the-value-of-the-partition/solutions/2844234/zhao-chu-fen-qu-zhi-by-leetcode-solution-77zg/)

#### 方法一：排序

令 $n$ 为数组 $nums$ 的元素数目。由题意可知，分区值必定为数组 $nums$ 的两个不同元素的绝对差，因此我们可以将数组从小到大进行排序，那么分区值的理论最小值必定为排序后数组相邻元素绝对差的最小值。假设理论最小值对应的两个相邻元素分别为 $nums[i]$ 和 $nums[i+1]$，那么我们可以将区间 $[0,i]$ 的元素分到 $nums1$，将区间 $[i+1,n-1]$ 的元素分到 $nums2$，那么理论分区最小值 $\vert nums[i]-nums[i+1] \vert$ 就是实际分区最小值。

根据以上分析，我们只需要将数组从小到大进行排序，然后求得数组相邻元素绝对差最小值即可。

```C++
class Solution {
public:
    int findValueOfPartition(vector<int>& nums) {
        sort(nums.begin(), nums.end());
        int res = INT_MAX;
        for (int i = 1; i < nums.size(); i++) {
            res = min(res, nums[i] - nums[i - 1]);
        }
        return res;
    }
};
```

```Go
func findValueOfPartition(nums []int) int {
    sort.Ints(nums)
    res := math.MaxInt
    for i := 1; i < len(nums); i++ {
        res = min(res, nums[i] - nums[i - 1])
    }
    return res
}
```

```Python
class Solution:
    def findValueOfPartition(self, nums: List[int]) -> int:
        nums.sort()
        res = inf
        for i in range(1, len(nums)):
            res = min(res, nums[i] - nums[i - 1])
        return res
```

```C
int cmp(const void *p1, const void *p2) {
    return *(const int *)p1 - *(const int *)p2;
}

int findValueOfPartition(int *nums, int numsSize){
    qsort(nums, numsSize, sizeof(int), cmp);
    int res = INT_MAX;
    for (int i = 1; i < numsSize; i++) {
        res = fmin(res, nums[i] - nums[i - 1]);
    }
    return res;
}
```

```Java
class Solution {
    public int findValueOfPartition(int[] nums) {
        Arrays.sort(nums);
        int res = Integer.MAX_VALUE;
        for (int i = 1; i < nums.length; i++) {
            res = Math.min(res, nums[i] - nums[i - 1]);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int FindValueOfPartition(int[] nums) {
        Array.Sort(nums);
        int res = int.MaxValue;
        for (int i = 1; i < nums.Length; i++) {
            res = Math.Min(res, nums[i] - nums[i - 1]);
        }
        return res;
    }
}
```

```JavaScript
var findValueOfPartition = function(nums) {
    nums.sort((x, y) => x - y);
    let res = Infinity;
    for (let i = 1; i < nums.length; i++) {
        res = Math.min(res, nums[i] - nums[i - 1]);
    }
    return res;
};
```

```TypeScript
var findValueOfPartition = function(nums) {
    nums.sort((x, y) => x - y);
    let res = Infinity;
    for (let i = 1; i < nums.length; i++) {
        res = Math.min(res, nums[i] - nums[i - 1]);
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn find_value_of_partition(mut nums: Vec<i32>) -> i32 {
        nums.sort();
        let mut res: i32 = 0x3f3f3f3f;
        for i in 1..nums.len() {
            res = std::cmp::min(res, nums[i] - nums[i - 1]);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 是 $nums$ 的长度。排序需要 $O(nlogn)$，遍历需要 $O(n)$。
- 空间复杂度：$O(logn)$。排序需要 $O(logn)$ 的栈空间（与排序算法有关）。
