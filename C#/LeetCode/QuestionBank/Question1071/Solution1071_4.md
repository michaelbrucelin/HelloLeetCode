#### [����������ѧ](https://leetcode.cn/problems/greatest-common-divisor-of-strings/solutions/143956/zi-fu-chuan-de-zui-da-gong-yin-zi-by-leetcode-solu/)

**˼·**

��Ҫ֪��һ�����ʣ�**��� `str1` �� `str2` ƴ�Ӻ���� `str2`�� `str1` ƴ���������ַ�����ע��ƴ��˳��ͬ������ôһ�����ڷ����������ַ��� `X`**��

��֤��Ҫ�ԣ���������ڷ����������ַ��� `X` ���� `str1` �� `str2` ƴ�Ӻ���� `str2`�� `str1` ƴ���������ַ�����

����ַ��� `X` ������������ô `str1=X+X+...+X+X=n*X` ��`str2=X+X+..+X+X=m*X`��`n*X` ��ʾ `n` ���ַ��� `X` ƴ�ӣ�`m*X` ͬ������ `str1` �� `str2` ƴ�Ӻ���ַ�����Ϊ `(n+m)*X`���� `str2` �� `str1` ƴ�Ӻ���ַ�����Ϊ `(m+n)*X`������ `(n+m)*X`�����Ա�Ҫ�Ե�֤��

�ٿ�����ԣ�����˵�����ǿ�������ͼһ���Ƚ�����ƴ�Ӻ���ַ�������һ�𡣲�ʧһ���ԣ����Ǽٶ� `str1` �ĳ��ȴ��� `str2`��

![](./asssets/img/Solution1071_4_01.png)

���ǵȼ��ȡ $gcd(len_1,len_2)$ ���ȵ��ַ�����

����ó��ȵ��� `str2` �ĳ��ȣ��� `str1` �ĳ��ȿ������� `str2` �ĳ��ȡ����ǿ���֪������֪ͼ�е�һ���ֵ���ͼ�еĵڶ����֣������ַ��� `str1` �Ŀ�ͷ������ͼ�еĵڶ������ֵ��ڵ������֣������ַ�����ȣ�����������֪����������Ҳ�ǵ��ڵ�һ���֡�ͬ�����ǿ����Ƶ�ͼ�л��ֵ� `1,3,5,7` �ĸ����ֶ���ȣ�����ƴ���������ַ��������ɵ�һ���ֵ�ǰ׺���������ɴ�ƴ�ӵõ���

![](./asssets/img/Solution1071_4_02.png)

��ô��������� `str2` �ĳ��ȣ�����������һ���ķ��������Ƶ���ͼ�б�Ⱦ��ɫ��ͬ���ַ���Ƭ������ȵģ�����ÿ����ɫƬ�ζ��ǳ�Ϊ $gcd(len_1,len_2)$ ���ַ�������ô��ͬ��ɫ�������ַ����Ƿ�Ҳ����أ������ȾͿ����Ƶ����ǵĽ�������ȷ�ġ�

![](./asssets/img/Solution1071_4_03.gif)

��ʵ����ͼ���ǿ���֪������Ϊ��һ���ַ����͵ڶ����ַ�����ȣ����������ַ�����ͷ�Ĳ��ֱ�Ȼ��ȡ����ǽ�ǰ $\dfrac{len_2}{gcd(len_1,len_2)}$ ����Ⱦ��ɫ�Ĳ��ַ���һ��Ƚϼ����Ƶò�ͬ��ɫ�Ĳ��ֶ���������ȵģ��������ǻ������ǿ�ͷ��Ⱦ����ɫ˳���ǲ�ͬ�ģ���һ��������

��ʵͼ�п��Կ�����һ���ַ�����Ⱦ����ɫ���� `str2` �ĳ�����ѭ���ģ����ڵڶ�������� `str1` �ĳ��Ȳ����� `str2` �ĳ��ȣ����µ�һ���ַ����� `str1` ���ֱ�Ⱦ����ɫ��ʱ��`str2` ��Ⱦ����ɫ��˳���Ȼ�����ڿ�ͷ `str1` ��Ⱦ����ɫ˳�򣬶��ڶ����ַ����Ŀ�ͷ���� `str2`������Ⱦɫ��˳���ǵ��ڵ�һ���ַ����� `str2` ��Ⱦɫ��˳��ģ����������ַ����Ŀ�ͷ��Ⱦ����ɫ˳��һ����ͬ��������Ǿ��Ƴ���� `str1` �� `str2` ƴ�Ӻ���� `str2` �� `str1` ƴ���������ַ�������ôһ�����ڷ����������ַ��� `X`��

![](./asssets/img/Solution1071_4_04.gif)

**�㷨**

���˸������Լ������������ʣ����ǾͿ������ж� `str1` �� `str2` ƴ�Ӻ��Ƿ���� `str2` �� `str1` ƴ���������ַ������������ֱ���������Ϊ $gcd(len_1,len_2)$ ��ǰ׺�����ɣ����򷵻ؿմ���

```cpp
class Solution {
public:
    string gcdOfStrings(string str1, string str2) {
        if (str1 + str2 != str2 + str1) return "";
        return str1.substr(0, __gcd((int)str1.length(), (int)str2.length())); // __gcd() Ϊc++�Դ��������Լ���ĺ���
    }
};
```

```java
class Solution {
    public String gcdOfStrings(String str1, String str2) {
        if (!str1.concat(str2).equals(str2.concat(str1))) {
            return "";
        }
        return str1.substring(0, gcd(str1.length(), str2.length()));
    }

    public int gcd(int a, int b) {
        int remainder = a % b;
        while (remainder != 0) {
            a = b;
            b = remainder;
            remainder = a % b;
        }
        return b;
    }
}
```

```python
class Solution:
    def gcdOfStrings(self, str1: str, str2: str) -> str:
        candidate_len = math.gcd(len(str1), len(str2))
        candidate = str1[: candidate_len]
        if str1 + str2 == str2 + str1:
            return candidate
        return ''
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$ ���ַ���ƴ�ӱȽ��Ƿ������Ҫ $O(n)$ ��ʱ�临�Ӷȣ��������ַ������ȵ����Լ����Ҫ $O(\log n)$ ��ʱ�临�Ӷȣ�������ʱ�临�Ӷ�Ϊ $O(n+\log n)=O(n)$ ��
-   �ռ临�Ӷȣ�$O(n)$ ����������ʱ�������м���������洢 `str1` �� `str2` ����ӽ����