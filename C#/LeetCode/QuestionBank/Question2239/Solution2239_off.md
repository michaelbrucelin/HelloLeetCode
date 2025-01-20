### [找到最接近 0 的数字](https://leetcode.cn/problems/find-closest-number-to-zero/solutions/1485646/zhao-dao-zui-jie-jin-0-de-shu-zi-by-leet-za0j/)

#### 方法一：遍历

**思路与算法**

一个数与 $0$ 的距离即为该数的绝对值，因此我们需要找出数组 $nums$ 里面绝对值最小的元素的最大值。

我们遍历数组，并用 $res$ 来维护已遍历元素中绝对值最小且数值最大的元素，以及 $dis$ 来维护已遍历元素的最小绝对值。这两个变量的初值即为数组第一个元素的数值与绝对值。

当我们遍历到新的元素 $num$ 时，我们需要比较该数绝对值 $\vert num \vert$ 与 $dis$ 的关系，此时会有三种情况:

- $\vert num \vert < dis$，此时我们需要将 $res$ 更新为 $num$，并将 $dis$ 更新为 $\vert num \vert$；
- $\vert num \vert = dis$，此时我们需要将 $res$ 更新为 $res$ 与 $num$ 的最大值；
- $\vert num \vert > dis$，此时无需进行任何操作。

最终，$res$ 即为数组 $nums$ 里面绝对值最小的元素的最大值，我们返回该值作为答案。

**代码**

```C++
class Solution {
public:
    int findClosestNumber(vector<int>& nums) {
        int res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
        int dis = abs(nums[0]);   // 已遍历元素的最小绝对值
        for (int num: nums) {
            if (abs(num) < dis) {
                dis = abs(num);
                res = num;
            } else if (abs(num) == dis) {
                res = max(res, num);
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def findClosestNumber(self, nums: List[int]) -> int:
        res = nums[0]   # 已遍历元素中绝对值最小且数值最大的元素
        dis = abs(nums[0])   # 已遍历元素的最小绝对值
        for num in nums:
            if abs(num) < dis:
                dis = abs(num)
                res = num
            elif abs(num) == dis:
                res = max(res, num)
        return res
```

```C
int findClosestNumber(int* nums, int numsSize) {
    int res = nums[0];        // 已遍历元素中绝对值最小且数值最大的元素
    int dis = abs(nums[0]);   // 已遍历元素的最小绝对值
    for (int i = 0; i < numsSize; ++i) {
        if (abs(nums[i]) < dis) {
            dis = abs(nums[i]);
            res = nums[i];
        } else if (abs(nums[i]) == dis) {
            res = fmax(res, nums[i]);
        }
    }
    return res;
}
```

```Go
func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}

func findClosestNumber(nums []int) int {
    res := nums[0]        // 已遍历元素中绝对值最小且数值最大的元素
    dis := abs(nums[0])   // 已遍历元素的最小绝对值
    for _, num := range nums {
        if abs(num) < dis {
            dis = abs(num)
            res = num
        } else if abs(num) == dis {
            res = max(res, num)
        }
    }
    return res
}
```

```Java
public class Solution {
    public int findClosestNumber(int[] nums) {
        int res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
        int dis = Math.abs(nums[0]);   // 已遍历元素的最小绝对值
        for (int num : nums) {
            if (Math.abs(num) < dis) {
                dis = Math.abs(num);
                res = num;
            } else if (Math.abs(num) == dis) {
                res = Math.max(res, num);
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int FindClosestNumber(int[] nums) {
        int res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
        int dis = Math.Abs(nums[0]);   // 已遍历元素的最小绝对值
        foreach (int num in nums) {
            if (Math.Abs(num) < dis) {
                dis = Math.Abs(num);
                res = num;
            } else if (Math.Abs(num) == dis) {
                res = Math.Max(res, num);
            }
        }
        return res;
    }
}
```

```JavaScript
var findClosestNumber = function(nums) {
    let res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
    let dis = Math.abs(nums[0]);   // 已遍历元素的最小绝对值
    for (let num of nums) {
        if (Math.abs(num) < dis) {
            dis = Math.abs(num);
            res = num;
        } else if (Math.abs(num) === dis) {
            res = Math.max(res, num);
        }
    }
    return res;
};
```

```TypeScript
function findClosestNumber(nums: number[]): number {
    let res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
    let dis = Math.abs(nums[0]);   // 已遍历元素的最小绝对值
    for (let num of nums) {
        if (Math.abs(num) < dis) {
            dis = Math.abs(num);
            res = num;
        } else if (Math.abs(num) === dis) {
            res = Math.max(res, num);
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn find_closest_number(nums: Vec<i32>) -> i32 {
        let mut res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
        let mut dis = nums[0].abs();   // 已遍历元素的最小绝对值
        for &num in nums.iter() {
            if num.abs() < dis {
                dis = num.abs();
                res = num;
            } else if num.abs() == dis {
                res = res.max(num);
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $nums$ 的长度。即为遍历寻找对应数字的时间复杂度。
- 空间复杂度：$O(1)$。
### [找到最接近 0 的数字](https://leetcode.cn/problems/find-closest-number-to-zero/solutions/1485646/zhao-dao-zui-jie-jin-0-de-shu-zi-by-leet-za0j/)

#### 方法一：遍历

**思路与算法**

一个数与 $0$ 的距离即为该数的绝对值，因此我们需要找出数组 $nums$ 里面绝对值最小的元素的最大值。

我们遍历数组，并用 $res$ 来维护已遍历元素中绝对值最小且数值最大的元素，以及 $dis$ 来维护已遍历元素的最小绝对值。这两个变量的初值即为数组第一个元素的数值与绝对值。

当我们遍历到新的元素 $num$ 时，我们需要比较该数绝对值 $\vert num \vert$ 与 $dis$ 的关系，此时会有三种情况:

- $\vert num \vert < dis$，此时我们需要将 $res$ 更新为 $num$，并将 $dis$ 更新为 $\vert num \vert$；
- $\vert num \vert = dis$，此时我们需要将 $res$ 更新为 $res$ 与 $num$ 的最大值；
- $\vert num \vert > dis$，此时无需进行任何操作。

最终，$res$ 即为数组 $nums$ 里面绝对值最小的元素的最大值，我们返回该值作为答案。

**代码**

```C++
class Solution {
public:
    int findClosestNumber(vector<int>& nums) {
        int res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
        int dis = abs(nums[0]);   // 已遍历元素的最小绝对值
        for (int num: nums) {
            if (abs(num) < dis) {
                dis = abs(num);
                res = num;
            } else if (abs(num) == dis) {
                res = max(res, num);
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def findClosestNumber(self, nums: List[int]) -> int:
        res = nums[0]   # 已遍历元素中绝对值最小且数值最大的元素
        dis = abs(nums[0])   # 已遍历元素的最小绝对值
        for num in nums:
            if abs(num) < dis:
                dis = abs(num)
                res = num
            elif abs(num) == dis:
                res = max(res, num)
        return res
```

```C
int findClosestNumber(int* nums, int numsSize) {
    int res = nums[0];        // 已遍历元素中绝对值最小且数值最大的元素
    int dis = abs(nums[0]);   // 已遍历元素的最小绝对值
    for (int i = 0; i < numsSize; ++i) {
        if (abs(nums[i]) < dis) {
            dis = abs(nums[i]);
            res = nums[i];
        } else if (abs(nums[i]) == dis) {
            res = fmax(res, nums[i]);
        }
    }
    return res;
}
```

```Go
func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}

func findClosestNumber(nums []int) int {
    res := nums[0]        // 已遍历元素中绝对值最小且数值最大的元素
    dis := abs(nums[0])   // 已遍历元素的最小绝对值
    for _, num := range nums {
        if abs(num) < dis {
            dis = abs(num)
            res = num
        } else if abs(num) == dis {
            res = max(res, num)
        }
    }
    return res
}
```

```Java
public class Solution {
    public int findClosestNumber(int[] nums) {
        int res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
        int dis = Math.abs(nums[0]);   // 已遍历元素的最小绝对值
        for (int num : nums) {
            if (Math.abs(num) < dis) {
                dis = Math.abs(num);
                res = num;
            } else if (Math.abs(num) == dis) {
                res = Math.max(res, num);
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int FindClosestNumber(int[] nums) {
        int res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
        int dis = Math.Abs(nums[0]);   // 已遍历元素的最小绝对值
        foreach (int num in nums) {
            if (Math.Abs(num) < dis) {
                dis = Math.Abs(num);
                res = num;
            } else if (Math.Abs(num) == dis) {
                res = Math.Max(res, num);
            }
        }
        return res;
    }
}
```

```JavaScript
var findClosestNumber = function(nums) {
    let res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
    let dis = Math.abs(nums[0]);   // 已遍历元素的最小绝对值
    for (let num of nums) {
        if (Math.abs(num) < dis) {
            dis = Math.abs(num);
            res = num;
        } else if (Math.abs(num) === dis) {
            res = Math.max(res, num);
        }
    }
    return res;
};
```

```TypeScript
function findClosestNumber(nums: number[]): number {
    let res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
    let dis = Math.abs(nums[0]);   // 已遍历元素的最小绝对值
    for (let num of nums) {
        if (Math.abs(num) < dis) {
            dis = Math.abs(num);
            res = num;
        } else if (Math.abs(num) === dis) {
            res = Math.max(res, num);
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn find_closest_number(nums: Vec<i32>) -> i32 {
        let mut res = nums[0];   // 已遍历元素中绝对值最小且数值最大的元素
        let mut dis = nums[0].abs();   // 已遍历元素的最小绝对值
        for &num in nums.iter() {
            if num.abs() < dis {
                dis = num.abs();
                res = num;
            } else if num.abs() == dis {
                res = res.max(num);
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $nums$ 的长度。即为遍历寻找对应数字的时间复杂度。
- 空间复杂度：$O(1)$。
