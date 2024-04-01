### [故障键盘](https://leetcode.cn/problems/faulty-keyboard/solutions/2711922/gu-zhang-jian-pan-by-leetcode-solution-l9zg/)

#### 方法一：使用双端队列进行模拟

##### 思路与算法

比较直观的思路是我们实时维护答案字符串 $\textit{ans}$，当遇到非 $\text{``i''}$ 的字符时，就将其加入字符串的末尾；否则将字符串进行反转。

然而字符串反转需要 $O(l)$ 的时间，其中 $l$ 是当前 $\textit{ans}$ 的长度，这样做的时间复杂度较高。事实上，当字符串进行反转后，在末尾添加字符等价于「不对字符串进行反转，并且在开头添加字符」。因此，我们可以使用一个双端队列和一个布尔变量 $\textit{head}$ 来维护答案：

- 当遇到非 $\text{``i''}$ 的字符时，如果 $\textit{head}$ 为真，就在队列的开头添加字符，否则在队列的末尾添加字符；
- 当遇到 $\text{``i''}$ 时，将 $\textit{head}$ 取反。

$\textit{head}$ 的初始值为假。这样一来，每一个字符只需要 $O(1)$ 的时间进行处理。

当处理完所有的字符后，如果 $\textit{head}$ 为真，那么将队列中的字符反序构造出答案字符串，否则正序构造出答案字符串。


##### 代码

```c++
class Solution {
public:
    string finalString(string s) {
        deque<char> q;
        bool head = false;
        for (char ch: s) {
            if (ch != 'i') {
                if (head) {
                    q.push_front(ch);
                }
                else {
                    q.push_back(ch);
                }
            }
            else {
                head = !head;
            }
        }
        string ans = (head ? string{q.rbegin(), q.rend()} : string{q.begin(), q.end()});
        return ans;
    }
};
```

```java
class Solution {
    public String finalString(String s) {
        Deque<Character> q = new ArrayDeque<Character>();
        boolean head = false;
        for (int i = 0; i < s.length(); i++) {
            char ch = s.charAt(i);
            if (ch != 'i') {
                if (head) {
                    q.offerFirst(ch);
                } else {
                    q.offerLast(ch);
                }
            } else {
                head = !head;
            }
        }
        StringBuilder ans = new StringBuilder();
        if (head) {
            while (!q.isEmpty()) {
                ans.append(q.po$l$ast());
            }
        } else {
            while (!q.isEmpty()) {
                ans.append(q.pollFirst());
            }
        }
        return ans.toString();
    }
}
```

```python
class Solution:
    def finalString(self, s: str) -> str:
        q = deque()
        head = False
        for ch in s:
            if ch != "i":
                if head:
                    q.appendleft(ch)
                else:
                    q.append(ch)
            else:
                head = not head
        ans = "".join(q)
        if head:
            ans = ans[::-1]
        return ans
```

```c
char* finalString(char* s) {
    int len = strlen(s);
    char q1[len], q2[len];
    int pos1 = 0, pos2 = 0;
    bool head = false;
    for (int i = 0; i < len; i++) {
        char ch = s[i];
        if (ch != 'i') {
            if (head) {
                q1[pos1++] = ch;
            } else {
                q2[pos2++] = ch;
            }
        } else {
            head = !head;
        }
    }

    char *ans = (char *)malloc(sizeof(char) * (len + 1));
    int pos = 0;
    if (head) {
        for (int i = pos2 - 1; i >= 0; i--) {
            ans[pos++] = q2[i]; 
        }
        memcpy(ans + pos, q1, sizeof(char) * pos1);
    } else {
        for (int i = pos1 - 1; i >= 0; i--) {
            ans[pos++] = q1[i];
        }
        memcpy(ans + pos, q2, sizeof(char) * pos2);
    }
    ans[pos1 + pos2] = '\0';
    return ans;
}
```

```go
func finalString(s string) string {
    q := []rune{}
    head := false
    for _, ch := range s {
        if ch != 'i' {
            if head {
                q = append([]rune{ch}, q...)
            } else {
                q = append(q, ch)
            }
        } else {
            head = !head
        }
    }
    if head {
        reverse(q)
    }
    return string(q)
}

func reverse(arr []rune) {
    for i, j := 0, len(arr) - 1; i < j; i, j = i + 1, j - 1 {
        arr[i], arr[j] = arr[j], arr[i]
    }
}
```

```javascript
var finalString = function(s) {
    let q = [];
    let head = false;
    for (let ch of s) {
        if (ch !== 'i') {
            if (head) {
                q.unshift(ch);
            } else {
                q.push(ch);
            }
        } else {
            head = !head;
        }
    }
    let ans = head ? q.reverse().join('') : q.join('');
    return ans;
};
```

```typescript
function finalString(s: string): string {
    let q: string[] = [];
    let head: boolean = false;
    for (let ch of s) {
        if (ch !== 'i') {
            if (head) {
                q.unshift(ch);
            } else {
                q.push(ch);
            }
        } else {
            head = !head;
        }
    }
    let ans: string = head ? q.reverse().join('') : q.join('');
    return ans;
};
```

```rust
impl Solution {
    pub fn final_string(s: String) -> String {
        let mut q = Vec::<char>::new();
        let mut head = false;
        for ch in s.chars() {
            if ch != 'i' {
                if head {
                    q.insert(0, ch);
                } else {
                    q.push(ch);
                }
            } else {
                head = !head;
            }
        }
        let ans: String = if head { q.iter().rev().collect() } else { q.iter().collect() };
        ans
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(n)$，即为双端队列需要使用的空间。
