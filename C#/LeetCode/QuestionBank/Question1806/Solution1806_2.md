#### [方法一：直接模拟](https://leetcode.cn/problems/minimum-number-of-operations-to-reinitialize-a-permutation/solutions/2051628/huan-yuan-pai-lie-de-zui-shao-cao-zuo-bu-d9cn/)

**思路与算法**

题目要求，一步操作中，对于每个索引 $i$，变换规则如下：

-   如果 $i$ 为偶数，那么 $arr[i] = perm[\dfrac{i}{2}]$；
-   如果 $i$ 为奇数，那么 $arr[i] = perm[\dfrac{n}{2} + \dfrac{i-1}{2}]$；

然后将 $arr$ 赋值给 $perm$。

我们假设初始序列 $perm = [0,1,2,\cdots,n-1]$，按照题目上述要求的变换规则进行模拟，直到 $perm$ 重新变回为序列 $[0,1,2,\cdots,n-1]$ 为止。每次将 $perm$ 按照上述规则变化产生数组 $arr$，并将 $arr$ 赋给 $perm$，然后我们检测 $perm$ 是否回到原始状态并计数，如果回到原始状态则中止变换，否则继续变换。

**代码**

```python
class Solution:
    def reinitializePermutation(self, n: int) -> int:
        perm = list(range(n))
        target = perm.copy()
        step = 0
        while True:
            step += 1
            perm = [perm[n // 2 + (i - 1) // 2] if i % 2 else perm[i // 2] for i in range(n)]
            if perm == target:
                return step
```

```cpp
class Solution {
public:
    int reinitializePermutation(int n) {
        vector<int> perm(n), target(n);
        iota(perm.begin(), perm.end(), 0);
        iota(target.begin(), target.end(), 0);
        int step = 0;
        while (true) {
            vector<int> arr(n);
            for (int i = 0; i < n; i++) {
                if (i & 1) {
                    arr[i] = perm[n / 2 + (i - 1) / 2];
                } else {
                    arr[i] = perm[i / 2];
                }
            }
            perm = move(arr);
            step++;
            if (perm == target) {
                break;
            }
        }
        return step;
    }
};
```

```java
class Solution {
    public int reinitializePermutation(int n) {
        int[] perm = new int[n];
        int[] target = new int[n];
        for (int i = 0; i < n; i++) {
            perm[i] = i;
            target[i] = i;
        }
        int step = 0;
        while (true) {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) {
                if ((i & 1) != 0) {
                    arr[i] = perm[n / 2 + (i - 1) / 2];
                } else {
                    arr[i] = perm[i / 2];
                }
            }
            perm = arr;
            step++;
            if (Arrays.equals(perm, target)) {
                break;
            }
        }
        return step;
    }
}
```

```csharp
public class Solution {
    public int ReinitializePermutation(int n) {
        int[] perm = new int[n];
        int[] target = new int[n];
        for (int i = 0; i < n; i++) {
            perm[i] = i;
            target[i] = i;
        }
        int step = 0;
        while (true) {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) {
                if ((i & 1) != 0) {
                    arr[i] = perm[n / 2 + (i - 1) / 2];
                } else {
                    arr[i] = perm[i / 2];
                }
            }
            perm = arr;
            step++;
            if (Enumerable.SequenceEqual(perm, target)) {
                break;
            }
        }
        return step;
    }
}
```

```c
int reinitializePermutation(int n) {
    int perm[n], arr[n], target[n];
    for (int i = 0; i < n; i++) {
        perm[i] = i;
        target[i] = i;
    }
    int step = 0;
    int *pArr = arr, *pPerm = perm;
    while (true) {
        for (int i = 0; i < n; i++) {
            if (i & 1) {
                pArr[i] = pPerm[n / 2 + (i - 1) / 2];
            } else {
                pArr[i] = pPerm[i / 2];
            }
        }
        int *tmp = pArr;
        pArr = pPerm;
        pPerm = tmp;
        step++;
        if (memcmp(pPerm, target, sizeof(int) * n) == 0) {
            break;
        }
    }
    return step;
}
```

```javascript
var reinitializePermutation = function(n) {
    let perm = new Array(n).fill(0).map((_, i) => i);
    const target = new Array(n).fill(0).map((_, i) => i);
    let step = 0;
    while (true) {
        const arr = new Array(n).fill(0);
        for (let i = 0; i < n; i++) {
            if ((i & 1) !== 0) {
                arr[i] = perm[Math.floor(n / 2) + Math.floor((i - 1) / 2)];
            } else {
                arr[i] = perm[Math.floor(i / 2)];
            }
        }
        perm = arr;
        step++;
        if (perm.toString() === target.toString()) {
            break;
        }
    }
    return step;
};
```

```go
func reinitializePermutation(n int) (step int) {
    target := make([]int, n)
    for i := range target {
        target[i] = i
    }
    perm := append([]int(nil), target...)
    for {
        step++
        arr := make([]int, n)
        for i := range arr {
            if i%2 == 0 {
                arr[i] = perm[i/2]
            } else {
                arr[i] = perm[n/2+i/2]
            }
        }
        perm = arr
        if equal(perm, target) {
            return
        }
    }
}

func equal(a, b []int) bool {
    for i, x := range a {
        if x != b[i] {
            return false
        }
    }
    return true
}
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 表示给定的元素。根据方法二的推论可以知道最多需要经过 $n$ 次变换即可回到初始状态，每次变换需要的时间复杂度为 $O(n)$，因此总的时间复杂度为 $O(n^2)$。
-   空间复杂度：$O(n)$，其中 $n$ 表示给定的元素。我们需要存储每次变换中的过程变量，需要的空间为 $O(n)$。
