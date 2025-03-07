### [美丽子集的数目](https://leetcode.cn/problems/the-number-of-beautiful-subsets/solutions/3081917/mei-li-zi-ji-de-shu-mu-by-leetcode-solut-dn4h/)

#### 方法一：回溯

**思路与算法**

注意到 $nums$ 的长度范围较小，可以考虑枚举所有子集。

枚举子集时，可以考虑是否将第 $i$ 个数加入子集。对于每一个 $nums_i$，有两种可能：

1. 不将 $nums_i$ 添加到子集中，无条件满足。
2. 将 $nums_i$ 添加到子集中，需要满足 $nums_i-k$ 和 $nums_i+k$ 还没有被添加到子集中。

为了检查当前子集中已经添加了哪些数，可以使用一个哈希表记录。

**代码**

```C++
class Solution {
public:
    int beautifulSubsets(vector<int>& nums, int k) {
        int ans = 0;
        unordered_map<int, int> cnt;
        function<void(int)> dfs = [&](int i) {
            if (i == nums.size()) {
                ans++;
                return;
            }
            dfs(i + 1);
            if (cnt[nums[i] - k] == 0 && cnt[nums[i] + k] == 0) {
                ++cnt[nums[i]];
                dfs(i + 1);
                --cnt[nums[i]];
            }
        };
        dfs(0);
        return ans - 1;
    }
};
```

```Java
class Solution {
    private int ans = 0;
    private Map<Integer, Integer> cnt = new HashMap<>();

    public int beautifulSubsets(int[] nums, int k) {
        dfs(nums, k, 0);
        return ans - 1;
    }

    public void dfs(int[] nums, int k, int i) {
        if (i == nums.length) {
            ans++;
            return;
        }
        dfs(nums, k, i + 1);
        if (cnt.getOrDefault(nums[i] - k, 0) == 0 && cnt.getOrDefault(nums[i] + k, 0) == 0) {
            cnt.put(nums[i], cnt.getOrDefault(nums[i], 0) + 1);
            dfs(nums, k, i + 1);
            cnt.put(nums[i], cnt.getOrDefault(nums[i], 0) - 1);
        }
    }
}
```

```CSharp
public class Solution {
    private int ans = 0;
    private Dictionary<int, int> cnt = new Dictionary<int, int>();

    public int BeautifulSubsets(int[] nums, int k) {
        DFS(nums, k, 0);
        return ans - 1;
    }

    public void DFS(int[] nums, int k, int i) {
        if (i == nums.Length) {
            ans++;
            return;
        }
        DFS(nums, k, i + 1);
        if (cnt.GetValueOrDefault(nums[i] - k, 0) == 0 && cnt.GetValueOrDefault(nums[i] + k, 0) == 0) {
            cnt[nums[i]] = cnt.GetValueOrDefault(nums[i], 0) + 1;
            DFS(nums, k, i + 1);
            cnt[nums[i]] = cnt.GetValueOrDefault(nums[i], 0) - 1;
        }
    }
}
```

```Go
func beautifulSubsets(nums []int, k int) int {
    ans := 0
    cnt := make(map[int]int)
    var dfs func(i int)
    dfs = func(i int) {
        if i == len(nums) {
            ans++
            return
        }
        dfs(i + 1)
        if cnt[nums[i] - k] == 0 && cnt[nums[i] + k] == 0 {
            cnt[nums[i]]++
            dfs(i + 1)
            cnt[nums[i]]--
        }
    }
    dfs(0)
    return ans - 1
}
```

```Python
class Solution:
    def beautifulSubsets(self, nums: List[int], k: int) -> int:
        ans = 0
        cnt = {}
        def dfs(i):
            nonlocal ans
            if i == len(nums):
                ans += 1
                return
            dfs(i + 1)
            if cnt.get(nums[i] - k, 0) == 0 and cnt.get(nums[i] + k, 0) == 0:
                cnt[nums[i]] = cnt.get(nums[i], 0) + 1
                dfs(i + 1)
                cnt[nums[i]] -= 1

        dfs(0)
        return ans - 1
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

void dfs(int i, int *nums, int numsSize, int k, HashItem **cnt, int *ans) {
    if (i == numsSize) {
        (*ans)++;
        return;
    }
    dfs(i + 1, nums, numsSize, k, cnt, ans);
    if (hashGetItem(cnt, nums[i] - k, 0) == 0 && hashGetItem(cnt, nums[i] + k, 0) == 0) {
        hashSetItem(cnt, nums[i], hashGetItem(cnt, nums[i], 0) + 1);
        dfs(i + 1, nums, numsSize, k, cnt, ans);
        hashSetItem(cnt, nums[i], hashGetItem(cnt, nums[i], 0) - 1);
    }
}

int beautifulSubsets(int* nums, int numsSize, int k) {
    int ans = 0;
    HashItem *cnt = NULL;
    dfs(0, nums, numsSize, k, &cnt, &ans);
    hashFree(&cnt);
    return ans - 1;
}
```

```JavaScript
var beautifulSubsets = function(nums, k) {
    let ans = 0;
    const cnt = new Map();
    function dfs(i) {
        if (i === nums.length) {
            ans++;
            return;
        }
        dfs(i + 1);
        if ((!cnt.has(nums[i] - k) || cnt.get(nums[i] - k) === 0) &&
            (!cnt.has(nums[i] + k) || cnt.get(nums[i] + k) === 0)) {
            cnt.set(nums[i], (cnt.get(nums[i]) || 0) + 1);
            dfs(i + 1);
            cnt.set(nums[i], (cnt.get(nums[i]) || 0) - 1);
        }
    }
    dfs(0);
    return ans - 1;
};
```

```TypeScript
function beautifulSubsets(nums: number[], k: number): number {
    let ans = 0;
    const cnt = new Map<number, number>();
    function dfs(i: number): void {
        if (i === nums.length) {
            ans++;
            return;
        }
        dfs(i + 1);
        if ((!cnt.has(nums[i] - k) || cnt.get(nums[i] - k) === 0) &&
            (!cnt.has(nums[i] + k) || cnt.get(nums[i] + k) === 0)) {
            cnt.set(nums[i], (cnt.get(nums[i]) || 0) + 1);
            dfs(i + 1);
            cnt.set(nums[i], (cnt.get(nums[i]) || 0) - 1);
        }
    }
    dfs(0);
    return ans - 1;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn beautiful_subsets(nums: Vec<i32>, k: i32) -> i32 {
        let mut ans = 0;
        let mut cnt = HashMap::new();
        fn dfs(i: usize, nums: &Vec<i32>, k: i32, ans: &mut i32, cnt: &mut HashMap<i32, i32>) {
            if i == nums.len() {
                *ans += 1;
                return;
            }
            dfs(i + 1, nums, k, ans, cnt);
            if cnt.get(&(nums[i] - k)).unwrap_or(&0) == &0 && cnt.get(&(nums[i] + k)).unwrap_or(&0) == &0 {
                *cnt.entry(nums[i]).or_insert(0) += 1;
                dfs(i + 1, nums, k, ans, cnt);
                *cnt.entry(nums[i]).or_insert(0) -= 1;
            }
        }
        dfs(0, &nums, k, &mut ans, &mut cnt);
        ans - 1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(2^n)$，其中 $n$ 为 $nums$ 的长度。
- 空间复杂度：$O(n)$。

#### 方法二：动态规划

**思路与算法**

我们可以考虑将每个数根据模 $k$ 的结果进行分组，如果模 $k$ 不同余，那么它们一定不相差 $k$。由于不同组之间的选择不会互相影响，我们只需要计算组内的选法，并把每组的选法相乘就能得到答案。

假设 $arr$ 表示 $nums$ 中模 $k$ 值相等的某一组数排序并去重后组成的数组，$cnt_i$ 表示 $arr_i$ 的出现次数。

由于 $arr$ 中数字相互之间的差值都是 $k$ 的整数倍且已经有序，那么只有与 $arr_i$ 相邻的数字有可能与 $arr_i$ 相差为 $k$，因此我们只需要考虑相邻的数能否同时选中。

令 $f(i,0)$ 表示 $arr_i$ 不加入子集，$f(i,1)$ 表示 $arr_i$ 加入子集。

不选择 $arr_i$ 时，前面的数可以任选，则递推方程为：

$$f(i,0)=f(i-1,0)+f(i-1,1)$$

当选择 $arr_i$ 时，其与 $arr_{i-1}$ 的差不能为 $k$。由于 $nums$ 中可能有多个值为 $arr_i$，至少选择其中一个的方案数为 $2^{cnt_i}-1$。递推方程为：

$$f(i,1)=\begin{cases}(f(i-1,0)+f(i-1,1)) \times (2^{cnt_i}-1), & arr_i-arr_{i-1} \ne k \\ f(i-1,0) \times (2^{cnt_i}-1), & arr_i-arr_{i-1}=k\end{cases}$$

初值 $f(0,0)=1，f(0,1)=2^{cnt_i}-1，f(n-1,0)+f(n-1,1)$ 就是答案。

**代码**

```C++
class Solution {
public:
    int beautifulSubsets(vector<int>& nums, int k) {
        unordered_map<int, map<int, int>> groups;
        for (int a : nums) {
            ++groups[a % k][a];
        }
        int ans = 1;
        for (auto& [_, g] : groups) {
            int m = g.size();
            vector<vector<int>> f(m, vector<int>(2, 0));
            f[0][0] = 1, f[0][1] = (1 << g.begin()->second) - 1;
            int i = 1;
            for (auto it = next(g.begin()); it != g.end(); it++, i++) {
                f[i][0] = f[i - 1][0] + f[i - 1][1];
                if (it->first - prev(it)->first == k) {
                    f[i][1] = f[i - 1][0] * ((1 << it->second) - 1);
                } else {
                    f[i][1] =
                        (f[i - 1][0] + f[i - 1][1]) * ((1 << it->second) - 1);
                }
            }
            ans *= f[m - 1][0] + f[m - 1][1];
        }
        return ans - 1;
    }
};
```

```Java
public class Solution {
    public int beautifulSubsets(int[] nums, int k) {
        Map<Integer, Map<Integer, Integer>> groups = new HashMap<>();
        for (int a : nums) {
            groups.computeIfAbsent(a % k, key -> new TreeMap<>()).merge(a, 1, Integer::sum);
        }
        int ans = 1;
        for (Map.Entry<Integer, Map<Integer, Integer>> entry : groups.entrySet()) {
            Map<Integer, Integer> g = entry.getValue();
            int m = g.size();
            int[][] f = new int[m][2];
            f[0][0] = 1;
            f[0][1] = (1 << g.get(g.keySet().iterator().next())) - 1;
            int i = 1;
            Iterator<Map.Entry<Integer, Integer>> it = g.entrySet().iterator();
            Map.Entry<Integer, Integer> prev = it.next();
            while (it.hasNext()) {
                Map.Entry<Integer, Integer> curr = it.next();
                f[i][0] = f[i - 1][0] + f[i - 1][1];
                if (curr.getKey() - prev.getKey() == k) {
                    f[i][1] = f[i - 1][0] * ((1 << curr.getValue()) - 1);
                } else {
                    f[i][1] = (f[i - 1][0] + f[i - 1][1]) * ((1 << curr.getValue()) - 1);
                }
                prev = curr;
                i++;
            }
            ans *= f[m - 1][0] + f[m - 1][1];
        }
        return ans - 1;
    }
}
```

```CSharp
public class Solution {
    public int BeautifulSubsets(int[] nums, int k) {
        var groups = new Dictionary<int, SortedDictionary<int, int>>();
        foreach (int a in nums) {
            int mod = a % k;
            if (!groups.ContainsKey(mod)) {
                groups[mod] = new SortedDictionary<int, int>();
            }
            groups[mod][a] = groups[mod].GetValueOrDefault(a, 0) + 1;
        }
        int ans = 1;
        foreach (var g in groups.Values) {
            int m = g.Count;
            int[,] f = new int[m, 2];
            f[0, 0] = 1;
            f[0, 1] = (1 << g.First().Value) - 1;
            int i = 1;
            var prev = g.First();
            foreach (var curr in g.Skip(1)) {
                f[i, 0] = f[i - 1, 0] + f[i - 1, 1];
                if (curr.Key - prev.Key == k) {
                    f[i, 1] = f[i - 1, 0] * ((1 << curr.Value) - 1);
                } else {
                    f[i, 1] = (f[i - 1, 0] + f[i - 1, 1]) * ((1 << curr.Value) - 1);
                }
                prev = curr;
                i++;
            }
            ans *= f[m - 1, 0] + f[m - 1, 1];
        }
        return ans - 1;
    }
}
```

```Go
func beautifulSubsets(nums []int, k int) int {
    groups := make(map[int]map[int]int)
    for _, a := range nums {
        mod := a % k
        if _, ok := groups[mod]; !ok {
            groups[mod] = make(map[int]int)
        }
        groups[mod][a]++
    }
    ans := 1
    for _, g := range groups {
        keys := make([]int, 0, len(g))
        for key := range g {
            keys = append(keys, key)
        }
        sort.Ints(keys)
        m := len(keys)
        f := make([][2]int, m)
        f[0][0] = 1
        f[0][1] = (1 << g[keys[0]]) - 1
        for i := 1; i < m; i++ {
            f[i][0] = f[i - 1][0] + f[i - 1][1]
            if keys[i] - keys[i - 1] == k {
                f[i][1] = f[i - 1][0] * ((1 << g[keys[i]]) - 1)
            } else {
                f[i][1] = (f[i - 1][0] + f[i - 1][1]) * ((1 << g[keys[i]]) - 1)
            }
        }
        ans *= f[m - 1][0] + f[m - 1][1]
    }
    return ans - 1
}
```

```Python
class Solution:
    def beautifulSubsets(self, nums: List[int], k: int) -> int:
        groups = defaultdict(dict)
        for a in nums:
            mod = a % k
            groups[mod][a] = groups[mod].get(a, 0) + 1
        ans = 1
        for g in groups.values():
            sorted_keys = sorted(g.keys())
            m = len(sorted_keys)
            f = [[0] * 2 for _ in range(m)]
            f[0][0] = 1
            f[0][1] = (1 << g[sorted_keys[0]]) - 1
            for i in range(1, m):
                f[i][0] = f[i - 1][0] + f[i - 1][1]
                if sorted_keys[i] - sorted_keys[i - 1] == k:
                    f[i][1] = f[i - 1][0] * ((1 << g[sorted_keys[i]]) - 1)
                else:
                    f[i][1] = (f[i - 1][0] + f[i - 1][1]) * ((1 << g[sorted_keys[i]]) - 1)
            ans *= f[m - 1][0] + f[m - 1][1]
        return ans - 1
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

int compare(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int beautifulSubsets(int* nums, int numsSize, int k) {
    HashItem *groups[k];
    for (int i = 0; i < k; i++) {
        groups[i] = NULL;
    }
    for (int i = 0; i < numsSize; i++) {
        int mod = nums[i] % k;
        hashSetItem(&groups[mod], nums[i], hashGetItem(&groups[mod], nums[i], 0) + 1);
    }
    int ans = 1;
    for (int j = 0; j < k; j++) {
        if (groups[j] == NULL) {
            continue;
        }
        int m = HASH_COUNT(groups[j]);
        int keys[m], f[m][2];
        int pos = 0;
        memset(f, 0, sizeof(f));
        for (HashItem *pEntry = groups[j]; pEntry != NULL; pEntry = pEntry->hh.next) {
            keys[pos++] = pEntry->key;
        }
        qsort(keys, m, sizeof(int), compare);
        f[0][0] = 1;
        f[0][1] = (1 << hashGetItem(&groups[j], keys[0], 0)) - 1;
        for (int i = 1; i < m; i++) {
            int val = hashGetItem(&groups[j], keys[i], 0);
            f[i][0] = f[i - 1][0] + f[i - 1][1];
            if (keys[i] - keys[i - 1] == k) {
                f[i][1] = f[i - 1][0] * ((1 << val) - 1);
            } else {
                f[i][1] = (f[i - 1][0] + f[i - 1][1]) * ((1 << val) - 1);
            }
        }
        ans *= f[m - 1][0] + f[m - 1][1];
        hashFree(&groups[j]);
    }

    return ans - 1;
}
```

```JavaScript
function beautifulSubsets(nums, k) {
    const groups = new Map();
    for (const a of nums) {
        const mod = a % k;
        if (!groups.has(mod)) {
            groups.set(mod, new Map());
        }
        const group = groups.get(mod);
        group.set(a, (group.get(a) || 0) + 1);
    }
    let ans = 1;
    for (const g of groups.values()) {
        const sortedKeys = Array.from(g.keys()).sort((a, b) => a - b);
        const m = sortedKeys.length;
        const f = Array.from({ length: m }, () => [0, 0]);
        f[0][0] = 1;
        f[0][1] = (1 << g.get(sortedKeys[0])) - 1;
        for (let i = 1; i < m; i++) {
            f[i][0] = f[i - 1][0] + f[i - 1][1];
            if (sortedKeys[i] - sortedKeys[i - 1] === k) {
                f[i][1] = f[i - 1][0] * ((1 << g.get(sortedKeys[i])) - 1);
            } else {
                f[i][1] = (f[i - 1][0] + f[i - 1][1]) * ((1 << g.get(sortedKeys[i])) - 1);
            }
        }
        ans *= f[m - 1][0] + f[m - 1][1];
    }
    return ans - 1;
}
```

```TypeScript
function beautifulSubsets(nums: number[], k: number): number {
    const groups = new Map<number, Map<number, number>>();
    for (const a of nums) {
        const mod = a % k;
        if (!groups.has(mod)) {
            groups.set(mod, new Map());
        }
        const group = groups.get(mod)!;
        group.set(a, (group.get(a) || 0) + 1);
    }
    let ans = 1;
    for (const g of groups.values()) {
        const sortedKeys = Array.from(g.keys()).sort((a, b) => a - b);
        const m = sortedKeys.length;
        const f = Array.from({ length: m }, () => [0, 0]);
        f[0][0] = 1;
        f[0][1] = (1 << g.get(sortedKeys[0])!) - 1;
        for (let i = 1; i < m; i++) {
            f[i][0] = f[i - 1][0] + f[i - 1][1];
            if (sortedKeys[i] - sortedKeys[i - 1] === k) {
                f[i][1] = f[i - 1][0] * ((1 << g.get(sortedKeys[i])!) - 1);
            } else {
                f[i][1] = (f[i - 1][0] + f[i - 1][1]) * ((1 << g.get(sortedKeys[i])!) - 1);
            }
        }
        ans *= f[m - 1][0] + f[m - 1][1];
    }
    return ans - 1;
}
```

```Rust
use std::collections::{BTreeMap, HashMap};

impl Solution {
    pub fn beautiful_subsets(nums: Vec<i32>, k: i32) -> i32 {
        let mut groups: HashMap<i32, BTreeMap<i32, i32>> = HashMap::new();
        for &a in &nums {
            let mod_val = a % k;
            groups.entry(mod_val).or_insert(BTreeMap::new()).entry(a).and_modify(|e| *e += 1).or_insert(1);
        }
        let mut ans = 1;
        for g in groups.values() {
            let m = g.len();
            let mut f = vec![vec![0; 2]; m];
            let first_key = *g.keys().next().unwrap();
            f[0][0] = 1;
            f[0][1] = (1 << g[&first_key]) - 1;
            let mut i = 1;
            let mut prev_key = first_key;
            for (&curr_key, &count) in g.iter().skip(1) {
                f[i][0] = f[i - 1][0] + f[i - 1][1];
                if curr_key - prev_key == k {
                    f[i][1] = f[i - 1][0] * ((1 << count) - 1);
                } else {
                    f[i][1] = (f[i - 1][0] + f[i - 1][1]) * ((1 << count) - 1);
                }
                prev_key = curr_key;
                i += 1;
            }
            ans *= f[m - 1][0] + f[m - 1][1];
        }
        ans - 1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 为 $nums$ 的长度。维护有序的数据结构需要 $O(nlogn)$ 的时间。
- 空间复杂度：$O(n)$。
