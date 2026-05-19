### [最小公共值](https://leetcode.cn/problems/minimum-common-value/solutions/3963830/zui-xiao-gong-gong-zhi-by-leetcode-solut-e4f5/)

#### 方法一：二分查找

**思路与算法**

由于两个数组都有序，可以在任何一个数组中二分查找另一个数组中的元素是否存在。

**代码**

```C++
class Solution {
public:
    int getCommon(vector<int>& nums1, vector<int>& nums2) {
        for (int num : nums1) {
            auto it = lower_bound(nums2.begin(), nums2.end(), num);
            if (it != nums2.end() && num == *it) {
                return num;
            }
        }
        return -1;
    }
};
```

```Java
class Solution {
    public int getCommon(int[] nums1, int[] nums2) {
        for (int num : nums1) {
            int idx = lowerBound(nums2, num);
            if (idx < nums2.length && nums2[idx] == num) {
                return num;
            }
        }
        return -1;
    }

    private int lowerBound(int[] nums, int target) {
        int left = 0, right = nums.length;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```Python
class Solution:
    def getCommon(self, nums1: list[int], nums2: list[int]) -> int:
        def lower_bound(arr: list[int], target: int) -> int:
            left, right = 0, len(arr)
            while left < right:
                mid = (left + right) // 2
                if arr[mid] < target:
                    left = mid + 1
                else:
                    right = mid
            return left

        for num in nums1:
            i = lower_bound(nums2, num)
            if i < len(nums2) and nums2[i] == num:
                return num
        return -1
```

```Go
func getCommon(nums1 []int, nums2 []int) int {
    for _, num := range nums1 {
        idx := lowerBound(nums2, num)
        if idx < len(nums2) && nums2[idx] == num {
            return num
        }
    }
    return -1
}

func lowerBound(nums []int, target int) int {
    left, right := 0, len(nums)
    for left < right {
        mid := left + (right-left)/2
        if nums[mid] < target {
            left = mid + 1
        } else {
            right = mid
        }
    }
    return left
}
```

```CSharp
public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        foreach (int num in nums1) {
            if (System.Array.BinarySearch(nums2, num) >= 0) {
                return num;
            }
        }
        return -1;
    }
}
```

```C
static int lowerBound(const int* nums, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (nums[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

int getCommon(int* nums1, int nums1Size, int* nums2, int nums2Size) {
    for (int i = 0; i < nums1Size; i++) {
        int idx = lowerBound(nums2, nums2Size, nums1[i]);
        if (idx < nums2Size && nums2[idx] == nums1[i]) {
            return nums1[i];
        }
    }
    return -1;
}
```

```JavaScript
var getCommon = function(nums1, nums2) {
    const lowerBound = (arr, target) => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = left + ((right - left) >> 1);
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    for (const num of nums1) {
        const idx = lowerBound(nums2, num);
        if (idx < nums2.length && nums2[idx] === num) {
            return num;
        }
    }
    return -1;
};
```

```TypeScript
function lowerBound(arr: number[], target: number): number {
    let left = 0, right = arr.length;
    while (left < right) {
        const mid = left + ((right - left) >> 1);
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

function getCommon(nums1: number[], nums2: number[]): number {
    for (const num of nums1) {
        const idx = lowerBound(nums2, num);
        if (idx < nums2.length && nums2[idx] === num) {
            return num;
        }
    }
    return -1;
}
```

```Rust
impl Solution {
    pub fn get_common(nums1: Vec<i32>, nums2: Vec<i32>) -> i32 {
        for num in nums1.iter() {
            if nums2.binary_search(num).is_ok() {
                return *num;
            }
        }
        -1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log m)$，其中 $n$ 和 $m$ 分别是 $nums_1$ 和 $nums_2$ 的长度。对于 $nums_1$ 中的每个元素都在 $nums_2$ 中进行一次二分查找，二分查找的复杂度为 $O(\log m)$。
- 空间复杂度：$O(1)$。仅使用常数个变量。

#### 方法二：哈希集合

**思路与算法**

我们可以将某一个数组中的所有元素都插入到哈希集合中，然后查找另一个数组中的元素是否存在。

**代码**

```C++
class Solution {
public:
    int getCommon(vector<int>& nums1, vector<int>& nums2) {
        unordered_map<int, int> mp;
        for (int num : nums1) {
            mp[num]++;
        }
        for (int num : nums2) {
            if (mp[num]) {
                return num;
            }
        }
        return -1;
    }
};
```

```Java
class Solution {
    public int getCommon(int[] nums1, int[] nums2) {
        java.util.HashSet<Integer> set = new java.util.HashSet<>();
        for (int num : nums1) {
            set.add(num);
        }
        for (int num : nums2) {
            if (set.contains(num)) {
                return num;
            }
        }
        return -1;
    }
}
```

```Python
class Solution:
    def getCommon(self, nums1: list[int], nums2: list[int]) -> int:
        s = set(nums1)
        for num in nums2:
            if num in s:
                return num
        return -1
```

```Go
func getCommon(nums1 []int, nums2 []int) int {
    set := make(map[int]struct{}, len(nums1))
    for _, num := range nums1 {
        set[num] = struct{}{}
    }
    for _, num := range nums2 {
        if _, ok := set[num]; ok {
            return num
        }
    }
    return -1
}
```

```CSharp
public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        var set = new System.Collections.Generic.HashSet<int>();
        foreach (int num in nums1) {
            set.Add(num);
        }
        foreach (int num in nums2) {
            if (set.Contains(num)) {
                return num;
            }
        }
        return -1;
    }
}
```

```C
const int HASH_MULT = 1e9 + 7;

int getCommon(int* nums1, int nums1Size, int* nums2, int nums2Size) {
    const size_t target = (size_t)nums1Size * 2 + 1;
    size_t cap = 1;
    while (cap < target)
        cap <<= 1;
    size_t mask = cap - 1;

    int* table = (int*)malloc(sizeof(int) * cap);
    unsigned char* used = (unsigned char*)calloc(cap, 1);
    if (table == NULL || used == NULL) {
        free(table);
        free(used);
        return -1;
    }

    for (int i = 0; i < nums1Size; i++) {
        int v = nums1[i];
        size_t idx =
            (size_t)(((uint64_t)(uint32_t)v * HASH_MULT) & (uint64_t)mask);
        while (used[idx] && table[idx] != v) {
            idx = (idx + 1) & mask;
        }
        table[idx] = v;
        used[idx] = 1;
    }

    for (int i = 0; i < nums2Size; i++) {
        int v = nums2[i];
        size_t idx =
            (size_t)(((uint64_t)(uint32_t)v * HASH_MULT) & (uint64_t)mask);
        while (used[idx]) {
            if (table[idx] == v) {
                free(table);
                free(used);
                return v;
            }
            idx = (idx + 1) & mask;
        }
    }

    free(table);
    free(used);
    return -1;
}
```

```JavaScript
var getCommon = function(nums1, nums2) {
    const set = new Set(nums1);
    for (const num of nums2) {
        if (set.has(num)) {
            return num;
        }
    }
    return -1;
};
```

```TypeScript
function getCommon(nums1: number[], nums2: number[]): number {
    const set = new Set<number>(nums1);
    for (const num of nums2) {
        if (set.has(num)) {
            return num;
        }
    }
    return -1;
}
```

```Rust
impl Solution {
    pub fn get_common(nums1: Vec<i32>, nums2: Vec<i32>) -> i32 {
        let set: std::collections::HashSet<i32> = nums1.into_iter().collect();
        for num in nums2.into_iter() {
            if set.contains(&num) {
                return num;
            }
        }
        -1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 和 $m$ 分别是 $nums_1$ 和 $nums_2$ 的长度。插入哈希表需要 $O(n)$，在哈希表中查找需要 $O(m)$。
- 空间复杂度：$O(n)$。哈希表需要存储某一个数组中的所有元素。

#### 方法三：双指针

**思路与算法**

假设指针 $i$ 和 $j$ 分别是指向 $nums_1$ 和 $nums_2$ 中的某个元素的指针。由于两个数组都有序，对于 $nums_1$ 中的某一个元素 $nums_1[i]$，$nums_2$ 中所有小于 $nums_1[i]$ 的元素都不可能是答案，可以直接将 $j$ 向后移动，直到 $nums_2[j]\ge nums_1[i]$。此时比较 $nums_2[j]$ 是否等于 $nums_1[i]$，如果是则返回答案，如果不是就向后移动指针 $i$，重复这一过程。

**代码**

```C++
class Solution {
public:
    int getCommon(vector<int>& nums1, vector<int>& nums2) {
        int i = 0;
        int j = 0;
        while (i < nums1.length && j < nums2.length) {
            if (nums1[i] == nums2[j]) {
                return nums1[i];
            }
            if (nums1[i] < nums2[j]) {
                i++;
            } else {
                j++;
            }
        }
        return -1;
    }
};
```

```Java
class Solution {
    public int getCommon(int[] nums1, int[] nums2) {
        int i = 0;
        int j = 0;
        while (i < nums1.length && j < nums2.length) {
            if (nums1[i] == nums2[j]) {
                return nums1[i];
            }
            if (nums1[i] < nums2[j]) {
                i++;
            } else {
                j++;
            }
        }
        return -1;
    }
}
```

```Python
class Solution:
    def getCommon(self, nums1: List[int], nums2: List[int]) -> int:
        i = j = 0
        while i < len(nums1) and j < len(nums2):
            if nums1[i] == nums2[j]:
                return nums1[i]
            if nums1[i] < nums2[j]:
                i += 1
            else:
                j += 1
        return -1
```

```Go
func getCommon(nums1 []int, nums2 []int) int {
    i, j := 0, 0
    for i < len(nums1) && j < len(nums2) {
        if nums1[i] == nums2[j] {
            return nums1[i]
        }
        if nums1[i] < nums2[j] {
            i++
        } else {
            j++
        }
    }
    return -1
}
```

```CSharp
public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        int i = 0, j = 0;
        while (i < nums1.Length && j < nums2.Length) {
            if (nums1[i] == nums2[j]) {
                return nums1[i];
            }
            if (nums1[i] < nums2[j]) {
                i++;
            } else {
                j++;
            }
        }
        return -1;
    }
}
```

```C
int getCommon(int* nums1, int nums1Size, int* nums2, int nums2Size) {
    int i = 0, j = 0;
    while (i < nums1Size && j < nums2Size) {
        if (nums1[i] == nums2[j]) {
            return nums1[i];
        }
        if (nums1[i] < nums2[j]) {
            i++;
        } else {
            j++;
        }
    }
    return -1;
}
```

```JavaScript
var getCommon = function(nums1, nums2) {
    let i = 0, j = 0;
    while (i < nums1.length && j < nums2.length) {
        if (nums1[i] === nums2[j]) {
            return nums1[i];
        }
        if (nums1[i] < nums2[j]) {
            i++;
        } else {
            j++;
        }
    }
    return -1;
};
```

```TypeScript
function getCommon(nums1: number[], nums2: number[]): number {
    let i = 0, j = 0;
    while (i < nums1.length && j < nums2.length) {
        if (nums1[i] === nums2[j]) {
            return nums1[i];
        }
        if (nums1[i] < nums2[j]) {
            i++;
        } else {
            j++;
        }
    }
    return -1;
}
```

```Rust
impl Solution {
    pub fn get_common(nums1: Vec<i32>, nums2: Vec<i32>) -> i32 {
        let mut i: usize = 0;
        let mut j: usize = 0;
        while i < nums1.len() && j < nums2.len() {
            let a = nums1[i];
            let b = nums2[j];
            if a == b {
                return a;
            }
            if a < b {
                i += 1;
            } else {
                j += 1;
            }
        }
        -1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 和 $m$ 分别是 $nums_1$ 和 $nums_2$ 的长度。只需要遍历数组一次。
- 空间复杂度：$O(1)$。仅使用常数个变量。
