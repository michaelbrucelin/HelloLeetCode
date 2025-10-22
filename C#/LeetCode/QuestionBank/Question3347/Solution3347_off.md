### [执行操作后元素的最高频率 II](https://leetcode.cn/problems/maximum-frequency-of-an-element-after-performing-operations-ii/solutions/3803631/zhi-xing-cao-zuo-hou-yuan-su-de-zui-gao-n4uko/)

#### 方法一：排序 + 枚举 + 二分查找

前置题目：[「3346. 执行操作后元素的最高频率 I」](https://leetcode.cn/problems/maximum-frequency-of-an-element-after-performing-operations-i/)。请确保已经理解并掌握了前置题目中的方法。

本题是前置题目的数据强化版本，将 $k$ 和 $nums[i]$ 的范围从 $1e5$ 变为了 $1e9$，因此不能再如[「3346. 执行操作后元素的最高频率 I」](https://leetcode.cn/problems/maximum-frequency-of-an-element-after-performing-operations-i/)中一样直接将 $[nums[i]_{min}, nums[i]_{max}]$ 作为枚举区间。

仍然考虑枚举 $m_i$ 作为目标众数，那么考虑前置题目中**最多能变成 $m_i$ 的元素个数 $f_i$** 的计算公式：

$$f_i=min(r-l+1,numOperations+count_i)$$

由于在枚举过程中 $numOperations$ 为常数，而**如果 $m_i$ 不在 $nums$ 中**（这正是我们无法直接枚举的原因）则 $count_i$ 恒为 $0$，显然此时 $f_i$ 的值**只取决于 $l$ 和 r**，换而言之，只取决于这个 $m_i$ 对应的 $nums$ 的上下界元素是否一致。

那么对于 $l$ 和 $r$ 相同的那些 $m_i$，是否可以只枚举一次？

考虑单侧情况，例如只考虑 $m_i$ 对应的 $r_i$。$r_i$ 的含义是：在排序后的 $nums$ 中，最后一个小于等于 $m_i+k$ 的元素的下标。

让我们假设 $m_i+k$ 的值恰好是 $nums[r_i]$。且 $nums[r_i]$ 的下一个元素 $nums[r_i+1]$ 的值是 $m_j+k$，即另一个 $m_j$ 对应的元素，那么显然有以下推论：

对于任意 $m_k\in [m_i,m_j)$ 有:

$$m_i+k\le m_k+k<m_j+k$$

又因为 $m_i+k=nums[r_i],m_j+k=nums[r_i+1]:$

$$nums[r_i]\le m_k+k<nums[r_i+1]$$

即:

$$nums[r_i]-k\le m_k<nums[r_i+1]-k$$

这意味着只考虑 $r$ 变化的情况下，对于任意 $m_k\in [nums[r_i]-k,nums[r_i+1]-k)$ 我们只需要统计一次答案，因为这些 $m_k$ 对应的右边界全都是 $r_i$。也就是对于任意 $nums[i]-k$，若其处于 $[nums[i]_{min}$，$nums[i]_{max]}$ 这个区间，且不在 $nums$ 中，则加入枚举值候选。同理，我们还需要将满足条件的 $nums[i]+k$ 加入候选。

上面这段内容还有一种更加通俗的理解方式：将 $l$ 和 $r$ 想象一个滑动窗口，它的中点是 $m_i$，窗口的右边界 $m_i+k$ 随着 $m_i$ 增加而右移，每当窗口的右边界越过 $nums$ 中的一个数，$r_i$ 会增加 $1$。同理，每当窗口的左边界离开 $nums$ 中的一个数，则 $l_i$ 会增加 $1$。而上面我们已经分析过，只有当 $l$ 和 $r$ 变化时，这些不在 $nums$ 中的 $m_i$ 对答案的贡献才会发生变化。因此我们只在滑动窗口处于临界情况时统计一次答案，就能保证计算到所有可能的 $m_i$。

综上所述，对于每一个 $nums[i]$ 只需要枚举 $nums[i]$，$nums[i]-k$ 和 $nums[i]+k$ 即可。

```C++
class Solution {
public:
    int maxFrequency(vector<int>& nums, int k, int numOperations) {
        sort(nums.begin(), nums.end());
        int ans = 0;
        unordered_map<int, int> numCount;
        set<int> modes;

        auto addMode = [&](int value) {
            modes.insert(value);
            if (value - k >= nums.front()) {
                modes.insert(value - k);
            }
            if (value + k <= nums.back()) {
                modes.insert(value + k);
            }
        };

        int lastNumIndex = 0;
        for (int i = 0; i < nums.size(); ++i) {
            if (nums[i] != nums[lastNumIndex]) {
                numCount[nums[lastNumIndex]] = i - lastNumIndex;
                ans = max(ans, i - lastNumIndex);
                addMode(nums[lastNumIndex]);
                lastNumIndex = i;
            }
        }

        numCount[nums[lastNumIndex]] = nums.size() - lastNumIndex;
        ans = max(ans, (int)nums.size() - lastNumIndex);
        addMode(nums[lastNumIndex]);

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

        for (int mode : modes) {
            int l = leftBound(mode - k);
            int r = rightBound(mode + k);

            int tempAns;
            if (numCount.count(mode)) {
                tempAns = min(r - l + 1, numCount[mode] + numOperations);
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
        Set<Integer> modes = new TreeSet<>();
        
        Consumer<Integer> addMode = (value) -> {
            modes.add(value);
            if (value - k >= nums[0]) {
                modes.add(value - k);
            }
            if (value + k <= nums[nums.length - 1]) {
                modes.add(value + k);
            }
        };
        
        int lastNumIndex = 0;
        for (int i = 0; i < nums.length; ++i) {
            if (nums[i] != nums[lastNumIndex]) {
                numCount.put(nums[lastNumIndex], i - lastNumIndex);
                ans = Math.max(ans, i - lastNumIndex);
                addMode.accept(nums[lastNumIndex]);
                lastNumIndex = i;
            }
        }
        
        numCount.put(nums[lastNumIndex], nums.length - lastNumIndex);
        ans = Math.max(ans, nums.length - lastNumIndex);
        addMode.accept(nums[lastNumIndex]);
        
        IntUnaryOperator leftBound = (value) -> {
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
        };
        
        IntUnaryOperator rightBound = (value) -> {
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
        };
        
        for (int mode : modes) {
            int l = leftBound.applyAsInt(mode - k);
            int r = rightBound.applyAsInt(mode + k);
            int tempAns;
            if (numCount.containsKey(mode)) {
                tempAns = Math.min(r - l + 1, numCount.get(mode) + numOperations);
            } else {
                tempAns = Math.min(r - l + 1, numOperations);
            }
            ans = Math.max(ans, tempAns);
        }
        
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxFrequency(int[] nums, int k, int numOperations) {
        Array.Sort(nums);
        
        int ans = 0;
        Dictionary<int, int> numCount = new Dictionary<int, int>();
        SortedSet<int> modes = new SortedSet<int>();
        
        Action<int> addMode = (value) => {
            modes.Add(value);
            if (value - k >= nums[0]) {
                modes.Add(value - k);
            }
            if (value + k <= nums[nums.Length - 1]) {
                modes.Add(value + k);
            }
        };
        
        int lastNumIndex = 0;
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] != nums[lastNumIndex]) {
                numCount[nums[lastNumIndex]] = i - lastNumIndex;
                ans = Math.Max(ans, i - lastNumIndex);
                addMode(nums[lastNumIndex]);
                lastNumIndex = i;
            }
        }
        
        numCount[nums[lastNumIndex]] = nums.Length - lastNumIndex;
        ans = Math.Max(ans, nums.Length - lastNumIndex);
        addMode(nums[lastNumIndex]);
        
        Func<int, int> leftBound = (value) => {
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
        };
        
        Func<int, int> rightBound = (value) => {
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
        };
        
        foreach (int mode in modes) {
            int l = leftBound(mode - k);
            int r = rightBound(mode + k);
            int tempAns;
            if (numCount.ContainsKey(mode)) {
                tempAns = Math.Min(r - l + 1, numCount[mode] + numOperations);
            } else {
                tempAns = Math.Min(r - l + 1, numOperations);
            }
            ans = Math.Max(ans, tempAns);
        }
        
        return ans;
    }
}
```

```Go
func maxFrequency(nums []int, k int, numOperations int) int {
    sort.Ints(nums)
    ans := 0
    numCount := make(map[int]int)
    modes := make(map[int]bool)
    
    addMode := func(value int) {
        modes[value] = true
        if value - k >= nums[0] {
            modes[value - k] = true
        }
        if value + k <= nums[len(nums)-1] {
            modes[value + k] = true
        }
    }
    
    lastNumIndex := 0
    for i := 0; i < len(nums); i++ {
        if nums[i] != nums[lastNumIndex] {
            numCount[nums[lastNumIndex]] = i - lastNumIndex
            if i - lastNumIndex > ans {
                ans = i - lastNumIndex
            }
            addMode(nums[lastNumIndex])
            lastNumIndex = i
        }
    }
    
    numCount[nums[lastNumIndex]] = len(nums) - lastNumIndex
    if len(nums) - lastNumIndex > ans {
        ans = len(nums) - lastNumIndex
    }
    addMode(nums[lastNumIndex])
    
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
    
    uniqueModes := make([]int, 0, len(modes))
    for mode := range modes {
        uniqueModes = append(uniqueModes, mode)
    }
    sort.Ints(uniqueModes)
    
    for _, mode := range uniqueModes {
        l := leftBound(mode - k)
        r := rightBound(mode + k)
        var tempAns int
        if count, exists := numCount[mode]; exists {
            tempAns = min(r - l + 1, count + numOperations)
        } else {
            tempAns = min(r - l + 1, numOperations)
        }
        if tempAns > ans {
            ans = tempAns
        }
    }
    
    return ans
}
```

```Python
class Solution:
    def maxFrequency(self, nums: List[int], k: int, numOperations: int) -> int:
        nums.sort()
        ans = 0
        num_count = defaultdict(int)
        modes = set()

        def add_mode(value):
            modes.add(value)
            if value - k >= nums[0]:
                modes.add(value - k)
            if value + k <= nums[-1]:
                modes.add(value + k)

        last_num_index = 0
        for i in range(len(nums)):
            if nums[i] != nums[last_num_index]:
                num_count[nums[last_num_index]] = i - last_num_index
                ans = max(ans, i - last_num_index)
                add_mode(nums[last_num_index])
                last_num_index = i

        num_count[nums[last_num_index]] = len(nums) - last_num_index
        ans = max(ans, len(nums) - last_num_index)
        add_mode(nums[last_num_index])

        for mode in sorted(modes):
            l = bisect.bisect_left(nums, mode - k)
            r = bisect.bisect_right(nums, mode + k) - 1
            if mode in num_count:
                temp_ans = min(r - l + 1, num_count[mode] + numOperations)
            else:
                temp_ans = min(r - l + 1, numOperations)
            ans = max(ans, temp_ans)
        
        return ans
```

```C
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

int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

void addMode(int *nums, int numsSize, int k, HashItem **modes, int value) {
    hashAddItem(modes, value, 1);
    if (value - k >= nums[0]) {
        hashAddItem(modes, value - k, 1);
    }
    if (value + k <= nums[numsSize - 1]) {
        hashAddItem(modes, value + k, 1);
    }
}

int leftBound(int *nums, int numsSize, int value) {
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

int rightBound(int *nums, int numsSize, int value) {
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

int maxFrequency(int* nums, int numsSize, int k, int numOperations) {
    qsort(nums, numsSize, sizeof(int), compare);
    int ans = 0;
    HashItem *numCount = NULL;
    HashItem *modes = NULL;
    
    
    int lastNumIndex = 0;
    for (int i = 0; i < numsSize; ++i) {
        if (nums[i] != nums[lastNumIndex]) {
            hashSetItem(&numCount, nums[lastNumIndex], i - lastNumIndex);
            if (i - lastNumIndex > ans) {
                ans = i - lastNumIndex;
            }
            addMode(nums, numsSize, k, &modes, nums[lastNumIndex]);
            lastNumIndex = i;
        }
    }
    
    hashSetItem(&numCount, nums[lastNumIndex], numsSize - lastNumIndex);
    if (numsSize - lastNumIndex > ans) {
        ans = numsSize - lastNumIndex;
    }
    addMode(nums, numsSize, k, &modes, nums[lastNumIndex]);
    
    int modesSize = HASH_COUNT(modes);
    int *sortModes = (int *)malloc(sizeof(int) * modesSize);
    int pos = 0;
    for (HashItem *pEntry = modes; pEntry; pEntry = pEntry->hh.next) {
        sortModes[pos++] = pEntry->key;
    }
    qsort(sortModes, modesSize, sizeof(int), compare);

    for (int i = 0; i < modesSize; i++) {
        int mode = sortModes[i];
        int l = leftBound(nums, numsSize, mode - k);
        int r = rightBound(nums, numsSize, mode + k);
        int tempAns;
        if (hashFindItem(&numCount, mode)) {
            int count = hashGetItem(&numCount, mode, 0);
            tempAns = fmin(r - l + 1, count + numOperations);
        } else {
            tempAns = fmin(r - l + 1, numOperations);
        }
        if (tempAns > ans) {
            ans = tempAns;
        }
    }
    
    hashFree(&numCount);
    hashFree(&modes);
    free(sortModes);
    return ans;
}
```

```JavaScript
var maxFrequency = function (nums, k, numOperations) {
    nums.sort((a, b) => a - b);

    let ans = 0;
    const numCount = new Map();
    const modes = new Set();

    const addMode = (value) => {
        modes.add(value);
        if (value - k >= nums.at(0)) {
            modes.add(value - k);
        }

        if (value + k <= nums.at(-1)) {
            modes.add(value + k);
        }
    };

    let lastNumIndex = 0;
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] !== nums[lastNumIndex]) {
            numCount.set(nums[lastNumIndex], i - lastNumIndex);
            ans = Math.max(ans, i - lastNumIndex);
            addMode(nums[lastNumIndex]);

            lastNumIndex = i;
        }
    }

    numCount.set(nums[lastNumIndex], nums.length - lastNumIndex);
    ans = Math.max(ans, nums.length - lastNumIndex);
    addMode(nums[lastNumIndex]);

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

    for (const mode of modes) {
        const [l, r] = [leftBound(mode - k), rightBound(mode + k)];

        let tempAns;

        if (numCount.has(mode)) {
            tempAns = Math.min(r - l + 1, numCount.get(mode) + numOperations);
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
    const modes: Set<number> = new Set();

    const addMode = (value: number) => {
        modes.add(value);
        if (value - k >= nums.at(0)!) {
            modes.add(value - k);
        }

        if (value + k <= nums.at(-1)!) {
            modes.add(value + k);
        }
    };

    let lastNumIndex = 0;
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] !== nums[lastNumIndex]) {
            numCount.set(nums[lastNumIndex], i - lastNumIndex);
            ans = Math.max(ans, i - lastNumIndex);
            addMode(nums[lastNumIndex]);

            lastNumIndex = i;
        }
    }

    numCount.set(nums[lastNumIndex], nums.length - lastNumIndex);
    ans = Math.max(ans, nums.length - lastNumIndex);
    addMode(nums[lastNumIndex]);

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

    for (const mode of modes) {
        const [l, r] = [leftBound(mode - k), rightBound(mode + k)];

        let tempAns: number;

        if (numCount.has(mode)) {
            tempAns = Math.min(r - l + 1, numCount.get(mode)! + numOperations);
        } else {
            tempAns = Math.min(r - l + 1, numOperations);
        }

        ans = Math.max(ans, tempAns);
    }

    return ans;
}
```

```Rust
use std::collections::{HashMap, HashSet};
use std::cmp;

impl Solution {
    pub fn max_frequency(nums: Vec<i32>, k: i32, num_operations: i32) -> i32 {
        let mut nums = nums;
        nums.sort();
        
        let mut ans = 0;
        let mut num_count = HashMap::new();
        let mut modes = HashSet::new();
        
        let mut add_mode = |value: i32| {
            modes.insert(value);
            if value - k >= nums[0] {
                modes.insert(value - k);
            }
            if value + k <= nums[nums.len() - 1] {
                modes.insert(value + k);
            }
        };
        
        let mut last_num_index = 0;
        for i in 0..nums.len() {
            if nums[i] != nums[last_num_index] {
                num_count.insert(nums[last_num_index], i - last_num_index);
                ans = cmp::max(ans, (i - last_num_index) as i32);
                add_mode(nums[last_num_index]);
                last_num_index = i;
            }
        }
        
        num_count.insert(nums[last_num_index], nums.len() - last_num_index);
        ans = cmp::max(ans, (nums.len() - last_num_index) as i32);
        add_mode(nums[last_num_index]);
        
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
        
        let mut sorted_modes: Vec<i32> = modes.into_iter().collect();
        sorted_modes.sort();
        
        for mode in sorted_modes {
            let l = left_bound(mode - k);
            let r = right_bound(mode + k);
            let temp_ans = if let Some(&count) = num_count.get(&mode) {
                cmp::min(r - l + 1, count + num_operations as usize)
            } else {
                cmp::min(r - l + 1, num_operations as usize)
            };
            ans = cmp::max(ans, temp_ans as i32);
        }
        
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：设 $n$ 为 $nums$ 的长度，排序需要 $O(n\log n)$，预处理需要 $O(n)$，枚举众数需要 $O(n\log n)$，总时间复杂度为 $O(n\log n)$。
- 空间复杂度：$O(n)$。
