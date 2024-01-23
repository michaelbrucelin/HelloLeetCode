### [O(1) 数学公式（Python/Java/C++/Go）](https://leetcode.cn/problems/minimum-number-of-pushes-to-type-word-i/solutions/2613419/o1-shu-xue-gong-shi-pythonjavacgo-by-end-v2bt/)

[视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Q5411C7mN%2F)

由于各个字母互不相同，所以均匀分配到这 $8$ 个按键。

设字符串长度为 $n$，$k=\left\lfloor\dfrac{n}{8}\right\rfloor$，那么先分配给每个按键 $k$ 个字母，总按键次数为

$$8\cdot(1+2+\cdots + k) = 4k(k+1)$$

剩余的 $n\bmod 8$ 个字母需要按 $k+1$ 次。

所以答案为

$$4k(k+1) + (n\bmod 8)(k+1) = (4k + n\bmod 8)(k+1)$$

```python
class Solution:
    def minimumPushes(self, word: str) -> int:
        k, rem = divmod(len(word), 8)
        return (k * 4 + rem) * (k + 1)
```

```java
class Solution {
    public int minimumPushes(String word) {
        int n = word.length();
        int k = n / 8;
        return (k * 4 + n % 8) * (k + 1);
    }
}
```

```c++
class Solution {
public:
    int minimumPushes(string &word) {
        int n = word.length();
        int k = n / 8;
        return (k * 4 + n % 8) * (k + 1);
    }
};
```

```go
func minimumPushes(word string) int {
    n := len(word)
    k := n / 8
    return (k*4 + n%8) * (k + 1)
}
```

#### 复杂度分析

- 时间复杂度：$\mathcal{O}(1)$。
- 空间复杂度：$\mathcal{O}(1)$。

[2023 下半年周赛题目总结](https://leetcode.cn/circle/discuss/lUu0KB/)
