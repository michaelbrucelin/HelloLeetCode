#### [�����������б�д��Ӧ�ĺ���](https://leetcode.cn/problems/fan-zhuan-dan-ci-shun-xu-lcof/solutions/1398807/fan-zhuan-dan-ci-shun-xu-by-leetcode-sol-vnwj/)

**˼·���㷨**

����Ҳ���Բ�ʹ�������е� API�������Լ���д��Ӧ�ĺ������ڲ�ͬ�����У���Щ����ʵ���ǲ�һ���ģ���Ҫ�Ĳ������Щ���Ե��ַ������ɱ䣨�� Java �� Python)����Щ���Ե��ַ����ɱ䣨�� C++)��

�����ַ������ɱ�����ԣ����ȵð��ַ���ת���������ɱ�����ݽṹ��ͬʱ����Ҫ��ת���Ĺ�����ȥ���ո�

![](./assets/img/Solution0058_4_01.png)

�����ַ����ɱ�����ԣ��Ͳ���Ҫ�ٶ��⿪�ٿռ��ˣ�ֱ�����ַ�����ԭ��ʵ�֡�����������£���ת�ַ���ȥ���ո����һ����ɡ�

![](./assets/img/Solution0058_4_02.png)

```python
class Solution:
    def trim_spaces(self, s: str) -> list:
        left, right = 0, len(s) - 1
        # ȥ���ַ�����ͷ�Ŀհ��ַ�
        while left <= right and s[left] == ' ':
            left += 1
        
        # ȥ���ַ���ĩβ�Ŀհ��ַ�
        while left <= right and s[right] == ' ':
            right -= 1
        
        # ���ַ��������Ŀհ��ַ�ȥ��
        output = []
        while left <= right:
            if s[left] != ' ':
                output.append(s[left])
            elif output[-1] != ' ':
                output.append(s[left])
            left += 1
        
        return output
            
    def reverse(self, l: list, left: int, right: int) -> None:
        while left < right:
            l[left], l[right] = l[right], l[left]
            left, right = left + 1, right - 1
            
    def reverse_each_word(self, l: list) -> None:
        n = len(l)
        start = end = 0
        
        while start < n:
            # ѭ�������ʵ�ĩβ
            while end < n and l[end] != ' ':
                end += 1
            # ��ת����
            self.reverse(l, start, end - 1)
            # ����start��ȥ����һ������
            start = end + 1
            end += 1
                
    def reverseWords(self, s: str) -> str:
        l = self.trim_spaces(s)
        
        # ��ת�ַ���
        self.reverse(l, 0, len(l) - 1)
        
        # ��תÿ������
        self.reverse_each_word(l)
        
        return ''.join(l)
```

```java
class Solution {
    public String reverseWords(String s) {
        StringBuilder sb = trimSpaces(s);

        // ��ת�ַ���
        reverse(sb, 0, sb.length() - 1);

        // ��תÿ������
        reverseEachWord(sb);

        return sb.toString();
    }

    public StringBuilder trimSpaces(String s) {
        int left = 0, right = s.length() - 1;
        // ȥ���ַ�����ͷ�Ŀհ��ַ�
        while (left <= right && s.charAt(left) == ' ') {
            ++left;
        }

        // ȥ���ַ���ĩβ�Ŀհ��ַ�
        while (left <= right && s.charAt(right) == ' ') {
            --right;
        }

        // ���ַ��������Ŀհ��ַ�ȥ��
        StringBuilder sb = new StringBuilder();
        while (left <= right) {
            char c = s.charAt(left);

            if (c != ' ') {
                sb.append(c);
            } else if (sb.charAt(sb.length() - 1) != ' ') {
                sb.append(c);
            }

            ++left;
        }
        return sb;
    }

    public void reverse(StringBuilder sb, int left, int right) {
        while (left < right) {
            char tmp = sb.charAt(left);
            sb.setCharAt(left++, sb.charAt(right));
            sb.setCharAt(right--, tmp);
        }
    }

    public void reverseEachWord(StringBuilder sb) {
        int n = sb.length();
        int start = 0, end = 0;

        while (start < n) {
            // ѭ�������ʵ�ĩβ
            while (end < n && sb.charAt(end) != ' ') {
                ++end;
            }
            // ��ת����
            reverse(sb, start, end - 1);
            // ����start��ȥ����һ������
            start = end + 1;
            ++end;
        }
    }
}
```

```cpp
class Solution {
public:
    string reverseWords(string s) {
        // ��ת�����ַ���
        reverse(s.begin(), s.end());

        int n = s.size();
        int idx = 0;
        for (int start = 0; start < n; ++start) {
            if (s[start] != ' ') {
                // ��һ���հ��ַ�Ȼ��idx�ƶ�����һ�����ʵĿ�ͷλ��
                if (idx != 0) s[idx++] = ' ';

                // ѭ�����������ʵ�ĩβ
                int end = start;
                while (end < n && s[end] != ' ') s[idx++] = s[end++];

                // ��ת��������
                reverse(s.begin() + idx - (end - start), s.begin() + idx);

                // ����start��ȥ����һ������
                start = end;
            }
        }
        s.erase(s.begin() + idx, s.end());
        return s;
    }
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ�����ַ����ĳ��ȡ�
-   �ռ临�Ӷȣ�`Java` �� `Python` �ķ�����Ҫ $O(n)$ �Ŀռ����洢�ַ������� `C++` ����ֻ��Ҫ $O(1)$ �Ķ���ռ���������ɱ�����
