#### [方法一：广度优先搜索](https://leetcode.cn/problems/minimum-moves-to-reach-target-with-rotations/solutions/2091767/chuan-guo-mi-gong-de-zui-shao-yi-dong-ci-pmnh/)

**思路与算法**

如果不考虑蛇的旋转，我们可以使用广度优先搜索的方法：即队列中存放蛇尾的坐标 $(x, y)$，每次从队列中取出一个坐标时，尝试向右移动一个单元格到 $(x, y+1)$，或向下移动一个单元格到 $(x+1, y)$。最后返回到 $(n−1, n−2)$ 最少需要的步数即可。

> 广度优先搜索方法的正确性在于：我们一定不会到达同一个位置两次及以上，因为这样必定不是最少的移动次数。

当考虑蛇的旋转时，我们可以有类似的结论。我们可以将蛇的状态本身与 $(x, y)$ 一起形成一个三元组 $(x,y,status)$。这样一来，我们一定不会到达同一个三元组两次及以上。其中 $status$ 的值为 $0/1$，$0$ 表示水平状态，$1$ 表示竖直状态。

因此，我们仍然可以使用广度优先搜索的方法解决本题。当 $status=0$ 时，需要考虑「向右移动」「向下移动」「顺时针旋转」三种情况；当 $status = 1$ 时，需要考虑「向右移动」「向下移动」「逆时针旋转」三种情况。读者可以自行思考每一种情况并编写代码，也可以参考下面的文字提示：

> 需要注意的是，$(x, y)$ 表示的是蛇尾坐标，这样的好处在于在进行旋转操作时，无需进行坐标的转换。

-   当 $status=0$ 时：
    -   「向右移动」：需要保证 $(x, y+2)$ 是空的单元格；
    -   「向下移动」：需要保证 $(x+1, y)$ 和 $(x+1, y)$ 均是空的单元格；
    -   「顺时针旋转」：需要保证 $(x+1, y)$ 和 $(x+1, y+1)$ 均是空的单元格。
-   当 $status = 1$ 时：
    -   「向右移动」：需要保证 $(x, y+1)$ 和 $(x+1, y+1)$ 均是空的单元格；
    -   「向下移动」：需要保证 $(x+2, y)$ 是空的单元格；
    -   「逆时针旋转」：需要保证 $(x, y+1)$ 和 $(x+1, y+1)$ 均是空的单元格。

**代码**

```cpp
class Solution {
public:
    int minimumMoves(vector<vector<int>>& grid) {
        int n = grid.size();
        vector<vector<array<int, 2>>> dist(n, vector<array<int, 2>>(n, {-1, -1}));
        dist[0][0][0] = 0;
        queue<tuple<int, int, int>> q;
        q.emplace(0, 0, 0);

        while (!q.empty()) {
            auto [x, y, status] = q.front();
            q.pop();
            if (status == 0) {
                // 向右移动一个单元格
                if (y + 2 < n && dist[x][y + 1][0] == -1 && grid[x][y + 2] == 0) {
                    dist[x][y + 1][0] = dist[x][y][0] + 1;
                    q.emplace(x, y + 1, 0);
                }
                // 向下移动一个单元格
                if (x + 1 < n && dist[x + 1][y][0] == -1 && grid[x + 1][y] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x + 1][y][0] = dist[x][y][0] + 1;
                    q.emplace(x + 1, y, 0);
                }
                // 顺时针旋转 90 度
                if (x + 1 < n && y + 1 < n && dist[x][y][1] == -1 && grid[x + 1][y] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x][y][1] = dist[x][y][0] + 1;
                    q.emplace(x, y, 1);
                }
            }
            else {
                // 向右移动一个单元格
                if (y + 1 < n && dist[x][y + 1][1] == -1 && grid[x][y + 1] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x][y + 1][1] = dist[x][y][1] + 1;
                    q.emplace(x, y + 1, 1);
                }
                // 向下移动一个单元格
                if (x + 2 < n && dist[x + 1][y][1] == -1 && grid[x + 2][y] == 0) {
                    dist[x + 1][y][1] = dist[x][y][1] + 1;
                    q.emplace(x + 1, y, 1);
                }
                // 逆时针旋转 90 度
                if (x + 1 < n && y + 1 < n && dist[x][y][0] == -1 && grid[x][y + 1] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x][y][0] = dist[x][y][1] + 1;
                    q.emplace(x, y, 0);
                }
            }
        }

        return dist[n - 1][n - 2][0];
    }
};
```

```java
class Solution {
    public int minimumMoves(int[][] grid) {
        int n = grid.length;
        int[][][] dist = new int[n][n][2];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Arrays.fill(dist[i][j], -1);
            }
        }
        dist[0][0][0] = 0;
        Queue<int[]> queue = new ArrayDeque<int[]>();
        queue.offer(new int[]{0, 0, 0});

        while (!queue.isEmpty()) {
            int[] arr = queue.poll();
            int x = arr[0], y = arr[1], status = arr[2];
            if (status == 0) {
                // 向右移动一个单元格
                if (y + 2 < n && dist[x][y + 1][0] == -1 && grid[x][y + 2] == 0) {
                    dist[x][y + 1][0] = dist[x][y][0] + 1;
                    queue.offer(new int[]{x, y + 1, 0});
                }
                // 向下移动一个单元格
                if (x + 1 < n && dist[x + 1][y][0] == -1 && grid[x + 1][y] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x + 1][y][0] = dist[x][y][0] + 1;
                    queue.offer(new int[]{x + 1, y, 0});
                }
                // 顺时针旋转 90 度
                if (x + 1 < n && y + 1 < n && dist[x][y][1] == -1 && grid[x + 1][y] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x][y][1] = dist[x][y][0] + 1;
                    queue.offer(new int[]{x, y, 1});
                }
            } else {
                // 向右移动一个单元格
                if (y + 1 < n && dist[x][y + 1][1] == -1 && grid[x][y + 1] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x][y + 1][1] = dist[x][y][1] + 1;
                    queue.offer(new int[]{x, y + 1, 1});
                }
                // 向下移动一个单元格
                if (x + 2 < n && dist[x + 1][y][1] == -1 && grid[x + 2][y] == 0) {
                    dist[x + 1][y][1] = dist[x][y][1] + 1;
                    queue.offer(new int[]{x + 1, y, 1});
                }
                // 逆时针旋转 90 度
                if (x + 1 < n && y + 1 < n && dist[x][y][0] == -1 && grid[x][y + 1] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x][y][0] = dist[x][y][1] + 1;
                    queue.offer(new int[]{x, y, 0});
                }
            }
        }

        return dist[n - 1][n - 2][0];
    }
}
```

```csharp
public class Solution {
    public int MinimumMoves(int[][] grid) {
        int n = grid.Length;
        int[][][] dist = new int[n][][];
        for (int i = 0; i < n; i++) {
            dist[i] = new int[n][];
            for (int j = 0; j < n; j++) {
                dist[i][j] = new int[2];
                Array.Fill(dist[i][j], -1);
            }
        }
        dist[0][0][0] = 0;
        Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
        queue.Enqueue(new Tuple<int, int, int>(0, 0, 0));

        while (queue.Count > 0) {
            Tuple<int, int, int> tuple = queue.Dequeue();
            int x = tuple.Item1, y = tuple.Item2, status = tuple.Item3;
            if (status == 0) {
                // 向右移动一个单元格
                if (y + 2 < n && dist[x][y + 1][0] == -1 && grid[x][y + 2] == 0) {
                    dist[x][y + 1][0] = dist[x][y][0] + 1;
                    queue.Enqueue(new Tuple<int, int, int>(x, y + 1, 0));
                }
                // 向下移动一个单元格
                if (x + 1 < n && dist[x + 1][y][0] == -1 && grid[x + 1][y] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x + 1][y][0] = dist[x][y][0] + 1;
                    queue.Enqueue(new Tuple<int, int, int>(x + 1, y, 0));
                }
                // 顺时针旋转 90 度
                if (x + 1 < n && y + 1 < n && dist[x][y][1] == -1 && grid[x + 1][y] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x][y][1] = dist[x][y][0] + 1;
                    queue.Enqueue(new Tuple<int, int, int>(x, y, 1));
                }
            } else {
                // 向右移动一个单元格
                if (y + 1 < n && dist[x][y + 1][1] == -1 && grid[x][y + 1] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x][y + 1][1] = dist[x][y][1] + 1;
                    queue.Enqueue(new Tuple<int, int, int>(x, y + 1, 1));
                }
                // 向下移动一个单元格
                if (x + 2 < n && dist[x + 1][y][1] == -1 && grid[x + 2][y] == 0) {
                    dist[x + 1][y][1] = dist[x][y][1] + 1;
                    queue.Enqueue(new Tuple<int, int, int>(x + 1, y, 1));
                }
                // 逆时针旋转 90 度
                if (x + 1 < n && y + 1 < n && dist[x][y][0] == -1 && grid[x][y + 1] == 0 && grid[x + 1][y + 1] == 0) {
                    dist[x][y][0] = dist[x][y][1] + 1;
                    queue.Enqueue(new Tuple<int, int, int>(x, y, 0));
                }
            }
        }

        return dist[n - 1][n - 2][0];
    }
}
```

```python
class Solution:
    def minimumMoves(self, grid: List[List[int]]) -> int:
        n = len(grid)
        dist = {(0, 0, 0): 0}
        q = deque([(0, 0, 0)])

        while q:
            x, y, status = q.popleft()
            if status == 0:
                # 向右移动一个单元格
                if y + 2 < n and (x, y + 1, 0) not in dist and grid[x][y + 2] == 0:
                    dist[(x, y + 1, 0)] = dist[(x, y, 0)] + 1
                    q.append((x, y + 1, 0))
                
                # 向下移动一个单元格
                if x + 1 < n and (x + 1, y, 0) not in dist and grid[x + 1][y] == grid[x + 1][y + 1] == 0:
                    dist[(x + 1, y, 0)] = dist[(x, y, 0)] + 1
                    q.append((x + 1, y, 0))
                
                # 顺时针旋转 90 度
                if x + 1 < n and y + 1 < n and (x, y, 1) not in dist and grid[x + 1][y] == grid[x + 1][y + 1] == 0:
                    dist[(x, y, 1)] = dist[(x, y, 0)] + 1
                    q.append((x, y, 1))
            else:
                # 向右移动一个单元格
                if y + 1 < n and (x, y + 1, 1) not in dist and grid[x][y + 1] == grid[x + 1][y + 1] == 0:
                    dist[(x, y + 1, 1)] = dist[(x, y, 1)] + 1
                    q.append((x, y + 1, 1))
                
                # 向下移动一个单元格
                if x + 2 < n and (x + 1, y, 1) not in dist and grid[x + 2][y] == 0:
                    dist[(x + 1, y, 1)] = dist[(x, y, 1)] + 1
                    q.append((x + 1, y, 1))
                
                # 逆时针旋转 90 度
                if x + 1 < n and y + 1 < n and (x, y, 0) not in dist and grid[x][y + 1] == grid[x + 1][y + 1] == 0:
                    dist[(x, y, 0)] = dist[(x, y, 1)] + 1
                    q.append((x, y, 0))

        return dist.get((n - 1, n - 2, 0), -1)
```

```javascript
var minimumMoves = function(grid) {
    const n = grid.length;
    const dist = new Array(n).fill(0).map(() => new Array(n).fill(0).map(() => new Array(2).fill(-1)));
    dist[0][0][0] = 0;
    const queue = [[0, 0, 0]];

    while (queue.length) {
        const arr = queue.shift();
        let x = arr[0], y = arr[1], status = arr[2];
        if (status === 0) {
            // 向右移动一个单元格
            if (y + 2 < n && dist[x][y + 1][0] === -1 && grid[x][y + 2] === 0) {
                dist[x][y + 1][0] = dist[x][y][0] + 1;
                queue.push([x, y + 1, 0]);
            }
            // 向下移动一个单元格
            if (x + 1 < n && dist[x + 1][y][0] === -1 && grid[x + 1][y] === 0 && grid[x + 1][y + 1] === 0) {
                dist[x + 1][y][0] = dist[x][y][0] + 1;
                queue.push([x + 1, y, 0]);
            }
            // 顺时针旋转 90 度
            if (x + 1 < n && y + 1 < n && dist[x][y][1] === -1 && grid[x + 1][y] === 0 && grid[x + 1][y + 1] === 0) {
                dist[x][y][1] = dist[x][y][0] + 1;
                queue.push([x, y, 1]);
            }
        } else {
            // 向右移动一个单元格
            if (y + 1 < n && dist[x][y + 1][1] === -1 && grid[x][y + 1] === 0 && grid[x + 1][y + 1] === 0) {
                dist[x][y + 1][1] = dist[x][y][1] + 1;
                queue.push([x, y + 1, 1]);
            }
            // 向下移动一个单元格
            if (x + 2 < n && dist[x + 1][y][1] === -1 && grid[x + 2][y] === 0) {
                dist[x + 1][y][1] = dist[x][y][1] + 1;
                queue.push([x + 1, y, 1]);
            }
            // 逆时针旋转 90 度
            if (x + 1 < n && y + 1 < n && dist[x][y][0] === -1 && grid[x][y + 1] === 0 && grid[x + 1][y + 1] === 0) {
                dist[x][y][0] = dist[x][y][1] + 1;
                queue.push([x, y, 0]);
            }
        }
    }

    return dist[n - 1][n - 2][0];
};
```

```go
func minimumMoves(grid [][]int) int {
    n := len(grid)
    dist := make([][][2]int, n)
    for i := range dist {
        dist[i] = make([][2]int, n)
        for j := range dist[i] {
            dist[i][j] = [2]int{-1, -1}
        }
    }
    dist[0][0][0] = 0
    queue := [][3]int{{0, 0, 0}}

    for len(queue) > 0 {
        arr := queue[0]
        queue = queue[1:]
        x := arr[0]
        y := arr[1]
        status := arr[2]
        if status == 0 {
            // 向右移动一个单元格
            if y+2 < n && dist[x][y+1][0] == -1 && grid[x][y+2] == 0 {
                dist[x][y+1][0] = dist[x][y][0] + 1
                queue = append(queue, [3]int{x, y + 1, 0})
            }
            // 向下移动一个单元格
            if x+1 < n && dist[x+1][y][0] == -1 && grid[x+1][y] == 0 && grid[x+1][y+1] == 0 {
                dist[x+1][y][0] = dist[x][y][0] + 1
                queue = append(queue, [3]int{x + 1, y, 0})
            }
            // 顺时针旋转 90 度
            if x+1 < n && y+1 < n && dist[x][y][1] == -1 && grid[x+1][y] == 0 && grid[x+1][y+1] == 0 {
                dist[x][y][1] = dist[x][y][0] + 1
                queue = append(queue, [3]int{x, y, 1})
            }
        } else {
            // 向右移动一个单元格
            if y+1 < n && dist[x][y+1][1] == -1 && grid[x][y+1] == 0 && grid[x+1][y+1] == 0 {
                dist[x][y+1][1] = dist[x][y][1] + 1
                queue = append(queue, [3]int{x, y + 1, 1})
            }
            // 向下移动一个单元格
            if x+2 < n && dist[x+1][y][1] == -1 && grid[x+2][y] == 0 {
                dist[x+1][y][1] = dist[x][y][1] + 1
                queue = append(queue, [3]int{x + 1, y, 1})
            }
            // 逆时针旋转 90 度
            if x+1 < n && y+1 < n && dist[x][y][0] == -1 && grid[x][y+1] == 0 && grid[x+1][y+1] == 0 {
                dist[x][y][0] = dist[x][y][1] + 1
                queue = append(queue, [3]int{x, y, 0})
            }
        }
    }

    return dist[n-1][n-2][0]
}
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，我们需要对整个网格进行一次广度优先搜索。
-   空间复杂度：$O(n^2)$，即为广度优先搜索中队列和存储距离的数组需要使用的空间。
