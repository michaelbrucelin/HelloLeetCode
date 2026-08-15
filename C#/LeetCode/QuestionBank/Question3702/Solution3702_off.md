### [按位异或非零的最长子序列](https://leetcode.cn/problems/longest-subsequence-with-non-zero-bitwise-xor/solutions/4005919/an-wei-yi-huo-fei-ling-de-zui-chang-zi-x-20dd/)

#### 方法一：分类讨论

**思路与算法**

> 异或运算具有如下三个性质：
>
> 1. 任何数与 $0$ 做异或运算，结果仍然是原来的数，即 $a\oplus 0=a$。
> 2. 任何数与其自身做异或运算，结果是 $0$，即 $a\oplus a=0$。
> 3. 异或运算满足交换律和结合律，即 $a\oplus b=b\oplus a$，a\oplus $(b\oplus c)=(a\oplus b)\oplus c$。
>
> 其中 $\oplus $ 表示异或运算符。

设数组 $nums$ 的长度为 $n$，答案显然不会超过 $n$。

记整个数组所有元素的按位异或和为 $totalXor$。

**情况一**：$totalXor\ne 0$

此时数组 $nums$ 本身就是一个满足要求的非空子序列，因此答案为 $n$。

**情况二**：$totalXor=0$ 且 $nums$ 的所有元素均为 $0$

此时任意非空子序列的按位异或和都等于 $0$，不存在满足要求的非空子序列。

**情况三**：$totalXor=0$ 且 $nums$ 中至少存在一个元素 $x\ne 0$

由于 $totalXor=0$，因此 $nums$ 中除 $x$ 外一定还存在其他元素。

记剩余 $n-1$ 个元素的按位异或和为 $subXor$，则有：

$$x\oplus subXor=totalXor=0$$

于是：

$$x\oplus subXor\oplus x=0\oplus x$$

根据异或运算性质，可得：

$$subXor=x\ne 0$$

也就是说，删除元素 $x$ 后，剩余的 $n-1$ 个元素仍可组成一个按位异或和不为 $0$ 的子序列，因此答案为 $n-1$。

**代码**

```C++
class Solution {
public:
    int longestSubsequence(vector<int>& nums) {
        int n = nums.size();
        int totalXor = 0;
        bool allZero = true;

        for (int x : nums) {
            totalXor ^= x;
            if (x > 0) {
                allZero = false;
            }
        }

        if (totalXor > 0) {
            return n;
        }

        return allZero ? 0 : n - 1;
    }
};
```

```Python
class Solution:
    def longestSubsequence(self, nums: List[int]) -> int:
        n = len(nums)
        totalXor = 0
        allZero = True

        for x in nums:
            totalXor ^= x
            if x > 0:
                allZero = False

        if totalXor > 0:
            return n
        return n - 1 if allZero == False else 0
```

```Java
class Solution {
    public int longestSubsequence(int[] nums) {
        int n = nums.length;
        int totalXor = 0;
        boolean allZero = true;

        for (int x : nums) {
            totalXor ^= x;
            if (x > 0) {
                allZero = false;
            }
        }
        if (totalXor > 0) {
            return n;
        }

        return allZero ? 0 : n - 1;
    }
}
```

```CSharp
public class Solution {
    public int LongestSubsequence(int[] nums) {
        int n = nums.Length;
        int totalXor = 0;
        bool allZero = true;

        foreach (int x in nums) {
            totalXor ^= x;
            if (x > 0) {
                allZero = false;
            }
        }

        if (totalXor > 0) {
            return n;
        }

        return allZero ? 0 : n - 1;
    }
}
```

```Go
func longestSubsequence(nums []int) int {
	n := len(nums)
	totalXor := 0
	allZero := true

	for _, x := range nums {
		totalXor ^= x
		if x > 0 {
			allZero = false
		}
	}

	if totalXor > 0 {
		return n
	}

	if allZero {
		return 0
	}
	return n - 1
}
```

```C
int longestSubsequence(int* nums, int numsSize) {
    int totalXor = 0;
    int allZero = 1;

    for (int i = 0; i < numsSize; i++) {
        totalXor ^= nums[i];
        if (nums[i] > 0) {
            allZero = 0;
        }
    }
    if (totalXor > 0) {
        return numsSize;
    }

    return allZero ? 0 : numsSize - 1;
}
```

```JavaScript
var longestSubsequence = function(nums) {
    const n = nums.length;
    let totalXor = 0;
    let allZero = true;

    for (const x of nums) {
        totalXor ^= x;
        if (x > 0) {
            allZero = false;
        }
    }

    if (totalXor > 0) {
        return n;
    }

    return allZero ? 0 : n - 1;
};
```

```TypeScript
function longestSubsequence(nums: number[]): number {
    const n: number = nums.length;
    let totalXor: number = 0;
    let allZero: boolean = true;

    for (const x of nums) {
        totalXor ^= x;
        if (x > 0) {
            allZero = false;
        }
    }

    if (totalXor > 0) {
        return n;
    }

    return allZero ? 0 : n - 1;
};
```

```Rust
impl Solution {
    pub fn longest_subsequence(nums: Vec<i32>) -> i32 {
        let n = nums.len() as i32;
        let mut total_xor = 0;
        let mut all_zero = true;

        for &x in &nums {
            total_xor ^= x;
            if x > 0 {
                all_zero = false;
            }
        }

        if total_xor > 0 {
            return n;
        }

        if all_zero {
            0
        } else {
            n - 1
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $nums$ 的长度。
- 空间复杂度：$O(1)$。
