#### [����һ��ʹ����������](https://leetcode.cn/problems/reverse-words-in-a-string/solutions/194450/fan-zhuan-zi-fu-chuan-li-de-dan-ci-by-leetcode-sol/)

**˼·���㷨**

�ܶ����Զ��ַ����ṩ�� `split`����֣���`reverse`����ת���� `join`�����ӣ��ȷ�����������ǿ��Լ򵥵ĵ������õ� API ��ɲ�����

1.  ʹ�� `split` ���ַ������ո�ָ���ַ������飻
2.  ʹ�� `reverse` ���ַ���������з�ת��
3.  ʹ�� `join` �������ַ�������ƴ��һ���ַ�����

![](./assets/img/Solution0151_3_01.png)

```python
class Solution:
    def reverseWords(self, s: str) -> str:
        return " ".join(reversed(s.split()))
```

```java
class Solution {
    public String reverseWords(String s) {
        // ��ȥ��ͷ��ĩβ�Ŀհ��ַ�
        s = s.trim();
        // ����ƥ�������Ŀհ��ַ���Ϊ�ָ����ָ�
        List<String> wordList = Arrays.asList(s.split("\\s+"));
        Collections.reverse(wordList);
        return String.join(" ", wordList);
    }
}
```

```javascript
var reverseWords = function(s) {
    return s.trim().split(/\s+/).reverse().join(' ');
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ�����ַ����ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(n)$�������洢�ַ����ָ�֮��Ľ����
