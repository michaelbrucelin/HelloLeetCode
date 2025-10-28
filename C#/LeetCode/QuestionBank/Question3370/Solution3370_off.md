### [仅含置位位的最小整数](https://leetcode.cn/problems/smallest-number-with-all-set-bits/solutions/3811610/jin-han-zhi-wei-wei-de-zui-xiao-zheng-sh-hgu5/)

#### 方法一：找规律

**思路与算法**

枚举仅包含置位位的整数：$1$，$3$，$7$，$15$。我们可以发现这个数列的规律，是前一个数乘以 $2$ 再加 $1$。

首先我们初始化 $x=1$，每次循环把当前 $x=x\times 2+1$，循环一直进行，直到 $x$ 大于等于 $n$，返回结果。

**代码**

```C++
class Solution {
public:
    int smallestNumber(int n) {
        int x = 1;
        while (x < n) {
            x = x * 2 + 1;
        }
        return x;
    }
};
```

```Java
class Solution {
    public int smallestNumber(int n) {
        int x = 1;
        while (x < n) {
            x = x * 2 + 1;
        }
        return x;
    }
}
```

```Python
class Solution:
    def smallestNumber(self, n: int) -> int:
        x = 1
        while x < n:
            x = x * 2 + 1
        return x
```

```JavaScript
var smallestNumber = function(n) {
    let x = 1;
    while (x < n) {
        x = x * 2 + 1;
    }
    return x;
};
```

```TypeScript
function smallestNumber(n: number): number {
    let x = 1;
    while (x < n) {
        x = x * 2 + 1;
    }
    return x;
};
```

```Go
func smallestNumber(n int) int {
    x := 1
    for x < n {
        x = x*2 + 1
    }
    return x
}
```

```CSharp
public class Solution {
    public int SmallestNumber(int n) {
        int x = 1;
        while (x < n) {
            x = x * 2 + 1;
        }
        return x;
    }
}
```

```C
int smallestNumber(int n) {
    int x = 1;
    while (x < n) {
        x = x * 2 + 1;
    }
    return x;
}
```

```Rust
impl Solution {
    pub fn smallest_number(n: i32) -> i32 {
        let mut x = 1;
        while x < n {
            x = x * 2 + 1;
        }
        x
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$。
- 空间复杂度：$O(1)$。
