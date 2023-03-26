#### [����һ��ö���Ƴ��±�](https://leetcode.cn/problems/remove-digit-from-number-to-maximize-result/solutions/1486072/yi-chu-zhi-ding-shu-zi-de-dao-de-zui-da-ikpqo/)

**˼·���㷨**

���ǿ��Ա��� $number$ Ѱ�����п����Ƴ����±ꡣͬʱ�������ַ��� $res$ ��¼���Եõ����������$res$ ��ʼΪ���ַ�����ÿ�������ҵ� $number[i] = digit$ ���±� $i$�����ǹ����Ƴ��±� $i$ ����ַ��� $tmp$�������Ƴ��±���ַ����ĳ���һ����ȣ����**�ֵ���Ĵ�С��ϵ���ڶ�Ӧ��ֵ�Ĵ�С��ϵ**��ͬʱ���ڿ��ַ������ֵ�����С���κηǿ��ַ���������ֻ��Ҫ�� $res$ ���� $res$ �� $tmp$ �Ľϴ�ֵ���ɡ����գ����Ƿ��� $res$ ��Ϊ�𰸡�

**����**

```cpp
class Solution {
public:
    string removeDigit(string number, char digit) {
        int n = number.size();
        string res;   // ���Եõ��������
        for (int i = 0; i < n; ++i) {
            if (number[i] == digit) {
                string tmp = number.substr(0, i);
                tmp.append(number.substr(i + 1, n - i));
                res = max(res, tmp);
            }
        }
        return res;
    }
};
```

```python
class Solution:
    def removeDigit(self, number: str, digit: str) -> str:
        n = len(number)
        res = ""   # ���Եõ��������
        for i in range(n):
            if number[i] == digit:
                tmp = number[:i] + number[i+1:]
                res = max(res, tmp)
        return res
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n^2)$������ $n$ Ϊ $number$ �ĳ��ȡ�����������Ҫ�Ƴ� $O(n)$ ���ַ�����ÿ�������Ƴ����ַ������Ƚϵ�ʱ�临�Ӷ�Ϊ $O(n)$��
-   �ռ临�Ӷȣ�$O(n)$����Ϊ�����Ƴ����ַ���ʱ�����ַ����Ŀռ俪����
