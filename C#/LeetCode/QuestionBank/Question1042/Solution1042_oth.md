#### [����д������ϣ�����飩/λ���㣨Python/Java/C++/Go��](https://leetcode.cn/problems/flower-planting-with-no-adjacent/solutions/2227318/liang-chong-xie-fa-ha-xi-biao-shu-zu-wei-7hm8/)

�����˿������ܵ� [��ɫ����](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E5%9B%9B%E8%89%B2%E5%AE%9A%E7%90%86%2F805159) �����������⡣

�����൱���� $4$ ����ɫ��ͼ�е�ÿ���ڵ�Ⱦɫ��Ҫ�����ڽڵ���ɫ��ͬ���������л�԰����� $3$ ��·�����Խ�����뿪�������൱��ͼ��ÿ����Ķ�������Ϊ $3$����ôֻҪѡһ�����ھӲ�ͬ����ɫ���ɡ�

#### ��ϣ�����飩ʵ��

```python
class Solution:
    def gardenNoAdj(self, n: int, paths: List[List[int]]) -> List[int]:
        g = [[] for _ in range(n)]
        for u, v in paths:
            g[u - 1].append(v - 1)
            g[v - 1].append(u - 1)  # ��ͼ
        color = [0] * n
        for i, nodes in enumerate(g):
            color[i] = (set(range(1, 5)) - {color[j] for j in nodes}).pop()
        return color
```

```java
class Solution {
    public int[] gardenNoAdj(int n, int[][] paths) {
        List<Integer> g[] = new ArrayList[n];
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : paths) {
            int x = e[0] - 1, y = e[1] - 1; // ��ŸĴ� 0 ��ʼ
            g[x].add(y);
            g[y].add(x); // ��ͼ
        }
        var color = new int[n];
        for (int i = 0; i < n; ++i) {
            var used = new boolean[5];
            for (var j : g[i])
                used[color[j]] = true;
            while (used[++color[i]]);
        }
        return color;
    }
}
```

```cpp
class Solution {
public:
    vector<int> gardenNoAdj(int n, vector<vector<int>> &paths) {
        vector<vector<int>> g(n);
        for (auto &e: paths) {
            int x = e[0] - 1, y = e[1] - 1; // ��ŸĴ� 0 ��ʼ
            g[x].push_back(y);
            g[y].push_back(x); // ��ͼ
        }
        vector<int> color(n);
        for (int i = 0; i < n; ++i) {
            bool used[5]{};
            for (int j: g[i])
                used[color[j]] = true;
            while (used[++color[i]]);
        }
        return color;
    }
};
```

```go
func gardenNoAdj(n int, paths [][]int) []int {
    g := make([][]int, n)
    for _, e := range paths {
        x, y := e[0]-1, e[1]-1 // ��ŸĴ� 0 ��ʼ
        g[x] = append(g[x], y)
        g[y] = append(g[y], x) // ��ͼ
    }
    color := make([]int, n)
    for i, nodes := range g {
        used := [5]bool{}
        for _, j := range nodes {
            used[color[j]] = true
        }
        for color[i]++; used[color[i]]; color[i]++ {
        }
    }
    return color
}
```

#### λ����ʵ��

���ϣ����߲������飩�����ö����Ʊ�ʾ�������ƴӵ͵��ߵ� $i$ λΪ $1$ ��ʾ $i$ �ڼ����У�Ϊ $0$ ��ʾ $i$ ���ڼ����С����缯�� ${0,2,3}$ ��Ӧ�Ķ�������Ϊ $1101_{(2)}$��

��������õ���λ���㼼�ɣ�

1.  �� $x$ ��ӵ� $mask$ �У��� `mask` ����Ϊ `mask | (1 << x)`��
2.  �ҵ� $mask$ �ӵ͵��ߵ�һ�� $0$ ��λ�ã����� $mask$ ȡ�����β����������� $mask=10111_{(2)}$��ȡ�����Ϊ $1000_{(2)}$��ʵ��ǰ����Ҳȡ���ˣ�����Ӱ����㣩��β�����Ϊ $3$����ǡ�þ��Ǵӵ͵��ߵ�һ�� $0$ ��λ�á�

```python
class Solution:
    def gardenNoAdj(self, n: int, paths: List[List[int]]) -> List[int]:
        g = [[] for _ in range(n)]
        for u, v in paths:
            g[u - 1].append(v - 1)
            g[v - 1].append(u - 1)  # ��ͼ
        color = [0] * n
        for i, nodes in enumerate(g):
            mask = 1  # ������ɫ�� 1~4���� 0 ���� mask ��֤���治����� 0
            for j in g[i]:
                mask |= 1 << color[j]
            mask = ~mask
            # Python û��ͳ��β��Ŀ⺯��������ö�٣������� lowbit �Ķ����Ƴ��ȼ�һ
            color[i] = (mask & -mask).bit_length() - 1
        return color
```

```java
class Solution {
    public int[] gardenNoAdj(int n, int[][] paths) {
        List<Integer> g[] = new ArrayList[n];
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : paths) {
            int x = e[0] - 1, y = e[1] - 1; // ��ŸĴ� 0 ��ʼ
            g[x].add(y);
            g[y].add(x); // ��ͼ
        }
        var color = new int[n];
        for (int i = 0; i < n; ++i) {
            int mask = 1; // ������ɫ�� 1~4���� 0 ���� mask ��֤���治����� 0
            for (var j : g[i])
                mask |= 1 << color[j];
            color[i] = Integer.numberOfTrailingZeros(~mask);
        }
        return color;
    }
}
```

```cpp
class Solution {
public:
    vector<int> gardenNoAdj(int n, vector<vector<int>> &paths) {
        vector<vector<int>> g(n);
        for (auto &e: paths) {
            int x = e[0] - 1, y = e[1] - 1; // ��ŸĴ� 0 ��ʼ
            g[x].push_back(y);
            g[y].push_back(x); // ��ͼ
        }
        vector<int> color(n);
        for (int i = 0; i < n; ++i) {
            int mask = 1; // ������ɫ�� 1~4���� 0 ���� mask ��֤���治����� 0
            for (int j: g[i])
                mask |= 1 << color[j];
            color[i] = __builtin_ctz(~mask);
        }
        return color;
    }
};
```

```go
func gardenNoAdj(n int, paths [][]int) []int {
    g := make([][]int, n)
    for _, e := range paths {
        x, y := e[0]-1, e[1]-1 // ��ŸĴ� 0 ��ʼ
        g[x] = append(g[x], y)
        g[y] = append(g[y], x) // ��ͼ
    }
    color := make([]int, n)
    for i, nodes := range g {
        mask := uint8(1) // ������ɫ�� 1~4���� 0 ���� mask ��֤���治����� 0
        for _, j := range nodes {
            mask |= 1 << color[j]
        }
        color[i] = bits.TrailingZeros8(^mask)
    }
    return color
}
```

#### ���Ӷȷ���

-   ʱ�临�Ӷȣ�$O(n+m)$������ $m$ Ϊ $paths$ �ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(n+m)$��
