#### [方法二：贪心](https://leetcode.cn/problems/maximal-network-rank/solutions/2167846/zui-da-wang-luo-zhi-by-leetcode-solution-x4gx/)

**思路与算法**

我们可以对解法一中的方法继续优化。设 $first$ 表示所有节点中度数的最大值，$second$ 表示所有节点中度数的次大值，实际我们只需要考虑度数为最大值与次大值的城市即可，其余即可城市可以无须考虑，原因如下：

-   已知最大值 $first$ 与次大值 $second$，则此时可以知道当前最差的情况下，假设这两城市存在连接，则最大的网络秩为 $first + second - 1$；
-   假设存在度数比 $second$ 的城市 $x$，则此时 $degree[x] < second$，此时含有 $x$ 构成的城市对的最大网络秩不超过 $degree[x] + first$，此时一定满足$degree[x] + first \le second + first$；

综上可以得出结论选择最大或者次大度数的城市一定是最优的。我们可以求出度数为 $first$ 的城市集合 $firstArr$，同时求出度数为 $second$ 的城市集合 $secondArr$。设城市的总数量为 $n$，道路的总数量为 $m$，集合 $firstArr$ 的数量为 $x$，则此时该集合可以构造的城市对数量为 $\dfrac{x(x-1)}{2}$，分以下几种情况来讨论:

-   如果 $x = 1$，此时我们必须选择 $firstArr$ 中唯一的城市，另一个城市只能在 $secondArr$ 中选择，枚举 $secondArr$ 中的每个城市，找到最大的网络秩即可，此时需要的时间复杂度为 $O(n)$；
-   如果 $x > 1$ 时，分类讨论如下：
    -   如果满足 $\binom{x}{2} > m$ 时，此时集合 $firstArr$ 一定存在一对城市，他们之间没有道路连接，此时最大的网络秩即为 $2 \times first$；
    -   如果满足 $\binom{x}{2} \le m$ 时，此时枚举集合 $firstArr$ 中所有不同的城市对即可，此时不需要再考虑次大的城市集合 $secondArr$，因为此时一定满足 $2 \times first - 1 \ge first + second > 2 \times second$ ，此时时间复杂度不超过 $O(m)$；

因此通过以上分析，上述解法的时间复杂度为 $O(n + m)$。

```cpp
class Solution {
public:
    int maximalNetworkRank(int n, vector<vector<int>>& roads) {
        vector<vector<bool>> connect(n, vector<bool>(n, false));
        vector<int> degree(n);
        for (auto road : roads) {
            int x = road[0], y = road[1];
            connect[x][y] = true;
            connect[y][x] = true;
            degree[x]++;
            degree[y]++;
        }

        int first = -1, second = -2;
        vector<int> firstArr, secondArr;
        for (int i = 0; i < n; ++i) {
            if (degree[i] > first) {
                second = first;
                secondArr = firstArr;
                first = degree[i];
                firstArr.clear();
                firstArr.emplace_back(i);
            } else if (degree[i] == first) {
                firstArr.emplace_back(i);
            } else if (degree[i] > second){
                secondArr.clear();
                second = degree[i];
                secondArr.emplace_back(i);
            } else if (degree[i] == second) {
                secondArr.emplace_back(i);
            }
        }
        if (firstArr.size() == 1) {
            int u = firstArr[0];
            for (int v : secondArr) {
                if (!connect[u][v]) {
                    return first + second;
                }
            }
            return first + second - 1;
        } else {
            int m = roads.size();
            if (firstArr.size() * (firstArr.size() - 1) / 2 > m) {
                return first * 2;
            }
            for (int u: firstArr) {
                for (int v: firstArr) {
                    if (u != v && !connect[u][v]) {
                        return first * 2;
                    }
                }
            }
            return first * 2 - 1;
        }
    }
};
```

```java
class Solution {
    public int maximalNetworkRank(int n, int[][] roads) {
        boolean[][] connect = new boolean[n][n];
        int[] degree = new int[n];
        for (int[] road : roads) {
            int x = road[0], y = road[1];
            connect[x][y] = true;
            connect[y][x] = true;
            degree[x]++;
            degree[y]++;
        }

        int first = -1, second = -2;
        List<Integer> firstArr = new ArrayList<Integer>();
        List<Integer> secondArr = new ArrayList<Integer>();
        for (int i = 0; i < n; ++i) {
            if (degree[i] > first) {
                second = first;
                secondArr = new ArrayList<Integer>(firstArr);
                first = degree[i];
                firstArr.clear();
                firstArr.add(i);
            } else if (degree[i] == first) {
                firstArr.add(i);
            } else if (degree[i] > second){
                secondArr.clear();
                second = degree[i];
                secondArr.add(i);
            } else if (degree[i] == second) {
                secondArr.add(i);
            }
        }
        if (firstArr.size() == 1) {
            int u = firstArr.get(0);
            for (int v : secondArr) {
                if (!connect[u][v]) {
                    return first + second;
                }
            }
            return first + second - 1;
        } else {
            int m = roads.length;
            if (firstArr.size() * (firstArr.size() - 1) / 2 > m) {
                return first * 2;
            }
            for (int u : firstArr) {
                for (int v : firstArr) {
                    if (u != v && !connect[u][v]) {
                        return first * 2;
                    }
                }
            }
            return first * 2 - 1;
        }
    }
}
```

```csharp
public class Solution {
    public int MaximalNetworkRank(int n, int[][] roads) {
        bool[][] connect = new bool[n][];
        for (int i = 0; i < n; i++) {
            connect[i] = new bool[n];
        }
        int[] degree = new int[n];
        foreach (int[] road in roads) {
            int x = road[0], y = road[1];
            connect[x][y] = true;
            connect[y][x] = true;
            degree[x]++;
            degree[y]++;
        }

        int first = -1, second = -2;
        IList<int> firstArr = new List<int>();
        IList<int> secondArr = new List<int>();
        for (int i = 0; i < n; ++i) {
            if (degree[i] > first) {
                second = first;
                secondArr = new List<int>(firstArr);
                first = degree[i];
                firstArr.Clear();
                firstArr.Add(i);
            } else if (degree[i] == first) {
                firstArr.Add(i);
            } else if (degree[i] > second){
                secondArr.Clear();
                second = degree[i];
                secondArr.Add(i);
            } else if (degree[i] == second) {
                secondArr.Add(i);
            }
        }
        if (firstArr.Count == 1) {
            int u = firstArr[0];
            foreach (int v in secondArr) {
                if (!connect[u][v]) {
                    return first + second;
                }
            }
            return first + second - 1;
        } else {
            int m = roads.Length;
            if (firstArr.Count * (firstArr.Count - 1) / 2 > m) {
                return first * 2;
            }
            foreach (int u in firstArr) {
                foreach (int v in firstArr) {
                    if (u != v && !connect[u][v]) {
                        return first * 2;
                    }
                }
            }
            return first * 2 - 1;
        }
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int maximalNetworkRank(int n, int** roads, int roadsSize, int* roadsColSize) {
    bool connect[n][n];
    int degree[n];
    memset(connect, 0, sizeof(connect));
    memset(degree, 0, sizeof(degree));
    for (int i = 0; i < roadsSize; i++) {
        int x = roads[i][0], y = roads[i][1];
        connect[x][y] = true;
        connect[y][x] = true;
        degree[x]++;
        degree[y]++;
    }

    int first = -1, second = -2;
    int firstArr[n], secondArr[n];
    int firstArrSize = 0, secondArrSize = 0;
    for (int i = 0; i < n; ++i) {
        if (degree[i] > first) {
            second = first;
            secondArrSize = firstArrSize;
            memcpy(secondArr, firstArr, sizeof(int) * firstArrSize);
            first = degree[i];
            firstArrSize = 0;
            firstArr[firstArrSize++] = i;
        } else if (degree[i] == first) {
            firstArr[firstArrSize++] = i;
        } else if (degree[i] > second){
            secondArrSize = 0;
            second = degree[i];
            secondArr[secondArrSize++] = i;
        } else if (degree[i] == second) {
            secondArr[secondArrSize++] = i;
        }
    }
    if (firstArrSize == 1) {
        int u = firstArr[0];
        for (int i = 0; i < secondArrSize; i++) {
            int v = secondArr[i];
            if (!connect[u][v]) {
                return first + second;
            }
        }
        return first + second - 1;
    } else {
        if (firstArrSize * (firstArrSize - 1) / 2 > roadsSize) {
            return first * 2;
        }
        for (int i = 0; i < firstArrSize; i++) {
            int u = firstArr[i];
            for (int j = i + 1; j < firstArrSize; j++) {
                int v = firstArr[j];
                if (!connect[u][v]) {
                    return first * 2;
                }
            }
        }
        return first * 2 - 1;
    }        
}
```

```javascript
var maximalNetworkRank = function(n, roads) {
    const connect = new Array(n).fill(0).map(() => new Array(n).fill(0));
    const degree = new Array(n).fill(0);
    for (const road of roads) {
        let x = road[0], y = road[1];
        connect[x][y] = true;
        connect[y][x] = true;
        degree[x]++;
        degree[y]++;
    }

    let first = -1, second = -2;
    let firstArr = [];
    let secondArr = [];
    for (let i = 0; i < n; ++i) {
        if (degree[i] > first) {
            second = first;
            secondArr = [...firstArr];
            first = degree[i];
            firstArr = [i];
        } else if (degree[i] === first) {
            firstArr.push(i);
        } else if (degree[i] > second){
            secondArr = [];
            second = degree[i];
            secondArr.push(i);
        } else if (degree[i] === second) {
            secondArr.push(i);
        }
    }
    if (firstArr.length === 1) {
        const u = firstArr[0];
        for (const v of secondArr) {
            if (!connect[u][v]) {
                return first + second;
            }
        }
        return first + second - 1;
    } else {
        const m = roads.length;
        if (firstArr.length * (firstArr.length - 1) / 2 > m) {
            return first * 2;
        }
        for (const u of firstArr) {
            for (const v of firstArr) {
                if (u !== v && !connect[u][v]) {
                    return first * 2;
                }
            }
        }
        return first * 2 - 1;
    }
};
```

**复杂度分析**

-   时间复杂度：$O(n + m)$，其中 $n$ 表示给定的数字 $n$，$m$ 表示城市之间的道路总数。计算城市的度数需要的时间为 $O(m)$，找到城市中最大度数和次大度数城市集合需要的时间为 $O(n)$，计算城市对中最大的网络秩需要的时间为 $O(m)$，因此总的时间复杂度为 $O(m + n)$。
-   空间复杂度：$O(n^2)$。需要记录图中所有的城市之间的联通关系，需要的空间为 $O(n^2)$，记录所有节点的度需要的空间为 $O(n)$，记录最大度数与次大度数的城市集合需要的空间为 $O(n)$，因此总的空间复杂度为 $O(n^2)$。如果用邻接表存储连通关系，空间复杂度可以优化到 $O(n + m)$，其中 $m$ 表示 $roads$ 的长度。
