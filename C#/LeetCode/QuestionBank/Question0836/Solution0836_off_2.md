#### [���������������](https://leetcode.cn/problems/rectangle-overlap/solutions/154848/ju-xing-zhong-die-by-leetcode-solution/)

**˼·**

������������ص�����ô�����ص�������һ��Ҳ��һ�����Σ���ô����������������� $x$ ��ƽ�еıߣ�ˮƽ�ߣ�ͶӰ�� $x$ ����ʱ���н������� $y$ ��ƽ�еıߣ���ֱ�ߣ�ͶӰ�� $y$ ����ʱҲ���н�������ˣ����ǿ��Խ����⿴��һά�߶��Ƿ��н��������⡣

**�㷨**

���� `rec1` �� `rec2` ��ˮƽ��ͶӰ�� $x$ ���ϵ��߶ηֱ�Ϊ `(rec1[0], rec1[2])` �� `(rec2[0], rec2[2])`��������ѧ֪ʶ���ǿ���֪������ `min(rec1[2], rec2[2]) > max(rec1[0], rec2[0])` ʱ���������߶��н��������ھ��� `rec1` �� `rec2` ����ֱ��ͶӰ�� $y$ ���ϵ��߶Σ�ͬ����Եõ����� `min(rec1[3], rec2[3]) > max(rec1[1], rec2[1])` ʱ���������߶��н�����

```java
class Solution {
    public boolean isRectangleOverlap(int[] rec1, int[] rec2) {
        return (Math.min(rec1[2], rec2[2]) > Math.max(rec1[0], rec2[0]) &&
                Math.min(rec1[3], rec2[3]) > Math.max(rec1[1], rec2[1]));
    }
}
```

```python
class Solution:
    def isRectangleOverlap(self, rec1: List[int], rec2: List[int]) -> bool:
        def intersect(p_left, p_right, q_left, q_right):
            return min(p_right, q_right) > max(p_left, q_left)
        return (intersect(rec1[0], rec1[2], rec2[0], rec2[2]) and
                intersect(rec1[1], rec1[3], rec2[1], rec2[3]))
```

```cpp
class Solution {
public:
    bool isRectangleOverlap(vector<int>& rec1, vector<int>& rec2) {
        return (min(rec1[2], rec2[2]) > max(rec1[0], rec2[0]) &&
                min(rec1[3], rec2[3]) > max(rec1[1], rec2[1]));
    }
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(1)$��
-   �ռ临�Ӷȣ�$O(1)$������Ҫ����Ŀռ䡣
