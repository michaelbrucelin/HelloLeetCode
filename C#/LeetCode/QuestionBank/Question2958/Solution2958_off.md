### [最多 K 个重复元素的最长子数组](https://leetcode.cn/problems/length-of-longest-subarray-with-at-most-k-frequency/solutions/4007022/zui-duo-k-ge-zhong-fu-yuan-su-de-zui-cha-3qgv/)

#### 方法一：双指针

**思路与算法**

记数组 $nums$ 的长度为 $n$。如果子数组 $[left,right]$ 是好数组，那么 $[left+1,right]$ 也一定是好数组，并且其右端点还可以继续向右扩展。因此，我们可以使用双指针解决本题。

枚举左端点 $left$，右端点 $right$ 只会单调向右移动。用哈希表 $occ$ 维护当前窗口 $[left,right]$ 中各元素的出现次数，初始时 $right=-1$。对于每个左端点 $left$：

- 若 $left>0$，说明左端点右移，需要将 $nums[left-1]$ 从哈希表中移除；
- 只要 $right+1<n$ 且 $occ[nums[right+1]]<k$，就可以将 $nums[right+1]$ 加入哈希表，并将右端点右移。

此时 $[left,right]$ 就是以 $left$ 为左端点的最长好子数组，用 $right-left+1$ 更新答案即可。

**代码**

```C++
class Solution {
public:
    int maxSubarrayLength(vector<int>& nums, int k) {
        int n = nums.size();
        unordered_map<int, int> occ;
        int right = -1, ans = 0;
        for (int left = 0; left < n; ++left) {
            if (left > 0) {
                --occ[nums[left - 1]];
            }
            while (right + 1 < n && occ[nums[right + 1]] < k) {
                ++right;
                ++occ[nums[right]];
            }
            ans = max(ans, right - left + 1);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def maxSubarrayLength(self, nums: List[int], k: int) -> int:
        n, occ = len(nums), Counter()
        right, ans = -1, 0
        for left in range(n):
            if left > 0:
                occ[nums[left - 1]] -= 1
            while right + 1 < n and occ[nums[right + 1]] < k:
                right += 1
                occ[nums[right]] += 1
            ans = max(ans, right - left + 1)
        return ans
```

```Java
class Solution {
    public int maxSubarrayLength(int[] nums, int k) {
        int n = nums.length;
        Map<Integer, Integer> occ = new HashMap<>();
        int right = -1;
        int ans = 0;

        for (int left = 0; left < n; left++) {
            if (left > 0) {
                int prevNum = nums[left - 1];
                occ.put(prevNum, occ.get(prevNum) - 1);
                if (occ.get(prevNum) == 0) {
                    occ.remove(prevNum);
                }
            }

            while (right + 1 < n && occ.getOrDefault(nums[right + 1], 0) < k) {
                right++;
                occ.put(nums[right], occ.getOrDefault(nums[right], 0) + 1);
            }
            ans = Math.max(ans, right - left + 1);
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxSubarrayLength(int[] nums, int k) {
        int n = nums.Length;
        Dictionary<int, int> occ = new Dictionary<int, int>();
        int right = -1, ans = 0;

        for (int left = 0; left < n; ++left) {
            if (left > 0) {
                int key = nums[left - 1];
                occ[key] = occ[key] - 1;
                if (occ[key] == 0) occ.Remove(key);
            }

            while (right + 1 < n && (!occ.ContainsKey(nums[right + 1]) || occ[nums[right + 1]] < k)) {
                ++right;
                if (!occ.ContainsKey(nums[right])) {
                    occ[nums[right]] = 0;
                }
                occ[nums[right]] = occ[nums[right]] + 1;
            }

            ans = Math.Max(ans, right - left + 1);
        }

        return ans;
    }
}
```

```Go
func maxSubarrayLength(nums []int, k int) int {
    n := len(nums)
    occ := make(map[int]int)
    right := -1
    ans := 0

    for left := 0; left < n; left++ {
        if left > 0 {
            occ[nums[left-1]]--
            if occ[nums[left-1]] == 0 {
                delete(occ, nums[left-1])
            }
        }

        for right+1 < n && occ[nums[right+1]] < k {
            right++
            occ[nums[right]]++
        }

        if right-left+1 > ans {
            ans = right - left + 1
        }
    }

    return ans
}
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

void hashEraseItem(HashItem **obj, int key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (pEntry) {
        HASH_DEL(*obj, pEntry);
        free(pEntry);
    }
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

int maxSubarrayLength(int* nums, int numsSize, int k) {
    HashItem *occ = NULL;
    int right = -1, ans = 0;

    for (int left = 0; left < numsSize; left++) {
        if (left > 0) {
            int key = nums[left - 1];
            int val = hashGetItem(&occ, key, 0) - 1;
            if (val == 0) {
                hashEraseItem(&occ, key);
            } else {
                hashSetItem(&occ, key, val);
            }
        }

        while (right + 1 < numsSize) {
            int nextKey = nums[right + 1];
            int count = hashGetItem(&occ, nextKey, 0);
            if (count >= k) break;

            right++;
            hashSetItem(&occ, nums[right], count + 1);
        }

        int len = right - left + 1;
        if (len > ans) ans = len;
    }

    hashFree(&occ);
    return ans;
}
```

```JavaScript
var maxSubarrayLength = function(nums, k) {
    const n = nums.length;
    const occ = new Map();
    let right = -1, ans = 0;

    for (let left = 0; left < n; ++left) {
        if (left > 0) {
            const key = nums[left - 1];
            occ.set(key, occ.get(key) - 1);
            if (occ.get(key) === 0) {
                occ.delete(key);
            }
        }

        while (right + 1 < n && (occ.get(nums[right + 1]) || 0) < k) {
            ++right;
            occ.set(nums[right], (occ.get(nums[right]) || 0) + 1);
        }

        ans = Math.max(ans, right - left + 1);
    }

    return ans;
};
```

```TypeScript
function maxSubarrayLength(nums: number[], k: number): number {
    const n = nums.length;
    const occ = new Map<number, number>();
    let right = -1, ans = 0;

    for (let left = 0; left < n; ++left) {
        if (left > 0) {
            const key = nums[left - 1];
            const val = occ.get(key)! - 1;
            if (val === 0) {
                occ.delete(key);
            } else {
                occ.set(key, val);
            }
        }

        while (right + 1 < n && (occ.get(nums[right + 1]) || 0) < k) {
            ++right;
            occ.set(nums[right], (occ.get(nums[right]) || 0) + 1);
        }

        ans = Math.max(ans, right - left + 1);
    }

    return ans;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn max_subarray_length(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len();
        let mut occ = HashMap::new();
        let mut right = -1;
        let mut ans = 0;

        for left in 0..n {
            if left > 0 {
                let key = nums[left - 1];
                if let Some(val) = occ.get_mut(&key) {
                    *val -= 1;
                    if *val == 0 {
                        occ.remove(&key);
                    }
                }
            }

            while right + 1 < n as i32 && *occ.get(&nums[(right + 1) as usize]).unwrap_or(&0) < k {
                right += 1;
                *occ.entry(nums[right as usize]).or_insert(0) += 1;
            }

            ans = ans.max(right - left as i32 + 1);
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。左右指针均至多移动 $n$ 次，哈希表单次操作的平均复杂度为 $O(1)$。
- 空间复杂度：$O(n)$，即为哈希表需要使用的空间。
