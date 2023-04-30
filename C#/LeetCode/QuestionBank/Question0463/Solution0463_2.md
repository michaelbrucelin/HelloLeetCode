#### [����һ������](https://leetcode.cn/problems/island-perimeter/solutions/466248/dao-yu-de-zhou-chang-by-leetcode-solution/)

**˼·���㷨**

����һ��½�ظ��ӵ�ÿ���ߣ���������������ܳ����ҽ���������Ϊ����ı߽�������ڵ���һ������Ϊˮ�� ��ˣ����ǿ��Ա���ÿ��½�ظ��ӣ������ĸ������Ƿ�Ϊ�߽����ˮ������ǣ��������ߵĹ��ף��� $1$������� $ans$ �м��ɡ�

**����**

```cpp
class Solution {
    constexpr static int dx[4] = {0, 1, 0, -1};
    constexpr static int dy[4] = {1, 0, -1, 0};
public:
    int islandPerimeter(vector<vector<int>> &grid) {
        int n = grid.size(), m = grid[0].size();
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                if (grid[i][j]) {
                    int cnt = 0;
                    for (int k = 0; k < 4; ++k) {
                        int tx = i + dx[k];
                        int ty = j + dy[k];
                        if (tx < 0 || tx >= n || ty < 0 || ty >= m || !grid[tx][ty]) {
                            cnt += 1;
                        }
                    }
                    ans += cnt;
                }
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    static int[] dx = {0, 1, 0, -1};
    static int[] dy = {1, 0, -1, 0};

    public int islandPerimeter(int[][] grid) {
        int n = grid.length, m = grid[0].length;
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                if (grid[i][j] == 1) {
                    int cnt = 0;
                    for (int k = 0; k < 4; ++k) {
                        int tx = i + dx[k];
                        int ty = j + dy[k];
                        if (tx < 0 || tx >= n || ty < 0 || ty >= m || grid[tx][ty] == 0) {
                            cnt += 1;
                        }
                    }
                    ans += cnt;
                }
            }
        }
        return ans;
    }
}
```

```javascript
var islandPerimeter = function (grid) {
    const dx = [0, 1, 0, -1];
    const dy = [1, 0, -1, 0];
    const n = grid.length, m = grid[0].length;
    let ans = 0;
    for (let i = 0; i < n; ++i) {
        for (let j = 0; j < m; ++j) {
            if (grid[i][j]) {
                let cnt = 0;
                for (let k = 0; k < 4; ++k) {
                    let tx = i + dx[k];
                    let ty = j + dy[k];
                    if (tx < 0 || tx >= n || ty < 0 || ty >= m || !grid[tx][ty]) {
                        cnt += 1;
                    }
                }
                ans += cnt;
            }
        }
    }
    return ans;
};
```

```go
type pair struct{ x, y int }
var dir4 = []pair{{-1, 0}, {1, 0}, {0, -1}, {0, 1}}

func islandPerimeter(grid [][]int) (ans int) {
    n, m := len(grid), len(grid[0])
    for i, row := range grid {
        for j, v := range row {
            if v == 1 {
                for _, d := range dir4 {
                    if x, y := i+d.x, j+d.y; x < 0 || x >= n || y < 0 || y >= m || grid[x][y] == 0 {
                        ans++
                    }
                }
            }
        }
    }
    return
}
```

```c
const int dx[4] = {0, 1, 0, -1};
const int dy[4] = {1, 0, -1, 0};

int islandPerimeter(int** grid, int gridSize, int* gridColSize) {
    int n = gridSize, m = gridColSize[0];
    int ans = 0;
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < m; ++j) {
            if (grid[i][j]) {
                int cnt = 0;
                for (int k = 0; k < 4; ++k) {
                    int tx = i + dx[k];
                    int ty = j + dy[k];
                    if (tx < 0 || tx >= n || ty < 0 || ty >= m || !grid[tx][ty]) {
                        cnt += 1;
                    }
                }
                ans += cnt;
            }
        }
    }
    return ans;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(nm)$������ $n$ Ϊ����ĸ߶ȣ�$m$ Ϊ����Ŀ�ȡ�������Ҫ����ÿ�����ӣ�ÿ������Ҫ������Χ $4$ �������Ƿ�Ϊ���죬�����ʱ�临�Ӷ�Ϊ $O(4nm)=O(nm)$��
-   �ռ临�Ӷȣ�$O(1)$��ֻ��Ҫ�����ռ������ɱ�����
