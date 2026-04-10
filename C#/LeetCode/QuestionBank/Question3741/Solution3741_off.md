### [三个相等元素之间的最小距离 II](https://leetcode.cn/problems/minimum-distance-between-three-equal-elements-ii/solutions/3941271/san-ge-xiang-deng-yuan-su-zhi-jian-de-zu-e15o/)

#### 方法一：遍历 $+$ 哈希表

**思路与算法**

分析题目可知，所求三元组的距离实际上是广义三角形的三边之和，不管选取的三个点顺序如何，长度一定等于两倍的端点构成的线段的长度；换而言之，设最右侧点的下标是 $k$，最左侧点的下标是 $i$，所求的距离就是 $2\times (k-i)$。

显然，对于所有相同元素对应下标构成的有效三元组，其最小距离必定在三个**相邻**元素构成的三元组间产生。以此为突破口，类比链表，我们可以通过维护前驱数组或者后继数组的方式快速求解当前元素的前驱和后继，以便计算距离并更新答案。

下面以后继数组为例讲解具体实现，采用前驱数组的方法只需要一次遍历，留给读者自行思考。

首先定义后继数组 $next$，设 $next[i]$ 记录了 $nums[i]$ 在 $nums$ 中下一次出现的位置。倒序遍历 $nums$，配合哈希表记录 $nums[i]$ 在倒序遍历中最近一次出现的位置，即可求出 $next$ 数组。

随后遍历 $nums$，借助 $next$ 数组，我们可以在 $O(1)$ 的时间内求出与 $nums[i]$ 值相同的两个相邻的后继元素，计算距离并更新答案即可。

**代码**

```C++
class Solution {
public:
    int minimumDistance(vector<int>& nums) {
        int n = nums.size();
        std::vector<int> next(n, -1);
        std::unordered_map<int, int> occur;
        int ans = n + 1;

        for (int i = n - 1; i >= 0; i--) {
            if (occur.count(nums[i])) {
                next[i] = occur[nums[i]];
            }
            occur[nums[i]] = i;
        }

        for (int i = 0; i < n; i++) {
            int secondPos = next[i];
            if (secondPos != -1) {
                int thirdPos = next[secondPos];
                if (thirdPos != -1) {
                    ans = std::min(ans, thirdPos - i);
                }
            }
        }

        return ans == n + 1 ? -1 : ans * 2;
    }
};
```

```JavaScript
var minimumDistance = function (nums) {
    const next = Array.from({ length: nums.length }).fill(-1);
    const occur = new Map();
    let ans = nums.length + 1;

    for (let i = nums.length - 1; i >= 0; i--) {
        if (occur.has(nums[i])) {
            next[i] = occur.get(nums[i]);
        }
        occur.set(nums[i], i);
    }

    for (let i = 0; i < nums.length; i++) {
        let secondPos = next[i];
        let thirdPos = next[secondPos];
        if (secondPos !== -1 && thirdPos !== -1) {
            ans = Math.min(ans, thirdPos - i);
        }
    }

    if (ans === nums.length + 1) {
        return -1;
    } else {
        return ans * 2;
    }
};
```

```TypeScript
function minimumDistance(nums: number[]): number {
    const next = Array.from<number>({ length: nums.length }).fill(-1);
    const occur = new Map<number, number>();
    let ans = nums.length + 1;

    for (let i = nums.length - 1; i >= 0; i--) {
        if (occur.has(nums[i])) {
            next[i] = occur.get(nums[i])!;
        }
        occur.set(nums[i], i);
    }

    for (let i = 0; i < nums.length; i++) {
        let secondPos = next[i];
        let thirdPos = next[secondPos];
        if (secondPos !== -1 && thirdPos !== -1) {
            ans = Math.min(ans, thirdPos - i);
        }
    }

    if (ans === nums.length + 1) {
        return -1;
    } else {
        return ans * 2;
    }
};
```

```Java
class Solution {
    public int minimumDistance(int[] nums) {
        int n = nums.length;
        int[] next = new int[n];
        Arrays.fill(next, -1);
        Map<Integer, Integer> occur = new HashMap<>();
        int ans = n + 1;

        for (int i = n - 1; i >= 0; i--) {
            if (occur.containsKey(nums[i])) {
                next[i] = occur.get(nums[i]);
            }
            occur.put(nums[i], i);
        }

        for (int i = 0; i < n; i++) {
            int secondPos = next[i];
            if (secondPos != -1) {
                int thirdPos = next[secondPos];
                if (thirdPos != -1) {
                    ans = Math.min(ans, thirdPos - i);
                }
            }
        }

        return ans == n + 1 ? -1 : ans * 2;
    }
}
```

```CSharp
public class Solution {
    public int MinimumDistance(int[] nums) {
        int n = nums.Length;
        int[] next = new int[n];
        Array.Fill(next, -1);
        Dictionary<int, int> occur = new();
        int ans = n + 1;

        for (int i = n - 1; i >= 0; i--) {
            if (occur.TryGetValue(nums[i], out int val)) {
                next[i] = val;
            }
            occur[nums[i]] = i;
        }

        for (int i = 0; i < n; i++) {
            int secondPos = next[i];
            if (secondPos != -1) {
                int thirdPos = next[secondPos];
                if (thirdPos != -1) {
                    ans = Math.Min(ans, thirdPos - i);
                }
            }
        }

        return ans == n + 1 ? -1 : ans * 2;
    }
}
```

```Go
func minimumDistance(nums []int) int {
    n := len(nums)
    next := make([]int, n)
    for i := range next {
        next[i] = -1
    }
    occur := make(map[int]int)
    ans := n + 1

    for i := n - 1; i >= 0; i-- {
        if val, ok := occur[nums[i]]; ok {
            next[i] = val
        }
        occur[nums[i]] = i
    }

    for i := 0; i < n; i++ {
        secondPos := next[i]
        if secondPos != -1 {
            thirdPos := next[secondPos]
            if thirdPos != -1 {
                if dist := thirdPos - i; dist < ans {
                    ans = dist
                }
            }
        }
    }

    if ans == n + 1 {
        return -1
    }
    return ans * 2
}
```

```Python
class Solution:
    def minimumDistance(self, nums: List[int]) -> int:
        n = len(nums)
        nxt = [-1] * n
        occur = {}
        ans = n + 1

        for i in range(n - 1, -1, -1):
            if nums[i] in occur:
                nxt[i] = occur[nums[i]]
            occur[nums[i]] = i

        for i in range(n):
            second_pos = nxt[i]
            if second_pos != -1:
                third_pos = nxt[second_pos]
                if third_pos != -1:
                    ans = min(ans, third_pos - i)

        return -1 if ans == n + 1 else ans * 2

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

int minimumDistance(int* nums, int numsSize) {
    int* next = (int*)malloc(numsSize * sizeof(int));
    for (int i = 0; i < numsSize; i++) {
        next[i] = -1;
    }

    HashItem* occur = NULL;
    int ans = numsSize + 1;

    for (int i = numsSize - 1; i >= 0; i--) {
        int prevPos = hashGetItem(&occur, nums[i], -1);
        if (prevPos != -1) {
            next[i] = prevPos;
        }
        hashSetItem(&occur, nums[i], i);
    }

    for (int i = 0; i < numsSize; i++) {
        int secondPos = next[i];
        if (secondPos != -1) {
            int thirdPos = next[secondPos];
            if (thirdPos != -1) {
                int distance = thirdPos - i;
                if (distance < ans) {
                    ans = distance;
                }
            }
        }
    }

    free(next);
    hashFree(&occur);

    return ans == numsSize + 1 ? - 1 : ans * 2;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn minimum_distance(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut next = vec![-1_isize; n];
        let mut occur = HashMap::new();
        let mut ans = n + 1;

        for i in (0..n).rev() {
            if let Some(&val) = occur.get(&nums[i]) {
                next[i] = val as isize;
            }
            occur.insert(nums[i], i);
        }

        for i in 0..n {
            let second_pos = next[i];
            if second_pos != -1 {
                let third_pos = next[second_pos as usize];
                if third_pos != -1 {
                    ans = ans.min(third_pos as usize - i);
                }
            }
        }

        if ans == n + 1 {
            -1
        } else {
            (ans * 2) as i32
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。倒序遍历构造 $next$ 数组和正序遍历求解答案各需要 $O(n)$，哈希表各项操作平均复杂度为 $O(1)$。
- 空间复杂度：$O(n)$，next 数组和哈希表需要 $O(n)$ 的空间。
