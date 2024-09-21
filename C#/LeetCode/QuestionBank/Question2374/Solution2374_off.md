### [边积分最高的节点](https://leetcode.cn/problems/node-with-highest-edge-score/solutions/2905555/bian-ji-fen-zui-gao-de-jie-dian-by-leetc-hzjb/)

#### 方法一：模拟

**思路与算法**

首先我们要求出所有点的边积分，然后从中找到边积分最高的点，若不止一个，则取编号最小的那个。

在求边积分时，需要用一个哈希表来统计所有点的边积分。具体的，我们每次遍历到一条由 $x$ 指向 $y$ 的有向边时，将 $y$ 的边积分增加 $x$。因为每个节点有且仅有一条边，因此我们不需要考虑重边的情况。

另外需要注意的是，点的编号数值最大可达 $10^5$，因此边积分可能会超出 $int32$ 的范围，在某些语言中需要使用 $int64$ 来存储边积分。

**代码**

```C++
class Solution {
public:
    using ll = long long;
    int edgeScore(vector<int>& edges) {
        int n = edges.size();
        vector<ll> points(n);
        for (int i = 0; i < n; i++) {
            points[edges[i]] += i;
        }
        ll max_points = -1;
        int res = -1;
        for (int i = 0; i < n; i++) {
            if (points[i] > max_points) {
                max_points = points[i];
                res = i;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int edgeScore(int[] edges) {
        int n = edges.length;
        long[] points = new long[n];
        for (int i = 0; i < n; i++) {
            points[edges[i]] += i;
        }
        long maxPoints = -1;
        int res = -1;
        for (int i = 0; i < n; i++) {
            if (points[i] > maxPoints) {
                maxPoints = points[i];
                res = i;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int EdgeScore(int[] edges) {
        int n = edges.Length;
        long[] points = new long[n];
        for (int i = 0; i < n; i++) {
            points[edges[i]] += i;
        }
        long maxPoints = -1;
        int res = -1;
        for (int i = 0; i < n; i++) {
            if (points[i] > maxPoints) {
                maxPoints = points[i];
                res = i;
            }
        }
        return res;
    }
}
```

```Pyhton
class Solution:
    def edgeScore(self, edges: List[int]) -> int:
        n = len(edges)
        points = [0] * n
        for x, y in enumerate(edges):
            points[y] += x
        max_points = -1
        res = -1
        for i in range(n):
            if points[i] > max_points:
                max_points = points[i]
                res = i
        return res
```

```Go
func edgeScore(edges []int) int {
    n := len(edges)
    points := make([]int64, n)
    for i, x := range edges {
        points[x] += int64(i);
    }
    maxPoints := int64(-1)
    res := -1
    for i := 0; i < n; i++ {
        if points[i] > maxPoints {
            maxPoints = points[i]
            res = i
        }
    }
    return res
}
```

```C
int edgeScore(int* edges, int edgesSize) {
    long long *points = (int *)calloc(edgesSize, sizeof(long long));
    for (int i = 0; i < edgesSize; i++) {
        points[edges[i]] += i;
    }
    long long maxPoints = -1;
    int res = -1;
    for (int i = 0; i < edgesSize; i++) {
        if (points[i] > maxPoints) {
            maxPoints = points[i];
            res = i;
        }
    }
    free(points);
    return res;
}
```

```JavaScript
var edgeScore = function(edges) {
    const n = edges.length;
    const points = new Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        points[edges[i]] += i;
    }
    let maxPoints = -1;
    let res = -1;
    for (let i = 0; i < n; i++) {
        if (points[i] > maxPoints) {
            maxPoints = points[i];
            res = i;
        }
    }
    return res;
};
```

```TypeScript
function edgeScore(edges: number[]): number {
    const n = edges.length;
    const points: number[] = new Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        points[edges[i]] += i;
    }
    let maxPoints: number = -1;
    let res: number = -1;
    for (let i = 0; i < n; i++) {
        if (points[i] > maxPoints) {
            maxPoints = points[i];
            res = i;
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn edge_score(edges: Vec<i32>) -> i32 {
        let n = edges.len();
        let mut points = vec![0i64; n];
        for (i, &edge) in edges.iter().enumerate() {
            points[edge as usize] += i as i64;
        }
        let mut max_points = -1i64;
        let mut res = -1i32;
        for (i, &points_val) in points.iter().enumerate() {
            if points_val > max_points {
                max_points = points_val;
                res = i as i32;
            }
        }
        res
    }
}
```

```Cangjie
class Solution {
    func edgeScore(edges: Array<Int64>): Int64 {
        var n = edges.size
        let points = Array<Int64>(n, item: 0)

        for (i in 0..n) {
            points[edges[i]] += i
        }
        var max_points:Int64 = -1
        var res:Int64 = -1
        for (i in 0..n) {
            if (points[i] > max_points) {
                max_points = points[i]
                res = i
            }
        }
        return res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $edges$ 的长度。过程中共有两次循环，每次循环的时间复杂度为 $O(n)$，因此总体时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$。由于点的编号有序且范围确定，我们使用数组来表示哈希表，空间复杂度为 $O(n)$。
