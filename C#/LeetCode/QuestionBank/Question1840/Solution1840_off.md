### [最高建筑高度](https://leetcode.cn/problems/maximum-building-height/solutions/742720/zui-gao-jian-zhu-gao-du-by-leetcode-solu-axbb/)

#### 方法一：限制的传递性

**提示 1**

由于每一栋建筑在数组 $restrictions$ 中最多只会出现一次，为了叙述方便，我们将限制表示为 $(i,h_i)$ 的形式，表示建筑 $i$ 的高度不能超过 $h_i$。

虽然 $(i,h_i)$ 是限制在建筑 $i$ 之上的，但实际上，该限制也会对其余的建筑产生影响。

**提示 $1$ 解释**

如果建筑 $i$ 的高度不能超过 $h_i$，并且根据题目要求，相邻建筑的高度差不能超过 $1$，因此：

- 建筑 $i-1$ 的高度不能超过 $h_i+1$；
- 建筑 $i+1$ 的高度不能超过 $h_i+1$。

更一般地：

- 建筑 $j$ 的高度不能超过 $h_i+\vert i-j\vert $。

**提示 2**

根据提示 $1$，每一个限制 $(i,h_i)$ 实际上是对所有 $n$ 栋建筑的限制。如果我们通过某种方法将每一个限制「传递」开来，得到对第 $i$ 栋建筑的**真正的最低限制**，记为 $limit_i$，那么第 $i$ 栋建筑的高度不能超过 $limit_i$。

因此最优的建造方法，**就是将第 $i$ 栋建筑建造为高度 limit_i**。

**提示 3**

根据提示 $2$，我们可以确定每一栋建筑的高度，然而本题的数据范围为 $n\le 10^9$，即使我们使用 $O(n)$ 的方法得到所有的 $limit_i$，也会超出时间（以及空间）限制。我们最多只能得到**出现在限制数组中的那些建筑的 limit_i**。

那么对于剩余的建筑，你能找到一种方法快速确定它们的高度吗？

**提示 $3$ 解释**

事实上，我们只需要关注的是「所有 $n$ 栋建筑中的高度最大值」。

因此，如果有两栋建筑 $i$ 和 $j$，满足 $i<j$ 并且它们之间没有其它出现在限制数组里面的建筑，那么根据限制的传递性，$i$ 到 $j$ 之间建筑的高度应该形如一座「山脉」，即从建筑 $i$ 开始，高度单调递增到达最大值，再单调递减到达建筑 $j$。

假设这个最大值为 $best(i,j)$，那么需要满足：

$$(best(i,j)-limit_i)+(best(i,j)-limit_j)\le j-i$$

解得

$$best(i,j)=\Big\lfloor\dfrac{(j-i)+limit_i+limit_j}{2}\Big\rfloor$$

这样我们就可以得到「所有 $n$ 栋建筑中的高度最大值」了。

**思路与算法**

首先我们需要求出所有的 $limit_i$。

为了方便处理边界情况（即第 $1$ 栋和第 $n$ 栋建筑），我们可以在限制数组中增加 $(1,0)$ 和 $(n,n-1)$ 这两个限制，随后将限制数组根据建筑编号为关键字升序排序。

随后我们就需要将每一个限制进行传递。一种简单的办法是对限制数组进行两次遍历，第一次遍历将限制「从左向右」传递，第二次遍历将限制「从右向左」传递：

- 在「从左向右」传递的过程中，对于在限制数组中相邻的两项 $(i,h_i)$ 以及 $(j,h_j)$，限制 $(i,h_i)$ 传递到第 $j$ 栋建筑会变为 $(j,h_i+(j-i))$，我们只需要将 $h_j$ 更新为其和 $h_i+(j-i)$ 中的较小值，就可以将第 $j$ 栋建筑左侧的所有限制传递过来；
- 在「从右向左」传递的过程中，对于在限制数组中相邻的两项 $(i,h_i)$ 以及 $(j,h_j)$，限制 $(j,h_j)$ 传递到第 $i$ 栋建筑会变为 $(i,h_j+(j-i))$，我们只需要将 $h_i$ 更新为其和 $h_j+(j-i)$ 中的较小值，就可以将第 $i$ 栋建筑右侧的所有限制传递过来。

在这之后，所有的 $h_i$ 即为 $limit_i$。我们只需要根据提示 $3$ 求出最大值，即可得到最终的答案。

**代码**

```C++
class Solution {
public:
    int maxBuilding(int n, vector<vector<int>>& restrictions) {
        auto&& r = restrictions;
        // 增加限制 (1, 0)
        r.push_back({1, 0});
        sort(r.begin(), r.end());

        // 增加限制 (n, n-1)
        if (r.back()[0] != n) {
            r.push_back({n, n - 1});
        }

        int m = r.size();

        // 从左向右传递限制
        for (int i = 1; i < m; ++i) {
            r[i][1] = min(r[i][1], r[i - 1][1] + (r[i][0] - r[i - 1][0]));
        }
        // 从右向左传递限制
        for (int i = m - 2; i >= 0; --i) {
            r[i][1] = min(r[i][1], r[i + 1][1] + (r[i + 1][0] - r[i][0]));
        }

        int ans = 0;
        for (int i = 0; i < m - 1; ++i) {
            // 计算 r[i][0] 和 r[i][1] 之间的建筑的最大高度
            int best = ((r[i + 1][0] - r[i][0]) + r[i][1] + r[i + 1][1]) / 2;
            ans = max(ans, best);
        }

        return ans;
    }
};
```

```Python
class Solution:
    def maxBuilding(self, n: int, restrictions: List[List[int]]) -> int:
        r = restrictions
        # 增加限制 (1, 0)
        r.append([1, 0])
        r.sort()

        # 增加限制 (n, n-1)
        if r[-1][0] != n:
            r.append([n, n - 1])

        m = len(r)

        # 从左向右传递限制
        for i in range(1, m):
            r[i][1] = min(r[i][1], r[i - 1][1] + (r[i][0] - r[i - 1][0]))
        # 从右向左传递限制
        for i in range(m - 2, 0, -1):
            r[i][1] = min(r[i][1], r[i + 1][1] + (r[i + 1][0] - r[i][0]))

        ans = 0
        for i in range(m - 1):
            # 计算 r[i][0] 和 r[i][1] 之间的建筑的最大高度
            best = ((r[i + 1][0] - r[i][0]) + r[i][1] + r[i + 1][1]) // 2
            ans = max(ans, best)

        return ans
```

```Java
class Solution {
    public int maxBuilding(int n, int[][] restrictions) {
        // 将限制转换为列表以便操作
        List<int[]> r = new ArrayList<>();
        for (int[] res : restrictions) {
            r.add(new int[]{res[0], res[1]});
        }

        // 增加限制 (1, 0)
        r.add(new int[]{1, 0});
        // 按位置排序
        r.sort((a, b) -> Integer.compare(a[0], b[0]));
        // 增加限制 (n, n-1)
        if (r.get(r.size() - 1)[0] != n) {
            r.add(new int[]{n, n - 1});
        }

        int m = r.size();

        // 从左向右传递限制
        for (int i = 1; i < m; ++i) {
            int dist = r.get(i)[0] - r.get(i - 1)[0];
            r.get(i)[1] = Math.min(r.get(i)[1], r.get(i - 1)[1] + dist);
        }

        // 从右向左传递限制
        for (int i = m - 2; i >= 0; --i) {
            int dist = r.get(i + 1)[0] - r.get(i)[0];
            r.get(i)[1] = Math.min(r.get(i)[1], r.get(i + 1)[1] + dist);
        }

        int ans = 0;
        for (int i = 0; i < m - 1; ++i) {
            // 计算 r[i][0] 和 r[i][1] 之间的建筑的最大高度
            int dist = r.get(i + 1)[0] - r.get(i)[0];
            int best = (dist + r.get(i)[1] + r.get(i + 1)[1]) / 2;
            ans = Math.max(ans, best);
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxBuilding(int n, int[][] restrictions) {
        // 将限制转换为列表以便操作
        List<int[]> r = new List<int[]>();
        foreach (int[] res in restrictions) {
            r.Add(new int[] { res[0], res[1] });
        }

        // 增加限制 (1, 0)
        r.Add(new int[] { 1, 0 });
        // 按位置排序
        r = r.OrderBy(x => x[0]).ToList();

        // 增加限制 (n, n-1)
        if (r[r.Count - 1][0] != n) {
            r.Add(new int[] { n, n - 1 });
        }

        int m = r.Count;

        // 从左向右传递限制
        for (int i = 1; i < m; ++i) {
            int dist = r[i][0] - r[i - 1][0];
            r[i][1] = Math.Min(r[i][1], r[i - 1][1] + dist);
        }

        // 从右向左传递限制
        for (int i = m - 2; i >= 0; --i) {
            int dist = r[i + 1][0] - r[i][0];
            r[i][1] = Math.Min(r[i][1], r[i + 1][1] + dist);
        }

        int ans = 0;
        for (int i = 0; i < m - 1; ++i) {
            // 计算 r[i][0] 和 r[i][1] 之间的建筑的最大高度
            int dist = r[i + 1][0] - r[i][0];
            int best = (dist + r[i][1] + r[i + 1][1]) / 2;
            ans = Math.Max(ans, best);
        }

        return ans;
    }
}
```

```Go
func maxBuilding(n int, restrictions [][]int) int {
	// 增加限制 (1, 0)
	restrictions = append(restrictions, []int{1, 0})
    r := restrictions

	// 按位置排序
	sort.Slice(r, func(i, j int) bool {
		return r[i][0] < r[j][0]
	})
	// 增加限制 (n, n-1)
	if r[len(r)-1][0] != n {
		r = append(r, []int{n, n - 1})
	}
	m := len(r)

	// 从左向右传递限制
	for i := 1; i < m; i++ {
		dist := r[i][0] - r[i-1][0]
		if r[i-1][1]+dist < r[i][1] {
			r[i][1] = r[i-1][1] + dist
		}
	}

	// 从右向左传递限制
	for i := m - 2; i >= 0; i-- {
		dist := r[i+1][0] - r[i][0]
		if r[i+1][1]+dist < r[i][1] {
			r[i][1] = r[i+1][1] + dist
		}
	}

	ans := 0
	for i := 0; i < m-1; i++ {
		// 计算 r[i][0] 和 r[i][1] 之间的建筑的最大高度
		dist := r[i+1][0] - r[i][0]
		best := (dist + r[i][1] + r[i+1][1]) / 2
		if best > ans {
			ans = best
		}
	}

	return ans
}
```

```C
int cmp(const void* a, const void* b) {
    int* pa = *(int**)a;
    int* pb = *(int**)b;
    return pa[0] - pb[0];
}

int maxBuilding(int n, int** restrictions, int restrictionsSize, int* restrictionsColSize) {
    int m = restrictionsSize + 2;
    int** r = (int**)malloc(m * sizeof(int*));
    for (int i = 0; i < m; i++) {
        r[i] = (int*)malloc(2 * sizeof(int));
    }
    for (int i = 0; i < restrictionsSize; i++) {
        r[i][0] = restrictions[i][0];
        r[i][1] = restrictions[i][1];
    }

    // 增加限制 (1, 0)
    r[restrictionsSize][0] = 1;
    r[restrictionsSize][1] = 0;
    int currentSize = restrictionsSize + 1;
    // 排序
    qsort(r, currentSize, sizeof(int*), cmp);

    // 增加限制 (n, n-1)
    if (r[currentSize - 1][0] != n) {
        r[currentSize][0] = n;
        r[currentSize][1] = n - 1;
        currentSize++;
    }

    // 从左向右传递限制
    for (int i = 1; i < currentSize; ++i) {
        int dist = r[i][0] - r[i - 1][0];
        int val = r[i - 1][1] + dist;
        if (val < r[i][1]) {
            r[i][1] = val;
        }
    }

    // 从右向左传递限制
    for (int i = currentSize - 2; i >= 0; --i) {
        int dist = r[i + 1][0] - r[i][0];
        int val = r[i + 1][1] + dist;
        if (val < r[i][1]) {
            r[i][1] = val;
        }
    }

    int ans = 0;
    for (int i = 0; i < currentSize - 1; ++i) {
        int dist = r[i + 1][0] - r[i][0];
        int best = (dist + r[i][1] + r[i + 1][1]) / 2;
        if (best > ans) {
            ans = best;
        }
    }
    for (int i = 0; i < currentSize; i++) {
        free(r[i]);
    }
    free(r);

    return ans;
}
```

```JavaScript
var maxBuilding = function(n, restrictions) {
    let r = restrictions.map(res => [res[0], res[1]]);
    // 增加限制 (1, 0)
    r.push([1, 0]);

    // 按位置排序
    r.sort((a, b) => a[0] - b[0]);

    // 增加限制 (n, n-1)
    if (r[r.length - 1][0] !== n) {
        r.push([n, n - 1]);
    }

    const m = r.length;

    // 从左向右传递限制
    for (let i = 1; i < m; i++) {
        const dist = r[i][0] - r[i - 1][0];
        r[i][1] = Math.min(r[i][1], r[i - 1][1] + dist);
    }

    // 从右向左传递限制
    for (let i = m - 2; i >= 0; i--) {
        const dist = r[i + 1][0] - r[i][0];
        r[i][1] = Math.min(r[i][1], r[i + 1][1] + dist);
    }

    let ans = 0;
    for (let i = 0; i < m - 1; i++) {
        const dist = r[i + 1][0] - r[i][0];
        const best = Math.floor((dist + r[i][1] + r[i + 1][1]) / 2);
        ans = Math.max(ans, best);
    }

    return ans;
};
```

```TypeScript
function maxBuilding(n: number, restrictions: number[][]): number {
    let r: number[][] = restrictions.map(res => [res[0], res[1]]);
    // 增加限制 (1, 0)
    r.push([1, 0]);

    // 按位置排序
    r.sort((a, b) => a[0] - b[0]);

    // 增加限制 (n, n-1)
    if (r[r.length - 1][0] !== n) {
        r.push([n, n - 1]);
    }

    const m = r.length;

    // 从左向右传递限制
    for (let i = 1; i < m; i++) {
        const dist = r[i][0] - r[i - 1][0];
        r[i][1] = Math.min(r[i][1], r[i - 1][1] + dist);
    }

    // 从右向左传递限制
    for (let i = m - 2; i >= 0; i--) {
        const dist = r[i + 1][0] - r[i][0];
        r[i][1] = Math.min(r[i][1], r[i + 1][1] + dist);
    }

    let ans = 0;
    for (let i = 0; i < m - 1; i++) {
        const dist = r[i + 1][0] - r[i][0];
        const best = Math.floor((dist + r[i][1] + r[i + 1][1]) / 2);
        ans = Math.max(ans, best);
    }

    return ans;
}
```

```Rust
impl Solution {
    pub fn max_building(n: i32, restrictions: Vec<Vec<i32>>) -> i32 {
        let mut r: Vec<Vec<i32>> = restrictions.clone();
        // 增加限制 (1, 0)
        r.push(vec![1, 0]);

        // 按位置排序
        r.sort_by(|a, b| a[0].cmp(&b[0]));

        // 增加限制 (n, n-1)
        if r.last().unwrap()[0] != n {
            r.push(vec![n, n - 1]);
        }

        let m = r.len();

        // 从左向右传递限制
        for i in 1..m {
            let dist = r[i][0] - r[i - 1][0];
            r[i][1] = r[i][1].min(r[i - 1][1] + dist);
        }

        // 从右向左传递限制
        for i in (0..m - 1).rev() {
            let dist = r[i + 1][0] - r[i][0];
            r[i][1] = r[i][1].min(r[i + 1][1] + dist);
        }

        let mut ans = 0;
        for i in 0..m - 1 {
            let dist = r[i + 1][0] - r[i][0];
            let best = (dist + r[i][1] + r[i + 1][1]) / 2;
            ans = ans.max(best);
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m\log m)$，其中 $m$ 是数组 $restrictions$ 的长度。我们需要将限制数组进行排序，时间复杂度为 $O(m\log m)$。后续对限制的两次传递以及计算高度的时间复杂度均为 $O(m)$，因此总时间复杂度为 $O(m\log m)$。
- 空间复杂度：$O(\log m)$，即为排序需要使用的栈空间。
