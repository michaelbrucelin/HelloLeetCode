#### 方法一：枚举

**思路与算法**

题目要求我们找到一个**连续**出现 $k$ 次且长度为 $m$ 的子数组。也就是说如果这个子数组的左端点是 $l$，那么对于任意 $offset \in [0, m \times k)$，都有 $a[l + {\rm offset}] = a[l + ({\rm offset} \bmod m)]$。因此，我们可以枚举左端点 $l$，对于每个 $l$ 枚举 $offset \in [0, m \times k)$，判断是否满足条件即可。

**代码**

```cpp
class Solution {
public:
    bool containsPattern(vector<int>& arr, int m, int k) {
        int n = arr.size();
        for (int l = 0; l <= n - m * k; ++l) {
            int offset;
            for (offset = 0; offset < m * k; ++offset) {
                if (arr[l + offset] != arr[l + offset % m]) {
                    break;
                }
            }
            if (offset == m * k) {
                return true;
            }
        }
        return false;
    }
};
```

```java
class Solution {
    public boolean containsPattern(int[] arr, int m, int k) {
        int n = arr.length;
        for (int l = 0; l <= n - m * k; ++l) {
            int offset;
            for (offset = 0; offset < m * k; ++offset) {
                if (arr[l + offset] != arr[l + offset % m]) {
                    break;
                }
            }
            if (offset == m * k) {
                return true;
            }
        }
        return false;
    }
}
```

```javascript
var containsPattern = function(arr, m, k) {
    const n = arr.length;
    for (let l = 0; l <= n - m * k; ++l) {
        let offset;
        for (offset = 0; offset < m * k; ++offset) {
            if (arr[l + offset] !== arr[l + offset % m]) {
                break;
            }
        }
        if (offset === m * k) {
            return true;
        }
    }
    return false;
};
```

```python
class Solution:
    def containsPattern(self, arr: List[int], m: int, k: int) -> bool:
        n = len(arr)
        for l in range(n - m * k + 1):
            offset = 0
            while offset < m * k:
                if arr[l + offset] != arr[l + offset % m]:
                    break
                offset += 1
            if offset == m * k:
                return True
        return False
```

**复杂度分析**

-   时间复杂度：$O(n \times m \times k)$。最外层循环 $l$ 的取值个数为 $n - m \times k$，内层循环 $offset$ 的取值个数为 $m \times k$，故渐进时间复杂度为 $O((n - m \times k) \times m \times k) = O(n\times m \times k)$。
-   空间复杂度：$O(1)$。
