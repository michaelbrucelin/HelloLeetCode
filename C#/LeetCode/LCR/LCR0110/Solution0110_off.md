### [所有路径](https://leetcode.cn/problems/bP4bmD/solutions/1036319/suo-you-lu-jing-by-leetcode-solution-z37g/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：深度优先搜索

**思路和算法**

我们可以使用深度优先搜索的方式求出所有可能的路径。具体地，我们从 $0$ 号点出发，使用栈记录路径上的点。每次我们遍历到点 $n-1$，就将栈中记录的路径加入到答案中。

特别地，因为本题中的图为有向无环图（$DAG$），搜索过程中不会反复遍历同一个点，因此我们无需判断当前点是否遍历过。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> ans;
    vector<int> stk;

    void dfs(vector<vector<int>>& graph, int x, int n) {
        if (x == n) {
            ans.push_back(stk);
            return;
        }
        for (auto& y : graph[x]) {
            stk.push_back(y);
            dfs(graph, y, n);
            stk.pop_back();
        }
    }

    vector<vector<int>> allPathsSourceTarget(vector<vector<int>>& graph) {
        stk.push_back(0);
        dfs(graph, 0, graph.size() - 1);
        return ans;
    }
};
```

```Java
class Solution {
    List<List<Integer>> ans = new ArrayList<List<Integer>>();
    Deque<Integer> stack = new ArrayDeque<Integer>();

    public List<List<Integer>> allPathsSourceTarget(int[][] graph) {
        stack.offerLast(0);
        dfs(graph, 0, graph.length - 1);
        return ans;
    }

    public void dfs(int[][] graph, int x, int n) {
        if (x == n) {
            ans.add(new ArrayList<Integer>(stack));
            return;
        }
        for (int y : graph[x]) {
            stack.offerLast(y);
            dfs(graph, y, n);
            stack.pollLast();
        }
    }
}
```

```Python
class Solution:
    def allPathsSourceTarget(self, graph: List[List[int]]) -> List[List[int]]:
        ans = list()
        stk = list()

        def dfs(x: int):
            if x == len(graph) - 1:
                ans.append(stk[:])
                return

            for y in graph[x]:
                stk.append(y)
                dfs(y)
                stk.pop()

        stk.append(0)
        dfs(0)
        return ans
```

```C
int** ans;
int stk[15];
int stkSize;

void dfs(int x, int n, int** graph, int* graphColSize, int* returnSize, int** returnColumnSizes) {
    if (x == n) {
        int* tmp = malloc(sizeof(int) * stkSize);
        memcpy(tmp, stk, sizeof(int) * stkSize);
        ans[*returnSize] = tmp;
        (*returnColumnSizes)[(*returnSize)++] = stkSize;
        return;
    }
    for (int i = 0; i < graphColSize[x]; i++) {
        int y = graph[x][i];
        stk[stkSize++] = y;
        dfs(y, n, graph, graphColSize, returnSize, returnColumnSizes);
        stkSize--;
    }
}

int** allPathsSourceTarget(int** graph, int graphSize, int* graphColSize, int* returnSize, int** returnColumnSizes) {
    stkSize = 0;
    stk[stkSize++] = 0;
    ans = malloc(sizeof(int*) * 16384);
    *returnSize = 0;
    *returnColumnSizes = malloc(sizeof(int) * 16384);
    dfs(0, graphSize - 1, graph, graphColSize, returnSize, returnColumnSizes);
    return ans;
}
```

```Go
func allPathsSourceTarget(graph [][]int) (ans [][]int) {
    stk := []int{0}
    var dfs func(int)
    dfs = func(x int) {
        if x == len(graph)-1 {
            ans = append(ans, append([]int(nil), stk...))
            return
        }
        for _, y := range graph[x] {
            stk = append(stk, y)
            dfs(y)
            stk = stk[:len(stk)-1]
        }
    }
    dfs(0)
    return
}
```

```JavaScript
var allPathsSourceTarget = function(graph) {
    const stack = [], ans = [];

    const dfs = (graph, x, n) => {
        if (x === n) {
            ans.push(stack.slice());
            return;
        }
        for (const y of graph[x]) {
            stack.push(y);
            dfs(graph, y, n);
            stack.pop();
        }
    }

    stack.push(0);
    dfs(graph, 0, graph.length - 1);
    return ans;
};
```

**复杂度分析**

- 时间复杂度：$O(n\times 2^n)$，其中 $n$ 为图中点的数量。我们可以找到一种最坏情况，即每一个点都可以去往编号比它大的点。此时路径数为 $O(2^n)$，且每条路径长度为 $O(n)$，因此总时间复杂度为 $O(n\times 2^n)$。
- 空间复杂度：$O(n)$，其中 $n$ 为点的数量。主要为栈空间的开销。注意返回值不计入空间复杂度。
