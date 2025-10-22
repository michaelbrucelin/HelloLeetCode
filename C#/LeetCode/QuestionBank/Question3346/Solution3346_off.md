### [执行操作后元素的最高频率 I](https://leetcode.cn/problems/maximum-frequency-of-an-element-after-performing-operations-i/solutions/3803630/zhi-xing-cao-zuo-hou-yuan-su-de-zui-gao-lk58w/)

#### 方法一：排序 + 枚举 + 二分查找

首先处理约束条件 $numOperations$。虽然题意要求**恰好**操作 $numOperations$ 次，但由于**可以选定若干个元素加 0** 且 $numOperations$ 小于 $nums$ 的长度，这实际上意味着可以**至多**选择 $numOperations$ 个元素，使它们在 $[-k,k]$ 范围内调整。

考虑枚举目标众数。设 $nums$ 的最小值和最大值分别为 $num_{min}$，$num_{max}$，显然有枚举区间 $[num_{min}, num_{max}]$。

假设对于每一个 $m_i$，都能算出最多有 $f_i$ 个数能变为 $m_i$，那么将 $f_i$ 作为 $anstemp$ 去更新全局 $ans$，由于答案一定存在于某个 $m_i$ 中，此时正确性是显然的。

下面考虑如何计算 $f_i$。

对于每一个 $m_i$，首先考虑约束条件 $k$，易得只有 $[m_i-k,m_i+k]$ 这个范围内的数才能变成 $m_i$，若对 $nums$ 排序，很容易通过二分查找找到 $m_i-k$ 和 $m_i+k$ 在 $nums$ 对应的下界元素（第一个大于等于 $m_i-k$ 的元素，下标记为 $l$）和上界元素（最后一个小于等于 $m_i+k$ 的元素，下标记为 $r$）。

这意味着任意 $nums[i],i\in [l,r]$ 都有机会消耗一次操作变为 $m_i$。为了满足 $numOperations$ 的约束，同时使这个区间内的数尽可能多的变为 $m_i$，$f_i$ 的值应该是区间长度和 $numOperations$ 的较小值，即 $f_i=m_in(r-l+1,numOperations)$。

还有最后一件事情需要考虑：如果我们枚举的 $m_i$ 是 $nums$ 中的某个数，那么不应该在这些数上浪费操作次数。因此我们还需要预处理出 $nums$ 中每个数的出现次数。在最后计算 $f_i$ 的时候加上它。设某个 $m_i$ 的出现次数为 $count_i$，$f_i$ 最终的计算方法为 $f_i=min(r-l+1,numOperations+count_i)$。

```C++
class Solution {
public:
    int maxFrequency(vector<int>& nums, int k, int numOperations) {
        sort(nums.begin(), nums.end());

        int ans = 0;
        unordered_map<int, int> numCount;

        int lastNumIndex = 0;
        for (int i = 0; i < nums.size(); ++i) {
            if (nums[i] != nums[lastNumIndex]) {
                numCount[nums[lastNumIndex]] = i - lastNumIndex;
                ans = max(ans, i - lastNumIndex);
                lastNumIndex = i;
            }
        }

        numCount[nums[lastNumIndex]] = nums.size() - lastNumIndex;
        ans = max(ans, (int)nums.size() - lastNumIndex);

        auto leftBound = [&](int value) {
            int left = 0, right = nums.size() - 1;
            while (left < right) {
                int mid = (left + right) / 2;
                if (nums[mid] < value) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            return left;
        };

        auto rightBound = [&](int value) {
            int left = 0, right = nums.size() - 1;
            while (left < right) {
                int mid = (left + right + 1) / 2;
                if (nums[mid] > value) {
                    right = mid - 1;
                } else {
                    left = mid;
                }
            }
            return left;
        };

        for (int i = nums.front(); i <= nums.back(); i++) {
            int l = leftBound(i - k);
            int r = rightBound(i + k);

            int tempAns;
            if (numCount.count(i)) {
                tempAns = min(r - l + 1, numCount[i] + numOperations);
            } else {
                tempAns = min(r - l + 1, numOperations);
            }
            ans = max(ans, tempAns);
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int maxFrequency(int[] nums, int k, int numOperations) {
        Arrays.sort(nums);
        
        int ans = 0;
        Map<Integer, Integer> numCount = new HashMap<>();
        
        int lastNumIndex = 0;
        for (int i = 0; i < nums.length; ++i) {
            if (nums[i] != nums[lastNumIndex]) {
                numCount.put(nums[lastNumIndex], i - lastNumIndex);
                ans = Math.max(ans, i - lastNumIndex);
                lastNumIndex = i;
            }
        }
        
        numCount.put(nums[lastNumIndex], nums.length - lastNumIndex);
        ans = Math.max(ans, nums.length - lastNumIndex);
        
        for (int i = nums[0]; i <= nums[nums.length - 1]; i++) {
            int l = leftBound(nums, i - k);
            int r = rightBound(nums, i + k);
            int tempAns;
            if (numCount.containsKey(i)) {
                tempAns = Math.min(r - l + 1, numCount.get(i) + numOperations);
            } else {
                tempAns = Math.min(r - l + 1, numOperations);
            }
            ans = Math.max(ans, tempAns);
        }
        
        return ans;
    }
    
    private int leftBound(int[] nums, int value) {
        int left = 0, right = nums.length - 1;
        while (left < right) {
            int mid = (left + right) / 2;
            if (nums[mid] < value) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
    
    private int rightBound(int[] nums, int value) {
        int left = 0, right = nums.length - 1;
        while (left < right) {
            int mid = (left + right + 1) / 2;
            if (nums[mid] > value) {
                right = mid - 1;
            } else {
                left = mid;
            }
        }
        return left;
    }
}
```

```CSharp
public class Solution {
    public int MaxFrequency(int[] nums, int k, int numOperations) {
        Array.Sort(nums);
        
        int ans = 0;
        Dictionary<int, int> numCount = new Dictionary<int, int>();
        
        int lastNumIndex = 0;
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] != nums[lastNumIndex]) {
                numCount[nums[lastNumIndex]] = i - lastNumIndex;
                ans = Math.Max(ans, i - lastNumIndex);
                lastNumIndex = i;
            }
        }
        
        numCount[nums[lastNumIndex]] = nums.Length - lastNumIndex;
        ans = Math.Max(ans, nums.Length - lastNumIndex);
        
        for (int i = nums[0]; i <= nums[nums.Length - 1]; i++) {
            int l = LeftBound(nums, i - k);
            int r = RightBound(nums, i + k);
            
            int tempAns;
            if (numCount.ContainsKey(i)) {
                tempAns = Math.Min(r - l + 1, numCount[i] + numOperations);
            } else {
                tempAns = Math.Min(r - l + 1, numOperations);
            }
            ans = Math.Max(ans, tempAns);
        }
        
        return ans;
    }
    
    private int LeftBound(int[] nums, int value) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            int mid = (left + right) / 2;
            if (nums[mid] < value) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
    
    private int RightBound(int[] nums, int value) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            int mid = (left + right + 1) / 2;
            if (nums[mid] > value) {
                right = mid - 1;
            } else {
                left = mid;
            }
        }
        return left;
    }
}
```

```Go
func maxFrequency(nums []int, k int, numOperations int) int {
    sort.Ints(nums)
    ans := 0
    numCount := make(map[int]int)
    
    lastNumIndex := 0
    for i := 0; i < len(nums); i++ {
        if nums[i] != nums[lastNumIndex] {
            numCount[nums[lastNumIndex]] = i - lastNumIndex
            ans = max(ans, i - lastNumIndex)
            lastNumIndex = i
        }
    }
    
    numCount[nums[lastNumIndex]] = len(nums) - lastNumIndex
    ans = max(ans, len(nums) - lastNumIndex)
    
    leftBound := func(value int) int {
        left, right := 0, len(nums)-1
        for left < right {
            mid := (left + right) / 2
            if nums[mid] < value {
                left = mid + 1
            } else {
                right = mid
            }
        }
        return left
    }
    
    rightBound := func(value int) int {
        left, right := 0, len(nums)-1
        for left < right {
            mid := (left + right + 1) / 2
            if nums[mid] > value {
                right = mid - 1
            } else {
                left = mid
            }
        }
        return left
    }
    
    for i := nums[0]; i <= nums[len(nums)-1]; i++ {
        l := leftBound(i - k)
        r := rightBound(i + k)
        
        tempAns := 0
        if count, exists := numCount[i]; exists {
            tempAns = min(r - l + 1, count + numOperations)
        } else {
            tempAns = min(r - l + 1, numOperations)
        }
        ans = max(ans, tempAns)
    }
    
    return ans
}
```

```Python
class Solution:
    def maxFrequency(self, nums: List[int], k: int, numOperations: int) -> int:
        nums.sort()
        ans = 0
        num_count = {}
        last_num_index = 0
        for i in range(len(nums)):
            if nums[i] != nums[last_num_index]:
                num_count[nums[last_num_index]] = i - last_num_index
                ans = max(ans, i - last_num_index)
                last_num_index = i

        num_count[nums[last_num_index]] = len(nums) - last_num_index
        ans = max(ans, len(nums) - last_num_index)

        for i in range(nums[0], nums[-1] + 1):
            l = bisect.bisect_left(nums, i - k)
            r = bisect.bisect_right(nums, i + k) - 1
            if i in num_count:
                temp_ans = min(r - l + 1, num_count[i] + numOperations)
            else:
                temp_ans = min(r - l + 1, numOperations)
            ans = max(ans, temp_ans)

        return ans
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int leftBound(int* nums, int numsSize, int value) {
    int left = 0, right = numsSize - 1;
    while (left < right) {
        int mid = (left + right) / 2;
        if (nums[mid] < value) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

int rightBound(int* nums, int numsSize, int value) {
    int left = 0, right = numsSize - 1;
    while (left < right) {
        int mid = (left + right + 1) / 2;
        if (nums[mid] > value) {
            right = mid - 1;
        } else {
            left = mid;
        }
    }
    return left;
}

typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

int maxFrequency(int* nums, int numsSize, int k, int numOperations) {
    qsort(nums, numsSize, sizeof(int), compare);
    int ans = 0;
    HashItem *numCount = NULL;        
    int lastNumIndex = 0;
    for (int i = 0; i < numsSize; ++i) {
        if (nums[i] != nums[lastNumIndex]) {
            hashSetItem(&numCount, nums[lastNumIndex], i - lastNumIndex);
            ans = fmax(ans, i - lastNumIndex);
            lastNumIndex = i;
        }
    }
    hashSetItem(&numCount, nums[lastNumIndex], numsSize - lastNumIndex);
    ans = fmax(ans, numsSize - lastNumIndex);
    for (int i = nums[0]; i <= nums[numsSize - 1]; i++) {
        int l = leftBound(nums, numsSize, i - k);
        int r = rightBound(nums, numsSize, i + k);
        int tempAns;
        if (hashFindItem(&numCount, i)) {
            tempAns = fmin(r - l + 1, hashGetItem(&numCount, i, 0) + numOperations);
        } else {
            tempAns = fmin(r - l + 1, numOperations);
        }
        ans = fmax(ans, tempAns);
    }
    hashFree(&numCount);
    return ans;
}
```

```JavaScript
var maxFrequency = function (nums, k, numOperations) {
    nums.sort((a, b) => a - b);

    let ans = 0;
    const numCount = new Map();

    let lastNumIndex = 0;
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] !== nums[lastNumIndex]) {
            numCount.set(nums[lastNumIndex], i - lastNumIndex);
            ans = Math.max(ans, i - lastNumIndex);

            lastNumIndex = i;
        }
    }

    numCount.set(nums[lastNumIndex], nums.length - lastNumIndex);
    ans = Math.max(ans, nums.length - lastNumIndex);

    const leftBound = (value) => {
        let left = 0;
        let right = nums.length - 1;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (nums[mid] < value) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    const rightBound = (value) => {
        let left = 0;
        let right = nums.length - 1;
        while (left < right) {
            const mid = Math.floor((left + right + 1) / 2);
            if (nums[mid] > value) {
                right = mid - 1;
            } else {
                left = mid;
            }
        }
        return left;
    };

    for (let i = nums.at(0); i <= nums.at(-1); i++) {
        const [l, r] = [leftBound(i - k), rightBound(i + k)];

        let tempAns;

        if (numCount.has(i)) {
            tempAns = Math.min(r - l + 1, numCount.get(i) + numOperations);
        } else {
            tempAns = Math.min(r - l + 1, numOperations);
        }

        ans = Math.max(ans, tempAns);
    }

    return ans;
};
```

```TypeScript
function maxFrequency(nums: number[], k: number, numOperations: number): number {
    nums.sort((a, b) => a - b);

    let ans = 0;
    const numCount: Map<number, number> = new Map();

    let lastNumIndex = 0;
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] !== nums[lastNumIndex]) {
            numCount.set(nums[lastNumIndex], i - lastNumIndex);
            ans = Math.max(ans, i - lastNumIndex);
            lastNumIndex = i;
        }
    }

    numCount.set(nums[lastNumIndex], nums.length - lastNumIndex);
    ans = Math.max(ans, nums.length - lastNumIndex);

    const leftBound = (value: number) => {
        let left = 0;
        let right = nums.length - 1;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (nums[mid] < value) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    const rightBound = (value: number) => {
        let left = 0;
        let right = nums.length - 1;
        while (left < right) {
            const mid = Math.floor((left + right + 1) / 2);
            if (nums[mid] > value) {
                right = mid - 1;
            } else {
                left = mid;
            }
        }
        return left;
    };

    for (let i = nums.at(0)!; i <= nums.at(-1)!; i++) {
        const [l, r] = [leftBound(i - k), rightBound(i + k)];

        let tempAns;

        if (numCount.has(i)) {
            tempAns = Math.min(r - l + 1, numCount.get(i)! + numOperations);
        } else {
            tempAns = Math.min(r - l + 1, numOperations);
        }

        ans = Math.max(ans, tempAns);
    }

    return ans;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn max_frequency(nums: Vec<i32>, k: i32, num_operations: i32) -> i32 {
        let mut nums = nums;
        nums.sort();
        
        let mut ans = 0;
        let mut num_count = HashMap::new();
        
        let mut last_num_index = 0;
        for i in 0..nums.len() {
            if nums[i] != nums[last_num_index] {
                num_count.insert(nums[last_num_index], (i - last_num_index) as i32);
                ans = ans.max((i - last_num_index) as i32);
                last_num_index = i;
            }
        }
        
        num_count.insert(nums[last_num_index], (nums.len() - last_num_index) as i32);
        ans = ans.max((nums.len() - last_num_index) as i32);
        
        let left_bound = |value: i32| -> usize {
            let mut left = 0;
            let mut right = nums.len() - 1;
            while left < right {
                let mid = (left + right) / 2;
                if nums[mid] < value {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            left
        };
        
        let right_bound = |value: i32| -> usize {
            let mut left = 0;
            let mut right = nums.len() - 1;
            while left < right {
                let mid = (left + right + 1) / 2;
                if nums[mid] > value {
                    right = mid - 1;
                } else {
                    left = mid;
                }
            }
            left
        };
        
        for i in nums[0]..=nums[nums.len() - 1] {
            let l = left_bound(i - k);
            let r = right_bound(i + k);
            
            let temp_ans = if let Some(&count) = num_count.get(&i) {
                (r - l + 1).min(count as usize + num_operations as usize)
            } else {
                (r - l + 1).min(num_operations as usize)
            };
            ans = ans.max(temp_ans as i32);
        }
        
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：设 $n$ 为 $nums$ 的长度，且 $0\le nums[i]\le k$。排序需要 $O(n\log n)$，预处理需要 $O(n)$，枚举众数需要 $O(k\log n)$，总时间复杂度为 $O(max(n\log n,k\log n))$。
- 空间复杂度：$O(n)$。
