跳跃游戏 IX

#### 方法一：区间分治

**思路与算法**

我们来模拟一下这个元素转移的过程。设 $nums$ 长度为 $n$，首先考虑全局最大值，设为 $r_{max1}$，其所在下标为 $i_1$。

该最大值把整个区间一分为二，容易发现，所有在 $i_1$ 右侧的元素都可以跳到 $r_{max1}$，显然对于这部分元素，这就是全局最优解。

然后考虑 $i_1$ 左侧的元素，我们取左侧这段区间 $[0,i_1-1]$ 的前缀最大值 $r_{max2}$，其所在下标为 $i_2$。这个最大值又将区间 $[0,i_1-1]$ 一分为二，我们还是先考虑这个区间上最大值右侧的元素，即区间 $[i_2,i_1-1]$ 上的元素，设刚刚前一个区间的右侧区间 $[i_1,n-1]$ 上的最小值是 $r_{min}$，则有以下两种情况：

- 如果 $r_{max2}\le r_{min}$，这说明当前区间内的所有元素都不能跳到 $i_1$ 的右侧区间 $[i_1,n-1]$ 上。因此当前右侧区间 $[i_2,i_1-1]$ 的这些元素只能转移到左侧区间 $[0,i_1-1]$ 的最大值 $r_{max2}$ 上，作为这些元素的最优解。
- 反之，若 $r_{max2}>r_{min}$，则当前右侧区间 $[i_2,i_1-1]$ 上的这些元素均可以先到达 $r_{max2}$，再通过右侧的 $r_{min}$ 元素中转，最终跳到右侧区间的最大值上，即这些元素的最优解是 $r_{max1}$。

类似地，我们会发现下一个区间 $[0,i_2-1]$ 上求解的过程有着和之前完全一样的子结构，都是要取前缀区间上的最大值，将区间一分为二，然后根据当前的右侧区间能否转移到上一个右侧区间进行分类讨论。故考虑基于区间分治的方法，动态转移右侧区间的最大值与最小值来求解本题。

预先维护前缀最大值，然后进行分治，分治的基本过程在上面的模拟中已经阐明的很详细了，剩下需要细化的是 $r_{min}$ 和 $r_{max}$ 的定义，以及如何动态转移。设当前遍历的前缀区间为 $[0,i]$，前缀最大值所在的位置是 $i^′$，根据区间 $[i^′,i]$ 能否转移到之前处理完的右侧区间上，有以下转移策略：

- $r_{max}$ 表示的是当前区间的目标最大值，也就是答案。对于 $r_{max}$，若可以转移到之前的右侧区间，则由于前一个区间的 $r_{max}$ 一定大于等于当前的前缀最大值，最大值直接继承之前的 $r_{max}$；若不能转移，则需要更新 $r_{max}$ 为当前的前缀最大值。
- 对于 $r_{min}$，确切的说，其表示的是 $r_{max}$ 的对应区间上，能转移到 $r_{max}$ 的元素中的最小值。因为 $r_{max}$ 的对应区间一定在当前区间的右侧，因此只要当前的前缀最大值大于 $r_{min}$，就意味着当前区间 $[i^′,i]$ 可以转移 $r_{max}$ 上，此时我们应该取新的 $r_{min}^′$ 为 $min(r_{min},i^′\le k\le imin(nums[k]))$，补充当前区间的值来更新 $r_{min}$。
- 实际上，对于不能转移的情况，我们仍然按上式更新 $r_{min}$。乍一看这样似乎存在问题，因为若无法转移到之前的右侧区间，则不应该考虑旧的 $r_{min}$，因为它代表的区间已经不可达了。但此时之前的 $r_{min}$ 一定大于等于当前区间的前缀最大值，故新的最小值一定在 $[i^′,i]$ 中产生，旧的 $r_{min}$ 即便参与计算也一定会被更新掉，相当于抛弃了旧的区间。所以我们更新的时候直接取 $min(r_{min},i^′\le k\le imin(nums[k]))$ 即可，本质上这里取的是 $[i^′,n-1]$ 上的后缀最小值。

按上述流程进行递归即可。

**代码**

```C++
class Solution {
public:
    vector<int> maxValue(vector<int>& nums) {
        int n = nums.size();
        vector<int> ans(n, 0);

        // [value, index]
        using Item = pair<int, int>;
        vector<Item> prevMax(n);

        Item prev = {INT_MIN, -1};
        for (int i = 0; i < n; ++i) {
            if (nums[i] > prev.first) {
                prev = {nums[i], i};
            }
            prevMax[i] = prev;
        }

        auto process = [&](auto& self, int r, int rightMin, int rightMax) -> void {
            auto [pMax, pivotIndex] = prevMax[r];
            int currMax = pMax <= rightMin ? pMax : rightMax;

            int nextRightMin = min(pMax, rightMin);
            for (int i = pivotIndex; i <= r; ++i) {
                ans[i] = currMax;
                nextRightMin = min(nextRightMin, nums[i]);
            }

            if (pivotIndex == 0) {
                return;
            }

            self(self, pivotIndex - 1, nextRightMin, currMax);
        };

        process(process, n - 1, INT_MAX, 0);

        return ans;
    }
};
```

```Java
class Solution {
    // [value, index]
    record Item(int value, int index) {}

    public int[] maxValue(int[] nums) {
        int n = nums.length;
        int[] ans = new int[n];
        Item[] prevMax = new Item[n];

        Item prev = new Item(Integer.MIN_VALUE, -1);
        for (int i = 0; i < n; i++) {
            if (nums[i] > prev.value()) {
                prev = new Item(nums[i], i);
            }
            prevMax[i] = prev;
        }

        process(n - 1, Integer.MAX_VALUE, 0, prevMax, ans, nums);
        return ans;
    }

    private void process(int r, int rightMin, int rightMax, Item[] prevMax, int[] ans, int[] nums) {
        int pMax = prevMax[r].value();
        int pivotIndex = prevMax[r].index();

        int currMax = pMax <= rightMin ? pMax : rightMax;

        int nextRightMin = Math.min(pMax, rightMin);
        for (int i = pivotIndex; i <= r; i++) {
            ans[i] = currMax;
            nextRightMin = Math.min(nextRightMin, nums[i]);
        }

        if (pivotIndex == 0) {
            return;
        }

        process(pivotIndex - 1, nextRightMin, currMax, prevMax, ans, nums);
    }
}
```

```Python
class Solution:
    def maxValue(self, nums: List[int]) -> List[int]:
        n = len(nums)

        ans = [0] * n
        # [value, index]
        prev_max = [(0, 0)] * n

        prev = (-math.inf, -1)
        for i, value in enumerate(nums):
            if value > prev[0]:
                prev = (value, i)
            prev_max[i] = prev

        def process(r: int, right_min: float, right_max: float) -> None:
            p_max, pivot_index = prev_max[r]
            curr_max = p_max if p_max <= right_min else right_max

            next_right_min = min(p_max, right_min)
            for i in range(pivot_index, r + 1):
                ans[i] = curr_max
                next_right_min = min(next_right_min, nums[i])

            if pivot_index == 0:
                return

            process(pivot_index - 1, next_right_min, curr_max)

        process(n - 1, math.inf, 0)

        return ans
```

```JavaScript
var maxValue = function(nums) {
    const n = nums.length;
    const ans = new Array(n).fill(0);

    const prevMax = new Array(n);

    nums.reduce(
        (prev, value, index) => {
            if (value > prev[0]) {
                prev = [value, index];
            }
            return (prevMax[index] = [...prev]);
        },
        [-Infinity, -1],
    );

    const process = (r, rightMin, rightMax) => {
        const [pMax, pivotIndex] = prevMax[r];
        const currMax = pMax <= rightMin ? pMax : rightMax;

        let nextRightMin = Math.min(pMax, rightMin);
        for (let i = pivotIndex; i <= r; i++) {
            ans[i] = currMax;
            nextRightMin = Math.min(nextRightMin, nums[i]);
        }

        if (pivotIndex === 0) {
            return;
        }

        process(pivotIndex - 1, nextRightMin, currMax);
    };

    process(n - 1, Infinity, 0);

    return ans;
};
```

```TypeScript
type Item = [number, number]; // [value, index]

function maxValue(nums: number[]): number[] {
    const n = nums.length;
    const ans = new Array<number>(n).fill(0);

    const prevMax: Item[] = new Array(n);

    nums.reduce(
        (prev, value, index) => {
            if (value > prev[0]) {
                prev = [value, index];
            }
            return (prevMax[index] = [...prev]);
        },
        [-Infinity, -1] as Item,
    );

    const process = (r: number, rightMin: number, rightMax: number) => {
        const [pMax, pivotIndex] = prevMax[r];
        const currMax = pMax <= rightMin ? pMax : rightMax;

        let nextRightMin = Math.min(pMax, rightMin);
        for (let i = pivotIndex; i <= r; i++) {
            ans[i] = currMax;
            nextRightMin = Math.min(nextRightMin, nums[i]);
        }

        if (pivotIndex === 0) {
            return;
        }

        process(pivotIndex - 1, nextRightMin, currMax);
    };

    process(n - 1, Infinity, 0);

    return ans;
}
```

```CSharp
public class Solution
{
    public int[] MaxValue(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        // [value, index]
        (int Value, int Index)[] prevMax = new (int, int)[n];

        (int Value, int Index) prev = (int.MinValue, -1);
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > prev.Value)
            {
                prev = (nums[i], i);
            }
            prevMax[i] = prev;
        }

        void Process(int r, int rightMin, int rightMax)
        {
            var (pMax, pivotIndex) = prevMax[r];
            int currMax = pMax <= rightMin ? pMax : rightMax;

            int nextRightMin = Math.Min(pMax, rightMin);
            for (int i = pivotIndex; i <= r; i++)
            {
                ans[i] = currMax;
                nextRightMin = Math.Min(nextRightMin, nums[i]);
            }

            if (pivotIndex == 0)
            {
                return;
            }

            Process(pivotIndex - 1, nextRightMin, currMax);
        }

        Process(n - 1, int.MaxValue, 0);
        return ans;
    }
}
```

```Go
func maxValue(nums []int) []int {
	n := len(nums)
	ans := make([]int, n)

	// [value, index] 对
	type Item struct {
		value int
		index int
	}
	prevMax := make([]Item, n)

	prev := Item{math.MinInt32, -1}
	for i := 0; i < n; i++ {
		if nums[i] > prev.value {
			prev = Item{nums[i], i}
		}
		prevMax[i] = prev
	}

	var process func(r int, rightMin int, rightMax int)
	process = func(r int, rightMin int, rightMax int) {
		pMax := prevMax[r].value
		pivotIndex := prevMax[r].index

		currMax := pMax
		if pMax <= rightMin {
			currMax = pMax
		} else {
			currMax = rightMax
		}

		nextRightMin := rightMin
		if pMax < nextRightMin {
			nextRightMin = pMax
		}
		for i := pivotIndex; i <= r; i++ {
			ans[i] = currMax
			if nums[i] < nextRightMin {
				nextRightMin = nums[i]
			}
		}

		if pivotIndex == 0 {
			return
		}

		process(pivotIndex-1, nextRightMin, currMax)
	}

	process(n-1, math.MaxInt32, 0)

	return ans
}
```

```C
typedef struct {
    int value;
    int index;
} Item;

void process(int* nums, int* ans, Item* prevMax, int r, int rightMin, int rightMax) {
    int pMax = prevMax[r].value;
    int pivotIndex = prevMax[r].index;

    int currMax = (pMax <= rightMin) ? pMax : rightMax;

    int nextRightMin = (pMax < rightMin) ? pMax : rightMin;
    for (int i = pivotIndex; i <= r; i++) {
        ans[i] = currMax;
        if (nums[i] < nextRightMin) {
            nextRightMin = nums[i];
        }
    }

    if (pivotIndex == 0) {
        return;
    }

    process(nums, ans, prevMax, pivotIndex - 1, nextRightMin, currMax);
}

int* maxValue(int* nums, int numsSize, int* returnSize) {
    int* ans = (int*)malloc(numsSize * sizeof(int));
    memset(ans, 0, numsSize * sizeof(int));
    Item* prevMax = (Item*)malloc(numsSize * sizeof(Item));

    Item prev = {INT_MIN, -1};
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] > prev.value) {
            prev.value = nums[i];
            prev.index = i;
        }
        prevMax[i] = prev;
    }

    process(nums, ans, prevMax, numsSize - 1, INT_MAX, 0);

    free(prevMax);
    *returnSize = numsSize;
    return ans;
}
```

```Rust
impl Solution {
    pub fn max_value(nums: Vec<i32>) -> Vec<i32> {
        let n = nums.len();

        let mut ans = vec![0; n];
        // [value, index]
        let mut prev_max = vec![(0, 0_isize); n];

        let mut prev = (std::i32::MIN, -1_isize);
        for (i, &value) in nums.iter().enumerate() {
            if value > prev.0 {
                prev = (value, i as isize);
            }
            prev_max[i] = prev;
        }

        fn process(
            r: isize,
            right_min: i32,
            right_max: i32,
            nums: &[i32],
            prev_max: &[(i32, isize)],
            ans: &mut [i32],
        ) {
            let (p_max, pivot_index) = prev_max[r as usize];
            let curr_max = if p_max <= right_min { p_max } else { right_max };

            let mut next_right_min = p_max.min(right_min);
            for i in pivot_index..=r {
                ans[i as usize] = curr_max;
                next_right_min = next_right_min.min(nums[i as usize]);
            }

            if pivot_index == 0 {
                return;
            }

            process(pivot_index - 1, next_right_min, curr_max, nums, prev_max, ans);
        }

        process((n - 1) as isize, std::i32::MAX, 0, &nums, &prev_max, &mut ans);

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。预处理前缀最大值需要 $O(n)$；区间分治的区间刚好严格覆盖整个 $nums$，因此区间分治总耗时也是 $O(n)$。
- 空间复杂度：$O(n)$，前缀最大值需要 $O(n)$ 的空间。

#### 方法二：单调栈

**思路与算法**

让我们从另一个角度分析此问题，题设条件实质上可以等价于：若 $nums$ 中的两个元素构成**逆序对**，则可以**互相到达**。维护元素间的连通情况，实质上就是在**维护一个无向图的连通块**。

观察由逆序对构成的连通块，易发现以下关键事实：对于当前元素 $nums[i]$ 和左侧的任意连通块，只要它小于这个连通块内的最大值，就可以与其合并；同时由于连通性是**双向**的，这些连通块也可以由 $nums[i]$ 作为中转而相互到达，最后整体形成了一个新的连通块。

考虑不等式的传递性，假设从左到右已经有两个独立且相邻的连通块 $A$ 和 $B$，则必须满足块 $A$ 的最大值 $a_{max}$ 小于等于块 $B$ 的最大值 $b_{max}$，那么当前元素只要能与 $A$ 合并（即 $nums[i]<a_{max}$），就一定可以与 $B$ 合并（此时有 $nums[i]<a_{max}\le b_{max}$），最后块 A、块 $B$ 和当前元素 $nums$ 形成了一个新的大连通块。

这实质上暗示了：由逆序对构成的连通块在原数组 $nums$ 上也一定是**连续**的，相邻连通块上的最大值一定不存在逆序关系（即具有**单调性**）；同时连通性的维护只取决于相邻块上的最大值，且不需要考虑跨越不同块的情况。

基于以上性质，我们就不需要再去考虑到达极值点的具体移动路径，可以配合单调栈实现的区间合并来维护连通性，连通块内的任意元素自然都能到达块内的最大值。

由于我们证明了这些连通块在原数组上一定是连续的，因此可以用一个三元组 $(value,left,right)$ 描述每个连通块的最大值和左右边界。维护一个单调栈，从左向右扫描 $nums$，对于遍历到的每个元素 $nums[i]$，不断从栈顶弹出左侧的连通块进行合并，直到合并不了为止，将新的连通块压入单调栈。最后每个连通块内的答案就等于该连通块上的最大值。

**代码**

```C++
class Solution {
public:
    struct Item {
        int value;
        int left;
        int right;
    };

    vector<int> maxValue(const vector<int>& nums) {
        int n = nums.size();
        vector<int> ans(n, 0);

        vector<Item> stack;

        for (int i = 0; i < n; ++i) {
            Item curr = {nums[i], i, i};

            while (!stack.empty() && stack.back().value > nums[i]) {
                Item top = stack.back();
                stack.pop_back();
                curr.value = max(curr.value, top.value);
                curr.left = top.left;
            }

            stack.push_back(curr);
        }

        for (size_t i = 0; i < stack.size(); ++i) {
            for (int j = stack[i].left; j <= stack[i].right; ++j) {
                ans[j] = stack[i].value;
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    record Item(int value, int left, int right) {}

    public int[] maxValue(int[] nums) {
        int n = nums.length;
        int[] ans = new int[n];

        List<Item> stack = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            Item curr = new Item(nums[i], i, i);

            while (!stack.isEmpty() && stack.getLast().value() > nums[i]) {
                Item top = stack.removeLast();
                curr = new Item(Math.max(curr.value(), top.value()), top.left(), curr.right());
            }

            stack.add(curr);
        }

        for (int i = 0; i < stack.size(); i++) {
            for (int j = stack.get(i).left(); j <= stack.get(i).right(); j++) {
                ans[j] = stack.get(i).value();
            }
        }

        return ans;
    }
}
```

```Python
class Solution:
    def maxValue(self, nums: List[int]) -> List[int]:
        n = len(nums)
        ans = [0] * n
        # [value, left, right]
        stack = []

        for i in range(n):
            curr_val = nums[i]
            curr_left = i
            curr_right = i

            while stack and stack[-1][0] > nums[i]:
                top_val, top_left, top_right = stack.pop()
                curr_val = max(curr_val, top_val)
                curr_left = top_left

            stack.append((curr_val, curr_left, curr_right))

        for i in range(len(stack)):
            for j in range(stack[i][1], stack[i][2] + 1):
                ans[j] = stack[i][0]

        return ans

```

```JavaScript
var maxValue = function (nums) {
    const n = nums.length;
    const ans = new Array(n);

    const stack = [];

    for (let i = 0; i < n; i++) {
        let curr = {
            value: nums[i],
            left: i,
            right: i,
        };

        while (stack.length > 0 && stack.at(-1).value > nums[i]) {
            const top = stack.pop();
            curr = {
                value: Math.max(curr.value, top.value),
                left: top.left,
                right: curr.right,
            };
        }

        stack.push(curr);
    }

    for (let i = 0; i < stack.length; i++) {
        for (let j = stack[i].left; j <= stack[i].right; j++) {
            ans[j] = stack[i].value;
        }
    }

    return ans;
}
```

```TypeScript
interface Item {
    value: number;
    left: number;
    right: number;
}

function maxValue(nums: number[]): number[] {
    const n = nums.length;
    const ans = new Array<number>(n);

    const stack: Item[] = [];

    for (let i = 0; i < n; i++) {
        let curr: Item = {
            value: nums[i],
            left: i,
            right: i,
        };

        while (stack.length > 0 && stack.at(-1)!.value > nums[i]) {
            const top = stack.pop()!;
            curr = {
                value: Math.max(curr.value, top.value),
                left: top.left,
                right: curr.right,
            };
        }

        stack.push(curr);
    }

    for (let i = 0; i < stack.length; i++) {
        for (let j = stack[i].left; j <= stack[i].right; j++) {
            ans[j] = stack[i].value;
        }
    }

    return ans;
}
```

```CSharp
public class Solution
{
    public int[] MaxValue(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];

        List<(int Value, int Left, int Right)> stack = new();

        for (int i = 0; i < n; i++)
        {
            var curr = (Value: nums[i], Left: i, Right: i);

            while (stack.Count > 0 && stack[^1].Value > nums[i])
            {
                var top = stack[^1];
                stack.RemoveAt(stack.Count - 1);
                curr = (Math.Max(curr.Value, top.Value), top.Left, curr.Right);
            }

            stack.Add(curr);
        }

        for (int i = 0; i < stack.Count; i++)
        {
            for (int j = stack[i].Left; j <= stack[i].Right; j++)
            {
                ans[j] = stack[i].Value;
            }
        }

        return ans;
    }
}
```

```Go
func maxValue(nums []int) []int {
	n := len(nums)
	ans := make([]int, n)

	type Item struct {
		value int
		left  int
		right int
	}

	stack := make([]Item, 0)
	for i := 0; i < n; i++ {
		curr := Item{nums[i], i, i}

		for len(stack) > 0 && stack[len(stack)-1].value > nums[i] {
			top := stack[len(stack)-1]
			stack = stack[:len(stack)-1]
			if top.value > curr.value {
				curr.value = top.value
			}
			curr.left = top.left
		}

		stack = append(stack, curr)
	}

	for i := 0; i < len(stack); i++ {
		for j := stack[i].left; j <= stack[i].right; j++ {
			ans[j] = stack[i].value
		}
	}

	return ans
}
```

```C
typedef struct {
    int value;
    int left;
    int right;
} Item;

int* maxValue(const int* nums, int numsSize, int* returnSize) {
    int* ans = (int*)malloc(numsSize * sizeof(int));
    memset(ans, 0, numsSize * sizeof(int));

    Item* stack = (Item*)malloc(numsSize * sizeof(Item));
    int stackSize = 0;
    for (int i = 0; i < numsSize; i++) {
        Item curr = {nums[i], i, i};
        while (stackSize > 0 && stack[stackSize - 1].value > nums[i]) {
            Item top = stack[stackSize - 1];
            stackSize--;
            curr.value = (top.value > curr.value) ? top.value : curr.value;
            curr.left = top.left;
        }

        stack[stackSize++] = curr;
    }

    for (int i = 0; i < stackSize; i++) {
        for (int j = stack[i].left; j <= stack[i].right; j++) {
            ans[j] = stack[i].value;
        }
    }

    free(stack);
    *returnSize = numsSize;
    return ans;
}
```

```Rust
impl Solution {
    pub fn max_value(nums: Vec<i32>) -> Vec<i32> {
        let n = nums.len();

        let mut ans = vec![0; n];

        struct Item {
            value: i32,
            left: usize,
            right: usize,
        }

        let mut stack: Vec<Item> = Vec::new();

        for i in 0..n {
            let mut curr = Item {
                value: nums[i],
                left: i,
                right: i,
            };

            while let Some(top) = stack.last() {
                if top.value > nums[i] {
                    let top = stack.pop().unwrap();
                    curr.value = curr.value.max(top.value);
                    curr.left = top.left;
                } else {
                    break;
                }
            }

            stack.push(curr);
        }

        for i in 0..stack.len() {
            for j in stack[i].left..=stack[i].right {
                ans[j] = stack[i].value;
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度，单调栈的进出次数对应 $nums$ 元素个数，累计后最多等于 $2n$，故所需时间严格为 $O(n)$。此外，根据单调栈维护的连通区间计算答案需要 $O(n)$，故总时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$，单调栈需要 $O(n)$ 的空间。
