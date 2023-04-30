#### [前言](https://leetcode.cn/problems/flood-fill/solutions/375836/tu-xiang-xuan-ran-by-leetcode-solution/)

本题要求将给定的二维数组中指定的「色块」染成另一种颜色。「色块」的定义是：直接或间接相邻的同色方格构成的整体。

可以发现，「色块」就是被不同颜色的方格包围的一个同色岛屿。我们从色块中任意一个地方开始，利用广度优先搜索或深度优先搜索即可遍历整个岛屿。

注意：当目标颜色和初始颜色相同时，我们无需对原数组进行修改。

#### [方法一：广度优先搜索](https://leetcode.cn/problems/flood-fill/solutions/375836/tu-xiang-xuan-ran-by-leetcode-solution/)

**思路及算法**

我们从给定的起点开始，进行广度优先搜索。每次搜索到一个方格时，如果其与初始位置的方格颜色相同，就将该方格加入队列，并将该方格的颜色更新，以防止重复入队。

注意：因为初始位置的颜色会被修改，所以我们需要保存初始位置的颜色，以便于之后的更新操作。

**代码**

```cpp
class Solution {
public:
    const int dx[4] = {1, 0, 0, -1};
    const int dy[4] = {0, 1, -1, 0};
    vector<vector<int>> floodFill(vector<vector<int>>& image, int sr, int sc, int color) {
        int currColor = image[sr][sc];
        if (currColor == color) {
            return image;
        }
        int n = image.size(), m = image[0].size();
        queue<pair<int, int>> que;
        que.emplace(sr, sc);
        image[sr][sc] = color;
        while (!que.empty()) {
            int x = que.front().first, y = que.front().second;
            que.pop();
            for (int i = 0; i < 4; i++) {
                int mx = x + dx[i], my = y + dy[i];
                if (mx >= 0 && mx < n && my >= 0 && my < m && image[mx][my] == currColor) {
                    que.emplace(mx, my);
                    image[mx][my] = color;
                }
            }
        }
        return image;
    }
};
```

```java
class Solution {
    int[] dx = {1, 0, 0, -1};
    int[] dy = {0, 1, -1, 0};

    public int[][] floodFill(int[][] image, int sr, int sc, int color) {
        int currColor = image[sr][sc];
        if (currColor == color) {
            return image;
        }
        int n = image.length, m = image[0].length;
        Queue<int[]> queue = new LinkedList<int[]>();
        queue.offer(new int[]{sr, sc});
        image[sr][sc] = color;
        while (!queue.isEmpty()) {
            int[] cell = queue.poll();
            int x = cell[0], y = cell[1];
            for (int i = 0; i < 4; i++) {
                int mx = x + dx[i], my = y + dy[i];
                if (mx >= 0 && mx < n && my >= 0 && my < m && image[mx][my] == currColor) {
                    queue.offer(new int[]{mx, my});
                    image[mx][my] = color;
                }
            }
        }
        return image;
    }
}
```

```python
class Solution:
    def floodFill(self, image: List[List[int]], sr: int, sc: int, color: int) -> List[List[int]]:
        currColor = image[sr][sc]
        if currColor == color:
            return image
        
        n, m = len(image), len(image[0])
        que = collections.deque([(sr, sc)])
        image[sr][sc] = color
        while que:
            x, y = que.popleft()
            for mx, my in [(x - 1, y), (x + 1, y), (x, y - 1), (x, y + 1)]:
                if 0 <= mx < n and 0 <= my < m and image[mx][my] == currColor:
                    que.append((mx, my))
                    image[mx][my] = color
        
        return image
```

```c
const int dx[4] = {1, 0, 0, -1};
const int dy[4] = {0, 1, -1, 0};

int** floodFill(int** image, int imageSize, int* imageColSize, int sr, int sc, int color, int* returnSize, int** returnColumnSizes) {
    int n = imageSize, m = imageColSize[0];
    *returnSize = n;
    for (int i = 0; i < n; i++) {
        (*returnColumnSizes)[i] = m;
    }
    int currColor = image[sr][sc];
    if (currColor == color) {
        return image;
    }
    int que[n * m][2];
    int l = 0, r = 0;
    que[r][0] = sr, que[r++][1] = sc;
    image[sr][sc] = color;
    while (l < r) {
        int x = que[l][0], y = que[l++][1];
        for (int i = 0; i < 4; i++) {
            int mx = x + dx[i], my = y + dy[i];
            if (mx >= 0 && mx < n && my >= 0 && my < m && image[mx][my] == currColor) {
                que[r][0] = mx, que[r++][1] = my;
                image[mx][my] = color;
            }
        }
    }
    return image;
}
```

```go
var (
    dx = []int{1, 0, 0, -1}
    dy = []int{0, 1, -1, 0}
)

func floodFill(image [][]int, sr int, sc int, color int) [][]int {
    currColor := image[sr][sc]
    if currColor == color {
        return image
    }
    n, m := len(image), len(image[0])
    queue := [][]int{}
    queue = append(queue, []int{sr, sc})
    image[sr][sc] = color
    for i := 0; i < len(queue); i++ {
        cell := queue[i]
        for j := 0; j < 4; j++ {
            mx, my := cell[0] + dx[j], cell[1] + dy[j]
            if mx >= 0 && mx < n && my >= 0 && my < m && image[mx][my] == currColor {
                queue = append(queue, []int{mx, my})
                image[mx][my] = color
            }
        }
    }
    return image
}
```

**复杂度分析**

-   时间复杂度：$O(n \times m)$，其中 $n$ 和 $m$ 分别是二维数组的行数和列数。最坏情况下需要遍历所有的方格一次。
-   空间复杂度：$O(n \times m)$，其中 $n$ 和 $m$ 分别是二维数组的行数和列数。主要为队列的开销。
