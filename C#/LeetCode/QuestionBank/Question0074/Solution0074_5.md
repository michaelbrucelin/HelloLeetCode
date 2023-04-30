#### [抽象 BST 解法](https://leetcode.cn/problems/search-a-2d-matrix/solutions/688573/gong-shui-san-xie-yi-ti-shuang-jie-er-fe-l0pq/)

我们可以将二维矩阵抽象成「以右上角为根的 BST」：

![](./assets/img/Solution0074_5_01.png)

那么我们可以从根（右上角）开始搜索，如果当前的节点不等于目标值，可以按照树的搜索顺序进行：

1.  当前节点「大于」目标值，搜索当前节点的「左子树」，也就是当前矩阵位置的「左方格子」，即 `y--`
2.  当前节点「小于」目标值，搜索当前节点的「右子树」，也就是当前矩阵位置的「下方格子」，即 `x++`

```java
class Solution {
    int m, n;
    public boolean searchMatrix(int[][] mat, int t) {
        m = mat.length; n = mat[0].length;
        int x = 0, y = n - 1;
        while (check(x, y) && mat[x][y] != t) {
            if (mat[x][y] > t) {
                y--;
            } else {
                x++;
            }
        }
        return check(x, y) && mat[x][y] == t;
    }
    boolean check(int x, int y) {
        return x >= 0 && x < m && y >= 0 && y < n;
    }
}
```

```python
class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        m, n = len(matrix), len(matrix[0])
        x,y = 0, n - 1
        while x < m and y >= 0:
            if matrix[x][y] > target:
                y -= 1
            elif matrix[x][y] < target:
                x += 1
            else:
                return True
        return False
```

```cpp
class Solution {
public:
    bool searchMatrix(vector<vector<int>>& matrix, int target) {
        int row = matrix.size(), col = matrix[0].size();
        // 右上角开始查找
        for(int i = 0, j = col-1; i < row && j >= 0;) {
            if(matrix[i][j] == target) 
                return true;
            else if(matrix[i][j] > target) 
                j--;
            else if(matrix[i][j] < target)
                i++;
        }
        return false;
    }
};
```

-   时间复杂度：$O(m+n)$
-   空间复杂度：$O(1)$
