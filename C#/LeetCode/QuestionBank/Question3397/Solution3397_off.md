### [执行操作后不同元素的最大数量](https://leetcode.cn/problems/maximum-number-of-distinct-elements-after-operations/solutions/3801871/zhi-xing-cao-zuo-hou-bu-tong-yuan-su-de-fmhzv/)

#### 方法一：贪心

**思路与算法**

由于题目要求对数组 $nums$ 中每个元素最多执行一次操作，使得 $nums$ 中**不同元素**的数量**最大**，每次操作可以将一个在范围 $[-k,k]$ 内的整数加到该元素上。设数组 $nums$ 中最小的元素为 $minVal$，最大的元素为 $maxVal$，则整个数组执行操作后所有元素的取值范围为 $[minVal-k,maxVal+k]$。为了使的不同元素的数量尽可能多，此时我们再构造每个元素时，应当每次尽量**贪心**的寻找最小可以使用的元素，此时数组中剩余的元素就可以有更大的取值空间，即可能构造出更多的不同元素。

根据以上思路，首先将数组 $nums$ 中的元素按照从小到大进行排序，接着依次考虑每个元素：

- 首先考虑 $nums[0]$，根据贪心原则，此时元素应尽可能的小，此时操作后的元素 $a_0=nums[0]-k$；
- 接着考虑 $nums[1]$，此时 $nums[1]$ 执行操作后的取值范围为 $[nums[1]-k,nums[1]+k]$，由于执行操作后的元素要与 $a_0$ 不同，此时最小取值即为 $a_0+1$，根据贪心原则，为了使得操作后的元素应尽可能的小，此时操作后的元素 $a_1=min(max(nums[1]-k,a_0+1),nums[1]+k)$，如果操作后的元素的取值 $a_1$ 满足 $a_1>a_0$ 时，此时不同元素的数量加 $1$；
- 按照同样的思路，我们依次考虑 $nums[2],nums[3],\dots ,nums[n-1]$，每次将当前构造的元素与上一个元素进行比较，并统计最终不同元素的数量即为答案。

实际上，由于所有元素的取值范围为 $[minVal-k,maxVal+k]$，此时我们也可以每次**贪心**的寻找最大可以使用的元素，即从大到小构造每个元素，在此不再详细描述。

**代码**

```C++
class Solution {
public:
    int maxDistinctElements(vector<int>& nums, int k) {
        sort(nums.begin(), nums.end());
        int cnt = 0, prev = INT_MIN;
        for (int num : nums) {
            int curr = min(max(num - k, prev + 1), num + k);
            if (curr > prev) {
                cnt++;
                prev = curr;
            }
        }
        return cnt;
    }
};
```

```Java
class Solution {
    public int maxDistinctElements(int[] nums, int k) {
        Arrays.sort(nums);
        int cnt = 0;
        int prev = Integer.MIN_VALUE;
        for (int num : nums) {
            int curr = Math.min(Math.max(num - k, prev + 1), num + k);
            if (curr > prev) {
                cnt++;
                prev = curr;
            }
        }
        return cnt;
    }
}
```

```CSharp
public class Solution {
    public int MaxDistinctElements(int[] nums, int k) {
        Array.Sort(nums);
        int cnt = 0;
        int prev = int.MinValue;
        foreach (int num in nums) {
            int curr = Math.Min(Math.Max(num - k, prev + 1), num + k);
            if (curr > prev) {
                cnt++;
                prev = curr;
            }
        }
        return cnt;
    }
}
```

```Go
func maxDistinctElements(nums []int, k int) int {
    sort.Ints(nums)
    cnt := 0
    prev := math.MinInt32
    
    for _, num := range nums {
        curr := min(max(num-k, prev+1), num+k)
        if curr > prev {
            cnt++
            prev = curr
        }
    }
    return cnt
}
```

```Python
class Solution:
    def maxDistinctElements(self, nums: List[int], k: int) -> int:
        nums.sort()

        cnt = 0
        prev = -math.inf

        for num in nums:
            curr = min(max(num - k, prev + 1), num + k)
            if curr > prev:
                cnt += 1
                prev = curr

        return cnt

```

```C
int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int maxDistinctElements(int* nums, int numsSize, int k) {
    qsort(nums, numsSize, sizeof(int), compare);
    int cnt = 0;
    int prev = INT_MIN;
    
    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        int curr = fmin(fmax(num - k, prev + 1), num + k);
        if (curr > prev) {
            cnt++;
            prev = curr;
        }
    }
    return cnt;
}
```

```JavaScript
var maxDistinctElements = function(nums, k) {
    nums.sort((a, b) => a - b);
    let cnt = 0;
    let prev = -Number.MAX_SAFE_INTEGER;
    
    for (const num of nums) {
        const curr = Math.min(Math.max(num - k, prev + 1), num + k);
        if (curr > prev) {
            cnt++;
            prev = curr;
        }
    }
    return cnt;
};
```

```TypeScript
function maxDistinctElements(nums: number[], k: number): number {
    nums.sort((a, b) => a - b);
    let cnt = 0;
    let prev = -Number.MAX_SAFE_INTEGER;
    
    for (const num of nums) {
        const curr = Math.min(Math.max(num - k, prev + 1), num + k);
        if (curr > prev) {
            cnt++;
            prev = curr;
        }
    }
    return cnt;
}
```

```Rust
impl Solution {
    pub fn max_distinct_elements(nums: Vec<i32>, k: i32) -> i32 {
        let mut nums = nums;
        nums.sort();
        let mut cnt = 0;
        let mut prev = i32::MIN;
        
        for num in nums {
            let curr = (num - k).max(prev + 1).min(num + k);
            if curr > prev {
                cnt += 1;
                prev = curr;
            }
        }
        cnt
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 表示给定数组 $nums$ 的长度。排序需要的实际为 $O(n\log n)$，排序后还需遍历数组一次，因此总的时间复杂度为 $O(n\log n)$。
- 空间复杂度：$O(\log n)$，其中 $n$ 表示给定数组 $nums$ 的长度。排序需要调用的递归栈空间为 $O(\log n)$。
