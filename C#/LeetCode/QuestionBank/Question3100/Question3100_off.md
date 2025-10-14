### [换水问题 II](https://leetcode.cn/problems/water-bottles-ii/solutions/3789673/huan-shui-wen-ti-ii-by-leetcode-solution-9eiq/)

#### 方法一：模拟

**思路与算法**

题目描述 $numExchange$ 个空瓶可以换一瓶水，随后 $numExchange$ 的值加一，问总共可以喝到几瓶水。

我们可以直接按照题目描述进行模拟，只要剩下的空瓶数量 $empty\ge numExchange$，就可以换到一瓶水，算上这瓶水喝完后的空瓶，$empty$ 的数量减少了 $numExchange-1$ 个。

**代码**

```C++
class Solution {
public:
    int maxBottlesDrunk(int numBottles, int numExchange) {
        int ans = numBottles;
        for (int empty = numBottles; empty >= numExchange; numExchange++) {
            ans++;
            empty -= numExchange - 1;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maxBottlesDrunk(int numBottles, int numExchange) {
        int ans = numBottles;
        for (int empty = numBottles; empty >= numExchange; numExchange++) {
            ans++;
            empty -= numExchange - 1;
        }
        return ans;
    }
}

```

```Python
class Solution:
    def maxBottlesDrunk(self, numBottles: int, numExchange: int) -> int:
        ans = numBottles
        empty = numBottles
        while empty >= numExchange:
            ans += 1
            empty -= numExchange - 1
            numExchange += 1
        return ans

```

```Go
func maxBottlesDrunk(numBottles int, numExchange int) int {
    ans := numBottles
    for empty := numBottles; empty >= numExchange; numExchange++ {
        ans++
        empty -= numExchange - 1
    }
    return ans
}
```

```C
int maxBottlesDrunk(int numBottles, int numExchange) {
    int ans = numBottles;
    int empty = numBottles;
    while (empty >= numExchange) {
        ans++;
        empty -= numExchange - 1;
        numExchange++;
    }
    return ans;
}
```

```CSharp
public class Solution {
    public int MaxBottlesDrunk(int numBottles, int numExchange) {
        int ans = numBottles;
        int empty = numBottles;
        while (empty >= numExchange) {
            ans++;
            empty -= numExchange - 1;
            numExchange++;
        }
        return ans;
    }
}
```

```JavaScript
var maxBottlesDrunk = function(numBottles, numExchange) {
    let ans = numBottles;
    let empty = numBottles;
    while (empty >= numExchange) {
        ans++;
        empty -= numExchange - 1;
        numExchange++;
    }
    return ans;
};
```

```TypeScript
function maxBottlesDrunk(numBottles: number, numExchange: number): number {
    let ans = numBottles;
    let empty = numBottles;
    while (empty >= numExchange) {
        ans++;
        empty -= numExchange - 1;
        numExchange++;
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn max_bottles_drunk(num_bottles: i32, mut num_exchange: i32) -> i32 {
        let mut ans = num_bottles;
        let mut empty = num_bottles;
        while empty >= num_exchange {
            ans += 1;
            empty -= num_exchange - 1;
            num_exchange += 1;
        }
        ans
    }
}
```

**复杂度分析**

令 $numBottles=n$，$numExchange=k$。

- 时间复杂度：$O(\sqrt{n})$。设空瓶换水次数，即循环次数为 $t$ 次，则前 $t$ 次换水总共从 $empty$ 中减去的量为 $S(t)=\sum\limits_{i=0}^{t-1}(k+i-1)=t(k-1)+\dfrac{t(t-1)}{2}$。由于 $S(t)\le n$，代入上式化简得 $t^2+(2\cdot k-3)t-2\cdot n\le 0$，因此 $t$ 的上界为 $O(\sqrt{n})$。
- 空间复杂度：$O(1)$。仅使用了若干额外变量。

#### 方法二：数学

**思路与算法**

参考方法一复杂度分析中对时间复杂度的分析，我们可以采用解方程的思想直接解出答案。

令空瓶换水次数为 $t$，交换的总空瓶数为 $empty$，产生的总空瓶数为 $total$，则有 $empty\le total$。我们要找到最大的 $t$ 使得不等式成立。

考虑 $empty$。由于每次换水所需的空瓶数量都增加 $1$，其值等于 $empty=\sum\limits_{i=0}^{t-1}(numExchange+i)$。利用等差数列求和公式可得 $empty=t\cdot numExchange+t(t-1)/2$。而 $total$ 就等于 $numBottles+t$，代入不等式得 $t\cdot numExchange+t(t-1)/2-(numBottles+t)\le 0$。使用一元二次方程求根公式解出 $t$ 值即可。

**代码**

```C++
class Solution {
public:
    int maxBottlesDrunk(int numBottles, int numExchange) {
        int a = 1;
        int b = 2 * numExchange - 3;
        int c = -2 * numBottles;
        double delta = (double)b * b - 4.0 * a * c;
        int t = (int)ceil(( -b + sqrt(delta)) / (2.0 * a));
        return numBottles + t - 1;
    }
};
```

```Java
class Solution {
    public int maxBottlesDrunk(int numBottles, int numExchange) {
        int t = 0;
        int empty = t * numExchange + t * (t - 1) / 2;
        int total = numBottles + t;
        int a = 1;
        int b = 2 * numExchange - 3;
        int c = -2 * numBottles;
        t = (int) Math.ceil(((-b + Math.sqrt(b * b - 4 * a * c)) / (2 * a)));
        return numBottles + t - 1;
    }
}
```

```Python
class Solution:
    def maxBottlesDrunk(self, numBottles: int, numExchange: int) -> int:
        a = 1
        b = 2 * numExchange - 3
        c = -2 * numBottles
        delta = b * b - 4 * a * c
        t = math.ceil((-b + math.sqrt(delta)) / (2 * a))
        return numBottles + t - 1

```

```Go
func maxBottlesDrunk(numBottles int, numExchange int) int {
    a := 1
    b := 2*numExchange - 3
    c := -2 * numBottles
    delta := float64(b*b - 4*a*c)
    t := int(math.Ceil((-float64(b) + math.Sqrt(delta)) / (2.0 * float64(a))))
    return numBottles + t - 1
}
```

```C
int maxBottlesDrunk(int numBottles, int numExchange) {
    int a = 1;
    int b = 2 * numExchange - 3;
    int c = -2 * numBottles;
    double delta = (double)b * b - 4.0 * a * c;
    int t = (int)ceil((-b + sqrt(delta)) / (2.0 * a));
    return numBottles + t - 1;
}
```

```CSharp
public class Solution {
    public int MaxBottlesDrunk(int numBottles, int numExchange) {
        int a = 1;
        int b = 2 * numExchange - 3;
        int c = -2 * numBottles;
        double delta = (double)b * b - 4.0 * a * c;
        int t = (int)Math.Ceiling((-b + Math.Sqrt(delta)) / (2.0 * a));
        return numBottles + t - 1;
    }
}
```

```JavaScript
var maxBottlesDrunk = function(numBottles, numExchange) {
    let a = 1;
    let b = 2 * numExchange - 3;
    let c = -2 * numBottles;
    let delta = b * b - 4 * a * c;
    let t = Math.ceil((-b + Math.sqrt(delta)) / (2 * a));
    return numBottles + t - 1;
};
```

```TypeScript
function maxBottlesDrunk(numBottles: number, numExchange: number): number {
    let a = 1;
    let b = 2 * numExchange - 3;
    let c = -2 * numBottles;
    let delta = b * b - 4 * a * c;
    let t = Math.ceil((-b + Math.sqrt(delta)) / (2 * a));
    return numBottles + t - 1;
};
```

```Rust
impl Solution {
    pub fn max_bottles_drunk(num_bottles: i32, num_exchange: i32) -> i32 {
        let a = 1.0;
        let b = (2 * num_exchange - 3) as f64;
        let c = (-2 * num_bottles) as f64;
        let delta = b * b - 4.0 * a * c;
        let t = ((-b + delta.sqrt()) / (2.0 * a)).ceil() as i32;
        num_bottles + t - 1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。结果直接计算得出。
- 空间复杂度：$O(1)$。仅使用了若干额外变量。
