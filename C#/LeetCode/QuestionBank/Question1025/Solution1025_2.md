#### [方法一：数学](https://leetcode.cn/problems/divisor-game/solutions/344153/chu-shu-bo-yi-by-leetcode-solution/)

**思路与算法**

博弈类的问题常常让我们摸不着头脑。当我们没有解题思路的时候，不妨试着写几项试试：
-   n = 1 的时候，区间 (0, 1) 中没有整数是 n 的因数，所以此时 Alice 败。
-   n = 2 的时候，Alice 只能拿 1，n 变成 1，Bob 无法继续操作，故 Alice 胜。
-   n = 3 的时候，Alice 只能拿 1，n 变成 2，根据 n = 2 的结论，我们知道此时 Bob 会获胜，Alice 败。
-   n = 4 的时候，Alice 能拿 1 或 2，如果 Alice 拿 1，根据 n = 3 的结论，Bob 会失败，Alice 会获胜。
-   n = 5 的时候，Alice 只能拿 1，根据 n = 4 的结论，Alice 会失败。
-   ......

写到这里，也许你有了一些猜想。没关系，请大胆地猜想，在这种情况下大胆地猜想是 AC 的第一步。也许你会发现这样一个现象：**n 为奇数的时候 Alice（先手）必败，n 为偶数的时候 Alice 必胜。** 这个猜想是否正确呢？下面我们来想办法证明它。

**证明**
1.  n = 1 和 n = 2 时结论成立。
2.  n > 2 时，假设 $n \leq k$ 时该结论成立，则 n = k + 1 时：
    -   如果 k 为偶数，则 k + 1 为奇数，x 是 k + 1 的因数，只可能是奇数，而奇数减去奇数等于偶数，且 $k + 1 - x \leq k$，故轮到 Bob 的时候都是偶数。而根据我们的猜想假设 $n\le k$ 的时候偶数的时候先手必胜，故此时无论 Alice 拿走什么，Bob 都会处于必胜态，所以 Alice 处于必败态。
    -   如果 k 为奇数，则 k + 1 为偶数，x 可以是奇数也可以是偶数，若 Alice 减去一个奇数，那么 k + 1 - x 是一个小于等于 k 的奇数，此时 Bob 占有它，处于必败态，则 Alice 处于必胜态。

综上所述，这个猜想是正确的。

下面是代码实现。

**代码**

```cpp
class Solution {
public:
    bool divisorGame(int n) {
        return n % 2 == 0;
    }
};
```

```java
class Solution {
    public boolean divisorGame(int n) {
        return n % 2 == 0;
    }
}
```

```go
func divisorGame(n int) bool {
    return n % 2 == 0
}
```

```c
bool divisorGame(int n) {
    return n % 2 == 0;
}
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
