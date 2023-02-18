#### [���� BST](https://leetcode.cn/problems/search-a-2d-matrix-ii/solutions/1065178/gong-shui-san-xie-yi-ti-shuang-jie-er-fe-y1ns/)

���������� [����⣩74. ������ά����](https://leetcode-cn.com/problems/search-a-2d-matrix/solution/gong-shui-san-xie-yi-ti-shuang-jie-er-fe-l0pq/) �ġ��ⷨ������ȫһ�¡�

���ǿ��Խ���ά�������ɡ������Ͻ�Ϊ���� BST����

![](./assets/img/Solution0240_6_01.png)

��ô���ǿ��ԴӸ������Ͻǣ���ʼ�����������ǰ�Ľڵ㲻����Ŀ��ֵ�����԰�����������˳����У�

1.  ��ǰ�ڵ㡸���ڡ�Ŀ��ֵ��������ǰ�ڵ�ġ�����������Ҳ���ǵ�ǰ����λ�õġ��󷽸��ӡ����� `c--`
2.  ��ǰ�ڵ㡸С�ڡ�Ŀ��ֵ��������ǰ�ڵ�ġ�����������Ҳ���ǵ�ǰ����λ�õġ��·����ӡ����� `r++`

���룺

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

-   ʱ�临�Ӷȣ�$O(m + n)$
-   �ռ临�Ӷȣ�$O(1)$
