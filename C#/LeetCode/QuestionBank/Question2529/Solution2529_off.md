### [正整数和负整数的最大计数](https://leetcode.cn/problems/maximum-count-of-positive-integer-and-negative-integer/solutions/2726974/zheng-zheng-shu-he-fu-zheng-shu-de-zui-d-psye/)

#### 方法一：遍历

##### 思路与算法

遍历整个数组，用两个变量分别统计正数和负数的个数，最后返回较大值即可。

##### 代码

```c++
class Solution {
public:
    int maximumCount(vector<int>& nums) {
        int pos = 0, neg = 0;
        for (int num : nums) {
            if (num > 0) {
                pos++;
            } else if (num < 0) {
                neg++;
            }
        }
        return max(pos, neg);
    }
};
```

```java
class Solution {
    public int maximumCount(int[] nums) {
        int pos = 0, neg = 0;
        for (int num : nums) {
            if (num > 0) {
                pos++;
            } else if (num < 0) {
                neg++;
            }
        }
        return Math.max(pos, neg);
    }
}
```

```csharp
public class Solution {
    public int MaximumCount(int[] nums) {
        int pos = 0, neg = 0;
        foreach (int num in nums) {
            if (num > 0) {
                pos++;
            } else if (num < 0) {
                neg++;
            }
        }
        return Math.Max(pos, neg);
    }
}
```

```c++
class Solution:
    def maximumCount(self, nums: List[int]) -> int:
        pos, neg = 0, 0
        for num in nums:
            if num > 0:
                pos += 1
            elif num < 0:
                neg += 1
        return max(pos, neg)
```

```c
int maximumCount(int* nums, int numsSize) {
    int pos = 0, neg = 0;
    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        if (num > 0) {
            pos++;
        } else if (num < 0) {
            neg++;
        }
    }
    return fmax(pos, neg);
}
```

```go
func maximumCount(nums []int) int {
    pos, neg := 0, 0
    for _, num := range nums {
        if num > 0 {
            pos++
        } else if num < 0 {
            neg++
        }
    }
    return max(pos, neg)
}
```

```javascript
var maximumCount = function(nums) {
    let pos = 0, neg = 0;
    for (const num of nums) {
        if (num > 0) {
            pos++;
        } else if (num < 0) {
            neg++;
        }
    }
    return Math.max(pos, neg);
};
```

```typescript
function maximumCount(nums: number[]): number {
    let pos = 0, neg = 0;
    for (const num of nums) {
        if (num > 0) {
            pos++;
        } else if (num < 0) {
            neg++;
        }
    }
    return Math.max(pos, neg);
};
```

```rust
impl Solution {
    pub fn maximum_count(nums: Vec<i32>) -> i32 {
        let mut pos = 0;
        let mut neg = 0;
        for &num in nums.iter() {
            if num > 0 {
                pos += 1;
            } else if num < 0 {
                neg += 1;
            }
        }
        pos.max(neg)
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是 $\textit{nums}$ 的长度。
- 空间复杂度：$O(1)$。

#### 方法二：二分查找

##### 思路与算法

由于数组呈现**非递减顺序**，因此可通过二分查找定位第一个数值大于等于 $0$ 的位置 $\textit{pos}_1$ 及第一个数值大于等于 $1$ 的下标 $\textit{pos}_2$。假定 $n$ 表示数组长度，且数组下标从 $0$，则负数的个数为 $\textit{pos}_1$，正数的个数为 $n - \textit{pos}_2$，返回这两者的较大值即可。

二分的实现思路可以参考题目「[34. 在排序数组中查找元素的第一个和最后一个位置](https://leetcode.cn/problems/find-first-and-last-position-of-element-in-sorted-array/description/)」的题解。

##### 代码

```c++
class Solution {
public:
    int lowerBound(vector<int>& nums, int val) {
        int l = 0, r = nums.size();
        while (l < r) {
            int m = (l + r) / 2;
            if (nums[m] >= val) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }

    int maximumCount(vector<int>& nums) {
        int pos1 = lowerBound(nums, 0);
        int pos2 = lowerBound(nums, 1);
        return max(pos1, (int) nums.size() - pos2);
    }
};
```

```java
class Solution {
    public int maximumCount(int[] nums) {
        int pos1 = lowerBound(nums, 0);
        int pos2 = lowerBound(nums, 1);
        return Math.max(pos1, nums.length - pos2);
    }

    public int lowerBound(int[] nums, int val) {
        int l = 0, r = nums.length;
        while (l < r) {
            int m = (l + r) / 2;
            if (nums[m] >= val) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }
}
```

```csharp
public class Solution {
    public int MaximumCount(int[] nums) {
        int pos1 = LowerBound(nums, 0);
        int pos2 = LowerBound(nums, 1);
        return Math.Max(pos1, nums.Length - pos2);
    }

    public int LowerBound(int[] nums, int val) {
        int l = 0, r = nums.Length;
        while (l < r) {
            int m = (l + r) / 2;
            if (nums[m] >= val) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }
}
```

```c++
class Solution:
    def lowerBound(self, nums, val):
        l, r = 0, len(nums)
        while l < r:
            m = (l + r) // 2
            if nums[m] >= val:
                r = m
            else:
                l = m + 1
        return l

    def maximumCount(self, nums: List[int]) -> int:
        pos1 = self.lowerBound(nums, 0)
        pos2 = self.lowerBound(nums, 1)
        return max(pos1, len(nums) - pos2)
```

```c
int lowerBound(const int *nums, int numsSize, int val) {
    int l = 0, r = numsSize;
    while (l < r) {
        int m = (l + r) / 2;
        if (nums[m] >= val) {
            r = m;
        } else {
            l = m + 1;
        }
    }
    return l;
}

int maximumCount(int* nums, int numsSize) {
    int pos1 = lowerBound(nums, numsSize, 0);
    int pos2 = lowerBound(nums, numsSize, 1);
    return fmax(pos1, numsSize - pos2);
}
```

```go
func maximumCount(nums []int) int {
    pos1 := lowerBound(nums, 0);
    pos2 := lowerBound(nums, 1);
    return max(pos1, len(nums) - pos2);
}

func lowerBound(nums []int, val int) int {
    l, r := 0, len(nums)
    for l < r {
        m := (l + r) / 2
        if nums[m] >= val {
            r = m
        } else {
            l = m + 1
        }
    }
    return l
}
```

```javascript
var maximumCount = function(nums) {
    const pos1 = lowerBound(nums, 0);
    const pos2 = lowerBound(nums, 1);
    return Math.max(pos1, nums.length - pos2);
};

const lowerBound = (nums, val) => {
    let l = 0, r = nums.length;
    while (l < r) {
        const m = (l + r) >> 1;
        if (nums[m] >= val) {
            r = m;
        } else {
            l = m + 1;
        }
    }
    return l;
}
```

```typescript
function maximumCount(nums: number[]): number {
    const pos1 = lowerBound(nums, 0);
    const pos2 = lowerBound(nums, 1);
    return Math.max(pos1, nums.length - pos2);
};

const lowerBound = (nums: number[], val: number): number => {
    let l = 0, r = nums.length;
    while (l < r) {
        const m = (l + r) >> 1;
        if (nums[m] >= val) {
            r = m;
        } else {
            l = m + 1;
        }
    }
    return l;
}
```

```rust
impl Solution {
    pub fn maximum_count(nums: Vec<i32>) -> i32 {
        fn lower_bound(nums: &Vec<i32>, val: i32) -> usize {
            let mut l = 0;
            let mut r = nums.len();
            while l < r {
                let m = (l + r) / 2;
                if nums[m] >= val {
                    r = m;
                } else {
                    l = m + 1;
                }
            }
            l
        }

        let pos1 = lower_bound(&nums, 0);
        let pos2 = lower_bound(&nums, 1);
        pos1.max(nums.len() - pos2) as i32
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(\log n)$，其中 $n$ 是 $\textit{nums}$ 的长度。
- 空间复杂度：$O(1)$。
