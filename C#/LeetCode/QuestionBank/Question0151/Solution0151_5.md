#### [��������˫�˶���](https://leetcode.cn/problems/reverse-words-in-a-string/solutions/194450/fan-zhuan-zi-fu-chuan-li-de-dan-ci-by-leetcode-sol/)

**˼·���㷨**

����˫�˶���֧�ִӶ���ͷ������ķ�����������ǿ��������ַ���һ��һ�����ʴ���Ȼ�󽫵���ѹ����е�ͷ�����ٽ�����ת���ַ������ɡ�

![](./assets/img/Solution0151_5_01.png)

```python
class Solution:
    def reverseWords(self, s: str) -> str:
        left, right = 0, len(s) - 1
        # ȥ���ַ�����ͷ�Ŀհ��ַ�
        while left <= right and s[left] == ' ':
            left += 1
        
        # ȥ���ַ���ĩβ�Ŀհ��ַ�
        while left <= right and s[right] == ' ':
            right -= 1
            
        d, word = collections.deque(), []
        # ������ push �����е�ͷ��
        while left <= right:
            if s[left] == ' ' and word:
                d.appendleft(''.join(word))
                word = []
            elif s[left] != ' ':
                word.append(s[left])
            left += 1
        d.appendleft(''.join(word))
        
        return ' '.join(d)
```

```java
class Solution {
    public String reverseWords(String s) {
        int left = 0, right = s.length() - 1;
        // ȥ���ַ�����ͷ�Ŀհ��ַ�
        while (left <= right && s.charAt(left) == ' ') {
            ++left;
        }

        // ȥ���ַ���ĩβ�Ŀհ��ַ�
        while (left <= right && s.charAt(right) == ' ') {
            --right;
        }

        Deque<String> d = new ArrayDeque<String>();
        StringBuilder word = new StringBuilder();
        
        while (left <= right) {
            char c = s.charAt(left);
            if ((word.length() != 0) && (c == ' ')) {
                // ������ push �����е�ͷ��
                d.offerFirst(word.toString());
                word.setLength(0);
            } else if (c != ' ') {
                word.append(c);
            }
            ++left;
        }
        d.offerFirst(word.toString());

        return String.join(" ", d);
    }
}
```

```cpp
class Solution {
public:
    string reverseWords(string s) {
        int left = 0, right = s.size() - 1;
        // ȥ���ַ�����ͷ�Ŀհ��ַ�
        while (left <= right && s[left] == ' ') ++left;

        // ȥ���ַ���ĩβ�Ŀհ��ַ�
        while (left <= right && s[right] == ' ') --right;

        deque<string> d;
        string word;

        while (left <= right) {
            char c = s[left];
            if (word.size() && c == ' ') {
                // ������ push �����е�ͷ��
                d.push_front(move(word));
                word = "";
            }
            else if (c != ' ') {
                word += c;
            }
            ++left;
        }
        d.push_front(move(word));
        
        string ans;
        while (!d.empty()) {
            ans += d.front();
            d.pop_front();
            if (!d.empty()) ans += ' ';
        }
        return ans;
    }
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ�����ַ����ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(n)$��˫�˶��д洢������Ҫ $O(n)$ �Ŀռ䡣
