#### [方法一：动态规划](https://leetcode.cn/problems/count-sorted-vowel-strings/solutions/2195462/tong-ji-zi-dian-xu-yuan-yin-zi-fu-chuan-sk7y1/)

分别使用数字 $0$，$1$，$2$，$3$，$4$ 代表元音字符 $'a'$，$'e'$，$'i'$，$'o'$，$'u'$。记 $dp[i][j]$ 表示长度为 $i+1$，以 $j$ 结尾的按字典序排列的字符串数量，那么状态转移方程如下：

$$dp[i][j] = \begin{cases} 1 &\qquad i = 0 \\ \sum^j_{k=0}{dp[i - 1][k]} & \qquad i \gt 0\\ \end{cases}$$

因此长度为 $n$ 的按字典序排列的字符串数量为 $\sum_{k=0}^{4}{dp[n-1][j]}$。因为 $dp[i]$ 的计算只涉及 $dp[i−1]$ 部分的数据，同时 $dp[i]$ 等价于 $dp[i-1]$ 的前缀和，我们可以只使用一维数组进行存储，同时在一维数组进行原地修改。

> 读者可以思考一下矩阵快速幂的做法。

```python
class Solution:
    def countVowelStrings(self, n: int) -> int:
        dp = [1] * 5
        for _ in range(n - 1):
            for j in range(1, 5):
                dp[j] += dp[j - 1]
        return sum(dp)
```

```cpp
class Solution {
public:
    int countVowelStrings(int n) {
        vector<int> dp(5, 1);
        for (int i = 1; i < n; i++) {
            for (int j = 1; j < 5; j++) {
                dp[j] += dp[j - 1];
            }
        }
        return accumulate(dp.begin(), dp.end(), 0);
    }
};
```

```java
class Solution {
    public int countVowelStrings(int n) {
        int[] dp = new int[5];
        Arrays.fill(dp, 1);
        for (int i = 1; i < n; i++) {
            for (int j = 1; j < 5; j++) {
                dp[j] += dp[j - 1];
            }
        }
        return Arrays.stream(dp).sum();
    }
}
```

```csharp
public class Solution {
    public int CountVowelStrings(int n) {
        int[] dp = new int[5];
        Array.Fill(dp, 1);
        for (int i = 1; i < n; i++) {
            for (int j = 1; j < 5; j++) {
                dp[j] += dp[j - 1];
            }
        }
        return dp.Sum();
    }
}
```

```c
int countVowelStrings(int n) {
    int dp[5];
    for (int i = 0; i < 5; i++) {
        dp[i] = 1;
    }
    for (int i = 1; i < n; i++) {
        for (int j = 1; j < 5; j++) {
            dp[j] += dp[j - 1];
        }
    }
    int ret = 0;
    for (int i = 0; i < 5; i++) {
        ret += dp[i];
    }
    return ret;
}
```

```javascript
var countVowelStrings = function(n) {
    const dp = new Array(5).fill(1);
    for (let i = 1; i < n; i++) {
        for (let j = 1; j < 5; j++) {
            dp[j] += dp[j - 1];
        }
    }
    return _.sum(dp);
};
```

```go
func countVowelStrings(n int) int {
    dp := [5]int{}
    for i := 0; i < 5; i++ {
        dp[i] = 1
    }
    for i := 1; i < n; i++ {
        for j := 1; j < 5; j++ {
            dp[j] += dp[j-1]
        }
    }
    ret := 0
    for i := 0; i < 5; i++ {
        ret += dp[i]
    }
    return ret
}
```

**复杂度分析**

-   时间复杂度：$O(n \times \Sigma)$，其中 $n$ 是字符串的长度，$\Sigma = 5$ 表示元音字符集大小。
-   空间复杂度：$O(\Sigma)$。
