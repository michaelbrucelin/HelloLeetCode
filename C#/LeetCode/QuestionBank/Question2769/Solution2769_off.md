### [找出最大的可达成数字](https://leetcode.cn/problems/find-the-maximum-achievable-number/solutions/2779918/zhao-chu-zui-da-de-ke-da-cheng-shu-zi-by-pgip/)

#### 方法一：直接计算

##### 思路与算法

题目要求得一个最大的整数 $x$，使其在不超过 $t$ 次操作内变成与 $\textit{num}$ 相等的数字。每次操作可以选择将 $x$ 增加或减少 $1$，同时可以选择将 $\textit{num}$ 增加或减少 $1$。

因此，$x$ 最大可以为 $\textit{num} + 2t$。

##### 代码

```python
class Solution:
    def theMaximumAchievableX(self, num: int, t: int) -> int:
        return num + 2 * t
```

```java
class Solution {
    public int theMaximumAchievableX(int num, int t) {
        return num + 2 * t;
    }
}
```

```csharp
public class Solution {
    public int TheMaximumAchievableX(int num, int t) {
        return num + 2 * t;
    }
}
```

```c++
class Solution {
public:
    int theMaximumAchievableX(int num, int t) {
        return num + 2 * t;
    }
};
```

```c
int theMaximumAchievableX(int num, int t){
    return num + 2 * t;
}
```

```go
func theMaximumAchievableX(num int, t int) int {
    return num + 2 * t
}
```

```javascript
var theMaximumAchievableX = function(num, t) {
    return num + 2 * t;
};
```

```typescript
function theMaximumAchievableX(num: number, t: number): number {
    return num + 2 * t;
};
```

```rust
impl Solution {
    pub fn the_maximum_achievable_x(num: i32, t: i32) -> i32 {
        num + 2 * t
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
