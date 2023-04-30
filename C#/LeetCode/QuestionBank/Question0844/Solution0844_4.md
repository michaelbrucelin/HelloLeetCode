#### [��������˫ָ��](https://leetcode.cn/problems/backspace-string-compare/solutions/451606/bi-jiao-han-tui-ge-de-zi-fu-chuan-by-leetcode-solu/)

**˼·���㷨**

һ���ַ��Ƿ�ᱻɾ����ֻȡ���ڸ��ַ�������˸����������ַ�ǰ����˸���޹ء���˵���������ر����ַ������Ϳ�������ȷ����ǰ�ַ��Ƿ�ᱻɾ����

����أ����Ƕ��� $skip$ ��ʾ��ǰ��ɾ�����ַ���������ÿ�����Ǳ�����һ���ַ���

-   �����ַ�Ϊ�˸������������Ҫ��ɾ��һ����ͨ�ַ��������� $skip$ �� $1$��
-   �����ַ�Ϊ��ͨ�ַ���
    -   �� $skip$ Ϊ $0$����˵����ǰ�ַ�����Ҫɾȥ��
    -   �� $skip$ ��Ϊ $0$����˵����ǰ�ַ���Ҫɾȥ�������� $skip$ �� $1$��

���������Ƕ�������ָ�룬�ֱ�ָ�����ַ�����ĩβ��ÿ����������ָ������ر������ַ�����ֱ�����ַ����ܹ�����ȷ��һ���ַ���Ȼ���������ַ����бȽϡ��ظ���һ����ֱ���ҵ��������ַ�����ȣ���������ַ���Ϊֹ��

![](./assets/img/Solution0844_4_01.gif)

**����**

```cpp
class Solution {
public:
    bool backspaceCompare(string S, string T) {
        int i = S.length() - 1, j = T.length() - 1;
        int skipS = 0, skipT = 0;

        while (i >= 0 || j >= 0) {
            while (i >= 0) {
                if (S[i] == '#') {
                    skipS++, i--;
                } else if (skipS > 0) {
                    skipS--, i--;
                } else {
                    break;
                }
            }
            while (j >= 0) {
                if (T[j] == '#') {
                    skipT++, j--;
                } else if (skipT > 0) {
                    skipT--, j--;
                } else {
                    break;
                }
            }
            if (i >= 0 && j >= 0) {
                if (S[i] != T[j]) {
                    return false;
                }
            } else {
                if (i >= 0 || j >= 0) {
                    return false;
                }
            }
            i--, j--;
        }
        return true;
    }
};
```

```java
class Solution {
    public boolean backspaceCompare(String S, String T) {
        int i = S.length() - 1, j = T.length() - 1;
        int skipS = 0, skipT = 0;

        while (i >= 0 || j >= 0) {
            while (i >= 0) {
                if (S.charAt(i) == '#') {
                    skipS++;
                    i--;
                } else if (skipS > 0) {
                    skipS--;
                    i--;
                } else {
                    break;
                }
            }
            while (j >= 0) {
                if (T.charAt(j) == '#') {
                    skipT++;
                    j--;
                } else if (skipT > 0) {
                    skipT--;
                    j--;
                } else {
                    break;
                }
            }
            if (i >= 0 && j >= 0) {
                if (S.charAt(i) != T.charAt(j)) {
                    return false;
                }
            } else {
                if (i >= 0 || j >= 0) {
                    return false;
                }
            }
            i--;
            j--;
        }
        return true;
    }
}
```

```go
func backspaceCompare(s, t string) bool {
    skipS, skipT := 0, 0
    i, j := len(s)-1, len(t)-1
    for i >= 0 || j >= 0 {
        for i >= 0 {
            if s[i] == '#' {
                skipS++
                i--
            } else if skipS > 0 {
                skipS--
                i--
            } else {
                break
            }
        }
        for j >= 0 {
            if t[j] == '#' {
                skipT++
                j--
            } else if skipT > 0 {
                skipT--
                j--
            } else {
                break
            }
        }
        if i >= 0 && j >= 0 {
            if s[i] != t[j] {
                return false
            }
        } else if i >= 0 || j >= 0 {
            return false
        }
        i--
        j--
    }
    return true
}
```

```python
class Solution:
    def backspaceCompare(self, S: str, T: str) -> bool:
        i, j = len(S) - 1, len(T) - 1
        skipS = skipT = 0

        while i >= 0 or j >= 0:
            while i >= 0:
                if S[i] == "#":
                    skipS += 1
                    i -= 1
                elif skipS > 0:
                    skipS -= 1
                    i -= 1
                else:
                    break
            while j >= 0:
                if T[j] == "#":
                    skipT += 1
                    j -= 1
                elif skipT > 0:
                    skipT -= 1
                    j -= 1
                else:
                    break
            if i >= 0 and j >= 0:
                if S[i] != T[j]:
                    return False
            elif i >= 0 or j >= 0:
                return False
            i -= 1
            j -= 1
        
        return True
```

```c
bool backspaceCompare(char* S, char* T) {
    int i = strlen(S) - 1, j = strlen(T) - 1;
    int skipS = 0, skipT = 0;

    while (i >= 0 || j >= 0) {
        while (i >= 0) {
            if (S[i] == '#') {
                skipS++, i--;
            } else if (skipS > 0) {
                skipS--, i--;
            } else {
                break;
            }
        }
        while (j >= 0) {
            if (T[j] == '#') {
                skipT++, j--;
            } else if (skipT > 0) {
                skipT--, j--;
            } else {
                break;
            }
        }
        if (i >= 0 && j >= 0) {
            if (S[i] != T[j]) {
                return false;
            }
        } else {
            if (i >= 0 || j >= 0) {
                return false;
            }
        }
        i--, j--;
    }
    return true;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(N+M)$������ $N$ �� $M$ �ֱ�Ϊ�ַ��� $S$ �� $T$ �ĳ��ȡ�������Ҫ�������ַ�����һ�Ρ�
-   �ռ临�Ӷȣ�$O(1)$������ÿ���ַ���������ֻ��Ҫ����һ��ָ���һ�����������ɡ�
