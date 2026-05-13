### [使数组互补的最少操作次数](https://leetcode.cn/problems/minimum-moves-to-make-array-complementary/solutions/3963827/shi-shu-zu-hu-bu-de-zui-shao-cao-zuo-ci-fhvrb/)

#### 方法一：差分

**思路与算法**

考虑 $nums$ 中任意符合题意的数对 $(a,b)$，其中 $a$ 是两者中的较小值，$b$ 是两者中的较大值。假设此时我们的目标是将所有的 $(a,b)$ 之和修改到 $c$，易得 $c$ 的取值范围是 $[2,2\times limit]$，根据 $c$ 的取值不同，某个数对 $(a,b)$ 需要的最小修改次数有如下五种情况：

- 当 $2\le c<a+1$ 时：需要操作 $2$ 次。即使将较大的数 $b$ 变为极小值 $1$，新的数对和 $a+1$ 依然大于 $c$，因此必须将 $a$ 和 $b$ 同时修改。
- 当 $a+1\le c<a+b$ 时：需要操作 $1$ 次。只需将较大的数 $b$ 减小到 $c-a$ 即可，修改后的 $c-a$ 必然落在合法范围 $1\le c-a\le limit$ 内。
- 当 $c=a+b$ 时：此时无需修改。
- 当 $a+b<c\le b+limit$ 时：需要操作 $1$ 次。只需将较小的数 $a$ 增大到 $c-b$ 即可，修改后的 $c-b$ 必然落在合法范围 $1\le c-b\le limit$ 内。
- 当 $b+limit<c\le 2\times limit$ 时：需要操作 $2$ 次。即使将较小的数 $a$ 变为极大值 $limit$，新的数对和 $b+limit$ 依然小于 $c$，因此必须将 $a$ 和 $b$ 同时修改。

观察以上五种情况，可以发现对于给定的数对 $(a,b)$ 和修改目标 $c$，其需要的操作次数在 $[2,2\times limit]$ 的**各个连续子区间上是一定的**，且分界点可以直接计算。这意味着每对数在不同目标值 $c$ 下需要操作数可以使用**差分数组**来维护，其前缀和就是当前目标 $c$ 下的总操作次数。维护该操作次数并取最小值即可。

**代码**

```C++
class Solution {
public:
    int minMoves(vector<int>& nums, int limit) {
        int n = nums.size();
        vector<int> diff(2 * limit + 2, 0);

        for (int i = 0; i < n / 2; ++i) {
            int a = min(nums[i], nums[n - 1 - i]);
            int b = max(nums[i], nums[n - 1 - i]);

            diff[2] += 2;
            diff[a + 1] -= 1;
            diff[a + b] -= 1;
            diff[a + b + 1] += 1;
            diff[b + limit + 1] += 1;
        }

        int min_ops = n;
        int current_ops = 0;

        for (int c = 2; c <= 2 * limit; ++c) {
            current_ops += diff[c];
            min_ops = min(min_ops, current_ops);
        }

        return min_ops;
    }
};
```

```Java
class Solution {
    public int minMoves(int[] nums, int limit) {
        int n = nums.length;
        int[] diff = new int[2 * limit + 2];

        for (int i = 0; i < n / 2; i++) {
            int a = Math.min(nums[i], nums[n - 1 - i]);
            int b = Math.max(nums[i], nums[n - 1 - i]);

            diff[2] += 2;
            diff[a + 1] -= 1;
            diff[a + b] -= 1;
            diff[a + b + 1] += 1;
            diff[b + limit + 1] += 1;
        }

        int minOps = n;
        int currentOps = 0;

        for (int c = 2; c <= 2 * limit; c++) {
            currentOps += diff[c];
            minOps = Math.min(minOps, currentOps);
        }

        return minOps;
    }
}
```

```CSharp
public class Solution {
    public int MinMoves(int[] nums, int limit) {
        int n = nums.Length;
        int[] diff = new int[2 * limit + 2];

        for (int i = 0; i < n / 2; i++) {
            int a = Math.Min(nums[i], nums[n - 1 - i]);
            int b = Math.Max(nums[i], nums[n - 1 - i]);

            diff[2] += 2;
            diff[a + 1] -= 1;
            diff[a + b] -= 1;
            diff[a + b + 1] += 1;
            diff[b + limit + 1] += 1;
        }

        int minOps = n;
        int currentOps = 0;

        for (int c = 2; c <= 2 * limit; c++) {
            currentOps += diff[c];
            minOps = Math.Min(minOps, currentOps);
        }

        return minOps;
    }
}
```

```Go
func minMoves(nums []int, limit int) int {
    n := len(nums)
    diff := make([]int, 2*limit+2)

    for i := 0; i < n/2; i++ {
        a := min(nums[i], nums[n-1-i])
        b := max(nums[i], nums[n-1-i])

        diff[2] += 2
        diff[a+1] -= 1
        diff[a+b] -= 1
        diff[a+b+1] += 1
        diff[b+limit+1] += 1
    }

    minOps := n
    currentOps := 0

    for c := 2; c <= 2*limit; c++ {
        currentOps += diff[c]
        minOps = min(minOps, currentOps)
    }

    return minOps
}
```

```Python
class Solution:
    def minMoves(self, nums: List[int], limit: int) -> int:
        n = len(nums)
        diff = [0] * (2 * limit + 2)

        for i in range(n // 2):
            a = min(nums[i], nums[n - 1 - i])
            b = max(nums[i], nums[n - 1 - i])

            diff[2] += 2
            diff[a + 1] -= 1
            diff[a + b] -= 1
            diff[a + b + 1] += 1
            diff[b + limit + 1] += 1

        min_ops = n
        current_ops = 0

        for c in range(2, 2 * limit + 1):
            current_ops += diff[c]
            if current_ops < min_ops:
                min_ops = current_ops

        return min_ops

```

```C
int minMoves(int* nums, int numsSize, int limit) {
    int n = numsSize;
    int* diff = (int*)calloc(2 * limit + 2, sizeof(int));

    for (int i = 0; i < n / 2; i++) {
        int a = fmin(nums[i], nums[n - 1 - i]);
        int b = fmax(nums[i], nums[n - 1 - i]);

        diff[2] += 2;
        diff[a + 1] -= 1;
        diff[a + b] -= 1;
        diff[a + b + 1] += 1;
        diff[b + limit + 1] += 1;
    }

    int minOps = n;
    int currentOps = 0;

    for (int c = 2; c <= 2 * limit; c++) {
        currentOps += diff[c];
        if (currentOps < minOps) {
            minOps = currentOps;
        }
    }

    free(diff);
    return minOps;
}
```

```JavaScript
var minMoves = function (nums, limit) {
    const n = nums.length;
    const diff = new Array(2 * limit + 2).fill(0);

    for (let i = 0; i < n / 2; i++) {
        const a = Math.min(nums[i], nums[n - 1 - i]);
        const b = Math.max(nums[i], nums[n - 1 - i]);

        diff[2] += 2;
        diff[a + 1] -= 1;
        diff[a + b] -= 1;
        diff[a + b + 1] += 1;
        diff[b + limit + 1] += 1;
    }

    let minOps = n;
    let currentOps = 0;

    for (let c = 2; c <= 2 * limit; c++) {
        currentOps += diff[c];
        minOps = Math.min(minOps, currentOps);
    }

    return minOps;
};
```

```TypeScript
function minMoves(nums: number[], limit: number): number {
    const n = nums.length;
    const diff = new Array(2 * limit + 2).fill(0);

    for (let i = 0; i < n / 2; i++) {
        const a = Math.min(nums[i], nums[n - 1 - i]);
        const b = Math.max(nums[i], nums[n - 1 - i]);

        diff[2] += 2;
        diff[a + 1] -= 1;
        diff[a + b] -= 1;
        diff[a + b + 1] += 1;
        diff[b + limit + 1] += 1;
    }

    let minOps = n;
    let currentOps = 0;

    for (let c = 2; c <= 2 * limit; c++) {
        currentOps += diff[c];
        minOps = Math.min(minOps, currentOps);
    }

    return minOps;
};
```

```Rust
impl Solution {
    pub fn min_moves(nums: Vec<i32>, limit: i32) -> i32 {
        let n = nums.len();
        let mut diff = vec![0; (2 * limit + 2) as usize];

        for i in 0..n / 2 {
            let a = nums[i].min(nums[n - 1 - i]);
            let b = nums[i].max(nums[n - 1 - i]);

            diff[2] += 2;
            diff[(a + 1) as usize] -= 1;
            diff[(a + b) as usize] -= 1;
            diff[(a + b + 1) as usize] += 1;
            diff[(b + limit + 1) as usize] += 1;
        }

        let mut min_ops = n as i32;
        let mut current_ops = 0;

        for c in 2..=(2 * limit) as usize {
            current_ops += diff[c];
            min_ops = min_ops.min(current_ops);
        }

        min_ops
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+L)$，其中 $n$ 是 $nums$ 的长度，$L$ 代表 $limit$。遍历 $\dfrac{n}{2}$ 对元素计算差分数组需要 $O(n)$，枚举可能的数对和取值需要 $O(L)$。
- 空间复杂度：$O(L)$。差分数组 $diff$ 需要 $O(L)$ 的空间。

#### 方法二：二分查找

**思路与算法**

方法一使用的差分思路不是那么好想，让我们从朴素做法开始：遍历所有可能的数对和取值 $c$，其范围是 $[2,2\times limit]$；对于每个可能的取值，我们遍历所有数对，计算其最小操作次数并累计后得到总操作次数并更新全局最优解，此时的时间复杂度是 $O(n\times limit)$，其中 $n$ 是 $nums$ 的长度。

考虑优化此方法，虽然 $c$ 的最优值最终会偏向中部，但是局部上并不具有单调性质，因此只能考虑优化统计操作次数的方法。那么还是假定对于一个给定的数对 $(a,b)$ 与 $c$，其中 $a$ 是两者的较小值，$b$ 是两者的较大值，可以这样考虑需要的操作次数：

- 对于所有的数对，先假设它们需要操作一次，其和才能变为目标值 $c$。
- 对于所有和已经是 $a+b$ 的数对，由于不需要额外操作，因此要在最后统计的次数中减去这样的数对的数量。
- 对于所有较小值大于 $c-1$ 或较大值小于 $c-limit$ 的数对，需要 $2$ 次操作才能变为目标值 $c$，因此要在最后统计的次数中加上这样的数对的数量。

即，可以把当前需要的操作次数描述为如下公式，其中 $count$ 表示满足条件的数对的数目：

$$currentOps=\dfrac{n}{2}-count(a+b=c)+count(a>c-1)+count(b<c-limit)$$

下面考虑如何在可接受的时间内计算 count(a+b=c)、count(a>c-1)、count(b<c-limit) 这三个量。

对于 $count(a+b=c)$，只需要使用哈希表预先统计好各个数对和的出现次数，即可在后续枚举 $c$ 时以 $O(1)$ 的时间复杂度直接获取。

对于 $count(a>c-1)$，因为这样的 $(a,b)$ 不可能满足 $a+b=c$，故可以直接提取所有数对中的较小值并排序，然后利用二分查找定位目标 $c$ 在该数组中的位置，即可在 $O(\log n)$ 的时间内得到这样的数对数量。

对于 $count(b<c-limit)$ 同理，提取所有数对中的较大值并排序，然后利用二分查找定位 $c-limit$ 即可。

按上述方式优化计算给定目标值下的总操作次数即可。较方法一而言，该方法慢了一个 $O(\log n)$ 的量级，但仍足够通过此题。

**代码**

```C++
class Solution {
public:
    int minMoves(vector<int>& nums, int limit) {
        int n = nums.size();
        unordered_map<int, int> sum_count;
        vector<int> min_arr, max_arr;
        min_arr.reserve(n / 2);
        max_arr.reserve(n / 2);

        for (int i = 0; i < n / 2; ++i) {
            int a = std::min(nums[i], nums[n - 1 - i]);
            int b = std::max(nums[i], nums[n - 1 - i]);

            sum_count[a + b]++;
            min_arr.push_back(a);
            max_arr.push_back(b);
        }

        std::sort(min_arr.begin(), min_arr.end());
        std::sort(max_arr.begin(), max_arr.end());

        int min_ops = n;

        for (int c = 2; c <= 2 * limit; ++c) {
            int add_left =
                n / 2 - (lower_bound(min_arr.begin(), min_arr.end(), c) -
                         min_arr.begin());
            int add_right =
                lower_bound(max_arr.begin(), max_arr.end(), c - limit) -
                max_arr.begin();

            int current_ops = n / 2 + add_left + add_right - sum_count[c];
            min_ops = min(min_ops, current_ops);
        }

        return min_ops;
    }
};
```

```Java
class Solution {
    public int minMoves(int[] nums, int limit) {
        int n = nums.length;
        Map<Integer, Integer> sumCount = new HashMap<>();
        int[] minArr = new int[n / 2];
        int[] maxArr = new int[n / 2];

        for (int i = 0; i < n / 2; i++) {
            int a = Math.min(nums[i], nums[n - 1 - i]);
            int b = Math.max(nums[i], nums[n - 1 - i]);

            sumCount.merge(a + b, 1, Integer::sum);
            minArr[i] = a;
            maxArr[i] = b;
        }

        Arrays.sort(minArr);
        Arrays.sort(maxArr);

        int minOps = n;

        for (int c = 2; c <= 2 * limit; c++) {
            int addLeft = n / 2 - lowerBound(minArr, c);
            int addRight = lowerBound(maxArr, c - limit);

            int currentOps = n / 2 + addLeft + addRight - sumCount.getOrDefault(c, 0);
            minOps = Math.min(minOps, currentOps);
        }

        return minOps;
    }

    private int lowerBound(int[] arr, int target) {
        int left = 0, right = arr.length;
        while (left < right) {
            int mid = (left + right) >>> 1;
            if (arr[mid] >= target) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return left;
    }
}
```

```CSharp
public class Solution {
    public int MinMoves(int[] nums, int limit) {
        int n = nums.Length;
        var sumCount = new Dictionary<int, int>();
        var minArr = new int[n / 2];
        var maxArr = new int[n / 2];

        for (int i = 0; i < n / 2; i++) {
            int a = Math.Min(nums[i], nums[n - 1 - i]);
            int b = Math.Max(nums[i], nums[n - 1 - i]);

            int sum = a + b;
            sumCount[sum] = sumCount.GetValueOrDefault(sum) + 1;

            minArr[i] = a;
            maxArr[i] = b;
        }

        Array.Sort(minArr);
        Array.Sort(maxArr);

        int LowerBound(int[] arr, int target) {
            int left = 0, right = arr.Length;
            while (left < right) {
                int mid = left + ((right - left) >>> 1);
                if (arr[mid] >= target) {
                    right = mid;
                } else {
                    left = mid + 1;
                }
            }
            return left;
        }

        int minOps = n;

        for (int c = 2; c <= 2 * limit; c++) {
            int addLeft = n / 2 - LowerBound(minArr, c);
            int addRight = LowerBound(maxArr, c - limit);

            int currentOps = n / 2 + addLeft + addRight - sumCount.GetValueOrDefault(c);
            minOps = Math.Min(minOps, currentOps);
        }

        return minOps;
    }
}
```

```Go
func minMoves(nums []int, limit int) int {
    n := len(nums)
    sumCount := make(map[int]int)
    minArr := make([]int, n/2)
    maxArr := make([]int, n/2)

    for i := 0; i < n/2; i++ {
        a := min(nums[i], nums[n-1-i])
        b := max(nums[i], nums[n-1-i])

        sumCount[a+b]++
        minArr[i] = a
        maxArr[i] = b
    }

    sort.Ints(minArr)
    sort.Ints(maxArr)
    minOps := n

    for c := 2; c <= 2*limit; c++ {
        addLeft := n/2 - lowerBound(minArr, c)
        addRight := lowerBound(maxArr, c-limit)

        currentOps := n/2 + addLeft + addRight - sumCount[c]
        minOps = min(minOps, currentOps)
    }

    return minOps
}

func lowerBound(arr []int, target int) int {
    left, right := 0, len(arr)
    for left < right {
        mid := (left + right) / 2
        if arr[mid] >= target {
            right = mid
        } else {
            left = mid + 1
        }
    }
    return left
}
```

```Python
class Solution:
    def minMoves(self, nums: List[int], limit: int) -> int:
        n = len(nums)
        sum_count = Counter()
        min_arr = []
        max_arr = []

        for i in range(n // 2):
            a = min(nums[i], nums[n - 1 - i])
            b = max(nums[i], nums[n - 1 - i])

            sum_count[a + b] += 1
            min_arr.append(a)
            max_arr.append(b)

        min_arr.sort()
        max_arr.sort()

        min_ops = n

        for c in range(2, 2 * limit + 1):
            add_left = n // 2 - bisect_left(min_arr, c)
            add_right = bisect_left(max_arr, c - limit)

            current_ops = n // 2 + add_left + add_right - sum_count[c]
            min_ops = min(min_ops, current_ops)

        return min_ops
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

int lowerBound(int* arr, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] >= target) {
            right = mid;
        } else {
            left = mid + 1;
        }
    }
    return left;
}

int minMoves(int* nums, int numsSize, int limit) {
    int n = numsSize;
    int half = n / 2;

    HashItem* sumCount = NULL;
    int* minArr = (int*)malloc(half * sizeof(int));
    int* maxArr = (int*)malloc(half * sizeof(int));

    for (int i = 0; i < half; i++) {
        int a = fmin(nums[i], nums[n - 1 - i]);
        int b = fmax(nums[i], nums[n - 1 - i]);

        int sum = a + b;
        int currentCount = hashGetItem(&sumCount, sum, 0);
        hashSetItem(&sumCount, sum, currentCount + 1);

        minArr[i] = a;
        maxArr[i] = b;
    }

    qsort(minArr, half, sizeof(int), compare);
    qsort(maxArr, half, sizeof(int), compare);

    int minOps = n;

    for (int c = 2; c <= 2 * limit; c++) {
        int addLeft = half - lowerBound(minArr, half, c);
        int addRight = lowerBound(maxArr, half, c - limit);

        int currentOps = half + addLeft + addRight - hashGetItem(&sumCount, c, 0);
        if (currentOps < minOps) {
            minOps = currentOps;
        }
    }

    free(minArr);
    free(maxArr);
    hashFree(&sumCount);

    return minOps;
}
```

```JavaScript
var minMoves = function (nums, limit) {
    const n = nums.length;
    const sumCount = new Map();
    const minArr = [];
    const maxArr = [];

    for (let i = 0; i < n / 2; i++) {
        const a = Math.min(nums[i], nums[n - 1 - i]);
        const b = Math.max(nums[i], nums[n - 1 - i]);

        const sum = a + b;
        sumCount.set(sum, (sumCount.get(sum) ?? 0) + 1);

        minArr.push(a);
        maxArr.push(b);
    }

    minArr.sort((x, y) => x - y);
    maxArr.sort((x, y) => x - y);

    const lowerBound = (arr, target) => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = left + ((right - left) >>> 1);
            if (arr[mid] >= target) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return left;
    };

    let minOps = n;

    for (let c = 2; c <= 2 * limit; c++) {
        const addLeft = n / 2 - lowerBound(minArr, c);
        const addRight = lowerBound(maxArr, c - limit);

        const currentOps = n / 2 + addLeft + addRight - (sumCount.get(c) ?? 0);
        minOps = Math.min(minOps, currentOps);
    }

    return minOps;
};
```

```TypeScript
function minMoves(nums: number[], limit: number): number {
    const n = nums.length;

    const sumCount = new Map<number, number>();
    const minArr: number[] = [];
    const maxArr: number[] = [];

    for (let i = 0; i < n / 2; i++) {
        const a = Math.min(nums[i], nums[n - 1 - i]);
        const b = Math.max(nums[i], nums[n - 1 - i]);

        const sum = a + b;
        sumCount.set(sum, (sumCount.get(sum) ?? 0) + 1);

        minArr.push(a);
        maxArr.push(b);
    }

    minArr.sort((x, y) => x - y);
    maxArr.sort((x, y) => x - y);

    const lowerBound = (arr: number[], target: number): number => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = left + Math.floor((right - left) >>> 1);
            if (arr[mid] >= target) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return left;
    };

    let minOps = n;

    for (let c = 2; c <= 2 * limit; c++) {
        const addLeft = n / 2 - lowerBound(minArr, c);
        const addRight = lowerBound(maxArr, c - limit);

        const currentOps = n / 2 + addLeft + addRight - (sumCount.get(c) ?? 0);
        minOps = Math.min(minOps, currentOps);
    }

    return minOps;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn min_moves(nums: Vec<i32>, limit: i32) -> i32 {
        let n = nums.len();
        let mut sum_count = HashMap::new();
        let mut min_arr = Vec::with_capacity(n / 2);
        let mut max_arr = Vec::with_capacity(n / 2);

        for i in 0..n / 2 {
            let a = nums[i].min(nums[n - 1 - i]);
            let b = nums[i].max(nums[n - 1 - i]);

            *sum_count.entry(a + b).or_insert(0) += 1;
            min_arr.push(a);
            max_arr.push(b);
        }

        min_arr.sort_unstable();
        max_arr.sort_unstable();

        let mut min_ops = n;

        for c in 2..=2 * limit {
            let add_left = n / 2 - min_arr.partition_point(|&x| x < c);
            let add_right = max_arr.partition_point(|&x| x < c - limit);

            let current_ops = n / 2 + add_left + add_right - sum_count.get(&c).unwrap_or(&0);
            min_ops = min_ops.min(current_ops);
        }

        min_ops as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+L\log n)$，其中 $n$ 是 $nums$ 的长度，$L$ 代表 $limit$。获取 $nums$ 中的每对元素并计数需要 $O(n)$；对 $minArr$ 和 $maxArr$ 排序需要 $O(n\log n)$；后续求解答案时，枚举可能的数对和取值需要 $O(L)$，循环内部进行二分查找与哈希表查询共需要 $O(\log n)$，故这部分时间复杂度是 $O(L\log n)$。
- 空间复杂度：$O(n)$，minArr、maxArr 和计数用的哈希表需要 $O(n)$ 的辅助空间。
