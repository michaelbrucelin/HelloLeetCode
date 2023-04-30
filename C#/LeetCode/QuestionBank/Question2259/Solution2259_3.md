#### [��������̰��](https://leetcode.cn/problems/remove-digit-from-number-to-maximize-result/solutions/1486072/yi-chu-zhi-ding-shu-zi-de-dao-de-zui-da-ikpqo/)

**��ʾ $1$**

�������²����Ƴ����ֿ���ʹ�����ս�����

1.  ���Ǵ������ұ��� $number$����������� $number[i] = digit$���� $number[i] < number[i + 1]$��������ڣ���ͬ����������ɾ�����ַ���õ��Ľ�����
    
2.  �������������ɲ�����������һ���������±꣬������ɾ�� $digit$ ���ֵ����һ���±꣬��ʱɾ�����ַ���õ��Ľ�����
    

**��ʾ $1$ ����**

���ǿ��������� $2$ �õ����� $num$ ��Ϊ��׼�����������������ܵõ��Ľ�����бȽϡ�

���ȣ�����Ƴ���λ�� $i$ ����ǰ���Ƴ���Ľ���� $num$ ֮���**����ֵ**һ�����ߡ�

��Σ����Ǹ��� $number[i]$ �� $number[i + 1]$ �Ĵ�С��ϵ�������ۣ�

-   $number[i] < number[i + 1]$����ʱɾ����Ľ��һ������ $num$����**����ɾ����������λ�õõ��Ľ��**��
-   $number[i] = number[i + 1]$����ʱɾ�� $number[i]$ ��ɾ�� $number[i + 1]$ �õ��Ľ����ͬ��
-   $number[i] > number[i + 1]$����ʱɾ����Ľ��һ��С�� $num$��������ǲ���ɾ����Ԫ�ء�

���ϣ�**��ʾ $1$** �еķ���һ������ʹ�����ս�����

**˼·���㷨**

���ǿ��Ը��� **��ʾ $1$** �ҵ���ѵ�ɾ���±ꡣ

����أ����Ǵ������ұ��� Ϊ $number$������ $last$ ��¼����������Ŀ���ɾ�����±ꡣ��������� $number[i] = digit$ʱ�����ǽ� $last$ ����Ϊ $i$����������� $number[i] < number[i + 1]$�������Ƿ���ɾ�����ַ��õ��Ľ����Ϊ�𰸡�

���������ɺ���δ�ҵ���������Ҫ����±꣬������ɾ�� $last$ �±��Ӧ���ַ������ء�

**����**

```cpp
class Solution {
public:
    string removeDigit(string number, char digit) {
        int n = number.size();
        int last = -1;   // ���һ����ɾ�����±�
        for (int i = 0; i < n; ++i) {
            if (number[i] == digit) {
                last = i;
                if (number[i] < number[i+1]){
                    string res = number.substr(0, i);
                res.append(number.substr(i + 1, n - i));
                return res;
                }
            }
        }
        string res = number.substr(0, last);
        res.append(number.substr(last + 1, n - last));
        return res;
    }
};
```

```python
class Solution:
    def removeDigit(self, number: str, digit: str) -> str:
        n = len(number)
        last = -1   # ���һ����ɾ�����±�
        for i in range(n):
            if number[i] == digit:
                last = i
                if i < n - 1 and number[i] < number[i+1]:
                    return number[:i] + number[i+1:]
        return number[:last] + number[last+1:]
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ $number$ �ĳ��ȡ���ΪѰ������Ƴ�λ�ú͹����Ƴ����ַ�����ʱ�临�Ӷȡ�
-   �ռ临�Ӷȣ�$O(n)$����Ϊ�����Ƴ����ַ���ʱ�����ַ����Ŀռ俪����
