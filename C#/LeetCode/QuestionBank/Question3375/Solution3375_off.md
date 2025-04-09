### [使数组的值全部为 K 的最少操作次数](https://leetcode.cn/problems/minimum-operations-to-make-array-values-equal-to-k/solutions/3636172/shi-shu-zu-de-zhi-quan-bu-wei-k-de-zui-s-bhcw/)

#### 方法一：哈希表

**思路与算法**

根据题意，若当前数组的最大值为 $x$，次大值（若有的话）为 $y$，那么我们可以选择一个 $h(y \le h < x)$，令数组中所有等于 $x$ 的数字都变成 $h$。

因此，若要使用最小的操作次数把整个数组中的数字都变成 $k$，那么：

- 若数组存在比 $k$ 小的数字，则无解；
- 否则，统计数组中所有大于 $k$ 的数字种类个数，该个数即为操作次数；

我们用一个哈希表去统计数组中大于 $k$ 的数字。在遍历数组的过程中，若遇到比 $k$ 小的则直接返回 $-1$。

**代码**

```C++
class Solution {
public:
    int minOperations(vector<int>& nums, int k) {
        unordered_set<int> st;
        for (int x : nums) {
            if (x < k) {
                return -1;
            } else if (x > k) {
                st.insert(x);
            }
        }
        return st.size();
    }
};
```

```Python
class Solution:
    def minOperations(self, nums: List[int], k: int) -> int:
        st = set()
        for x in nums:
            if x < k:
                return -1
            elif x > k:
                st.add(x)
        return len(st)
```

```Rust
use std::collections::HashSet;
impl Solution {
    pub fn min_operations(nums: Vec<i32>, k: i32) -> i32 {
        let mut st = HashSet::new();
        for x in nums {
            if x < k {
                return -1
            } else if x > k {
                st.insert(x);
            }
        }
        st.len() as i32
    }
}
```

```Java
class Solution {
    public int minOperations(int[] nums, int k) {
        Set<Integer> st = new HashSet<>();
        for (int x : nums) {
            if (x < k) {
                return -1;
            } else if (x > k) {
                st.add(x);
            }
        }
        return st.size();
    }
}
```

```CSharp
public class Solution {
    public int MinOperations(int[] nums, int k) {
        HashSet<int> st = new HashSet<int>();
        foreach (int x in nums) {
            if (x < k) {
                return -1;
            } else if (x > k) {
                st.Add(x);
            }
        }
        return st.Count;
    }
}
```

```Go
func minOperations(nums []int, k int) int {
    st := make(map[int]bool)
    for _, x := range nums {
        if x < k {
            return -1
        } else if x > k {
            st[x] = true
        }
    }
    return len(st)
}
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

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}
int minOperations(int* nums, int numsSize, int k) {
    HashItem *st = NULL;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] < k) {
            return -1;
        } else if (nums[i] > k) {
            hashAddItem(&st, nums[i]);
        }
    }
    int ret = HASH_COUNT(st);
    hashFree(&st);
    return ret;
}

```

```JavaScript
var minOperations = function(nums, k) {
    const st = new Set();
    for (const x of nums) {
        if (x < k) {
            return -1;
        } else if (x > k) {
            st.add(x);
        }
    }
    return st.size;
};
```

```TypeScript
function minOperations(nums: number[], k: number): number {
    const st = new Set<number>();
    for (const x of nums) {
        if (x < k) {
            return -1;
        } else if (x > k) {
            st.add(x);
        }
    }
    return st.size;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。我们仅需遍历一次 $nums$，并且向哈希表中添加元素的时间复杂度为 $O(1)$，因此总体时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$。使用哈希表的空间复杂度为 $O(n)$。
