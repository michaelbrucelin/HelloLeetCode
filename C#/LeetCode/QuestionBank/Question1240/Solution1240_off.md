#### [方法一：回溯](https://leetcode.cn/problems/tiling-a-rectangle-with-the-fewest-squares/solutions/2300093/pu-ci-zhuan-by-leetcode-solution-r1bk/)

**前言**

本题为一道经典的数学问题，详细可以参考相关的学术论文：「[Minimum tiling of a rectangle by squares](https://leetcode.cn/link/?target=https%3A%2F%2Flink.springer.com%2Farticle%2F10.1007%2Fs10479-017-2746-2)」。假设 $n,m$ 分别为矩形的长与宽，设 $h(m,n)$ 表示铺满该矩形所需的正方形的最少数目，根据参考资料: 「[Filling rectangles with integer-sided squares](https://leetcode.cn/link/?target=http%3A%2F%2Fint-e.eu%2F~bf3%2Fsquares%2Fproofs.html)」，已有如下结论：

-   $h(n,m) \le \max(n, m)$；
-   $h(n + m,m) = 1 + h(n, m) \quad if ~~ 1 \le m \le 4$；
-   $h(n+m,m) = 1 + h(n,m) \quad if ~~ 3n \geq m^2$；

详细证明过程参考相关学术论文即可，在此不再描述。

根据参考资料可以知道，实际该问题可以参考已有的计算结果与代码如下：

-   「[可视化数据](https://leetcode.cn/link/?target=http%3A%2F%2Fint-e.eu%2F~bf3%2Fsquares%2Fview.html%2313%2C11)」
-   「[参考代码](https://leetcode.cn/link/?target=http%3A%2F%2Fint-e.eu%2F~bf3%2Fsquares%2Fyoung.cc)」

**思路与算法**

由于本题为 $NP-Complete$ 问题，没有类似于动态规划的递推公式。具体到本题给定的 $n,m$ 的取值范围为 $1 \le n \le 13, 1 \le m \le 13$，因此我们可以采用暴力搜索的方法，依次尝试在空余的格子中铺设正方形，尝试遍历所有可能铺设方法，找到最少的正方形的数目即可。我们用二维矩阵 $rect[n][m]$ 来表示当前长方形中每个点被覆盖的情况，具体搜索过程如下：

-   初始时，由于长方形的每个点均未被覆盖，矩阵中每个单元格的状态均设置为 $false$；
-   从位置 $(0,0)$ 开始依次尝试用正方形来覆盖部分区域，如果当前位置 $(x, y)$ 已经覆盖，则尝试下一个位置 $(x, y + 1)$。每次尝试从 $(x, y)$ 进行正方形覆盖，假设当前覆盖的正方形的左上顶点为 $(x,y)$，正方形的长度为 $k$，则过程如下：
    -   由于当前覆盖的正方形不能超越长方形区域的边界，此时 $k$ 的取值范围为 $1 \le k < \min(n - x, m - y)$，为了减枝，$k$ 的取值依次从大到小进行尝试。
    -   同时需要检测该正方形区域内是否已被其它正方形覆盖过，即检测该区域中是否存在 $rect[i][j] = true$，此时 $i,j$ 的取值范围 $x \le i < x + k, y \le j < y + k$，如果可以填充则对该正方形区域进行填充，并移动到下一个位置 $(x, y + k)$ 继续尝试搜索；
-   当前如果已经将该矩形进行完全覆盖完成，记录当前最小值并返回。在搜索时同时对当前已经覆盖的正方形进行计数，如果当前计数 $cnt$ 大于等于当前的最小值 $ans$ 时，说明当前的覆盖方法已经不是最优解则直接返回。

**代码**

```cpp
class Solution {
public:
    int ans;
    int tilingRectangle(int n, int m) {
        ans = max(n, m);
        vector<vector<bool>> rect(n, vector<bool>(m, false));
        dfs(0, 0, rect, 0);
        return ans;
    }

    void dfs(int x, int y, vector<vector<bool>> &rect, int cnt) {
        int n = rect.size(), m = rect[0].size();
        if (cnt >= ans) {
            return;
        }        
        if (x >= n) {
            ans = cnt; 
            return;
        }
        /* 检测下一行 */        
        if (y >= m) {
            dfs(x + 1, 0, rect, cnt); 
            return;
        }        
        /* 如当前已经被覆盖，则直接尝试下一个位置 */
        if (rect[x][y]) {
            dfs(x, y + 1, rect, cnt);
            return;
        }
    
        for (int k = min(n - x, m - y); k >= 1 && isAvailable(rect, x, y, k); k--) {
            /* 将长度为 k 的正方形区域标记覆盖 */
            fillUp(rect, x, y, k, true);
            /* 跳过 k 个位置开始检测 */
            dfs(x, y + k, rect, cnt + 1);
            fillUp(rect, x, y, k, false);
        }
    }

    bool isAvailable(vector<vector<bool>> &rect, int x, int y, int k) {
        for (int i = 0; i < k; i++) {
            if (accumulate(rect[x + i].begin() + y, rect[x + i].begin() + y + k, false, bit_or())) {
                return false;
            }
        }
        return true;
    }

    void fillUp(vector<vector<bool>> &rect, int x, int y, int k, bool val) {
        for (int i = 0; i < k; i++){
            fill(rect[x + i].begin() + y, rect[x + i].begin() + y + k, val);
        }
    }
};
```

```java
class Solution {
    int ans;

    public int tilingRectangle(int n, int m) {
        ans = Math.max(n, m);
        boolean[][] rect = new boolean[n][m];
        dfs(0, 0, rect, 0);
        return ans;
    }

    public void dfs(int x, int y, boolean[][] rect, int cnt) {
        int n = rect.length, m = rect[0].length;
        if (cnt >= ans) {
            return;
        }        
        if (x >= n) {
            ans = cnt; 
            return;
        }
        /* 检测下一行 */        
        if (y >= m) {
            dfs(x + 1, 0, rect, cnt); 
            return;
        }        
        /* 如当前已经被覆盖，则直接尝试下一个位置 */
        if (rect[x][y]) {
            dfs(x, y + 1, rect, cnt);
            return;
        }
    
        for (int k = Math.min(n - x, m - y); k >= 1 && isAvailable(rect, x, y, k); k--) {
            /* 将长度为 k 的正方形区域标记覆盖 */
            fillUp(rect, x, y, k, true);
            /* 跳过 k 个位置开始检测 */
            dfs(x, y + k, rect, cnt + 1);
            fillUp(rect, x, y, k, false);
        }
    }

    public boolean isAvailable(boolean[][] rect, int x, int y, int k) {
        for (int i = 0; i < k; i++) {
            for (int j = 0; j < k; j++) {
                if (rect[x + i][y + j]) {
                    return false;
                }
            }
        }
        return true;
    }

    public void fillUp(boolean[][] rect, int x, int y, int k, boolean val) {
        for (int i = 0; i < k; i++){
            for (int j = 0; j < k; j++) {
                rect[x + i][y + j] = val;
            }
        }
    }
}
```

```csharp
public class Solution {
    int ans;

    public int TilingRectangle(int n, int m) {
        ans = Math.Max(n, m);
        bool[][] rect = new bool[n][];
        for (int i = 0; i < n; i++) {
            rect[i] = new bool[m];
        }
        DFS(0, 0, rect, 0);
        return ans;
    }

    public void DFS(int x, int y, bool[][] rect, int cnt) {
        int n = rect.Length, m = rect[0].Length;
        if (cnt >= ans) {
            return;
        }        
        if (x >= n) {
            ans = cnt; 
            return;
        }
        /* 检测下一行 */        
        if (y >= m) {
            DFS(x + 1, 0, rect, cnt); 
            return;
        }        
        /* 如当前已经被覆盖，则直接尝试下一个位置 */
        if (rect[x][y]) {
            DFS(x, y + 1, rect, cnt);
            return;
        }
    
        for (int k = Math.Min(n - x, m - y); k >= 1 && IsAvailable(rect, x, y, k); k--) {
            /* 将长度为 k 的正方形区域标记覆盖 */
            FillUp(rect, x, y, k, true);
            /* 跳过 k 个位置开始检测 */
            DFS(x, y + k, rect, cnt + 1);
            FillUp(rect, x, y, k, false);
        }
    }

    public bool IsAvailable(bool[][] rect, int x, int y, int k) {
        for (int i = 0; i < k; i++) {
            for (int j = 0; j < k; j++) {
                if (rect[x + i][y + j]) {
                    return false;
                }
            }
        }
        return true;
    }

    public void FillUp(bool[][] rect, int x, int y, int k, bool val) {
        for (int i = 0; i < k; i++){
            for (int j = 0; j < k; j++) {
                rect[x + i][y + j] = val;
            }
        }
    }
}
```

```go
func min(a, b int) int {
    if a < b {
        return a
    }
    return b
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}

func tilingRectangle(n int, m int) int {
    ans := max(n, m)
    rect := make([][]bool, n)
    for i := 0; i < n; i++ {
        rect[i] = make([]bool, m)
    }

    isAvailable := func(x, y, k int) bool {
        for i := 0; i < k; i++ {
            for j := 0; j < k; j++ {
                if rect[x + i][y + j] {
                    return false
                }
            }
        }
        return true
    }

    fillUp := func(x, y, k int, val bool) {
        for i := 0; i < k; i++ {
            for j := 0; j < k; j++ {
                rect[x + i][y + j] = val
            }
        }
    }

    var dfs func(int, int, int)
    dfs = func(x, y, cnt int) {
        if cnt >= ans {
            return
        }
        if x >= n {
            ans = cnt
            return
        }
        // 检测下一行
        if y >= m {
            dfs(x + 1, 0, cnt)
            return
        }
        // 如当前已经被覆盖，则直接尝试下一个位置
        if rect[x][y] {
            dfs(x, y + 1, cnt)
            return
        }
        for k := min(n - x, m - y); k >= 1 && isAvailable(x, y, k); k-- {
            // 将长度为 k 的正方形区域标记覆盖
            fillUp(x, y, k, true)
            // 跳过 k 个位置开始检测
            dfs(x, y + k, cnt + 1)
            fillUp(x, y, k, false)
        }
    }

    dfs(0, 0, 0)
    return ans
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))
#define MIN(a, b) ((a) < (b) ? (a) : (b))

bool isAvailable(const bool **rect, int x, int y, int k) {
    for (int i = 0; i < k; i++) {
        for (int j = 0; j < k; j++) {
            if (rect[x + i][y + j]) {
                return false;
            }
        }
    }
    return true;
}

void fillUp(bool **rect, int x, int y, int k, bool val) {
    for (int i = 0; i < k; i++){
        for (int j = 0; j < k; j++) {
            rect[x + i][y + j] = val;
        }
    }
}

void dfs(int x, int y, bool **rect, int n, int m, int cnt, int *ans) {
    if (cnt >= *ans) {
        return;
    }        
    if (x >= n) {
        *ans = cnt; 
        return;
    }
    /* 检测下一行 */          
    if (y >= m) {
        dfs(x + 1, 0, rect, n, m, cnt, ans); 
        return;
    }        
    /* 如当前已经被覆盖，则直接尝试下一个位置 */
    if (rect[x][y]) {
        dfs(x, y + 1, rect, n, m, cnt, ans);
        return;
    }

    for (int k = MIN(n - x, m - y); k >= 1 && isAvailable(rect, x, y, k); k--) {
        /* 将长度为 k 的正方形区域标记覆盖 */
        fillUp(rect, x, y, k, true);
        /* 跳过 k 个位置开始检测 */
        dfs(x, y + k, rect, n, m, cnt + 1, ans);
        fillUp(rect, x, y, k, false);
    }
}

int tilingRectangle(int n, int m) {
    int ans = MAX(n, m);
    bool *rect[n];
    for (int i = 0; i < n; i++) {
        rect[i] = (bool *)calloc(m, sizeof(bool));
    }
    dfs(0, 0, rect, n, m, 0, &ans);
    for (int i = 0; i < n; i++) {
        free(rect[i]);
    }
    return ans;
}
```

```javascript
var tilingRectangle = function(n, m) {
    let ans = Math.max(n, m);
    const rect = new Array(n).fill(0).map(() => new Array(m).fill(false));

    const dfs = (x, y, rect, cnt) => {
        const n = rect.length, m = rect[0].length;
        if (cnt >= ans) {
            return;
        }        
        if (x >= n) {
            ans = cnt; 
            return;
        }
        /* 检测下一行 */        
        if (y >= m) {
            dfs(x + 1, 0, rect, cnt); 
            return;
        }        
        /* 如当前已经被覆盖，则直接尝试下一个位置 */
        if (rect[x][y]) {
            dfs(x, y + 1, rect, cnt);
            return;
        }

        for (let k = Math.min(n - x, m - y); k >= 1 && isAvailable(rect, x, y, k); k--) {
            /* 将长度为 k 的正方形区域标记覆盖 */
            fillUp(rect, x, y, k, true);
            /* 跳过 k 个位置开始检测 */
            dfs(x, y + k, rect, cnt + 1);
            fillUp(rect, x, y, k, false);
        }
    }
    dfs(0, 0, rect, 0);
    return ans;
}



const isAvailable = (rect, x, y, k) => {
    for (let i = 0; i < k; i++) {
        for (let j = 0; j < k; j++) {
            if (rect[x + i][y + j]) {
                return false;
            }
        }
    }
    return true;
}

const fillUp = (rect, x, y, k, val) => {
    for (let i = 0; i < k; i++){
        for (let j = 0; j < k; j++) {
            rect[x + i][y + j] = val;
        }
    }
};
```

```python
class Solution:
    def tilingRectangle(self, n: int, m: int) -> int:
        def dfs(x: int, y: int, cnt: int) -> None:
            nonlocal ans
            if cnt >= ans:
                return
            if x >= n:
                ans = cnt
                return
            
            # 检测下一行
            if y >= m:
                dfs(x + 1, 0, cnt)
                return
            # 如当前已经被覆盖，则直接尝试下一个位置
            if rect[x][y]:
                dfs(x, y + 1, cnt)
                return
            
            k = min(n - x, m - y)
            while k >= 1 and isAvailable(x, y, k):
                fillUp(x, y, k, True)
                # 跳过 k 个位置开始检测
                dfs(x, y + k, cnt + 1)
                fillUp(x, y, k, False)
                k -= 1

        def isAvailable(x: int, y: int, k: int) -> bool:
            for i in range(k):
                for j in range(k):
                    if rect[x + i][y + j] == True:
                        return False
            return True
        
        def fillUp(x: int, y: int, k: int, val: bool) -> None:
            for i in range(k):
                for j in range(k):
                    rect[x + i][y + j] = val

        ans = max(n, m)
        rect = [[False] * m for _ in range(n)]
        dfs(0, 0, 0)
        return ans
```

**复杂度分析**

本题暂不分析时空复杂度。
