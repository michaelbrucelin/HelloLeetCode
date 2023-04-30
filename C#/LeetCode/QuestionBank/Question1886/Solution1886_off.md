#### [����һ��ģ����ת����](https://leetcode.cn/problems/determine-whether-matrix-can-be-obtained-by-rotation/solutions/815371/pan-duan-ju-zhen-jing-lun-zhuan-hou-shi-qa9d0/)

**��ʾ $1$**

��һ������ $90$ ��˳ʱ����ת $4$ �Σ���ת��ľ����뱾��һ�¡�

**˼·���㷨**

���� **��ʾ $1$**�����ǿ���ģ�� $4$ �ν� $mat$ $90$ ��˳ʱ����ת�Ĳ���������ÿ����ת�������� $target$ �Ƚϡ�

������ת���������Խ�����������ʵ�֣�Ҳ����ԭ����ת����ͬ�����ľ���ϸ��������Ƶ����߿��Բο�[��48. ��תͼ�񡹵����](https://leetcode-cn.com/problems/rotate-image/solution/xuan-zhuan-tu-xiang-by-leetcode-solution-vu3m/)��

�����У����ǲ���ԭ����ת�ķ�ʽ����������������е� **������**��ʵ����ת������

**����**

```cpp
class Solution {
public:
    int temp;
    bool flag;

    bool findRotation(vector<vector<int>>& mat, vector<vector<int>>& target) {
        int n = mat.size();
        // �����ת 4 ��
        for (int k = 0; k < 4; ++k) {
            // ��ת����
            for (int i = 0; i < n / 2; ++i) {
                for (int j = 0; j < (n + 1) / 2; ++j) {
                    temp = mat[i][j];
                    mat[i][j] = mat[n-1-j][i];
                    mat[n-1-j][i] = mat[n-1-i][n-1-j];
                    mat[n-1-i][n-1-j] = mat[j][n-1-i];
                    mat[j][n-1-i] = temp;
                }
            }
            
            if (mat == target) {
                return true;
            }
        }
        return false;    
    }
};
```

```python
class Solution:
    def findRotation(self, mat: List[List[int]], target: List[List[int]]) -> bool:
        n = len(mat)
        # �����ת 4 ��
        for k in range(4):
            # ��ת����
            for i in range(n // 2):
                for j in range((n + 1) // 2):
                    mat[i][j], mat[n-1-j][i], mat[n-1-i][n-1-j], mat[j][n-1-i] \
                        = mat[n-1-j][i], mat[n-1-i][n-1-j], mat[j][n-1-i], mat[i][j]
            
            if mat == target:
                return True
        return False
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n^2)$������ $n$ Ϊ $mat$ �ı߳������������� $4$ ����ת��Ƚϲ�����ÿ����ת������ʱ�临�Ӷ�Ϊ $O(n^2)$��ÿ�αȽϲ�����ʱ�临�Ӷ�Ϊ $O(n^2)$��
-   �ռ临�Ӷȣ�$O(1)$��
