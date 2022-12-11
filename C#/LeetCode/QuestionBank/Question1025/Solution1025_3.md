#### [方法二：动态规划](https://leetcode.cn/problems/divisor-game/solutions/344153/chu-shu-bo-yi-by-leetcode-solution/)

**思路与算法**

在「方法一」中，我们写出了前面几项的答案，在这个过程中我们发现，Alice 处在 n = k 的状态时，他（她）做一步操作，必然使得 Bob 处于 n = m (m < k) 的状态。因此我们只要看是否存在一个 m 是必败的状态，那么 Alice 直接执行对应的操作让当前的数字变成 m，Alice 就必胜了，如果没有任何一个是必败的状态的话，说明 Alice 无论怎么进行操作，最后都会让 Bob 处于必胜的状态，此时 Alice 是必败的。

结合以上我们定义 f[i] 表示当前数字 i 的时候先手是处于必胜态还是必败态，true 表示先手必胜，false 表示先手必败，从前往后递推，根据我们上文的分析，枚举 i 在 (0, i) 中 i 的因数 j，看是否存在 f[i−j] 为必败态即可。

代码如下。

**代码**

```cpp
class Solution {
public:
    bool divisorGame(int n) {
        vector<int> f(n + 5, false);

        f[1] = false;
        f[2] = true;
        for (int i = 3; i <= n; ++i) {
            for (int j = 1; j < i; ++j) {
                if (i % j == 0 && !f[i - j]) {
                    f[i] = true;
                    break;
                }
            }
        }

        return f[n];
    }
};
```

```java
class Solution {
    public boolean divisorGame(int n) {
        boolean[] f = new boolean[n + 5];

        f[1] = false;
        f[2] = true;
        for (int i = 3; i <= n; ++i) {
            for (int j = 1; j < i; ++j) {
                if ((i % j) == 0 && !f[i - j]) {
                    f[i] = true;
                    break;
                }
            }
        }

        return f[n];
    }
}
```

```go
func divisorGame(n int) bool {
    f := make([]bool, n + 5)
    f[1], f[2] = false, true
    for i := 3; i <= n; i++ {
        for j := 1; j < i; j++ {
            if i % j == 0 && !f[i - j] {
                f[i] = true
                break
            }
        }
    }
    return f[n]
}
```

```c
bool divisorGame(int n) {
    int f[n + 5];
    memset(f, 0, sizeof(f));

    f[1] = false;
    f[2] = true;
    for (int i = 3; i <= n; ++i) {
        for (int j = 1; j < i; ++j) {
            if (i % j == 0 && !f[i - j]) {
                f[i] = true;
                break;
            }
        }
    }

    return f[n];
}
```

**复杂度分析**

-   时间复杂度：$O(n^2)$。递推的时候一共有 n 个状态要计算，每个状态需要 $O(n)$ 的时间枚举因数，因此总时间复杂度为 $O(n^2)$。
-   空间复杂度：$O(n)$。我们需要 $O(n)$ 的空间存储递推数组 f 的值。
