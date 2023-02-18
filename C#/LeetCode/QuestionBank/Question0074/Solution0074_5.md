#### [���� BST �ⷨ](https://leetcode.cn/problems/search-a-2d-matrix/solutions/688573/gong-shui-san-xie-yi-ti-shuang-jie-er-fe-l0pq/)

���ǿ��Խ���ά�������ɡ������Ͻ�Ϊ���� BST����

![](./assets/img/Solution0074_5_01.png)

��ô���ǿ��ԴӸ������Ͻǣ���ʼ�����������ǰ�Ľڵ㲻����Ŀ��ֵ�����԰�����������˳����У�

1.  ��ǰ�ڵ㡸���ڡ�Ŀ��ֵ��������ǰ�ڵ�ġ�����������Ҳ���ǵ�ǰ����λ�õġ��󷽸��ӡ����� `y--`
2.  ��ǰ�ڵ㡸С�ڡ�Ŀ��ֵ��������ǰ�ڵ�ġ�����������Ҳ���ǵ�ǰ����λ�õġ��·����ӡ����� `x++`

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
        // ���Ͻǿ�ʼ����
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

-   ʱ�临�Ӷȣ�$O(m+n)$
-   �ռ临�Ӷȣ�$O(1)$
