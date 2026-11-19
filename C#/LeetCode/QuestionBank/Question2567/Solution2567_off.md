### [修改两个元素的最小分数](https://leetcode.cn/problems/minimum-score-by-changing-two-elements/solutions/4055013/xiu-gai-liang-ge-yuan-su-de-zui-xiao-fen-43br/)

#### 方法一：排序 + 贪心

**思路与算法**

根据题目的定义，数组 $nums$ 的最小得分为任意两个不同位置的元素的最小绝对差值，最大得分为任意两个不同位置的元素的最大绝对差值。数组的分数为最小得分与最大得分之和。

由于这两个值与数组的元素顺序无关，我们可以先将 $nums$ 按**非递减**顺序排序。

排序之后：

- 最小得分为两个相邻元素差值的最小值，且最小得分一定大于等于 $0$。
- 最大得分为 $nums[n-1]-nums[0]$，即最大元素与最小元素之差，其中 $n$ 为数组的长度。

题目要求我们最多修改数组中的两个元素，使数组的分数最小。

由于最小得分非负，因此数组的分数一定大于等于最大得分。我们可以先考虑如何最小化最大得分，再判断能否同时使最小得分为 $0$。

为了缩小最大元素与最小元素之差，我们应该优先修改数组两端的元素。由于最多可以修改两个元素，因此只需要考虑以下三种情况：

- 将 $nums[0]$ 和 $nums[1]$ 修改为 $nums[2]$。此时最大得分为 $nums[n-1]-nums[2]$。
- 将 $nums[0]$ 修改为 $nums[1]$，将 $nums[n-1]$ 修改为 $nums[n-2]$。此时最大得分为 $nums[n-2]-nums[1]$。
- 将 $nums[n-2]$ 和 $nums[n-1]$ 修改为 $nums[n-3]$。此时最大得分为 $nums[n-3]-nums[0]$。

下面说明这三种情况一定包含最优方案。

由于最多只能修改两个元素，因此修改后至少有 $n-2$ 个原始元素保持不变。对于任意一种修改方案，保留下来的元素的最大值与最小值之差，都不会超过修改后整个数组的最大得分。

为了使保留下来的元素的极差最小，我们只需要保留排序后连续的 $n-2$ 个元素。否则，如果保留的元素不连续，我们可以将其中的元素替换为位于保留区间内部的元素，而不会增大极差。

因此，修改后的最大得分至少为

$$D=min\begin{Bmatrix}nums[n-1]-nums[2], \\ nums[n-2]-nums[1], \\ nums[n-3]-nums[0]\end{Bmatrix}.$$

另一方面，在上述三种修改方案中，被修改的元素都被设置为某个未修改元素的值，因此修改后的数组一定存在两个相同元素，最小得分为 $0$。

这说明我们不仅可以使最大得分达到下界 $D$，还可以同时使最小得分达到下界 $0$。

因此，数组的最小分数恰好为 $D$，返回上述三种情况的最小值即可。

注意，这个贪心方法也可以推广到任意操作次数的情况。

**代码**

```C++
class Solution {
public:
    int minimizeSum(vector<int>& nums) {
        int n = nums.size();
        ranges::sort(nums);
        return min({nums[n-1] - nums[2], nums[n - 2] - nums[1], nums[n - 3] - nums[0]});
    }
};
```

```Python
class Solution:
    def minimizeSum(self, nums: List[int]) -> int:
        n = len(nums)
        nums.sort()
        return min(nums[n-1] - nums[2], nums[n - 2] - nums[1], nums[n - 3] - nums[0])
```

```Java
class Solution {
    public int minimizeSum(int[] nums) {
        Arrays.sort(nums);
        int n = nums.length;
        return Math.min(Math.min(nums[n - 3] - nums[0], nums[n - 2] - nums[1]), nums[n - 1] - nums[2]);
    }
}
```

```JavaScript
var minimizeSum = function(nums) {
    const n = nums.length;
    nums.sort((a, b) => a - b);
    return Math.min(nums[n - 1] - nums[2], nums[n - 2] - nums[1], nums[n - 3] - nums[0]);
};
```

```CSharp
public class Solution {
    public int MinimizeSum(int[] nums) {
        int n = nums.Length;
        Array.Sort(nums);
        return Math.Min(
            nums[n - 1] - nums[2],
            Math.Min(nums[n - 2] - nums[1], nums[n - 3] - nums[0])
        );
    }
}
```

```Go
func minimizeSum(nums []int) int {
    n := len(nums)
    sort.Ints(nums)
    a := nums[n-1] - nums[2]
    b := nums[n-2] - nums[1]
    c := nums[n-3] - nums[0]
    return min(a, min(b, c))
}
```

```C
static int cmp(const void* a, const void* b) {
    int x = *(const int*)a;
    int y = *(const int*)b;
    return (x > y) - (x < y);
}

int minimizeSum(int* nums, int numsSize) {
    int n = numsSize;
    qsort(nums, n, sizeof(int), cmp);
    int a = nums[n - 1] - nums[2];
    int b = nums[n - 2] - nums[1];
    int c = nums[n - 3] - nums[0];
    return fmin(a, fmin(b, c));
}
```

```TypeScript
function minimizeSum(nums: number[]): number {
    const n = nums.length;
    nums.sort((a, b) => a - b);
    return Math.min(
        nums[n - 1] - nums[2],
        nums[n - 2] - nums[1],
        nums[n - 3] - nums[0]
    );
}
```

```Rust
impl Solution {
    pub fn minimize_sum(mut nums: Vec<i32>) -> i32 {
        let n = nums.len();
        nums.sort();
        let a = nums[n - 1] - nums[2];
        let b = nums[n - 2] - nums[1];
        let c = nums[n - 3] - nums[0];
        a.min(b).min(c)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$。n 为输入数组 $nums$ 的长度。对数组排序需要 $O(n\log n)$ 的时间。
- 空间复杂度：$O(\log n)$ 或 $O(n)$，取决于所使用语言的排序算法实现。

#### 方法二：一次遍历

**思路与算法**

方法一通过排序，找到数组中最小的三个元素和最大的三个元素，然后计算三种修改方案的最小值。

实际上，我们并不需要对整个数组进行排序，只需要知道数组中最小的三个元素和最大的三个元素，因此可以通过一次遍历，在 $O(n)$ 的时间内找到这六个元素。

具体地，使用六个变量维护：

- $mn_1\le mn_2\le mn_3$，分别表示数组中第一小、第二小和第三小的元素。
- $mx_1\ge mx_2\ge mx_3$，分别表示数组中第一大、第二大和第三大的元素。

初始时，将 $mn_1,mn_2,mn_3$ 均设为正无穷大，将 $mx_1,mx_2,mx_3$ 均设为负无穷大。

遍历数组，对于当前元素 $x$：

- 如果 $x<mn_1$，则依次更新 $mn_3=mn_2$、$mn_2=mn_1$、$mn_1=x$。
- 否则，如果 $x<mn_2$，则更新 $mn_3=mn_2$、$mn_2=x$。
- 否则，如果 $x<mn_3$，则更新 $mn_3=x$。

最大元素的维护方式类似，只需要将比较方向反过来。

遍历结束后，根据方法一的结论，答案为

$$min\begin{Bmatrix}mx_1-mn_3, \\ mx_2-mn_2, \\ mx_3-mn_1\end{Bmatrix}.$$

**代码**

```C++
class Solution {
public:
    int minimizeSum(vector<int>& nums) {
        int mn1 = INT_MAX, mn2 = INT_MAX, mn3 = INT_MAX;
        int mx1 = INT_MIN, mx2 = INT_MIN, mx3 = INT_MIN;

        for (int x : nums) {
            if (x < mn1) {
                mn3 = mn2;
                mn2 = mn1;
                mn1 = x;
            } else if (x < mn2) {
                mn3 = mn2;
                mn2 = x;
            } else if (x < mn3) {
                mn3 = x;
            }

            if (x > mx1) {
                mx3 = mx2;
                mx2 = mx1;
                mx1 = x;
            } else if (x > mx2) {
                mx3 = mx2;
                mx2 = x;
            } else if (x > mx3) {
                mx3 = x;
            }
        }

        return min({mx1 - mn3, mx2 - mn2, mx3 - mn1});
    }
};
```

```Python
class Solution:
    def minimizeSum(self, nums: List[int]) -> int:
        mn1 = mn2 = mn3 = inf
        mx1 = mx2 = mx3 = -inf

        for x in nums:
            if x < mn1:
                mn1, mn2, mn3 = x, mn1, mn2
            elif x < mn2:
                mn2, mn3 = x, mn2
            elif x < mn3:
                mn3 = x

            if x > mx1:
                mx1, mx2, mx3 = x, mx1, mx2
            elif x > mx2:
                mx2, mx3 = x, mx2
            elif x > mx3:
                mx3 = x

        return min(mx1 - mn3, mx2 - mn2, mx3 - mn1)
```

```Java
class Solution {
    public int minimizeSum(int[] nums) {
        int mn1 = Integer.MAX_VALUE, mn2 = Integer.MAX_VALUE, mn3 = Integer.MAX_VALUE;
        int mx1 = Integer.MIN_VALUE, mx2 = Integer.MIN_VALUE, mx3 = Integer.MIN_VALUE;

        for (int x : nums) {
            if (x < mn1) {
                mn3 = mn2;
                mn2 = mn1;
                mn1 = x;
            } else if (x < mn2) {
                mn3 = mn2;
                mn2 = x;
            } else if (x < mn3) {
                mn3 = x;
            }

            if (x > mx1) {
                mx3 = mx2;
                mx2 = mx1;
                mx1 = x;
            } else if (x > mx2) {
                mx3 = mx2;
                mx2 = x;
            } else if (x > mx3) {
                mx3 = x;
            }
        }

        return Math.min(mx1 - mn3, Math.min(mx2 - mn2, mx3 - mn1));
    }
}
```

```JavaScript
var minimizeSum = function(nums) {
    let mn1 = Infinity, mn2 = Infinity, mn3 = Infinity;
    let mx1 = -Infinity, mx2 = -Infinity, mx3 = -Infinity;

    for (const x of nums) {
        if (x < mn1) {
            [mn1, mn2, mn3] = [x, mn1, mn2];
        } else if (x < mn2) {
            [mn2, mn3] = [x, mn2];
        } else if (x < mn3) {
            mn3 = x;
        }

        if (x > mx1) {
            [mx1, mx2, mx3] = [x, mx1, mx2];
        } else if (x > mx2) {
            [mx2, mx3] = [x, mx2];
        } else if (x > mx3) {
            mx3 = x;
        }
    }

    return Math.min(mx1 - mn3, mx2 - mn2, mx3 - mn1);
};
```

```CSharp
public class Solution {
    public int MinimizeSum(int[] nums) {
        int mn1 = int.MaxValue, mn2 = int.MaxValue, mn3 = int.MaxValue;
        int mx1 = int.MinValue, mx2 = int.MinValue, mx3 = int.MinValue;

        foreach (int x in nums) {
            if (x < mn1) {
                mn3 = mn2; mn2 = mn1; mn1 = x;
            } else if (x < mn2) {
                mn3 = mn2; mn2 = x;
            } else if (x < mn3) {
                mn3 = x;
            }

            if (x > mx1) {
                mx3 = mx2; mx2 = mx1; mx1 = x;
            } else if (x > mx2) {
                mx3 = mx2; mx2 = x;
            } else if (x > mx3) {
                mx3 = x;
            }
        }

        return Math.Min(Math.Min(mx1 - mn3, mx2 - mn2), mx3 - mn1);
    }
}
```

```Go
func minimizeSum(nums []int) int {
	mn1, mn2, mn3 := int(^uint(0)>>1), int(^uint(0)>>1), int(^uint(0)>>1)
	mx1, mx2, mx3 := -mn1-1, -mn1-1, -mn1-1

	for _, x := range nums {
		if x < mn1 {
			mn1, mn2, mn3 = x, mn1, mn2
		} else if x < mn2 {
			mn2, mn3 = x, mn2
		} else if x < mn3 {
			mn3 = x
		}

		if x > mx1 {
			mx1, mx2, mx3 = x, mx1, mx2
		} else if x > mx2 {
			mx2, mx3 = x, mx2
		} else if x > mx3 {
			mx3 = x
		}
	}

	min := func(a, b int) int {
		if a < b {
			return a
		}
		return b
	}

	return min(min(mx1-mn3, mx2-mn2), mx3-mn1)
}
```

```C
int minimizeSum(int* nums, int numsSize) {
    int mn1 = INT_MAX, mn2 = INT_MAX, mn3 = INT_MAX;
    int mx1 = INT_MIN, mx2 = INT_MIN, mx3 = INT_MIN;

    for (int idx = 0; idx < numsSize; idx++) {
        int x = nums[idx];

        if (x < mn1) {
            mn3 = mn2;
            mn2 = mn1;
            mn1 = x;
        } else if (x < mn2) {
            mn3 = mn2;
            mn2 = x;
        } else if (x < mn3) {
            mn3 = x;
        }

        if (x > mx1) {
            mx3 = mx2;
            mx2 = mx1;
            mx1 = x;
        } else if (x > mx2) {
            mx3 = mx2;
            mx2 = x;
        } else if (x > mx3) {
            mx3 = x;
        }
    }

    int a = mx1 - mn3;
    int b = mx2 - mn2;
    int c = mx3 - mn1;
    int m = a < b ? a : b;
    return m < c ? m : c;
}
```

```TypeScript
function minimizeSum(nums: number[]): number {
    let mn1 = Infinity, mn2 = Infinity, mn3 = Infinity;
    let mx1 = -Infinity, mx2 = -Infinity, mx3 = -Infinity;

    for (const x of nums) {
        if (x < mn1) {
            [mn1, mn2, mn3] = [x, mn1, mn2];
        } else if (x < mn2) {
            [mn2, mn3] = [x, mn2];
        } else if (x < mn3) {
            mn3 = x;
        }

        if (x > mx1) {
            [mx1, mx2, mx3] = [x, mx1, mx2];
        } else if (x > mx2) {
            [mx2, mx3] = [x, mx2];
        } else if (x > mx3) {
            mx3 = x;
        }
    }

    return Math.min(mx1 - mn3, mx2 - mn2, mx3 - mn1);
}
```

```Rust
impl Solution {
    pub fn minimize_sum(nums: Vec<i32>) -> i32 {
        let mut mn1 = i32::MAX;
        let mut mn2 = i32::MAX;
        let mut mn3 = i32::MAX;
        let mut mx1 = i32::MIN;
        let mut mx2 = i32::MIN;
        let mut mx3 = i32::MIN;

        for &x in &nums {
            if x < mn1 {
                mn3 = mn2;
                mn2 = mn1;
                mn1 = x;
            } else if x < mn2 {
                mn3 = mn2;
                mn2 = x;
            } else if x < mn3 {
                mn3 = x;
            }

            if x > mx1 {
                mx3 = mx2;
                mx2 = mx1;
                mx1 = x;
            } else if x > mx2 {
                mx3 = mx2;
                mx2 = x;
            } else if x > mx3 {
                mx3 = x;
            }
        }

        (mx1 - mn3).min(mx2 - mn2).min(mx3 - mn1)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组 $nums$ 的长度。只需要遍历数组一次，每次更新最多涉及常数次比较和赋值。
- 空间复杂度：$O(1)$，只需要使用六个变量维护数组中最小的三个元素和最大的三个元素。
