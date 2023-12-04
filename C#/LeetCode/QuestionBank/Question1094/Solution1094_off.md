### [拼车](https://leetcode.cn/problems/car-pooling/solutions/2546591/pin-che-by-leetcode-solution-scp6/)

#### 方法一：差分数组

**思路与算法**

由于车的位置范围为 $[0, 1000]$，那么我们可以使用一个长度为 $1000$ 的数组 $count$ 来记录每一个位置时的乘客数量。对于一个给定的 $trips_i = (num_i, from_i, to_i)$，我们将

$$count[from_i], count[from_i + 1], \cdots, count[to_i - 1] \tag{1}$$

均增加 $num_i$。这样一来，当我们枚举完整个数组 $trips$ 后，数组 $count$ 中的最大值即为需要的座位数量，我们将其与 $capacity$ 进行比较，即可得到答案。

然而这样做的时间复杂度较高（虽仍然可以通过本题），我们可以使用差分数组来进行优化。

差分数组是前缀和的逆运算。我们用数组 $diff$ 表示数组 $count$ 的差分数组，那么：

$$\begin{cases} count[0] = diff[0] \\ count[1] = diff[0] + diff[1] \\ count[2] = diff[0] + diff[1] + diff[2] \\ \cdots \\ count[k] = diff[0] + diff[1] + diff[2] + \cdots + diff[k] \\ \cdots \\ \end{cases}$$

也就是：

$$diff[k] = \begin{cases} count[0], \quad & k = 0 \\ count[k] - count[k - 1], \quad & k > 0 \\ \end{cases} \tag{2}$$

如果我们能维护数组 $diff$，那么最终我们只需要求出它的每一个前缀和，就可以得到数组 $count$。

对于给定的 $trips_i = (num_i, from_i, to_i)$，当我们将 $(1)$ 中的元素增加 $num_i$ 时，根据 $(2)$ 中的定义：

-   当 $k < from_i$ 时，$diff[k]$ 的值不变；
-   当 $k = from_i$ 时，$diff[k]$ 的值增加 $num_i$；
-   当 $from_i < k < to_i$ 时，$diff[k]$ 的值不变；
-   当 $k = to_i$ 时，$diff[k]$ 的值减少 $num_i$；
-   当 $k > to_i$ 时，$diff[k]$ 的值不变。

因此，我们只需要 $2$ 次操作即可完成对差分数组 $diff$ 的修改：将 $diff[from_i]$ 的值增加 $num_i$，并将 $diff[to_i]$ 的值减少 $num_i$。这样就可以将处理 $trips_i$ 的时间复杂度减少至 $O(1)$。

**细节**

我们可以预先对数组 $trips$ 进行一次遍历，得到所有 $to_i$ 中的最大值 $to_{\max}$，差分数组的最大下标只需要到 $to_{\max}$。

**代码**

```c++
class Solution {
public:
    bool carPooling(vector<vector<int>>& trips, int capacity) {
        int to_max = 0;
        for (const auto& trip: trips) {
            to_max = max(to_max, trip[2]);
        }

        vector<int> diff(to_max + 1);
        for (const auto& trip: trips) {
            diff[trip[1]] += trip[0];
            diff[trip[2]] -= trip[0];
        }

        int count = 0;
        for (int i = 0; i <= to_max; ++i) {
            count += diff[i];
            if (count > capacity) {
                return false;
            }
        }
        return true;
    }
};
```

```java
class Solution {
    public boolean carPooling(int[][] trips, int capacity) {
        int toMax = 0;
        for (int[] trip : trips) {
            toMax = Math.max(toMax, trip[2]);
        }

        int[] diff = new int[toMax + 1];
        for (int[] trip : trips) {
            diff[trip[1]] += trip[0];
            diff[trip[2]] -= trip[0];
        }

        int count = 0;
        for (int i = 0; i <= toMax; ++i) {
            count += diff[i];
            if (count > capacity) {
                return false;
            }
        }
        return true;
    }
}
```

```csharp
public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        int toMax = 0;
        foreach (int[] trip in trips) {
            toMax = Math.Max(toMax, trip[2]);
        }

        int[] diff = new int[toMax + 1];
        foreach (int[] trip in trips) {
            diff[trip[1]] += trip[0];
            diff[trip[2]] -= trip[0];
        }

        int count = 0;
        for (int i = 0; i <= toMax; ++i) {
            count += diff[i];
            if (count > capacity) {
                return false;
            }
        }
        return true;
    }
}
```

```python
class Solution:
    def carPooling(self, trips: List[List[int]], capacity: int) -> bool:
        to_max = max(trip[2] for trip in trips)
        diff = [0] * (to_max + 1)
        for num_i, from_i, to_i in trips:
            diff[from_i] += num_i
            diff[to_i] -= num_i
        
        count = 0
        for i in range(to_max + 1):
            count += diff[i]
            if count > capacity:
                return False
        
        return True
```

```go
func carPooling(trips [][]int, capacity int) bool {
    toMax := 0
    for _, trip := range trips {
        toMax = max(toMax, trip[2])
    }
    
    diff := make([]int, toMax + 1)
    for _, trip := range trips {
        diff[trip[1]] += trip[0]
        diff[trip[2]] -= trip[0]
    }

    count := 0
    for i := 0; i < toMax; i++ {
        count += diff[i]
        if count > capacity {
            return false
        }
    }
    return true
}
```

```c
bool carPooling(int **trips, int tripsSize, int *tripsColSize, int capacity) {
    int toMax = 0;
    for (int i = 0; i < tripsSize; i++) {
        if (toMax < trips[i][2]) {
            toMax = trips[i][2];
        }
    }

    int *diff = malloc(sizeof(int) * (toMax + 1));
    memset(diff, 0, sizeof(int) * (toMax + 1));
    for (int i = 0; i < tripsSize; i++) {
        diff[trips[i][1]] += trips[i][0];
        diff[trips[i][2]] -= trips[i][0];
    }

    int count = 0;
    for (int i = 0; i < toMax; i++) {
        count += diff[i];
        if (count > capacity) {
            return false;
        }
    }
    free(diff);
    return true;
}
```

```javascript
var carPooling = function(trips, capacity) {
    let to_max = 0;
    for (const trip of trips) {
        to_max = Math.max(to_max, trip[2]);
    }

    const diff = new Array(to_max + 1).fill(0);
    for (const trip of trips) {
        diff[trip[1]] += trip[0];
        diff[trip[2]] -= trip[0];
    }

    let count = 0;
    for (let i = 0; i <= to_max; ++i) {
        count += diff[i];
        if (count > capacity) {
            return false;
        }
    }
    return true;
};
```

**复杂度分析**

-   时间复杂度：$O(n + l)$，其中 $n$ 是数组 $trips$ 的长度，$l$ 是 $to_i$ 中的最大值。
-   空间复杂度：$O(l)$，即为差分数组 $diff$ 需要使用的空间。
