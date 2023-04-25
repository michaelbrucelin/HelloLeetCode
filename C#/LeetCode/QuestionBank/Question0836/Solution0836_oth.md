#### [ͼ�⣺�������ص�����ת��Ϊ�����ص����⣨C++/Java/Python��](https://leetcode.cn/problems/rectangle-overlap/solutions/155825/tu-jie-jiang-ju-xing-zhong-die-wen-ti-zhuan-hua-we/)

�����ص�Ҫ���ǵ�����ܶ࣬�������ε��ص������кö��ֲ�ͬ����̬�������������������Ļ�����������©��ĳЩ��������³���

�����ص��Ƕ�ά�����⣬��������ܶ࣬�Ƚϸ��ӡ�Ϊ�˼����⣬���ǿ��Կ��ǽ���ά����ת��Ϊһά���⡣��Ȼ��Ŀ�еľ��ζ���ƽ����������ģ����ǽ�����ͶӰ���������ϣ�

![](./assets/img/Solution0836_oth_01.jpg)

����ͶӰ���������ϣ��ͱ����**����**���Լ�˼�������Ƿ��֣�**���������ص��ľ��Σ������� xxx ��� yyy ����ͶӰ��������Ҳ�ǻ����ص���**�����������Ǿͽ������ص�����ת�����������ص����⡣

�����ص���һά�����⣬�ȶ�ά����򵥺ܶࡣ���ǿ�����ٳ������������п��ܵ� 6 �ֹ�ϵ��

![](./assets/img/Solution0836_oth_02.jpg)

���Կ���������� 6 �ֹ�ϵ�У����ص�ֻ������������жϲ��ص����򵥡�������������ֱ��� `[s1, e1]` �� `[s2, e2]` �Ļ������䲻�ص�������������� `e1 <= s2` �� `e2 <= s1`��

![](./assets/img/Solution0836_oth_03.jpg)

���Ǿ͵õ����䲻�ص���������`e1 <= s2 || e2 <= s1`��������ȡ����Ϊ�����ص���������

���������ǾͿ���д���жϾ����ص��Ĵ����ˣ�

```cpp
bool isRectangleOverlap(vector<int>& rec1, vector<int>& rec2) {
    bool x_overlap = !(rec1[2] <= rec2[0] || rec2[2] <= rec1[0]);
    bool y_overlap = !(rec1[3] <= rec2[1] || rec2[3] <= rec1[1]);
    return x_overlap && y_overlap;
}
```

```java
public boolean isRectangleOverlap(int[] rec1, int[] rec2) {
    boolean x_overlap = !(rec1[2] <= rec2[0] || rec2[2] <= rec1[0]);
    boolean y_overlap = !(rec1[3] <= rec2[1] || rec2[3] <= rec1[1]);
    return x_overlap && y_overlap;
}
```

```python
def isRectangleOverlap(self, rec1: List[int], rec2: List[int]) -> bool:
    x_overlap = not(rec1[2] <= rec2[0] or rec2[2] <= rec1[0])
    y_overlap = not(rec1[3] <= rec2[1] or rec2[3] <= rec1[1])
    return x_overlap and y_overlap
```
