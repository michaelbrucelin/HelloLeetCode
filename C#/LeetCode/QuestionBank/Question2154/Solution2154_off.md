### [将找到的值乘以 2](https://leetcode.cn/problems/keep-multiplying-found-values-by-two/solutions/1249143/jiang-zhao-dao-de-zhi-cheng-yi-2-by-leet-blv4/)

#### 方法一：排序

**思路与算法**

如果我们不对数组 $nums$ 进行任何操作，那么每次更新 $original$ 后，都需要 $O(n)$ 的时间完整遍历一遍。最终时间复杂度为 $O(n^2)$。

我们可以对这一过程进行优化。具体而言，每次在数组中找到 $original$ 后，$original$ 的数值都会比更新前更大，因此我们可以先将数组 $nums$ **升序排序**，这样每次更新后的 $original$ 数值在数组中的位置（如有）只可能位于更新前的后面，我们只需要一边**从左至右遍历**排序后的 $nums$ 数组一边尝试更新 $original$ 即可。

**代码**

```C++
class Solution {
public:
    int findFinalValue(vector<int>& nums, int original) {
        sort(nums.begin(), nums.end());
        for (int num: nums) {
            if (original == num) {
                original *= 2;
            }
        }
        return original;
    }
};
```

```Python
class Solution:
    def findFinalValue(self, nums: List[int], original: int) -> int:
        nums.sort()
        for num in nums:
            if num == original:
                original *= 2
        return original
```

```Java
class Solution {
    public int findFinalValue(int[] nums, int original) {
        Arrays.sort(nums);
        for (int num : nums) {
            if (original == num) {
                original *= 2;
            }
        }
        return original;
    }
}
```

```CSharp
public class Solution {
    public int FindFinalValue(int[] nums, int original) {
        Array.Sort(nums);
        foreach (int num in nums) {
            if (original == num) {
                original *= 2;
            }
        }
        return original;
    }
}
```

```Go
func findFinalValue(nums []int, original int) int {
    sort.Ints(nums)
    for _, num := range nums {
        if original == num {
            original *= 2
        }
    }
    return original
}
```

```C
int cmp(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int findFinalValue(int* nums, int numsSize, int original) {
    qsort(nums, numsSize, sizeof(int), cmp);
    for (int i = 0; i < numsSize; i++) {
        if (original == nums[i]) {
            original *= 2;
        }
    }
    return original;
}
```

```JavaScript
var findFinalValue = function(nums, original) {
    nums.sort((a, b) => a - b);
    for (const num of nums) {
        if (original === num) {
            original *= 2;
        }
    }
    return original;
};
```

```TypeScript
function findFinalValue(nums: number[], original: number): number {
    nums.sort((a, b) => a - b);
    for (const num of nums) {
        if (original === num) {
            original *= 2;
        }
    }
    return original;
}
```

```Rust
impl Solution {
    pub fn find_final_value(nums: Vec<i32>, original: i32) -> i32 {
        let mut nums = nums;
        nums.sort();
        let mut original = original;
        for &num in nums.iter() {
            if original == num {
                original *= 2;
            }
        }
        original
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 为 $nums$ 的长度。排序的时间复杂度为 $O(n\log n)$，遍历更新 $original$ 的时间复杂度最多为 $O(n)$。
- 空间复杂度：$O(\log n)$，即为排序的栈空间开销。

#### 方法二：哈希表

**思路与算法**

我们还可以采用更加直接地利用空间换取时间的方法：利用哈希集合存储数组 $nums$ 中的元素，然后我们只需要每次判断 $original$ 是否位于该哈希集合中即可。具体地：

- 如果 $original$ 位于哈希集合中，我们将 $original$ 乘以 $2$，然后再次判断；
- 如果 $original$ 不位于哈希集合中，那么循环结束，我们返回当前的 $original$ 作为答案。

**代码**

```C++
class Solution {
public:
    int findFinalValue(vector<int>& nums, int original) {
        unordered_set<int> s(nums.begin(), nums.end());
        while (s.count(original)) {
            original *= 2;
        }
        return original;
    }
};
```

```Python
class Solution:
    def findFinalValue(self, nums: List[int], original: int) -> int:
        s = set(nums)
        while original in s:
            original *= 2
        return original
```

```Java
class Solution {
    public int findFinalValue(int[] nums, int original) {
        Set<Integer> set = new HashSet<>();
        for (int num : nums) {
            set.add(num);
        }
        while (set.contains(original)) {
            original *= 2;
        }
        return original;
    }
}
```

```CSharp
public class Solution {
    public int FindFinalValue(int[] nums, int original) {
        HashSet<int> set = new HashSet<int>(nums);
        while (set.Contains(original)) {
            original *= 2;
        }
        return original;
    }
}
```

```Go
func findFinalValue(nums []int, original int) int {
    set := make(map[int]bool)
    for _, num := range nums {
        set[num] = true
    }
    for set[original] {
        original *= 2
    }
    return original
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

int findFinalValue(int* nums, int numsSize, int original) {
    HashItem *set = NULL;
    for (int i = 0; i < numsSize; i++) {
        hashAddItem(&set, nums[i]);
    }
    while (hashFindItem(&set, original)) {
        original *= 2;
    }
    hashFree(&set);
    return original;
}
```

```JavaScript
var findFinalValue = function(nums, original) {
    const set = new Set(nums);
    while (set.has(original)) {
        original *= 2;
    }
    return original;
};
```

```TypeScript
function findFinalValue(nums: number[], original: number): number {
    const set = new Set(nums);
    while (set.has(original)) {
        original *= 2;
    }
    return original;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn find_final_value(nums: Vec<i32>, original: i32) -> i32 {
        let set: HashSet<_> = nums.into_iter().collect();
        let mut original = original;
        while set.contains(&original) {
            original *= 2;
        }
        original
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $nums$ 的长度。遍历数组维护元素哈希集合的时间复杂度为 $O(n)$，遍历更新 $original$ 的时间复杂度最多为 $O(n)$。
- 空间复杂度：$O(n)$，即为元素哈希集合的空间开销。
