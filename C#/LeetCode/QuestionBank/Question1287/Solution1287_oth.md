#### [�������������������](https://leetcode.cn/problems/element-appearing-more-than-25-in-sorted-array/solutions/71711/li-yong-you-xu-shu-zu-te-xing-qiu-jie-by-user8300r/)

#### ����˼·

1.  ��� 25% ��Ӧ�ĳ��ִ���threshold
2.  ��������
3.  �������������飬ֻ��Ƚ� ��ǰλ�� i ֵ�� i + threshold��ֵ�Ƿ���ȼ���

#### ����

```cpp
class Solution {
    public int findSpecialInteger(int[] arr) {
        int threshold = arr.length / 4;
        for (int i = 0; i < arr.length; i++) {
            if (arr[i + threshold] == arr[i]) {
                return arr[i];
            }
        }
        return 0;
    }
}
```
