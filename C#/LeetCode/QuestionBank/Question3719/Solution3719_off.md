### [最长平衡子数组 I](https://leetcode.cn/problems/longest-balanced-subarray-i/solutions/3896554/zui-chang-ping-heng-zi-shu-zu-i-by-leetc-7mlh/)

#### 方法一：暴力

**思路与算法**

本题是[「3721. 最长平衡子数组 II」](https://leetcode.cn/problems/longest-balanced-subarray-ii/)的数据简化版，可以直接使用暴力算法求解。

考虑 $O(n^2)$ 遍历区间，使用两个哈希表维护区间内奇偶数元素出现的次数，在遍历过程中不断更新满足条件的最大长度。

本题在具体实现上，可以有多种方法来维护哈希表。最简单的方式就是在每次确定区间左端点时新建哈希表，并在扩展右端点的同时更新结果。

**代码**

```C++
class Solution {
public:
    int longestBalanced(vector<int>& nums) {
        size_t len = 0;

        for (size_t i = 0; i < nums.size(); i++) {
            auto odd = unordered_map<int, int>();
            auto even = unordered_map<int, int>();

            for (size_t j = i; j < nums.size(); j++) {
                auto& c = (nums[j] & 1) ? odd : even;
                c[nums[j]]++;

                if (odd.size() == even.size()) {
                    len = std::max(len, j - i + 1);
                }
            }
        }

        return int(len);
    }
};
```

```JavaScript
var longestBalanced = function (nums) {
    let len = 0;

    for (let i = 0; i < nums.length; i++) {
        const odd = new Map();
        const even = new Map();

        for (let j = i; j < nums.length; j++) {
            const c = (nums[j] & 1) ? odd : even;

            c.set(nums[j], (c.get(nums[j]) ?? 0) + 1);

            if (odd.size == even.size) {
                len = Math.max(len, j - i + 1);
            }
        }
    }

    return len;
}
```

```TypeScript
function longestBalanced(nums: number[]): number {
    let len = 0;

    for (let i = 0; i < nums.length; i++) {
        const odd = new Map<number, number>();
        const even = new Map<number, number>();

        for (let j = i; j < nums.length; j++) {
            const c = (nums[j] & 1) ? odd : even;

            c.set(nums[j], (c.get(nums[j]) ?? 0) + 1);

            if (odd.size == even.size) {
                len = Math.max(len, j - i + 1);
            }
        }
    }

    return len;
}
```

```Java
class Solution {
    public int longestBalanced(int[] nums) {
        int len = 0;

        for (int i = 0; i < nums.length; i++) {
            HashMap<Integer, Integer> odd = new HashMap<>();
            HashMap<Integer, Integer> even = new HashMap<>();

            for (int j = i; j < nums.length; j++) {
                HashMap<Integer, Integer> map = (nums[j] & 1) == 1 ? odd : even;
                map.put(nums[j], map.getOrDefault(nums[j], 0) + 1);

                if (odd.size() == even.size()) {
                    len = Math.max(len, j - i + 1);
                }
            }
        }

        return len;
    }
}
```

```CSharp
public class Solution {
    public int LongestBalanced(int[] nums) {
        int len = 0;

        for (int i = 0; i < nums.Length; i++) {
            var odd = new Dictionary<int, int>();
            var even = new Dictionary<int, int>();

            for (int j = i; j < nums.Length; j++) {
                var dict = (nums[j] & 1) == 1 ? odd : even;
                dict[nums[j]] = dict.GetValueOrDefault(nums[j]) + 1;

                if (odd.Count == even.Count) {
                    len = Math.Max(len, j - i + 1);
                }
            }
        }

        return len;
    }
}
```

```Go
func longestBalanced(nums []int) int {
    maxLen := 0

    for i := 0; i < len(nums); i++ {
        odd := make(map[int]int)
        even := make(map[int]int)

        for j := i; j < len(nums); j++ {
            if nums[j] & 1 == 1 {
                odd[nums[j]]++
            } else {
                even[nums[j]]++
            }

            if len(odd) == len(even) {
                if j-i+1 > maxLen {
                    maxLen = j - i + 1
                }
            }
        }
    }

    return maxLen
}
```

```Python
class Solution:
    def longestBalanced(self, nums: List[int]) -> int:
        max_len = 0

        for i in range(len(nums)):
            odd = {}
            even = {}

            for j in range(i, len(nums)):
                if nums[j] & 1:
                    odd[nums[j]] = odd.get(nums[j], 0) + 1
                else:
                    even[nums[j]] = even.get(nums[j], 0) + 1

                if len(odd) == len(even):
                    max_len = max(max_len, j - i + 1)

        return max_len
```

```C
typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem;

HashItem* hashFindItem(HashItem** obj, int key) {
    HashItem* pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem** obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem* pEntry = (HashItem*)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem** obj, int key, int val) {
    HashItem* pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem** obj, int key, int defaultVal) {
    HashItem* pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

bool hashEraseItem(HashItem** obj, int key) {
    HashItem* pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    if (pEntry) {
        HASH_DEL(*obj, pEntry);
        free(pEntry);
        return true;
    }
    return false;
}

void hashFree(HashItem** obj) {
    HashItem* curr = NULL;
    HashItem* tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
    *obj = NULL;
}


int hashSize(HashItem* obj) {
    return HASH_COUNT(obj);
}

int longestBalanced(int* nums, int numsSize) {
    size_t len = 0;
    for (size_t i = 0; i < numsSize; i++) {
        HashItem* odd = NULL;
        HashItem* even = NULL;
        for (size_t j = i; j < numsSize; j++) {
            int count = hashGetItem(&odd, nums[j], 0);
            if ((nums[j] & 1) == 1) {
                hashSetItem(&odd, nums[j], count + 1);
            } else {
                hashSetItem(&even, nums[j], count + 1);
            }
            if (hashSize(odd) == hashSize(even)) {
                len = fmax(len, j - i + 1);
            }
        }
        hashFree(&odd);
        hashFree(&even);
    }

    return (int)len;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn longest_balanced(nums: Vec<i32>) -> i32 {
        let mut max_len = 0;

        for i in 0..nums.len() {
            let mut odd = HashMap::new();
            let mut even = HashMap::new();

            for j in i..nums.len() {
                let map = if nums[j] & 1 == 1 {
                    &mut odd
                } else {
                    &mut even
                };

                *map.entry(nums[j]).or_insert(0) += 1;

                if odd.len() == even.len() {
                    max_len = max_len.max((j - i + 1) as i32);
                }
            }
        }

        max_len
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $nums$ 的长度。遍历区间需要 $O(n^2)$，使用哈希表维护元素出现的次数需要 $O(1)$。
- 空间复杂度：$O(n)$，哈希表需要 $O(n)$ 的空间。
