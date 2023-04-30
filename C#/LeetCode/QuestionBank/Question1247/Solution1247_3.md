#### [没想明白？一张图秒懂！（Python/Java/C++/Go）...](https://leetcode.cn/problems/minimum-swaps-to-make-strings-equal/solutions/2131832/mei-xiang-ming-bai-yi-zhang-tu-miao-dong-a6r1/)

![](./assets/img/Solution1247_3_01.png)

#### 答疑

**问**：为什么这种交换方案是最优的？需不需要 $s_1[i]=s_2[i]$ 的字母参与？

**答**：对于不同的字母，这种做法是尽量「内部消化」。对于偶数+偶数的情况，每次交换操作都使 ddd 减二，这是单次操作的极限；对于奇数+奇数的情况，只额外交换了一次就转换成了偶数+偶数的情况，这是必要的。所以这种交换方案充分利用了每次交换操作，也无需 $s_1[i]=s_2[i]$ 的字母参与。

**问**：为什么奇数+奇数交换一次就变成了偶数+偶数？

**答**：交换一次后，要么 $s_1$ 中的 $x$ 多一，$y$ 少一，变成偶数+偶数；要么 $x$ 少一，$y$ 多一，也变成偶数+偶数。

```python
class Solution:
    def minimumSwap(self, s1: str, s2: str) -> int:
        cnt = Counter(x for x, y in zip(s1, s2) if x != y)
        d = cnt['x'] + cnt['y']
        return -1 if d % 2 else d // 2 + cnt['x'] % 2
```

```java
class Solution {
    public int minimumSwap(String s1, String s2) {
        int[] cnt = new int[2];
        for (int i = 0, n = s1.length(); i < n; ++i)
            if (s1.charAt(i) != s2.charAt(i))
                ++cnt[s1.charAt(i) % 2]; // x 和 y ASCII 值的二进制最低位不同
        int d = cnt[0] + cnt[1];
        return d % 2 != 0 ? -1 : d / 2 + cnt[0] % 2;
    }
}
```

```cpp
class Solution {
public:
    int minimumSwap(string s1, string s2) {
        int cnt[2]{};
        for (int i = 0, n = s1.length(); i < n; ++i)
            if (s1[i] != s2[i])
                ++cnt[s1[i] % 2]; // x 和 y ASCII 值的二进制最低位不同
        int d = cnt[0] + cnt[1];
        return d % 2 != 0 ? -1 : d / 2 + cnt[0] % 2;
    }
};
```

```go
func minimumSwap(s1, s2 string) int {
    cnt := [2]int{}
    for i, x := range s1 {
        if byte(x) != s2[i] {
            cnt[x%2]++ // 'x' 和 'y' ASCII 值的二进制最低位不同
        }
    }
    d := cnt[0] + cnt[1]
    if d%2 > 0 {
        return -1
    }
    return d/2 + cnt[0]%2
}
```

#### 复杂度分析

-   时间复杂度：$O(n)$，其中 $n$ 为 $s_1$ 的长度。
-   空间复杂度：$O(1)$，仅用到若干额外变量。

#### 思考题

如果字符串有超过两种字符，要怎么做呢？
