### [使数组连续的最少操作数](https://leetcode.cn/problems/minimum-number-of-operations-to-make-array-continuous/solutions/2726967/shi-shu-zu-lian-xu-de-zui-shao-cao-zuo-s-swzt/)

#### 方法一：去重 + 排序 + 滑动窗口

##### 思路

记数组 $\textit{nums}$ 的长度为 $n$。经过若干次操作后，若数组变为连续的，那么数组的长度不会改变，仍然为 $n$，且数组最大值与最小值之差为 $n-1$，所有元素均不相同。可以反向考虑，假设最后连续的数组的最小值为 $\textit{left}$，则最大值 $right = left + n - 1$。原数组 $\textit{nums}$ 中，如果有位于 $[\textit{left}, \textit{right}]$ 中的，如果只出现一次，我们可以对其进行保留；多次出现时，我们则需要对其进行操作；不在这个区间的数字，我们也需要对其进行操作，将它们变成其他数字来对这个区间进行补足。因此，我们需要统计原数组 $\textit{nums}$ 中，位于区间 $[\textit{left}, \textit{right}]$ 内不同的数字个数 $k$，而 $n-k$ 就是我们需要进行的操作数。

接下来就是需要确定 $\textit{left}$，我们可以将原数组 $\textit{nums}$ 所有不同的数字作为 $\textit{left}$ 的候选值，分别计算出 $n-k$，然后求出最小值。这样的话，我们可以先将原数字进行去重后排序，然后利用滑动窗口。滑动窗口左端点的值作为 $\textit{left}$，然后向右扩展右端点，窗口的长度即为 $k$，求出所有可能性下最小的 $n-k$ 即可。

##### 代码

```python
class Solution:
    def minOperations(self, nums: List[int]) -> int:
        n = len(nums)
        sortedUniqueNums = sorted((set(nums)))
        res = n
        j = 0
        for i, left in enumerate(sortedUniqueNums):
            right = left + n - 1
            while j < len(sortedUniqueNums) and sortedUniqueNums[j] <= right:
                res = min(res, n - (j - i + 1))
                j += 1
        return res
```

```java
class Solution {
    public int minOperations(int[] nums) {
        int n = nums.length;
        Set<Integer> set = new HashSet<Integer>();
        for (int num : nums) {
            set.add(num);
        }
        List<Integer> sortedUniqueNums = new ArrayList<Integer>(set);
        Collections.sort(sortedUniqueNums);
        int res = n;
        int j = 0;
        for (int i = 0; i < sortedUniqueNums.size(); i++) {
            int left = sortedUniqueNums.get(i);
            int right = left + n - 1;
            while (j < sortedUniqueNums.size() && sortedUniqueNums.get(j) <= right) {
                res = Math.min(res, n - (j - i + 1));
                j++;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int MinOperations(int[] nums) {
        int n = nums.Length;
        ISet<int> set = new HashSet<int>();
        foreach (int num in nums) {
            set.Add(num);
        }
        IList<int> sortedUniqueNums = new List<int>(set);
        ((List<int>) sortedUniqueNums).Sort();
        int res = n;
        int j = 0;
        for (int i = 0; i < sortedUniqueNums.Count; i++) {
            int left = sortedUniqueNums[i];
            int right = left + n - 1;
            while (j < sortedUniqueNums.Count && sortedUniqueNums[j] <= right) {
                res = Math.Min(res, n - (j - i + 1));
                j++;
            }
        }
        return res;
    }
}
```

```c++
class Solution {
public:
    int minOperations(vector<int>& nums) {
        int n = nums.size();
        unordered_set<int> cnt(nums.begin(), nums.end());
        vector<int> sortedUniqueNums(cnt.begin(), cnt.end());
        sort(sortedUniqueNums.begin(), sortedUniqueNums.end());
        int res = n, j = 0;
        for (int i = 0; i < sortedUniqueNums.size(); i++) {
            int right = sortedUniqueNums[i] + n - 1;
            while (j < sortedUniqueNums.size() && sortedUniqueNums[j] <= right) {
                res = min(res, n - (j - i + 1));
                j++;
            }
        }            
        return res;
    }
};
```

```c
static int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int minOperations(int* nums, int numsSize) {
    qsort(nums, numsSize, sizeof(int), cmp);
    int sortedUniqueNums[numsSize];
    sortedUniqueNums[0] = nums[0];
    int pos = 1;
    for (int i = 1; i < numsSize; i++) {
        if (nums[i] != nums[i - 1]) {
            sortedUniqueNums[pos++] = nums[i];
        }
    }
    int res = numsSize, j = 0;
    for (int i = 0; i < pos; i++) {
        int right = sortedUniqueNums[i] + numsSize - 1;
        while (j < pos && sortedUniqueNums[j] <= right) {
            res = fmin(res, numsSize - (j - i + 1));
            j++;
        }
    }      

    return res;
}
```

```go
func minOperations(nums []int) int {
    n := len(nums)
    cnt := make(map[int]bool)
    for _, num := range nums {
        cnt[num] = true
    }
    sortedUniqueNums := []int{}
    for num, _ := range cnt {
        sortedUniqueNums = append(sortedUniqueNums, num)
    }
    sort.Ints(sortedUniqueNums)
    res := n
    j := 0
    for i, left := range sortedUniqueNums {
        right := left + n - 1
        for j < len(sortedUniqueNums) && sortedUniqueNums[j] <= right {
            res = min(res, n - (j - i + 1))
            j++
        }
    }
    return res
}
```

```javascript
var minOperations = function(nums) {
    const n = nums.length;
    const sortedUniqueNums = [...new Set(nums)];
    sortedUniqueNums.sort((a, b) => a - b);
    let res = n;
    let j = 0;
    for (let i = 0; i < sortedUniqueNums.length; i++) {
        const left = sortedUniqueNums[i];
        const right = left + n - 1;
        while (j < sortedUniqueNums.length && sortedUniqueNums[j] <= right) {
            res = Math.min(res, n - (j - i + 1));
            j++;
        }
    }
    return res;
};
```

```typescript
function minOperations(nums: number[]): number {
    const n: number = nums.length;
    const sortedUniqueNums: number[] = [...new Set(nums)];
    sortedUniqueNums.sort((a, b) => a - b);
    let res: number = n;
    let j: number = 0;
    for (let i: number = 0; i < sortedUniqueNums.length; i++) {
        const left: number = sortedUniqueNums[i];
        const right: number = left + n - 1;
        while (j < sortedUniqueNums.length && sortedUniqueNums[j] <= right) {
            res = Math.min(res, n - (j - i + 1));
            j++;
        }
    }
    return res;
};
```

```rust
use std::collections::HashSet;

impl Solution {
    pub fn min_operations(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let sorted_unique_nums: Vec<i32> = nums.iter().cloned().collect::<HashSet<_>>().into_iter().collect();
        let mut sorted_unique_nums = sorted_unique_nums;
        sorted_unique_nums.sort_unstable();
        let mut res = n as i32;
        let mut j = 0;
        for (i, &left) in sorted_unique_nums.iter().enumerate() {
            let right = left + n as i32 - 1;
            while j < sorted_unique_nums.len() && sorted_unique_nums[j] <= right {
                res = res.min(n as i32 - (j - i + 1) as i32);
                j += 1;
            }
        }
        res
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n \times \log{n})$，其中 $n$ 是数组 $\textit{nums}$ 的长度。排序消耗 $O(n \times \log{n})$，滑动窗口消耗 $O(n)$。
- 时间复杂度：$O(n)$，新建一个去重后排序的数组消耗 $O(n)$。
