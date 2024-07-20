### [将石头分散到网格图的最少移动次数](https://leetcode.cn/problems/minimum-moves-to-spread-stones-over-grid/solutions/2844232/jiang-shi-tou-fen-san-dao-wang-ge-tu-de-b4xos/)

#### 方法一：枚举

**思路与算法**

如果某个位置 $(x,y)$ 恰好有一个石头，那么要想达到最少移动次数，移动 $(x,y)$ 到别处 $P$ 一定不会更优：这是因为如果我们这样做，就需要将另一个 $Q$ 处的石头再移动到位置 $(x,y)$，那就不如直接将 $Q$ 处的石头移动到 $P$ 了。

因此，我们只需要考虑所有至少有两个石头的位置，以及没有石头的位置。在最少的移动次数的策略中，一定是对于每一个没有石头的位置，分配一个多出的石头，并将该石头使用最少的移动次数（曼哈顿距离）送达。这样一来，我们可以使用两个数组 $more$ 和 $less$，分别存储上述的位置。如果一个位置有 $k (k \le 2)$ 个石头，那么其在 $more$ 中出现 $k-1$ 次；如果一个位置没有石头，那么其在 $less$ 中出现 $1$ 次。

例如对于「示例 2」，这两个数组分别为：

$$more = =[(0,1),(0,1),(2,2),(2,2)] \\ less =[(0,2),(1,1),(1,2),(2,1)]$$

我们可以枚举 $more$ 或者 $less$ 的每一个排列，而另一个数组保持不变，这样就可以枚举所有可能的分配情况。

**细节**

注意到这两个数组的长度相同，而 $less$ 中没有重复元素但 $more$ 中有，因此 $more$ 的排列个数更少，枚举 $more$ 的每一个排列可以使得时间复杂度更低。

枚举排列可以使用语言自带的 API，或者参考「[47\. 全排列 II](https://leetcode.cn/problems/permutations-ii/description/)」。

**代码**

```C++
class Solution {
public:
    int minimumMoves(vector<vector<int>>& grid) {
        vector<pair<int, int>> more, less;
        for (int i = 0; i < 3; ++i) {
            for (int j = 0; j < 3; ++j) {
                if (grid[i][j] > 1) {
                    for (int k = 2; k <= grid[i][j]; ++k) {
                        more.emplace_back(i, j);
                    }
                }
                else if (grid[i][j] == 0) {
                    less.emplace_back(i, j);
                }
            }
        }

        int ans = INT_MAX;
        do {
            int steps = 0;
            for (int i = 0; i < more.size(); ++i) {
                steps += abs(more[i].first - less[i].first) + abs(more[i].second - less[i].second);
            }
            ans = min(ans, steps);
        } while (next_permutation(more.begin(), more.end()));
        return ans;
    }
};
```

```Java
class Solution {
    public int minimumMoves(int[][] grid) {
        List<int[]> more = new ArrayList<int[]>();
        List<int[]> less = new ArrayList<int[]>();
        for (int i = 0; i < 3; ++i) {
            for (int j = 0; j < 3; ++j) {
                if (grid[i][j] > 1) {
                    for (int k = 2; k <= grid[i][j]; ++k) {
                        more.add(new int[]{i, j});
                    }
                } else if (grid[i][j] == 0) {
                    less.add(new int[]{i, j});
                }
            }
        }

        int ans = Integer.MAX_VALUE;
        do {
            int steps = 0;
            for (int i = 0; i < more.size(); i++) {
                steps += Math.abs(less.get(i)[0] - more.get(i)[0]) + Math.abs(less.get(i)[1] - more.get(i)[1]);
            }
            ans = Math.min(ans, steps);
        } while (nextPermutation(more)); 
        return ans;
    }

    public boolean nextPermutation(List<int[]> more) {
        int p = -1;
        for (int i = 0; i < more.size() - 1; i++) {
            if (isLess(more.get(i), more.get(i + 1))) {
                p = i;
            }
        }
        if (p == -1) {
            return false;
        }
        int q = -1;
        for (int j = p + 1; j < more.size(); j++) {
            if (isLess(more.get(p), more.get(j))) {
                q = j;
            }
        }
        Collections.swap(more, p, q);
        int i = p + 1, j = more.size() - 1;
        while (i < j) {
            Collections.swap(more, i, j);
            i++;
            j--;
        }
        return true;
    }

    public boolean isLess(int[] pair1, int[] pair2) {
        return pair1[0] < pair2[0] || (pair1[0] == pair2[0] && pair1[1] < pair2[1]);
    }
}
```

```CSharp
public class Solution {
    public int MinimumMoves(int[][] grid) {
        IList<int[]> more = new List<int[]>();
        IList<int[]> less = new List<int[]>();
        for (int i = 0; i < 3; ++i) {
            for (int j = 0; j < 3; ++j) {
                if (grid[i][j] > 1) {
                    for (int k = 2; k <= grid[i][j]; ++k) {
                        more.Add(new int[]{i, j});
                    }
                } else if (grid[i][j] == 0) {
                    less.Add(new int[]{i, j});
                }
            }
        }

        int ans = int.MaxValue;
        do {
            int steps = 0;
            for (int i = 0; i < more.Count; i++) {
                steps += Math.Abs(less[i][0] - more[i][0]) + Math.Abs(less[i][1] - more[i][1]);
            }
            ans = Math.Min(ans, steps);
        } while (NextPermutation(more)); 
        return ans;
    }

    public bool NextPermutation(IList<int[]> more) {
        int p = -1;
        for (int idx = 0; idx < more.Count - 1; idx++) {
            if (IsLess(more[idx], more[idx + 1])) {
                p = idx;
            }
        }
        if (p == -1) {
            return false;
        }
        int q = -1;
        for (int idx = p + 1; idx < more.Count; idx++) {
            if (IsLess(more[p], more[idx])) {
                q = idx;
            }
        }
        Swap(more, p, q);
        int i = p + 1, j = more.Count - 1;
        while (i < j) {
            Swap(more, i, j);
            i++;
            j--;
        }
        return true;
    }

    public bool IsLess(int[] pair1, int[] pair2) {
        return pair1[0] < pair2[0] || (pair1[0] == pair2[0] && pair1[1] < pair2[1]);
    }

    public void Swap(IList<int[]> more, int index1, int index2) {
        int[] temp = more[index1];
        more[index1] = more[index2];
        more[index2] = temp;
    }
}
```

```Python
class Solution:
    def minimumMoves(self, grid: List[List[int]]) -> int:
        # itertools.permutations 无法对生成的全排列去重
        def my_permutations(x: List[Any]) -> List[Any]:
            n = len(x)
            while True:
                yield x
                # 生成下一个排列
                p = -1
                for i in range(n - 1):
                    if x[i] < x[i + 1]:
                        p = i
                if p == -1:
                    return
                q = -1
                for j in range(p + 1, n):
                    if x[p] < x[j]:
                        q = j
                x[p], x[q] = x[q], x[p]
                i, j = p + 1, n - 1
                while i < j:
                    x[i], x[j] = x[j], x[i]
                    i += 1
                    j -= 1

        more, less = list(), list()
        for i in range(3):
            for j in range(3):
                if grid[i][j] > 1:
                    more.extend([(i, j)] * (grid[i][j] - 1))
                elif grid[i][j] == 0:
                    less.append((i, j))

        ans = inf
        total = 0
        for perm in my_permutations(more):
            steps = 0
            for (px, py), (lx, ly) in zip(perm, less):
                total += 1
                steps += abs(px - lx) + abs(py - ly)
            ans = min(ans, steps)
        return ans
```

```C
bool isLess(int *a, int *b) {
    return a[0] < b[0] || (a[0] == b[0] && a[1] < b[1]);
}

void swap(int *a, int *b) {
    int tmp = a[0];
    a[0] = b[0];
    b[0] = tmp;
    tmp = a[1];
    a[1] = b[1];
    b[1] = tmp;
}

bool nextPermutation(int **arr, int arrSize) {
    int p = -1;
    for (int i = 0; i < arrSize - 1; i++) {
        if (isLess(arr[i], arr[i + 1])) {
            p = i;
        }
    }
    if (p == -1) {
        return false;
    }
    int q = -1;
    for (int j = p + 1; j < arrSize; j++) {
        if (isLess(arr[p], arr[j])) {
            q = j;
        }
    }
    swap(arr[p], arr[q]);
    int i = p + 1, j = arrSize - 1;
    while (i < j) {
        swap(arr[i], arr[j]);
        i++;
        j--;
    }
    return true;
}

int minimumMoves(int** grid, int gridSize, int* gridColSize){
    int *more[9], *less[9];
    int moreSize = 0, lessSize = 0;
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) {
            if (grid[i][j] > 1) {
                for (int k = 0; k < grid[i][j] - 1; k++) {
                    more[moreSize] = (int *)malloc(sizeof(int) * 2);
                    more[moreSize][0] = i;
                    more[moreSize][1] = j;
                    moreSize++;
                }
            } else if (grid[i][j] == 0) {
                less[lessSize] = (int *)malloc(sizeof(int) * 2);
                less[lessSize][0] = i;
                less[lessSize][1] = j;
                lessSize++;
            }
        }
    }

    int ans = INT_MAX;
    do {
        int steps = 0;
        for (int i = 0; i < moreSize; i++) {
            steps += abs(less[i][0] - more[i][0]) + abs(less[i][1] - more[i][1]);
        }
        ans = fmin(ans, steps);
    } while (nextPermutation(more, moreSize));        
    return ans;
}
```

```Go
func minimumMoves(grid [][]int) int {
    more, less := [][]int{}, [][]int{}
    for i := 0; i < 3; i++ {
        for j := 0; j < 3; j++ {
            if grid[i][j] > 1 {
                for k := 0; k < grid[i][j] - 1; k++ {
                    more = append(more, []int{i, j})
                }
            } else if grid[i][j] == 0 {
                less = append(less, []int{i, j})
            }
        }
    }

    ans := math.MaxInt32
    for {
        steps := 0
        for i := 0; i < len(more); i++ {
            steps += abs(less[i][0] - more[i][0]) + abs(less[i][1] - more[i][1])
        }
        if steps < ans {
            ans = steps
        }
        if !nextPermutation(more) {
            break
        }
    }
    return ans
}

func isLess(a, b []int) bool {
    return a[0] < b[0] || (a[0] == b[0] && a[1] < b[1])
}

func abs(a int) int {
    if a < 0 {
        return -a
    }
    return a
}

func nextPermutation(arr [][]int) bool {
    p := -1
    for i := 0; i < len(arr)-1; i++ {
        if isLess(arr[i], arr[i+1]) {
            p = i
        }
    }
    if p == -1 {
        return false
    }
    q := -1
    for j := p + 1; j < len(arr); j++ {
        if isLess(arr[p], arr[j]) {
            q = j
        }
    }
    arr[p], arr[q] = arr[q], arr[p]
    i, j := p+1, len(arr)-1
    for i < j {
        arr[i], arr[j] = arr[j], arr[i]
        i++
        j--
    }
    return true
}
```

```JavaScript
var minimumMoves = function(grid) {
    let more = [], less = [];
    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
            if (grid[i][j] > 1) {
                for (let k = 0; k < grid[i][j] - 1; k++) {
                    more.push([i, j]);
                }
            } else if (grid[i][j] === 0) {
                less.push([i, j]);
            }
        }
    }

    let ans = Number.MAX_SAFE_INTEGER;
    do {
        let steps = 0;
        for (let i = 0; i < more.length; i++) {
            steps += Math.abs(less[i][0] - more[i][0]) + Math.abs(less[i][1] - more[i][1]);
        }
        ans = Math.min(ans, steps);
    } while (nextPermutation(more));

    return ans;
};

const isLess  = (a, b) => {
    return a[0] < b[0] || (a[0] == b[0] && a[1] < b[1]);
}

const nextPermutation = (arr) => {
    let p = -1;
    for (let i = 0; i < arr.length - 1; i++) {
        if (isLess(arr[i], arr[i + 1])) {
            p = i;
        }
    }
    if (p === -1) {
        return false;
    }
    let q = -1;
    for (let j = p + 1; j < arr.length; j++) {
        if (isLess(arr[p], arr[j])) {
            q = j;
        }
    }

    [arr[p], arr[q]] = [arr[q], arr[p]];
    let i = p + 1, j = arr.length - 1;
    while (i < j) {
        [arr[i], arr[j]] = [arr[j], arr[i]];
        i++;
        j--;
    }
    
    return true;
}
```

```TypeScript
const isLess = (a: number[], b: number[]): boolean => {
    return a[0] < b[0] || (a[0] === b[0] && a[1] < b[1]);
};

const nextPermutation = (arr: number[][]): boolean => {
    let p = -1;
    for (let i = 0; i < arr.length - 1; i++) {
        if (isLess(arr[i], arr[i + 1])) {
            p = i;
        }
    }
    if (p === -1) {
        return false;
    }
    let q = -1;
    for (let j = p + 1; j < arr.length; j++) {
        if (isLess(arr[p], arr[j])) {
            q = j;
        }
    }

    [arr[p], arr[q]] = [arr[q], arr[p]];
    let i = p + 1, j = arr.length - 1;
    while (i < j) {
        [arr[i], arr[j]] = [arr[j], arr[i]];
        i++;
        j--;
    }

    return true;
};

function minimumMoves(grid: number[][]): number {
    let more: number[][] = [];
    let less: number[][] = [];
    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
            if (grid[i][j] > 1) {
                for (let k = 0; k < grid[i][j] - 1; k++) {
                    more.push([i, j]);
                }
            } else if (grid[i][j] === 0) {
                less.push([i, j]);
            }
        }
    }

    let ans = Number.MAX_SAFE_INTEGER;
    do {
        let steps = 0;
        for (let i = 0; i < more.length; i++) {
            steps += Math.abs(less[i][0] - more[i][0]) + Math.abs(less[i][1] - more[i][1]);
        }
        ans = Math.min(ans, steps);
    } while (nextPermutation(more));

    return ans;
};
```

```Rust
fn is_less(a: &[i32], b: &[i32]) -> bool {
    a[0] < b[0] || (a[0] == b[0] && a[1] < b[1])
}

fn swap(arr: &mut Vec<Vec<i32>>, i: usize, j: usize) {
    let temp = arr[i].clone();
    arr[i] = arr[j].clone();
    arr[j] = temp;
}

impl Solution {
    pub fn minimum_moves(grid: Vec<Vec<i32>>) -> i32 {
        let mut more = vec![];
        let mut less = vec![];
        for i in 0..3 {
            for j in 0..3 {
                if grid[i][j] > 1 {
                    for _ in 0..grid[i][j] - 1 {
                        more.push(vec![i as i32, j as i32]);
                    }
                } else if grid[i][j] == 0 {
                    less.push(vec![i as i32, j as i32]);
                }
            }
        }

        let mut ans = i32::MAX;
        loop {
            let mut steps = 0;
            for i in 0..more.len() {
                steps += (less[i][0] - more[i][0]).abs() + (less[i][1] - more[i][1]).abs();
            }
            if steps < ans {
                ans = steps;
            }
            if !Self::next_permutation(&mut more) {
                break;
            }
        }
        ans
    }

    pub fn next_permutation(arr: &mut Vec<Vec<i32>>) -> bool {
        let mut p = -1;
        for i in 0..arr.len() - 1 {
            if is_less(&arr[i], &arr[i + 1]) {
                p = i as i32;
            }
        }
        if p == -1 {
            return false;
        }
        let mut q = -1;
        for j in (p + 1) as usize..arr.len() {
            if is_less(&arr[p as usize], &arr[j]) {
                q = j as i32;
            }
        }
        swap(arr, p as usize, q as usize);
        let mut i = p + 1;
        let mut j = arr.len() as i32 - 1;
        while i < j {
            swap(arr, i as usize, j as usize);
            i += 1;
            j -= 1;
        }
        true
    }
}
```

**复杂度分析**

- 时间复杂度：记 $m,n$ 为网格的行数和列数，对于一般的 $m,n$ 进行分析较为复杂，这里只分析 $m=n=3$ 的情况。
    时间复杂度有两部分组成，一是排列的个数 $U$，二是数组 $more$ 和 $less$ 的长度 $V$，二者的乘积即为枚举的总次数，与时间复杂度正相关。
    考虑 $V (1 \le V \le 8)$，那么 $more$ 的长度为 $V$，且其中不同的元素个数不超过 $k \le min(V,9-V)$。那么排列的个数为：
    $$\dfrac{V!}{V_0!V_1! \dotsm V_k!} , s.t. \sum_i Vi =V$$
    当 $V$ 为定值时，分子为定值，分母应当尽量小。由于 $V_i$  的和也为定值，因此应当需要 $i$ 尽可能大并且每一个 $V_i$  尽可能小（因为 $a!b! \lt (a+b)!$）。列举所有的情况：
    - $V=1, k=1$，最多有 $\frac{1!}{1!}=1$ 个排列，枚举的总次数为 $1 \times 1=1$；
    - $V=2, k=2$，最多有 $\frac{2!}{1!1!}=2$ 个排列，枚举的总次数为 $2 \times 2=4$；
    - $V=3, k=3$，最多有 $\frac{3!}{1!1!1!}=6$ 个排列，枚举的总次数为 $3 \times 6=18$；
    - $V=4, k=4$，最多有 $\frac{4!}{1!1!1!1!}=24$ 个排列，枚举的总次数为 $4 \times 24=96$；
    - $V=5, k=4$，最多有 $\frac{5!}{1!1!1!2!}=60$ 个排列，枚举的总次数为 $5 \times 60=300$；
    - $V=6, k=3$，最多有 $\frac{6!}{2!2!2!}=90$ 个排列，枚举的总次数为 $6 \times 90=540$；
    - $V=7, k=2$，最多有 $\frac{7!}{3!4!}=35$ 个排列，枚举的总次数为 $7 \times 35=245$；
    - $V=8, k=1$，最多有 $\frac{8!}{8!}=1$ 个排列，枚举的总次数为 $8 \times 1=8$。
    因此最多的枚举次数为 $540$ 次。
- 空间复杂度：$O(mn)$，即为数组 $more$ 和 $less$ 需要使用的空间。
