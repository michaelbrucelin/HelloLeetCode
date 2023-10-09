### [最小和分割](https://leetcode.cn/problems/split-with-minimum-sum/solutions/2470641/zui-xiao-he-fen-ge-by-leetcode-solution-6fde/)

#### 方法一：贪心

**思路与算法**

当我们将给定的 $num$ 分成 $num_1$ 和 $num_2$ 时，$num_1$ 中的数字应该是单调递增的。否则，例如 $nums_1 = 1243$，我们将 $4$ 和 $3$ 交换可以得到更小的值。同理，$nums_2$ 中的数字也应该是单调递增的。

接下来我们考虑 $num_1$ 和 $num_2$ 之间的情况。设 $num_1$ 中有一个数字 $x$ 是从低到高的第 $p~(p \geq 0)$ 位，表示 $x \times 10^p$，$num_2$ 中有一个数字 $y$ 是从低到高的低 $q$ 位，表示 $y \times 10^q$。我们交换 $x$ 和 $y$，不应该得到更小的值，因此有：

$$x \times 10^p + y \times 10^q \leq x \times 10^q + y \times 10^p$$

即：

$$(x - y) \times (10^p - 10^q) \leq 0$$

也就是说：

> 如果 $x$ 的位数更高（即 $10^p \geq 10^q$，那么 $x$ 必须不能大于 $y$）；如果 $y$ 的位数更高，那么 $y$ 必须不能大于 $x$。

结合之前得出的 $num_1$ 和 $num_2$ 分别是单调递增的，这就告诉我们：

> 任何一个数字，都不能大于任何一个数中比它位数更小的数字。

当 $num_1$ 和 $num_2$ 位数不相等时，我们需要补上前导零使得它们位数相等。例如，$1234$ 和 $5$ 是满足上述要求的，但 $234$ 和 $15$ 的和显然更小，这是因为我们需要把 $5$ 看成 $0005$，那么 $1234$ 中的 $1$ 与 $0[00]5$ 中括号部分的两个 $0$ 是不满足要求的。这也就告诉我们，$num_1$ 和 $num_2$ 的位数差不能超过 $1$，否则位数少的那个数能补上至少 $2$ 个前导零，其中不是最高位的那些前导零和位数多的那个数的最高位是不满足要求的。

因此，我们就可以得出最小和的分割方法：

-   将 $num$ 的数字进行递增排序；
-   按照递增顺序，交替地将数字分配给 $num_1$ 和 $num_2$。

**代码**

```cpp
class Solution {
public:
    int splitNum(int num) {
        string stnum = to_string(num);
        sort(stnum.begin(), stnum.end());
        int num1 = 0, num2 = 0;
        for (int i = 0; i < stnum.size(); ++i) {
            if (i % 2 == 0) {
                num1 = num1 * 10 + (stnum[i] - '0');
            }
            else {
                num2 = num2 * 10 + (stnum[i] - '0');
            }
        }
        return num1 + num2;
    }
};
```

```java
class Solution {
    public int splitNum(int num) {
        char[] stnum = Integer.toString(num).toCharArray();
        Arrays.sort(stnum);
        int num1 = 0, num2 = 0;
        for (int i = 0; i < stnum.length; ++i) {
            if (i % 2 == 0) {
                num1 = num1 * 10 + (stnum[i] - '0');
            } else {
                num2 = num2 * 10 + (stnum[i] - '0');
            }
        }
        return num1 + num2;
    }
}
```

```csharp
public class Solution {
    public int SplitNum(int num) {
        char[] stnum = num.ToString().ToCharArray();
        Array.Sort(stnum);
        int num1 = 0, num2 = 0;
        for (int i = 0; i < stnum.Length; ++i) {
            if (i % 2 == 0) {
                num1 = num1 * 10 + (stnum[i] - '0');
            } else {
                num2 = num2 * 10 + (stnum[i] - '0');
            }
        }
        return num1 + num2;
    }
}
```

```python
class Solution:
    def splitNum(self, num: int) -> int:
        stnum = "".join(sorted(str(num)))
        num1, num2 = int(stnum[::2]), int(stnum[1::2])
        return num1 + num2
```

```c
static int cmp(const void *a, const void *b) {
    return *(char *)a - *(char *)b;
}

int splitNum(int num) {
    char stnum[16];
    sprintf(stnum, "%d", num);
    int len = strlen(stnum);
    qsort(stnum, len, sizeof(char), cmp);
    int num1 = 0, num2 = 0;
    for (int i = 0; i < len; ++i) {
        if (i % 2 == 0) {
            num1 = num1 * 10 + (stnum[i] - '0');
        } else {
            num2 = num2 * 10 + (stnum[i] - '0');
        }
    }
    return num1 + num2;
}
```

```go
func splitNum(num int) int {
    stnum := []byte(strconv.Itoa(num))
    sort.Slice(stnum, func(i, j int) bool {
      return stnum[i] < stnum[j]
    })
    num1, num2 := 0, 0
    for i := 0; i < len(stnum); i++ {
        if i % 2 == 0 {
            num1 = num1 * 10 + int(stnum[i] - '0')
        } else {
            num2 = num2 * 10 + int(stnum[i] - '0')
        }
    }
    return num1 + num2;
}
```

```javascript
var splitNum = function(num) {
    const stnum = [...String(num)].map(Number).sort((a, b) => a - b);
    let num1 = 0, num2 = 0;
    stnum.forEach((val, i) => {
        i % 2 == 0 ? num1 = num1 * 10 + val : num2 = num2 * 10 + val;
    });
    return num1 + num2;
};
```

**复杂度分析**

-   时间复杂度：$O(\log num \cdot \log \log num)$。$num$ 的数位个数为 $O(\log num)$，因此排序需要 $O(\log num \cdot \log \log num)$ 的时间。
-   空间复杂度：$O(\log num)$。
