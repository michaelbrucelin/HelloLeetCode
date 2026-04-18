### [整数的镜像距离](https://leetcode.cn/problems/mirror-distance-of-an-integer/solutions/3943092/zheng-shu-de-jing-xiang-ju-chi-by-leetco-p0pl/)

#### 方法一：数学

将整数 $n$ 的十进制表示逐位反转，得到镜像数 $rev$。具体地，每次取出 $n$ 的末位数字 $n\bmod 10$，将 $rev$ 的值更新为 $rev\times 10+n\bmod 10$，然后将 $n$ 的值更新为 $\lfloor\dfrac{n}{10}\rfloor$，直到 $n=0$。

最终答案为 $\vert n-rev\vert$。

```C++
class Solution {
public:
    int reverse(int n) {
        int res = 0;
        while (n > 0) {
            res = res * 10 + n % 10;
            n /= 10;
        }
        return res;
    }

    int mirrorDistance(int n) {
        return abs(n - reverse(n));
    }
};
```

```Go
func reverse(n int) int {
    res := 0
    for n > 0 {
        res = res * 10 + n % 10
        n /= 10
    }
    return res
}

func mirrorDistance(n int) int {
    diff := n - reverse(n)
    if diff < 0 {
        return -diff
    }
    return diff
}
```

```Python
class Solution:
    def reverse(self, n: int) -> int:
        res = 0
        while n > 0:
            res = res * 10 + n % 10
            n //= 10
        return res

    def mirrorDistance(self, n: int) -> int:
        return abs(n - self.reverse(n))
```

```Java
class Solution {
    public int reverse(int n) {
        int res = 0;
        while (n > 0) {
            res = res * 10 + n % 10;
            n /= 10;
        }
        return res;
    }

    public int mirrorDistance(int n) {
        return Math.abs(n - reverse(n));
    }
}
```

```TypeScript
function reverse(n: number): number {
    let res = 0;
    while (n > 0) {
        res = res * 10 + n % 10;
        n = Math.floor(n / 10);
    }
    return res;
}

function mirrorDistance(n: number): number {
    return Math.abs(n - reverse(n));
}
```

```JavaScript
var reverse = function(n) {
    let res = 0;
    while (n > 0) {
        res = res * 10 + n % 10;
        n = Math.floor(n / 10);
    }
    return res;
};

var mirrorDistance = function(n) {
    return Math.abs(n - reverse(n));
};
```

```CSharp
public class Solution {
    public int Reverse(int n) {
        int res = 0;
        while (n > 0) {
            res = res * 10 + n % 10;
            n /= 10;
        }
        return res;
    }

    public int MirrorDistance(int n) {
        return Math.Abs(n - Reverse(n));
    }
}
```

```C
int reverse(int n) {
    int res = 0;
    while (n > 0) {
        res = res * 10 + n % 10;
        n /= 10;
    }
    return res;
}

int mirrorDistance(int n) {
    return abs(n - reverse(n));
}
```

```Rust
impl Solution {
    fn reverse(mut n: i32) -> i32 {
        let mut res = 0;
        while n > 0 {
            res = res * 10 + n % 10;
            n /= 10;
        }
        res
    }

    fn mirror_distance(n: i32) -> i32 {
        (n - Self::reverse(n)).abs()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$，其中 $n$ 为输入整数。反转过程需要遍历 $n$ 的每一位数字，共 $O(\log n)$ 位。
- 空间复杂度：$O(1)$。
