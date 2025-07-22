### [删除子数组的最大得分](https://leetcode.cn/problems/maximum-erasure-value/solutions/3719982/shan-chu-zi-shu-zu-de-zui-da-de-fen-by-l-jp9y/)

#### 方法一：哈希表 + 前缀和

**思路与算法**

题目要求找到数组中由**不同元素**组成的连续子数组和的最大值，由于数组中元素的取值范围均大于等于 $0$，此时如果可以找到以任意索引 $i$ 为结尾的**不同元素**组成的最长子数组，即可找到目标和的最大值。仔细观察可以发现存在如下递推关系：

- 假设以 $i$ 为结尾且由**不同元素**构成的最长连续子数组从索引 $j$ 开始，到索引 $i$ 结尾，则此时子数组 $[nums[j],nums[j+1],\cdots ,nums[i]]$ 中各个元素均不相同，此时以 $i$ 为结尾的最大子数组和为 $\sum_{k=j}^i​nums[k]$；
- 当加入新元素 $nums[i]$ 时，此时设 $nums[i+1]$ 左侧最近出现的索引为 $k$，此时令 $l=max(k+1,j)$，以 $i+1$ 为结尾且由**不同元素**构成的最长连续子数组应当从索引 $l$ 开始，到索引 $i+1$ 结束，即此时**不同元素**构成的最长连续子数组则为：$[nums[l],nums[l+1],\cdots ,nums[i+1]]$，此时以 $i+1$ 为结尾的最大子数组和为 $\sum_{p=l}^{i+1}​nums[p]$；

根据上述分析可知，我们枚举以 $i$ 为结尾且由**不同元素**构成的最长连续子数组，并求该子数组的和，找到和的最大值即为答案。实际遍历时，我们用 $psum$ 记录数组的前缀和，用哈希表 $cnt$ 记录当前已经遍历过的元素在数组中出现的最右索引，用 $pre$ 记录最长连续子数组的最左侧的索引，当遍历 $nums[i]$ 时，此时通过哈希表找到元素 $nums[i]$ 出现的前一个索引 $cnt[nums[i]]$，此时更新 $pre=max(pre,cnt[nums[i]])$，可通过前缀和 $psum$ 求出当前子数组的和，并更新答案 $ans$，同时更新 $nums[i]$ 出现的索引为 $i$，最后返回答案 $ans$ 即可。

**代码**

```C++
class Solution {
public:
    int maximumUniqueSubarray(vector<int>& nums) {
        int n = nums.size();
        vector<int> psum(n + 1);
        unordered_map<int, int> cnt;
        int ans = 0, pre = 0;
        for(int i = 0; i < n; ++i) {
            psum[i + 1] = psum[i] + nums[i];
            pre = max(pre, cnt[nums[i]]);
            ans = max(ans, psum[i + 1] - psum[pre]);
            cnt[nums[i]] = i + 1;
        }
        
        return ans;
    }
};
```

```Java
class Solution {
    public int maximumUniqueSubarray(int[] nums) {
        int n = nums.length;
        int[] psum = new int[n + 1];
        HashMap<Integer, Integer> cnt = new HashMap<>();
        int ans = 0, pre = 0;
        for (int i = 0; i < n; ++i) {
            psum[i + 1] = psum[i] + nums[i];
            pre = Math.max(pre, cnt.getOrDefault(nums[i], 0));
            ans = Math.max(ans, psum[i + 1] - psum[pre]);
            cnt.put(nums[i], i + 1);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaximumUniqueSubarray(int[] nums) {
        int n = nums.Length;
        int[] psum = new int[n + 1];
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        int ans = 0, pre = 0;
        for (int i = 0; i < n; ++i) {
            psum[i + 1] = psum[i] + nums[i];
            pre = Math.Max(pre, cnt.GetValueOrDefault(nums[i], 0));
            ans = Math.Max(ans, psum[i + 1] - psum[pre]);
            cnt[nums[i]] = i + 1;
        }
        return ans;
    }
}
```

```Go
func maximumUniqueSubarray(nums []int) int {
    n := len(nums)
    psum := make([]int, n + 1)
    cnt := make(map[int]int)
    ans, pre := 0, 0
    for i := 0; i < n; i++ {
        psum[i + 1] = psum[i] + nums[i]
        if val, exists := cnt[nums[i]]; exists {
            pre = max(pre, val)
        }
        ans = max(ans, psum[i + 1] - psum[pre]);
        cnt[nums[i]] = i + 1
    }
    return ans
}
```

```Python
class Solution:
    def maximumUniqueSubarray(self, nums: List[int]) -> int:
        n = len(nums)
        psum = [0] * (n + 1)
        cnt = {}
        ans = pre = 0
        for i in range(n):
            psum[i + 1] = psum[i] + nums[i]
            pre = max(pre, cnt.get(nums[i], 0))
            ans = max(ans, psum[i + 1] - psum[pre])
            cnt[nums[i]] = i + 1
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

int maximumUniqueSubarray(int* nums, int numsSize) {
    int *psum = (int*)calloc(numsSize + 1, sizeof(int));
    HashItem *cnt = NULL;
    int ans = 0, pre = 0;
    for(int i = 0; i < numsSize; ++i) {
        psum[i + 1] = psum[i] + nums[i];
        pre = fmax(pre, hashGetItem(&cnt, nums[i], 0));
        ans = fmax(ans, psum[i + 1] - psum[pre]);
        hashSetItem(&cnt, nums[i], i + 1);
    }
    free(psum);
    hashFree(&cnt);
    return ans;
}
```

```JavaScript
var maximumUniqueSubarray = function(nums) {
    const n = nums.length;
    const psum = new Array(n + 1).fill(0);
    const cnt = new Map();
    let ans = 0, pre = 0;
    for (let i = 0; i < n; ++i) {
        psum[i + 1] = psum[i] + nums[i];
        pre = Math.max(pre, cnt.get(nums[i]) || 0);
        ans = Math.max(ans, psum[i + 1] - psum[pre]);
        cnt.set(nums[i], i + 1);
    }
    return ans;
};
```

```TypeScript
function maximumUniqueSubarray(nums: number[]): number {
    const n = nums.length;
    const psum: number[] = new Array(n + 1).fill(0);
    const cnt: Map<number, number> = new Map();
    let ans = 0, pre = 0;
    for (let i = 0; i < n; ++i) {
        psum[i + 1] = psum[i] + nums[i];
        pre = Math.max(pre, cnt.get(nums[i]) || 0);
        ans = Math.max(ans, psum[i + 1] - psum[pre]);
        cnt.set(nums[i], i + 1);
    }
    return ans;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn maximum_unique_subarray(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut psum = vec![0; n + 1];
        let mut cnt = HashMap::new();
        let mut ans = 0;
        let mut pre = 0;
        for i in 0..n {
            psum[i + 1] = psum[i] + nums[i];
            pre = pre.max(*cnt.get(&nums[i]).unwrap_or(&0));
            ans = ans.max(psum[i + 1] - psum[pre as usize]);
            cnt.insert(nums[i], (i + 1) as i32);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示给定数组 $nums$ 的长度。仅需遍历一遍数组即可求出最大得分，需要的时间为 $O(n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定数组 $nums$ 的长度。需要哈希表存储数组每个元素出现的索引以及数组的前缀和，需要的空间为 $O(n)$。

#### 方法二：滑动窗口

**思路与算法**

题目要求找到数组中由**不同元素**组成的连续子数组和的最大值，此时我们可以引入一个集合，当遇到重复元素则移动窗口并维护变量即可。设 $seen$ 保存当前集合中所有已经出现的元素，并用 $psum$ 保存当前窗口内的元素和，当遇到集合中出现重复元素时，则向右移动窗口并更新元素和 $psum$，直到窗口内不再出现重复元素为止。

**代码**

```C++
class Solution {
public:
    int maximumUniqueSubarray(vector<int>& nums) {
        int n = nums.size();
        unordered_set<int> seen;
        int ans = 0, psum = 0;
        for(int i = 0, j = 0; i < n; ++i) {
            psum += nums[i];
            while (seen.count(nums[i])) {
                seen.erase(nums[j]);
                psum -= nums[j];
                j++;
            }
            seen.emplace(nums[i]);
            ans = max(ans, psum);
        }
        
        return ans;
    }
};
```

```Java
class Solution {
    public int maximumUniqueSubarray(int[] nums) {
        int n = nums.length;
        Set<Integer> seen = new HashSet<>();
        int ans = 0, psum = 0;
        for (int i = 0, j = 0; i < n; ++i) {
            psum += nums[i];
            while (seen.contains(nums[i])) {
                seen.remove(nums[j]);
                psum -= nums[j];
                j++;
            }
            seen.add(nums[i]);
            ans = Math.max(ans, psum);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaximumUniqueSubarray(int[] nums) {
        int n = nums.Length;
        HashSet<int> seen = new HashSet<int>();
        int ans = 0, psum = 0;
        for (int i = 0, j = 0; i < n; ++i) {
            psum += nums[i];
            while (seen.Contains(nums[i])) {
                seen.Remove(nums[j]);
                psum -= nums[j];
                j++;
            }
            seen.Add(nums[i]);
            ans = Math.Max(ans, psum);
        }
        return ans;
    }
}
```

```Go
func maximumUniqueSubarray(nums []int) int {
     n := len(nums)
    seen := make(map[int]bool)
    ans, psum := 0, 0
    for i, j := 0, 0; i < n; i++ {
        psum += nums[i]
        for seen[nums[i]] {
            delete(seen, nums[j])
            psum -= nums[j]
            j++
        }
        seen[nums[i]] = true
        if psum > ans {
            ans = psum
        }
    }
    return ans
}
```

```Python
class Solution:
    def maximumUniqueSubarray(self, nums: List[int]) -> int:
        n = len(nums)
        seen = set()
        ans = psum = 0
        j = 0
        for i in range(n):
            psum += nums[i]
            while nums[i] in seen:
                seen.remove(nums[j])
                psum -= nums[j]
                j += 1
            seen.add(nums[i])
            ans = max(ans, psum)
        return ans
```

```C
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashEraseItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    HASH_DEL(*obj, pEntry);
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

int maximumUniqueSubarray(int* nums, int numsSize) {
    HashItem *seen = NULL;
    int ans = 0, psum = 0;
    for (int i = 0, j = 0; i < numsSize; ++i) {
        psum += nums[i];
        while (hashFindItem(&seen, nums[i])) {
            hashEraseItem(&seen, nums[j]);
            psum -= nums[j];
            j++;
        }
        hashAddItem(&seen, nums[i]);
        ans = fmax(ans, psum);
    }
    hashFree(&seen);
    return ans;
}
```

```JavaScript
var maximumUniqueSubarray = function(nums) {
    const n = nums.length;
    const seen = new Set();
    let ans = 0, psum = 0;
    for (let i = 0, j = 0; i < n; ++i) {
        psum += nums[i];
        while (seen.has(nums[i])) {
            seen.delete(nums[j]);
            psum -= nums[j];
            j++;
        }
        seen.add(nums[i]);
        ans = Math.max(ans, psum);
    }
    return ans;
};
```

```TypeScript
function maximumUniqueSubarray(nums: number[]): number {
    const n = nums.length;
    const seen = new Set<number>();
    let ans = 0, psum = 0;
    for (let i = 0, j = 0; i < n; ++i) {
        psum += nums[i];
        while (seen.has(nums[i])) {
            seen.delete(nums[j]);
            psum -= nums[j];
            j++;
        }
        seen.add(nums[i]);
        ans = Math.max(ans, psum);
    }
    return ans;
};
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn maximum_unique_subarray(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut seen = HashSet::new();
        let mut ans = 0;
        let mut psum = 0;
        let mut j = 0;
        for i in 0..n {
            psum += nums[i];
            while seen.contains(&nums[i]) {
                seen.remove(&nums[j]);
                psum -= nums[j];
                j += 1;
            }
            seen.insert(nums[i]);
            ans = ans.max(psum);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示给定数组 $nums$ 的长度。仅需遍历一遍数组即可求出最大得分，需要的时间为 $O(n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定数组 $nums$ 的长度。需要存储数组中每个元素出现的索引需要的空间为 $O(n)$。
