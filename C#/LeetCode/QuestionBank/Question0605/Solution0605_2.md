﻿#### [方法一：贪心](https://leetcode.cn/problems/can-place-flowers/solutions/542556/chong-hua-wen-ti-by-leetcode-solution-sojr/)

判断能否在不打破种植规则的情况下在花坛内种入 $n$ 朵花，从贪心的角度考虑，应该在不打破种植规则的情况下种入尽可能多的花，然后判断可以种入的花的最多数量是否大于或等于 $n$。

假设花坛的下标 $i$ 和下标 $j$ 处都种植了花，其中 $j-i \ge 2$，且在下标 $[i+1,j-1]$ 范围内没有种植花，则只有当 $j-i \ge 4$ 时才可以在下标 $i$ 和下标 $j$ 之间种植更多的花，且可以种植花的下标范围是 $[i+2,j-2]$。可以种植花的位置数是 $p=j-i-3$，当 $p$ 是奇数时最多可以在该范围内种植 $(p+1)/2$ 朵花，当 $p$ 是偶数时最多可以在该范围内种植 $p/2$ 朵花。由于当 $p$ 是偶数时，在整数除法的规则下 $p/2$ 和 $(p+1)/2$ 相等，因此无论 $p$ 是奇数还是偶数，都是最多可以在该范围内种植 $(p+1)/2$ 朵花，即最多可以在该范围内种植 $(j-i-2)/2$ 朵花。

上述情况是在已有的两朵花之间种植花的情况（已有的两朵花之间没有别的花）。假设花坛的下标 $l$ 处是最左边的已经种植的花，下标 $r$ 处是最右边的已经种植的花（即对于任意 $k<l$ 或 $k>r$ 都有 $flowerbed[k]=0$），如何计算在下标 $l$ 左边最多可以种植多少朵花以及在下标 $r$ 右边最多可以种植多少朵花？

下标 $l$ 左边有 $l$ 个位置，当 $l<2$ 时无法在下标 $l$ 左边种植花，当 $l \ge 2$ 时可以在下标范围 $[0,l-2]$ 范围内种植花，可以种植花的位置数是 $l-1$，最多可以种植 $l/2$ 朵花。

令 $m$ 为数组 $flowerbed$ 的长度，下标 $r$ 右边有 $m-r-1$ 个位置，可以种植花的位置数是 $m-r-2$，最多可以种植 $(m-r-1)/2$ 朵花。

如果花坛上没有任何花朵，则有 $m$ 个位置可以种植花，最多可以种植 $(m+1)/2$ 朵花。

根据上述计算方法，计算花坛中可以种入的花的最多数量，判断是否大于或等于 $n$ 即可。具体做法如下。

-   维护 $prev$ 表示上一朵已经种植的花的下标位置，初始时 $prev=-1$，表示尚未遇到任何已经种植的花。
-   从左往右遍历数组 $flowerbed$，当遇到 $flowerbed[i]=1$ 时根据 $prev$ 和 $i$ 的值计算上一个区间内可以种植花的最多数量，然后令 $prev=i$，继续遍历数组 $flowerbed$ 剩下的元素。
-   遍历数组 $flowerbed$ 结束后，根据数组 $prev$ 和长度 $m$ 的值计算最后一个区间内可以种植花的最多数量。
-   判断整个花坛内可以种入的花的最多数量是否大于或等于 $n$。

```java
class Solution {
    public boolean canPlaceFlowers(int[] flowerbed, int n) {
        int count = 0;
        int m = flowerbed.length;
        int prev = -1;
        for (int i = 0; i < m; i++) {
            if (flowerbed[i] == 1) {
                if (prev < 0) {
                    count += i / 2;
                } else {
                    count += (i - prev - 2) / 2;
                }
                prev = i;
            }
        }
        if (prev < 0) {
            count += (m + 1) / 2;
        } else {
            count += (m - prev - 1) / 2;
        }
        return count >= n;
    }
}
```

```cpp
class Solution {
public:
    bool canPlaceFlowers(vector<int>& flowerbed, int n) {
        int count = 0;
        int m = flowerbed.size();
        int prev = -1;
        for (int i = 0; i < m; ++i) {
            if (flowerbed[i] == 1) {
                if (prev < 0) {
                    count += i / 2;
                } else {
                    count += (i - prev - 2) / 2;
                }
                prev = i;
            }
        }
        if (prev < 0) {
            count += (m + 1) / 2;
        } else {
            count += (m - prev - 1) / 2;
        }
        return count >= n;
    }
};
```

```javascript
var canPlaceFlowers = function(flowerbed, n) {
    let count = 0;
    const m = flowerbed.length;
    let prev = -1;
    for (let i = 0; i < m; i++) {
        if (flowerbed[i] === 1) {
            if (prev < 0) {
                count += Math.floor(i / 2);
            } else {
                count += Math.floor((i - prev - 2) / 2);
            }
            prev = i;
        }
    }
    if (prev < 0) {
        count += (m + 1) / 2;
    } else {
        count += (m - prev - 1) / 2;
    }
    return count >= n;
};
```

```python
class Solution:
    def canPlaceFlowers(self, flowerbed: List[int], n: int) -> bool:
        count, m, prev = 0, len(flowerbed), -1
        for i in range(m):
            if flowerbed[i] == 1:
                if prev < 0:
                    count += i // 2
                else:
                    count += (i - prev - 2) // 2
                prev = i
        
        if prev < 0:
            count += (m + 1) // 2
        else:
            count += (m - prev - 1) // 2
        
        return count >= n
```

```go
func canPlaceFlowers(flowerbed []int, n int) bool {
    count := 0
    m := len(flowerbed)
    prev := -1
    for i := 0; i < m; i++ {
        if flowerbed[i] == 1 {
            if prev < 0 {
                count += i / 2
            } else {
                count += (i - prev - 2) / 2
            }
            prev = i
        }
    }
    if prev < 0 {
        count += (m + 1) / 2
    } else {
        count += (m - prev - 1) / 2
    }
    return count >= n
}
```

```c
bool canPlaceFlowers(int* flowerbed, int flowerbedSize, int n) {
    int count = 0;
    int prev = -1;
    for (int i = 0; i < flowerbedSize; ++i) {
        if (flowerbed[i] == 1) {
            if (prev < 0) {
                count += i / 2;
            } else {
                count += (i - prev - 2) / 2;
            }
            prev = i;
        }
    }
    if (prev < 0) {
        count += (flowerbedSize + 1) / 2;
    } else {
        count += (flowerbedSize - prev - 1) / 2;
    }
    return count >= n;
}
```

由于只需要判断能否在不打破种植规则的情况下在花坛内种入 $n$ 朵花，不需要具体知道最多可以在花坛内种入多少朵花，因此可以在循环内进行优化，当可以种入的花的数量已经达到 $n$，则可以直接返回 true\\text{true}true，不需要继续计算数组剩下的部分。

```java
class Solution {
    public boolean canPlaceFlowers(int[] flowerbed, int n) {
        int count = 0;
        int m = flowerbed.length;
        int prev = -1;
        for (int i = 0; i < m; i++) {
            if (flowerbed[i] == 1) {
                if (prev < 0) {
                    count += i / 2;
                } else {
                    count += (i - prev - 2) / 2;
                }
                if (count >= n) {
                    return true;
                }
                prev = i;
            }
        }
        if (prev < 0) {
            count += (m + 1) / 2;
        } else {
            count += (m - prev - 1) / 2;
        }
        return count >= n;
    }
}
```

```cpp
class Solution {
public:
    bool canPlaceFlowers(vector<int>& flowerbed, int n) {
        int count = 0;
        int m = flowerbed.size();
        int prev = -1;
        for (int i = 0; i < m; i++) {
            if (flowerbed[i] == 1) {
                if (prev < 0) {
                    count += i / 2;
                } else {
                    count += (i - prev - 2) / 2;
                }
                if (count >= n) {
                    return true;
                }
                prev = i;
            }
        }
        if (prev < 0) {
            count += (m + 1) / 2;
        } else {
            count += (m - prev - 1) / 2;
        }
        return count >= n;
    }
};
```

```javascript
var canPlaceFlowers = function(flowerbed, n) {
    let count = 0;
    const m = flowerbed.length;
    let prev = -1;
    for (let i = 0; i < m; i++) {
        if (flowerbed[i] === 1) {
            if (prev < 0) {
                count += Math.floor(i / 2);
            } else {
                count += Math.floor((i - prev - 2) / 2);
            }
            if (count >= n) {
                return true;
            }
            prev = i;
        }
    }
    if (prev < 0) {
        count += (m + 1) / 2;
    } else {
        count += (m - prev - 1) / 2;
    }
    return count >= n;
};
```

```python
class Solution:
    def canPlaceFlowers(self, flowerbed: List[int], n: int) -> bool:
        count, m, prev = 0, len(flowerbed), -1
        for i in range(m):
            if flowerbed[i] == 1:
                if prev < 0:
                    count += i // 2
                else:
                    count += (i - prev - 2) // 2
                if count >= n:
                    return True
                prev = i
        
        if prev < 0:
            count += (m + 1) // 2
        else:
            count += (m - prev - 1) // 2
        
        return count >= n
```

```go
func canPlaceFlowers(flowerbed []int, n int) bool {
    count := 0
    m := len(flowerbed)
    prev := -1
    for i := 0; i < m; i++ {
        if flowerbed[i] == 1 {
            if prev < 0 {
                count += i / 2
            } else {
                count += (i - prev - 2) / 2
            }
            if count >= n {
                return true
            }
            prev = i
        }
    }
    if prev < 0 {
        count += (m + 1) / 2
    } else {
        count += (m - prev - 1) / 2
    }
    return count >= n
}
```

```c
bool canPlaceFlowers(int* flowerbed, int flowerbedSize, int n) {
    int count = 0;
    int prev = -1;
    for (int i = 0; i < flowerbedSize; i++) {
        if (flowerbed[i] == 1) {
            if (prev < 0) {
                count += i / 2;
            } else {
                count += (i - prev - 2) / 2;
            }
            if (count >= n) {
                return true;
            }
            prev = i;
        }
    }
    if (prev < 0) {
        count += (flowerbedSize + 1) / 2;
    } else {
        count += (flowerbedSize - prev - 1) / 2;
    }
    return count >= n;
}
```

**复杂度分析**

-   时间复杂度：$O(m)$，其中 $m$ 是数组 $flowerbed$ 的长度。需要遍历数组一次。
-   空间复杂度：$O(1)$。额外使用的空间为常数。
