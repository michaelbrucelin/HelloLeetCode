### [检查数组是否是好的](https://leetcode.cn/problems/check-if-array-is-good/solutions/3963828/jian-cha-shu-zu-shi-fou-shi-hao-de-by-le-19zt/)

#### 方法一：排序

**思路与算法**

将数组进行排序，随后遍历前 $n$ 个元素，比对是否等于 $i+1$，最后检查末尾元素是否等于 $n$ 即可。

**代码**

```C++
class Solution {
public:
    bool isGood(vector<int>& nums) {
        sort(nums.begin(), nums.end());
        int n = nums.size() - 1;
        for (int i = 0; i < n; ++i) {
            if (nums[i] != i + 1) {
                return false;
            }
        }
        return nums[n] == n;
    }
};
```

```Java
class Solution {
    public boolean isGood(int[] nums) {
        Arrays.sort(nums);
        int n = nums.length - 1;
        for (int i = 0; i < n; i++) {
            if (nums[i] != i + 1) {
                return false;
            }
        }
        return nums[n] == n;
    }
}
```

```Python
class Solution:
    def isGood(self, nums: List[int]) -> bool:
        nums.sort()
        n = len(nums) - 1
        for i in range(n):
            if nums[i] != i + 1:
                return False
        return nums[n] == n
```

```JavaScript
var isGood = function(nums) {
    nums.sort((a, b) => a - b);
    const n = nums.length - 1;
    for (let i = 0; i < n; i++) {
        if (nums[i] !== i + 1) {
            return false;
        }
    }
    return nums[n] === n;
};
```

```TypeScript
function isGood(nums: number[]): boolean {
    nums.sort((a, b) => a - b);
    const n = nums.length - 1;
    for (let i = 0; i < n; i++) {
        if (nums[i] !== i + 1) {
            return false;
        }
    }
    return nums[n] === n;
};
```

```Go
func isGood(nums []int) bool {
    sort.Ints(nums)
    n := len(nums) - 1
    for i := 0; i < n; i++ {
        if nums[i] != i + 1 {
            return false
        }
    }
    return nums[n] == n
}
```

```CSharp
public class Solution {
    public bool IsGood(int[] nums) {
        Array.Sort(nums);
        int n = nums.Length - 1;
        for (int i = 0; i < n; i++) {
            if (nums[i] != i + 1) {
                return false;
            }
        }
        return nums[n] == n;
    }
}
```

```C
int cmp(const void *a, const void *b) {
    return (*(int*)a - *(int*)b);
}

bool isGood(int* nums, int numsSize) {
    qsort(nums, numsSize, sizeof(int), cmp);
    int n = numsSize - 1;
    for (int i = 0; i < n; i++) {
        if (nums[i] != i + 1) {
            return false;
        }
    }
    return nums[n] == n;
}
```

```Rust
impl Solution {
    pub fn is_good(nums: Vec<i32>) -> bool {
        let mut nums = nums;
        nums.sort_unstable();
        let n = nums.len() - 1;
        for i in 0..n {
            if nums[i] != (i + 1) as i32 {
                return false;
            }
        }
        nums[n] == n as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(\log n)$，其中 $n$ 是数组的长度。

#### 方法二：统计频数

**思路与算法**

遍历数组，使用数组来统计每个元素出现的次数。

在遍历统计的过程中，如发现有超过 $n$ 的数，就可以提前判断为不符合并返回。数字 $n$，出现的次数不能超过 $2$ 次。其它数字，出现的次数不能超过 $1$ 次。否则提前判断为不符合并返回。

若全部满足，则说明它是好数组，并返回结果。

**代码**

```C++
class Solution {
public:
    bool isGood(vector<int>& nums) {
        int n = nums.size();
        vector<int> count(n, 0);
        for (int a : nums) {
            if (a >= n) {
                return false;
            }
            if (a < n - 1 && count[a] > 0) {
                return false;
            }
            if (a == n - 1 && count[a] > 1) {
                return false;
            }
            count[a]++;
        }
        return true;
    }
};
```

```Java
class Solution {
    public boolean isGood(int[] nums) {
        int n = nums.length;
        int[] count = new int[n];
        for (int a : nums) {
            if (a >= n) {
                return false;
            }
            if (a < n - 1 && count[a] > 0) {
                return false;
            }
            if (a == n - 1 && count[a] > 1) {
                return false;
            }
            count[a]++;
        }
        return true;
    }
}
```

```Python
class Solution:
    def isGood(self, nums: List[int]) -> bool:
        n = len(nums)
        count = [0] * n
        for a in nums:
            if a >= n:
                return False
            if a < n - 1 and count[a] > 0:
                return False
            if a == n - 1 and count[a] > 1:
                return False
            count[a] += 1
        return True
```

```JavaScript
var isGood = function(nums) {
    const n = nums.length;
    const count = new Array(n).fill(0);
    for (const a of nums) {
        if (a >= n) {
            return false;
        }
        if (a < n - 1 && count[a] > 0) {
            return false;
        }
        if (a === n - 1 && count[a] > 1) {
            return false;
        }
        count[a]++;
    }
    return true;
};
```

```TypeScript
function isGood(nums: number[]): boolean {
    const n = nums.length;
    const count = new Array(n).fill(0);
    for (const a of nums) {
        if (a >= n) {
            return false;
        }
        if (a < n - 1 && count[a] > 0) {
            return false;
        }
        if (a === n - 1 && count[a] > 1) {
            return false;
        }
        count[a]++;
    }
    return true;
};
```

```Go
func isGood(nums []int) bool {
    n := len(nums)
    count := make([]int, n)
    for _, a := range nums {
        if a < 1 || a >= n {
            return false
        }
        if a < n - 1 && count[a] > 0 {
            return false
        }
        if a == n - 1 && count[a] > 1 {
            return false
        }
        count[a]++
    }
    return true
}
```

```CSharp
public class Solution {
    public bool IsGood(int[] nums) {
        int n = nums.Length;
        int[] count = new int[n];
        foreach (int a in nums) {
            if (a < 1 || a >= n) {
                return false;
            }
            if (a < n - 1 && count[a] > 0) {
                return false;
            }
            if (a == n - 1 && count[a] > 1) {
                return false;
            }
            count[a]++;
        }
        return true;
    }
}
```

```C
bool isGood(int* nums, int numsSize) {
    int n = numsSize;
    int* count = (int*)calloc(n, sizeof(int));
    for (int i = 0; i < n; i++) {
        int a = nums[i];
        if (a < 1 || a >= n) {
            free(count);
            return false;
        }
        if (a < n - 1 && count[a] > 0) {
            free(count);
            return false;
        }
        if (a == n - 1 && count[a] > 1) {
            free(count);
            return false;
        }
        count[a]++;
    }
    free(count);
    return true;
}
```

```Rust
impl Solution {
    pub fn is_good(nums: Vec<i32>) -> bool {
        let n = nums.len() as i32;
        let mut count = vec![0; n as usize];
        for &a in nums.iter() {
            if a < 1 || a >= n {
                return false;
            }
            if a < n - 1 && count[a as usize] > 0 {
                return false;
            }
            if a == n - 1 && count[a as usize] > 1 {
                return false;
            }
            count[a as usize] += 1;
        }
        true
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度。
