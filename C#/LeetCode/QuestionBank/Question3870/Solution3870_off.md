### [统计范围内的逗号](https://leetcode.cn/problems/count-commas-in-range/solutions/4020362/tong-ji-fan-wei-nei-de-dou-hao-by-leetco-8p2i/)

#### 方法一：遍历计数

**思路与算法**

这个方法通过直接遍历从 $1$ 到 $n$ 的所有整数，来统计符合条件的数字个数。根据题意，在 $[1,n]$ 的范围内（$n\le 10^5$），只有大于 $999$ 的数才会在标准格式下包含一个逗号（例如 $1,000$）。因此，每次遇到循环变量大于 $999$ 时，就将结果增加 $1$，最后返回总数即可。

**代码**

```C++
class Solution {
public:
    int countCommas(int n) {
        int res = 0;
        for (int a = 1; a <= n; ++a) {
            if (a > 999) {
                res += 1;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int countCommas(int n) {
        int res = 0;
        for (int a = 1; a <= n; ++a) {
            if (a > 999) {
                res += 1;
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def countCommas(self, n: int) -> int:
        res = 0
        for a in range(1, n + 1):
            if a > 999:
                res += 1
        return res
```

```JavaScript
var countCommas = function(n) {
    let res = 0;
    for (let a = 1; a <= n; ++a) {
        if (a > 999) {
            res += 1;
        }
    }
    return res;
};
```

```TypeScript
function countCommas(n: number): number {
    let res = 0;
    for (let a = 1; a <= n; ++a) {
        if (a > 999) {
            res += 1;
        }
    }
    return res;
}
```

```Go
func countCommas(n int) int {
    res := 0
    for a := 1; a <= n; a++ {
        if a > 999 {
            res += 1
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public int CountCommas(int n) {
        int res = 0;
        for (int a = 1; a <= n; ++a) {
            if (a > 999) {
                res += 1;
            }
        }
        return res;
    }
}
```

```C
int countCommas(int n) {
    int res = 0;
    for (int a = 1; a <= n; ++a) {
        if (a > 999) {
            res += 1;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn count_commas(n: i32) -> i32 {
        let mut res = 0;
        for a in 1..(n + 1) {
            if a > 999 {
                res += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。

#### 方法二：直接计算

**思路与算法**

这个方法通过数学计算在 $O(1)$ 的时间内得出答案。

根据题目限制，在 $[1,n]$ 的范围内（$n\le 10^5$），只有大于等于 $1000$ 的数才会包含且仅包含一个逗号（例如 $1,000$ 到 $100,000$）。

因此，如果 $n\ge 1000$，包含逗号的数字个数就是 $n-999$；如果 $n<1000$，则个数为 $0$。我们可以直接取 $n-999$ 和 $0$ 之间的最大值作为最终结果，避免了不必要的循环过程。

**代码**

```C++
class Solution {
public:
    int countCommas(int n) {
        return max(n - 999, 0);
    }
};
```

```Java
class Solution {
    public int countCommas(int n) {
        return Math.max(n - 999, 0);
    }
}
```

```Python
class Solution:
    def countCommas(self, n: int) -> int:
        return max(n - 999, 0)
```

```JavaScript
var countCommas = function(n) {
    return Math.max(n - 999, 0);
};
```

```TypeScript
function countCommas(n: number): number {
    return Math.max(n - 999, 0);
}
```

```Go
func countCommas(n int) int {
    return max(n - 999, 0)
}
```

```CSharp
public class Solution {
    public int CountCommas(int n) {
        return Math.Max(n - 999, 0);
    }
}
```

```C
int countCommas(int n) {
    return n > 999 ? n - 999 : 0;
}
```

```Rust
impl Solution {
    pub fn count_commas(n: i32) -> i32 {
        0.max(n - 999)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
