### [收集足够苹果的最小花园周长](https://leetcode.cn/problems/minimum-garden-perimeter-to-collect-enough-apples/solutions/908396/shou-ji-zu-gou-ping-guo-de-zui-xiao-hua-1rjsw/)

#### 方法一：枚举

##### 提示 $1$

如果正方形土地的右上角坐标为 $(n, n)$，即边长为 $2n$，周长为 $8n$，那么其中包含的苹果总数为：

$$S_n = 2n(n+1)(2n+1)$$

##### 提示 $1$ 解释

对于坐标为 $(x, y)$ 的树，它有 $|x| + |y|$ 个苹果。因此，一块右上角坐标为 $(n, n)$ 的正方形土地包含的苹果总数为：

$$S_n = \sum_{x=-n}^n \sum_{y=-n}^n |x| + |y|$$

由于 $x$ 和 $y$ 是对称的，因此：

$$\begin{aligned} S_n &= 2 \sum_{x=-n}^n \sum_{y=-n}^n |x| \\ &= 2 \sum_{x=-n}^n (2n+1) |x| \\ &= 2(2n+1) \sum_{x=-n}^n |x| \\ &= 2n(n+1)(2n+1) \end{aligned}$$

##### 思路与算法

我们从小到大枚举 $n$，直到 $2n(n+1)(2n+1) \geq neededApples$ 为止。

##### 代码

```c++
class Solution {
public:
    long long minimumPerimeter(long long neededApples) {
        long long n = 1;
        for(; 2 * n * (n + 1) * (2 * n + 1) < neededApples; ++n);
        return n * 8;
    }
};
```

```python
class Solution:
    def minimumPerimeter(self, neededApples: int) -> int:
        n = 1
        while 2 * n * (n + 1) * (2 * n + 1) < neededApples:
            n += 1
        return n * 8
```

```java
class Solution {
    public long minimumPerimeter(long neededApples) {
        long n = 1;
        while (2 * n * (n + 1) * (2 * n + 1) < neededApples) {
            n++;
        }
        return n * 8;
    }
}
```

```csharp
public class Solution {
    public long MinimumPerimeter(long neededApples) {
        long n = 1;
        while (2 * n * (n + 1) * (2 * n + 1) < neededApples) {
            n++;
        }
        return n * 8;
    }
}
```

```c
long long minimumPerimeter(long long neededApples) {
    long long n = 1;
    while (2 * n * (n + 1) * (2 * n + 1) < neededApples) {
        n++;
    }
    return n * 8;
}
```

```go
func minimumPerimeter(neededApples int64) int64 {
    n := int64(1)
    for 2 * n * (n + 1) * (2 * n + 1) < neededApples {
        n++
    }
    return n * 8
}
```

```javascript
var minimumPerimeter = function(neededApples) {
    let n = 1;
    while (2 * n * (n + 1) * (2 * n + 1) < neededApples) {
        n++;
    }
    return n * 8;
};
```

#### 复杂度分析

- 时间复杂度：$O(m^{1/3})$，其中 $m$ 表示题目中的 $neededApples$。可以发现，$S_n$ 是关于 $n$ 的三次函数，因此需要枚举的 $n$ 的数量级为 $O(m^{1/3})$。
- 空间复杂度：$O(1)$。

#### 方法二：二分查找

##### 思路与算法

由于 $S_n$ 是随着 $n$ 单调递增的，那么我们可以通过二分查找的方法，找出最小的满足 $S_n \geq neededApples$ 的 $n$ 值即为答案。

##### 细节

二分查找的下界可以直接置为 $1$，而上界 $right$ 需要保证有 $S_right \geq neededApples$。根据方法一，我们只需要令 $right = \lfloor neededApples^{1/3} \rfloor$ 即可，其中 $\lfloor \cdot \rfloor$ 表示向下取整。但由于大部分语言中立方根运算较难实现，在实际的编码中，我们可以取一个更加宽松的上界，例如 $neededApples^{1/3}$ 最大值 $10^{15}$ 的立方根 $10^5$。

##### 代码

```c++
class Solution {
public:
    long long minimumPerimeter(long long neededApples) {
        long long left = 1, right = 100000, ans = 0;
        while (left <= right) {
            long long mid = (left + right) / 2;
            if (2 * mid * (mid + 1) * (mid * 2 + 1) >= neededApples) {
                ans = mid;
                right = mid - 1;
            }
            else {
                left = mid + 1;
            }
        }
        return ans * 8;
    }
};
```

```python
class Solution:
    def minimumPerimeter(self, neededApples: int) -> int:
        left, right, ans = 1, 100000, 0
        while left <= right:
            mid = (left + right) // 2
            if 2 * mid * (mid + 1) * (mid * 2 + 1) >= neededApples:
                ans = mid
                right = mid - 1
            else:
                left = mid + 1
        return ans * 8
```

```c
long long minimumPerimeter(long long neededApples) {
    long long left = 1, right = 100000, ans = 0;
    while (left <= right) {
        long long mid = (left + right) / 2;
        if (2 * mid * (mid + 1) * (mid * 2 + 1) >= neededApples) {
            ans = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return ans * 8;
}
```

```java
class Solution {
    public long minimumPerimeter(long neededApples) {
        long left = 1, right = 100000, ans = 0;
        while (left <= right) {
            long mid = (left + right) / 2;
            if (2 * mid * (mid + 1) * (mid * 2 + 1) >= neededApples) {
                ans = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return ans * 8;
    }
}
```

```csharp
public class Solution {
    public long MinimumPerimeter(long neededApples) {
        long left = 1, right = 100000, ans = 0;
        while (left <= right) {
            long mid = (left + right) / 2;
            if (2 * mid * (mid + 1) * (mid * 2 + 1) >= neededApples) {
                ans = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return ans * 8;
    }
}
```

```go
func minimumPerimeter(neededApples int64) int64 {
    left, right := int64(1), int64(100000)
    ans := int64(0)
    for left <= right {
        mid := (left + right) / 2
        if 2 * mid * (mid + 1) * (mid * 2 + 1) >= neededApples {
            ans = mid
            right = mid - 1
        } else {
            left = mid + 1
        }
    }
    return ans * 8
}
```

```javascript
var minimumPerimeter = function(neededApples) {
    let left = 1, right = 100000, ans = 0;
    while (left <= right) {
        const mid = (left + right) >> 1;
        if (2 * mid * (mid + 1) * (mid * 2 + 1) >= neededApples) {
            ans = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return ans * 8;
};
```

#### 复杂度分析

- 时间复杂度：$O(\log m)$，其中 $m$ 表示题目中的 $neededApples$，即为二分查找需要的时间。
- 空间复杂度：$O(1)$。
