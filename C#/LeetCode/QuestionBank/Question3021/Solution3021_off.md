### [Alice 和 Bob 玩鲜花游戏](https://leetcode.cn/problems/alice-and-bob-playing-flower-game/solutions/3753655/alice-he-bob-wan-xian-hua-you-xi-by-leet-pkhl/)

#### 方法一：数学

由题意可知，只有当 $x+y$ 为奇数时，Alice 才能赢得游戏。那么有两种情况：

- $x$ 为奇数，$y$ 为偶数，满足题目描述的数对 $(x,y)$ 数目为 $\lceil\frac{n}{2}\rceil \times \lfloor\frac{m}{2}\rfloor$
- $x$ 为偶数，$y$ 为奇数，满足题目描述的数对 $(x,y)$ 数目为 $\lfloor\frac{n}{2}\rfloor \times \lceil\frac{m}{2}\rceil$

所有满足题目描述的数对 $(x,y)$ 数目为：

$$\lceil\dfrac{n}{2}\rceil \times \lfloor\dfrac{m}{2}\rfloor +\lfloor\dfrac{n}{2}\rfloor \times \lceil\dfrac{m}{2}\rceil$$

考虑简化以上公式：

- 当 $n$ 和 $m$ 都为偶数时，化简为 $\frac{nm}{2}$
- 当 $n$ 和 $m$ 都为奇数时，化简为 $\frac{n+1}{2}\times\frac{m-1}{2}+\frac{n-1}{2}\times\frac{m+1}{2}=\frac{nm-1}{2}$
- 当 $n$ 或 $m$ 其中一个为奇数时，以 $n$ 为奇数为例，化简为 $\frac{n+1}{2}\times\frac{m}{2}+\frac{n-1}{2}\times\frac{m}{2}=\frac{nm}{2}$

那么简化公式可以归纳为 $\lfloor\frac{nm}{2}\rfloor $。

```C++
class Solution {
public:
    long long flowerGame(int n, int m) {
        return (long long)m * n / 2;
    }
};
```

```Go
func flowerGame(n int, m int) int64 {
    return int64(m) * int64(n) / 2
}
```

```Python
class Solution:
    def flowerGame(self, n: int, m: int) -> int:
        return (m * n) // 2
```

```Java
class Solution {
    public long flowerGame(int n, int m) {
        return (long)m * n / 2;
    }
}
```

```TypeScript
function flowerGame(n: number, m: number): number {
    return Math.floor(m * n / 2);
};
```

```JavaScript
var flowerGame = function(n, m) {
    return Math.floor(m * n / 2);
};
```

```CSharp
public class Solution {
    public long FlowerGame(int n, int m) {
        return (long)m * n / 2;
    }
}
```

```C
long long flowerGame(int n, int m) {
    return (long long)m * n / 2;
}
```

```Rust
impl Solution {
    pub fn flower_game(n: i32, m: i32) -> i64 {
        (m as i64) * (n as i64) / 2
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
