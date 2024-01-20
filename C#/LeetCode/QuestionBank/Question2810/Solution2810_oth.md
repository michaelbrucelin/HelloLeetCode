### [双端队列 O(n) 做法（Python/Java/C++/Go）](https://leetcode.cn/problems/faulty-keyboard/solutions/2375152/shuang-duan-dui-lie-on-zuo-fa-by-endless-5pe1/)

[视频讲解](https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Yr4y1o7aP%2F)

把反转看成是后续往字符串的头部添加字符。

这可以用双端队列实现。

不想用双端队列的话，可以参考下面 Go 语言代码的实现。

```python
class Solution:
    def finalString(self, s: str) -> str:
        q = deque()
        tail = True
        for c in s:
            if c == 'i':
                tail = not tail  # 修改添加方向
            elif tail:  # 加尾部
                q.append(c)
            else:  # 加头部
                q.appendleft(c)
        return ''.join(q if tail else reversed(q))
```

```java
class Solution {
    public String finalString(String s) {
        var q = new ArrayDeque<Character>();
        var tail = true;
        for (var c : s.toCharArray()) {
            if (c == 'i') tail = !tail;
            else if (tail) q.addLast(c);
            else q.addFirst(c);
        }
        var ans = new StringBuilder();
        for (var c : q) ans.append(c);
        if (!tail) ans.reverse();
        return ans.toString();
    }
}
```

```c++
class Solution {
public:
    string finalString(string s) {
        deque<char> q;
        bool tail = true;
        for (char c: s) {
            if (c == 'i') tail = !tail;
            else if (tail) q.push_back(c);
            else q.push_front(c);
        }
        return tail ? string(q.begin(), q.end()) : string(q.rbegin(), q.rend());
    }
};
```

```go
func finalString(s string) string {
    qs := [2][]rune{}
    tail := 1
    for _, c := range s {
        if c == 'i' {
            tail ^= 1
        } else {
            qs[tail] = append(qs[tail], c)
        }
    }
    q := qs[tail^1]
    for i, n := 0, len(q); i < n/2; i++ {
        q[i], q[n-1-i] = q[n-1-i], q[i]
    }
    return string(append(q, qs[tail]...))
}
```

#### 复杂度分析

- 时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $s$ 的长度。
- 空间复杂度：$\mathcal{O}(n)$。
