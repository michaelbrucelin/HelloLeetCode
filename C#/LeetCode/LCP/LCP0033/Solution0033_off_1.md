#### [方法一：贪心 + 数学](https://leetcode.cn/problems/o8SXZn/solutions/2276388/xu-shui-by-leetcode-solution-g4lx/)

**思路与算法**

题目给出 $n$ 个无限容量且初始均空的水缸，每个水缸配有一个对应的水桶用来打水，其中第 $i$ 个水缸配备的水桶容量为 $bucket[i]$，对应的最低蓄水量为 $vat[i]$。现在我们有以下两种操作：

-   「升级水桶」：选择任意一个水桶，使其容量加一。
-   「蓄水」：将全部水桶接满水，倒入各自对应的水缸。

现在我们需要返回能使全部水缸完成蓄水要求的最少操作次数。首先显然应该把所有「升级水桶」的操作放在「蓄水」之前，这样每次蓄水时的增益是最大的。那么若当前已知最终需要「蓄水」次数为 $k$，则对于第 $i$ 个水缸配备的水桶在「蓄水」操作前的容量 $m_i$ 至少应该达到

$$m_i = \lceil{\frac{vat[i]}{k}}\rceil$$

其中 $\lceil{x}\rceil$ 表示对 $x$ 向上取整。此时对于第 $i$ 个水桶需要的「升级水桶」操作次数为 $\max\{0, m_i - bucket[i]\}$。所以总的操作次数为

$$k + \sum_{j=0}^{n-1}{\max\{0, m_j - bucket[j]\}}$$

那么我们枚举「蓄水」操作次数的 $k$ 即可。其中「蓄水」操作次数一定不会大于全部水缸的最大最低蓄水量。并且当 $k$ 大于等于当前已经得到的最少操作总次数时，可以提前结束枚举。

**代码**

```cpp
class Solution {
public:
    int storeWater(vector<int>& bucket, vector<int>& vat) {
        int n = bucket.size();
        int maxk = *max_element(vat.begin(), vat.end());
        if (maxk == 0) {
            return 0;
        }
        int res = INT_MAX;
        for (int k = 1; k <= maxk && k < res; ++k) {
            int t = 0;
            for (int i = 0; i < bucket.size(); ++i) {
                t += max(0, (vat[i] + k - 1) / k - bucket[i]);
            }
            res = min(res, t + k);
        }
        return res;
    }
};
```

```java
class Solution {
    public int storeWater(int[] bucket, int[] vat) {
        int n = bucket.length;
        int maxk = Arrays.stream(vat).max().getAsInt();
        if (maxk == 0) {
            return 0;
        }
        int res = Integer.MAX_VALUE;
        for (int k = 1; k <= maxk && k < res; ++k) {
            int t = 0;
            for (int i = 0; i < bucket.length; ++i) {
                t += Math.max(0, (vat[i] + k - 1) / k - bucket[i]);
            }
            res = Math.min(res, t + k);
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int StoreWater(int[] bucket, int[] vat) {
        int n = bucket.Length;
        int maxk = vat.Max();
        if (maxk == 0) {
            return 0;
        }
        int res = int.MaxValue;
        for (int k = 1; k <= maxk && k < res; ++k) {
            int t = 0;
            for (int i = 0; i < bucket.Length; ++i) {
                t += Math.Max(0, (vat[i] + k - 1) / k - bucket[i]);
            }
            res = Math.Min(res, t + k);
        }
        return res;
    }
}
```

```python
class Solution:
    def storeWater(self, bucket: List[int], vat: List[int]) -> int:
        n = len(bucket)
        maxk = max(vat)
        if maxk == 0:
            return 0
        res = float('inf')
        for k in range(1, maxk + 1):
            t = 0
            for i in range(n):
                t += max(0, (vat[i] + k - 1) // k - bucket[i])
            res = min(res, t + k)
        return res
```

```go
func storeWater(bucket []int, vat []int) int {
    n := len(bucket)
    maxk := 0
    for _, v := range vat {
        if v > maxk {
            maxk = v
        }
    }
    if maxk == 0 {
        return 0
    }
    res := math.MaxInt32
    for k := 1; k <= maxk && k < res; k++ {
        t := 0
        for i := 0; i < n; i++ {
            t += max(0, (vat[i] + k - 1) / k - bucket[i])
        }
        res = min(res, t+k)
    }
    return res
}

func max(x, y int) int {
    if x > y {
        return x
    }
    return y
}

func min(x, y int) int {
    if x < y {
        return x
    }
    return y
}
```

```c
static int max(int a, int b) {
    return a > b ? a : b;
}

static int min(int a, int b) {
    return a < b ? a : b;
}

int storeWater(int* bucket, int bucketSize, int* vat, int vatSize) {
    int maxk = 0;
    for (int i = 0; i < vatSize; i++) {
        maxk = max(maxk, vat[i]);
    }
    if (maxk == 0) {
        return 0;
    }
    int res = INT_MAX;
    for (int k = 1; k <= maxk && k < res; ++k) {
        int t = 0;
        for (int i = 0; i < bucketSize; ++i) {
            t += max(0, (vat[i] + k - 1) / k - bucket[i]);
        }
        res = min(res, t + k);
    }
    return res;
}
```

```javascript
var storeWater = function(bucket, vat) {
    const maxk = _.max(vat);
    if (maxk === 0) {
        return 0;
    }
    let res = Number.MAX_VALUE;
    for (let k = 1; k <= maxk && k < res; ++k) {
        let t = 0;
        for (let i = 0; i < bucket.length; ++i) {
            t += Math.max(0, Math.floor((vat[i] + k - 1) / k - bucket[i]));
        }
        res = Math.min(res, t + k);
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n \times C)$，其中 $n$ 为数组 $bucket$ 的长度，$C$ 为数组 $vat$ 的范围。
-   空间复杂度：$O(1)$，仅使用常量空间。
