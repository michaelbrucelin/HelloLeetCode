#### [����һ��ö��](https://leetcode.cn/problems/buddy-strings/solutions/1090079/qin-mi-zi-fu-chuan-by-leetcode-solution-yyis/)

**˼·���㷨**

�������ַ����ֱ�Ϊ $s$ �� $goal$������ $s[i]$ ��ʾ $s$ �ĵ� $i$ ���ַ������� $goal[i]$ ��ʾ $goal$ �ĵ� $i$ ���ַ������ $s[i] = goal[i]$�����Ǿ�˵ $i$ ��ƥ��ģ������ $i$ �ǲ�ƥ��ġ������ַ�������Ϊ����Ҫ���� $s$ �еĵ� $i$ ���ַ� $s[i]$ �� $s$ �е� $j$ ���ַ������� $i \neq j$�������� $s$ �� $goal$ ��ȡ������ַ����������ַ�����Ҫ����һ����������ȵ������ַ�����ȡ�

������㽻�� $s[i]$ �� $s[j]$ �������ַ�����ȣ���ô��Ҫ�������¼�������ʹ�� $s$ �� $goal$ Ϊ�����ַ�����

-   �ַ��� $s$ �ĳ������ַ��� $goal$ �ĳ�����ȣ�
-   ���� $i \neq j$ ������ $s[i] = goal[j]$ �Լ� $s[j] = goal[i]$��ʵ���� $s[i], s[j], goal[i], goal[j]$ ���ĸ����ɱ����У�ֻ�������������
    1.  ���� $s[i] = s[j]$�����ʱ��Ȼ���� $s[i] = s[j] = goal[i] = goal[j]$���ַ��� $s$ �� $goal$ ��ȣ�����Ӧ���ܹ��� $s$ ���ҵ�������ͬ������ $i,j$�������� $s[i] = s[j]$������ܹ��ҵ�����������ͬ��ֵ��ȵ��ַ������� $s$ �� $goal$ Ϊ�����ַ���������Ϊ�����ַ�����
    2.  ���� $s[i] \neq s[j]$������ $s[i] = goal[j], s[j] = goal[i], s[i] \neq s[j]$ ������£������ַ��� $s$ �� $goal$ �������� $i,j$ ������ַ�����ƥ��ġ�

**����**

```java
class Solution {
    public boolean buddyStrings(String s, String goal) {
        if (s.length() != goal.length()) {
            return false;
        }
        
        if (s.equals(goal)) {
            int[] count = new int[26];
            for (int i = 0; i < s.length(); i++) {
                count[s.charAt(i) - 'a']++;
                if (count[s.charAt(i) - 'a'] > 1) {
                    return true;
                }
            }
            return false;
        } else {
            int first = -1, second = -1;
            for (int i = 0; i < goal.length(); i++) {
                if (s.charAt(i) != goal.charAt(i)) {
                    if (first == -1)
                        first = i;
                    else if (second == -1)
                        second = i;
                    else
                        return false;
                }
            }

            return (second != -1 && s.charAt(first) == goal.charAt(second) &&
                    s.charAt(second) == goal.charAt(first));
        }
    }
}
```

```cpp
class Solution {
public:
    bool buddyStrings(string s, string goal) {
        if (s.size() != goal.size()) {
            return false;
        }
        
        if (s == goal) {
            vector<int> count(26);
            for (int i = 0; i < s.size(); i++) {
                count[s[i] - 'a']++;
                if (count[s[i] - 'a'] > 1) {
                    return true;
                }
            }
            return false;
        } else {
            int first = -1, second = -1;
            for (int i = 0; i < s.size(); i++) {
                if (s[i] != goal[i]) {
                    if (first == -1)
                        first = i;
                    else if (second == -1)
                        second = i;
                    else
                        return false;
                }
            }

            return (second != -1 && s[first] == goal[second] && s[second] == goal[first]);
        }
    }
};
```

```csharp
public class Solution {
    public bool BuddyStrings(string s, string goal) {
        if (s.Length != goal.Length) {
            return false;
        }
        
        if (s.Equals(goal)) {
            int[] count = new int[26];
            for (int i = 0; i < s.Length; i++) {
                count[s[i] - 'a']++;
                if (count[s[i] - 'a'] > 1) {
                    return true;
                }
            }
            return false;
        } else {
            int first = -1, second = -1;
            for (int i = 0; i < goal.Length; i++) {
                if (s[i] != goal[i]) {
                    if (first == -1)
                        first = i;
                    else if (second == -1)
                        second = i;
                    else
                        return false;
                }
            }

            return (second != -1 && s[first] == goal[second] && s[second] == goal[first]);
        }
    }
}
```

```python
class Solution:
    def buddyStrings(self, s: str, goal: str) -> bool:
        if len(s) != len(goal):
            return False
        if s == goal:
            if len(set(s)) < len(goal): 
                return True
            else:
                return False
        diff = [(a, b) for a, b in zip(s, goal) if a != b]
        return len(diff) == 2 and diff[0][0] == diff[1][1] and diff[0][1] == diff[1][0]
```

```go
func buddyStrings(s, goal string) bool {
    if len(s) != len(goal) {
        return false
    }

    if s == goal {
        seen := [26]bool{}
        for _, ch := range s {
            if seen[ch-'a'] {
                return true
            }
            seen[ch-'a'] = true
        }
        return false
    }

    first, second := -1, -1
    for i := range s {
        if s[i] != goal[i] {
            if first == -1 {
                first = i
            } else if second == -1 {
                second = i
            } else {
                return false
            }
        }
    }
    return second != -1 && s[first] == goal[second] && s[second] == goal[first]
}
```

```javascript
var buddyStrings = function(s, goal) {
    if (s.length != goal.length) {
        return false;
    }
    
    if (s === goal) {
        const count = new Array(26).fill(0);
        for (let i = 0; i < s.length; i++) {
            count[s[i].charCodeAt() - 'a'.charCodeAt()]++;
            if (count[s[i].charCodeAt() - 'a'.charCodeAt()] > 1) {
                return true;
            }
        }
        return false;
    } else {
        let first = -1, second = -1;
        for (let i = 0; i < s.length; i++) {
            if (s[i] !== goal[i]) {
                if (first === -1)
                    first = i;
                else if (second === -1)
                    second = i;
                else
                    return false;
            }
        }

        return (second !== -1 && s[first] === goal[second] && s[second] === goal[first]);
    }
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(N)$������ $N$ Ϊ�ַ����ĳ��ȡ�������������ַ������顣
-   �ռ临�Ӷȣ�$O(C)$����Ҫ�������ռ䱣���ַ������ַ�ͳ�ƴ���������ͳ������Сд��ĸ�ĸ�������� $C = 26$��
