#### [��λ���� & ����������ֻ���ڼ��������ҵ�������](https://leetcode.cn/problems/check-if-the-sentence-is-pangram/solutions/729796/wei-yun-suan-zhi-shu-ji-shu-zhi-neng-zai-mu0c/)

ֱ��Set����Map����������ģ��̫���ˣ�����Ͳ�д�ˣ�д�˵�Ƚ�����˼�Ľⷨ��

1.  λ����

> ��ÿһ����ĸӳ�䵽һ��intֵ�Ķ�����λ�ϣ�������ʮ������ĸȫ��ʱ���״̬���Աȼ��ɡ�

```java
class Solution {
    public boolean checkIfPangram(String sentence) {
        int res = 0;
        for ( char c : sentence.toCharArray()) {
            res |= 1 << (c - 'a');
            if ((res ^ 0x3ffffff) == 0) {
                return true;
            }
        }
        return false;
    }
}
```

2.  ������

> �ö�ʮ����������ʾÿһ����ĸ����python��Ҫ��Ϊpython������û���ޡ�

```python
class Solution:
    def checkIfPangram(self, sentence: str) -> bool:
        arr = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
               31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
               73, 79, 83, 89, 97, 101]
        res = 1
        for c in sentence:
            if res % arr[ord(c) - 97] != 0:
                res *= arr[ord(c) - 97]
        if res == 232862364358497360900063316880507363070:
            return True
        return False
```
