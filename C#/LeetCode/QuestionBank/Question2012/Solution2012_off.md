### [数组美丽值求和](https://leetcode.cn/problems/sum-of-beauty-in-the-array/solutions/3088657/shu-zu-mei-li-zhi-qiu-he-by-leetcode-sol-y8ej/)

#### 方法一：两次遍历

**思路与算法**

美丽值只有三种取值：

1. 对于取值为 $2$ 的情况，我们总共需要两次遍历，第一次遍历判断某个值是否严格大于前面所有的值，第二次倒序遍历判断某个值是否严格小于后面所有的值。
2. 对于取值为 $1$ 的情况，在第二次遍历时排除取值为 $2$ 后判断即可。
3. 对于取值为 $0$ 的情况，不需要特殊判断。

对于取值为 $2$ 的情况，在第一次遍历的过程中维护一个前缀最大值，若当前值严格大于该前缀最大值，则标记当前值；接着在第二次遍历的过程中维护一个后缀最小值，若当前值严格小于该后缀最小值并且当前值在第一次遍历时被标记过，则答案累加 $2$。

**代码**

```Java
class Solution {
    public int sumOfBeauties(int[] nums) {
        int n = nums.length;
        int[] state = new int[n];
        int pre_max = nums[0];
        for (int i = 1; i < n - 1; i++) {
            if (nums[i] > pre_max) {
                state[i] = 1;
                pre_max = nums[i];
            }
        }
        int suf_min = nums[n - 1];
        int res = 0;
        for (int i = n - 2; i > 0; i--) {
            if (state[i] == 1 && nums[i] < suf_min) {
                res += 2;
            } else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1]) {
                res += 1;
            }
            suf_min = Math.min(suf_min, nums[i]);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int SumOfBeauties(int[] nums) {
        int n = nums.Length;
        int[] state = new int[n];
        int pre_max = nums[0];
        for (int i = 1; i < n - 1; i++) {
            if (nums[i] > pre_max) {
                state[i] = 1;
                pre_max = nums[i];
            }
        }
        int suf_min = nums[n - 1];
        int res = 0;
        for (int i = n - 2; i > 0; i--) {
            if (state[i] == 1 && nums[i] < suf_min) {
                res += 2;
            } else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1]) {
                res += 1;
            }
            suf_min = Math.Min(suf_min, nums[i]);
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    int sumOfBeauties(vector<int>& nums) {
        int n = nums.size();
        vector<int> state(n);
        int pre_max = nums[0];
        for (int i = 1; i < n - 1; i++) {
            if (nums[i] > pre_max) {
                state[i] = 1;
                pre_max = nums[i];
            }
        }
        int suf_min = nums[n - 1];
        int res = 0;
        for (int i = n - 2; i > 0; i--) {
            if (state[i] && nums[i] < suf_min) {
                res += 2;
            } else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1]) {
                res += 1;
            }
            suf_min = min(suf_min, nums[i]);
        }
        return res;
    }
};
```

```Python
class Solution:
    def sumOfBeauties(self, nums: List[int]) -> int:
        n = len(nums)
        state = [0] * n
        pre_max = nums[0]
        for i in range(1, n - 1):
            if nums[i] > pre_max:
                state[i] = 1
                pre_max = nums[i]
        
        suf_min = nums[n - 1]
        res = 0
        for i in range(n - 2, 0, -1):
            if state[i] == 1 and nums[i] < suf_min:
                res += 2
            elif nums[i - 1] < nums[i] and nums[i] < nums[i + 1]:
                res += 1
            suf_min = min(suf_min, nums[i])
        return res
```

```Go
func sumOfBeauties(nums []int) int {
    n := len(nums)
    state := make([]int, n)
    pre_max := nums[0]
    for i := 1; i < n - 1; i++ {
        if nums[i] > pre_max {
            state[i] = 1
            pre_max = nums[i]
        }
    }
    suf_min := nums[n-1]
    res := 0
    for i := n - 2; i > 0; i-- {
        if state[i] == 1 && nums[i] < suf_min {
            res += 2
        } else if nums[i - 1] < nums[i] && nums[i] < nums[i + 1] {
            res += 1
        }
        suf_min = min(suf_min, nums[i])
    }
    return res
}
```

```C
int sumOfBeauties(int* nums, int numsSize) {
    int* state = (int*)calloc(numsSize, sizeof(int));
    int pre_max = nums[0];
    for (int i = 1; i < numsSize - 1; i++) {
        if (nums[i] > pre_max) {
            state[i] = 1;
            pre_max = nums[i];
        }
    }
    int suf_min = nums[numsSize - 1];
    int res = 0;
    for (int i = numsSize - 2; i > 0; i--) {
        if (state[i] && nums[i] < suf_min) {
            res += 2;
        } else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1]) {
            res += 1;
        }
        suf_min = nums[i] < suf_min ? nums[i] : suf_min;
    }
    free(state);
    return res;
}
```

```JavaScript
var sumOfBeauties = function(nums) {
    const n = nums.length;
    const state = new Array(n).fill(0);
    let pre_max = nums[0];
    for (let i = 1; i < n - 1; i++) {
        if (nums[i] > pre_max) {
            state[i] = 1;
            pre_max = nums[i];
        }
    }
    let suf_min = nums[n - 1];
    let res = 0;
    for (let i = n - 2; i > 0; i--) {
        if (state[i] && nums[i] < suf_min) {
            res += 2;
        } else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1]) {
            res += 1;
        }
        suf_min = Math.min(suf_min, nums[i]);
    }
    return res;
}
```

```TypeScript
function sumOfBeauties(nums: number[]): number {
    const n = nums.length;
    const state: number[] = new Array(n).fill(0);
    let pre_max = nums[0];
    for (let i = 1; i < n - 1; i++) {
        if (nums[i] > pre_max) {
            state[i] = 1;
            pre_max = nums[i];
        }
    }
    let suf_min = nums[n - 1];
    let res = 0;
    for (let i = n - 2; i > 0; i--) {
        if (state[i] && nums[i] < suf_min) {
            res += 2;
        } else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1]) {
            res += 1;
        }
        suf_min = Math.min(suf_min, nums[i]);
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn sum_of_beauties(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut state = vec![0; n];
        let mut pre_max = nums[0];
        for i in 1..n-1 {
            if nums[i] > pre_max {
                state[i] = 1;
                pre_max = nums[i];
            }
        }
        let mut suf_min = nums[n - 1];
        let mut res = 0;
        for i in (1..n-1).rev() {
            if state[i] == 1 && nums[i] < suf_min {
                res += 2;
            } else if nums[i - 1] < nums[i] && nums[i] < nums[i + 1] {
                res += 1;
            }
            suf_min = suf_min.min(nums[i]);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。我们遍历了两次 $nums$，每次遍历的时间复杂度为 $O(n)$，因此总体时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$。使用标记状态数组 $state$ 的空间复杂度为 $O(n)$。
