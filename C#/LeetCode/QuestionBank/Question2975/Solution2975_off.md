### [移除栅栏得到的正方形田地的最大面积](https://leetcode.cn/problems/maximum-square-area-by-removing-fences-from-a-field/solutions/3878494/yi-chu-zha-lan-de-dao-de-zheng-fang-xing-00t4/)

#### 方法一：枚举

**思路与算法**

题目要我们求去除一些栅栏所能形成的最大面积的正方形田地的面积，我们可以分别求出水平和垂直方向上去除栅栏所能形成的正方形边长，得到两个集合，再求出这两个集合交集中的最大值，求其平方即可。如果这两个集合的交集为空，则答案为 $-1$。

具体的，我们在水平和垂直方向上计算出任意两个栅栏之间的距离（去除两栅栏之间的栅栏后形成的边长），就可以得到去除栅栏后所能形成的正方形边长。

**代码**

```C++
class Solution {
    unordered_set<int> getEdges(vector<int>& fences, int border) {
        unordered_set<int> st;
        fences.push_back(1);
        fences.push_back(border);
        sort(fences.begin(), fences.end());
        for (int i = 0; i < fences.size(); i++) {
            for (int j = i + 1; j < fences.size(); j++) {
                st.insert(fences[j] - fences[i]);
            }
        }
        return st;
    }
public:
    int maximizeSquareArea(int m, int n, vector<int>& hFences, vector<int>& vFences) {
        auto hEdges = getEdges(hFences, m);
        auto vEdges = getEdges(vFences, n);
        int res = 0;
        for (auto e : hEdges) {
            if (vEdges.contains(e)) {
                res = max(res, e);
            }
        }
        if (res == 0) {
            res = -1;
        } else {
            res = 1ll * res * res % 1000000007;
        }
        return res;
    }
};
```

```Python
class Solution:
    def get_edges(self, fences: List[int], border: int) -> set:
            points = sorted([1] + fences + [border])
            return {points[j] - points[i]
                    for i in range(len(points))
                    for j in range(i + 1, len(points))}

    def maximizeSquareArea(self, m: int, n: int, hFences: List[int], vFences: List[int]) -> int:
        MOD = 10**9 + 7
        h_edges = self.get_edges(hFences, m)
        v_edges = self.get_edges(vFences, n)

        max_edge = max(h_edges & v_edges, default=0)
        return (max_edge * max_edge) % MOD if max_edge else -1
```

```Java
class Solution {
    public int maximizeSquareArea(int m, int n, int[] hFences, int[] vFences) {
        Set<Integer> hEdges = getEdges(hFences, m);
        Set<Integer> vEdges = getEdges(vFences, n);

        long res = 0;
        for (int e : hEdges) {
            if (vEdges.contains(e)) {
                res = Math.max(res, e);
            }
        }

        if (res == 0) {
            return -1;
        } else {
            return (int)((res * res) % 1000000007);
        }
    }

    private Set<Integer> getEdges(int[] fences, int border) {
        Set<Integer> set = new HashSet<>();
        List<Integer> list = new ArrayList<>();

        for (int fence : fences) {
            list.add(fence);
        }

        list.add(1);
        list.add(border);
        Collections.sort(list);

        for (int i = 0; i < list.size(); i++) {
            for (int j = i + 1; j < list.size(); j++) {
                set.add(list.get(j) - list.get(i));
            }
        }

        return set;
    }
}
```

```CSharp
public class Solution {
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences) {
        var hEdges = GetEdges(hFences, m);
        var vEdges = GetEdges(vFences, n);

        long res = 0;
        foreach (int e in hEdges) {
            if (vEdges.Contains(e)) {
                res = Math.Max(res, e);
            }
        }

        if (res == 0) {
            return -1;
        } else {
            return (int)((res * res) % 1000000007);
        }
    }

    private HashSet<int> GetEdges(int[] fences, int border) {
        var set = new HashSet<int>();
        var list = new List<int>(fences);

        list.Add(1);
        list.Add(border);
        list.Sort();
        for (int i = 0; i < list.Count; i++) {
            for (int j = i + 1; j < list.Count; j++) {
                set.Add(list[j] - list[i]);
            }
        }

        return set;
    }
}
```

```Go
func maximizeSquareArea(m int, n int, hFences []int, vFences []int) int {
    hEdges := getEdges(hFences, m)
    vEdges := getEdges(vFences, n)

    var res int64 = 0
    for e := range hEdges {
        if _, exists := vEdges[e]; exists {
            if int64(e) > res {
                res = int64(e)
            }
        }
    }

    if res == 0 {
        return -1
    }
    return int((res * res) % 1000000007)
}

func getEdges(fences []int, border int) map[int]bool {
    set := make(map[int]bool)
    list := make([]int, len(fences))

    copy(list, fences)
    list = append(list, 1, border)
    sort.Ints(list)

    for i := 0; i < len(list); i++ {
        for j := i + 1; j < len(list); j++ {
            set[list[j] - list[i]] = true
        }
    }

    return set
}
```

```C
static int compare(const void* a, const void* b) {
    int x = *(const int*)a;
    int y = *(const int*)b;
    return (x > y) - (x < y);
}

static int* getEdges(int* fences, int fencesSize, int border, int* outSize) {
    int arrSize = fencesSize + 2;
    int* arr = (int*)malloc(sizeof(int) * arrSize);
    memcpy(arr, fences, sizeof(int) * fencesSize);
    arr[fencesSize] = 1;
    arr[fencesSize + 1] = border;
    qsort(arr, arrSize, sizeof(int), compare);

    int maxEdges = arrSize * (arrSize - 1) / 2;
    int* edges = (int*)malloc(sizeof(int) * maxEdges);
    int idx = 0;
    for (int i = 0; i < arrSize; i++) {
        for (int j = i + 1; j < arrSize; j++) {
            edges[idx++] = arr[j] - arr[i];
        }
    }
    free(arr);
    qsort(edges, idx, sizeof(int), compare);

    int k = 0;
    for (int i = 0; i < idx; i++) {
        if (i == 0 || edges[i] != edges[i - 1]) {
            edges[k++] = edges[i];
        }
    }
    *outSize = k;
    return edges;
}

int maximizeSquareArea(int m, int n, int* hFences, int hFencesSize,
                       int* vFences, int vFencesSize) {
    int hSize = 0, vSize = 0;
    int* hEdges = getEdges(hFences, hFencesSize, m, &hSize);
    int* vEdges = getEdges(vFences, vFencesSize, n, &vSize);

    int i = 0, j = 0;
    int res = 0;
    while (i < hSize && j < vSize) {
        if (hEdges[i] == vEdges[j]) {
            if (hEdges[i] > res) res = hEdges[i];
            i++;
            j++;
        } else if (hEdges[i] < vEdges[j]) {
            i++;
        } else {
            j++;
        }
    }

    free(hEdges);
    free(vEdges);

    if (res == 0) return -1;
    long long ans = (long long)res * res % 1000000007;
    return (int)ans;
}
```

```JavaScript
var maximizeSquareArea = function(m, n, hFences, vFences) {
    const MOD = 1000000007;

    const getEdges = (fences, border) => {
        const set = new Set();
        const list = [...fences];
        list.push(1);
        list.push(border);
        list.sort((a, b) => a - b);

        for (let i = 0; i < list.length; i++) {
            for (let j = i + 1; j < list.length; j++) {
                set.add(list[j] - list[i]);
            }
        }

        return set;
    };

    const hEdges = getEdges(hFences, m);
    const vEdges = getEdges(vFences, n);

    let res = 0;
    for (const e of hEdges) {
        if (vEdges.has(e)) {
            res = Math.max(res, e);
        }
    }

    if (res === 0) {
        return -1;
    }

    return Number((BigInt(res) * BigInt(res)) % BigInt(MOD));
};
```

```TypeScript
function maximizeSquareArea(m: number, n: number, hFences: number[], vFences: number[]): number {
    const MOD = 1000000007;

    const getEdges = (fences: number[], border: number): Set<number> => {
        const set = new Set<number>();
        const list = [...fences];

        list.push(1);
        list.push(border);
        list.sort((a, b) => a - b);

        for (let i = 0; i < list.length; i++) {
            for (let j = i + 1; j < list.length; j++) {
                set.add(list[j] - list[i]);
            }
        }

        return set;
    };

    const hEdges = getEdges(hFences, m);
    const vEdges = getEdges(vFences, n);

    let res = 0;
    for (const e of hEdges) {
        if (vEdges.has(e)) {
            res = Math.max(res, e);
        }
    }

    if (res === 0) {
        return -1;
    }

    return Number((BigInt(res) * BigInt(res)) % BigInt(MOD));
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn maximize_square_area(m: i32, n: i32, h_fences: Vec<i32>, v_fences: Vec<i32>) -> i32 {
        const MOD: i64 = 1_000_000_007;

        let get_edges = |fences: &[i32], border: i32| -> HashSet<i32> {
            let mut points = vec![1];
            points.extend_from_slice(fences);
            points.push(border);
            points.sort_unstable();

            (0..points.len())
                .flat_map(|i| {
                    let pi = points[i];
                    points[i+1..].iter().map(move |&b| b - pi)
                })
                .collect()
        };

        let h_edges = get_edges(&h_fences, m);
        let v_edges = get_edges(&v_fences, n);

        h_edges.intersection(&v_edges)
            .max()
            .map_or(-1, |&e| ((e as i64).pow(2) % MOD) as i32)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(h^2+v^2)$，其中 $h$ 是 $hFences$ 的大小, $v$ 是 $vFences$ 的大小。计算水平和垂直方向上任意两个栅栏之间的距离的时间复杂度分别为 $O(h^2)$ 和 $O(v^2)$，计算交集的时间复杂度为 $O(h^2)$（枚举水平方向上的边，查看垂直方向上是否有相同长度的边），因此总体时间复杂度为 $O(h^2)+O(v^2)$。
- 空间复杂度：$O(h^2+v^2)$。
