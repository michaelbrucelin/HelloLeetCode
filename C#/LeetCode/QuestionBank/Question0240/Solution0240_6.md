#### [抽象 BST](https://leetcode.cn/problems/search-a-2d-matrix-ii/solutions/1065178/gong-shui-san-xie-yi-ti-shuang-jie-er-fe-y1ns/)

该做法则与 [（题解）74. 搜索二维矩阵](https://leetcode-cn.com/problems/search-a-2d-matrix/solution/gong-shui-san-xie-yi-ti-shuang-jie-er-fe-l0pq/) 的「解法二」完全一致。

我们可以将二维矩阵抽象成「以右上角为根的 BST」：

![](./assets/img/Solution0240_6_01.png)

那么我们可以从根（右上角）开始搜索，如果当前的节点不等于目标值，可以按照树的搜索顺序进行：

1.  当前节点「大于」目标值，搜索当前节点的「左子树」，也就是当前矩阵位置的「左方格子」，即 `c--`
2.  当前节点「小于」目标值，搜索当前节点的「右子树」，也就是当前矩阵位置的「下方格子」，即 `r++`

代码：

```java
class Solution {
    public boolean searchMatrix(int[][] matrix, int target) {
        int m = matrix.length, n = matrix[0].length;
        int r = 0, c = n - 1;
        while (r < m && c >= 0) {
            if (matrix[r][c] < target) r++;
            else if (matrix[r][c] > target) c--;
            else return true;
        }
        return false;
    }
}
```

-   时间复杂度：$O(m + n)$
-   空间复杂度：$O(1)$
