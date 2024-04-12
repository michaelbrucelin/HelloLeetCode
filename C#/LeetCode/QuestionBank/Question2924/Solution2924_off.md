### [找到冠军 II](https://leetcode.cn/problems/find-champion-ii/solutions/2718321/zhao-dao-guan-jun-ii-by-leetcode-solutio-4x5y/)

#### 方法一：直接遍历

##### 思路与算法

由于每只队伍是有向无环图 $\text{DAG}$ 上的一个节点，如果存在一条边 $(a,b)$，则表示 $a$ 队比 $b$ 队强。如果不存在任何一只队伍比 $a$ 队强，则认为 $a$ 队为**冠军**，题目要求返回唯一的冠军，否则返回 $-1$，即队伍中只存在一个队伍 $a$，不存在任何队伍比 $a$ 强。

根据分析可知，$\text{DAG}$ 中所有入度为 $0$ 的点对应的队伍都不存在更强的队伍，因此入度为 $0$ 的点对应的队伍都是**冠军**，因此我们只需要检测 $\text{DAG}$ 中是否只存在**唯一**的入度为 $0$ 的节点即可。

- 首先遍历所有的边 $\textit{edges}$，对于边 $[u, v]$，将节点 $v$ 的入度加 $1$，统计完所有的入度之后再遍历 $n$ 个节点，**唯一**的入度为 $0$ 的节点返回即可，如果存在多个入度为 $0$ 的节点则返回 $-1$。

##### 代码

```c++
class Solution {
public:
    int findChampion(int n, vector<vector<int>>& edges) {
        vector<int> degree(n);
        for (auto e : edges) {
            degree[e[1]]++;
        }
        int champion = -1;
        for (int i = 0; i < n; i++) {
            if (degree[i] == 0) {
                if (champion == -1) {
                    champion = i;
                } else {
                    return -1;
                }
            }
        }
        return champion;
    }
};
```

```c
int findChampion(int n, int** edges, int edgesSize, int* edgesColSize) {
    int degree[n];
    memset(degree, 0, sizeof(degree));
    for (int i = 0; i < edgesSize; i++) {
        degree[edges[i][1]]++;
    }
    int champion = -1;
    for (int i = 0; i < n; i++) {
        if (degree[i] == 0) {
            if (champion == -1) {
                champion = i;
            } else {
                return -1;
            }
        }
    }
    return champion;
}
```

```java
class Solution {
    public int findChampion(int n, int[][] edges) {
        int[] degree = new int[n];
        for (int[] e : edges) {
            degree[e[1]]++;
        }
        int champion = -1;
        for (int i = 0; i < n; i++) {
            if (degree[i] == 0) {
                if (champion == -1) {
                    champion = i;
                } else {
                    return -1;
                }
            }
        }
        return champion;
    }
}
```

```csharp
public class Solution {
    public int FindChampion(int n, int[][] edges) {
        int[] degree = new int[n];
        foreach (int[] e in edges) {
            degree[e[1]]++;
        }
        int champion = -1;
        for (int i = 0; i < n; i++) {
            if (degree[i] == 0) {
                if (champion == -1) {
                    champion = i;
                } else {
                    return -1;
                }
            }
        }
        return champion;
    }
}
```

```python
class Solution:
    def findChampion(self, n: int, edges: List[List[int]]) -> int:
        degree = [0] * n
        for x, y in edges:
            degree[y] += 1
        champion = -1
        for i, d in enumerate(degree):
            if d == 0:
                if champion == -1:
                    champion = i
                else:
                    return -1
        return champion
```

```go
func findChampion(n int, edges [][]int) int {
    degree := make([]int, n)
    for _, e := range edges {
        degree[e[1]]++
    }
    champion := -1
    for i, d := range degree {
        if d == 0 {
            if champion == -1 {
                champion = i
            } else {
                return -1
            }
        }
    }
    return champion
}
```

```javascript
var findChampion = function(n, edges) {
    let degree = new Array(n).fill(0);
    edges.forEach(e => {
        degree[e[1]]++;
    });
    let champion = -1;
    for (let i = 0; i < n; i++) {
        if (degree[i] === 0) {
            if (champion === -1) {
                champion = i;
            } else {
                return -1;
            }
        }
    }
    return champion;
};
```

```typescript
function findChampion(n: number, edges: number[][]): number {
    let degree: number[] = new Array(n).fill(0);
    edges.forEach(e => {
        degree[e[1]]++;
    });
    let champion: number = -1;
    for (let i = 0; i < n; i++) {
        if (degree[i] === 0) {
            if (champion === -1) {
                champion = i;
            } else {
                return -1;
            }
        }
    }
    return champion;
};
```

```rust
impl Solution {
    pub fn find_champion(n: i32, edges: Vec<Vec<i32>>) -> i32 {
        let mut degree = vec![0; n as usize];
        for e in edges.iter() {
            degree[e[1] as usize] += 1;
        }
        let mut champion = -1;
        for i in 0..n {
            if degree[i as usize] == 0 {
                if champion == -1 {
                    champion = i;
                } else {
                    return -1;
                }
            }
        }
        champion
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n + m)$，其中 $n$ 表示给定节点的数目 $n$，$m$ 表示给定边 $\textit{edges}$ 的长度。需要遍历每条边，同时需要遍历每个节点的度数，需要的时间为 $O(n + m)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定节点的数目。
