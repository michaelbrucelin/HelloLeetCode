### [排序排列的最少操作数](https://leetcode.cn/problems/minimum-operations-to-sort-a-permutation/solutions/4043902/pai-xu-pai-lie-de-zui-shao-cao-zuo-shu-b-p91d/)

#### 方法一：模拟

**思路与算法**

本题的突破口在于，在**循环数组**的视角下，题中所允许的操作并不会影响数组内**元素间的相对顺序**。

虽然题目允许的是 **反转数组** 和 **循环左移一位** 两种操作，但是对反转后的数组应用循环左移，在反转前的数组视角下就相当于 **循环右移一位**。结合反转操作本身的性质，我们可以推出：在循环数组的视角下，$nums$ 必须**已经是一个递增或者递减排列**，这样才有可能通过左移、右移和反转操作得到所需的递增排列。

接下来考虑在可以得到递增排列的情况下，如何计算最小操作次数。

显然，由于左移和右移操作的效果相互抵消，没必要混用两种操作，我们可以贪心地左移或者右移数组，直到原数组单调为止。根据 $nums$ 在循环数组视角下的单调性，设排列的第一个元素（即元素 $0$）所在下标为 $i_0$，数组长度为 $n$，有如下情况：

- $nums$ 在循环数组视角下已经单调递增：
  - 应用左移操作，只需要左移 $i_0$ 次，原数组即为递增排列。
  - 应用右移操作，需要右移 $n-i_0$ 次。其中因为右移需要反转一次数组，还需要再反转一次数组恢复原单调性，故共需要操作 $n-i_0+2$ 次。
- $nums$ 在循环数组视角下单调递减：
  - 应用左移操作，我们的目的是将排列的首元素移动到下标 $n-1$，故需要 $i_0+1$ 次左移，然后再反转数组，故一共需要 $i_0+2$ 次操作。
  - 应用右移操作，需要右移 $n-i_0 -$ 1次，因为右移已经反转了一次数组，故此时数组已单调递增，共需要操作 $n-i_0$ 次。

取对应情况下的最小值即为答案。

**代码**

```C++
class Solution {
public:
    int minOperations(vector<int>& nums) {
        const int n = nums.size();
        if (n == 1) {
            return 0;
        }

        const int start = find(nums.begin(), nums.end(), 0) - nums.begin();
        bool asc = true;
        bool desc = true;

        for (int i = 1; i < n; i++) {
            const int value = nums[(start + i) % n];

            if (value != i) {
                asc = false;
            }
            if (value != n - i) {
                desc = false;
            }

            if (!asc && !desc) {
                return -1;
            }
        }

        if (asc) {
            return min(start, n - start + 2);
        }

        return min(n - start, start + 2);
    }
};
```

```Python
class Solution:
    def minOperations(self, nums: list[int]) -> int:
        n = len(nums)
        if n == 1:
            return 0

        start = nums.index(0)

        asc = True
        desc = True

        for i in range(1, n):
            value = nums[(start + i) % n]

            if value != i:
                asc = False
            if value != n - i:
                desc = False

            if not asc and not desc:
                return -1

        if asc:
            return min(start, n - start + 2)

        return min(n - start, start + 2)

```

```Java
class Solution {
    public int minOperations(int[] nums) {
        final int n = nums.length;
        if (n == 1) {
            return 0;
        }

        int start = 0;
        while (nums[start] != 0) {
            start++;
        }

        boolean asc = true;
        boolean desc = true;

        for (int i = 1; i < n; i++) {
            final int value = nums[(start + i) % n];

            if (value != i) {
                asc = false;
            }
            if (value != n - i) {
                desc = false;
            }

            if (!asc && !desc) {
                return -1;
            }
        }

        if (asc) {
            return Math.min(start, n - start + 2);
        }

        return Math.min(n - start, start + 2);
    }
}
```

```CSharp
public class Solution {
    public int MinOperations(int[] nums) {
        int n = nums.Length;
        if (n == 1) {
            return 0;
        }

        int start = Array.IndexOf(nums, 0);

        bool asc = true;
        bool desc = true;

        for (int i = 1; i < n; i++) {
            int value = nums[(start + i) % n];

            if (value != i) {
                asc = false;
            }
            if (value != n - i) {
                desc = false;
            }

            if (!asc && !desc) {
                return -1;
            }
        }

        if (asc) {
            return Math.Min(start, n - start + 2);
        }

        return Math.Min(n - start, start + 2);
    }
}
```

```Go
func minOperations(nums []int) int {
	n := len(nums)
	if n == 1 {
		return 0
	}

	start := 0
	for nums[start] != 0 {
		start++
	}

	asc := true
	desc := true

	for i := 1; i < n; i++ {
		value := nums[(start+i)%n]

		if value != i {
			asc = false
		}
		if value != n-i {
			desc = false
		}

		if !asc && !desc {
			return -1
		}
	}

	if asc {
		return min(start, n-start+2)
	}

	return min(n-start, start+2)
}
```

```C
static inline int min(int a, int b) {
    return a < b ? a : b;
}

int minOperations(const int* nums, int nums_size) {
    const int n = nums_size;
    if (n == 1) {
        return 0;
    }

    int start = 0;
    while (nums[start] != 0) {
        start++;
    }

    bool asc = true;
    bool desc = true;

    for (int i = 1; i < n; i++) {
        const int value = nums[(start + i) % n];

        if (value != i) {
            asc = false;
        }
        if (value != n - i) {
            desc = false;
        }

        if (!asc && !desc) {
            return -1;
        }
    }

    if (asc) {
        return min(start, n - start + 2);
    }

    return min(n - start, start + 2);
}
```

```JavaScript
var minOperations = function (nums) {
    const n = nums.length;
    if (n === 1) {
        return 0;
    }

    const start = nums.indexOf(0);

    let asc = true;
    let desc = true;

    for (let i = 1; i < n; i++) {
        const value = nums[(start + i) % n];

        if (value !== i) {
            asc = false;
        }
        if (value !== n - i) {
            desc = false;
        }

        if (!asc && !desc) {
            return -1;
        }
    }

    if (asc) {
        return Math.min(start, n - start + 2);
    }

    return Math.min(n - start, start + 2);
};
```

```TypeScript
function minOperations(nums: number[]): number {
    const n = nums.length;
    if (n === 1) {
        return 0;
    }

    const start = nums.indexOf(0);
    let asc = true;
    let desc = true;

    for (let i = 1; i < n; i++) {
        const value = nums[(start + i) % n];

        if (value !== i) {
            asc = false;
        }
        if (value !== n - i) {
            desc = false;
        }

        if (!asc && !desc) {
            return -1;
        }
    }

    if (asc) {
        return Math.min(start, n - start + 2);
    }

    return Math.min(n - start, start + 2);
}
```

```Rust
impl Solution {
    pub fn min_operations(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        if n == 1 {
            return 0;
        }

        let start = nums.iter().position(|&x| x == 0).unwrap();

        let mut asc = true;
        let mut desc = true;

        for i in 1..n {
            let value = nums[(start + i) % n];

            if value != i as i32 {
                asc = false;
            }
            if value != (n - i) as i32 {
                desc = false;
            }

            if !asc && !desc {
                return -1;
            }
        }

        if asc {
            return start.min(n - start + 2) as i32;
        }

        (n - start).min(start + 2) as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。遍历 $nums$ 需要 $O(n)$。
- 空间复杂度：$O(1)$，只用到常数个辅助变量。
