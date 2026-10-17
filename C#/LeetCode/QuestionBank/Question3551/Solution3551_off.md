### [数位和排序需要的最小交换次数](https://leetcode.cn/problems/minimum-swaps-to-sort-by-digit-sum/solutions/4039935/shu-wei-he-pai-xu-xu-yao-de-zui-xiao-jia-o3mk/)

#### 方法一：置换环

**思路与算法**

给定一个由互不相同的正整数组成的数组 $nums$，需要根据每个数字的数位和按升序排序（数位和相等时，较小的数字排在前面），计算将原数组变为目标顺序所需的最小交换次数。

这是一个经典的「求将一个排列变成有序排列的最小交换次数」问题。由于 $nums$ 中的元素互不相同，排序后每个元素都有唯一确定的目标位置，因此可以将原位置到目标位置的映射视为一个置换。

对于一个长度为 $n$ 的排列，将 $n$ 个位置视为图中的 $n$ 个节点，从位置 $i$ 向其元素的目标位置 $pos[i]$ 连一条有向边。由于每个节点的入度和出度均为 $1$，图中会形成若干个不相交的有向环，称为置换环。

对于一个长度为 $k$ 的置换环，最少需要 $k-1$ 次交换才能将所有元素归位。因此总的最小交换次数为：

$$\sum (k_i-1)=(\sum k_i)-cycles=n-cycles$$

其中 $k_i$ 表示第 $i$ 个置换环的长度，$cycles$ 表示置换环的数量。

**具体步骤**：

1. 计算每个元素的数位和
2. 按照 (数位和, 数值) 的排序规则对下标进行排序，得到排序后的目标顺序
3. 对每个原始位置 $i$，确定其元素在排序后应处于的位置 $pos[i]$
4. 循环遍历所有置换环，统计环的数量
5. 返回 $n-cycles$

**代码**

```C++
class Solution {
public:
    int minSwaps(vector<int>& nums) {
        int n = nums.size();
        vector<int> digitSum(n);
        for (int i = 0; i < n; i++) {
            int x = nums[i], sum = 0;
            while (x > 0) {
                sum += x % 10;
                x /= 10;
            }
            digitSum[i] = sum;
        }

        vector<int> indices(n);
        iota(indices.begin(), indices.end(), 0);
        sort(indices.begin(), indices.end(), [&](int a, int b) {
            if (digitSum[a] != digitSum[b]) {
                return digitSum[a] < digitSum[b];
            }
            return nums[a] < nums[b];
        });

        vector<int> targetPos(n);
        for (int pos = 0; pos < n; pos++) {
            targetPos[indices[pos]] = pos;
        }

        vector<int> visited(n);
        int cycles = 0;
        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                cycles++;
                int j = i;
                while (!visited[j]) {
                    visited[j] = true;
                    j = targetPos[j];
                }
            }
        }

        return n - cycles;
    }
};
```

```Go
func minSwaps(nums []int) int {
    n := len(nums)
    digitSum := make([]int, n)
    for i, v := range nums {
        sum := 0
        for v > 0 {
            sum += v % 10
            v /= 10
        }
        digitSum[i] = sum
    }

    indices := make([]int, n)
    for i := 0; i < n; i++ {
        indices[i] = i
    }
    sort.Slice(indices, func(a, b int) bool {
        if digitSum[indices[a]] != digitSum[indices[b]] {
            return digitSum[indices[a]] < digitSum[indices[b]]
        }
        return nums[indices[a]] < nums[indices[b]]
    })

    targetPos := make([]int, n)
    for pos, idx := range indices {
        targetPos[idx] = pos
    }

    visited := make([]bool, n)
    cycles := 0
    for i := 0; i < n; i++ {
        if !visited[i] {
            cycles++
            j := i
            for !visited[j] {
                visited[j] = true
                j = targetPos[j]
            }
        }
    }

    return n - cycles
}
```

```Python
class Solution:
    def minSwaps(self, nums: List[int]) -> int:
        n = len(nums)
        digitSum = [0] * n
        for i, v in enumerate(nums):
            s = 0
            while v > 0:
                s += v % 10
                v //= 10
            digitSum[i] = s

        indices = list(range(n))
        indices.sort(key=lambda i: (digitSum[i], nums[i]))

        targetPos = [0] * n
        for pos, idx in enumerate(indices):
            targetPos[idx] = pos

        visited = [False] * n
        cycles = 0
        for i in range(n):
            if not visited[i]:
                cycles += 1
                j = i
                while not visited[j]:
                    visited[j] = True
                    j = targetPos[j]

        return n - cycles
```

```Java
class Solution {
    public int minSwaps(int[] nums) {
        int n = nums.length;
        int[] digitSum = new int[n];
        for (int i = 0; i < n; i++) {
            int x = nums[i], sum = 0;
            while (x > 0) {
                sum += x % 10;
                x /= 10;
            }
            digitSum[i] = sum;
        }

        Integer[] indices = new Integer[n];
        for (int i = 0; i < n; i++) {
            indices[i] = i;
        }
        Arrays.sort(indices, (a, b) -> {
            if (digitSum[a] != digitSum[b]) {
                return Integer.compare(digitSum[a], digitSum[b]);
            }
            return Integer.compare(nums[a], nums[b]);
        });

        int[] targetPos = new int[n];
        for (int pos = 0; pos < n; pos++) {
            targetPos[indices[pos]] = pos;
        }

        boolean[] visited = new boolean[n];
        int cycles = 0;
        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                cycles++;
                int j = i;
                while (!visited[j]) {
                    visited[j] = true;
                    j = targetPos[j];
                }
            }
        }

        return n - cycles;
    }
}
```

```CSharp
public class Solution {
    public int MinSwaps(int[] nums) {
        int n = nums.Length;
        int[] digitSum = new int[n];
        for (int i = 0; i < n; i++) {
            int x = nums[i], sum = 0;
            while (x > 0) {
                sum += x % 10;
                x /= 10;
            }
            digitSum[i] = sum;
        }

        int[] indices = new int[n];
        for (int i = 0; i < n; i++) {
            indices[i] = i;
        }
        Array.Sort(indices, (a, b) => {
            if (digitSum[a] != digitSum[b]) {
                return digitSum[a].CompareTo(digitSum[b]);
            }
            return nums[a].CompareTo(nums[b]);
        });

        int[] targetPos = new int[n];
        for (int pos = 0; pos < n; pos++) {
            targetPos[indices[pos]] = pos;
        }

        bool[] visited = new bool[n];
        int cycles = 0;
        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                cycles++;
                int j = i;
                while (!visited[j]) {
                    visited[j] = true;
                    j = targetPos[j];
                }
            }
        }

        return n - cycles;
    }
}
```

```TypeScript
function minSwaps(nums: number[]): number {
    const n = nums.length;
    const digitSum: number[] = new Array(n);
    for (let i = 0; i < n; i++) {
        let x = nums[i], sum = 0;
        while (x > 0) {
            sum += x % 10;
            x = Math.floor(x / 10);
        }
        digitSum[i] = sum;
    }

    const indices: number[] = Array.from({ length: n }, (_, i) => i);
    indices.sort((a, b) => {
        if (digitSum[a] !== digitSum[b]) {
            return digitSum[a] - digitSum[b];
        }
        return nums[a] - nums[b];
    });

    const targetPos: number[] = new Array(n);
    for (let pos = 0; pos < n; pos++) {
        targetPos[indices[pos]] = pos;
    }

    const visited: boolean[] = new Array(n).fill(false);
    let cycles = 0;
    for (let i = 0; i < n; i++) {
        if (!visited[i]) {
            cycles++;
            let j = i;
            while (!visited[j]) {
                visited[j] = true;
                j = targetPos[j];
            }
        }
    }

    return n - cycles;
}
```

```JavaScript
var minSwaps = function(nums) {
    const n = nums.length;
    const digitSum = new Array(n);
    for (let i = 0; i < n; i++) {
        let x = nums[i], sum = 0;
        while (x > 0) {
            sum += x % 10;
            x = Math.floor(x / 10);
        }
        digitSum[i] = sum;
    }

    const indices = Array.from({ length: n }, (_, i) => i);
    indices.sort((a, b) => {
        if (digitSum[a] !== digitSum[b]) {
            return digitSum[a] - digitSum[b];
        }
        return nums[a] - nums[b];
    });

    const targetPos = new Array(n);
    for (let pos = 0; pos < n; pos++) {
        targetPos[indices[pos]] = pos;
    }

    const visited = new Array(n).fill(false);
    let cycles = 0;
    for (let i = 0; i < n; i++) {
        if (!visited[i]) {
            cycles++;
            let j = i;
            while (!visited[j]) {
                visited[j] = true;
                j = targetPos[j];
            }
        }
    }

    return n - cycles;
};
```

```C
typedef struct {
    int digitSum;
    int value;
    int origIdx;
} Elem;

int cmp(const void* a, const void* b) {
    Elem* ea = (Elem*)a;
    Elem* eb = (Elem*)b;
    if (ea->digitSum != eb->digitSum) {
        return ea->digitSum - eb->digitSum;
    }
    return ea->value - eb->value;
}

int minSwaps(int* nums, int numsSize) {
    int n = numsSize;
    Elem* elems = (Elem*)malloc(n * sizeof(Elem));
    for (int i = 0; i < n; i++) {
        int x = nums[i], sum = 0;
        while (x > 0) {
            sum += x % 10;
            x /= 10;
        }
        elems[i].digitSum = sum;
        elems[i].value = nums[i];
        elems[i].origIdx = i;
    }
    qsort(elems, n, sizeof(Elem), cmp);

    int* targetPos = (int*)malloc(n * sizeof(int));
    for (int pos = 0; pos < n; pos++) {
        targetPos[elems[pos].origIdx] = pos;
    }

    bool* visited = (bool*)calloc(n, sizeof(bool));
    int cycles = 0;
    for (int i = 0; i < n; i++) {
        if (!visited[i]) {
            cycles++;
            int j = i;
            while (!visited[j]) {
                visited[j] = true;
                j = targetPos[j];
            }
        }
    }

    free(elems);
    free(targetPos);
    free(visited);
    return n - cycles;
}
```

```Rust
impl Solution {
    pub fn min_swaps(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut digit_sum = vec![0; n];
        for i in 0..n {
            let mut x = nums[i];
            let mut sum = 0;
            while x > 0 {
                sum += x % 10;
                x /= 10;
            }
            digit_sum[i] = sum;
        }

        let mut indices: Vec<usize> = (0..n).collect();
        indices.sort_by_key(|&i| (digit_sum[i], nums[i]));

        let mut target_pos = vec![0; n];
        for (pos, &idx) in indices.iter().enumerate() {
            target_pos[idx] = pos;
        }

        let mut visited = vec![false; n];
        let mut cycles = 0;
        for i in 0..n {
            if !visited[i] {
                cycles += 1;
                let mut j = i;
                while !visited[j] {
                    visited[j] = true;
                    j = target_pos[j];
                }
            }
        }

        (n - cycles) as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+n\log M)$，其中 $n$ 是数组 $nums$ 的长度，$M$ 是数组中的最大值。计算数位和需要 $O(n\log M)$，排序需要 $O(n\log n)$，遍历置换环需要 $O(n)$。整体时间复杂度为 $O(n\log n+n\log M)$。
- 空间复杂度：$O(n)$。需要 $digitSum$、$indices$、$targetPos$、$visited$ 四个辅助数组，各占 $O(n)$ 空间。

#### 方法二：并查集

**思路与算法**

方法一通过遍历来统计置换环的数量。由于置换环本质上就是连通分量，我们也可以使用并查集来实现同样的效果。

对于每个位置 $i$，将其和目标位置 $pos[i]$ 合并在同一个集合中。由于位置 $i$ 和 $pos[i]$ 都属于同一个置换环，合并完所有位置后，并查集中连通分量的数量 $components$ 就等于置换环的数量。最小交换次数同样为 $n-components$。

**具体步骤**：

1. 计算每个元素的数位和
2. 按照排序规则对下标进行排序，得到排序后的目标顺序
3. 对每个原始位置 $i$，确定其元素在排序后应处于的位置 $pos[i]$
4. 初始化并查集，每个位置自成一个集合
5. 遍历所有位置，将 $i$ 和 $pos[i]$ 合并；若两个位置原本不在同一集合中，连通分量数减一
6. 返回 $n-components$

**代码**

```C++
class Solution {
public:
    int minSwaps(vector<int>& nums) {
        int n = nums.size();
        vector<int> digitSum(n);
        for (int i = 0; i < n; i++) {
            int x = nums[i], sum = 0;
            while (x > 0) {
                sum += x % 10;
                x /= 10;
            }
            digitSum[i] = sum;
        }

        vector<int> indices(n);
        iota(indices.begin(), indices.end(), 0);
        sort(indices.begin(), indices.end(), [&](int a, int b) {
            if (digitSum[a] != digitSum[b]) {
                return digitSum[a] < digitSum[b];
            }
            return nums[a] < nums[b];
        });

        vector<int> targetPos(n);
        for (int pos = 0; pos < n; pos++) {
            targetPos[indices[pos]] = pos;
        }

        vector<int> parent(n);
        iota(parent.begin(), parent.end(), 0);
        int components = n;

        function<int(int)> find = [&](int x) -> int {
            if (parent[x] != x) {
                parent[x] = find(parent[x]);
            }
            return parent[x];
        };

        for (int i = 0; i < n; i++) {
            int ri = find(i);
            int rj = find(targetPos[i]);
            if (ri != rj) {
                parent[ri] = rj;
                components--;
            }
        }

        return n - components;
    }
};
```

```Go
func minSwaps(nums []int) int {
    n := len(nums)
    digitSum := make([]int, n)
    for i, v := range nums {
        sum := 0
        for v > 0 {
            sum += v % 10
            v /= 10
        }
        digitSum[i] = sum
    }

    indices := make([]int, n)
    for i := 0; i < n; i++ {
        indices[i] = i
    }
    sort.Slice(indices, func(a, b int) bool {
        if digitSum[indices[a]] != digitSum[indices[b]] {
            return digitSum[indices[a]] < digitSum[indices[b]]
        }
        return nums[indices[a]] < nums[indices[b]]
    })

    targetPos := make([]int, n)
    for pos, idx := range indices {
        targetPos[idx] = pos
    }

    parent := make([]int, n)
    for i := 0; i < n; i++ {
        parent[i] = i
    }
    components := n

    var find func(int) int
    find = func(x int) int {
        if parent[x] != x {
            parent[x] = find(parent[x])
        }
        return parent[x]
    }

    for i := 0; i < n; i++ {
        ri := find(i)
        rj := find(targetPos[i])
        if ri != rj {
            parent[ri] = rj
            components--
        }
    }

    return n - components
}
```

```Python
class Solution:
    def minSwaps(self, nums: List[int]) -> int:
        n = len(nums)
        digitSum = [0] * n
        for i, v in enumerate(nums):
            s = 0
            while v > 0:
                s += v % 10
                v //= 10
            digitSum[i] = s

        indices = list(range(n))
        indices.sort(key=lambda i: (digitSum[i], nums[i]))

        targetPos = [0] * n
        for pos, idx in enumerate(indices):
            targetPos[idx] = pos

        parent = list(range(n))
        components = n

        def find(x):
            if parent[x] != x:
                parent[x] = find(parent[x])
            return parent[x]

        for i in range(n):
            ri = find(i)
            rj = find(targetPos[i])
            if ri != rj:
                parent[ri] = rj
                components -= 1

        return n - components
```

```Java
class Solution {
    public int minSwaps(int[] nums) {
        int n = nums.length;
        int[] digitSum = new int[n];
        for (int i = 0; i < n; i++) {
            int x = nums[i], sum = 0;
            while (x > 0) {
                sum += x % 10;
                x /= 10;
            }
            digitSum[i] = sum;
        }

        Integer[] indices = new Integer[n];
        for (int i = 0; i < n; i++) {
            indices[i] = i;
        }
        Arrays.sort(indices, (a, b) -> {
            if (digitSum[a] != digitSum[b]) {
                return Integer.compare(digitSum[a], digitSum[b]);
            }
            return Integer.compare(nums[a], nums[b]);
        });

        int[] targetPos = new int[n];
        for (int pos = 0; pos < n; pos++) {
            targetPos[indices[pos]] = pos;
        }

        int[] parent = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
        int components = n;

        for (int i = 0; i < n; i++) {
            int ri = find(parent, i);
            int rj = find(parent, targetPos[i]);
            if (ri != rj) {
                parent[ri] = rj;
                components--;
            }
        }

        return n - components;
    }

    private int find(int[] parent, int x) {
        if (parent[x] != x) {
            parent[x] = find(parent, parent[x]);
        }
        return parent[x];
    }
}
```

```CSharp
public class Solution {
    public int MinSwaps(int[] nums) {
        int n = nums.Length;
        int[] digitSum = new int[n];
        for (int i = 0; i < n; i++) {
            int x = nums[i], sum = 0;
            while (x > 0) {
                sum += x % 10;
                x /= 10;
            }
            digitSum[i] = sum;
        }

        int[] indices = new int[n];
        for (int i = 0; i < n; i++) {
            indices[i] = i;
        }
        Array.Sort(indices, (a, b) => {
            if (digitSum[a] != digitSum[b]) {
                return digitSum[a].CompareTo(digitSum[b]);
            }
            return nums[a].CompareTo(nums[b]);
        });

        int[] targetPos = new int[n];
        for (int pos = 0; pos < n; pos++) {
            targetPos[indices[pos]] = pos;
        }

        int[] parent = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
        int components = n;

        for (int i = 0; i < n; i++) {
            int ri = Find(parent, i);
            int rj = Find(parent, targetPos[i]);
            if (ri != rj) {
                parent[ri] = rj;
                components--;
            }
        }

        return n - components;
    }

    private int Find(int[] parent, int x) {
        if (parent[x] != x) {
            parent[x] = Find(parent, parent[x]);
        }
        return parent[x];
    }
}
```

```TypeScript
function minSwaps(nums: number[]): number {
    const n = nums.length;
    const digitSum: number[] = new Array(n);
    for (let i = 0; i < n; i++) {
        let x = nums[i], sum = 0;
        while (x > 0) {
            sum += x % 10;
            x = Math.floor(x / 10);
        }
        digitSum[i] = sum;
    }

    const indices: number[] = Array.from({ length: n }, (_, i) => i);
    indices.sort((a, b) => {
        if (digitSum[a] !== digitSum[b]) {
            return digitSum[a] - digitSum[b];
        }
        return nums[a] - nums[b];
    });

    const targetPos: number[] = new Array(n);
    for (let pos = 0; pos < n; pos++) {
        targetPos[indices[pos]] = pos;
    }

    const parent: number[] = Array.from({ length: n }, (_, i) => i);
    let components = n;

    const find = (x: number): number => {
        if (parent[x] !== x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    };

    for (let i = 0; i < n; i++) {
        const ri = find(i);
        const rj = find(targetPos[i]);
        if (ri !== rj) {
            parent[ri] = rj;
            components--;
        }
    }

    return n - components;
}
```

```JavaScript
var minSwaps = function(nums) {
    const n = nums.length;
    const digitSum = new Array(n);
    for (let i = 0; i < n; i++) {
        let x = nums[i], sum = 0;
        while (x > 0) {
            sum += x % 10;
            x = Math.floor(x / 10);
        }
        digitSum[i] = sum;
    }

    const indices = Array.from({ length: n }, (_, i) => i);
    indices.sort((a, b) => {
        if (digitSum[a] !== digitSum[b]) {
            return digitSum[a] - digitSum[b];
        }
        return nums[a] - nums[b];
    });

    const targetPos = new Array(n);
    for (let pos = 0; pos < n; pos++) {
        targetPos[indices[pos]] = pos;
    }

    const parent = Array.from({ length: n }, (_, i) => i);
    let components = n;

    const find = (x) => {
        if (parent[x] !== x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    };

    for (let i = 0; i < n; i++) {
        const ri = find(i);
        const rj = find(targetPos[i]);
        if (ri !== rj) {
            parent[ri] = rj;
            components--;
        }
    }

    return n - components;
};
```

```C
typedef struct {
    int digitSum;
    int value;
    int origIdx;
} Elem;

int cmp(const void* a, const void* b) {
    Elem* ea = (Elem*)a;
    Elem* eb = (Elem*)b;
    if (ea->digitSum != eb->digitSum) {
        return ea->digitSum - eb->digitSum;
    }
    return ea->value - eb->value;
}

int find(int* parent, int x) {
    if (parent[x] != x) {
        parent[x] = find(parent, parent[x]);
    }
    return parent[x];
}

int minSwaps(int* nums, int numsSize) {
    int n = numsSize;
    Elem* elems = (Elem*)malloc(n * sizeof(Elem));
    for (int i = 0; i < n; i++) {
        int x = nums[i], sum = 0;
        while (x > 0) {
            sum += x % 10;
            x /= 10;
        }
        elems[i].digitSum = sum;
        elems[i].value = nums[i];
        elems[i].origIdx = i;
    }
    qsort(elems, n, sizeof(Elem), cmp);

    int* targetPos = (int*)malloc(n * sizeof(int));
    for (int pos = 0; pos < n; pos++) {
        targetPos[elems[pos].origIdx] = pos;
    }

    int* parent = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        parent[i] = i;
    }
    int components = n;

    for (int i = 0; i < n; i++) {
        int ri = find(parent, i);
        int rj = find(parent, targetPos[i]);
        if (ri != rj) {
            parent[ri] = rj;
            components--;
        }
    }

    free(elems);
    free(targetPos);
    free(parent);
    return n - components;
}
```

```Rust
impl Solution {
    pub fn min_swaps(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut digit_sum = vec![0; n];
        for i in 0..n {
            let mut x = nums[i];
            let mut sum = 0;
            while x > 0 {
                sum += x % 10;
                x /= 10;
            }
            digit_sum[i] = sum;
        }

        let mut indices: Vec<usize> = (0..n).collect();
        indices.sort_by_key(|&i| (digit_sum[i], nums[i]));

        let mut target_pos = vec![0; n];
        for (pos, &idx) in indices.iter().enumerate() {
            target_pos[idx] = pos;
        }

        let mut parent: Vec<usize> = (0..n).collect();
        let mut components = n;

        for i in 0..n {
            let ri = Self::find(&mut parent, i);
            let rj = Self::find(&mut parent, target_pos[i]);
            if ri != rj {
                parent[ri] = rj;
                components -= 1;
            }
        }

        (n - components) as i32
    }

    fn find(parent: &mut Vec<usize>, x: usize) -> usize {
        if parent[x] != x {
            parent[x] = Self::find(parent, parent[x]);
        }
        parent[x]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+n\log M)$，其中 $n$ 是数组 $nums$ 的长度，$M$ 是数组中的最大值。计算数位和需要 $O(n\log M)$，排序需要 $O(n\log n)$，并查集部分仅使用路径压缩、未按秩合并，均摊时间复杂度为 $O(n\log n)$。整体时间复杂度为 $O(n\log n+n\log M)$。
- 空间复杂度：$O(n)$。需要 $digitSum$、$indices$、$targetPos$、$parent$ 四个辅助数组，各占 $O(n)$ 空间。
