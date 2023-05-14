#### [方法二：计数统计](https://leetcode.cn/problems/distant-barcodes/solutions/2267110/ju-chi-xiang-deng-de-tiao-xing-ma-by-lee-31qt/)

**思路**

通过观察我们可以发现，出现次数最多的元素，会始终在最大堆的顶部，我们实际上并不需要关心其他元素的相对大小顺序。在这个思路上可以进行优化，先统计所有元素的频数，找到出现次数最多的元素，然后将出现次数最多的元素交替排列。

这个方法在实现过程，会应用不常规的小技巧，具体证明过程可以参考题目「[767\. 重构字符串的官方题解](https://leetcode.cn/problems/reorganize-string/solution/zhong-gou-zi-fu-chuan-by-leetcode-solution/)」的方法二。

首先统计每个元素的出现次数，然后根据每个元素的出现次数重构数组。

当 $n$ 是奇数且出现最多的元素的出现次数是 $\dfrac{n+1}{2}$ 时，出现次数最多的元素必须全部放置在偶数下标，否则一定会出现相邻的元素相同的情况。其余情况下，每个元素放置在偶数下标或者奇数下标都是可行的。

维护偶数下标 $evenIndex$ 和奇数下标 $oddIndex$，初始值分别为 $0$ 和 $1$。遍历每个元素，根据每个元素的出现次数判断元素应该放置在偶数下标还是奇数下标。

首先考虑是否可以放置在奇数下标。根据上述分析可知，只要元素的出现次数不超过数组的长度的一半（即出现次数小于或等于 $\Big\lfloor \dfrac{n}{2} \Big\rfloor$），就可以放置在奇数下标，只有当元素的出现次数超过数组的长度的一半时，才必须放置在偶数下标。元素的出现次数超过数组的长度的一半只可能发生在 $n$ 是奇数的情况下，且最多只有一个元素的出现次数会超过数组的长度的一半。

因此通过如下操作在重构的数组中放置元素。

-   如果元素的出现次数大于 $0$ 且小于或等于 $\Big\lfloor \dfrac{n}{2} \Big\rfloor$，且 $oddIndex$ 没有超出数组下标范围，则将元素放置在 $oddIndex$，然后将 $oddIndex$ 的值加 $2$。
-   如果元素的出现次数大于 $\Big\lfloor \dfrac{n}{2} \Big\rfloor$，或 $oddIndex$ 超出数组下标范围，则将元素放置在 $evenIndex$，然后将 $evenIndex$ 的值加 $2$。

如果一个元素出现了多次，则重复上述操作，直到该元素全部放置完毕。

**代码**

```java
class Solution {
    public static int[] rearrangeBarcodes(int[] barcodes) {
        int length = barcodes.length;
        if (length < 2) {
            return barcodes;
        }

        Map<Integer, Integer> counts = new HashMap<>();
        int maxCount = 0;
        for (int b : barcodes) {
            counts.put(b, counts.getOrDefault(b, 0) + 1);
            maxCount = Math.max(maxCount, counts.get(b));
        }

        int evenIndex = 0;
        int oddIndex = 1;
        int halfLength = length / 2;
        int[] res = new int[length];
        for (Map.Entry<Integer, Integer> entry : counts.entrySet()) {
            int x = entry.getKey();
            int count = entry.getValue();
            while (count > 0 && count <= halfLength && oddIndex < length) {
                res[oddIndex] = x;
                count--;
                oddIndex += 2;
            }
            while (count > 0) {
                res[evenIndex] = x;
                count--;
                evenIndex += 2;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] RearrangeBarcodes(int[] barcodes) {
        int length = barcodes.Length;
        if (length < 2) {
            return barcodes;
        }

        IDictionary<int, int> counts = new Dictionary<int, int>();
        int maxCount = 0;
        foreach (int b in barcodes) {
            counts.TryAdd(b, 0);
            counts[b]++;
            maxCount = Math.Max(maxCount, counts[b]);
        }

        int evenIndex = 0;
        int oddIndex = 1;
        int halfLength = length / 2;
        int[] res = new int[length];
        foreach (KeyValuePair<int, int> pair in counts) {
            int x = pair.Key;
            int count = pair.Value;
            while (count > 0 && count <= halfLength && oddIndex < length) {
                res[oddIndex] = x;
                count--;
                oddIndex += 2;
            }
            while (count > 0) {
                res[evenIndex] = x;
                count--;
                evenIndex += 2;
            }
        }
        return res;
    }
}
```

```cpp
class Solution {
public:
    vector<int> rearrangeBarcodes(vector<int>& barcodes) {
        int length = barcodes.size();
        if (length < 2) {
            return barcodes;
        }

        unordered_map<int, int> counts;
        int maxCount = 0;
        for (int b : barcodes) {
            maxCount = max(maxCount, ++counts[b]);
        }

        int evenIndex = 0, oddIndex = 1, halfLength = length / 2;
        vector<int> res(length);
        for (auto &[x, cx] : counts) {
            while (cx > 0 && cx <= halfLength && oddIndex < length) {
                res[oddIndex] = x;
                cx--;
                oddIndex += 2;
            }
            while (cx > 0) {
                res[evenIndex] = x;
                cx--;
                evenIndex += 2;
            }
        }
        return res;
    }
};
```

```python
class Solution:
    def rearrangeBarcodes(self, barcodes: List[int]) -> List[int]:
        length = len(barcodes)
        if length < 2:
            return barcodes

        counts = {}
        max_count = 0
        for b in barcodes:
            counts[b] = counts.get(b, 0) + 1
            max_count = max(max_count, counts[b])

        evenIndex = 0
        oddIndex = 1
        half_length = length // 2
        res = [0] * length
        for x, count in counts.items():
            while count > 0 and count <= half_length and oddIndex < length:
                res[oddIndex] = x
                count -= 1
                oddIndex += 2
            while count > 0:
                res[evenIndex] = x
                count -= 1
                evenIndex += 2
        return res
```

```go
func rearrangeBarcodes(barcodes []int) []int {
    if len(barcodes) < 2 {
        return barcodes
    }

    counts := make(map[int]int)
    maxCount := 0
    for _, b := range barcodes {
        counts[b] = counts[b] + 1
        if counts[b] > maxCount {
            maxCount = counts[b]
        }
    }

    evenIndex := 0
    oddIndex := 1
    halfLength := len(barcodes) / 2
    res := make([]int, len(barcodes))
    for x, count := range counts {
        for count > 0 && count <= halfLength && oddIndex < len(barcodes) {
            res[oddIndex] = x
            count--
            oddIndex += 2
        }
        for count > 0 {
            res[evenIndex] = x
            count--
            evenIndex += 2
        }
    }
    return res
}
```

```javascript
var rearrangeBarcodes = function(barcodes) {
    const length = barcodes.length;
    if (length < 2) {
        return barcodes;
    }

    const counts = new Map();
    let maxCount = 0;
    for (const b of barcodes) {
        counts.set(b, (counts.get(b) || 0) + 1);
        maxCount = Math.max(maxCount, counts.get(b));
    }

    let evenIndex = 0;
    let oddIndex = 1;
    let halfLength = Math.floor(length / 2);
    const res = _.fill(Array(length), 0);
    for (let [x, count] of counts.entries()) {
        while (count > 0 && count <= halfLength && oddIndex < length) {
            res[oddIndex] = x;
            count--;
            oddIndex += 2;
        }
        while (count > 0) {
            res[evenIndex] = x;
            count--;
            evenIndex += 2;
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是 $barcodes$ 长度。
-   空间复杂度：$O(n)$，其中 $n$ 是 $barcodes$ 长度。
