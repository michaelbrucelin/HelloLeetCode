### [使 K 个子数组内元素相等的最少操作数](https://leetcode.cn/problems/minimum-operations-to-make-elements-within-k-subarrays-equal/solutions/4048805/shi-k-ge-zi-shu-zu-nei-yuan-su-xiang-den-908x/)

#### 方法一：滑动窗口 + 对顶堆 + 数学 + 动态规划

**思路与算法**

题目给出一个整数数组 $nums$，我们可以对这个数组进行操作，每次操作可以将 $nums$ 中的任意元素加 $1$ 或减 $1$。除此之外题目还给出两个整数 $x$ 和 $k$，我们的任务是计算出最少的操作次数，使 $nums$ 中 **至少** 包含 $k$ 个长度 **恰好** 为 $x$ 的 **不重叠的子数组**，并且同一个子数组中的元素相等。

在思考本题前，我们先思考本题的一个拆分：对于一个能进行上述操作的整数数组 $nums$，如何计算出最少的操作数，使 $nums$ 中包含 $1$ 个长度 **恰好** 为 $x$ 的子数组，该子数组中元素相等。

很容易想到，用一个长度为 $x$ 的窗口在数组 $nums$ 上滑动，计算一个最少的操作次数，使当前窗口中所有元素相等。那么我们需要处理两个问题：

设当前窗口的起始位置为 $pos$

1. 选择什么值作为 $tag$ 能够最小化令当前窗口满足条件的操作次数，即：$\sum\limits_{i=pos}^{pos+x-1}\vert nums[i]-tag\vert$
2. 如何高效求出令每个窗口满足条件的最小操作次数？

对于问题 $1$，答案是选取窗口中的中位数为 $tag$，证明如下：

对于一个长度为 $x$ 的数组 $a=[a_0,a_1,\dots,a_{x-1}]$，我们需要找到一个数 $y$，使得 $\vert y-a_i\vert $ 的和最小，我们称 $\vert y-a_i\vert $ 为 $y$ 到 $a_i$ 的距离。假设 $a$ 已经排好序，若 $y$ 取 $a_{i-1}$ 和 $a_i$ 之间的数，那么 $y$ 左移一个单位，到右边 $x-i$ 个数的距离加一个单位，到左边 $i$ 个数的距离减少一个单位，总共增加了 $x-2i$ 个单位。易知当 $x-2i>0$ 时，说明 $y$ 向左移动会导致总距离增加，因此 $y$ 应该向右移动，反之 $y$ 应该向左移动，因此 $i$ 取 $\Big\lfloor\dfrac{x}{2}\Big\rfloor$ 是最优的，即中位数的下标。

对于问题 $2$，见[滑动窗口中位数](https://leetcode.cn/problems/sliding-window-median/description/)，我们可以使用滑动窗口和带延迟删除的对顶堆，在 $O(n\log n)$ 时间内求出每个窗口的中位数 $mid$，其中 $n$ 是数组的长度。在此基础上额外维护大根堆和小根堆中有效元素之和 $sumL$ 以及 $sumR$，用于求将窗口中元素全部转换为中位数的操作数量 $ops$，具体公式如下：

$$\begin{array}{rcl}ops & = & mid\times leftSize-sumL+sumR-mid\times rightSize \\ & = & sumR-sumL+mid\times (leftSize-rightSize)\end{array}$$

其中 $leftSize$ 和 $rightSize$ 分别是大根堆和小根堆中的有效元素数量，不包含已标记为删除但尚未弹出的元素。

解决了上述的两个问题就可以在 $O(n\log n)$ 时间内求出在数组 $nums$ 上令每个窗口满足条件的最小操作次数了。我们可以用一个数组 $ops$ 来保存这些值，其中 $ops[i]$ 表示窗口右边界为 $i$ 时，令该窗口中所有元素相等所需的最小操作次数。

那么原问题就被简化为如下表述：

给你一个整数数组 $nums$，对于该数组中每个窗口大小为 $x$ 的子数组，我们已知将其中元素变得相同的最小操作次数了，目标是从中 **恰好选取** $k$ 个不重叠的子数组，使这些子数组内部元素相等所需的总操作次数最少。

为什么只需要 **恰好选取** $k$ 个子数组呢？将一个子数组中元素转换为相等元素的操作数一定是非负的，因此从任意不少于 $k$ 个不重叠子数组的选择中保留 $k$ 个，总操作次数都不会增加。这里限制的是选取的子数组数量，最终数组中可以存在更多满足条件的子数组。

于是我们可以使用动态规划来解决上述问题。

设 $dp[i][j]$ 表示在前缀 $nums[0\dots i]$ 中选取 **恰好** $j$ 个长度为 $x$ 的不重叠子数组，并使每个子数组内部元素相同所需要的最小操作数。

转移方程如下：

$$dp[i][j]=min(dp[i-1][j],dp[i-x][j-1]+ops[i])$$

第一项 $dp[i-1][j]$ 表示不选取 $i$ 作为第 $j$ 段子数组的结尾，而第二项 $dp[i-x][j-1]+ops[i]$ 表示选取 $i$ 为第 $j$ 段子数组的结尾。

初始化如下：

首先将数组 $dp$ 中的元素初始化为无穷大，用于求操作的最小值。

- $j=0$ 时，对于任意的 $i$，dp[i][j]=0。
- $j=1$ 时，由于 $i<x-1$ 时 $1$ 个子数组都凑不出来，因此从 $i=x-1$ 初始化，即 $dp[x-1][j]=ops[x-1]$。
- $j>1$ 时，同 $j=1$ 的情况，$i<j\times x-1$ 时凑不出来 $j$ 个子数组，因此从 $i=j\times x-1$ 初始化，有 $dp[j\times x-1][j]=dp[(j-1)\times x-1][j-1]+ops[j\times x-1]$。每一个子数组首尾相接，这是最紧凑的情况，用递推式即可初始化。

答案为 $dp[n-1][k]$。

```C++
class Solution {
public:
    long long minOperations(vector<int>& nums, int x, int k) {
        int n = nums.size();
        priority_queue<int> Left;
        priority_queue<int, vector<int>, greater<int>> Right;
        unordered_map<int, int> delayed;
        int leftSize = 0, rightSize = 0;
        vector<long long> ops(n);
        long long sumL = 0, sumR = 0;

        auto prune = [&](auto& heap) {
            while (!heap.empty()) {
                if (delayed[heap.top()]) {
                    --delayed[heap.top()];
                    heap.pop();
                } else {
                    break;
                }
            }
        };

        auto balance = [&]() {
            if (leftSize > rightSize + 1) {
                int num = Left.top();
                Right.push(num);
                sumR += num;
                sumL -= num;
                Left.pop();
                ++rightSize;
                --leftSize;
                prune(Left);
            } else if (rightSize > leftSize) {
                int num = Right.top();
                Left.push(num);
                sumL += num;
                sumR -= num;
                Right.pop();
                ++leftSize;
                --rightSize;
                prune(Right);
            }
        };

        for (int i = 0; i < n; i++) {
            if (Left.empty() || nums[i] <= Left.top()) {
                Left.push(nums[i]);
                ++leftSize;
                sumL += nums[i];
            } else {
                Right.push(nums[i]);
                ++rightSize;
                sumR += nums[i];
            }
            balance();
            if (i >= x) {
                int num = nums[i - x];
                if (num <= Left.top()) {
                    --leftSize;
                    ++delayed[num];
                    sumL -= num;
                    if (num == Left.top()) {
                        prune(Left);
                    }
                } else {
                    --rightSize;
                    ++delayed[num];
                    sumR -= num;
                    if (num == Right.top()) {
                        prune(Right);
                    }
                }
                balance();
            }

            if (i >= x - 1) {
                long long mid = Left.top();
                ops[i] = sumR - sumL  + mid * (leftSize - rightSize);
            }
        }

        vector<vector<long long>> dp(n, vector<long long>(k + 1, LLONG_MAX));

        for (int i = 0; i < n; i++) {
            dp[i][0] = 0;
        }
        for (int j = 1; j <= k; j++) {
            if (j == 1) {
                dp[x - 1][j] = ops[x - 1];
            } else {
                dp[j * x - 1][j] = dp[(j - 1) * x - 1][j - 1] + ops[j * x - 1];
            }
        }
        for (int j = 1; j <= k; j++) {
            for (int i = j * x; i < n; i++) {
                dp[i][j] = min(dp[i - x][j - 1] + ops[i], dp[i - 1][j]);
            }
        }

        return dp[n - 1][k];
    }
};
```

```Go
func minOperations(nums []int, x int, k int) int64 {
    n := len(nums)
    left := &intHeap{isMax: true}
    right := &intHeap{}
    delayed := map[int]int{}
    leftSize, rightSize := 0, 0
    var sumL, sumR int64
    ops := make([]int64, n)

    prune := func(h *intHeap) {
        for h.Len() > 0 && delayed[h.data[0]] > 0 {
            delayed[h.data[0]]--
            heap.Pop(h)
        }
    }

    balance := func() {
        if leftSize > rightSize+1 {
            num := heap.Pop(left).(int)
            heap.Push(right, num)
            sumR += int64(num)
            sumL -= int64(num)
            rightSize++
            leftSize--
            prune(left)
        } else if rightSize > leftSize {
            num := heap.Pop(right).(int)
            heap.Push(left, num)
            sumL += int64(num)
            sumR -= int64(num)
            leftSize++
            rightSize--
            prune(right)
        }
    }

    for i, num := range nums {
        if left.Len() == 0 || num <= left.data[0] {
            heap.Push(left, num)
            leftSize++
            sumL += int64(num)
        } else {
            heap.Push(right, num)
            rightSize++
            sumR += int64(num)
        }
        balance()
        if i >= x {
            num := nums[i-x]
            delayed[num]++
            if num <= left.data[0] {
                leftSize--
                sumL -= int64(num)
                if num == left.data[0] {
                    prune(left)
                }
            } else {
                rightSize--
                sumR -= int64(num)
                if num == right.data[0] {
                    prune(right)
                }
            }
            balance()
        }
        if i >= x-1 {
            mid := int64(left.data[0])
            ops[i] = sumR - sumL + mid*int64(leftSize-rightSize)
        }
    }

    dp := make([][]int64, n)
    for i := range dp {
        dp[i] = make([]int64, k+1)
        for j := 1; j <= k; j++ {
            dp[i][j] = 1<<63 - 1
        }
    }
    for j := 1; j <= k; j++ {
        if j == 1 {
            dp[x-1][j] = ops[x-1]
        } else {
            dp[j*x-1][j] = dp[(j-1)*x-1][j-1] + ops[j*x-1]
        }
    }
    for j := 1; j <= k; j++ {
        for i := j * x; i < n; i++ {
            dp[i][j] = min(dp[i-x][j-1]+ops[i], dp[i-1][j])
        }
    }
    return dp[n-1][k]
}

type intHeap struct {
    data  []int
    isMax bool
}

func (h intHeap) Len() int { return len(h.data) }
func (h intHeap) Less(i, j int) bool {
    if h.isMax {
        return h.data[i] > h.data[j]
    }
    return h.data[i] < h.data[j]
}
func (h intHeap) Swap(i, j int) { h.data[i], h.data[j] = h.data[j], h.data[i] }
func (h *intHeap) Push(v any) { h.data = append(h.data, v.(int)) }
func (h *intHeap) Pop() any {
    n := len(h.data)
    v := h.data[n-1]
    h.data = h.data[:n-1]
    return v
}
```

```Python
class Solution:
    def minOperations(self, nums: List[int], x: int, k: int) -> int:
        n = len(nums)
        left, right = [], []
        delayed = defaultdict(int)
        left_size = right_size = 0
        sum_l = sum_r = 0
        ops = [0] * n

        def prune(h: List[int], sign: int) -> None:
            while h and delayed[sign * h[0]]:
                delayed[sign * h[0]] -= 1
                heappop(h)

        def balance() -> None:
            nonlocal left_size, right_size, sum_l, sum_r
            if left_size > right_size + 1:
                num = -heappop(left)
                heappush(right, num)
                sum_r += num
                sum_l -= num
                right_size += 1
                left_size -= 1
                prune(left, -1)
            elif right_size > left_size:
                num = heappop(right)
                heappush(left, -num)
                sum_l += num
                sum_r -= num
                left_size += 1
                right_size -= 1
                prune(right, 1)

        for i, num in enumerate(nums):
            if not left or num <= -left[0]:
                heappush(left, -num)
                left_size += 1
                sum_l += num
            else:
                heappush(right, num)
                right_size += 1
                sum_r += num
            balance()
            if i >= x:
                num = nums[i - x]
                delayed[num] += 1
                if num <= -left[0]:
                    left_size -= 1
                    sum_l -= num
                    if num == -left[0]:
                        prune(left, -1)
                else:
                    right_size -= 1
                    sum_r -= num
                    if num == right[0]:
                        prune(right, 1)
                balance()
            if i >= x - 1:
                mid = -left[0]
                ops[i] = sum_r - sum_l + mid * (left_size - right_size)

        dp = [[0] + [inf] * k for _ in range(n)]
        for j in range(1, k + 1):
            if j == 1:
                dp[x - 1][j] = ops[x - 1]
            else:
                dp[j * x - 1][j] = dp[(j - 1) * x - 1][j - 1] + ops[j * x - 1]
        for j in range(1, k + 1):
            for i in range(j * x, n):
                dp[i][j] = min(dp[i - x][j - 1] + ops[i], dp[i - 1][j])
        return dp[n - 1][k]
```

```Java
class Solution {
    private static class DualHeap {
        PriorityQueue<Integer> left = new PriorityQueue<>(Comparator.reverseOrder());
        PriorityQueue<Integer> right = new PriorityQueue<>();
        Map<Integer, Integer> delayed = new HashMap<>();
        int leftSize = 0, rightSize = 0;
        long sumL = 0, sumR = 0;

        void prune(PriorityQueue<Integer> heap) {
            while (!heap.isEmpty() && delayed.getOrDefault(heap.peek(), 0) > 0) {
                int num = heap.poll();
                delayed.put(num, delayed.get(num) - 1);
            }
        }

        void balance() {
            if (leftSize > rightSize + 1) {
                int num = left.poll();
                right.offer(num);
                sumR += num;
                sumL -= num;
                ++rightSize;
                --leftSize;
                prune(left);
            } else if (rightSize > leftSize) {
                int num = right.poll();
                left.offer(num);
                sumL += num;
                sumR -= num;
                ++leftSize;
                --rightSize;
                prune(right);
            }
        }

        void add(int num) {
            if (left.isEmpty() || num <= left.peek()) {
                left.offer(num);
                ++leftSize;
                sumL += num;
            } else {
                right.offer(num);
                ++rightSize;
                sumR += num;
            }
            balance();
        }

        void remove(int num) {
            delayed.put(num, delayed.getOrDefault(num, 0) + 1);
            if (num <= left.peek()) {
                --leftSize;
                sumL -= num;
                if (num == left.peek()) {
                    prune(left);
                }
            } else {
                --rightSize;
                sumR -= num;
                if (num == right.peek()) {
                    prune(right);
                }
            }
            balance();
        }
    }

    public long minOperations(int[] nums, int x, int k) {
        int n = nums.length;
        DualHeap heaps = new DualHeap();
        long[] ops = new long[n];
        for (int i = 0; i < n; ++i) {
            heaps.add(nums[i]);
            if (i >= x) {
                heaps.remove(nums[i - x]);
            }
            if (i >= x - 1) {
                long mid = heaps.left.peek();
                ops[i] = heaps.sumR - heaps.sumL + mid * (heaps.leftSize - heaps.rightSize);
            }
        }

        long[][] dp = new long[n][k + 1];
        for (int i = 0; i < n; ++i) {
            Arrays.fill(dp[i], Long.MAX_VALUE);
            dp[i][0] = 0;
        }
        for (int j = 1; j <= k; ++j) {
            if (j == 1) {
                dp[x - 1][j] = ops[x - 1];
            } else {
                dp[j * x - 1][j] = dp[(j - 1) * x - 1][j - 1] + ops[j * x - 1];
            }
        }
        for (int j = 1; j <= k; ++j) {
            for (int i = j * x; i < n; ++i) {
                dp[i][j] = Math.min(dp[i - x][j - 1] + ops[i], dp[i - 1][j]);
            }
        }
        return dp[n - 1][k];
    }
}
```

```CSharp
public class Solution {
    public long MinOperations(int[] nums, int x, int k) {
        int n = nums.Length;
        PriorityQueue<int, int> left = new PriorityQueue<int, int>();
        PriorityQueue<int, int> right = new PriorityQueue<int, int>();
        Dictionary<int, int> delayed = new Dictionary<int, int>();
        int leftSize = 0, rightSize = 0;
        long sumL = 0, sumR = 0;
        long[] ops = new long[n];

        void Prune(PriorityQueue<int, int> heap) {
            while (heap.Count > 0 && delayed.TryGetValue(heap.Peek(), out int count) && count > 0) {
                int num = heap.Dequeue();
                delayed[num] = count - 1;
            }
        }

        void Balance() {
            if (leftSize > rightSize + 1) {
                int num = left.Dequeue();
                right.Enqueue(num, num);
                sumR += num;
                sumL -= num;
                ++rightSize;
                --leftSize;
                Prune(left);
            } else if (rightSize > leftSize) {
                int num = right.Dequeue();
                left.Enqueue(num, -num);
                sumL += num;
                sumR -= num;
                ++leftSize;
                --rightSize;
                Prune(right);
            }
        }

        for (int i = 0; i < n; ++i) {
            int num = nums[i];
            if (left.Count == 0 || num <= left.Peek()) {
                left.Enqueue(num, -num);
                ++leftSize;
                sumL += num;
            } else {
                right.Enqueue(num, num);
                ++rightSize;
                sumR += num;
            }
            Balance();
            if (i >= x) {
                num = nums[i - x];
                delayed.TryGetValue(num, out int count);
                delayed[num] = count + 1;
                if (num <= left.Peek()) {
                    --leftSize;
                    sumL -= num;
                    if (num == left.Peek()) {
                        Prune(left);
                    }
                } else {
                    --rightSize;
                    sumR -= num;
                    if (num == right.Peek()) {
                        Prune(right);
                    }
                }
                Balance();
            }
            if (i >= x - 1) {
                long mid = left.Peek();
                ops[i] = sumR - sumL + mid * (leftSize - rightSize);
            }
        }

        long[,] dp = new long[n, k + 1];
        for (int i = 0; i < n; ++i) {
            for (int j = 1; j <= k; ++j) {
                dp[i, j] = long.MaxValue;
            }
        }
        for (int j = 1; j <= k; ++j) {
            if (j == 1) {
                dp[x - 1, j] = ops[x - 1];
            } else {
                dp[j * x - 1, j] = dp[(j - 1) * x - 1, j - 1] + ops[j * x - 1];
            }
        }
        for (int j = 1; j <= k; ++j) {
            for (int i = j * x; i < n; ++i) {
                dp[i, j] = Math.Min(dp[i - x, j - 1] + ops[i], dp[i - 1, j]);
            }
        }
        return dp[n - 1, k];
    }
}
```

```C
typedef struct {
    int* data;
    int size;
    bool isMax;
} MedianHeap;

typedef struct {
    int key;
    int count;
    UT_hash_handle hh;
} DelayedEntry;

typedef struct {
    MedianHeap left, right;
    DelayedEntry* delayed;
    int leftSize, rightSize;
    long long sumL, sumR;
} DualHeap;

static bool higherPriority(MedianHeap* heap, int a, int b) {
    return heap->isMax ? a > b : a < b;
}

static void heapPush(MedianHeap* heap, int num) {
    int i = heap->size++;
    while (i > 0) {
        int parent = (i - 1) / 2;
        if (!higherPriority(heap, num, heap->data[parent])) {
            break;
        }
        heap->data[i] = heap->data[parent];
        i = parent;
    }
    heap->data[i] = num;
}

static int heapPop(MedianHeap* heap) {
    int top = heap->data[0];
    int num = heap->data[--heap->size];
    if (heap->size == 0) {
        return top;
    }
    int i = 0;
    while (2 * i + 1 < heap->size) {
        int child = 2 * i + 1;
        if (child + 1 < heap->size &&
            higherPriority(heap, heap->data[child + 1], heap->data[child])) {
            ++child;
        }
        if (!higherPriority(heap, heap->data[child], num)) {
            break;
        }
        heap->data[i] = heap->data[child];
        i = child;
    }
    heap->data[i] = num;
    return top;
}

static void prune(DualHeap* heaps, MedianHeap* heap) {
    while (heap->size > 0) {
        int num = heap->data[0];
        DelayedEntry* entry;
        HASH_FIND_INT(heaps->delayed, &num, entry);
        if (entry == NULL || entry->count == 0) {
            break;
        }
        --entry->count;
        heapPop(heap);
    }
}

static void balance(DualHeap* heaps) {
    if (heaps->leftSize > heaps->rightSize + 1) {
        int num = heapPop(&heaps->left);
        heapPush(&heaps->right, num);
        heaps->sumR += num;
        heaps->sumL -= num;
        ++heaps->rightSize;
        --heaps->leftSize;
        prune(heaps, &heaps->left);
    } else if (heaps->rightSize > heaps->leftSize) {
        int num = heapPop(&heaps->right);
        heapPush(&heaps->left, num);
        heaps->sumL += num;
        heaps->sumR -= num;
        ++heaps->leftSize;
        --heaps->rightSize;
        prune(heaps, &heaps->right);
    }
}

static void addNum(DualHeap* heaps, int num) {
    if (heaps->left.size == 0 || num <= heaps->left.data[0]) {
        heapPush(&heaps->left, num);
        ++heaps->leftSize;
        heaps->sumL += num;
    } else {
        heapPush(&heaps->right, num);
        ++heaps->rightSize;
        heaps->sumR += num;
    }
    balance(heaps);
}

static void removeNum(DualHeap* heaps, int num) {
    DelayedEntry* entry;
    HASH_FIND_INT(heaps->delayed, &num, entry);
    if (entry == NULL) {
        entry = malloc(sizeof(DelayedEntry));
        entry->key = num;
        entry->count = 0;
        HASH_ADD_INT(heaps->delayed, key, entry);
    }
    ++entry->count;
    if (num <= heaps->left.data[0]) {
        --heaps->leftSize;
        heaps->sumL -= num;
        if (num == heaps->left.data[0]) {
            prune(heaps, &heaps->left);
        }
    } else {
        --heaps->rightSize;
        heaps->sumR -= num;
        if (num == heaps->right.data[0]) {
            prune(heaps, &heaps->right);
        }
    }
    balance(heaps);
}

long long minOperations(int* nums, int numsSize, int x, int k) {
    int n = numsSize;
    DualHeap heaps = {0};
    heaps.left.data = malloc(sizeof(int) * n);
    heaps.left.isMax = true;
    heaps.right.data = malloc(sizeof(int) * n);
    long long* ops = calloc(n, sizeof(long long));

    for (int i = 0; i < n; ++i) {
        addNum(&heaps, nums[i]);
        if (i >= x) {
            removeNum(&heaps, nums[i - x]);
        }
        if (i >= x - 1) {
            long long mid = heaps.left.data[0];
            ops[i] = heaps.sumR - heaps.sumL + mid * (heaps.leftSize - heaps.rightSize);
        }
    }

    long long (*dp)[k + 1] = calloc(n, sizeof(long long) * (k + 1));
    for (int i = 0; i < n; ++i) {
        dp[i][0] = 0;
        for (int j = 1; j <= k; ++j) {
            dp[i][j] = LLONG_MAX;
        }
    }
    for (int j = 1; j <= k; ++j) {
        if (j == 1) {
            dp[x - 1][j] = ops[x - 1];
        } else {
            dp[j * x - 1][j] = dp[(j - 1) * x - 1][j - 1] + ops[j * x - 1];
        }
    }
    for (int j = 1; j <= k; ++j) {
        for (int i = j * x; i < n; ++i) {
            long long cost = dp[i - x][j - 1] + ops[i];
            dp[i][j] = cost < dp[i - 1][j] ? cost : dp[i - 1][j];
        }
    }

    long long answer = dp[n - 1][k];
    DelayedEntry *entry, *tmp;
    HASH_ITER(hh, heaps.delayed, entry, tmp) {
        HASH_DEL(heaps.delayed, entry);
        free(entry);
    }
    free(heaps.left.data);
    free(heaps.right.data);
    free(ops);
    free(dp);
    return answer;
}
```

```JavaScript
var minOperations = function(nums, x, k) {
    const n = nums.length;
    const left = new MaxPriorityQueue();
    const right = new MinPriorityQueue();
    const delayed = new Map();
    let leftSize = 0, rightSize = 0;
    let sumL = 0, sumR = 0;
    const ops = Array(n).fill(0);

    const prune = (heap) => {
        while (!heap.isEmpty() && (delayed.get(heap.front()) || 0) > 0) {
            const num = heap.dequeue();
            delayed.set(num, delayed.get(num) - 1);
        }
    };

    const balance = () => {
        if (leftSize > rightSize + 1) {
            const num = left.dequeue();
            right.enqueue(num);
            sumR += num;
            sumL -= num;
            ++rightSize;
            --leftSize;
            prune(left);
        } else if (rightSize > leftSize) {
            const num = right.dequeue();
            left.enqueue(num);
            sumL += num;
            sumR -= num;
            ++leftSize;
            --rightSize;
            prune(right);
        }
    };

    for (let i = 0; i < n; ++i) {
        const num = nums[i];
        if (left.isEmpty() || num <= left.front()) {
            left.enqueue(num);
            ++leftSize;
            sumL += num;
        } else {
            right.enqueue(num);
            ++rightSize;
            sumR += num;
        }
        balance();
        if (i >= x) {
            const num = nums[i - x];
            delayed.set(num, (delayed.get(num) || 0) + 1);
            if (num <= left.front()) {
                --leftSize;
                sumL -= num;
                if (num === left.front()) {
                    prune(left);
                }
            } else {
                --rightSize;
                sumR -= num;
                if (num === right.front()) {
                    prune(right);
                }
            }
            balance();
        }
        if (i >= x - 1) {
            const mid = left.front();
            ops[i] = sumR - sumL + mid * (leftSize - rightSize);
        }
    }

    const dp = Array.from({ length: n }, () => Array(k + 1).fill(Infinity));
    for (let i = 0; i < n; ++i) {
        dp[i][0] = 0;
    }
    for (let j = 1; j <= k; ++j) {
        if (j === 1) {
            dp[x - 1][j] = ops[x - 1];
        } else {
            dp[j * x - 1][j] = dp[(j - 1) * x - 1][j - 1] + ops[j * x - 1];
        }
    }
    for (let j = 1; j <= k; ++j) {
        for (let i = j * x; i < n; ++i) {
            dp[i][j] = Math.min(dp[i - x][j - 1] + ops[i], dp[i - 1][j]);
        }
    }
    return dp[n - 1][k];
};
```

```TypeScript
function minOperations(nums: number[], x: number, k: number): number {
    const n = nums.length;
    const left = new MaxPriorityQueue<number>();
    const right = new MinPriorityQueue<number>();
    const delayed = new Map<number, number>();
    let leftSize = 0, rightSize = 0;
    let sumL = 0, sumR = 0;
    const ops = Array(n).fill(0);

    const prune = (heap: MaxPriorityQueue<number> | MinPriorityQueue<number>): void => {
        while (!heap.isEmpty() && (delayed.get(heap.front()!) || 0) > 0) {
            const num = heap.dequeue()!;
            delayed.set(num, delayed.get(num)! - 1);
        }
    };

    const balance = () => {
        if (leftSize > rightSize + 1) {
            const num = left.dequeue()!;
            right.enqueue(num);
            sumR += num;
            sumL -= num;
            ++rightSize;
            --leftSize;
            prune(left);
        } else if (rightSize > leftSize) {
            const num = right.dequeue()!;
            left.enqueue(num);
            sumL += num;
            sumR -= num;
            ++leftSize;
            --rightSize;
            prune(right);
        }
    };

    for (let i = 0; i < n; ++i) {
        const num = nums[i];
        if (left.isEmpty() || num <= left.front()!) {
            left.enqueue(num);
            ++leftSize;
            sumL += num;
        } else {
            right.enqueue(num);
            ++rightSize;
            sumR += num;
        }
        balance();
        if (i >= x) {
            const num = nums[i - x];
            delayed.set(num, (delayed.get(num) || 0) + 1);
            if (num <= left.front()!) {
                --leftSize;
                sumL -= num;
                if (num === left.front()!) {
                    prune(left);
                }
            } else {
                --rightSize;
                sumR -= num;
                if (num === right.front()!) {
                    prune(right);
                }
            }
            balance();
        }
        if (i >= x - 1) {
            const mid = left.front()!;
            ops[i] = sumR - sumL + mid * (leftSize - rightSize);
        }
    }

    const dp = Array.from({ length: n }, () => Array(k + 1).fill(Infinity));
    for (let i = 0; i < n; ++i) {
        dp[i][0] = 0;
    }
    for (let j = 1; j <= k; ++j) {
        if (j === 1) {
            dp[x - 1][j] = ops[x - 1];
        } else {
            dp[j * x - 1][j] = dp[(j - 1) * x - 1][j - 1] + ops[j * x - 1];
        }
    }
    for (let j = 1; j <= k; ++j) {
        for (let i = j * x; i < n; ++i) {
            dp[i][j] = Math.min(dp[i - x][j - 1] + ops[i], dp[i - 1][j]);
        }
    }
    return dp[n - 1][k];
}
```

```Rust
struct DualHeap {
    left: std::collections::BinaryHeap<i32>,
    right: std::collections::BinaryHeap<std::cmp::Reverse<i32>>,
    delayed: std::collections::HashMap<i32, i32>,
    left_size: i32,
    right_size: i32,
    sum_l: i64,
    sum_r: i64,
}

impl DualHeap {
    fn new() -> Self {
        Self {
            left: Default::default(),
            right: Default::default(),
            delayed: Default::default(),
            left_size: 0,
            right_size: 0,
            sum_l: 0,
            sum_r: 0,
        }
    }

    fn prune_left(&mut self) {
        while let Some(&num) = self.left.peek() {
            let count = self.delayed.entry(num).or_default();
            if *count == 0 {
                break;
            }
            *count -= 1;
            self.left.pop();
        }
    }

    fn prune_right(&mut self) {
        while let Some(&std::cmp::Reverse(num)) = self.right.peek() {
            let count = self.delayed.entry(num).or_default();
            if *count == 0 {
                break;
            }
            *count -= 1;
            self.right.pop();
        }
    }

    fn balance(&mut self) {
        if self.left_size > self.right_size + 1 {
            let num = self.left.pop().unwrap();
            self.right.push(std::cmp::Reverse(num));
            self.sum_r += i64::from(num);
            self.sum_l -= i64::from(num);
            self.right_size += 1;
            self.left_size -= 1;
            self.prune_left();
        } else if self.right_size > self.left_size {
            let num = self.right.pop().unwrap().0;
            self.left.push(num);
            self.sum_l += i64::from(num);
            self.sum_r -= i64::from(num);
            self.left_size += 1;
            self.right_size -= 1;
            self.prune_right();
        }
    }

    fn add(&mut self, num: i32) {
        if self.left.is_empty() || num <= *self.left.peek().unwrap() {
            self.left.push(num);
            self.left_size += 1;
            self.sum_l += i64::from(num);
        } else {
            self.right.push(std::cmp::Reverse(num));
            self.right_size += 1;
            self.sum_r += i64::from(num);
        }
        self.balance();
    }

    fn remove(&mut self, num: i32) {
        *self.delayed.entry(num).or_default() += 1;
        if num <= *self.left.peek().unwrap() {
            self.left_size -= 1;
            self.sum_l -= i64::from(num);
            if num == *self.left.peek().unwrap() {
                self.prune_left();
            }
        } else {
            self.right_size -= 1;
            self.sum_r -= i64::from(num);
            if num == self.right.peek().unwrap().0 {
                self.prune_right();
            }
        }
        self.balance();
    }
}

impl Solution {
    pub fn min_operations(nums: Vec<i32>, x: i32, k: i32) -> i64 {
        let n = nums.len();
        let x = x as usize;
        let k = k as usize;
        let mut heaps = DualHeap::new();
        let mut ops = vec![0_i64; n];
        for i in 0..n {
            heaps.add(nums[i]);
            if i >= x {
                heaps.remove(nums[i - x]);
            }
            if i >= x - 1 {
                let mid = i64::from(*heaps.left.peek().unwrap());
                ops[i] = heaps.sum_r - heaps.sum_l
                    + mid * i64::from(heaps.left_size - heaps.right_size);
            }
        }

        let mut dp = vec![vec![i64::MAX; k + 1]; n];
        for row in &mut dp {
            row[0] = 0;
        }
        for j in 1..=k {
            if j == 1 {
                dp[x - 1][j] = ops[x - 1];
            } else {
                dp[j * x - 1][j] = dp[(j - 1) * x - 1][j - 1] + ops[j * x - 1];
            }
        }
        for j in 1..=k {
            for i in j * x..n {
                dp[i][j] = (dp[i - x][j - 1] + ops[i]).min(dp[i - 1][j]);
            }
        }
        dp[n - 1][k]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+nk)$，其中 $n$ 是数组 $nums$ 的长度。滑动窗口部分共进行 $O(n)$ 次插入、堆间转移和删除操作。由于采用延迟删除，已经离开窗口但未到达堆顶的元素可能继续留在堆中，堆的实际大小最坏可达到 $O(n)$，因此单次堆操作需要 $O(\log n)$ 时间，预处理所有窗口代价需要 $O(n\log n)$ 时间。动态规划共有 $O(nk)$ 个状态，每个状态的转移需要 $O(1)$ 时间，因此总时间复杂度为 $O(n\log n+nk)$。
- 空间复杂度：$O(nk)$。两个堆、延迟删除哈希表和窗口代价数组 $ops$ 分别最多占用 $O(n)$ 空间；二维动态规划数组 $dp$ 占用 $O(nk)$ 空间，因此总空间复杂度为 $O(nk)$。

#### 方法二：滑动窗口 + 有序多重集合 + 数学 + 动态规划（滚动数组）

**思路与算法**

本方法沿用方法一的中位数结论和动态规划转移，只优化窗口的维护方式以及动态规划的空间。

**1\. 用两个有序多重集合维护窗口**

将方法一中的两个堆替换为两个有序多重集合 $Left$ 和 $Right$，分别保存窗口中较小的一半元素和较大的一半元素，并维护它们的元素和 sumL、sumR。始终保证：

- $Left$ 中的任意元素不大于 $Right$ 中的任意元素。
- $\vert Left\vert =\vert Right\vert $ 或 $\vert Left\vert =\vert Right\vert +1$。

每次滑动窗口，先根据新元素与 $Left$ 最大值的大小关系插入对应集合，再从集合中直接删除离开窗口的元素。注意每次只删除该值的一次出现，例如 $C++$ 中应先用 `find` 找到迭代器，再调用 `erase`，不能直接按值删除所有相同元素。最后根据两个集合的大小，将 $Left$ 的最大值或 $Right$ 的最小值转移到另一个集合，恢复大小关系，同时更新元素和。

此时 $Left$ 的最大值就是窗口的中位数，仍使用方法一的公式计算 $ops[i]$。由于可以直接删除指定元素，不再需要延迟删除哈希表，两个集合中最多暂存 $x+1$ 个元素，单次插入、查找和删除只需 $O(\log x)$ 时间。

对于不直接支持重复元素的有序容器，可以用有序映射记录每个值的出现次数，或将「元素值、原数组下标」组成二元组作为键，以区分相同值的不同元素。

**2\. 用滚动数组优化动态规划**

为了方便处理空前缀，这里改用前缀长度作为下标：计算第 $j$ 层时，$pre[i]$ 表示在前 $i$ 个元素中选取 $j-1$ 个子数组的最小操作数，$cur[i]$ 表示选取 $j$ 个子数组的最小操作数。转移为：

$$cur[i]=min(cur[i-1], pre[i-x]+ops[i-1])$$

初始时尚未选取子数组，因此 $pre[i]=0$。每次计算新的一层，先将 $cur$ 全部重置为无穷大，再从 $i=jx$ 开始递增枚举，保证前缀足够容纳 $j$ 个子数组，且 $cur[i-1]$ 已经计算完毕。计算完这一层后交换 $pre$ 和 $cur$，供下一层使用。

每一层只依赖上一层和本层已经计算的状态，因此只需保留两个长度为 $n+1$ 的数组。完成 $k$ 层转移后，答案为 $pre[n]$。

**代码**

```C++
class Solution {
    vector<long long> getCosts(const vector<int>& nums, int x) {
        int n = nums.size();
        vector<long long> ops(n);

        multiset<int> Left, Right;
        long long sumL = 0, sumR = 0;

        for (int i = 0; i < n; ++i) {
            int v = nums[i];
            if (Left.empty() || v <= *Left.rbegin()) {
                Left.insert(v);
                sumL += v;
            } else {
                Right.insert(v);
                sumR += v;
            }
            if (i >= x) {
                v = nums[i - x];
                auto it = Left.find(v);
                if (it != Left.end()) {
                    sumL -= v;
                    Left.erase(it);
                } else {
                    it = Right.find(v);
                    sumR -= v;
                    Right.erase(it);
                }
            }
            if (Left.size() > Right.size() + 1) {
                auto it = prev(Left.end());
                v = *it;
                Right.insert(v);
                Left.erase(it);
                sumL -= v;
                sumR += v;
            } else if (Left.size() < Right.size()) {
                auto it = Right.begin();
                v = *it;
                Left.insert(v);
                Right.erase(it);
                sumL += v;
                sumR -= v;
            }
            if (i >= x - 1) {
                long long mid = *Left.rbegin();
                long long leftCost = mid * (long long)Left.size() - sumL;
                long long rightCost = sumR - mid * (long long)Right.size();
                ops[i] = leftCost + rightCost;
            }
        }
        return ops;
    }

public:
    long long minOperations(vector<int>& nums, int x, int k) {
        int n = nums.size();
        vector<long long> ops = getCosts(nums, x);
        vector<long long> pre(n + 1, 0);
        vector<long long> cur(n + 1, LLONG_MAX);

        for (int j = 1; j <= k; ++j) {
            fill(cur.begin(), cur.end(), LLONG_MAX);
            for (int i = j * x; i <= n; ++i) {
                cur[i] = min(cur[i - 1], pre[i - x] + ops[i - 1]);
            }
            pre.swap(cur);
        }
        return pre[n];
    }
};
```

```Java
class Solution {
    private static class MultiSet {
        TreeMap<Integer, Integer> counts = new TreeMap<>();
        int size = 0;
        long sum = 0;

        void add(int value) {
            counts.put(value, counts.getOrDefault(value, 0) + 1);
            ++size;
            sum += value;
        }

        void remove(int value) {
            int count = counts.get(value);
            if (count == 1) {
                counts.remove(value);
            } else {
                counts.put(value, count - 1);
            }
            --size;
            sum -= value;
        }

        int min() {
            return counts.firstKey();
        }

        int max() {
            return counts.lastKey();
        }
    }

    private long[] getCosts(int[] nums, int x) {
        int n = nums.length;
        long[] ops = new long[n];
        MultiSet left = new MultiSet();
        MultiSet right = new MultiSet();

        for (int i = 0; i < n; ++i) {
            int value = nums[i];
            if (left.size == 0 || value <= left.max()) {
                left.add(value);
            } else {
                right.add(value);
            }
            if (i >= x) {
                value = nums[i - x];
                if (left.counts.containsKey(value)) {
                    left.remove(value);
                } else {
                    right.remove(value);
                }
            }
            if (left.size > right.size + 1) {
                value = left.max();
                left.remove(value);
                right.add(value);
            } else if (left.size < right.size) {
                value = right.min();
                right.remove(value);
                left.add(value);
            }
            if (i >= x - 1) {
                long mid = left.max();
                ops[i] = mid * left.size - left.sum + right.sum - mid * right.size;
            }
        }
        return ops;
    }

    public long minOperations(int[] nums, int x, int k) {
        int n = nums.length;
        long[] ops = getCosts(nums, x);
        long[] pre = new long[n + 1];
        long[] cur = new long[n + 1];

        for (int j = 1; j <= k; ++j) {
            Arrays.fill(cur, Long.MAX_VALUE);
            for (int i = j * x; i <= n; ++i) {
                cur[i] = Math.min(cur[i - 1], pre[i - x] + ops[i - 1]);
            }
            long[] temp = pre;
            pre = cur;
            cur = temp;
        }
        return pre[n];
    }
}
```

```Python
class Solution:
    def minOperations(self, nums: List[int], x: int, k: int) -> int:
        n = len(nums)
        left, right = SortedList(), SortedList()
        sum_l = sum_r = 0
        ops = [0] * n

        for i, value in enumerate(nums):
            if not left or value <= left[-1]:
                left.add(value)
                sum_l += value
            else:
                right.add(value)
                sum_r += value
            if i >= x:
                value = nums[i - x]
                if value in left:
                    left.remove(value)
                    sum_l -= value
                else:
                    right.remove(value)
                    sum_r -= value
            if len(left) > len(right) + 1:
                value = left.pop()
                right.add(value)
                sum_l -= value
                sum_r += value
            elif len(left) < len(right):
                value = right.pop(0)
                left.add(value)
                sum_l += value
                sum_r -= value
            if i >= x - 1:
                mid = left[-1]
                ops[i] = mid * len(left) - sum_l + sum_r - mid * len(right)

        pre = [0] * (n + 1)
        cur = [inf] * (n + 1)
        for j in range(1, k + 1):
            for i in range(n + 1):
                cur[i] = inf
            for i in range(j * x, n + 1):
                cur[i] = min(cur[i - 1], pre[i - x] + ops[i - 1])
            pre, cur = cur, pre
        return pre[n]
```

```CSharp
public class Solution {
    private long[] GetCosts(int[] nums, int x) {
        int n = nums.Length;
        long[] ops = new long[n];
        SortedSet<(int Value, int Index)> left = new SortedSet<(int Value, int Index)>();
        SortedSet<(int Value, int Index)> right = new SortedSet<(int Value, int Index)>();
        long sumL = 0, sumR = 0;

        for (int i = 0; i < n; ++i) {
            var item = (Value: nums[i], Index: i);
            if (left.Count == 0 || item.Value <= left.Max.Value) {
                left.Add(item);
                sumL += item.Value;
            } else {
                right.Add(item);
                sumR += item.Value;
            }
            if (i >= x) {
                var old = (Value: nums[i - x], Index: i - x);
                if (left.Remove(old)) {
                    sumL -= old.Value;
                } else {
                    right.Remove(old);
                    sumR -= old.Value;
                }
            }
            if (left.Count > right.Count + 1) {
                item = left.Max;
                left.Remove(item);
                right.Add(item);
                sumL -= item.Value;
                sumR += item.Value;
            } else if (left.Count < right.Count) {
                item = right.Min;
                right.Remove(item);
                left.Add(item);
                sumL += item.Value;
                sumR -= item.Value;
            }
            if (i >= x - 1) {
                long mid = left.Max.Value;
                ops[i] = mid * left.Count - sumL + sumR - mid * right.Count;
            }
        }
        return ops;
    }

    public long MinOperations(int[] nums, int x, int k) {
        int n = nums.Length;
        long[] ops = GetCosts(nums, x);
        long[] pre = new long[n + 1];
        long[] cur = new long[n + 1];

        for (int j = 1; j <= k; ++j) {
            Array.Fill(cur, long.MaxValue);
            for (int i = j * x; i <= n; ++i) {
                cur[i] = Math.Min(cur[i - 1], pre[i - x] + ops[i - 1]);
            }
            (pre, cur) = (cur, pre);
        }
        return pre[n];
    }
}
```

```TypeScript
import { AvlTree } from '@datastructures-js/binary-search-tree';

type Entry = [number, number];

function getCosts(nums: number[], x: number): number[] {
    const n = nums.length;
    const ops = Array(n).fill(0);
    const compare = (a: Entry, b: Entry): number => a[0] - b[0] || a[1] - b[1];
    const left = new AvlTree<Entry>(compare);
    const right = new AvlTree<Entry>(compare);
    let sumL = 0, sumR = 0;

    for (let i = 0; i < n; ++i) {
        let item: Entry = [nums[i], i];
        if (left.count() === 0 || item[0] <= left.max()!.getValue()[0]) {
            left.insert(item);
            sumL += item[0];
        } else {
            right.insert(item);
            sumR += item[0];
        }
        if (i >= x) {
            const old: Entry = [nums[i - x], i - x];
            if (left.remove(old)) {
                sumL -= old[0];
            } else {
                right.remove(old);
                sumR -= old[0];
            }
        }
        if (left.count() > right.count() + 1) {
            item = left.max()!.getValue();
            left.remove(item);
            right.insert(item);
            sumL -= item[0];
            sumR += item[0];
        } else if (left.count() < right.count()) {
            item = right.min()!.getValue();
            right.remove(item);
            left.insert(item);
            sumL += item[0];
            sumR -= item[0];
        }
        if (i >= x - 1) {
            const mid = left.max()!.getValue()[0];
            ops[i] = mid * left.count() - sumL + sumR - mid * right.count();
        }
    }
    return ops;
}

function minOperations(nums: number[], x: number, k: number): number {
    const n = nums.length;
    const ops = getCosts(nums, x);
    let pre = Array(n + 1).fill(0);
    let cur = Array(n + 1).fill(Infinity);

    for (let j = 1; j <= k; ++j) {
        cur.fill(Infinity);
        for (let i = j * x; i <= n; ++i) {
            cur[i] = Math.min(cur[i - 1], pre[i - x] + ops[i - 1]);
        }
        [pre, cur] = [cur, pre];
    }
    return pre[n];
}
```

```Go
import "github.com/emirpasic/gods/trees/redblacktree"

type multiSet struct {
    tree *redblacktree.Tree
    size int
    sum  int64
}

func (s *multiSet) add(value int) {
    count := 0
    if v, ok := s.tree.Get(value); ok {
        count = v.(int)
    }
    s.tree.Put(value, count+1)
    s.size++
    s.sum += int64(value)
}

func (s *multiSet) remove(value int) {
    v, _ := s.tree.Get(value)
    count := v.(int)
    if count == 1 {
        s.tree.Remove(value)
    } else {
        s.tree.Put(value, count-1)
    }
    s.size--
    s.sum -= int64(value)
}

func (s *multiSet) min() int { return s.tree.Left().Key.(int) }
func (s *multiSet) max() int { return s.tree.Right().Key.(int) }

func getCosts(nums []int, x int) []int64 {
    n := len(nums)
    ops := make([]int64, n)
    left := &multiSet{tree: redblacktree.NewWithIntComparator()}
    right := &multiSet{tree: redblacktree.NewWithIntComparator()}

    for i, value := range nums {
        if left.size == 0 || value <= left.max() {
            left.add(value)
        } else {
            right.add(value)
        }
        if i >= x {
            value = nums[i-x]
            if _, ok := left.tree.Get(value); ok {
                left.remove(value)
            } else {
                right.remove(value)
            }
        }
        if left.size > right.size+1 {
            value = left.max()
            left.remove(value)
            right.add(value)
        } else if left.size < right.size {
            value = right.min()
            right.remove(value)
            left.add(value)
        }
        if i >= x-1 {
            mid := int64(left.max())
            ops[i] = mid*int64(left.size) - left.sum + right.sum - mid*int64(right.size)
        }
    }
    return ops
}

func minOperations(nums []int, x int, k int) int64 {
    n := len(nums)
    ops := getCosts(nums, x)
    pre := make([]int64, n+1)
    cur := make([]int64, n+1)

    for j := 1; j <= k; j++ {
        for i := range cur {
            cur[i] = 1<<63 - 1
        }
        for i := j * x; i <= n; i++ {
            cur[i] = min(cur[i-1], pre[i-x]+ops[i-1])
        }
        pre, cur = cur, pre
    }
    return pre[n]
}
```

```C
typedef struct AVLNode {
    int value, count, height;
    struct AVLNode *left, *right;
} AVLNode;

typedef struct {
    AVLNode* root;
    int size;
    long long sum;
} MultiSet;

static int nodeHeight(AVLNode* node) {
    return node == NULL ? 0 : node->height;
}

static void updateHeight(AVLNode* node) {
    int left = nodeHeight(node->left);
    int right = nodeHeight(node->right);
    node->height = 1 + (left > right ? left : right);
}

static AVLNode* rotateRight(AVLNode* root) {
    AVLNode* next = root->left;
    root->left = next->right;
    next->right = root;
    updateHeight(root);
    updateHeight(next);
    return next;
}

static AVLNode* rotateLeft(AVLNode* root) {
    AVLNode* next = root->right;
    root->right = next->left;
    next->left = root;
    updateHeight(root);
    updateHeight(next);
    return next;
}

static AVLNode* rebalance(AVLNode* root) {
    if (root == NULL) {
        return NULL;
    }
    updateHeight(root);
    int diff = nodeHeight(root->left) - nodeHeight(root->right);
    if (diff > 1) {
        if (nodeHeight(root->left->left) < nodeHeight(root->left->right)) {
            root->left = rotateLeft(root->left);
        }
        return rotateRight(root);
    }
    if (diff < -1) {
        if (nodeHeight(root->right->right) < nodeHeight(root->right->left)) {
            root->right = rotateRight(root->right);
        }
        return rotateLeft(root);
    }
    return root;
}

static AVLNode* insertNode(AVLNode* root, int value) {
    if (root == NULL) {
        AVLNode* node = malloc(sizeof(AVLNode));
        *node = (AVLNode){value, 1, 1, NULL, NULL};
        return node;
    }
    if (value < root->value) {
        root->left = insertNode(root->left, value);
    } else if (value > root->value) {
        root->right = insertNode(root->right, value);
    } else {
        ++root->count;
        return root;
    }
    return rebalance(root);
}

static AVLNode* eraseNode(AVLNode* root, int value) {
    if (root == NULL) {
        return NULL;
    }
    if (value < root->value) {
        root->left = eraseNode(root->left, value);
    } else if (value > root->value) {
        root->right = eraseNode(root->right, value);
    } else {
        if (root->count > 1) {
            --root->count;
            return root;
        }
        if (root->left == NULL || root->right == NULL) {
            AVLNode* child = root->left != NULL ? root->left : root->right;
            free(root);
            return child;
        }
        AVLNode* next = root->right;
        while (next->left != NULL) {
            next = next->left;
        }
        root->value = next->value;
        root->count = next->count;
        next->count = 1;
        root->right = eraseNode(root->right, next->value);
    }
    return rebalance(root);
}

static bool contains(MultiSet* set, int value) {
    AVLNode* node = set->root;
    while (node != NULL) {
        if (value == node->value) {
            return true;
        }
        node = value < node->value ? node->left : node->right;
    }
    return false;
}

static int minValue(MultiSet* set) {
    AVLNode* node = set->root;
    while (node->left != NULL) {
        node = node->left;
    }
    return node->value;
}

static int maxValue(MultiSet* set) {
    AVLNode* node = set->root;
    while (node->right != NULL) {
        node = node->right;
    }
    return node->value;
}

static void addValue(MultiSet* set, int value) {
    set->root = insertNode(set->root, value);
    ++set->size;
    set->sum += value;
}

static void removeValue(MultiSet* set, int value) {
    set->root = eraseNode(set->root, value);
    --set->size;
    set->sum -= value;
}

static void freeTree(AVLNode* root) {
    if (root != NULL) {
        freeTree(root->left);
        freeTree(root->right);
        free(root);
    }
}

static long long* getCosts(int* nums, int n, int x) {
    long long* ops = calloc(n, sizeof(long long));
    MultiSet left = {0}, right = {0};

    for (int i = 0; i < n; ++i) {
        int value = nums[i];
        if (left.size == 0 || value <= maxValue(&left)) {
            addValue(&left, value);
        } else {
            addValue(&right, value);
        }
        if (i >= x) {
            value = nums[i - x];
            if (contains(&left, value)) {
                removeValue(&left, value);
            } else {
                removeValue(&right, value);
            }
        }
        if (left.size > right.size + 1) {
            value = maxValue(&left);
            removeValue(&left, value);
            addValue(&right, value);
        } else if (left.size < right.size) {
            value = minValue(&right);
            removeValue(&right, value);
            addValue(&left, value);
        }
        if (i >= x - 1) {
            long long mid = maxValue(&left);
            ops[i] = mid * left.size - left.sum + right.sum - mid * right.size;
        }
    }
    freeTree(left.root);
    freeTree(right.root);
    return ops;
}

long long minOperations(int* nums, int numsSize, int x, int k) {
    int n = numsSize;
    long long* ops = getCosts(nums, n, x);
    long long* pre = calloc(n + 1, sizeof(long long));
    long long* cur = malloc(sizeof(long long) * (n + 1));

    for (int j = 1; j <= k; ++j) {
        for (int i = 0; i <= n; ++i) {
            cur[i] = LLONG_MAX;
        }
        for (int i = j * x; i <= n; ++i) {
            long long cost = pre[i - x] + ops[i - 1];
            cur[i] = cur[i - 1] < cost ? cur[i - 1] : cost;
        }
        long long* temp = pre;
        pre = cur;
        cur = temp;
    }
    long long answer = pre[n];
    free(ops);
    free(pre);
    free(cur);
    return answer;
}
```

```Rust
impl Solution {
    fn get_costs(nums: &[i32], x: usize) -> Vec<i64> {
        let n = nums.len();
        let mut ops = vec![0_i64; n];
        let mut left = std::collections::BTreeSet::<(i32, usize)>::new();
        let mut right = std::collections::BTreeSet::<(i32, usize)>::new();
        let mut sum_l = 0_i64;
        let mut sum_r = 0_i64;

        for i in 0..n {
            let item = (nums[i], i);
            if left.is_empty() || item.0 <= left.last().unwrap().0 {
                left.insert(item);
                sum_l += i64::from(item.0);
            } else {
                right.insert(item);
                sum_r += i64::from(item.0);
            }
            if i >= x {
                let old = (nums[i - x], i - x);
                if left.remove(&old) {
                    sum_l -= i64::from(old.0);
                } else {
                    right.remove(&old);
                    sum_r -= i64::from(old.0);
                }
            }
            if left.len() > right.len() + 1 {
                let item = left.pop_last().unwrap();
                right.insert(item);
                sum_l -= i64::from(item.0);
                sum_r += i64::from(item.0);
            } else if left.len() < right.len() {
                let item = right.pop_first().unwrap();
                left.insert(item);
                sum_l += i64::from(item.0);
                sum_r -= i64::from(item.0);
            }
            if i >= x - 1 {
                let mid = i64::from(left.last().unwrap().0);
                ops[i] = mid * left.len() as i64 - sum_l + sum_r - mid * right.len() as i64;
            }
        }
        ops
    }

    pub fn min_operations(nums: Vec<i32>, x: i32, k: i32) -> i64 {
        let n = nums.len();
        let x = x as usize;
        let k = k as usize;
        let ops = Self::get_costs(&nums, x);
        let mut pre = vec![0_i64; n + 1];
        let mut cur = vec![i64::MAX; n + 1];

        for j in 1..=k {
            cur.fill(i64::MAX);
            for i in j * x..=n {
                cur[i] = cur[i - 1].min(pre[i - x] + ops[i - 1]);
            }
            std::mem::swap(&mut pre, &mut cur);
        }
        pre[n]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log x+nk)$，其中 $n$ 是数组 $nums$ 的长度。使用平衡树实现有序多重集合时，每次插入、查找、删除和转移元素需要 $O(\log x)$ 时间，窗口共移动 $O(n)$ 次，因此预处理所有窗口代价需要 $O(n\log x)$ 时间。动态规划共有 $k$ 层，每层重置滚动数组和计算转移均需 $O(n)$ 时间，因此总时间复杂度为 $O(n\log x+nk)$。
- 空间复杂度：$O(n)$。两个有序多重集合共保存 $O(x)$ 个元素，窗口代价数组 $ops$ 占用 $O(n)$ 空间，滚动数组 $pre$ 和 $cur$ 共占用 $O(n)$ 空间。由于 $x\le n$，总空间复杂度为 $O(n)$。
