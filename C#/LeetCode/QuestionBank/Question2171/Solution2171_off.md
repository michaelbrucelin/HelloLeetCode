### [拿出最少数目的魔法豆](https://leetcode.cn/problems/removing-minimum-number-of-magic-beans/solutions/1270306/na-chu-zui-shao-shu-mu-de-mo-fa-dou-by-l-dhsl/)

#### 方法一：数学

##### 提示 $1$

我们可以将问题转化为：

> 寻找某一个数字 $x$，当我们将豆子数量小于 $x$ 的袋子清空，并将豆子数量大于 $x$ 的袋中豆子数量变为 $x$ 时，拿出的豆子数量最少。

那么，$x$ 一定等于某一个袋子的豆子数。

##### 提示 $1$ 证明

我们可以用反证法来证明上述命题。当 $x$ 不等于某一个袋子的豆子数时，我们可以分两种情况讨论：

- $x$ 大于最多袋子的豆子数：不妨设**最多**的袋子豆子数为 $y$，所有袋子豆子总数为 $total$，则：
    - $x$ 对应拿出的豆子数为 $total$；
    - $y$ 对应拿出的豆子数为 $total - y \times n_y$ ，其中 $n_y > 1$ 为豆子数为 $y$ 的袋子数量。
- $x$ 小于最多袋子的豆子数：假设豆子数量**大于** $x$ 的袋子中**最小**的豆子数量为 $y$，所有袋子豆子总数为 $total$，则：
    - $x$ 对应拿出的豆子数为 $total - x \times n_x$ ，其中 $n_x > 1$ 为豆子数大于等于 $x$ 的袋子数量；
- $y$ 对应拿出的豆子数为 $total - y \times n_y$ ，其中 $n_y = n_x$ 为豆子数大于等于 $y$ 的袋子数量。

对于上述两种情况而言，都存在至少一种等于某个袋子豆子数的情况，对应拿出的豆子数更低。

#### 思路与算法

我们不妨设 $beans$ 数组的长度为 $n$。根据**提示 $1$**，最少的豆子数量即为：

$$\min_{x \in beans} (total - x \times n_x).$$

容易发现，对于每一个 $x$，都需要 $O(n)$ 的时间复杂度计算豆子数大于等于 $x$ 的袋子数量 $n_x$ ，那么总时间复杂度为 $O(n^2)$，不符合题目要求。因此我们需要简化计算 $n_x$  的时间复杂度。

我们可以对 $beans$ 数组升序排序。那么对于排序后数组下标为 $i$ 的元素，对应的 $n_x$  即为 $n - i$。这样一来，我们只需要 $O(1)$ 的时间复杂度就可以计算出上文的每个 $n_x$ 。与此同时，上式变为：

$$\min_{0 \le i < n} (total - beans[i] \times (n - i)).$$

那么，我们只需要遍历排序后的 $beans$ 数组，并维护上式的最小值，最终将最小值返回作为答案即可。

##### 细节

在计算最小值的过程中，$total$ 和 $beans[i] \times (n - i)$ 都有可能超过 $32$ 位有符号整数的上界，因此对于 $\texttt{C++}$ 等语言，我们需要使用 $64$ 位整数来维护并计算上述变量与最小值。

##### 代码

```c++
class Solution {
public:
    long long minimumRemoval(vector<int>& beans) {
        int n = beans.size();
        sort(beans.begin(), beans.end());
        long long total = accumulate(beans.begin(), beans.end(), 0LL); // 豆子总数
        long long res = total; // 最少需要移除的豆子数
        for (int i = 0; i < n; i++) {
            res = min(res, total - (long long)beans[i] * (n - i));
        }
        return res;
    }
};
```

```python
class Solution:
    def minimumRemoval(self, beans: List[int]) -> int:
        n = len(beans)
        beans.sort()
        total = sum(beans) # 豆子总数
        res = total # 最少需要移除的豆子数
        for i in range(n):
            res = min(res, total - beans[i] * (n - i))
        return res
```

```go
func minimumRemoval(beans []int) int64 {
    n := len(beans)
    sort.Ints(beans)
    total := int64(0) // 豆子总数
    for _, bean := range beans {
        total += int64(bean)
    }
    res := total // 最少需要移除的豆子数
    for i := 0; i < n; i++ {
        res = min(res, total - int64(beans[i]) * int64(n - i))
    }
    return res
}
```

```c
int cmp(const void *p1, const void *p2) {
    return *(const int *)p1 - *(const int *)p2;
}

long long minimumRemoval(int* beans, int beansSize){
    qsort(beans, beansSize, sizeof(int), cmp);
    long long total = 0; // 豆子总数
    for (int i = 0; i < beansSize; i++) {
        total += beans[i];
    }
    long long res = total; // 最少需要移除的豆子数
    for (int i = 0; i < beansSize; i++) {
        long long t = total - (long long)beans[i] * (beansSize - i);
        res = res > t ? t : res;
    }
    return res;
}
```

```java
class Solution {
    public long minimumRemoval(int[] beans) {
        int n = beans.length;
        Arrays.sort(beans);
        long total = 0; // 豆子总数
        for (int i = 0; i < n; i++) {
            total += beans[i];
        }
        long res = total; // 最少需要移除的豆子数
        for (int i = 0; i < n; i++) {
            res = Math.min(res, total - (long) beans[i] * (n - i));
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public long MinimumRemoval(int[] beans) {
        int n = beans.Length;
        Array.Sort(beans);
        long total = 0; // 豆子总数
        for (int i = 0; i < n; i++) {
            total += beans[i];
        }
        long res = total; // 最少需要移除的豆子数
        for (int i = 0; i < n; i++) {
            res = Math.Min(res, total - (long) beans[i] * (n - i));
        }
        return res;
    }
}
```

```javascript
var minimumRemoval = function(beans) {
    let n = beans.length
    beans.sort((a, b) => a - b);
    let total = beans.reduce((a, b) => a + b, 0); // 豆子总数
    let res = total; // 最少需要移除的豆子数
    for (let i = 0; i < n; i++) {
        res = Math.min(res, total - beans[i] * (n - i));
    }
    return res;
};
```

```typescript
function minimumRemoval(beans: number[]): number {
    let n = beans.length
    beans.sort((a, b) => a - b);
    let total = beans.reduce((a, b) => a + b, 0); // 豆子总数
    let res = total; // 最少需要移除的豆子数
    for (let i = 0; i < n; i++) {
        res = Math.min(res, total - beans[i] * (n - i));
    }
    return res;
};
```

#### 复杂度分析

- 时间复杂度：$O(n \log n)$，其中 $n$ 为 $beans$ 数组的长度。即为排序的时间复杂度。
- 空间复杂度：$O(\log n)$，即为排序的栈空间开销。
