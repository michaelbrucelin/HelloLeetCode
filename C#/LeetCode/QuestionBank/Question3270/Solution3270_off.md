### [求出数字答案](https://leetcode.cn/problems/find-the-key-of-the-numbers/solutions/3036325/qiu-chu-shu-zi-da-an-by-leetcode-solutio-84cv/)

#### 方法一：枚举

**思路与算法**

我们可以从低到高枚举三个数的数位，三者的最小值就是答案 $key$ 对应数位上的值。无需补充前导 $0$，因为当某个数在当前枚举的数位上没有值时，后续数位的最小值都为 $0$，对于答案 $key$ 就是需要删去的前导 $0$。

**代码**

```C++
class Solution {
public:
    int generateKey(int num1, int num2, int num3) {
        int key = 0;
        for (int p = 1; num1 && num2 && num3; p *= 10) {
            key += min({num1 % 10, num2 % 10, num3 % 10}) * p;
            num1 /= 10;
            num2 /= 10;
            num3 /= 10;
        }
        return key;
    }
};
```

```Java
class Solution {
    public int generateKey(int num1, int num2, int num3) {
        int key = 0;
        for (int p = 1; num1 > 0 && num2 > 0 && num3 > 0; p *= 10) {
            key += Math.min(Math.min(num1 % 10, num2 % 10), num3 % 10) * p;
            num1 /= 10;
            num2 /= 10;
            num3 /= 10;
        }
        return key;
    }
}
```

```CSharp
public class Solution {
    public int GenerateKey(int num1, int num2, int num3) {
        int key = 0;
        for (int p = 1; num1 > 0 && num2 > 0 && num3 > 0; p *= 10) {
            key += Math.Min(Math.Min(num1 % 10, num2 % 10), num3 % 10) * p;
            num1 /= 10;
            num2 /= 10;
            num3 /= 10;
        }
        return key;
    }
}
```

```Go
func generateKey(num1 int, num2 int, num3 int) int {
    key := 0
    for p := 1; num1 > 0 && num2 > 0 && num3 > 0; p *= 10 {
        key += min(num1 % 10, min(num2 % 10, num3 % 10)) * p
        num1, num2, num3 = num1 / 10, num2 / 10, num3 / 10
    }
    return key
}
```

```Python
class Solution:
    def generateKey(self, num1: int, num2: int, num3: int) -> int:
        key, p = 0, 1
        while num1 and num2 and num3:
            key += min(num1 % 10, num2 % 10, num3 % 10) * p
            p *= 10
            num1, num2, num3 = num1 // 10, num2 // 10, num3 // 10
        return key
```

```C
int generateKey(int num1, int num2, int num3) {
    int key = 0;
    for (int p = 1; num1 && num2 && num3; p *= 10) {
        key += fmin(num1 % 10, fmin(num2 % 10, num3 % 10)) * p;
        num1 /= 10;
        num2 /= 10;
        num3 /= 10;
    }
    return key;
}
```

```JavaScript
var generateKey = function(num1, num2, num3) {
    let key = 0;
    for (let p = 1; num1 > 0 && num2 > 0 && num3 > 0; p *= 10) {
        key += Math.min(num1 % 10, num2 % 10, num3 % 10) * p;
        num1 = Math.floor(num1 / 10);
        num2 = Math.floor(num2 / 10);
        num3 = Math.floor(num3 / 10);
    }
    return key;
};
```

```TypeScript
function generateKey(num1: number, num2: number, num3: number): number {
    let key = 0;
    for (let p = 1; num1 > 0 && num2 > 0 && num3 > 0; p *= 10) {
        key += Math.min(num1 % 10, num2 % 10, num3 % 10) * p;
        num1 = Math.floor(num1 / 10);
        num2 = Math.floor(num2 / 10);
        num3 = Math.floor(num3 / 10);
    }
    return key;
}
```

```Rust
use std::cmp::min;
impl Solution {
    pub fn generate_key(mut num1: i32, mut num2: i32, mut num3: i32) -> i32 {
        let mut key = 0;
        let mut p = 1;
        while num1 > 0 && num2 > 0 && num3 > 0 {
            key += min(min(num1 % 10, num2 % 10), num3 % 10) * p;
            num1 /= 10;
            num2 /= 10;
            num3 /= 10;
            p *= 10;
        }
        key
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $key$ 的数位长度。
- 空间复杂度：$O(1)$。
