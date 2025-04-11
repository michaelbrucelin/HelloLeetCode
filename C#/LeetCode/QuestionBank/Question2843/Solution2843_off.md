### [统计对称整数的数目](https://leetcode.cn/problems/count-symmetric-integers/solutions/3636168/tong-ji-dui-cheng-zheng-shu-de-shu-mu-by-layo/)

#### 方法一：枚举

**思路与算法**

枚举从 $low$ 到 $high$ 的所有数字：

- 如果它是两位数并且是 $11$ 的倍数，则它是对称整数。
- 如果它是四位数，则计算千位和百位的和，以及十位和个位的和，如果相等则是对称整数。

最后返回范围内的对称整数的数目。

**代码**

```C++
class Solution {
public:
    int countSymmetricIntegers(int low, int high) {
        int res = 0;
        for (int a = low; a <= high; ++a) {
            if (a < 100 && a % 11 == 0) {
                res++;
            } else if (1000 <= a && a < 10000) {
                int left = a / 1000 + (a % 1000) / 100;
                int right = (a % 100) / 10 + a % 10;
                if (left == right) {
                    res++;
                }
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int countSymmetricIntegers(int low, int high) {
        int res = 0;
        for (int a = low; a <= high; ++a) {
            if (a < 100 && a % 11 == 0) {
                res++;
            } else if (1000 <= a && a < 10000) {
                int left = a / 1000 + (a % 1000) / 100;
                int right = (a % 100) / 10 + a % 10;
                if (left == right) {
                    res++;
                }
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def countSymmetricIntegers(self, low: int, high: int) -> int:
        res = 0
        for a in range(low, high + 1):
            if a < 100 and a % 11 == 0:
                res += 1
            if 1000 <= a < 10000:
                left = a // 1000 + a % 1000 // 100
                right = a % 100 // 10 + a % 10
                if left == right:
                    res += 1
        return res
```

```JavaScript
var countSymmetricIntegers = function(low, high) {
        let res = 0;
    for (let a = low; a <= high; ++a) {
        if (a < 100 && a % 11 === 0) {
            res++;
        } else if (1000 <= a && a < 10000) {
            const left = Math.floor(a / 1000) + Math.floor((a % 1000) / 100);
            const right = Math.floor((a % 100) / 10) + a % 10;
            if (left === right) {
                res++;
            }
        }
    }
    return res;
};
```

```TypeScript
function countSymmetricIntegers(low: number, high: number): number {
    let res = 0;
    for (let a = low; a <= high; ++a) {
        if (a < 100 && a % 11 === 0) {
            res++;
        } else if (1000 <= a && a < 10000) {
            const left = Math.floor(a / 1000) + Math.floor((a % 1000) / 100);
            const right = Math.floor((a % 100) / 10) + a % 10;
            if (left === right) {
                res++;
            }
        }
    }
    return res;
};
```

```Go
func countSymmetricIntegers(low int, high int) int {
    res := 0
    for a := low; a <= high; a++ {
        if a < 100 && a%11 == 0 {
            res++
        } else if 1000 <= a && a < 10000 {
            left := a/1000 + (a%1000)/100
            right := (a%100)/10 + a%10
            if left == right {
                res++
            }
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public int CountSymmetricIntegers(int low, int high) {
        int res = 0;
        for (int a = low; a <= high; ++a) {
            if (a < 100 && a % 11 == 0) {
                res++;
            } else if (1000 <= a && a < 10000) {
                int left = a / 1000 + (a % 1000) / 100;
                int right = (a % 100) / 10 + a % 10;
                if (left == right) {
                    res++;
                }
            }
        }
        return res;
    }
}
```

```C
int countSymmetricIntegers(int low, int high) {
    int res = 0;
    for (int a = low; a <= high; ++a) {
        if (a < 100 && a % 11 == 0) {
            res++;
        } else if (1000 <= a && a < 10000) {
            int left = a / 1000 + (a % 1000) / 100;
            int right = (a % 100) / 10 + a % 10;
            if (left == right) {
                res++;
            }
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn count_symmetric_integers(low: i32, high: i32) -> i32 {
        let mut res = 0;
        for a in low..=high {
            if a < 100 && a % 11 == 0 {
                res += 1;
            } else if 1000 <= a && a < 10000 {
                let left = a / 1000 + (a % 1000) / 100;
                let right = (a % 100) / 10 + a % 10;
                if left == right {
                    res += 1;
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(high-low)$.
- 空间复杂度：$O(1)$.
