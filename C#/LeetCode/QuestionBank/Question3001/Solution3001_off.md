### [捕获黑皇后需要的最少移动次数](https://leetcode.cn/problems/minimum-moves-to-capture-the-queen/solutions/2995567/bu-huo-hei-huang-hou-xu-yao-de-zui-shao-vxmt1/)

#### 方法一：分类讨论

**思路与算法**

根据棋盘中 **车** 的移动规则可以知道，对于棋盘中任意的位置 $(x,y)$，位置 $(i,j)$ 的 **车** 至多需要 $2$ 步即可移动到指定位置 $(x,y)$，移动方法如下：

- 对于 **车** 来说，可以从起始位置 $(i,j)$ 先垂直移动到 $(x,j)$，再水平移动到 $(x,y)$，或者先水平移动到 $(i,y)$，再垂直移动到 $(x,y)$；

如果 **白色象、黑皇后** 处在同一条对角线或者 **白色车、黑皇后** 处于同一条线上，此时可能只需要 $1$ 次移动即可捕获 **黑皇后**，根据题意分析如下：

- 如果 **白色象** 与 **黑皇后** 处在同一条对角线时，且此时该路径上无 **白色车** 阻挡时，此时只需移动 $1$ 次即可捕获 **黑皇后**；
- 如果 **白色车** 与 **黑皇后** 处在同一行或者同一列时，且此时二者移动路线之间无 **白色象** 阻挡时，此时只需移动 $1$ 次即可捕获 **黑皇后**；
- 其余情况下，**白色车** 最多需要 $2$ 次移动即可捕获 **黑皇后**；

**代码**

```C
class Solution {
public:
    int minMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f) {
        // 车与皇后处在同一行，且中间没有象
        if (a == e && (c != a || d <= min(b, f) || d >= max(b, f))) {
            return 1;
        }
        // 车与皇后处在同一列，且中间没有象
        if (b == f && (d != b || c <= min(a, e) || c >= max(a, e))) {
            return 1;
        }
        // 象、皇后处在同一条对角线，且中间没有车
        if (abs(c - e) == abs(d - f) && ((c - e) * (b - f) != (a - e) * (d - f) 
            || a < min(c, e) || a > max(c, e))) {
            return 1;
        }
        return 2;
    }
};
```

```Java
class Solution {
    public int minMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f) {
         // 车与皇后处在同一行，且中间没有象
        if (a == e && (c != a || d <= Math.min(b, f) || d >= Math.max(b, f))) {
            return 1;
        }
        // 车与皇后处在同一列，且中间没有象
        if (b == f && (d != b || c <= Math.min(a, e) || c >= Math.max(a, e))) {
            return 1;
        }
        // 象、皇后处在同一条对角线，且中间没有车
        if (Math.abs(c - e) == Math.abs(d - f) && ((c - e) * (b - f) != (a - e) * (d - f) 
            || a < Math.min(c, e) || a > Math.max(c, e))) {
            return 1;
        }
        return 2;
    }
}
```

```CSharp
public class Solution {
    public int MinMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f) {
         // 车与皇后处在同一行，且中间没有象
        if (a == e && (c != a || d <= Math.Min(b, f) || d >= Math.Max(b, f))) {
            return 1;
        }
        // 车与皇后处在同一列，且中间没有象
        if (b == f && (d != b || c <= Math.Min(a, e) || c >= Math.Max(a, e))) {
            return 1;
        }
        // 象、皇后处在同一条对角线，且中间没有车
        if (Math.Abs(c - e) == Math.Abs(d - f) && ((c - e) * (b - f) != (a - e) * (d - f) 
            || a < Math.Min(c, e) || a > Math.Max(c, e))) {
            return 1;
        }
        return 2;
    }
}
```

```Go
func minMovesToCaptureTheQueen(a int, b int, c int, d int, e int, f int) int {
    // 车与皇后处在同一行，且中间没有象
    if a == e && (c != a || d <= min(b, f) || d >= max(b, f)) {
        return 1;
    }
    // 车与皇后处在同一列，且中间没有象
    if b == f && (d != b || c <= min(a, e) || c >= max(a, e)) {
        return 1;
    }
    // 象、皇后处在同一条对角线，且中间没有车
    if abs(c - e) == abs(d - f) && ((c - e) * (b - f) != (a - e) * (d - f) || a < min(c, e) || a > max(c, e)) {
        return 1;
    }
    return 2;
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```Python
class Solution:
    def minMovesToCaptureTheQueen(self, a: int, b: int, c: int, d: int, e: int, f: int) -> int:
        # 车与皇后处在同一行，且中间没有象
        if a == e and (c != a or d <= min(b, f) or d >= max(b, f)):
            return 1
        # 车与皇后处在同一列，且中间没有象
        if b == f and (d != b or c <= min(a, e) or c >= max(a, e)):
            return 1
        # 象、皇后处在同一条对角线，且中间没有车
        if abs(c - e) == abs(d - f) and ((c - e) * (b - f) != (a - e) * (d - f) \
                                         or a < min(c, e) or a > max(c, e)):
            return 1
        return 2
```

```C
int minMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f) {
    // 车与皇后处在同一行，且中间没有象
    if (a == e && (c != a || d <= fmin(b, f) || d >= fmax(b, f))) {
        return 1;
    }
    // 车与皇后处在同一列，且中间没有象
    if (b == f && (d != b || c <= fmin(a, e) || c >= fmax(a, e))) {
        return 1;
    }
    // 象、皇后处在同一条对角线，且中间没有车
    if (abs(c - e) == abs(d - f) && ((c - e) * (b - f) != (a - e) * (d - f) 
        || a < fmin(c, e) || a > fmax(c, e))) {
        return 1;
    }
    return 2;
}
```

```JavaScript
var minMovesToCaptureTheQueen = function(a, b, c, d, e, f) {
    // 车与皇后处在同一行，且中间没有象
    if (a === e && (c !== a || d <= Math.min(b, f) || d >= Math.max(b, f))) {
        return 1;
    }
    // 车与皇后处在同一列，且中间没有象
    if (b === f && (d !== b || c <= Math.min(a, e) || c >= Math.max(a, e))) {
        return 1;
    }
    // 象、皇后处在同一条对角线，且中间没有车
    if (Math.abs(c - e) === Math.abs(d - f) && ((c - e) * (b - f) !== (a - e) * (d - f)
        || a < Math.min(c, e) || a > Math.max(c, e))) {
        return 1;
    }
    return 2;
};
```

```TypeScript
function minMovesToCaptureTheQueen(a: number, b: number, c: number, d: number, e: number, f: number): number {
    // 车与皇后处在同一行，且中间没有象
    if (a === e && (c !== a || d <= Math.min(b, f) || d >= Math.max(b, f))) {
        return 1;
    }
    // 车与皇后处在同一列，且中间没有象
    if (b === f && (d !== b || c <= Math.min(a, e) || c >= Math.max(a, e))) {
        return 1;
    }
    // 象、皇后处在同一条对角线，且中间没有车
    if (Math.abs(c - e) === Math.abs(d - f) && ((c - e) * (b - f) !== (a - e) * (d - f)
        || a < Math.min(c, e) || a > Math.max(c, e))) {
        return 1;
    }
    return 2;
};
```

```Rust
use std::cmp::{min, max};

impl Solution {
    pub fn min_moves_to_capture_the_queen(a: i32, b: i32, c: i32, d: i32, e: i32, f: i32) -> i32 {
        // 车与皇后处在同一行，且中间没有象
        if a == e && (c != a || d <= min(b, f) || d >= max(b, f)) {
            return 1;
        }
        // 车与皇后处在同一列，且中间没有象
        if b == f && (d != b || c <= min(a, e) || c >= max(a, e)) {
            return 1;
        }
        // 象、皇后处在同一条对角线，且中间没有车
        if (c - e).abs() == (d - f).abs() && ((c - e) * (b - f) != (a - e) * (d - f) 
            || a < min(c, e) || a > max(c, e)) {
            return 1;
        }
        2
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
