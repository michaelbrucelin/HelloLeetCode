#### [����һ����ɫ���](https://leetcode.cn/problems/flower-planting-with-no-adjacent/solutions/2226271/bu-lin-jie-zhi-hua-by-leetcode-solution-bv74/)

**˼·���㷨**

����ÿ����԰����� $3$ ��·�����Խ�����뿪�����˵��ÿ����԰����� $3$ ����԰��֮���ڣ���ÿ����԰��ѡ����ֲ������ $4$ �֣���ͱ�֤һ�����ںϷ�����ֲ����������ĿҪ�󡣻�԰����ֲ��ͬ�Ļ�������Ϊÿ����԰ֻ�ܱ��Ϊ������4����ɫΪ $1,2,3,4$ �е�һ�֣���ʼ��ʱ���ǿ���Ϊÿ����԰���Ϊ��ɫ $0$�����ڵ� $i$ ����԰��ͳ������Χ�Ļ�԰�Ѿ�����ǵ���ɫ��Ȼ���δ��ǵ���ɫ��ѡһ����ɫ�����Ǽ��ɡ������ǹ������£�

-   ���Ƚ�������ͼ���ڽ��б� $adj$ ��
-   ��ʼ��ʱ����ÿ����԰�ڵ����ɫȫ�����Ϊ $0$��
-   ����ÿ����԰����ͳ�������ڵĻ�԰����ɫ��ǣ�����δ����ǵ���ɫ���ҵ�һ����ɫ����ǰ�Ļ�԰���б�ǣ�
-   �������л�԰����ɫ��Ƿ������ɡ�

**����**

```cpp
class Solution {
public:
    vector<int> gardenNoAdj(int n, vector<vector<int>>& paths) {
        vector<vector<int>> adj(n);
        for (auto &path : paths) {
            adj[path[0] - 1].emplace_back(path[1] - 1);
            adj[path[1] - 1].emplace_back(path[0] - 1);
        }
        vector<int> ans(n);
        for (int i = 0; i < n; i++) {
            vector<bool> colored(5, false);
            for (auto &vertex : adj[i]) { 
                colored[ans[vertex]] = true;
            }
            for (int j = 1; j <= 4; j++) { 
                if (colored[j] == 0) { 
                    ans[i] = j;
                    break;
                }
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int[] gardenNoAdj(int n, int[][] paths) {
        List<Integer>[] adj = new List[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new ArrayList<Integer>();
        }
        for (int[] path : paths) {
            adj[path[0] - 1].add(path[1] - 1);
            adj[path[1] - 1].add(path[0] - 1);
        }
        int[] ans = new int[n];
        for (int i = 0; i < n; i++) {
            boolean[] colored = new boolean[5];
            for (int vertex : adj[i]) { 
                colored[ans[vertex]] = true;
            }
            for (int j = 1; j <= 4; j++) { 
                if (!colored[j]) { 
                    ans[i] = j;
                    break;
                }
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def gardenNoAdj(self, n: int, paths: List[List[int]]) -> List[int]:
        adj = [[] for i in range(n)]
        for path in paths:
            adj[path[0] - 1].append(path[1] - 1)
            adj[path[1] - 1].append(path[0] - 1)
        ans = [0] * n
        for i in range(n):
            colored = [False] * 5
            for vertex in adj[i]:
                colored[ans[vertex]] = True
            for j in range(1, 5):
                if not colored[j]:
                    ans[i] = j
                    break
        return ans
```

```csharp
public class Solution {
    public int[] GardenNoAdj(int n, int[][] paths) {
        IList<int>[] adj = new IList<int>[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new List<int>();
        }
        foreach (int[] path in paths) {
            adj[path[0] - 1].Add(path[1] - 1);
            adj[path[1] - 1].Add(path[0] - 1);
        }
        int[] ans = new int[n];
        for (int i = 0; i < n; i++) {
            bool[] colored = new bool[5];
            foreach (int vertex in adj[i]) { 
                colored[ans[vertex]] = true;
            }
            for (int j = 1; j <= 4; j++) { 
                if (!colored[j]) { 
                    ans[i] = j;
                    break;
                }
            }
        }
        return ans;
    }
}
```

```c
int* gardenNoAdj(int n, int** paths, int pathsSize, int* pathsColSize, int* returnSize) {
    int adj[n][3], adjSize[n];
    memset(adjSize, 0, sizeof(adjSize));
    for (int i = 0; i < pathsSize; i++) {
        int x = paths[i][0] - 1;
        int y = paths[i][1] - 1;
        adj[x][adjSize[x]++] = y;
        adj[y][adjSize[y]++] = x;
    }
    int *ans = (int *)calloc(sizeof(int), n);
    for (int i = 0; i < n; i++) {
        bool colored[5];
        memset(colored, 0, sizeof(colored));
        for (int j = 0; j < adjSize[i]; j++) { 
            int vertex = adj[i][j];
            colored[ans[vertex]] = true;
        }
        for (int j = 1; j <= 4; j++) { 
            if (colored[j] == 0) { 
                ans[i] = j;
                break;
            }
        }
    }
    *returnSize = n;
    return ans;
}
```

```go
func gardenNoAdj(n int, paths [][]int) []int {
    adj := make([][]int, n)
    for i := 0; i < n; i++ {
        adj[i] = []int{}
    }
    for _, path := range paths {
        adj[path[0]-1] = append(adj[path[0]-1], path[1]-1)
        adj[path[1]-1] = append(adj[path[1]-1], path[0]-1)
    }
    ans := make([]int, n)
    for i := 0; i < n; i++ {
        colored := make([]bool, 5)
        for _, vertex := range adj[i] {
            colored[ans[vertex]] = true
        }
        for j := 1; j <= 4; j++ {
            if !colored[j] {
                ans[i] = j
                break
            }
        }
    }
    return ans
}
```

```javascript
var gardenNoAdj = function(n, paths) {
    let adj = new Array(n).fill(null).map(() => []);
    for (let path of paths) {
        adj[path[0] - 1].push(path[1] - 1);
        adj[path[1] - 1].push(path[0] - 1);
    }
    let ans = new Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        let colored = new Array(5).fill(false);
        for (let vertex of adj[i]) {
            colored[ans[vertex]] = true;
        }
        for (let j = 1; j <= 4; j++) {
            if (!colored[j]) {
                ans[i] = j;
                break;
            }
        }
    }
    return ans;
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n + m)$������ $n$ ��ʾ��԰����Ŀ��$m$ ��ʾ $paths$ ����Ŀ��������Ŀ��ÿ����԰���ڽӽڵ���Ŀ������ $3$ �������ÿ���ڵ�ı߲����� $3$ �������Ա������еĽڵ������еı���Ҫ���ܵ�ʱ�䲻���� $O(m + n)$��
-   �ռ临�Ӷȣ�$O(n + m)$������ $n$ ��ʾ��԰����Ŀ��$m$ ��ʾ $paths$ ����Ŀ����Ҫ�洢ÿ���ڵ���ڽӽڵ㣬�ܹ���Ҫ�Ŀռ�Ϊ $O(n + m)$��
