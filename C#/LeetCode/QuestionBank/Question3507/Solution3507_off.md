### [移除最小数对使数组有序 I](https://leetcode.cn/problems/minimum-pair-removal-to-sort-array-i/solutions/3880128/yi-chu-zui-xiao-shu-dui-shi-shu-zu-you-x-gwq7/)

#### 方法一：模拟

**思路与算法**

由于数据范围非常小，故直接按题意模拟即可。

遍历 $nums$ 的相邻元素，维护最小相邻数对和的同时判断 $nums$ 是否满足非严格单调递增，如果不满足条件则更新数组，将相邻数对合并为新元素。重复以上操作，直到满足非严格单调递增的条件或 $nums$ 的长度为 $1$ 为止。

**代码**

```C++
class Solution {
public:
    int minimumPairRemoval(std::vector<int>& nums) {
        int count = 0;

        while (nums.size() > 1) {
            bool isAscending = true;
            int minSum = std::numeric_limits<int>::max();
            int targetIndex = -1;

            for (size_t i = 0; i < nums.size() - 1; ++i) {
                int sum = nums[i] + nums[i + 1];

                if (nums[i] > nums[i + 1]) {
                    isAscending = false;
                }

                if (sum < minSum) {
                    minSum = sum;
                    targetIndex = static_cast<int>(i);
                }
            }

            if (isAscending) {
                break;
            }

            count++;
            nums[targetIndex] = minSum;
            nums.erase(nums.begin() + targetIndex + 1);
        }

        return count;
    }
};
```

```Java
class Solution {
    public int minimumPairRemoval(int[] nums) {
        List<Integer> list = new ArrayList<>();
        for (int num : nums) {
            list.add(num);
        }
        var count = 0;

        while (list.size() > 1) {
            var isAscending = true;
            var minSum = Integer.MAX_VALUE;
            var targetIndex = -1;

            for (var i = 0; i < list.size() - 1; i++) {
                var sum = list.get(i) + list.get(i + 1);

                if (list.get(i) > list.get(i + 1)) {
                    isAscending = false;
                }

                if (sum < minSum) {
                    minSum = sum;
                    targetIndex = i;
                }
            }

            if (isAscending) {
                break;
            }

            count++;
            list.set(targetIndex, minSum);
            list.remove(targetIndex + 1);
        }

        return count;
    }
}
```

```Python
class Solution:
    def minimumPairRemoval(self, nums: List[int]) -> int:
        count = 0

        while len(nums) > 1:
            isAscending = True
            minSum = float("inf")
            targetIndex = -1

            for i in range(len(nums) - 1):
                pair_sum = nums[i] + nums[i + 1]

                if nums[i] > nums[i + 1]:
                    isAscending = False

                if pair_sum < minSum:
                    minSum = pair_sum
                    targetIndex = i

            if isAscending:
                break

            count += 1
            nums[targetIndex] = minSum
            nums.pop(targetIndex + 1)

        return count

```

```CSharp
public class Solution {
    public int MinimumPairRemoval(int[] nums) {
        var count = 0;
        var list = nums.ToList();

        while (list.Count > 1) {
            var isAscending = true;
            var minSum = int.MaxValue;
            var targetIndex = -1;

            for (var i = 0; i < list.Count - 1; i++) {
                var sum = list[i] + list[i + 1];

                if (list[i] > list[i + 1]) {
                    isAscending = false;
                }

                if (sum < minSum) {
                    minSum = sum;
                    targetIndex = i;
                }
            }

            if (isAscending) {
                break;
            }

            count++;
            list[targetIndex] = minSum;
            list.RemoveAt(targetIndex + 1);
        }

        return count;
    }
}
```

```JavaScript
var minimumPairRemoval = function (nums) {
    let count = 0;

    while (nums.length > 1) {
        let isAscending = true;
        let minSum = Infinity;
        let targetIndex = -1;

        for (let i = 0; i < nums.length - 1; i++) {
            const sum = nums[i] + nums[i + 1];

            if (nums[i] > nums[i + 1]) {
                isAscending = false;
            }

            if (sum < minSum) {
                minSum = sum;
                targetIndex = i;
            }
        }

        if (isAscending) {
            break;
        }

        count++;
        nums[targetIndex] = minSum;
        nums.splice(targetIndex + 1, 1);
    }

    return count;
}
```

```TypeScript
function minimumPairRemoval(nums: number[]): number {
    let count = 0;

    while (nums.length > 1) {
        let isAscending = true;
        let minSum = Infinity;
        let targetIndex = -1;

        for (let i = 0; i < nums.length - 1; i++) {
            const sum = nums[i] + nums[i + 1];

            if (nums[i] > nums[i + 1]) {
                isAscending = false;
            }

            if (sum < minSum) {
                minSum = sum;
                targetIndex = i;
            }
        }

        if (isAscending) {
            break;
        }

        count++;
        nums[targetIndex] = minSum;
        nums.splice(targetIndex + 1, 1);
    }

    return count;
}
```

```Go
func minimumPairRemoval(nums []int) int {
    count := 0

    for len(nums) > 1 {
        isAscending := true
        minSum := 1 << 31 - 1
        targetIndex := -1

        for i := 0; i < len(nums)-1; i++ {
            sum := nums[i] + nums[i+1]
            if nums[i] > nums[i+1] {
                isAscending = false
            }
            if sum < minSum {
                minSum = sum
                targetIndex = i
            }
        }

        if isAscending {
            break
        }
        count++
        nums[targetIndex] = minSum
        nums = append(nums[:targetIndex+1], nums[targetIndex + 2:]...)
    }

    return count
}
```

```C
int minimumPairRemoval(int* nums, int numsSize) {
    int count = 0;
    int size = numsSize;

    while (size > 1) {
        int isAscending = 1;
        int minSum = INT_MAX;
        int targetIndex = -1;
        for (int i = 0; i < size - 1; i++) {
            int sum = nums[i] + nums[i + 1];
            if (nums[i] > nums[i + 1]) {
                isAscending = 0;
            }
            if (sum < minSum) {
                minSum = sum;
                targetIndex = i;
            }
        }

        if (isAscending) {
            break;
        }
        count++;
        nums[targetIndex] = minSum;
        for (int i = targetIndex + 1; i < size - 1; i++) {
            nums[i] = nums[i + 1];
        }
        size--;
    }

    return count;
}
```

```Rust
impl Solution {
    pub fn minimum_pair_removal(nums: Vec<i32>) -> i32 {
        let mut count = 0;
        let mut nums = nums.clone();

        while nums.len() > 1 {
            let mut is_ascending = true;
            let mut min_sum = i32::MAX;
            let mut target_index = -1;

            for i in 0..nums.len() - 1 {
                let sum = nums[i] + nums[i + 1];
                if nums[i] > nums[i + 1] {
                    is_ascending = false;
                }
                if sum < min_sum {
                    min_sum = sum;
                    target_index = i as i32;
                }
            }

            if is_ascending {
                break;
            }

            count += 1;
            let ti = target_index as usize;
            nums[ti] = min_sum;
            nums.remove(ti + 1);
        }

        count
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $nums$ 的长度。合并数对最多进行 $n$ 次；判断单调性、寻找数对和删除数组中的元素均需要消耗 $O(n)$ 的时间，故总时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(1)$，只用到了常数个变量。

#### 方法二：模拟 + 数组模拟链表

**思路与算法**

除了直接在数组上移除元素外，也可以采用模拟链表的思路，从而支持 $O(1)$ 的删除操作。考虑维护一个 $next$ 数组，代表下标 $i$ 处元素的下一个元素所在位置。由于不管是判断单调性，还是寻找最小相邻数对和，都只是对线性表的顺序遍历，因此遍历部分的逻辑基本和方法一基本相同，只需要在删除元素的时候维护 $next$ 数组，将目标元素的下一个元素指向下下个元素即可。

**代码**

```C++
class Solution {
public:
    int minimumPairRemoval(std::vector<int>& nums) {
        int n = nums.size();
        std::vector<int> next(n);
        std::iota(next.begin(), next.end(), 1);
        next[n - 1] = -1;
        int count = 0;

        while (n - count > 1) {
            int curr = 0;
            int target = 0;
            int targetAdjSum = nums[target] + nums[next[target]];
            bool isAscending = true;

            while (curr != -1 && next[curr] != -1) {
                if (nums[curr] > nums[next[curr]]) {
                    isAscending = false;
                }

                int currAdjSum = nums[curr] + nums[next[curr]];
                if (currAdjSum < targetAdjSum) {
                    target = curr;
                    targetAdjSum = currAdjSum;
                }
                curr = next[curr];
            }

            if (isAscending) {
                break;
            }

            count++;
            next[target] = next[next[target]];
            nums[target] = targetAdjSum;
        }

        return count;
    }
};
```

```Java
class Solution {
    public int minimumPairRemoval(int[] nums) {
        var n = nums.length;
        var next = new int[n];
        Arrays.setAll(next, i -> i + 1);
        next[n - 1] = -1;
        var count = 0;

        while (n - count > 1) {
            var curr = 0;
            var target = 0;
            var targetAdjSum = nums[target] + nums[next[target]];
            var isAscending = true;

            while (curr != -1 && next[curr] != -1) {
                if (nums[curr] > nums[next[curr]]) {
                    isAscending = false;
                }

                var currAdjSum = nums[curr] + nums[next[curr]];
                if (currAdjSum < targetAdjSum) {
                    target = curr;
                    targetAdjSum = currAdjSum;
                }
                curr = next[curr];
            }

            if (isAscending) {
                break;
            }

            count++;
            next[target] = next[next[target]];
            nums[target] = targetAdjSum;
        }

        return count;

    }
}
```

```Python
class Solution:
    def minimumPairRemoval(self, nums: List[int]) -> int:
        next_node = list(range(1, len(nums) + 1))
        next_node[-1] = None
        count = 0

        while len(nums) - count > 1:
            curr = 0
            target = 0
            target_adj_sum = nums[target] + nums[next_node[target]]
            is_ascending = True

            while curr is not None and next_node[curr] is not None:
                if nums[curr] > nums[next_node[curr]]:
                    is_ascending = False

                curr_adj_sum = nums[curr] + nums[next_node[curr]]
                if curr_adj_sum < target_adj_sum:
                    target = curr
                    target_adj_sum = curr_adj_sum

                curr = next_node[curr]

            if is_ascending:
                break

            count += 1
            next_node[target] = next_node[next_node[target]]
            nums[target] = target_adj_sum

        return count
```

```CSharp
public class Solution {
    public int MinimumPairRemoval(int[] nums) {
        var next = new int?[nums.Length];
        for (var i = 0; i < nums.Length - 1; i++) next[i] = i + 1;

        var count = 0;

        while (nums.Length - count > 1) {
            int? curr = 0;
            var target = 0;
            var targetAdjSum = nums[target] + nums[next[target]!.Value];
            var isAscending = true;

            while (curr is not null && next[curr.Value] is not null) {
                var nextVal = next[curr.Value]!.Value;

                if (nums[curr.Value] > nums[nextVal]) {
                    isAscending = false;
                }

                var currAdjSum = nums[curr.Value] + nums[nextVal];
                if (currAdjSum < targetAdjSum) {
                    target = curr.Value;
                    targetAdjSum = currAdjSum;
                }

                curr = next[curr.Value];
            }

            if (isAscending) {
                break;
            }

            count++;
            next[target] = next[next[target]!.Value];
            nums[target] = targetAdjSum;
        }

        return count;
    }
}
```

```JavaScript
var minimumPairRemoval = function (nums) {
    const next = nums.map((_, i) => i + 1);
    next[nums.length - 1] = null;
    let count = 0;

    while (nums.length - count > 1) {
        let curr = 0;
        let target = 0;
        let targetAdjSum = nums[target] + nums[next[target]];
        let isAscending = true;

        while (curr !== null && next[curr] !== null) {
            if (nums[curr] > nums[next[curr]]) {
                isAscending = false;
            }

            let currAdjSum = nums[curr] + nums[next[curr]];
            if (currAdjSum < targetAdjSum) {
                target = curr;
                targetAdjSum = currAdjSum;
            }
            curr = next[curr];
        }

        if (isAscending) {
            break;
        }

        count++;
        next[target] = next[next[target]];
        nums[target] = targetAdjSum;
    }

    return count;
}
```

```TypeScript
function minimumPairRemoval(nums: number[]): number {
    const next = nums.map<number | null>((_, i) => i + 1);
    next[nums.length - 1] = null;
    let count = 0;

    while (nums.length - count > 1) {
        let curr: number | null = 0;
        let target = 0;
        let targetAdjSum = nums[target] + nums[next[target]!];
        let isAscending = true;

        while (curr !== null && next[curr] !== null) {
            if (nums[curr] > nums[next[curr]!]) {
                isAscending = false;
            }

            let currAdjSum = nums[curr] + nums[next[curr]!];
            if (currAdjSum < targetAdjSum) {
                target = curr;
                targetAdjSum = currAdjSum;
            }
            curr = next[curr];
        }

        if (isAscending) {
            break;
        }

        count++;
        next[target] = next[next[target]!];
        nums[target] = targetAdjSum;
    }

    return count;
}
```

```Go
func minimumPairRemoval(nums []int) int {
    n := len(nums)
    next := make([]int, n)

    for i := 0; i < n; i++ {
        next[i] = i + 1
    }
    next[n - 1] = -1
    count := 0
    for n - count > 1 {
        curr := 0
        target := 0
        targetAdjSum := nums[target] + nums[next[target]]
        isAscending := true

        for curr != -1 && next[curr] != -1 {
            if nums[curr] > nums[next[curr]] {
                isAscending = false
            }

            currAdjSum := nums[curr] + nums[next[curr]]
            if currAdjSum < targetAdjSum {
                target = curr
                targetAdjSum = currAdjSum
            }
            curr = next[curr]
        }

        if isAscending {
            break
        }

        count++
        next[target] = next[next[target]]
        nums[target] = targetAdjSum
    }

    return count
}
```

```C
int minimumPairRemoval(int* nums, int n) {
    int* next = (int*)malloc(n * sizeof(int));
    if (next == NULL) {
        return -1;
    }
    for (int i = 0; i < n; i++) {
        next[i] = i + 1;
    }
    next[n - 1] = -1;

    int count = 0;
    while (n - count > 1) {
        int curr = 0;
        int target = 0;
        int targetAdjSum = nums[target] + nums[next[target]];
        int isAscending = 1;

        while (curr != -1 && next[curr] != -1) {
            if (nums[curr] > nums[next[curr]]) {
                isAscending = 0;
            }

            int currAdjSum = nums[curr] + nums[next[curr]];
            if (currAdjSum < targetAdjSum) {
                target = curr;
                targetAdjSum = currAdjSum;
            }
            curr = next[curr];
        }
        if (isAscending) {
            break;
        }
        count++;
        next[target] = next[next[target]];
        nums[target] = targetAdjSum;
    }

    free(next);
    return count;
}
```

```Rust
impl Solution {
    pub fn minimum_pair_removal(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut nums = nums.clone();
        let mut next: Vec<isize> = (0..n as isize).map(|i| i + 1).collect();
        next[n - 1] = -1;

        let mut count = 0;

        while (n as i32 - count) > 1 {
            let mut curr: isize = 0;
            let mut target: isize = 0;
            let mut target_adj_sum = nums[0] + nums[next[0] as usize];
            let mut is_ascending = true;

            while curr != -1 && next[curr as usize] != -1 {
                let curr_idx = curr as usize;
                let next_idx = next[curr_idx] as usize;

                if nums[curr_idx] > nums[next_idx] {
                    is_ascending = false;
                }

                let curr_adj_sum = nums[curr_idx] + nums[next_idx];
                if curr_adj_sum < target_adj_sum {
                    target = curr;
                    target_adj_sum = curr_adj_sum;
                }
                curr = next[curr_idx];
            }

            if is_ascending {
                break;
            }

            count += 1;
            let target_idx = target as usize;
            let next_target = next[target_idx] as usize;
            next[target_idx] = next[next_target];
            nums[target_idx] = target_adj_sum;
        }

        count
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $nums$ 的长度。具体分析同方法一，只是删除操作此时只需 $O(1)$ 即可完成。
- 空间复杂度：$O(n)$，next 数组需要使用 $O(n)$ 的辅助空间。
