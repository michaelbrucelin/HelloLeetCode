### [哈沙德数](https://leetcode.cn/problems/harshad-number/solutions/2823604/ha-sha-de-shu-by-leetcode-solution-pnpd/)

#### 方法一：模拟

**思路与算法**

计算 $x$ 的数位之和 $s$，判断 $x$ 是否能被 $s$ 整除，若能，则是哈沙德数，返回 $s$，否则返回 $-1$。

**代码**

```Python
class Solution:
    def sumOfTheDigitsOfHarshadNumber(self, x: int) -> int:
        s = 0
        y = x
        while y:
            y, r = divmod(y, 10)
            s += r
        return -1 if x % s else s
```

```C++
class Solution {
public:
    int sumOfTheDigitsOfHarshadNumber(int x) {
        int s = 0;
        for (int y = x; y; y /= 10) {
            s += y % 10;
        }
        return x % s ? -1 : s;
    }
};
```

```Java
class Solution {
    public int sumOfTheDigitsOfHarshadNumber(int x) {
        int s = 0;
        for (int y = x; y != 0; y /= 10) {
            s += y % 10;
        }
        return x % s != 0 ? -1 : s;
    }
}
```

```CSharp
public class Solution {
    public int SumOfTheDigitsOfHarshadNumber(int x) {
        int s = 0;
        for (int y = x; y != 0; y /= 10) {
            s += y % 10;
        }
        return x % s != 0 ? -1 : s;
    }
}
```

```Go
func sumOfTheDigitsOfHarshadNumber(x int) int {
    s := 0
    for y := x; y != 0; y /= 10 {
        s += y % 10
    }

    if x % s != 0 {
        return -1
    }
    return s
}
```

```C
int sumOfTheDigitsOfHarshadNumber(int x) {
    int s = 0;
    for (int y = x; y; y /= 10) {
        s += y % 10;
    }
    return x % s ? -1 : s;
}
```

```JavaScript
var sumOfTheDigitsOfHarshadNumber = function(x) {
    let s = 0;
    for (let y = x; y != 0; y = Math.floor(y / 10)) {
        s += y % 10;
    }
    return x % s ? -1 : s;
};
```

```TypeScript
function sumOfTheDigitsOfHarshadNumber(x: number): number {
    let s = 0;
    for (let y = x; y != 0; y = Math.floor(y / 10)) {
        s += y % 10;
    }
    return x % s ? -1 : s;
};
```

```Rust
impl Solution {
    pub fn sum_of_the_digits_of_harshad_number(x: i32) -> i32 {
        let mut s = 0;
        let mut y = x;
        while y != 0 {
            s += y % 10;
            y /= 10;
        }
        if x % s != 0 {
            -1
        } else {
            s
        }
    }
}
```


**复杂度分析**

- 时间复杂度：$O(logx)$。
- 空间复杂度：$O(1)$。
