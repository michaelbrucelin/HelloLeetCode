### [统计特殊三元组](https://leetcode.cn/problems/count-special-triplets/solutions/3848618/tong-ji-te-shu-san-yuan-zu-by-leetcode-s-f3ac/)

#### 方法一：枚举 + 计数

**思路与算法**

根据题意，容易观察到对于三元组 $(i,j,k)$ 有 $nums[i]=nums[k]$，考虑枚举两侧的数或者中间的数进行计数。

如果枚举两侧的数，例如枚举 $nums[i]$，寻找合法的 $(j,k)$，那么势必需要维护 $nums$ 数组上数与数之间的相对位置信息，这是繁琐的，且在这个数据范围限制下较难实现。

不妨换个思路，枚举中间的 $nums[j]$，此时只需要知道左右两侧分别有多少个数等于 $nums[j]\times 2$，即可计算 $nums[j]$ 对答案的贡献。

设对于当前位置左侧有 $LeftCnt$ 个满足条件的下标，右侧有 $RightCnt$ 个满足条件的下标，根据计数问题的乘法原理，它们对答案的贡献是：$LeftCnt\times RightCnt\bmod (10^9+7)$。

下面思考如何计算 $LeftCnt$ 和 $RightCnt$。

考虑使用哈希表对 $nums$ 中的元素进行计数，我们维护两个哈希表 $numCnt$ 和 $numPartialCnt$，分别代表 $nums$ 中的每个元素在**整个数组**中出现的总次数和在**当前遍历位置**下每个元素出现的次数。

我们可以提前遍历计算 $numCnt$，然后在枚举的同时更新 $numPartialCnt$。设此时需要寻找的目标值为 $t$（即两倍的 $nums[j]$），此时显然有：$LeftCnt=numPartialCnt[t],RightCnt=numCnt[t]-numPartialCnt[t]$。

最后需要注意当前位置的元素对更新 $numPartialCnt$ 的影响。因为当 $nums[j]=0$ 时，我们要寻找的三个数是相同的，因此更新 $numPartialCnt$ 的时机需要放在计算 $LeftCnt$ 之后，且在计算 $RightCnt$ 之前。

**代码**

```C++
class Solution {
public:
    int specialTriplets(vector<int>& nums) {
        const int MOD = 1e9 + 7;
        unordered_map<int, int> numCnt;
        unordered_map<int, int> numPartialCnt;

        numCnt.reserve(nums.size() * 2);
        numPartialCnt.reserve(nums.size() * 2);

        for (int v : nums) {
            numCnt[v]++;
        }

        int ans = 0;
        for (int v : nums) {
            int target = v * 2;
            int lCnt = numPartialCnt[target];
            numPartialCnt[v]++;
            int rCnt = numCnt[target] - numPartialCnt[target];
            ans = (ans + (lCnt * 1LL * rCnt % MOD)) % MOD;
        }

        return ans;
    }
};
```

```JavaScript
const MOD = 1e9 + 7;

var specialTriplets = function (nums) {
    const numCnt = new Map();
    const numPartialCnt = new Map();

    for (const v of nums) {
        numCnt.set(v, (numCnt.get(v) ?? 0) + 1);
    }

    let ans = 0;
    for (const v of nums) {
        const target = v * 2;
        const lCnt = numPartialCnt.get(target) ?? 0;

        numPartialCnt.set(v, (numPartialCnt.get(v) ?? 0) + 1);
        const rCnt = (numCnt.get(target) ?? 0) - (numPartialCnt.get(target) ?? 0);

        ans += (lCnt * rCnt) % MOD;
        ans %= MOD;
    }
    return ans;
}
```

```TypeScript
const MOD = 1e9 + 7;

function specialTriplets(nums: number[]): number {
    const numCnt = new Map<number, number>();
    const numPartialCnt = new Map<number, number>();

    for (const v of nums) {
        numCnt.set(v, (numCnt.get(v) ?? 0) + 1);
    }

    let ans = 0;
    for (const v of nums) {
        const target = v * 2;
        const lCnt = numPartialCnt.get(target) ?? 0;

        numPartialCnt.set(v, (numPartialCnt.get(v) ?? 0) + 1);
        const rCnt = (numCnt.get(target) ?? 0) - (numPartialCnt.get(target) ?? 0);

        ans += (lCnt * rCnt) % MOD;
        ans %= MOD;
    }
    return ans;
}
```

```Java
class Solution {
    public int specialTriplets(int[] nums) {
        final int MOD = 1000000007;
        Map<Integer, Integer> numCnt = new HashMap<>();
        Map<Integer, Integer> numPartialCnt = new HashMap<>();

        for (int v : nums) {
            numCnt.put(v, numCnt.getOrDefault(v, 0) + 1);
        }

        long ans = 0;
        for (int v : nums) {
            int target = v * 2;
            int lCnt = numPartialCnt.getOrDefault(target, 0);
            numPartialCnt.put(v, numPartialCnt.getOrDefault(v, 0) + 1);
            int rCnt = numCnt.getOrDefault(target, 0) - numPartialCnt.getOrDefault(target, 0);
            ans = (ans + (long) lCnt * rCnt) % MOD;
        }

        return (int) ans;
    }
}
```

```CSharp
public class Solution {
    public int SpecialTriplets(int[] nums) {
        const int MOD = 1000000007;
        Dictionary<int, int> numCnt = new Dictionary<int, int>();
        Dictionary<int, int> numPartialCnt = new Dictionary<int, int>();

        foreach (int v in nums) {
            if (numCnt.ContainsKey(v)) {
                numCnt[v]++;
            } else {
                numCnt[v] = 1;
            }
        }

        long ans = 0;
        foreach (int v in nums) {
            int target = v * 2;
            int lCnt = numPartialCnt.ContainsKey(target) ? numPartialCnt[target] : 0;
            if (numPartialCnt.ContainsKey(v)) {
                numPartialCnt[v]++;
            } else {
                numPartialCnt[v] = 1;
            }

            int totalCnt = numCnt.ContainsKey(target) ? numCnt[target] : 0;
            int partialCnt = numPartialCnt.ContainsKey(target) ? numPartialCnt[target] : 0;
            int rCnt = totalCnt - partialCnt;

            ans = (ans + (long)lCnt * rCnt) % MOD;
        }

        return (int)ans;
    }
}
```

```Go
func specialTriplets(nums []int) int {
    const MOD = 1000000007
    numCnt := make(map[int]int)
    numPartialCnt := make(map[int]int)

    for _, v := range nums {
        numCnt[v]++
    }

    ans := 0
    for _, v := range nums {
        target := v * 2
        lCnt := numPartialCnt[target]
        numPartialCnt[v]++
        rCnt := numCnt[target] - numPartialCnt[target]

        ans = (ans + lCnt * rCnt) % MOD
    }

    return ans
}
```

```Python
class Solution:
    def specialTriplets(self, nums: List[int]) -> int:
        MOD = 10**9 + 7
        num_cnt = {}
        num_partial_cnt = {}

        for v in nums:
            num_cnt[v] = num_cnt.get(v, 0) + 1

        ans = 0
        for v in nums:
            target = v * 2
            l_cnt = num_partial_cnt.get(target, 0)
            num_partial_cnt[v] = num_partial_cnt.get(v, 0) + 1
            r_cnt = num_cnt.get(target, 0) - num_partial_cnt.get(target, 0)
            ans = (ans + l_cnt * r_cnt) % MOD

        return ans
```

```C
#define MOD 1000000007

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

int specialTriplets(int* nums, int numsSize) {
    HashItem *numCnt = NULL;
    HashItem *numPartialCnt = NULL;

    for (int i = 0; i < numsSize; i++) {
        int v = nums[i];
        hashSetItem(&numCnt, v, hashGetItem(&numCnt, v, 0) + 1);
    }

    long long ans = 0;
    for (int i = 0; i < numsSize; i++) {
        int v = nums[i];
        int target = v * 2;
        int lCnt = hashGetItem(&numPartialCnt, target, 0);
        hashSetItem(&numPartialCnt, v, hashGetItem(&numPartialCnt, v, 0) + 1);
        int rCnt = hashGetItem(&numCnt, target, 0) - hashGetItem(&numPartialCnt, target, 0);
        ans = (ans + (long long)lCnt * rCnt) % MOD;
    }

    hashFree(&numCnt);
    hashFree(&numPartialCnt);
    return (int)ans;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn special_triplets(nums: Vec<i32>) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let mut num_cnt: HashMap<i32, i32> = HashMap::new();
        let mut num_partial_cnt: HashMap<i32, i32> = HashMap::new();

        for &v in &nums {
            *num_cnt.entry(v).or_insert(0) += 1;
        }

        let mut ans: i64 = 0;
        for v in nums {
            let target = v * 2;
            let l_cnt = *num_partial_cnt.get(&target).unwrap_or(&0);
            *num_partial_cnt.entry(v).or_insert(0) += 1;
            let total_cnt = *num_cnt.get(&target).unwrap_or(&0);
            let partial_cnt = *num_partial_cnt.get(&target).unwrap_or(&0);
            let r_cnt = total_cnt - partial_cnt;
            ans = (ans + l_cnt as i64 * r_cnt as i64) % MOD;
        }

        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，设 $n$ 是 $nums$ 的长度，遍历 $nums$ 需要 $O(n)$，哈希表的存取需要 $O(1)$，故总时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$，哈希表需要 $O(n)$ 的空间。

#### 方法二：枚举 + 二分查找

**思路与算法**

基本思路同方法一，区别在于建立位置索引后再利用二分查找来计算 $LeftCnt$ 和 $RightCnt$。

使用哈希表 $pos$ 建立每个元素的位置索引，将元素在 $nums$ 中出现的下标序列存入 $pos$。

由于这个下标序列的长度蕴含了对应元素出现的次数信息，故对于当前枚举的位置 $j$，只需要通过二分查找 $j$ 在目标元素的下标序列中的位置，即可计算 $LeftCnt$ 和 $RightCnt$。

**代码**

```C++
class Solution {
public:
    int specialTriplets(vector<int>& nums) {
        const int MOD = 1e9 + 7;
        unordered_map<int, vector<int>> pos;
        pos.reserve(nums.size() * 2);

        for (int i = 0; i < nums.size(); i++) {
            pos[nums[i]].push_back(i);
        }

        int ans = 0;

        for (int i = 1; i < nums.size() - 1; i++) {
            int target = nums[i] * 2LL;
            if (pos.count(target) == 0) {
                continue;
            }

            const auto& arr = pos[target];
            if (arr.size() <= 1 || arr[0] >= i) {
                continue;
            }

            auto split = upper_bound(arr.begin(), arr.end(), i);
            int l = split - arr.begin();
            int r = arr.size() - l;

            if (nums[i] == 0) {
                l--;
            }
            ans = (ans + l * 1LL * r % MOD) % MOD;
        }

        return ans;
    }
};
```

```JavaScript
const MOD = 1e9 + 7;

var specialTriplets = function (nums) {
    const pos = new Map();

    for (let i = 0; i < nums.length; i++) {
        const v = nums[i];
        if (pos.has(v)) {
            pos.get(v).push(i);
        } else {
            pos.set(v, [i]);
        }
    }

    const upperBound = (arr, i) => {
        let l = 0, r = arr.length - 1;

        while (l < r) {
            const mid = l + ((r - l + 1) >> 1);
            if (i >= arr[mid]) {
                l = mid;
            } else {
                r = mid - 1;
            }
        }
        return [l + 1, arr.length - 1 - l];
    };

    let ans = 0;
    for (let i = 1; i < nums.length - 1; i++) {
        const targetPos = pos.get(nums[i] * 2);
        if (targetPos && targetPos.length > 1 && targetPos[0] < i) {
            let [l, r] = upperBound(targetPos, i);
            if (nums[i] === 0) {
                l--;
            }
            ans += (l * r) % MOD;
            ans %= MOD;
        }
    }
    return ans;
};
```

```TypeScript
const MOD = 1e9 + 7;

function specialTriplets(nums: number[]): number {
    const pos = new Map<number, number[]>();

    for (let i = 0; i < nums.length; i++) {
        const v = nums[i];
        if (pos.has(v)) {
            pos.get(v)!.push(i);
        } else {
            pos.set(v, [i]);
        }
    }

    const upperBound = (arr: number[], i: number) => {
        let l = 0, r = arr.length - 1;

        while (l < r) {
            const mid = l + ((r - l + 1) >> 1);
            if (i >= arr[mid]) {
                l = mid;
            } else {
                r = mid - 1;
            }
        }
        return [l + 1, arr.length - 1 - l];
    };

    let ans = 0;
    for (let i = 1; i < nums.length - 1; i++) {
        const targetPos = pos.get(nums[i] * 2);
        if (targetPos && targetPos.length > 1 && targetPos[0] < i) {
            let [l, r] = upperBound(targetPos, i);
            if (nums[i] === 0) {
                l--;
            }
            ans += (l * r) % MOD;
            ans %= MOD;
        }
    }
    return ans;
}
```

```Java
class Solution {
    private static final int MOD = 1000000007;

    public int specialTriplets(int[] nums) {
        Map<Integer, List<Integer>> pos = new HashMap<>();

        for (int i = 0; i < nums.length; i++) {
            int v = nums[i];
            pos.computeIfAbsent(v, k -> new ArrayList<>()).add(i);
        }

        int ans = 0;
        for (int i = 1; i < nums.length - 1; i++) {
            int target = nums[i] * 2;
            List<Integer> targetPos = pos.get(target);
            if (targetPos != null && targetPos.size() > 1 && targetPos.get(0) < i) {
                int[] lr = upperBound(targetPos, i);
                int l = lr[0];
                int r = lr[1];
                if (nums[i] == 0) {
                    l--;
                }
                ans = (int)((ans + (long)l * r) % MOD);
            }
        }
        return ans;
    }

    private int[] upperBound(List<Integer> arr, int i) {
        int l = 0, r = arr.size() - 1;
        while (l < r) {
            int mid = l + ((r - l + 1) >> 1);
            if (i >= arr.get(mid)) {
                l = mid;
            } else {
                r = mid - 1;
            }
        }
        return new int[]{l + 1, arr.size() - 1 - l};
    }
}
```

```CSharp
using System;
using System.Collections.Generic;

public class Solution {
    private const int MOD = 1000000007;

    public int SpecialTriplets(int[] nums) {
        Dictionary<int, List<int>> pos = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++) {
            int v = nums[i];
            if (!pos.ContainsKey(v)) {
                pos[v] = new List<int>();
            }
            pos[v].Add(i);
        }

        int ans = 0;
        for (int i = 1; i < nums.Length - 1; i++) {
            int target = nums[i] * 2;
            if (pos.ContainsKey(target) && pos[target].Count > 1 && pos[target][0] < i) {
                var (l, r) = UpperBound(pos[target], i);
                int leftCount = l;
                int rightCount = r;
                if (nums[i] == 0) {
                    leftCount--;
                }
                ans = (int)((ans + (long)leftCount * rightCount) % MOD);
            }
        }
        return ans;
    }

    private (int, int) UpperBound(List<int> arr, int i) {
        int l = 0, r = arr.Count - 1;
        while (l < r) {
            int mid = l + ((r - l + 1) >> 1);
            if (i >= arr[mid]) {
                l = mid;
            } else {
                r = mid - 1;
            }
        }
        return (l + 1, arr.Count - 1 - l);
    }
}
```

```Go
func specialTriplets(nums []int) int {
    const MOD = 1000000007
    pos := make(map[int][]int)

    for i, v := range nums {
        pos[v] = append(pos[v], i)
    }

    ans := 0
    for i := 1; i < len(nums)-1; i++ {
        target := nums[i] * 2
        if targetPos, exists := pos[target]; exists && len(targetPos) > 1 && targetPos[0] < i {
            l, r := upperBound(targetPos, i)
            if nums[i] == 0 {
                l--
            }
            ans = (ans + l * r) % MOD
        }
    }
    return ans
}

func upperBound(arr []int, i int) (int, int) {
    l, r := 0, len(arr)-1
    for l < r {
        mid := l + ((r - l + 1) >> 1)
        if i >= arr[mid] {
            l = mid
        } else {
            r = mid - 1
        }
    }
    return l + 1, len(arr) - 1 - l
}
```

```Python
class Solution:
    def specialTriplets(self, nums: List[int]) -> int:
        MOD = 10**9 + 7
        pos = defaultdict(list)

        for i, v in enumerate(nums):
            pos[v].append(i)

        def upper_bound(arr, i):
            l, r = 0, len(arr) - 1
            while l < r:
                mid = l + ((r - l + 1) >> 1)
                if i >= arr[mid]:
                    l = mid
                else:
                    r = mid - 1
            return l + 1, len(arr) - 1 - l

        ans = 0
        for i in range(1, len(nums) - 1):
            target = nums[i] * 2
            if target in pos and len(pos[target]) > 1 and pos[target][0] < i:
                l, r = upper_bound(pos[target], i)
                if nums[i] == 0:
                    l -= 1
                ans = (ans + l * r) % MOD

        return ans
```

```C
#define MOD 1000000007

typedef struct {
    int key;
    int *indices;
    int size;
    int capacity;
    UT_hash_handle hh;
} HashItem;

HashItem* hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int index) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (pEntry) {
        if (pEntry->size >= pEntry->capacity) {
            pEntry->capacity *= 2;
            pEntry->indices = realloc(pEntry->indices, pEntry->capacity * sizeof(int));
        }
        pEntry->indices[pEntry->size++] = index;
    } else {
        pEntry = (HashItem *)malloc(sizeof(HashItem));
        pEntry->key = key;
        pEntry->capacity = 32;
        pEntry->size = 1;
        pEntry->indices = malloc(pEntry->capacity * sizeof(int));
        pEntry->indices[0] = index;
        HASH_ADD_INT(*obj, key, pEntry);
    }

    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr->indices);
        free(curr);
    }
}

int upperBound(int *arr, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] <= target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

int specialTriplets(int* nums, int numsSize) {
    HashItem *pos = NULL;
    for (int i = 0; i < numsSize; i++) {
        hashAddItem(&pos, nums[i], i);
    }

    int ans = 0;
    for (int i = 1; i < numsSize - 1; i++) {
        int target = nums[i] * 2;
        HashItem *pEntry = hashFindItem(&pos, target);
        if (pEntry == NULL || pEntry->size <= 1) {
            continue;
        }

        int *targetPos = pEntry->indices;
        int arrSize = pEntry->size;
        if (targetPos[0] >= i) {
            continue;
        }

        int split = upperBound(targetPos, arrSize, i);
        int l = split;
        int r = arrSize - split;
        if (nums[i] == 0) {
            l--;
        }
        if (l > 0 && r > 0) {
            ans = (int)((ans + (long long)l * r) % MOD);
        }
    }

    hashFree(&pos);
    return ans;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn special_triplets(nums: Vec<i32>) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let mut pos: HashMap<i32, Vec<usize>> = HashMap::new();

        for (i, &v) in nums.iter().enumerate() {
            pos.entry(v).or_insert_with(Vec::new).push(i);
        }

        let upper_bound = |arr: &[usize], i: usize| -> (usize, usize) {
            let (mut l, mut r) = (0, arr.len() - 1);
            while l < r {
                let mid = l + ((r - l + 1) >> 1);
                if i >= arr[mid] {
                    l = mid;
                } else {
                    r = mid - 1;
                }
            }
            (l + 1, arr.len() - 1 - l)
        };

        let mut ans: i64 = 0;
        for i in 1..nums.len() - 1 {
            let target = nums[i] * 2;
            if let Some(target_pos) = pos.get(&target) {
                if target_pos.len() > 1 && target_pos[0] < i {
                    let (mut l, r) = upper_bound(target_pos, i);
                    if nums[i] == 0 {
                        l -= 1;
                    }
                    ans = (ans + l as i64 * r as i64) % MOD;
                }
            }
        }

        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，设 $n$ 是 $nums$ 的长度，遍历 $nums$ 需要 $O(n)$，哈希表的存取需要 $O(1)$，二分查找复杂度为 $O(\log n)$，故总时间复杂度为 $O(n\log n)$。
- 空间复杂度：$O(n)$，哈希表存储元素下标索引序列，均摊后需要 $O(n)$ 的空间。
