### [交换得到字典序最小的数组](https://leetcode.cn/problems/make-lexicographically-smallest-array-by-swapping-elements/solutions/4011271/jiao-huan-de-dao-zi-dian-xu-zui-xiao-de-nvtg9/)

#### 方法一：排序

在正式解答本题前，我们提前说明一个重要结论，有助于读者解决一些不限制交换操作次数和顺序的类似题目。

依据题目给出的交换规则，如果元素 $x$ 可以与 $y$ 交换，$y$ 又可以与 $z$ 交换，那么即使 $x$ 和 $z$ 不能直接交换，我们仍然能够借助 $y$ 完成它们的位置互换。

假如当前 $x$，$y$，$z$ 的位置情况如下：

$$[\dots x\dots y\dots z\dots ]$$

先交换 $x$ 和 $y$：

$$[\dots y\dots x\dots z\dots ]$$

再交换 $y$ 和 $z$：

$$[\dots z\dots x\dots y\dots ]$$

最后交换 $x$ 和 $y$：

$$[\dots z\dots y\dots x\dots ]$$

这样就在不影响其他元素的情况下，实现了 $x$ 与 $z$ 的交换。

推广至一般情况，如果我们将每个元素视为一个节点，并在符合交换条件的元素之间两两连边，那么 **处于同一连通块中的元素，可以通过若干次合法交换任意重新排列**。反之，位于不同连通块中的元素则无法进行任何交换操作。

---

**思路与算法**

回到本题，题目中给出的交换规则为：对于下标 $i$ 和 $j$，只有当

$$\vert nums[i]-nums[j]\vert \le limit$$

时，才能交换这两个位置上的元素。

按照前文给出的结论，我们在符合以上交换条件的元素之间两两连边，并独立处理每个连通块。

为了使最终数组的字典序最小，应当让较小的元素尽可能出现在更靠前的位置。因此只需将连通块内的元素按 **非递减** 顺序排列，再从左至右依次放入数组的原位置中。详细的处理操作如下：

1. 记录该连通块中所有元素的原下标，同时收集元素值；
2. 将元素值按非递减顺序排序；
3. 将排好序的元素值从左至右填回原下标位置。

假如数组长度为 $n$，朴素的连边操作要求遍历每一对元素并判断他们是否需要连边，这将导致 $O(n^2)$ 的时间复杂度，在本题的数据规模下会超过时间限制。

由于题目所给限制条件的特殊性，我们有复杂度更低的做法：

1. 将数组 $nums$ 按非递减顺序排序；
2. 每个连通块在排序后的数组中对应一个连续区间。从左到右扫描排序后的数组，根据相邻元素差值是否超过 $limit$ 来划分连通块；
3. 对每个连通块执行上述的处理操作。

- 提示: 由于最终还需要将元素放回原数组中的对应位置，因此排序时需要同时保存元素值及其原始下标，这样在确定连通块后，便能够获得该连通块内所有元素的原下标，并完成答案的构造。

下面我们说明该做法的正确性。

设排序后的数组为：

$$v0\le v1\le \dots \le v{n-1}$$

由于数组已经有序，在 $j<i$ 时，有 $v_j\le v_i$，因此：

$$\vert v_i-v_j\vert =v_i-v_j$$

此时题目的限制条件等同于：

$$v_i-v_j\le limit$$

下面我们说明，我们只需要考虑排序后相邻元素之间的关系，即可完整构建连通关系图。

我们从左到右遍历元素并考虑该元素与数组中其他元素的连边关系。

假如现在考虑到了元素 $v_i$。由于边是无向的，我们只需考虑 $v_i$ 与其左侧元素 $v_j(j<i)$ 可能存在的连边，$v_i$ 与其右侧元素的连边关系将在后续的遍历中考虑到。

##### 1. $v_i-v_{i-1}\le limit$

我们将 $v_i$ 与 $v_{i-1}$ 相连。

对于左侧剩余的元素 $v_j$，如果：

$$v_i-v_j\le limit,$$

那么 $v_i$ 与 $v_j$ 也应该相连。注意到数组已经有序，我们有：

$$v_{i-1}\le v_i$$

进而：

$$v_{i-1}-v_j\le v_i-v_j\le limit,$$

也就是说，在考虑 $v_i$ 前，$v_{i-1}$ 与 $v_j$ 已经位于同一个连通块中了。因此，在 $v_i$ 与 $v_{i-1}$ 连边后，$v_i$ 与左侧所有元素可能存在的连边关系都已经完整考虑到了。

##### 2. $v_i-v_{i-1}>limit$

由于数组已经有序，因此对于任意 $j\le i-1$：

$$v_j\le v_{i-1}$$

进而：

$$v_i-v_j\ge v_i-v_{i-1}>limit$$

因此 $v_i$ 与其左侧元素不存在任何连边关系。

综上所述，排序后所有满足

$$v_i-v_{i-1}\le limit$$

的相邻元素会被划分到同一个连通块中，而一旦出现

$$v_i-v_{i-1}>limit,$$

连通块就会在此处分裂。

换句话说，每个连通块在排序后的数组中一定对应一个连续区间。因此我们只需从左到右扫描排序后的数组，根据相邻元素差值是否超过 $limit$ 来划分连通块即可。

**代码**

```C++
class Solution {
public:
    vector<int> lexicographicallySmallestArray(vector<int>& nums, int limit) {
        int n = nums.size();
        vector<int> ans(n, 0);

        // 将元素值与原下标绑定
        vector<pair<int, int>> arr;
        for (int i = 0; i < n; i++) {
            arr.push_back({nums[i], i});
        }

        // 按元素值升序排序
        sort(arr.begin(), arr.end());

        vector<int> values, indices;
        for (auto& p : arr) {
            values.push_back(p.first);
            indices.push_back(p.second);
        }

        int i = 0;
        while (i < n) {
            int start = i;

            // 当前连通块中的原下标
            vector<int> groupIndices;

            // 当前连通块中的元素值
            vector<int> groupValues;

            while (i < n && (i == start || values[i] - values[i - 1] <= limit)) {
                groupIndices.push_back(indices[i]);
                groupValues.push_back(values[i]);
                i++;
            }

            // 由于元素值数组已经有序，这里不需要再排序
            sort(groupIndices.begin(), groupIndices.end());

            // 为得到字典序最小的结果，将较小元素放到较小下标处
            for (int k = 0; k < groupIndices.size(); k++) {
                ans[groupIndices[k]] = groupValues[k];
            }
        }

        return ans;
    }
};
```

```Python
class Solution:
    def lexicographicallySmallestArray(self, nums: List[int], limit: int) -> List[int]:
        n = len(nums)
        ans = [0] * n

        # 将元素值与原下标绑定
        arr = [(x, i) for i, x in enumerate(nums)]

        # 按元素值升序排序
        arr.sort(key=lambda p: p[0])

        values = [value for value, _ in arr]
        indices = [index for _, index in arr]

        i = 0
        while i < n:
            start = i

            # 当前连通块中的原下标
            groupIndices = []

            # 当前连通块中的元素值
            groupValues = []

            while i < n and (i == start or values[i] - values[i - 1] <= limit):
                groupIndices.append(indices[i])
                groupValues.append(values[i])
                i += 1

            # 由于元素值数组已经有序，这里不需要再排序
            groupIndices.sort()

            # 为得到字典序最小的结果，将较小元素放到较小下标处
            for index, value in zip(groupIndices, groupValues):
                ans[index] = value

        return ans
```

```Rust
impl Solution {
    pub fn lexicographically_smallest_array(nums: Vec<i32>, limit: i32) -> Vec<i32> {
        let n = nums.len();
        let mut ans = vec![0; n];

        // 将元素值与原下标绑定
        let mut arr: Vec<(i32, usize)> = nums
            .into_iter()
            .enumerate()
            .map(|(i, x)| (x, i))
            .collect();

        // 按元素值升序排序
        arr.sort_by_key(|p| p.0);

        let values: Vec<i32> = arr.iter().map(|p| p.0).collect();
        let indices: Vec<usize> = arr.iter().map(|p| p.1).collect();

        let mut i = 0;
        while i < n {
            let start = i;

            // 当前连通块中的原下标
            let mut groupIndices = Vec::new();

            // 当前连通块中的元素值
            let mut groupValues = Vec::new();

            while i < n
                && (i == start || values[i] - values[i - 1] <= limit)
            {
                groupIndices.push(indices[i]);
                groupValues.push(values[i]);
                i += 1;
            }

            // 由于元素值数组已经有序，这里不需要再排序
            groupIndices.sort();

            // 为得到字典序最小的结果，将较小元素放到较小下标处
            for (index, value) in groupIndices.into_iter().zip(groupValues.into_iter()) {
                ans[index] = value;
            }
        }

        ans
    }
}
```

```Java
class Solution {
    public int[] lexicographicallySmallestArray(int[] nums, int limit) {
        int n = nums.length;
        int[] ans = new int[n];

        // 将元素值与原下标绑定
        int[][] arr = new int[n][2];
        for (int i = 0; i < n; i++) {
            arr[i][0] = nums[i];
            arr[i][1] = i;
        }

        // 按元素值升序排序
        Arrays.sort(arr, (a, b) -> Integer.compare(a[0], b[0]));

        int[] values = new int[n];
        int[] indices = new int[n];

        for (int i = 0; i < n; i++) {
            values[i] = arr[i][0];
            indices[i] = arr[i][1];
        }

        int i = 0;
        while (i < n) {
            int start = i;

            // 当前连通块中的原下标
            List<Integer> groupIndices = new ArrayList<>();

            // 当前连通块中的元素值
            List<Integer> groupValues = new ArrayList<>();

            while (i < n && (i == start || values[i] - values[i - 1] <= limit)) {
                groupIndices.add(indices[i]);
                groupValues.add(values[i]);
                i++;
            }

            // 由于元素值数组已经有序，这里不需要再排序
            Collections.sort(groupIndices);

            // 为得到字典序最小的结果，将较小元素放到较小下标处
            for (int k = 0; k < groupIndices.size(); k++) {
                ans[groupIndices.get(k)] = groupValues.get(k);
            }
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] LexicographicallySmallestArray(int[] nums, int limit) {
        int n = nums.Length;
        int[] ans = new int[n];

        // 将元素值与原下标绑定
        List<(int value, int index)> arr = new();
        for (int i = 0; i < n; i++) {
            arr.Add((nums[i], i));
        }

        // 按元素值升序排序
        arr.Sort((a, b) => a.value.CompareTo(b.value));

        List<int> values = new();
        List<int> indices = new();

        foreach (var p in arr) {
            values.Add(p.value);
            indices.Add(p.index);
        }

        int ptr = 0;
        while (ptr < n) {
            int start = ptr;

            // 当前连通块中的原下标
            List<int> groupIndices = new();

            // 当前连通块中的元素值
            List<int> groupValues = new();

            while (ptr < n && (ptr == start || values[ptr] - values[ptr - 1] <= limit)) {
                groupIndices.Add(indices[ptr]);
                groupValues.Add(values[ptr]);
                ptr++;
            }

            // 由于元素值数组已经有序，这里不需要再排序
            groupIndices.Sort();

            // 为得到字典序最小的结果，将较小元素放到较小下标处
            for (int k = 0; k < groupIndices.Count; k++) {
                ans[groupIndices[k]] = groupValues[k];
            }
        }

        return ans;
    }
}
```

```Go
import "sort"

func lexicographicallySmallestArray(nums []int, limit int) []int {
    n := len(nums)
    ans := make([]int, n)

    // 将元素值与原下标绑定
    arr := make([][2]int, n)
    for i, x := range nums {
        arr[i] = [2]int{x, i}
    }

    // 按元素值升序排序
    sort.Slice(arr, func(i, j int) bool {
        return arr[i][0] < arr[j][0]
    })

    values := make([]int, n)
    indices := make([]int, n)

    for i, p := range arr {
        values[i] = p[0]
        indices[i] = p[1]
    }

    i := 0
    for i < n {
        start := i

        // 当前连通块中的原下标
        groupIndices := []int{}

        // 当前连通块中的元素值
        groupValues := []int{}

        for i < n && (i == start || values[i]-values[i-1] <= limit) {
            groupIndices = append(groupIndices, indices[i])
            groupValues = append(groupValues, values[i])
            i++
        }

        // 由于元素值数组已经有序，这里不需要再排序
        sort.Ints(groupIndices)

        // 为得到字典序最小的结果，将较小元素放到较小下标处
        for k := 0; k < len(groupIndices); k++ {
            ans[groupIndices[k]] = groupValues[k]
        }
    }

    return ans
}
```

```C
typedef struct {
    int value;
    int index;
} Pair;

int cmpPair(const void* a, const void* b) {
    return ((Pair*)a)->value - ((Pair*)b)->value;
}

int cmpInt(const void* a, const void* b) {
    return (*(int*)a) - (*(int*)b);
}

int* lexicographicallySmallestArray(int* nums, int numsSize, int limit, int* returnSize) {
    int n = numsSize;
    *returnSize = n;

    int* ans = (int*)calloc(n, sizeof(int));
    if (!ans) return NULL;

    // 将元素值与原下标绑定
    Pair* arr = (Pair*)malloc(sizeof(Pair) * n);
    if (!arr) {
        free(ans);
        return NULL;
    }
    for (int i = 0; i < n; i++) {
        arr[i].value = nums[i];
        arr[i].index = i;
    }

    // 按元素值升序排序
    qsort(arr, n, sizeof(Pair), cmpPair);

    // 提取值数组和下标数组
    int* values = (int*)malloc(sizeof(int) * n);
    int* indices = (int*)malloc(sizeof(int) * n);

    for (int i = 0; i < n; i++) {
        values[i] = arr[i].value;
        indices[i] = arr[i].index;
    }

    int* groupIndices = (int*)malloc(sizeof(int) * n);
    int* groupValues = (int*)malloc(sizeof(int) * n);
    int i = 0;
    while (i < n) {
        int start = i;
        int cnt = 0;

        // 找出当前连通块
        while (i < n && (i == start || values[i] - values[i - 1] <= limit)) {
            groupIndices[cnt] = indices[i];
            groupValues[cnt] = values[i];
            cnt++;
            i++;
        }

        // 对原下标排序
        qsort(groupIndices, cnt, sizeof(int), cmpInt);

        // 将较小元素放到较小下标处
        for (int k = 0; k < cnt; k++) {
            ans[groupIndices[k]] = groupValues[k];
        }
    }

    free(groupValues);
    free(groupIndices);
    free(indices);
    free(values);
    free(arr);

    return ans;
}
```

```JavaScript
var lexicographicallySmallestArray = function(nums, limit) {
    const n = nums.length;
    const ans = new Array(n).fill(0);

    // 将元素值与原下标绑定
    const arr = nums.map((x, i) => [x, i]);

    // 按元素值升序排序
    arr.sort((a, b) => a[0] - b[0]);

    const values = arr.map(p => p[0]);
    const indices = arr.map(p => p[1]);

    let i = 0;
    while (i < n) {
        const start = i;

        // 当前连通块中的原下标
        const groupIndices = [];

        // 当前连通块中的元素值
        const groupValues = [];

        while (i < n && (i === start || values[i] - values[i - 1] <= limit)) {
            groupIndices.push(indices[i]);
            groupValues.push(values[i]);
            i++;
        }

        // 由于元素值数组已经有序，这里不需要再排序
        groupIndices.sort((a, b) => a - b);

        // 为得到字典序最小的结果，将较小元素放到较小下标处
        for (let k = 0; k < groupIndices.length; k++) {
            ans[groupIndices[k]] = groupValues[k];
        }
    }

    return ans;
};
```

```TypeScript
function lexicographicallySmallestArray(nums: number[], limit: number): number[] {
    const n = nums.length;
    const ans: number[] = new Array(n).fill(0);

    // 将元素值与原下标绑定
    const arr: [number, number][] = nums.map((x, i) => [x, i]);

    // 按元素值升序排序
    arr.sort((a, b) => a[0] - b[0]);

    const values = arr.map(p => p[0]);
    const indices = arr.map(p => p[1]);

    let i = 0;
    while (i < n) {
        const start = i;

        // 当前连通块中的原下标
        const groupIndices: number[] = [];

        // 当前连通块中的元素值
        const groupValues: number[] = [];

        while (i < n && (i === start || values[i] - values[i - 1] <= limit)) {
            groupIndices.push(indices[i]);
            groupValues.push(values[i]);
            i++;
        }

        // 由于元素值数组已经有序，这里不需要再排序
        groupIndices.sort((a, b) => a - b);

        // 为得到字典序最小的结果，将较小元素放到较小下标处
        for (let k = 0; k < groupIndices.length; k++) {
            ans[groupIndices[k]] = groupValues[k];
        }
    }

    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组 $nums$ 的长度。瓶颈在排序上，时间复杂度为 $O(n\log n)$。
- 空间复杂度：$O(n)$。代码中数组 $arr$ 用于绑定原数组的元素和下标，$groupValues$ 和 groupIndices用于记录连通块内的元素值和元素下标，这些辅助数组都需要 $O(n)$ 的空间。
