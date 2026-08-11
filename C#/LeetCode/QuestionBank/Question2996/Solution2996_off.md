### [大于等于顺序前缀和的最小缺失整数]()

#### 方法一：模拟 + 前缀和

**思路与算法**

从 $0$ 开始顺序遍历 $nums$，按题目定义找到最长的顺序前缀，同时计算前缀和，遇到第一个不满足顺序前缀定义的位置就可以跳出循环。然后以该前缀和为起点，递增寻找第一个不存在于 $nums$ 中的数字即为所求。

寻找不在 $nums$ 中出现过的数字时，我们使用 $nums$ 构造哈希表，即可快速判断一个数是否在 $nums$ 中出现过。

**代码**

```C++
class Solution {
public:
    int missingInteger(std::vector<int>& nums) {
        int n = nums.size();
        std::unordered_set<int> num_set(nums.begin(), nums.end());
        int total = nums[0];

        for (int i = 1; i < n; i++) {
            if (nums[i] == nums[i - 1] + 1) {
                total += nums[i];
            } else {
                break;
            }
        }

        while (num_set.count(total)) {
            total += 1;
        }

        return total;
    }
};
```

```C
int missingInteger(int* nums, int numsSize) {
    int total = nums[0];

    for (int i = 1; i < numsSize; i++) {
        if (nums[i] == nums[i - 1] + 1) {
            total += nums[i];
        } else {
            break;
        }
    }

    bool found = true;

    while (found) {
        found = false;
        for (int i = 0; i < numsSize; i++) {
            if (nums[i] == total) {
                found = true;
                total += 1;
                break;
            }
        }
    }

    return total;
}
```

```Java
class Solution {
    public int missingInteger(int[] nums) {
        int n = nums.length;
        Set<Integer> numSet = new HashSet<>(n);
        for (int num : nums) {
            numSet.add(num);
        }
        int total = nums[0];

        for (int i = 1; i < n; i++) {
            if (nums[i] == nums[i - 1] + 1) {
                total += nums[i];
            } else {
                break;
            }
        }

        while (numSet.contains(total)) {
            total += 1;
        }

        return total;
    }
}
```

```CSharp
public class Solution {
    public int MissingInteger(int[] nums) {
        int n = nums.Length;
        HashSet<int> numSet = new HashSet<int>(nums);
        int total = nums[0];

        for (int i = 1; i < n; i++) {
            if (nums[i] == nums[i - 1] + 1) {
                total += nums[i];
            } else {
                break;
            }
        }

        while (numSet.Contains(total)) {
            total += 1;
        }

        return total;
    }
}
```

```Python
class Solution:
    def missingInteger(self, nums: list[int]) -> int:
        total = nums[0]

        for a, b in pairwise(nums):
            if b == a + 1:
                total += b
            else:
                break

        num_set = set(nums)

        while total in num_set:
            total += 1

        return total

```

```Go
func missingInteger(nums []int) int {
	n := len(nums)
	numSet := make(map[int]bool, n)
	for _, num := range nums {
		numSet[num] = true
	}
	total := nums[0]

	for i := 1; i < n; i++ {
		if nums[i] == nums[i-1]+1 {
			total += nums[i]
		} else {
			break
		}
	}

	for numSet[total] {
		total += 1
	}

	return total
}
```

```JavaScript
var missingInteger = function(nums) {
    const n = nums.length;
    const numSet = new Set(nums);
    let total = nums[0];

    for (let i = 1; i < n; i++) {
        if (nums[i] === nums[i - 1] + 1) {
            total += nums[i];
        } else {
            break;
        }
    }

    while (numSet.has(total)) {
        total += 1;
    }

    return total;
};
```

```Typescript
function missingInteger(nums: number[]): number {
    const n = nums.length;
    const numSet = new Set(nums);
    let total = nums[0];

    for (let i = 1; i < n; i++) {
        if (nums[i] === nums[i - 1] + 1) {
            total += nums[i];
        } else {
            break;
        }
    }

    while (numSet.has(total)) {
        total += 1;
    }

    return total;
};
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn missing_integer(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let num_set: HashSet<&i32> = nums.iter().collect();
        let mut total = nums[0];

        for i in 1..n {
            if nums[i] == nums[i - 1] + 1 {
                total += nums[i];
            } else {
                break;
            }
        }

        while num_set.contains(&total) {
            total += 1;
        }

        total
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。寻找顺序前缀需要 $O(n)$，遍历寻找第一个不存在于 $nums$ 中的数需要 $O(n)$。
- 空间复杂度：$O(n)$，使用哈希表判定存在性需要 $O(n)$ 的辅助空间。

#### 方法二：模拟 + 数列求和公式

**思路与算法**

思路基本同方法一，因为题目所求的前缀是一个步长为一的整数递增数列，故可以不提前统计前缀和，而是使用数列求和公式来计算。

**代码**

```C++
class Solution {
public:
    int missingInteger(std::vector<int>& nums) {
        int n = nums.size();
        std::unordered_set<int> num_set(nums.begin(), nums.end());
        int prefix_len = 1;

        for (int i = 1; i < n; i++) {
            if (nums[i] == nums[i - 1] + 1) {
                prefix_len += 1;
            } else {
                break;
            }
        }

        int total = (nums[prefix_len - 1] + nums[0]) * prefix_len / 2;
        while (num_set.count(total)) {
            total += 1;
        }

        return total;
    }
};
```

```C
int missingInteger(int* nums, int numsSize) {
    int prefix_len = 1;

    for (int i = 1; i < numsSize; i++) {
        if (nums[i] == nums[i - 1] + 1) {
            prefix_len += 1;
        } else {
            break;
        }
    }

    int total = (nums[prefix_len - 1] + nums[0]) * prefix_len / 2;
    bool found = true;

    while (found) {
        found = false;
        for (int i = 0; i < numsSize; i++) {
            if (nums[i] == total) {
                found = true;
                total += 1;
                break;
            }
        }
    }

    return total;
}
```

```Java
class Solution {
    public int missingInteger(int[] nums) {
        int n = nums.length;
        Set<Integer> numSet = new HashSet<>(n);
        for (int num : nums) {
            numSet.add(num);
        }
        int prefixLen = 1;

        for (int i = 1; i < n; i++) {
            if (nums[i] == nums[i - 1] + 1) {
                prefixLen += 1;
            } else {
                break;
            }
        }

        int total = (nums[prefixLen - 1] + nums[0]) * prefixLen / 2;
        while (numSet.contains(total)) {
            total += 1;
        }

        return total;
    }
}
```

```CSharp
public class Solution {
    public int MissingInteger(int[] nums) {
        int n = nums.Length;
        HashSet<int> numSet = new HashSet<int>(nums);
        int prefixLen = 1;

        for (int i = 1; i < n; i++) {
            if (nums[i] == nums[i - 1] + 1) {
                prefixLen += 1;
            } else {
                break;
            }
        }

        int total = (nums[prefixLen - 1] + nums[0]) * prefixLen / 2;
        while (numSet.Contains(total)) {
            total += 1;
        }

        return total;
    }
}
```

```Python
class Solution:
    def missingInteger(self, nums: list[int]) -> int:
        prefix_len = 1
        num_set = set(nums)

        for prev, curr in zip(nums, nums[1:]):
            if curr == prev + 1:
                prefix_len += 1
            else:
                break

        total = (nums[prefix_len - 1] + nums[0]) * prefix_len // 2
        while total in num_set:
            total += 1

        return total

```

```Go
func missingInteger(nums []int) int {
	n := len(nums)
	numSet := make(map[int]bool, n)
	for _, num := range nums {
		numSet[num] = true
	}
	prefixLen := 1

	for i := 1; i < n; i++ {
		if nums[i] == nums[i-1]+1 {
			prefixLen += 1
		} else {
			break
		}
	}

	total := (nums[prefixLen-1] + nums[0]) * prefixLen / 2
	for numSet[total] {
		total += 1
	}

	return total
}
```

```JavaScript
var missingInteger = function(nums) {
    const n = nums.length;
    const numSet = new Set(nums);
    let prefixLen = 1;

    for (let i = 1; i < n; i++) {
        if (nums[i] === nums[i - 1] + 1) {
            prefixLen += 1;
        } else {
            break;
        }
    }

    let total = (nums[prefixLen - 1] + nums[0]) * prefixLen / 2;
    while (numSet.has(total)) {
        total += 1;
    }

    return total;
};
```

```Typescript
function missingInteger(nums: number[]): number {
    const n = nums.length;
    const numSet = new Set(nums);
    let perfixLen = 1;

    for (let i = 1; i < n; i++) {
        if (nums[i] === nums[i - 1] + 1) {
            perfixLen += 1;
        } else {
            break;
        }
    }

    let total = (nums[perfixLen - 1] + nums[0]) * perfixLen / 2;
    while (numSet.has(total)) {
        total += 1;
    }

    return total;
};
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn missing_integer(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let num_set: HashSet<&i32> = nums.iter().collect();
        let mut prefix_len = 1;

        for i in 1..n {
            if nums[i] == nums[i - 1] + 1 {
                prefix_len += 1;
            } else {
                break;
            }
        }

        let mut total = (nums[prefix_len - 1] + nums[0]) * (prefix_len as i32) / 2;
        while num_set.contains(&total) {
            total += 1;
        }

        total
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。寻找顺序前缀需要 $O(n)$，遍历寻找第一个不存在于 $nums$ 中的数需要 $O(n)$。
- 空间复杂度：$O(n)$，使用哈希表判定存在性需要 $O(n)$ 的辅助空间。
