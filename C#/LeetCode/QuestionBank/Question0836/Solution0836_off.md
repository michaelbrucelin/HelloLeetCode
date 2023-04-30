#### [����һ�����λ��](https://leetcode.cn/problems/rectangle-overlap/solutions/154848/ju-xing-zhong-die-by-leetcode-solution/)

**˼·**

���ǳ��Է�����ʲô����£����� `rec1` �� `rec2` û���ص���

������� `rec1` �� `rec2` ��������һ�����ε����Ϊ $0$����һ��û���ص���

������ `rec1` �� `rec2` ����������� $0$ ʱ�����������ƽ���з���һ���̶��ľ��� `rec2`����ô���� `rec1` ����Ҫ������ `rec2` �ġ����ܡ���Ҳ����˵������ `rec1` ��Ҫ����������������е�����һ�֣�

-   ���� `rec1` �ھ��� `rec2` ����ࣻ
-   ���� `rec1` �ھ��� `rec2` ���Ҳࣻ
-   ���� `rec1` �ھ��� `rec2` ���Ϸ���
-   ���� `rec1` �ھ��� `rec2` ���·���

��Ϊ����ࡹ��������� `rec1` �ھ��� `rec2` ����࣬�Ǿͱ�ʾ���ǿ����ҵ�һ����ֱ���ߣ���������εı��غϣ���ʹ�þ��� `rec1` �� `rec2` �������������ߵ����ࡣ���ڡ��Ҳࡹ�����Ϸ����Լ����·��������ǵĶ����롸��ࡹ�����Ƶġ�

**�㷨**

�����жϾ��� `rec1` �� `rec2` ������Ƿ�Ϊ $0$��

-   ���ھ��� `rec1` ���ԣ������Ϊ $0$ ���ҽ��� `rec1[0] == rec1[2]` �� `rec1[1] == rec1[3]`��
-   ���ھ��� `rec2` ���ԣ������Ϊ $0$ ���ҽ��� `rec2[0] == rec2[2]` �� `rec2[1] == rec2[3]`��

���������һ�����ε����Ϊ $0$����һ��û���ص���

������� `rec1` �� `rec2` ����������� $0$�������������ε�λ�á����ǽ����������������ɴ��롣����أ������� `(rec[0], rec[1])` ��ʾ���ε����½ǣ�`(rec[2], rec[3])` ��ʾ���ε����Ͻǣ�����Ŀ����һ�¡����ڡ���ࡹ�������� `rec1` �� `x` ���ϵ����ֵ���ܴ��ھ��� `rec2` �� `x` ������Сֵ�����ڡ��Ҳࡹ�����Ϸ����Լ����·���ͬ��������ǿ��Է�������µĴ��룺

-   ��ࣺ`rec1[2] <= rec2[0]`��
-   �Ҳࣺ`rec1[0] >= rec2[2]`��
-   �Ϸ���`rec1[1] >= rec2[3]`��
-   �·���`rec1[3] <= rec2[1]`��

```java
class Solution {
    public boolean isRectangleOverlap(int[] rec1, int[] rec2) {
        if (rec1[0] == rec1[2] || rec1[1] == rec1[3] || rec2[0] == rec2[2] || rec2[1] == rec2[3]) {
            return false;
        }
        return !(rec1[2] <= rec2[0] ||   // left
                 rec1[3] <= rec2[1] ||   // bottom
                 rec1[0] >= rec2[2] ||   // right
                 rec1[1] >= rec2[3]);    // top
    }
}
```

```python
class Solution:
    def isRectangleOverlap(self, rec1: List[int], rec2: List[int]) -> bool:
        if rec1[0] == rec1[2] or rec1[1] == rec1[3] or rec2[0] == rec2[2] or rec2[1] == rec2[3]:
            return False
        return not (rec1[2] <= rec2[0] or  # left
                    rec1[3] <= rec2[1] or  # bottom
                    rec1[0] >= rec2[2] or  # right
                    rec1[1] >= rec2[3])    # top
```

```cpp
class Solution {
public:
    bool isRectangleOverlap(vector<int>& rec1, vector<int>& rec2) {
        if (rec1[0] == rec1[2] || rec1[1] == rec1[3] || rec2[0] == rec2[2] || rec2[1] == rec2[3]) {
            return false;
        }
        return !(rec1[2] <= rec2[0] ||   // left
                 rec1[3] <= rec2[1] ||   // bottom
                 rec1[0] >= rec2[2] ||   // right
                 rec1[1] >= rec2[3]);    // top
    }
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(1)$��
-   �ռ临�Ӷȣ�$O(1)$������Ҫ����Ŀռ䡣
