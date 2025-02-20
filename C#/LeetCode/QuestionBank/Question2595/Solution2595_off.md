### [奇偶位数](https://leetcode.cn/problems/number-of-even-and-odd-bits/solutions/3065366/qi-ou-wei-shu-by-leetcode-solution-v0cc/)

#### 方法一：位运算

**思路与算法**

用$i=0$表示当前位是奇数位，$i=1$表示当前位是偶数位，并记录对应奇偶数位的结果。

当$n>0$时，如果当前位是$1$，则增加对应奇偶位的计数，然后反转$i$并将$n$作右移位运算。

循环以上过程，直到$n=0$，最后返回结果。

**代码**

```C++
class Solution {
public:
    vector<int> evenOddBit(int n) {
        vector<int> res = {0, 0};
        int i = 0;
        while (n) {
            res[i] += n & 1;
            n >>= 1;
            i ^= 1;
        }
        return res;
    }
};
```

```Java
class Solution {
    public int[] evenOddBit(int n) {
        int[] res = new int[2];
        int i = 0;
        while (n > 0) {
            res[i] += n & 1;
            n >>= 1;
            i ^= 1;
        }
        return res;
    }
}
```

```Python
class Solution:
    def evenOddBit(self, n: int) -> List[int]:
        res = [0, 0]
        i = 0
        while n:
            res[i] += n & 1
            n >>= 1
            i = i ^ 1
        return res
```

```JavaScript
var evenOddBit = function(n) {
    const res = [0, 0];
    let i = 0;
    while (n > 0) {
        res[i] += n & 1;
        n >>= 1;
        i ^= 1;
    }
    return res;
};
```

```TypeScript
function evenOddBit(n: number): number[] {
    const res = [0, 0];
    let i = 0;
    while (n > 0) {
        res[i] += n & 1;
        n >>= 1;
        i ^= 1;
    }
    return res;
};
```

```Go
func evenOddBit(n int) []int {
    res := []int{0, 0}
    i := 0
    for n > 0 {
        res[i] += n & 1
        n >>= 1
        i ^= 1
    }
    return res
}
```

```CSharp
public class Solution {
    public int[] EvenOddBit(int n) {
        int[] res = new int[2];
        int i = 0;
        while (n > 0) {
            res[i] += n & 1;
            n >>= 1;
            i ^= 1;
        }
        return res;
    }
}
```

```C
int* evenOddBit(int n, int* returnSize) {
    *returnSize = 2;
    int* res = (int*)malloc(sizeof(int) * 2);
    res[0] = 0;
    res[1] = 0;
    int i = 0;
    while (n > 0) {
        res[i] += n & 1;
        n >>= 1;
        i ^= 1;
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn even_odd_bit(n: i32) -> Vec<i32> {
        let mut res = vec![0, 0];
        let mut i = 0;
        let mut n_mut = n;
        while n_mut > 0 {
            res[i as usize] += n_mut & 1;
            n_mut >>= 1;
            i ^= 1;
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$。
- 空间复杂度：$O(1)$。
