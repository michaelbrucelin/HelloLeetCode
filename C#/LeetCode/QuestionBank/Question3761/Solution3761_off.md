### [镜像对之间最小绝对距离](https://leetcode.cn/problems/minimum-absolute-distance-between-mirror-pairs/solutions/3950421/jing-xiang-dui-zhi-jian-zui-xiao-jue-dui-7dt2/)

#### 方法一：一次遍历

**思路与算法**

我们从左到右遍历数组，并维护哈希表 $prev$。其中 $prev[v]$ 表示最近的下标 $j$，满足 $reverse(nums[j])=v$。

对于当前位置 $i$，设当前值为 $x=nums[i]$：

- 若 $x$ 在 $prev$ 中出现过，说明存在下标 $j$ 使得 $reverse(nums[j])=x$，因此 $(j,i)$ 是一组镜像对，可以用 $i-j$ 更新答案；
- 随后计算 $reverse(x)$，并令 $prev[reverse(x)]=i$，表示当前下标可以与后续值为 $reverse(x)$ 的元素配对。

对于同一个键，我们始终保留最近下标。因为后续固定右端点时，左端点越靠右，距离越小，这样才能够得到最小绝对距离。

**代码**

```C++
class Solution {
public:
    int minMirrorPairDistance(vector<int>& nums) {
        auto reverseNum = [](int x) {
            int y = 0;
            while (x > 0) {
                y = y * 10 + x % 10;
                x /= 10;
            }
            return y;
        };

        int n = nums.size();
        unordered_map<int, int> prev;
        int ans = n + 1;
        for (int i = 0; i < n; ++i) {
            int x = nums[i];
            if (prev.count(x)) {
                ans = min(ans, i - prev[x]);
            }
            prev[reverseNum(x)] = i;
        }

        return ans == n + 1 ? -1 : ans;
    }
};
```

```Python
class Solution:
    def minMirrorPairDistance(self, nums: List[int]) -> int:
        prev = dict()
        ans = inf
        for i, num in enumerate(nums):
            if num in prev:
                ans = min(ans, i - prev[num])
            prev[int(str(num)[::-1])] = i
        return -1 if ans == inf else ans
```

```Java
class Solution {
    public int minMirrorPairDistance(int[] nums) {
        Map<Integer, Integer> prev = new HashMap<>();
        int n = nums.length;
        int ans = n + 1;

        for (int i = 0; i < n; i++) {
            int x = nums[i];
            if (prev.containsKey(x)) {
                ans = Math.min(ans, i - prev.get(x));
            }
            prev.put(reverseNum(x), i);
        }

        return ans == n + 1 ? -1 : ans;
    }

    private int reverseNum(int x) {
        int y = 0;
        while (x > 0) {
            y = y * 10 + x % 10;
            x /= 10;
        }
        return y;
    }
}
```

```CSharp
public class Solution {
    public int MinMirrorPairDistance(int[] nums) {
        Dictionary<int, int> prev = new Dictionary<int, int>();
        int n = nums.Length;
        int ans = n + 1;

        for (int i = 0; i < n; i++) {
            int x = nums[i];
            if (prev.ContainsKey(x)) {
                ans = Math.Min(ans, i - prev[x]);
            }
            prev[ReverseNum(x)] = i;
        }

        return ans == n + 1 ? -1 : ans;
    }

    private int ReverseNum(int x) {
        int y = 0;
        while (x > 0) {
            y = y * 10 + x % 10;
            x /= 10;
        }
        return y;
    }
}
```

```Go
func minMirrorPairDistance(nums []int) int {
    reverseNum := func(x int) int {
        y := 0
        for x > 0 {
            y = y*10 + x%10
            x /= 10
        }
        return y
    }

    prev := make(map[int]int)
    n := len(nums)
    ans := n + 1

    for i, x := range nums {
        if idx, exists := prev[x]; exists {
            if i-idx < ans {
                ans = i - idx
            }
        }
        prev[reverseNum(x)] = i
    }

    if ans == n+1 {
        return -1
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
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
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

int minMirrorPairDistance(int* nums, int numsSize) {
    int reverseNum(int x) {
        int y = 0;
        while (x > 0) {
            y = y * 10 + x % 10;
            x /= 10;
        }
        return y;
    }

    HashItem *prev = NULL;
    int ans = numsSize + 1;

    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];
        int prevIndex = hashGetItem(&prev, x, -1);
        if (prevIndex != -1) {
            int distance = i - prevIndex;
            if (distance < ans) {
                ans = distance;
            }
        }

        hashSetItem(&prev, reverseNum(x), i);
    }

    hashFree(&prev);

    return ans == numsSize + 1 ? -1 : ans;
}
```

```JavaScript
var minMirrorPairDistance = function(nums) {
    const reverseNum = (x) => {
        let y = 0;
        while (x > 0) {
            y = y * 10 + (x % 10);
            x = Math.floor(x / 10);
        }
        return y;
    };

    const prev = new Map();
    const n = nums.length;
    let ans = n + 1;

    for (let i = 0; i < n; i++) {
        const x = nums[i];
        if (prev.has(x)) {
            ans = Math.min(ans, i - prev.get(x));
        }
        prev.set(reverseNum(x), i);
    }

    return ans === n + 1 ? -1 : ans;
};
```

```TypeScript
function minMirrorPairDistance(nums: number[]): number {
    const reverseNum = (x: number): number => {
        let y = 0;
        while (x > 0) {
            y = y * 10 + (x % 10);
            x = Math.floor(x / 10);
        }
        return y;
    };

    const prev = new Map<number, number>();
    const n = nums.length;
    let ans = n + 1;

    for (let i = 0; i < n; i++) {
        const x = nums[i];
        if (prev.has(x)) {
            ans = Math.min(ans, i - prev.get(x)!);
        }
        prev.set(reverseNum(x), i);
    }

    return ans === n + 1 ? -1 : ans;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn min_mirror_pair_distance(nums: Vec<i32>) -> i32 {
        let reverse_num = |mut x: i32| -> i32 {
            let mut y = 0;
            while x > 0 {
                y = y * 10 + x % 10;
                x /= 10;
            }
            y
        };

        let mut prev = HashMap::new();
        let n = nums.len();
        let mut ans = n + 1;

        for (i, &x) in nums.iter().enumerate() {
            if let Some(&idx) = prev.get(&x) {
                ans = ans.min(i - idx);
            }
            prev.insert(reverse_num(x), i);
        }

        if ans == n + 1 {
            -1
        } else {
            ans as i32
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log C)$，其中 $n$ 是数组 $nums$ 的长度，$C$ 是数组 $nums$ 的元素范围。数组只需遍历一次，哈希表单次操作的平均复杂度为 $O(1)$，单次整数反转需要 $O(\log C)$ 的时间。
- 空间复杂度：$O(n)$，哈希表在最坏情况下需要存储 $n$ 个键值对。
