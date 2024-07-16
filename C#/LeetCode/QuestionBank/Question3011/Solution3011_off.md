### [判断一个数组是否可以变为有序](https://leetcode.cn/problems/find-if-array-can-be-sorted/solutions/2837005/pan-duan-yi-ge-shu-zu-shi-fou-ke-yi-bian-xwgy/)

#### 方法一：模拟

**思路**

首先我们需要将数组进行分组，分组需要满足以下要求：

- 一个子数组内，如果所有元素在二进制下数位为 $1$ 的数目相同，则这个子数组的所有元素为一组。
- 原数组的每个元素都要在组内。
- 每个组的元素要尽可能多，即相邻的组的元素在二进制下数位为 $1$ 的数目不同。

经过这样的要求分组，我们再将每个组进行排序，如此处理之后，如果原数组变为有序，则返回 $true$，否则返回 $false$。

我们发现，我们不需要将每个组进行排序。如果每个组的元素都大于上一个组的元素的最大值，那么原数组就可以变为有序。我们遍历数组，用 curCnt 表示当前元素二进制下数位为 $1$ 的数目，用 $lastCnt$ 表示当前元素二进制下数位为 $1$ 的数目，比较这二者来判断是否进入了一个新的组。用 $lastGroupMax$ 来表示上一个组的最大值，用 $curGroupMax$ 来表示当前组的最大值。如果进入了一个新的组，则更新 $lastGroupMax$ 和 $curGroupMax$，否则只更新 $curGroupMax$。每次都需要判断当前元素是否大于上一个组的元素的最大值，不满足则直接返回 $false$，否则继续遍历。遍历结束后返回 $true$。

**代码**

```Python
class Solution:
    def canSortArray(self, nums: List[int]) -> bool:
        lastCnt = 0
        lastGroupMax = 0
        curGroupMax = 0
        for num in nums:
            curCnt = num.bit_count()
            if curCnt == lastCnt:
                curGroupMax = max(curGroupMax, num)
            else:
                lastCnt = curCnt
                lastGroupMax = curGroupMax
                curGroupMax = num
            if num < lastGroupMax:
                return False
        return True
```

```Java
class Solution {
    public boolean canSortArray(int[] nums) {
        int lastCnt = 0;
        int lastGroupMax = 0;
        int curGroupMax = 0;
        for (int num : nums) {
            int curCnt = Integer.bitCount(num);
            if (curCnt == lastCnt) {
                curGroupMax = Math.max(curGroupMax, num);
            } else {
                lastCnt = curCnt;
                lastGroupMax = curGroupMax;
                curGroupMax = num;
            }
            if (num < lastGroupMax) {
                return false;
            }
        }
        return true;
    }
}
```

```C++
bool canSortArray(int* nums, int numsSize) {
    int lastCnt = 0;
    int lastGroupMax = 0;
    int curGroupMax = 0;

    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        int curCnt = __builtin_popcount(num);
        if (curCnt == lastCnt) {
            curGroupMax = fmax(curGroupMax, num);
        } else {
            lastCnt = curCnt;
            lastGroupMax = curGroupMax;
            curGroupMax = num;
        }
        if (num < lastGroupMax) {
            return false;
        }
    }
    return true;
}
```

```C
bool canSortArray(int* nums, int numsSize) {
    int lastCnt = 0;
    int lastGroupMax = 0;
    int curGroupMax = 0;

    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        int curCnt = __builtin_popcount(num);
        if (curCnt == lastCnt) {
            curGroupMax = fmax(curGroupMax, num);
        } else {
            lastCnt = curCnt;
            lastGroupMax = curGroupMax;
            curGroupMax = num;
        }
        if (num < lastGroupMax) {
            return false;
        }
    }
    return true;
}
```

```Go
func canSortArray(nums []int) bool {
    lastCnt := 0
    lastGroupMax := 0
    curGroupMax := 0

    for _, num := range nums {
        curCnt := bits.OnesCount(uint(num))
        if curCnt == lastCnt {
            curGroupMax = max(curGroupMax, num)
        } else {
            lastCnt = curCnt
            lastGroupMax = curGroupMax
            curGroupMax = num
        }
        if num < lastGroupMax {
            return false
        }
    }
    return true
}
```

```JavaScript
var canSortArray = function(nums) {
    let lastCnt = 0;
    let lastGroupMax = 0;
    let curGroupMax = 0;

    for (let num of nums) {
        let curCnt = countBits(num);
        if (curCnt === lastCnt) {
            curGroupMax = Math.max(curGroupMax, num);
        } else {
            lastCnt = curCnt;
            lastGroupMax = curGroupMax;
            curGroupMax = num;
        }
        if (num < lastGroupMax) {
            return false;
        }
    }
    return true;
};

const countBits = (num) => {
    let count = 0;
    while (num !== 0) {
        count++;
        num &= num - 1;
    }
    return count;
}
```

```TypeScript
const countBits = (num) => {
    let count = 0;
    while (num !== 0) {
        count++;
        num &= num - 1;
    }
    return count;
}

function canSortArray(nums: number[]): boolean {
    let lastCnt = 0;
    let lastGroupMax = 0;
    let curGroupMax = 0;

    for (let num of nums) {
        let curCnt = countBits(num);
        if (curCnt === lastCnt) {
            curGroupMax = Math.max(curGroupMax, num);
        } else {
            lastCnt = curCnt;
            lastGroupMax = curGroupMax;
            curGroupMax = num;
        }
        if (num < lastGroupMax) {
            return false;
        }
    }
    return true;
};
```

```Rust
impl Solution {
    pub fn can_sort_array(nums: Vec<i32>) -> bool {
        let mut last_cnt = 0;
        let mut last_group_max = 0;
        let mut cur_group_max = 0;

        for num in nums {
            let cur_cnt = num.count_ones();
            if cur_cnt == last_cnt {
                cur_group_max = cur_group_max.max(num);
            } else {
                last_cnt = cur_cnt;
                last_group_max = cur_group_max;
                cur_group_max = num;
            }
            if num < last_group_max {
                return false;
            }
        }
        true
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(1)$。
