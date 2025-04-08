### [使数组元素互不相同所需的最少操作次数](https://leetcode.cn/problems/minimum-number-of-operations-to-make-elements-in-array-distinct/solutions/3634685/shi-shu-zu-yuan-su-hu-bu-xiang-tong-suo-cay1s/)

#### 方法一：模拟

**思路与算法**

题目要求执行操作使得数组中的剩余元素是否互不相同，最直接的方法即每次从数组开头跳过 $3$ 个元素，并检测数组中剩余元素是否存在重复元素，我们可以用一个哈希表来检测数组是否存在重复元素即可。

**代码**

```C++
class Solution {
public:
    int minimumOperations(vector<int>& nums) {
        auto checkUnique = [&](int start) {
            unordered_set<int> seen;
            for (int i = start; i < nums.size(); i++) {
                if (seen.count(nums[i])) {
                    return false;
                }
                seen.emplace(nums[i]);
            }
            return true;
        };

        int ans = 0;
        for (int i = 0; i < nums.size(); i += 3, ans++) {
            if (checkUnique(i)) {
                return ans;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int minimumOperations(int[] nums) {
        int ans = 0;
        for (int i = 0; i < nums.length; i += 3, ans++) {
            if (checkUnique(nums, i)) {
                return ans;
            }
        }
        return ans;
    }

    private boolean checkUnique(int[] nums, int start) {
        HashSet<Integer> cnt = new HashSet<>();
        for (int i = start; i < nums.length; i++) {
            if (cnt.contains(nums[i])) {
                return false;
            }
            cnt.add(nums[i]);
        }
        return true;
    }
}
```

```CSharp
public class Solution {
     public int MinimumOperations(int[] nums) {
        int ans = 0;
        for (int i = 0; i < nums.Length; i += 3, ans++) {
            if (CheckUnique(nums, i)) {
                return ans;
            }
        }
        return ans;
    }

    private bool CheckUnique(int[] nums, int start) {
        HashSet<int> seen = new HashSet<int>();
        for (int i = start; i < nums.Length; i++) {
            if (seen.Contains(nums[i])) {
                return false;
            }
            seen.Add(nums[i]);
        }
        return true;
    }
}
```

```Go
func minimumOperations(nums []int) int {
    ans := 0
    for i := 0; i < len(nums); i += 3 {
        if checkUnique(nums, i) {
            return ans
        }
        ans++
    }
    return ans
}

func checkUnique(nums []int, start int) bool {
    seen := make(map[int]struct{})
    for i := start; i < len(nums); i++ {
        if _, exists := seen[nums[i]]; exists {
            return false
        }
        seen[nums[i]] = struct{}{}
    }
    return true
}
```

```Python
class Solution:
    def minimumOperations(self, nums: List[int]) -> int:
        def check_unique(start):
            seen = set()
            for num in nums[start:]:
                if num in seen:
                    return False
                seen.add(num)
            return True

        ans = 0
        for i in range(0, len(nums), 3):
            if check_unique(i):
                return ans
            ans += 1
        return ans
```

```C
bool checkUnique(int* nums, int numsSize, int start) {
    int seen[128] = {0};
    for (int i = start; i < numsSize; i++) {
        if (seen[nums[i]]) {
            return false;
        }
        seen[nums[i]] = true;
    }
    return true;
}

int minimumOperations(int* nums, int numsSize) {
    int ans = 0;
    for (int i = 0; i < numsSize; i += 3, ans++) {
        if (checkUnique(nums, numsSize, i)) {
            return ans;
        }
    }
    return ans;
}
```

```JavaScript
var minimumOperations = function(nums) {
    let ans = 0;
    for (let i = 0; i < nums.length; i += 3, ans++) {
        if (checkUnique(nums, i)) {
            return ans;
        }
    }
    return ans;
};

const checkUnique = (nums, start) => {
    let seen = new Set();
    for (let i = start; i < nums.length; i++) {
        if (seen.has(nums[i])) {
            return false;
        }
        seen.add(nums[i]);
    }
    return true;
}
```

```TypeScript
function minimumOperations(nums: number[]): number {
    let ans = 0;
    for (let i = 0; i < nums.length; i += 3, ans++) {
        if (checkUnique(nums, i)) {
            return ans;
        }
    }
    return ans;
};

function checkUnique(nums: number[], start: number): boolean {
    let seen = new Set<number>();
    for (let i = start; i < nums.length; i++) {
        if (seen.has(nums[i])) {
            return false;
        }
        seen.add(nums[i]);
    }
    return true;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn minimum_operations(nums: Vec<i32>) -> i32 {
        let mut ans = 0;
        let check_unique = |start: usize| -> bool {
            let mut seen = HashSet::new();
            for &num in &nums[start..] {
                if seen.contains(&num) {
                    return false;
                }
                seen.insert(num);
            }
            true
        };

        for i in (0..nums.len()).step_by(3) {
            if check_unique(i) {
                return ans;
            }
            ans += 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，$n$ 表示给定数组 $nums$ 的长度。每次检测剩余的数组中是否存在重复元素，需要时间最多为 $O(n)$，一共最多需要检测 $n$ 次，因此总的时间为 $O(n^2)$。
- 空间复杂度：$O(n)$，$n$ 表示给定数组 $nums$ 的长度。每次检测数组是否含有重复元素时，需要用哈希表记录已经出现的元素，最多存在 $n$ 个元素需要记录，因此需要的空间为 $O(n)$。

#### 方法二：倒序遍历

**思路与算法**

假设重复元素 $x$ 在数组索引 $i,j$ 处出现，若此时满足 $i<j$，则至少需要移除索引 $i$ 之前所有的元素，则此时问题转换为求数组满足所有元素互不相同的最长后缀。由于每次需要移除 $3$ 个元素，此时移除索引 $i$ 之前的所有元素 $nums[0 \cdots i]$，至少需要 $\lceil \dfrac{i+1}{3}​ \rceil = \lfloor \dfrac{i}{3}​ \rfloor +1$ 次移除**操作**。

假设数组长度为 $n$，我们尝试倒序遍历数组，同时用 $seen$ 记录已经出现的元素，当遍历到第一个重复元素 $nums[i]$ 时，即该元素已经在当前的后缀中存在，此时返回最少操作次数 $\lfloor \dfrac{i}{3}​ \rfloor +1$，如果数组中不存在重复元素，则返回 $0$。

**代码**

```C++
class Solution {
public:
    int minimumOperations(vector<int>& nums) {
        vector<bool> seen(128);
        for (int i = nums.size() - 1; i >= 0; i--) {
            if (seen[nums[i]]) {
                return i / 3 + 1;
            }
            seen[nums[i]] = true;
        }
        return 0;
    }
};
```

```Java
class Solution {
    public int minimumOperations(int[] nums) {
        boolean[] seen = new boolean[128];
        for (int i = nums.length - 1; i >= 0; i--) {
            if (seen[nums[i]]) {
                return i / 3 + 1;
            }
            seen[nums[i]] = true;
        }
        return 0;
    }
}
```

```CSharp
public class Solution {
    public int MinimumOperations(int[] nums) {
        bool[] seen = new bool[128];
        for (int i = nums.Length - 1; i >= 0; i--) {
            if (seen[nums[i]]) {
                return i / 3 + 1;
            }
            seen[nums[i]] = true;
        }
        return 0;
    }
}
```

```Go
func minimumOperations(nums []int) int {
    seen := make([]bool, 128)
    for i := len(nums) - 1; i >= 0; i-- {
        if seen[nums[i]] {
            return i/3 + 1
        }
        seen[nums[i]] = true
    }
    return 0
}
```

```Python
class Solution:
    def minimumOperations(self, nums: List[int]) -> int:
        seen = [False] * 128
        for i in range(len(nums) - 1, -1, -1):
            if seen[nums[i]]:
                return i // 3 + 1
            seen[nums[i]] = True
        return 0
```

```C
int minimumOperations(int* nums, int numsSize) {
    int seen[128] = {0};
    for (int i = numsSize - 1; i >= 0; i--) {
        if (seen[nums[i]]) {
            return i / 3 + 1;
        }
        seen[nums[i]] = true;
    }
    return 0;
}
```

```JavaScript
var minimumOperations = function(nums) {
    const seen = new Array(128).fill(false);
    for (let i = nums.length - 1; i >= 0; i--) {
        if (seen[nums[i]]) {
            return Math.floor(i / 3) + 1;
        }
        seen[nums[i]] = true;
    }
    return 0;
};
```

```TypeScript
function minimumOperations(nums: number[]): number {
    const seen: boolean[] = new Array(128).fill(false);
    for (let i = nums.length - 1; i >= 0; i--) {
        if (seen[nums[i]]) {
            return Math.floor(i / 3) + 1;
        }
        seen[nums[i]] = true;
    }
    return 0;
};
```

```Rust
impl Solution {
    pub fn minimum_operations(nums: Vec<i32>) -> i32 {
        let mut seen = [false; 128];
        for i in (0..nums.len()).rev() {
            let num = nums[i] as usize;
            if seen[num] {
                return (i as i32) / 3 + 1;
            }
            seen[num] = true;
        }
        0
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，$n$ 表示给定数组 $nums$ 的长度。只需遍历一遍数组即可，需要的时间为 $O(n)$。
- 空间复杂度：$O(n)$，$n$ 表示给定数组 $nums$ 的长度。需要使用哈希表保存已经遍历过的数据，最多需要保存 $n$ 个元素，需要的空间为 $O(n)$。
